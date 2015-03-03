using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class DescriptionCtrl : UserControl {
        public DescriptionCtrl() {
            InitializeComponent();
        }

        public string Description {
            get { return txtDesc.Text; }
            set { txtDesc.Text = value; }
        }

        public string DescriptionLabel {
            set { lblDescriptionLabel.Text = value; }
        }
    }
}