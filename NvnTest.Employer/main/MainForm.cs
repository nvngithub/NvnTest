using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;
using System.Threading;

namespace NvnTest.Employer {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

            mainCtrl1.LogoutClicked += new EventHandler(mainCtrl1_LogoutClicked);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            mainCtrl1.LoadControl();
        }

        void mainCtrl1_LogoutClicked(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}