using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditPaperForm : Form {
        private TestService.Paper paper;
        Dictionary<TestService.QuestionType, List<string>> idsByType = new Dictionary<TestService.QuestionType, List<string>>();
        private uint currentIndex = 0;
        private uint maxPages = 0;
        private bool loadingQuestions = false;

        public AddEditPaperForm() {
            InitializeComponent();

            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Multiple choice questions");
            cmbFilter.Items.Add("Programming questions");
            cmbFilter.Items.Add("Programming questions (Auto Evaluation)");
            cmbFilter.Items.Add("Web programming");
        }

        public TestService.Paper Paper {
            get { return paper; }
            set { paper = value; }
        }

        public void LoadForm() {
            if (paper != null) {
                txtPaperName.Text = paper.Name;
                txtDescription.Text = paper.Desc;

                string[] ids = paper.QuestionIds.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in ids) {
                    string[] idType = id.Split("|".ToCharArray());
                    TestService.QuestionType type = (TestService.QuestionType)Enum.Parse(typeof(TestService.QuestionType), idType[1]);
                    if (idsByType.ContainsKey(type) == false) {
                        idsByType.Add(type, new List<string>());
                    }

                    idsByType[type].Add(idType[0]);
                }
            }

            LoadQuestions();

            SetSelectedQuestionsCount();

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.PapersPrivilege > 1;
            }
        }

        private void LoadQuestions() {
            loadingQuestions = true;

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

            TestService.Questions questions = (TestService.Questions)response;
            AddQuestionsToGrid(questions.ObjectiveQuestions);
            AddQuestionsToGrid(questions.SQLQuestions);
            AddQuestionsToGrid(questions.ProgrammingQuestions);
            AddQuestionsToGrid(questions.AutoProgrammingQuestions);
            AddQuestionsToGrid(questions.WebProgrammingQuestions);

            lblIndex.Text = (currentIndex + 1).ToString();

            loadingQuestions = false;
        }

        private void AddQuestionsToGrid<T>(T[] questions) where T : TestService.QuestionBase {
            foreach (TestService.QuestionBase question in questions) {
                AddQuestionToGrid(question);
            }
        }

        private void AddQuestionToGrid(TestService.QuestionBase question) {
            int index = dgrQuestions.Rows.Add();
            dgrQuestions[DescriptionCol.Index, index].Value = question.Desc;
            dgrQuestions[QuestionTypeCol.Index, index].Value = question.Type;
            if (IsAlreadyExists(question)) {
                ((DataGridViewCheckBoxCell)dgrQuestions[SelectCol.Name, index]).Value = true;
            }
            dgrQuestions.Rows[index].Tag = question;
        }

        private bool IsAlreadyExists(TestService.QuestionBase question) {
            if (idsByType.ContainsKey(question.Type)) {
                return idsByType[question.Type].Contains(question.Id.ToString());
            }
            return false;
        }

        private void SetSelectedQuestionsCount() {
            int count = 0;
            foreach (TestService.QuestionType questionType in idsByType.Keys) {
                count += idsByType[questionType].Count;
            }

            lblSelectedQuestionsCount.Text = "" + count;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (paper == null) {
                paper = new TestService.Paper();
                paper.TempId = Guid.NewGuid().ToString().Replace("-", "");
                paper.AdminId = ServiceManager.Instance.UserInfo.Id;
            }

            paper.Name = txtPaperName.Text;
            paper.Desc = txtDescription.Text;
            // set question ids
            List<string> questionIds = new List<string>();
            foreach (TestService.QuestionType type in idsByType.Keys) {
                List<string> ids = idsByType[type];
                foreach (string id in ids) {
                    questionIds.Add(id + "|" + type.ToString() + "|0");
                }
            }

            paper.QuestionIds = string.Join(",", questionIds.ToArray());

            object response = ServiceManager.Instance.UpdatePaper(paper);
            if (response != null) {
                paper = (TestService.Paper)response;
                if (ServiceManager.Instance.Papers.ContainsKey(paper.Id) == false) {
                    ServiceManager.Instance.Papers.Add(paper.Id, paper);
                } else {
                    ServiceManager.Instance.Papers[paper.Id] = paper;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidInput() {
            if (String.IsNullOrEmpty(txtPaperName.Text)) {
                MessageBox.Show("Paper name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtDescription.Text)) {
                MessageBox.Show("Paper description is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool questionSelected = false;
            for (int i = 0; i < dgrQuestions.Rows.Count; i++) {
                if (dgrQuestions[SelectCol.Name, i].Value != null) {
                    questionSelected = true; break;
                }
            }

            if (questionSelected == false) {
                MessageBox.Show("You have not selected any question for this paper.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }

        private void pbFirst_Click(object sender, EventArgs e) {
            currentIndex = 0;
            LoadQuestions();
        }

        private void pbPrevious_Click(object sender, EventArgs e) {
            if (currentIndex > 0) {
                currentIndex--;
                LoadQuestions();
            }
        }

        private void pbNext_Click(object sender, EventArgs e) {
            if (currentIndex < maxPages - 1) {
                currentIndex++;
                LoadQuestions();
            }
        }

        private void pbLast_Click(object sender, EventArgs e) {
            currentIndex = maxPages - 1;
            LoadQuestions();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) {
            currentIndex = 0;
            LoadQuestions();
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

        private void dgrQuestions_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dgrQuestions.IsCurrentCellDirty) {
                dgrQuestions.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgrQuestions_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (loadingQuestions || e.RowIndex < 0) return;

            TestService.QuestionBase question = (TestService.QuestionBase)dgrQuestions.Rows[e.RowIndex].Tag;
            if (idsByType.ContainsKey(question.Type) == false) {
                idsByType.Add(question.Type, new List<string>());
            }

            string id = "" + question.Id;
            bool value = (bool)((DataGridViewCheckBoxCell)dgrQuestions.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value;
            if (value) {
                if (idsByType[question.Type].Contains(id) == false) {
                    idsByType[question.Type].Add(id);
                }
            } else {
                if (idsByType[question.Type].Contains(id)) {
                    idsByType[question.Type].Remove(id);
                }
            }

            SetSelectedQuestionsCount();
        }

        private void chkSelectedQuestions_CheckedChanged(object sender, EventArgs e) {
            cmbFilter.SelectedIndex = 0;

            cmbFilter.Enabled = chkSelectedQuestions.Checked == false;

            LoadQuestions();

            if (chkSelectedQuestions.Checked) {
                for (int i = dgrQuestions.Rows.Count - 1; i >= 0; i--) {
                    DataGridViewRow row = dgrQuestions.Rows[i];
                    TestService.QuestionBase question = (TestService.QuestionBase)row.Tag;
                    string id = "" + question.Id;

                    if (idsByType.ContainsKey(question.Type) == false || idsByType[question.Type].Contains(id) == false) {
                        dgrQuestions.Rows.Remove(row);
                    }
                }
            }
        }
    }
}