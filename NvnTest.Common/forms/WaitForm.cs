using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Common {
    public partial class WaitForm : Form {
        public WaitForm() {
            InitializeComponent();
        }

        private void WaitForm_Load(object sender, EventArgs e) {
            this.Size = new Size(48, 48);
        }

        private void pbWait_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
