using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class UserExtensionsForm : Form {
        private TestService.UserExtension[] userExtensions;

        public UserExtensionsForm() {
            InitializeComponent();
        }

        public TestService.UserExtension[] UserExtensions {
            set { userExtensions = value; }
        }

        public void LoadForm() {
            dgrUserExtensions.Rows.Clear();
            if (userExtensions != null && userExtensions.Length > 0) {
                foreach (TestService.UserExtension userExtension in userExtensions) {
                    AddUserExtensionToGrid(userExtension);
                }
            }
        }

        private void AddUserExtensionToGrid(TestService.UserExtension userExtension) {
            int index = dgrUserExtensions.Rows.Add();
            UpdateUserExtensionOnGrid(userExtension, index);
        }

        private void UpdateUserExtensionOnGrid(TestService.UserExtension userExtension, int index) {
            dgrUserExtensions[NameCol.Index, index].Value = userExtension.FirstName + " " + userExtension.LastName;
            dgrUserExtensions[EmailCol.Index, index].Value = userExtension.Email;

            switch (userExtension.SchedulesPrivilege) {
                case TestService.PrivilegeType.None: dgrUserExtensions[SchedulesPrivilegeCol.Index, index].Value = "None"; break;
                case TestService.PrivilegeType.View: dgrUserExtensions[SchedulesPrivilegeCol.Index, index].Value = "View Only"; break;
                case TestService.PrivilegeType.Edit: dgrUserExtensions[SchedulesPrivilegeCol.Index, index].Value = "Add/Edit"; break;
            }

            switch (userExtension.PapersPrivilege) {
                case TestService.PrivilegeType.None: dgrUserExtensions[PapersPrivilegeCol.Index, index].Value = "None"; break;
                case TestService.PrivilegeType.View: dgrUserExtensions[PapersPrivilegeCol.Index, index].Value = "View Only"; break;
                case TestService.PrivilegeType.Edit: dgrUserExtensions[PapersPrivilegeCol.Index, index].Value = "Add/Edit"; break;
            }

            switch (userExtension.QuestionsPrivilege) {
                case TestService.PrivilegeType.None: dgrUserExtensions[QuestionsPrivilegeCol.Index, index].Value = "None"; break;
                case TestService.PrivilegeType.View: dgrUserExtensions[QuestionsPrivilegeCol.Index, index].Value = "View Only"; break;
                case TestService.PrivilegeType.Edit: dgrUserExtensions[QuestionsPrivilegeCol.Index, index].Value = "Add/Edit"; break;
            }

            dgrUserExtensions[EditCol.Index, index].Value = "Edit";
            dgrUserExtensions[DeleteCol.Index, index].Value = "Delete";

            dgrUserExtensions.Rows[index].Tag = userExtension;
        }

        private void dgrUserExtensions_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == EditCol.Index) {
                AddEditUserExtensionForm addEditUserExtensionForm = new AddEditUserExtensionForm();
                addEditUserExtensionForm.UserExtension = (TestService.UserExtension)dgrUserExtensions.Rows[e.RowIndex].Tag;
                addEditUserExtensionForm.LoadForm();

                if (addEditUserExtensionForm.ShowDialog() == DialogResult.OK) {
                    UpdateUserExtensionOnGrid(addEditUserExtensionForm.UserExtension, e.RowIndex);
                }
            } else if (e.ColumnIndex == DeleteCol.Index) {
                TestService.UserExtension userExtension = (TestService.UserExtension)dgrUserExtensions.Rows[e.RowIndex].Tag;
                if (MessageBox.Show("Are you sure you want to remove user: " + userExtension.FirstName + " " + userExtension.LastName + " ?", "Delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                    bool success = ServiceManager.Instance.RemoveUserExtension(userExtension);
                    if (success) {
                        dgrUserExtensions.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e) {
            AddEditUserExtensionForm addEditUserExtensionForm = new AddEditUserExtensionForm();
            if (addEditUserExtensionForm.ShowDialog() == DialogResult.OK) {
                AddUserExtensionToGrid(addEditUserExtensionForm.UserExtension);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
