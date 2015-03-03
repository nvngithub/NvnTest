using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class MainCtrl : UserControl {
        public event EventHandler LogoutClicked;

        public MainCtrl() {
            InitializeComponent();
        }

        public void LoadControl() {
            LoadAll();
        }

        private void LoadAll() {
            // Load service data
            ServiceManager.Instance.LoadData();
            // Load each control
            questionsCtrl1.LoadControl();
            papersCtrl1.LoadControl();
            schedulesCtrl1.LoadControl();

            tbMain.TabPages.Clear();
            tbMain.TabPages.Add(tbSchedules);
            tbMain.TabPages.Add(tbPapers);
            tbMain.TabPages.Add(tbQuestions);

            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                TestService.UserExtension userExtension = ServiceManager.Instance.UserInfo.UserExtension;
                if (userExtension.QuestionsPrivilege == TestService.PrivilegeType.None) {
                    tbMain.TabPages.Remove(tbQuestions);
                }

                if (userExtension.PapersPrivilege == TestService.PrivilegeType.None) {
                    tbMain.TabPages.Remove(tbPapers);
                }

                if (userExtension.SchedulesPrivilege == TestService.PrivilegeType.None) {
                    tbMain.TabPages.Remove(tbSchedules);
                }
            }
        }

        private void lnkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ShowSettings();
        }

        private void pbSettings_Click(object sender, EventArgs e) {
            ShowSettings();
        }

        private void ShowSettings() {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.LoadForm();
            settingsForm.ShowDialog();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (LogoutClicked != null) LogoutClicked(this, null);
        }

        private void pbLogout_Click(object sender, EventArgs e) {
            if (LogoutClicked != null) LogoutClicked(this, null);
        }

        private void lnkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            TermsForm terms = new TermsForm();
            terms.ShowDialog();
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            LoadAll();
        }

        private void pbRefresh_Click(object sender, EventArgs e) {
            LoadAll();
        }

        private void pbUserExtensions_Click(object sender, EventArgs e) {
            ShowUserExtensions();
        }

        private void lnkUserExtensions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ShowUserExtensions();
        }

        private void ShowUserExtensions() {
            if (ServiceManager.Instance.UserInfo.UserExtension != null) return;

            TestService.UserExtension[] userExtensions = (TestService.UserExtension[])ServiceManager.Instance.GetUserExtensions();

            UserExtensionsForm userExtensionForm = new UserExtensionsForm();
            userExtensionForm.UserExtensions = userExtensions;
            userExtensionForm.LoadForm();
            userExtensionForm.ShowDialog();
        }
    }
}
