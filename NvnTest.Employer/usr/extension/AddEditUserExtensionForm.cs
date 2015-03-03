using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditUserExtensionForm : Form {
        private TestService.UserExtension userExtension;

        public AddEditUserExtensionForm() {
            InitializeComponent();
        }

        public TestService.UserExtension UserExtension {
            get { return userExtension; }
            set { userExtension = value; }
        }

        public void LoadForm() {
            if (userExtension != null) {
                txtFirstName.Text = userExtension.FirstName;
                txtLastName.Text = userExtension.LastName;
                txtEmail.Text = userExtension.Email;
                txtNote.Text = userExtension.Note;
                txtPassword.Text = userExtension.Password;

                switch (userExtension.SchedulesPrivilege) {
                    case TestService.PrivilegeType.None: rbSchedulePrivilegeNone.Checked = true; break;
                    case TestService.PrivilegeType.View: rbSchedulePrivilegeViewOnly.Checked = true; break;
                }

                switch (userExtension.PapersPrivilege) {
                    case TestService.PrivilegeType.None: rbPapersPrivilegeNone.Checked = true; break;
                    case TestService.PrivilegeType.View: rbPapersPrivilegeViewOnly.Checked = true; break;
                    case TestService.PrivilegeType.Edit: rbPapersPrivilegeAddEdit.Checked = true; break;
                }

                switch (userExtension.QuestionsPrivilege) {
                    case TestService.PrivilegeType.None: rbQuestionsPrivilegeNone.Checked = true; break;
                    case TestService.PrivilegeType.View: rbQuestionsPrivilegeViewOnly.Checked = true; break;
                    case TestService.PrivilegeType.Edit: rbQuestionsPrivilegeAddEdit.Checked = true; break;
                }
            }

            txtPassword.Enabled = userExtension == null;
        }

        private void btnSetPassword_Click(object sender, EventArgs e) {
            txtPassword.Text = string.Empty;
            txtPassword.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidateInput() == false) return;

            if (userExtension == null) {
                userExtension = new TestService.UserExtension();
                userExtension.AdminId = ServiceManager.Instance.UserInfo.Id;
            }

            userExtension.FirstName = txtFirstName.Text;
            userExtension.LastName = txtLastName.Text;
            userExtension.Note = txtNote.Text;
            userExtension.Email = txtEmail.Text;
            userExtension.Password = txtPassword.Text;

            if (rbSchedulePrivilegeNone.Checked) userExtension.SchedulesPrivilege = TestService.PrivilegeType.None;
            else if (rbSchedulePrivilegeViewOnly.Checked) userExtension.SchedulesPrivilege = TestService.PrivilegeType.View;

            if (rbPapersPrivilegeNone.Checked) userExtension.PapersPrivilege = TestService.PrivilegeType.None;
            else if (rbPapersPrivilegeViewOnly.Checked) userExtension.PapersPrivilege = TestService.PrivilegeType.View;
            else if (rbPapersPrivilegeAddEdit.Checked) userExtension.PapersPrivilege = TestService.PrivilegeType.Edit;

            if (rbQuestionsPrivilegeNone.Checked) userExtension.QuestionsPrivilege = TestService.PrivilegeType.None;
            else if (rbQuestionsPrivilegeViewOnly.Checked) userExtension.QuestionsPrivilege = TestService.PrivilegeType.View;
            else if (rbQuestionsPrivilegeAddEdit.Checked) userExtension.QuestionsPrivilege = TestService.PrivilegeType.Edit;

            bool success = ServiceManager.Instance.UpdateUserExtension(userExtension);
            if (success) {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private bool ValidateInput() {
            if (InputValidator.ValueNotEmpty("First Name", txtFirstName.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Last Name", txtLastName.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Email", txtEmail.Text) == false) return false;
            if (InputValidator.ValueNotEmpty("Password", txtPassword.Text) == false) return false;

            if (InputValidator.ValidEmailFormat(txtEmail.Text) == false) return false;

            return true;
        }
    }
}
