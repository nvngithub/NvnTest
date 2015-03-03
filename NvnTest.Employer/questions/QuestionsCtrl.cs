using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Employer {
    public partial class QuestionsCtrl : UserControl {
        private TestService.Questions questions;
        private uint currentIndex = 0;
        private uint maxPages = 0;

        public QuestionsCtrl() {
            InitializeComponent();

            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Multiple choice questions");
            cmbFilter.Items.Add("Programming questions");
            cmbFilter.Items.Add("Programming questions (Auto Evaluation)");
            cmbFilter.Items.Add("Web programming");
        }

        public void LoadControl() {
            dgrQuestions.Rows.Clear();

            object response = null;
            if (cmbFilter.SelectedIndex <= 0) {
                maxPages = (uint)ServiceManager.Instance.GetNumberOfQuestionPages();

                response = ServiceManager.Instance.LoadQuestions(currentIndex);
            } else {
                TestService.QuestionType questionType = GetQuestionType();
                maxPages = (uint)ServiceManager.Instance.GetNumberOfQuestionPages(questionType);
                
                response = ServiceManager.Instance.LoadQuestions(questionType, currentIndex);
            }

            questions = (TestService.Questions)response;
            AddQuestionsToGrid(questions.ObjectiveQuestions);
            AddQuestionsToGrid(questions.SQLQuestions);
            AddQuestionsToGrid(questions.ProgrammingQuestions);
            AddQuestionsToGrid(questions.AutoProgrammingQuestions);
            AddQuestionsToGrid(questions.WebProgrammingQuestions);

            lblIndex.Text = (currentIndex + 1).ToString();

            btnAddQuestions.Enabled = btnImportQuestions.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnAddQuestions.Enabled = btnImportQuestions.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }

            ServiceManager.Instance.LoadQuestionCategories();
            ServiceManager.Instance.LoadQuestionLevels();
        }

        private void AddQuestionsToGrid<T>(T[] questions) where T : TestService.QuestionBase {
            foreach (TestService.QuestionBase question in questions) {
                AddQuestionToGrid(question);
            }
        }

        private void AddQuestionToGrid(TestService.QuestionBase question) {
            int rowIndex = dgrQuestions.Rows.Add();
            dgrQuestions[IndexCol.Index, rowIndex].Value = rowIndex + 1;
            dgrQuestions[DescCol.Index, rowIndex].Value = question.Desc;
            dgrQuestions[DateModifiedCol.Index, rowIndex].Value = question.DateTimeModified.ToString("dd-MMM-yyyy");
            dgrQuestions[QuestionTypeCol.Index, rowIndex].Value = imageList.Images[(int)question.Type];
            dgrQuestions.Rows[rowIndex].Tag = question;
        }

        private void dgrQuestions_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            TestService.QuestionBase question = (TestService.QuestionBase)dgrQuestions.Rows[e.RowIndex].Tag;
            if (dgrQuestions.Columns[e.ColumnIndex].Name == EditCol.Name) {
                EditQuestion(question, e.RowIndex);
            } else if (dgrQuestions.Columns[e.ColumnIndex].Name == DeleteCol.Name) {
                if ((int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege <= 1) {
                    MessageBox.Show("You do not have enough privilege to delete questions.", "Delete question", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this question ?", "Delete question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                    object response = ServiceManager.Instance.RemoveQuestion(question);
                    dgrQuestions.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dgrQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EditQuestion((TestService.QuestionBase)dgrQuestions.Rows[e.RowIndex].Tag, e.RowIndex);
        }

        private void btnAddNewObjectiveQuestion_Click(object sender, EventArgs e) {
            AddEditObjectiveQuestionForm objectiveQuestionForm = new AddEditObjectiveQuestionForm();
            if (objectiveQuestionForm.ShowDialog() == DialogResult.OK) {
                AddQuestionToGrid(objectiveQuestionForm.ObjectiveQuestion);
            }
        }

        private void btnAddNewSqlQuestion_Click(object sender, EventArgs e) {
            AddEditSqlQuestionForm sqlQuestionForm = new AddEditSqlQuestionForm();
            if (sqlQuestionForm.ShowDialog() == DialogResult.OK) {
                AddQuestionToGrid(sqlQuestionForm.SqlQuestion);
            }
        }

        private void btnAddNewProgrammingQuestion_Click(object sender, EventArgs e) {
            AddEditProgrammingQuestionForm programmingQuestionForm = new AddEditProgrammingQuestionForm();
            if (programmingQuestionForm.ShowDialog() == DialogResult.OK) {
                AddQuestionToGrid(programmingQuestionForm.ProgrammingQuestion);
            }
        }

        private void btnAddNewAutoProgrammingQuestion_Click(object sender, EventArgs e) {
            AddEditAutoProgrammingQuestionForm autoProgrammingQuestionForm = new AddEditAutoProgrammingQuestionForm();
            if (autoProgrammingQuestionForm.ShowDialog() == DialogResult.OK) {
                AddQuestionToGrid(autoProgrammingQuestionForm.AutoProgrammingQuestion);
            }
        }

        private void btnAddNewWebProgrammingQuestion_Click(object sender, EventArgs e) {
            AddEditWebProgrammingQuestionForm webProgrammingQuestionForm = new AddEditWebProgrammingQuestionForm();
            if (webProgrammingQuestionForm.ShowDialog() == DialogResult.OK) {
                AddQuestionToGrid(webProgrammingQuestionForm.WebProgrammingQuestion);
            }
        }

        private void EditQuestion(TestService.QuestionBase question, int index) {
            if (IsQuestionInUse(question)) {
                MessageBox.Show("Question you are editing is already answered in certain test. Editing this question could make existing answer wrong or irrelevant.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            switch (question.Type) {
                case TestService.QuestionType.Objective:
                    AddEditObjectiveQuestionForm objectiveQuestionForm = new AddEditObjectiveQuestionForm();
                    objectiveQuestionForm.ObjectiveQuestion = ObjectCopier.Clone<TestService.ObjectiveQuestion>((TestService.ObjectiveQuestion)question);
                    objectiveQuestionForm.LoadForm();
                    if (objectiveQuestionForm.ShowDialog() == DialogResult.OK) {
                        dgrQuestions[DescCol.Index, index].Value = objectiveQuestionForm.ObjectiveQuestion.Desc;
                        dgrQuestions.Rows[index].Tag = objectiveQuestionForm.ObjectiveQuestion;
                    }
                    break;
                case TestService.QuestionType.Sql:
                    AddEditSqlQuestionForm sqlQuestionForm = new AddEditSqlQuestionForm();
                    sqlQuestionForm.SqlQuestion = ObjectCopier.Clone<TestService.SqlQuestion>((TestService.SqlQuestion)question);
                    sqlQuestionForm.LoadForm();
                    if (sqlQuestionForm.ShowDialog() == DialogResult.OK) {
                        dgrQuestions[DescCol.Index, index].Value = sqlQuestionForm.SqlQuestion.Desc;
                        dgrQuestions.Rows[index].Tag = sqlQuestionForm.SqlQuestion;
                    }
                    break;
                case TestService.QuestionType.Programming:
                    AddEditProgrammingQuestionForm programmingQuestionForm = new AddEditProgrammingQuestionForm();
                    programmingQuestionForm.ProgrammingQuestion = ObjectCopier.Clone<TestService.ProgrammingQuestion>((TestService.ProgrammingQuestion)question);
                    programmingQuestionForm.LoadForm();
                    if (programmingQuestionForm.ShowDialog() == DialogResult.OK) {
                        dgrQuestions[DescCol.Index, index].Value = programmingQuestionForm.ProgrammingQuestion.Desc;
                        dgrQuestions.Rows[index].Tag = programmingQuestionForm.ProgrammingQuestion;
                    }
                    break;
                case TestService.QuestionType.AutoProgramming:
                    AddEditAutoProgrammingQuestionForm autoProgrammingQuestionForm = new AddEditAutoProgrammingQuestionForm();
                    autoProgrammingQuestionForm.AutoProgrammingQuestion = ObjectCopier.Clone<TestService.AutoProgrammingQuestion>((TestService.AutoProgrammingQuestion)question);
                    autoProgrammingQuestionForm.LoadForm();
                    if (autoProgrammingQuestionForm.ShowDialog() == DialogResult.OK) {
                        dgrQuestions[DescCol.Index, index].Value = autoProgrammingQuestionForm.AutoProgrammingQuestion.Desc;
                        dgrQuestions.Rows[index].Tag = autoProgrammingQuestionForm.AutoProgrammingQuestion;
                    }
                    break;
                case TestService.QuestionType.WebProgramming:
                    AddEditWebProgrammingQuestionForm webProgrammingQuestionForm = new AddEditWebProgrammingQuestionForm();
                    webProgrammingQuestionForm.WebProgrammingQuestion = ObjectCopier.Clone<TestService.WebProgrammingQuestion>((TestService.WebProgrammingQuestion)question);
                    webProgrammingQuestionForm.LoadForm();
                    if (webProgrammingQuestionForm.ShowDialog() == DialogResult.OK) {
                        dgrQuestions[DescCol.Index, index].Value = webProgrammingQuestionForm.WebProgrammingQuestion.Desc;
                        dgrQuestions.Rows[index].Tag = webProgrammingQuestionForm.WebProgrammingQuestion;
                    }
                    break;
            }
        }

        private bool IsQuestionInUse(TestService.QuestionBase question) {
            foreach (TestService.TestSchedule testSchedule in ServiceManager.Instance.Schedules.Values) {
                if (testSchedule.Status == TestService.TestStatus.Taken) {
                    uint paperId = testSchedule.PaperId;
                    if (ServiceManager.Instance.Papers.ContainsKey(paperId)) {
                        TestService.Paper paper = ServiceManager.Instance.Papers[paperId];

                        string questionTypeAndId = question.Type.ToString() + question.Id;

                        string[] questions = paper.QuestionIds.Split(",".ToCharArray());
                        foreach (string q in questions) {
                            string[] idAndType = q.Split("|".ToCharArray());
                            if ((idAndType[1] + idAndType[0]) == questionTypeAndId) {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void btnExportQuestions_Click(object sender, EventArgs e) {
            List<TestService.QuestionBase> selectedQuestions = new List<TestService.QuestionBase>();
            foreach (DataGridViewRow row in dgrQuestions.Rows) {
                if (row.Cells[SelectedQuestionCol.Index].Value != null && (bool)row.Cells[SelectedQuestionCol.Index].Value) {
                    selectedQuestions.Add((TestService.QuestionBase)row.Tag);
                }
            }

            if (selectedQuestions.Count > 0) {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.DefaultExt = "nvn";
                dlg.Filter = "NvnTest files|*.nvn";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    LoadSave.Save(selectedQuestions, typeof(List<TestService.QuestionBase>), dlg.FileName);
                }
            } else {
                MessageBox.Show("Please select questions which you like to export", "Select questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportQuestions_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "NvnTest Files|*.nvn";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK) {
                List<TestService.QuestionBase> questions = (List<TestService.QuestionBase>)LoadSave.Load(typeof(List<TestService.QuestionBase>), dlg.FileName);

                if (questions != null && questions.Count > 0) {
                    ImportQuestionsForm importQuestionsForm = new ImportQuestionsForm();
                    importQuestionsForm.Questions = questions;
                    importQuestionsForm.LoadForm();
                    if (importQuestionsForm.ShowDialog() == DialogResult.OK) {
                        List<TestService.QuestionBase> selectedQuestions = importQuestionsForm.SelectedQuestions;
                        ImportQuestions(selectedQuestions);
                    }
                }
            }
        }

        private void ImportQuestions(List<TestService.QuestionBase> questions) {
            foreach (TestService.QuestionBase question in questions) {
                question.Id = 0;
                question.AdminId = ServiceManager.Instance.UserInfo.Id;
                question.DateTimeCreated = question.DateTimeModified = DateTime.Now;
                question.TempId = Guid.NewGuid().ToString().Replace("-", "");

                object response = ServiceManager.Instance.UpdateQuestion(question);

                if (response != null) {
                    TestService.QuestionBase questionResponse = (TestService.QuestionBase)response;

                    AddQuestionToGrid(questionResponse);
                }
            }
        }

        private void btnQuestionCategories_Click(object sender, EventArgs e) {
            QuestionCategoriesForm questionCategoriesForm = new QuestionCategoriesForm();
            questionCategoriesForm.LoadForm();
            questionCategoriesForm.ShowDialog();
        }

        private void btnQuestionLevels_Click(object sender, EventArgs e) {
            QuestionLevelsForm questionlevelsForm = new QuestionLevelsForm();
            questionlevelsForm.LoadForm();
            questionlevelsForm.ShowDialog();
        }

        private void pbFirst_Click(object sender, EventArgs e) {
            currentIndex = 0;
            LoadControl();
        }

        private void pbPrevious_Click(object sender, EventArgs e) {
            if (currentIndex > 0) {
                currentIndex--;
                LoadControl();
            }
        }

        private void pbNext_Click(object sender, EventArgs e) {
            if (currentIndex < maxPages - 1) {
                currentIndex++;
                LoadControl();
            }
        }

        private void pbLast_Click(object sender, EventArgs e) {
            currentIndex = maxPages - 1;
            LoadControl();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) {
            currentIndex = 0;
            LoadControl();
        }

        private TestService.QuestionType GetQuestionType() {
            TestService.QuestionType questionType = TestService.QuestionType.Objective;
            switch (cmbFilter.SelectedIndex) {
                case 1: questionType = TestService.QuestionType.Objective; break;
                case 2: questionType = TestService.QuestionType.Programming; break;
                case 3: questionType = TestService.QuestionType.AutoProgramming; break;
                case 4: questionType = TestService.QuestionType.WebProgramming; break;
            }

            return questionType;
        }
    }
}
