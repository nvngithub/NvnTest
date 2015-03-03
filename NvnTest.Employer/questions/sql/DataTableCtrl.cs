using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class DataTableCtrl : UserControl {
        public event EventHandler DataTableDeleted;
        public event EventHandler DataTableEdited;
        private TestService.SqlTable sqlTable;

        public DataTableCtrl() {
            InitializeComponent();
        }

        public TestService.SqlTable SqlTable {
            get { return sqlTable; }
            set { sqlTable = value; }
        }

        public bool IsDefined {
            get { return dgrTestData.Rows.Count > 0; }
        }

        public void LoadControl() {
            // Table name
            dgrTableName.Columns[0].HeaderText = sqlTable.TableName;

            // Fill test data
            DbManager.Instance.CreateTable(sqlTable);
            DbResult result = DbManager.Instance.GetSqlResult("SELECT * FROM " + sqlTable.TableName);
            if (result.ResultStatus == DbResultStatus.Success) {
                dgrTestData.DataSource = result.Data;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (DataTableDeleted != null) { DataTableDeleted(this, null); }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            DefineSqlTableForm sqlTableForm = new DefineSqlTableForm();
            sqlTableForm.SqlTable = sqlTable;
            sqlTableForm.LoadForm();
            if (sqlTableForm.ShowDialog() == DialogResult.OK) {
                // Reload control
                LoadControl();
                if (DataTableEdited != null) DataTableEdited(this, null);
            }
        }
    }
}
