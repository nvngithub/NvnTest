using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class TermsForm : Form {
        public TermsForm() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
