using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class LoginCtrl : UserControl {
        public event EventHandler LoginClicked;
        public event EventHandler ForgotPasswordClicked;
        public event EventHandler CreateUserClicked;

        public LoginCtrl() {
            InitializeComponent();
#if !LIVE
            txtUserName.Text = "hegde.naveen@gmail.com";
            txtPassword.Text = "naveen";
#endif
        }

        public string UserName {
            get { return txtUserName.Text; }
        }

        public string Password {
            get { return txtPassword.Text; }
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (LoginClicked != null) LoginClicked(this, null);
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (ForgotPasswordClicked != null) ForgotPasswordClicked(this, null);
        }

        private void lnkCreateUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (CreateUserClicked != null) CreateUserClicked(this, null);
        }
    }
}