using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class VideoPreviewForm : Form {
        public VideoPreviewForm() {
            InitializeComponent();
        }

        public void LoadForm() {
            WebCamManager.Instance.StartVideoStreaming(this.pbLive);
        }

        private void btnContinue_Click(object sender, EventArgs e) {
            WebCamManager.Instance.StopVideoStreaming();
            WebCamManager.Instance.ClearImages();
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e) {
            WebCamManager.Instance.ClearImages();
            this.DialogResult = DialogResult.No;
        }
    }
}
