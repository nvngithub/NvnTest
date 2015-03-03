using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class ForgotPasswordCtrl : UserControl {
        public event EventHandler ResetPasswordClicked;
        public event EventHandler ResetPasswordCancelClicked;

        public ForgotPasswordCtrl() {
            InitializeComponent();
        }

        public string UserName {
            get { return txtUserName.Text; }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            if (ResetPasswordClicked != null) ResetPasswordClicked(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if (ResetPasswordCancelClicked != null) ResetPasswordCancelClicked(this, null);
        }
    }
}
