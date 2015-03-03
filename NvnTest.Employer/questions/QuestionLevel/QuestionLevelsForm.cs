using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class QuestionLevelsForm : Form {
        public QuestionLevelsForm() {
            InitializeComponent();
        }

        public void LoadForm() {
            dgrQuestionLevels.Rows.Clear();
            foreach (uint key in ServiceManager.Instance.QuestionLevels.Keys) {
                TestService.QuestionLevel questionLevel = ServiceManager.Instance.QuestionLevels[key];

                AddQuestionLevelToGrid(questionLevel);
            }
        }

        private void btnAddNewLevel_Click(object sender, EventArgs e) {
            AddEditQuestionLevelForm questionLevelForm = new AddEditQuestionLevelForm();
            if (questionLevelForm.ShowDialog() == DialogResult.OK) {
                TestService.QuestionLevel questionLevel = new TestService.QuestionLevel();
                questionLevel.Description = questionLevelForm.Description;
                questionLevel.AdminId = ServiceManager.Instance.UserInfo.Id;
                questionLevel.TempId = Guid.NewGuid().ToString().Replace("-", "");

                object response = ServiceManager.Instance.UpdateQuestionLevel(questionLevel);
                if (response != null) {
                    questionLevel = (TestService.QuestionLevel)response;
                    ServiceManager.Instance.QuestionLevels.Add(questionLevel.Id, questionLevel);

                    AddQuestionLevelToGrid(questionLevel);
                }
            }
        }

        private void AddQuestionLevelToGrid(TestService.QuestionLevel questionLevel) {
            int index = dgrQuestionLevels.Rows.Add();
            dgrQuestionLevels[DescriptionColumn.Index, index].Value = questionLevel.Description;
            dgrQuestionLevels[EditColumn.Index, index].Value = imageList.Images[0];
            dgrQuestionLevels[DeleteColumn.Index, index].Value = imageList.Images[1];
            dgrQuestionLevels.Rows[index].Tag = questionLevel;
        }


        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void dgrQuestionLevels_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            if (dgrQuestionLevels.Columns[e.ColumnIndex].Name == EditColumn.Name) {
                AddEditQuestionLevelForm questionLevelsForm = new AddEditQuestionLevelForm();
                questionLevelsForm.Description = (string)dgrQuestionLevels[DescriptionColumn.Index, e.RowIndex].Value;
                questionLevelsForm.LoadForm();

                if (questionLevelsForm.ShowDialog() == DialogResult.OK) {
                    TestService.QuestionLevel questionLevel = (TestService.QuestionLevel)dgrQuestionLevels.Rows[e.RowIndex].Tag;
                    questionLevel.Description = questionLevelsForm.Description;
                    object response = ServiceManager.Instance.UpdateQuestionLevel(questionLevel);
                    if (response != null) {
                        questionLevel = (TestService.QuestionLevel)response;
                        if (ServiceManager.Instance.QuestionLevels.ContainsKey(questionLevel.Id)) {
                            ServiceManager.Instance.QuestionLevels[questionLevel.Id] = questionLevel;
                        }

                        dgrQuestionLevels[DescriptionColumn.Index, e.RowIndex].Value = questionLevelsForm.Description;
                    }
                }
            } else if (dgrQuestionLevels.Columns[e.ColumnIndex].Name == DeleteColumn.Name) {
                if (MessageBox.Show("Do you really want to delete this question level ? All questions assigned to this level is set to none.", "Delete question level", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK) {
                    TestService.QuestionLevel questionLevel = (TestService.QuestionLevel)dgrQuestionLevels.Rows[e.RowIndex].Tag;
                    object response = ServiceManager.Instance.RemoveQuestionLevel(questionLevel);
                    if (response != null) {
                        // Remove from cache
                        questionLevel = (TestService.QuestionLevel)response;
                        if (ServiceManager.Instance.QuestionLevels.ContainsKey(questionLevel.Id)) {
                            ServiceManager.Instance.QuestionLevels.Remove(questionLevel.Id);
                        }

                        // Remove row
                        dgrQuestionLevels.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
