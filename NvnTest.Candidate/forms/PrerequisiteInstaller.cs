using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace NvnTest.Candidate {
    public partial class PrerequisiteInstaller : Form {
        private bool jsharpInstalled = false;

        public PrerequisiteInstaller() {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void PrerequisiteInstaller_Load(object sender, EventArgs e) {
            Thread installerThread = new Thread(new ThreadStart(InstallPrerequisites));
            installerThread.IsBackground = true;
            installerThread.Start();
        }

        public List<string> InstallationStatus() {
            List<string> status = new List<string>();

            if (IsJsharpInstalled() == false) {
                status.Add("Unable to find JSharp. Hence java programs may not work properly. Launch NvnTest again to install pre-requisites.");
            }

            return status;
        }

        private void InstallPrerequisites() {
            Thread jsharpThread = new Thread(new ThreadStart(InstallJsharp));
            jsharpThread.IsBackground = true;
            jsharpThread.Start();

            jsharpThread.Join();

            if (jsharpInstalled) {
                this.DialogResult = DialogResult.OK;
            } else {
                this.DialogResult = DialogResult.No;
            }
        }

        private void InstallJsharp() {
            string jsharpRedistPath = Common.Common.LocalPath + "vjredist.exe";
            string jsharpRedistUrl = "http://www.coderlabz.com/app/redist/vjredist.exe";

            bool status = true;
            if (IsJsharpInstalled() == false) {
                if (File.Exists(jsharpRedistPath) == false) {
                    status = status && Download(jsharpRedistUrl, jsharpRedistPath);
                }

                status = status && InstallMsi(jsharpRedistPath, " /q:a /c:\"install /q\"");
            }

            jsharpInstalled = status;
        }

        private bool IsJsharpInstalled() {
            return File.Exists(@"C:\Windows\Microsoft.NET\Framework\VJSharp\vjshost.dll");
        }

        private bool Download(string url, string localFilePath) {
            try {
                using (var client = new WebClient()) {
                    lblStatus.Text = "Downloading";
                    client.DownloadFile(url, localFilePath);
                }
            } catch {
                return false;
            }

            return true;
        }

        public bool InstallMsi(string msiPath, string args) {
            try {
                lblStatus.Text = "Installing";

                Process process = new Process();
                process.StartInfo.FileName = String.Format("\"{0}\"", msiPath);
                process.StartInfo.Arguments = args;
                process.Start();
                process.WaitForExit();
            } catch {
                return false;
            }

            return true;
        }
    }
}
