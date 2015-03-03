using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class MessageBoxForm : Form {
        public MessageBoxForm() {
            InitializeComponent();
        }

        public string Caption {
            set { this.Text = value; }
        }

        public string Message {
            set { lblMessage.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }

    internal class MessageBoxEx {
        internal static void Show(string caption, string message) {
            MessageBoxForm messageBoxForm = new MessageBoxForm();
            messageBoxForm.Caption = caption;
            messageBoxForm.Message = message;

            messageBoxForm.ShowDialog();
        }

        internal static void Show(string caption, string[] messages) {
            MessageBoxForm messageBoxForm = new MessageBoxForm();
            messageBoxForm.Caption = caption;
            messageBoxForm.Message = String.Join(Environment.NewLine, messages);

            messageBoxForm.ShowDialog();
        }
    }
}
