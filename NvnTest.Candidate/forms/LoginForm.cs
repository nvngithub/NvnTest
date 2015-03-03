using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
            
            ShowLogo();
            txtUserName.Text = Globals.DemoEmail;
        }

        private void ShowLogo() {
            Control ctrl = new LogoCtrl();
            switch (Common.Common.LogoType) {
                case Common.LogoType.Eduji: 
                    ctrl = new EdujiniLogoCtrl(); break;
            }

            ctrl.Dock = DockStyle.Fill;
            pnlLogo.Controls.Add(ctrl);
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (ServiceManager.Instance.Authenticate(txtUserName.Text, txtPassword.Text)) {
                ServiceManager.Instance.Email = txtUserName.Text;
                ServiceManager.Instance.Password = txtPassword.Text;

                if (ServiceManager.Instance.TestSchedule.Status == TestService.TestStatus.Submitted) {
                    MessageBox.Show("This test is already taken. You have no other test scheduled for you.", "Authenticate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (ServiceManager.Instance.TestSchedule.Status == TestService.TestStatus.Taken) {
                    // do crash recovery
                    string localAswersPath = Common.Common.LocalPath + ServiceManager.Instance.TestSchedule.Id.ToString();
                    if (File.Exists(localAswersPath)) {
                        bool submitted = ServiceManager.Instance.SubmitTestAnswers();
                        if (submitted) {
                            MessageBox.Show("Test answers successfully recovered.", "Revover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            File.Delete(localAswersPath);
                        } else {
                            MessageBox.Show("Unfortunately we could not recover your test answers. We apologise for any inconvenience caused. Please save file shown in next prompt and email it to Coderlabz support team: support@coderlabz.com", "Recover", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName = "answers.txt";
                            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            if (dlg.ShowDialog() == DialogResult.OK) {
                                File.Copy(Common.Common.LocalPath + ServiceManager.Instance.TestSchedule.Id, dlg.FileName, true);
                            }
                        }
                        this.DialogResult = DialogResult.No;
                    }
                } else if (ServiceManager.Instance.TestSchedule.Status == TestService.TestStatus.Disqualified) {
                    MessageBox.Show("You have already taken the test assigned to you, but disqualified! Please contact employer/consultant for more details.", "Authenticate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    ServiceManager.Instance.GetEmployerInfo();
                    this.DialogResult = DialogResult.OK;
                }
            } else {
                MessageBox.Show("Authentification failed. Please try again.", "Authenticate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}