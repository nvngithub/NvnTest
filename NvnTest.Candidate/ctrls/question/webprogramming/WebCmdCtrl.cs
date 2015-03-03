using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class WebCmdCtrl : UserControl {
        public event EventHandler RunClicked;
        public event EventHandler SaveClicked;

        public WebCmdCtrl() {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e) {
            if (RunClicked != null) { RunClicked(this, null); }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (SaveClicked != null) { SaveClicked(this, null); }
        }
    }
}