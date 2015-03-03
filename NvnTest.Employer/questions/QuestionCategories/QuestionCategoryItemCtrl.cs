using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class QuestionCategoryItemCtrl : UserControl {
        public event EventHandler CategoryUnselected;
        private uint id;

        public QuestionCategoryItemCtrl() {
            InitializeComponent();
        }

        public string Category {
            set { lblCategoryName.Text = value; }            
        }

        public uint Id {
            get { return id; }
            set { id = value; }
        }

        private void btnUnselectCategory_Click(object sender, EventArgs e) {
            if (CategoryUnselected != null) {
                CategoryUnselected(this, null);
            }
        }
    }
}
