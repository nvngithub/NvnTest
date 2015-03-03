using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class ObjectiveQuestionItemCtrl : UserControl {
        public event EventHandler DeleteOptionClicked;

        public ObjectiveQuestionItemCtrl() {
            InitializeComponent();
        }

        public string OptionText {
            get { return txtOptionText.Text; }
            set { txtOptionText.Text = value; }
        }

        public bool IsAnswer {
            get { return chkCorrectAnswer.Checked; }
            set { chkCorrectAnswer.Checked = value; }
        }

        public string Marks {
            get { return txtMarks.Text; }
            set { txtMarks.Text = value; }
        }

        public bool ValidateInput() {
            if (String.IsNullOrEmpty(txtOptionText.Text)) {
                MessageBox.Show("Option exists but option text is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (chkCorrectAnswer.Checked && String.IsNullOrEmpty(txtMarks.Text)) {
                MessageBox.Show("Marks cannot be empty if option is the correct answer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Int16 marks = 0;
            if (chkCorrectAnswer.Checked && Int16.TryParse(txtMarks.Text, out marks) == false) {
                MessageBox.Show(String.Format("Marks entered:{0} is not in the valid format.", txtMarks.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e) {
            txtOptionText.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (DeleteOptionClicked != null) { DeleteOptionClicked(this, null); }
        }

        private void chkCorrectAnswer_CheckedChanged(object sender, EventArgs e) {
            txtMarks.Enabled = chkCorrectAnswer.Checked;
            txtMarks.Text = string.Empty;
        }
    }
}
