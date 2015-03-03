using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();

            updateUserInfoCtrl.SaveClicked += new EventHandler(updateUserInfoCtrl_SaveClicked);
            updateUserInfoCtrl.CloseClicked += new EventHandler(updateUserInfoCtrl_CloseClicked);
        }

        public void LoadForm() {
            updateUserInfoCtrl.UserInfo = ServiceManager.Instance.UserInfo;
            updateUserInfoCtrl.LoadControl();
        }

        void updateUserInfoCtrl_SaveClicked(object sender, EventArgs e) {
            if (updateUserInfoCtrl.UserInfo.UserExtension != null) {
                ServiceManager.Instance.UpdateUserExtension(updateUserInfoCtrl.UserInfo.UserExtension);
            } else {
                ServiceManager.Instance.UpdateUserInfo(updateUserInfoCtrl.UserInfo);
            }
            this.DialogResult = DialogResult.OK;
        }

        void updateUserInfoCtrl_CloseClicked(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
