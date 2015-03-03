using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class AddEditTestScheduleForm : Form {
        private TestService.TestSchedule testSchedule;
        private bool assignToYourself;
        
        public AddEditTestScheduleForm() {
            InitializeComponent();
        }

        public TestService.TestSchedule TestSchedule {
            get { return testSchedule; }
            set { testSchedule = value; }
        }

        public bool AssignToYourself {
            get { return assignToYourself; }
            set { assignToYourself = value; }
        }

        public void LoadForm() {
            if (testSchedule != null && assignToYourself == false) {
                txtFirstName.Text = testSchedule.FirstName;
                txtLastName.Text = testSchedule.LastName;
                txtEmail.Text = testSchedule.Email;
                txtConfirmEmail.Text = testSchedule.Email;
                txtEmail.Enabled = txtConfirmEmail.Enabled = false;
                numDaysLeft.Value = testSchedule.DaysLimit;
                dtDuration.Value = (new DateTime(2000, 01, 01, 0, 0, 0)).AddMinutes(testSchedule.Duration);
                chkLiveImages.Checked = testSchedule.LiveImage;
                chkWebReference.Checked = testSchedule.WebReference;
            }

            //TODO: web service can be hacked... Carefull !!!!
            if (assignToYourself) {
                txtFirstName.Text = ServiceManager.Instance.UserInfo.FirstName;
                txtLastName.Text = ServiceManager.Instance.UserInfo.LastName;
                txtEmail.Text = ServiceManager.Instance.UserInfo.Email;
                txtConfirmEmail.Text = ServiceManager.Instance.UserInfo.Email;
                dtDuration.Value = new DateTime(2000, 01, 01, 01, 0, 0);
                txtFirstName.Enabled = txtLastName.Enabled = txtEmail.Enabled = txtConfirmEmail.Enabled = false;
            }

            // load test papers
            foreach (uint key in ServiceManager.Instance.Papers.Keys) {
                TestService.Paper paper = ServiceManager.Instance.Papers[key];
                if (paper.IsAuto == false) {
                    int index = dgrPapers.Rows.Add();
                    dgrPapers[PaperDescCol.Name, index].Value = paper.Name;
                    dgrPapers[PaperTypeColumn.Name, index].Value = "Manual";
                    dgrPapers.Rows[index].Tag = paper;
                }
            }

            // load auto test papers
            foreach (uint key in ServiceManager.Instance.AutoPapers.Keys) {
                TestService.AutoPaper paper = ServiceManager.Instance.AutoPapers[key];
                int index = dgrPapers.Rows.Add();
                dgrPapers[PaperDescCol.Name, index].Value = paper.Name;
                dgrPapers[PaperTypeColumn.Name, index].Value = "Auto";
                dgrPapers.Rows[index].Tag = paper;
            }

            btnSave.Enabled = ServiceManager.Instance.UserInfo.UserExtension == null;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (testSchedule == null) {
                testSchedule = new TestService.TestSchedule();
                testSchedule.TempId = Guid.NewGuid().ToString().Replace("-", "");
                testSchedule.AdminId = ServiceManager.Instance.UserInfo.Id;
            }

            testSchedule.FirstName = txtFirstName.Text;
            testSchedule.LastName = txtLastName.Text;
            testSchedule.Email = txtEmail.Text;
            testSchedule.DaysLimit = Convert.ToUInt32(numDaysLeft.Value);
            testSchedule.Duration = (uint)(dtDuration.Value.Hour * 60 + dtDuration.Value.Minute);
            testSchedule.LiveImage = chkLiveImages.Checked;
            testSchedule.WebReference = chkWebReference.Checked;

            if (dgrPapers.SelectedRows[0].Tag is TestService.Paper) {
                testSchedule.PaperId = ((TestService.Paper)dgrPapers.SelectedRows[0].Tag).Id;
            } else if (dgrPapers.SelectedRows[0].Tag is TestService.AutoPaper) {
                TestService.AutoPaper autoPaper = (TestService.AutoPaper)dgrPapers.SelectedRows[0].Tag;
                TestService.Paper newPaper = (TestService.Paper)ServiceManager.Instance.CreatePaperByAutoPaper(autoPaper);
                testSchedule.PaperId = newPaper.Id;
            }

            object response = ServiceManager.Instance.UpdateTestSchedule(testSchedule);
            if (response != null) {
                testSchedule = (TestService.TestSchedule)response;
                if (ServiceManager.Instance.Schedules.ContainsKey(testSchedule.Id) == false) {
                    ServiceManager.Instance.Schedules.Add(testSchedule.Id, testSchedule);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidInput() {
            //Validate whether all input fields given
            if (InputValidator.ValueNotEmpty("First name", txtFirstName.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Last name", txtLastName.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Email", txtEmail.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Confirm email", txtConfirmEmail.Text) == false) return false;

            // Valid input length
            if (InputValidator.ValidStringLength("First name", txtFirstName.Text, 40) == false) return false;
            if (InputValidator.ValidStringLength("Last name", txtLastName.Text, 40) == false) return false;
            if (InputValidator.ValidStringLength("Email", txtEmail.Text, 200) == false) return false;
            if (InputValidator.ValidStringLength("Confirm email", txtConfirmEmail.Text, 200) == false) return false;

            //Check email in valid format
            if (InputValidator.ValidEmailFormat(txtEmail.Text) == false) return false;

            //Compare emails
            if (InputValidator.CompareValues("Emails", txtEmail.Text, txtConfirmEmail.Text) == false) return false;

            //Check for valid duration
            int duration = (dtDuration.Value.Hour * 60 + dtDuration.Value.Minute);
            if (InputValidator.ValidRange("Test duration (in minutes)", 10, 300, duration) == false) return false;

            return true; 
        }
    }
}
