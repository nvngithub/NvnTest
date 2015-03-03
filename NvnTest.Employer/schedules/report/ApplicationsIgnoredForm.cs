using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class ApplicationsIgnoredForm : Form {
        public ApplicationsIgnoredForm() {
            InitializeComponent();
        }

        public void LoadForm(string[] apps) {
            foreach (string app in apps) {
                int index = dgrApps.Rows.Add();
                dgrApps[AppNameCol.Index, index].Value = app;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
