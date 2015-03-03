using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class SqlHistoryForm : Form {
        private string selectedQuery;

        public SqlHistoryForm() {
            InitializeComponent();
        }

        public string SelectedQuery {
            get { return selectedQuery; }
        }

        public void LoadForm(TestService.SqlQuestion question) {
            List<SqlHistory> hists = SqlHistory.GetHistory(question);
            if (hists != null) {
                foreach (SqlHistory hist in hists) {
                    int index = dgrQueries.Rows.Add();
                    dgrQueries[QueryCol.Index, index].Value = hist.Sql;
                    dgrQueries[DateTimeCol.Index, index].Value = hist.DateTimeExecuted.ToString("dd-MMM-yyyy hh:mm tt");
                    dgrQueries.Rows[index].Tag = hist;
                }
            }

            if (dgrQueries.RowCount > 0) {
                SqlHistory hist = (SqlHistory)dgrQueries.Rows[0].Tag;
                txtSql.Text = hist.Sql;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            SqlHistory hist = (SqlHistory)dgrQueries.Rows[e.RowIndex].Tag;
            txtSql.Text = hist.Sql;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(txtSql.Text) == false) {
                selectedQuery = txtSql.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}