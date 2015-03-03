using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class VarifyForm : Form {
        public VarifyForm() {
            InitializeComponent();
        }

        public string Email {
            set { lblEmail.Text = value; }
        }

        private void btnVarify_Click(object sender, EventArgs e) {
            object response = ServiceManager.Instance.VarifyCode(lblEmail.Text, txtVarificationCode.Text);
            if ((bool)response) {
                MessageBox.Show("Your email address is successfully varified", "Varify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;                
            } else {
                MessageBox.Show("Varification failed. Please enter valid varification code", "Varify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkNewCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            object response = ServiceManager.Instance.CreateNewCode(lblEmail.Text);
            if ((bool)response) {
                MessageBox.Show("New varification code is sent to your email address.", "Varify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
