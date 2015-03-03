using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NvnTest.Candidate {
    public partial class DisqualifiedForm : Form {
        public DisqualifiedForm() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void DisqualifiedForm_Load(object sender, EventArgs e) {
            Thread thread = new Thread(new ThreadStart(ThreadFunction));
            thread.IsBackground = true;
            thread.Start();
        }

        private void ThreadFunction() {
            Thread.Sleep(5000);
            this.Close();
        }
    }
}
