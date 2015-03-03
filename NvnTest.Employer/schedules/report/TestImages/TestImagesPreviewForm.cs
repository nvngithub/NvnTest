using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NvnTest.Employer {
    public partial class TestImagesPreviewForm : Form {
        private TestService.TestImage[] testImages;

        public TestImagesPreviewForm() {
            InitializeComponent();
        }

        public TestService.TestImage[] TestImages {
            get { return testImages; }
            set { testImages = value; }
        }

        public void LoadForm() {
            pnlImagePreview.Controls.Clear();

            if (testImages.Length > 0) {
                foreach (TestService.TestImage testImage in testImages) {
                    TestImagePreviewCtrl previewCtrl = new TestImagePreviewCtrl();
                    previewCtrl.TestImage = testImage;
                    previewCtrl.LoadControl();

                    pnlImagePreview.Controls.Add(previewCtrl);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
