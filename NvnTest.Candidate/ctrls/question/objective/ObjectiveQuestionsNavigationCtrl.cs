using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ObjectiveQuestionsNavigationCtrl : UserControl {
        public event EventHandler NextClicked;
        public event EventHandler PrevClicked;
        public event EventHandler FlagClicked;

        public ObjectiveQuestionsNavigationCtrl() {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (NextClicked != null) NextClicked(this, null);
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            if (PrevClicked != null) PrevClicked(this, null);
        }

        private void btnFlag_Click(object sender, EventArgs e) {
            if (FlagClicked != null) FlagClicked(this, null);
        }
    }
}
