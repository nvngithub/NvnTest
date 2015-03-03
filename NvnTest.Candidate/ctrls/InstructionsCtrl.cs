using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class InstructionsCtrl : UserControl {
        public event EventHandler StartClicked;
        public event EventHandler CancelClicked;

        public InstructionsCtrl() {
            InitializeComponent();

            ShowLogo();
        }

        public void LoadControl() {
            testInfoCtrl1.LoadControl();
            lblInstruction1.Text = lblInstruction1.Text.Replace("[time]", testInfoCtrl1.Duration);
        }

        private void ShowLogo() {
            Control ctrl = new LogoCtrl();
            switch (Common.Common.LogoType) {
                case Common.LogoType.Eduji: ctrl = new EdujiniLogoCtrl(); break;
            }

            ctrl.Dock = DockStyle.Fill;
            pnlLogo.Controls.Add(ctrl);
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (chkAgreeInstructions.Checked == false || chkAgreeTermsAndConditions.Checked == false) {
                MessageBox.Show("You can start test only if you agree with the instructions provided and Coderlabz terms and conditions.", "Terms", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                if (StartClicked != null) StartClicked(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if (CancelClicked != null) CancelClicked(this, null);
        }

        private void btnViewTermsAndConditions_Click(object sender, EventArgs e) {
            TermsAndConditionsForm termsAndConditionsForm = new TermsAndConditionsForm();
            termsAndConditionsForm.ShowDialog();
        }
    }
}
