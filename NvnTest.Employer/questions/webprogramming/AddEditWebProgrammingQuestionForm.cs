using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditWebProgrammingQuestionForm : Form {
        private TestService.WebProgrammingQuestion webProgrammingQuestion;

        public AddEditWebProgrammingQuestionForm() {
            InitializeComponent();
        }

        public TestService.WebProgrammingQuestion WebProgrammingQuestion {
            get { return webProgrammingQuestion; }
            set { webProgrammingQuestion = value; }
        }

        private void AddEditWebProgrammingQuestionForm_Load(object sender, EventArgs e) {
            selectQuestionCategoryCtrl1.LoadControl();

            if (selectQuestionLevelCtrl1.IsLoaded == false) {
                selectQuestionLevelCtrl1.LoadControl();
            }
        }

        public void LoadForm() {
            if (webProgrammingQuestion != null) {
                descriptionCtrl1.Description = webProgrammingQuestion.Desc;
            }

            if (webProgrammingQuestion.Categories != null) {
                selectQuestionCategoryCtrl1.Categories.AddRange(webProgrammingQuestion.Categories);
            }

            selectQuestionLevelCtrl1.LoadControl();
            selectQuestionLevelCtrl1.QuestionLevel = webProgrammingQuestion.DifficultyLevel;

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidInput() == false) return;

            if (webProgrammingQuestion == null) {
                webProgrammingQuestion = new TestService.WebProgrammingQuestion();
                webProgrammingQuestion.Type = TestService.QuestionType.WebProgramming;
                webProgrammingQuestion.AdminId = ServiceManager.Instance.UserInfo.Id;
                webProgrammingQuestion.DateTimeCreated = webProgrammingQuestion.DateTimeModified = DateTime.Now;
                webProgrammingQuestion.TempId = Guid.NewGuid().ToString().Replace("-", "");
            }

            webProgrammingQuestion.Desc = descriptionCtrl1.Description;

            webProgrammingQuestion.Categories = selectQuestionCategoryCtrl1.Categories.ToArray();

            webProgrammingQuestion.DifficultyLevel = selectQuestionLevelCtrl1.QuestionLevel;

            object response = ServiceManager.Instance.UpdateQuestion(webProgrammingQuestion);
            if (response != null) {
                webProgrammingQuestion = (TestService.WebProgrammingQuestion)response;
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
