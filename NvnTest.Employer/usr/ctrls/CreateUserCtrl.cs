using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class CreateUsrCtrl : UserControl {
        public event EventHandler CreateUserClicked;
        public event EventHandler CreateUserCancelClicked;
        public event EventHandler CreateUserBackClicked;

        public CreateUsrCtrl() {
            InitializeComponent();
        }

        public string UserName {
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        public string FirstName {
            get { return txtFirstName.Text; }
        }

        public string LastName {
            get { return txtLastName.Text; }
        }

        public string Company_Name {
            get { return txtCompanyName.Text; }
        }

        public string Password {
            get { return txtPassword.Text; }
        }

        public string ConfirmPassword {
            get { return txtConfirmPassword.Text; }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            if (CreateUserBackClicked != null) CreateUserBackClicked(this, null);
        }

        private void btnCreateUser_Click(object sender, EventArgs e) {
            if (CreateUserClicked != null) CreateUserClicked(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if (CreateUserCancelClicked != null) CreateUserCancelClicked(this, null);
        }
    }
}
