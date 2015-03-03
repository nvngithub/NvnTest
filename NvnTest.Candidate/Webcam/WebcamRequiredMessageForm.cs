using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class WebcamRequiredMessageForm : Form {
        public WebcamRequiredMessageForm() {
            InitializeComponent();
        }

        private void WebcamRequiredMessageForm_Load(object sender, EventArgs e) {
            if (ServiceManager.Instance.Email == Globals.DemoEmail) {
                this.lnkSkipWebcamDetection.Visible = true;
            }
        }

        private void lnkSkipWebcamDetection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
