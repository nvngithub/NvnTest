using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class ImportQuestionsForm : Form {
        private List<TestService.QuestionBase> questions;
        private List<TestService.QuestionBase> selectedQuestions = new List<TestService.QuestionBase>();

        public ImportQuestionsForm() {
            InitializeComponent();
        }

        public List<TestService.QuestionBase> Questions {
            set { questions = value; }
        }

        public List<TestService.QuestionBase> SelectedQuestions {
            get { return selectedQuestions; }
        }

        public void LoadForm() {
            if (questions != null && questions.Count > 0) {
                foreach (TestService.QuestionBase question in questions) {
                    int index = dgrQuestions.Rows.Add();
                    dgrQuestions[DescCol.Index, index].Value = question.Desc;
                    switch (question.Type) {
                        case TestService.QuestionType.Objective:
                            dgrQuestions[QuestionTypeCol.Index, index].Value = "Objective";
                            break;
                        case TestService.QuestionType.Programming:
                            dgrQuestions[QuestionTypeCol.Index, index].Value = "Programming";
                            break;
                        case TestService.QuestionType.Sql:
                            dgrQuestions[QuestionTypeCol.Index, index].Value = "SQL";
                            break;
                        case TestService.QuestionType.WebProgramming:
                            dgrQuestions[QuestionTypeCol.Index, index].Value = "Web Programming";
                            break;
                    }

                    dgrQuestions.Rows[index].Tag = question;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e) {
            selectedQuestions.Clear();
            foreach (DataGridViewRow row in dgrQuestions.Rows) {
                if (row.Cells[SelectQuestionCol.Index].Value != null && (bool)row.Cells[SelectQuestionCol.Index].Value) {
                    selectedQuestions.Add((TestService.QuestionBase)row.Tag);
                }
            }

            if (selectedQuestions.Count > 0) {
                this.DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show("Please select questions which you like to import", "Import questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
