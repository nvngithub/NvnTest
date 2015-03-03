using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class SqlCommandCtrl : UserControl {
        public event EventHandler RunClicked;
        public event EventHandler PauseClicked;
        public event EventHandler HistoryClicked;
        public event EventHandler SqlQuerySaved;

        public SqlCommandCtrl() {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e) {
            if (RunClicked != null) RunClicked(this, null);
            if (SqlQuerySaved != null) SqlQuerySaved(this, e);
        }

        private void btnPause_Click(object sender, EventArgs e) {
            if (PauseClicked != null) PauseClicked(this, null);
        }

        private void btnHistory_Click(object sender, EventArgs e) {
            if (HistoryClicked != null) HistoryClicked(this, null);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (SqlQuerySaved != null) SqlQuerySaved(this, e);
        }
    }
}