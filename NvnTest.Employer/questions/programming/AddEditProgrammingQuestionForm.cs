using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditProgrammingQuestionForm : Form {
        private TestService.ProgrammingQuestion programmingQuestion;

        public AddEditProgrammingQuestionForm() {
            InitializeComponent();
        }

        public TestService.ProgrammingQuestion ProgrammingQuestion {
            get { return programmingQuestion; }
            set { programmingQuestion = value; }
        }

        private void AddEditProgrammingQuestionForm_Load(object sender, EventArgs e) {
            selectQuestionCategoryCtrl1.LoadControl();
            
            if (selectQuestionLevelCtrl1.IsLoaded == false) {
                selectQuestionLevelCtrl1.LoadControl();
            }
        }

        public void LoadForm() {
            if (programmingQuestion != null) {
                descriptionCtrl1.Description = programmingQuestion.Desc;
            }

            if (programmingQuestion.Categories != null) {
                selectQuestionCategoryCtrl1.Categories.AddRange(programmingQuestion.Categories);
            }

            selectQuestionLevelCtrl1.LoadControl();
            selectQuestionLevelCtrl1.QuestionLevel = programmingQuestion.DifficultyLevel;

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (programmingQuestion == null) {
                programmingQuestion = new TestService.ProgrammingQuestion();
                programmingQuestion.Type = TestService.QuestionType.Programming;
                programmingQuestion.AdminId = ServiceManager.Instance.UserInfo.Id;
                programmingQuestion.DateTimeCreated = programmingQuestion.DateTimeModified = DateTime.Now;
                programmingQuestion.TempId = Guid.NewGuid().ToString().Replace("-", "");
            }

            programmingQuestion.Desc = descriptionCtrl1.Description;

            programmingQuestion.Categories = selectQuestionCategoryCtrl1.Categories.ToArray();

            programmingQuestion.DifficultyLevel = selectQuestionLevelCtrl1.QuestionLevel;

            object response = ServiceManager.Instance.UpdateQuestion(programmingQuestion);
            if (response != null) {
                programmingQuestion = (TestService.ProgrammingQuestion)response;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private bool ValidInput() {
            if (String.IsNullOrEmpty(descriptionCtrl1.Description)) {
                MessageBox.Show("Question description cannot be empty. Please enter question description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
