using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class CodeCmdCtrl : UserControl {
        public event EventHandler RunClicked;
        public event EventHandler ClearClicked;

        public CodeCmdCtrl() {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e) {
            if (RunClicked != null) RunClicked(this, null);
        }

        private void btnClear_Click(object sender, EventArgs e) {
            if (ClearClicked != null) ClearClicked(this, null);
        }
    }
}