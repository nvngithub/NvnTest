using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class TermsAndConditionsForm : Form {
        public TermsAndConditionsForm() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
