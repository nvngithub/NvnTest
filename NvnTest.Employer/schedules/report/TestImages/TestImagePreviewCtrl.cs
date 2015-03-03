using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class TestImagePreviewCtrl : UserControl {
        private TestService.TestImage testImage;

        public TestImagePreviewCtrl() {
            InitializeComponent();
        }

        public TestService.TestImage TestImage {
            get { return testImage; }
            set { testImage = value; }
        }

        public void LoadControl() {
            pbTestImage.Image = StringImageConverter.StringToImage(testImage.Stream);
            lblTimeTaken.Text = Path.GetFileNameWithoutExtension(testImage.Name).Replace("_", ":");
        }

        private void lnkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            TestImageViewForm imageViewForm = new TestImageViewForm();
            imageViewForm.TestImage = testImage;
            imageViewForm.LoadForm();
            imageViewForm.ShowDialog();
        }
    }
}
