using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnTest.Employer {
    public partial class TestPurchaseForm : Form {
        private bool assignToYourself = false;

        public TestPurchaseForm() {
            InitializeComponent();
        }

        public bool AssignToYourself {
            get { return assignToYourself; }
        }

        private void btnAssignToYourself_Click(object sender, EventArgs e) {
            assignToYourself = true;
            this.DialogResult = DialogResult.OK;
        }

        private void btnPurchaseTests_Click(object sender, EventArgs e) {
            Process.Start("http://www.colderlabz.com/purchase.aspx");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
