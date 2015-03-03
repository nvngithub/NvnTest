using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class WebsitesVisitedForm : Form {
        public WebsitesVisitedForm() {
            InitializeComponent();
        }

        public void LoadForm(string[] urls) {
            foreach (string url in urls) {
                txtUrls.AppendText(url + Environment.NewLine);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
