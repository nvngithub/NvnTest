using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditQuestionLevelForm : Form {
        private string description;

        public AddEditQuestionLevelForm() {
            InitializeComponent();
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public void LoadForm() {
            txtDescription.Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            bool isValidInput = CheckIsValidInput();
            if (isValidInput) {
                description = txtDescription.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private bool CheckIsValidInput() {
            if (String.IsNullOrEmpty(txtDescription.Text)) {
                MessageBox.Show("Please enter level description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
