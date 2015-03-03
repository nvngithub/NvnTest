using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditAutoPaperForm : Form {
        private TestService.AutoPaper paper;

        public AddEditAutoPaperForm() {
            InitializeComponent();
        }

        public TestService.AutoPaper Paper {
            get { return paper; }
            set { paper = value; }
        }

        public void LoadForm() {
            if (paper == null) return;

            txtPaperName.Text = paper.Name;
            txtDescription.Text = paper.Desc;
            string[] items = paper.Configs.Split("~".ToCharArray());
            foreach (string item in items) {
                AutoPaperConfigItemCtrl ctrl = new AutoPaperConfigItemCtrl();
                ctrl.DeleteItemClicked += new EventHandler(ctrl_DeleteItemClicked);
                ctrl.Config = item;
                ctrl.LoadControl();
                pnlCriterias.Controls.Add(ctrl);
            }
        }

        private void btnAddNewCriteria_Click(object sender, EventArgs e) {
            AutoPaperConfigItemCtrl ctrl = new AutoPaperConfigItemCtrl();
            ctrl.DeleteItemClicked += new EventHandler(ctrl_DeleteItemClicked);
            pnlCriterias.Controls.Add(ctrl);
        }

        private void ctrl_DeleteItemClicked(object sender, EventArgs e) {
            AutoPaperConfigItemCtrl ctrl = (AutoPaperConfigItemCtrl)sender;
            
            if (pnlCriterias.Controls.Contains(ctrl)) {
                pnlCriterias.Controls.Remove(ctrl);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (paper == null) {
                paper = new TestService.AutoPaper();
                paper.TempId = Guid.NewGuid().ToString().Replace("-", "");
                paper.AdminId = ServiceManager.Instance.UserInfo.Id;
            }

            paper.Name = txtPaperName.Text;
            paper.Desc = txtDescription.Text;

            List<string> configs = new List<string>();
            foreach (AutoPaperConfigItemCtrl ctrl in pnlCriterias.Controls) {
                string config = ctrl.Config;
                if (String.IsNullOrEmpty(config)) {
                    return;
                }

                configs.Add(config);
            }
            paper.Configs = String.Join("~", configs.ToArray());

            object response = ServiceManager.Instance.UpdateAutoPaper(paper);
            if (response != null) {
                paper = (TestService.AutoPaper)response;
                if (ServiceManager.Instance.AutoPapers.ContainsKey(paper.Id) == false) {
                    ServiceManager.Instance.AutoPapers.Add(paper.Id, paper);
                } else {
                    ServiceManager.Instance.AutoPapers[paper.Id] = paper;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private bool ValidInput() {
            if (String.IsNullOrEmpty(txtPaperName.Text)) {
                MessageBox.Show("Paper name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtDescription.Text)) {
                MessageBox.Show("Paper description is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
