using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditAutoProgrammingQuestionForm : Form {
        private TestService.AutoProgrammingQuestion autoProgrammingQuestion;

        public AddEditAutoProgrammingQuestionForm() {
            InitializeComponent();

            functionSignatureCtrl1.FunctionSignatureChanged += new EventHandler(functionSignatureCtrl1_FunctionSignatureChanged);
        }

        public TestService.AutoProgrammingQuestion AutoProgrammingQuestion {
            get { return autoProgrammingQuestion; }
            set { autoProgrammingQuestion = value; }
        }

        private void AddEditAutoProgrammingQuestionForm_Load(object sender, EventArgs e) {
            selectQuestionCategoryCtrl1.LoadControl();

            if (selectQuestionLevelCtrl1.IsLoaded == false) {
                selectQuestionLevelCtrl1.LoadControl();
            }
        }

        public void LoadForm() {
            if (autoProgrammingQuestion != null) {
                descriptionCtrl1.Description = autoProgrammingQuestion.Desc;
                
                functionSignatureCtrl1.Config = autoProgrammingQuestion.Config;
                functionSignatureCtrl1.LoadControl();

                testCaseCtrl1.TestCases.AddRange(autoProgrammingQuestion.TestCases);
                testCaseCtrl1.Config = autoProgrammingQuestion.Config;
                testCaseCtrl1.LoadControl();
            }

            if (autoProgrammingQuestion.Categories != null) {
                selectQuestionCategoryCtrl1.Categories.AddRange(autoProgrammingQuestion.Categories);
            }

            selectQuestionLevelCtrl1.LoadControl();
            selectQuestionLevelCtrl1.QuestionLevel = autoProgrammingQuestion.DifficultyLevel;

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }
        }

        private void functionSignatureCtrl1_FunctionSignatureChanged(object sender, EventArgs e) {
            testCaseCtrl1.Config = functionSignatureCtrl1.Config;
            testCaseCtrl1.LoadControl();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (autoProgrammingQuestion == null) {
                autoProgrammingQuestion = new TestService.AutoProgrammingQuestion();
                autoProgrammingQuestion.Type = TestService.QuestionType.AutoProgramming;
                autoProgrammingQuestion.AdminId = ServiceManager.Instance.UserInfo.Id;
                autoProgrammingQuestion.DateTimeCreated = autoProgrammingQuestion.DateTimeModified = DateTime.Now;
                autoProgrammingQuestion.TempId = Guid.NewGuid().ToString().Replace("-", "");
            }

            autoProgrammingQuestion.Desc = descriptionCtrl1.Description;
            autoProgrammingQuestion.Config = functionSignatureCtrl1.Config;
            autoProgrammingQuestion.TestCases = testCaseCtrl1.TestCases.ToArray();

            autoProgrammingQuestion.Categories = selectQuestionCategoryCtrl1.Categories.ToArray();

            autoProgrammingQuestion.DifficultyLevel = selectQuestionLevelCtrl1.QuestionLevel;

            object response = ServiceManager.Instance.UpdateQuestion(autoProgrammingQuestion);
            if (response != null) {
                autoProgrammingQuestion = (TestService.AutoProgrammingQuestion)response;
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
