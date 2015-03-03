using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;
using System.Drawing.Imaging;

namespace NvnTest.Employer {
    public partial class UpdateUserInfoCtrlcs : UserControl {
        public event EventHandler SaveClicked;
        public event EventHandler CloseClicked;

        private TestService.UserInfo userInfo;

        public UpdateUserInfoCtrlcs() {
            InitializeComponent();
        }

        public TestService.UserInfo UserInfo {
            get { return userInfo; }
            set { userInfo = value; }
        }

        public void LoadControl() {
            if (userInfo.UserExtension != null) {
                lblEmail.Text = userInfo.UserExtension.Email;
                txtFirstName.Text = userInfo.UserExtension.FirstName;
                txtLastName.Text = userInfo.UserExtension.LastName;
                txtPassword.Text = userInfo.UserExtension.Password;
                txtCompanyName.Text = userInfo.CompanyName;

                txtCompanyName.Enabled = false;
            } else {
                lblEmail.Text = userInfo.Email;
                txtFirstName.Text = userInfo.FirstName;
                txtLastName.Text = userInfo.LastName;
                txtPassword.Text = userInfo.Password;
                txtCompanyName.Text = userInfo.CompanyName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (userInfo.UserExtension != null) {
                userInfo.UserExtension.FirstName = txtFirstName.Text;
                userInfo.UserExtension.LastName = txtLastName.Text;
                userInfo.UserExtension.Password = txtPassword.Text;
                //userInfo.CompanyName = txtCompanyName.Text;
            } else {
                userInfo.FirstName = txtFirstName.Text;
                userInfo.LastName = txtLastName.Text;
                userInfo.Password = txtPassword.Text;
                userInfo.CompanyName = txtCompanyName.Text;
            }

            if (SaveClicked != null) SaveClicked(this, null);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            if (CloseClicked != null) CloseClicked(this, null);
        }
    }
}
