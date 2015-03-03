using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class AddEditSqlQuestionForm : Form {
        TestService.SqlQuestion sqlQuestion;

        public AddEditSqlQuestionForm() {
            InitializeComponent();
        }

        public TestService.SqlQuestion SqlQuestion {
            get { return sqlQuestion; }
            set { sqlQuestion = value; }
        }
        
        public void LoadForm() {
            if (sqlQuestion != null) {
                descriptionCtrl1.Description = sqlQuestion.Desc;

                if (sqlQuestion.Tables != null) {
                    foreach (TestService.SqlTable sqlTable in sqlQuestion.Tables) {
                        DataTableCtrl dataTableCtrl = new DataTableCtrl();
                        dataTableCtrl.DataTableDeleted += new EventHandler(dataTableCtrl_DataTableDeleted);
                        dataTableCtrl.SqlTable = sqlTable;
                        dataTableCtrl.LoadControl();
                        pnlTables.Controls.Add(dataTableCtrl);
                    }
                }
            }

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }
        }

        private void btnAddNewTable_Click(object sender, EventArgs e) {
            DataTableCtrl dataTableCtrl = new DataTableCtrl();
            dataTableCtrl.SqlTable = new TestService.SqlTable();
            dataTableCtrl.DataTableDeleted +=new EventHandler(dataTableCtrl_DataTableDeleted);
            pnlTables.Controls.Add(dataTableCtrl);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (sqlQuestion == null) {
                sqlQuestion = new TestService.SqlQuestion();
                sqlQuestion.Type = TestService.QuestionType.Sql;
                sqlQuestion.AdminId = ServiceManager.Instance.UserInfo.Id;
                sqlQuestion.DateTimeCreated = sqlQuestion.DateTimeModified = DateTime.Now;
                sqlQuestion.TempId = Guid.NewGuid().ToString().Replace("-", "");
                sqlQuestion.ExpectedResultSql = string.Empty;
            }

            sqlQuestion.Desc = descriptionCtrl1.Description;
            List<TestService.SqlTable> tables = new List<TestService.SqlTable>();
            foreach (Control ctrl in pnlTables.Controls) {
                if (ctrl is DataTableCtrl) {
                    DataTableCtrl dataTableCtrl = (DataTableCtrl)ctrl;
                    tables.Add(dataTableCtrl.SqlTable);
                }
            }

            sqlQuestion.Tables = tables.ToArray();

            object response = ServiceManager.Instance.UpdateQuestion(sqlQuestion);
            if (response != null) {
                sqlQuestion = (TestService.SqlQuestion)response;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private void dataTableCtrl_DataTableDeleted(object sender, EventArgs e) {
            pnlTables.Controls.Remove((DataTableCtrl)sender);
        }

        private void pnlTables_ControlAdded(object sender, ControlEventArgs e) {
            pnlTables.ScrollControlIntoView(e.Control);
        }

        private bool ValidInput() {
            // 1. Description is not empty
            if (String.IsNullOrEmpty(descriptionCtrl1.Description)) {
                MessageBox.Show("Question description cannot be empty. Please enter question description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 2. At least one table defined
            bool isTableAddedAndDefined = false;
            foreach (Control ctrl in pnlTables.Controls) {
                if (ctrl is DataTableCtrl) {
                    DataTableCtrl tblCtrl = (DataTableCtrl)ctrl;
                    if (tblCtrl.IsDefined) {
                        isTableAddedAndDefined = true;
                        break;
                    }
                }
            }
            if (isTableAddedAndDefined == false) {
                MessageBox.Show("No database table found. Please add at least one table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}