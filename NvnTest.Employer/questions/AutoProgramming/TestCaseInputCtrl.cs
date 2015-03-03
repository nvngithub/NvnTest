using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class TestCaseInputCtrl : UserControl {
        public TestCaseInputCtrl() {
            InitializeComponent();
        }

        public string Input {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public string ArgumentName {
            get { return lblArgumentName.Text; }
            set { lblArgumentName.Text = value; }
        }
    }
}
