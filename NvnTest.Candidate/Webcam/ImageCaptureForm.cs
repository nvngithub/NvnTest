using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ImageCaptureForm : Form {
        public ImageCaptureForm() {
            InitializeComponent();

            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
        }

        public void LoadForm() {
            if (WebCamManager.Instance.IsConnected) {
                WebCamManager.Instance.StartImageCapture(this.pbLiveImages);
            }
        }
    }
}
