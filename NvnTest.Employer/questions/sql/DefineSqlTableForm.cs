using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class DefineSqlTableForm : Form {
        private TestService.SqlTable sqlTable;

        public DefineSqlTableForm() {
            InitializeComponent();
        }

        public TestService.SqlTable SqlTable {
            get { return sqlTable; }
            set { sqlTable = value; }
        }

        public void LoadForm() {
            if (sqlTable != null) {
                txtTableName.Text = sqlTable.TableName;
                txtCreateSql.Text = sqlTable.CreateTableSql;
                if (String.IsNullOrEmpty(sqlTable.TableDataSql) == false) {
                    string[] insertStatements = sqlTable.TableDataSql.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string insertStatement in insertStatements) {
                        txtTableDataSql.AppendText(insertStatement + Environment.NewLine);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (IsValidInput() == false) return;

            if (sqlTable == null) sqlTable = new TestService.SqlTable();

            sqlTable.TableName = txtTableName.Text;
            sqlTable.CreateTableSql = txtCreateSql.Text;
            sqlTable.TableDataSql = txtTableDataSql.Text;

            if (IsValidSQLInput()) {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private bool IsValidInput() {
            if (String.IsNullOrEmpty(txtTableName.Text)) {
                MessageBox.Show("Table name is empty. Please enter table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtCreateSql.Text)) {
                MessageBox.Show("Create table SQL query not found. Please enter valid CREATE TABLE SQL query", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtTableDataSql.Text)) {
                MessageBox.Show("Test data not defined. Please enter valid INSERT statement separated by line.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Table name same as table name used in create statement
            string[] parts = txtCreateSql.Text.Split(" ()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 2 && parts[2].Equals(txtTableName.Text, StringComparison.OrdinalIgnoreCase) == false) {
                MessageBox.Show("Table name mismatch. Please enter table name same as table name used in CREATE SQL statement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool IsValidSQLInput() {
            DbManager.Instance.CreateTable(sqlTable);
            DbResult result = DbManager.Instance.GetSqlResult("SELECT * FROM " + sqlTable.TableName);
            if (result.ResultStatus == DbResultStatus.Success) {
                if (result.Data.Rows.Count > 0) {
                    return true;
                }
                if (result.Data.Rows.Count == 0) {
                    MessageBox.Show("Unable to load test data. Please varify your test data input and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Unexpected error occured while creating table and loading test data. Please varify your input and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}