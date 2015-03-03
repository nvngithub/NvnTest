using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NvnTest.Candidate {
    public partial class TaskItemCtrl : UserControl {
        private Process process;
        public event EventHandler<IgnoredAppEventArgs> ApplicationIgnored;

        public TaskItemCtrl() {
            InitializeComponent();
        }

        public string TaskName {
            set { lblTaskName.Text = value; }
        }

        public Icon TaskIcon {
            set { pbTaskIcon.Image = value.ToBitmap(); }
        }

        public Process Process {
            get { return process; }
            set { process = value; }
        }

        private void btnEndTask_Click(object sender, EventArgs e) {
            process.CloseMainWindow();
        }

        private void btnIgnore_Click(object sender, EventArgs e) {
            if (ApplicationIgnored != null) {
                ApplicationIgnored(this, new IgnoredAppEventArgs(lblTaskName.Text));
            }
        }
    }

    public class IgnoredAppEventArgs : EventArgs{
        private string applicationName;

        public string ApplicationName {
            get { return applicationName; }
            set { applicationName = value; }
        }

        public IgnoredAppEventArgs(string applicationName) {
            this.applicationName = applicationName;
        }
    }
}