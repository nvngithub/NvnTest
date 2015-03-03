using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class TestImageViewForm : Form {
        private TestService.TestImage testImage;

        public TestImageViewForm() {
            InitializeComponent();
        }

        public TestService.TestImage TestImage {
            get { return testImage; }
            set { testImage = value; }
        }

        public void LoadForm() {
            if (testImage != null) {
                pbTestImage.Image = StringImageConverter.StringToImage(testImage.Stream);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.Filter = "JPeg Image|*.jpeg";
            dlg.FileName = testImage.Name;
            if (dlg.ShowDialog() == DialogResult.OK) {
                StringBinaryConverter.StringToBinary(dlg.FileName, testImage.Stream);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
