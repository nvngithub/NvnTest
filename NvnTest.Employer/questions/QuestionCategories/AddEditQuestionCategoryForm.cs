using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditQuestionCategoryForm : Form {
        private string category;

        public AddEditQuestionCategoryForm() {
            InitializeComponent();
        }

        public string Category {
            get { return category; }
            set { category = value; }
        }

        public void LoadForm() {
            txtCategoryName.Text = category;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            category = txtCategoryName.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
