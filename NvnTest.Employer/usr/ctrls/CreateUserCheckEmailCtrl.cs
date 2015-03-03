using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class CreateUserCheckEmailCtrl : UserControl {
        public event EventHandler CheckUserNameExistsClicked;
        public event EventHandler CheckUserNameCancelClicked;

        public CreateUserCheckEmailCtrl() {
            InitializeComponent();
        }

        public string UserName {
            get { return txtUserName.Text; }
        }

        private void btnCheckUserName_Click(object sender, EventArgs e) {
            if (CheckUserNameExistsClicked != null) CheckUserNameExistsClicked(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if (CheckUserNameCancelClicked != null) CheckUserNameCancelClicked(this, null);
        }
    }
}