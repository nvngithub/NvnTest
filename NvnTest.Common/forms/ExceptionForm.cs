using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Common {
    public partial class ExceptionForm : Form {
        public ExceptionForm() {
            InitializeComponent();
        }

        public void LoadForm(string message) {
            lblMessage.Text = message;
        }

        private void btnReport_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnDontReport_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
