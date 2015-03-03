using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class CodeOutputCtrl : UserControl {
        public CodeOutputCtrl() {
            InitializeComponent();
        }

        public void Clear() {
            txtOutput.Text = string.Empty;
        }

        public Color TextColor {
            get { return txtOutput.ForeColor; }
            set { txtOutput.ForeColor = value; }
        }

        public void AppendMessage(string message) {
            txtOutput.AppendText(message + Environment.NewLine);
        }
    }
}