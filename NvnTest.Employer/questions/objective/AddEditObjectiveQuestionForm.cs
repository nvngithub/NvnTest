using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditObjectiveQuestionForm : Form {
        TestService.ObjectiveQuestion objectiveQuestion;

        public AddEditObjectiveQuestionForm() {
            InitializeComponent();
        }

        public TestService.ObjectiveQuestion ObjectiveQuestion {
            get { return objectiveQuestion; }
            set { objectiveQuestion = value; }
        }

        private void AddEditObjectiveQuestionForm_Load(object sender, EventArgs e) {
            selectQuestionCategoryCtrl1.LoadControl();

            if (selectQuestionLevelCtrl1.IsLoaded == false) {
                selectQuestionLevelCtrl1.LoadControl();
            }
        }

        public void LoadForm() {
            descriptionCtrl1.Description = objectiveQuestion.Desc; // TODO: use RTF format
            // Create item controls
            List<string> options = new List<string>(objectiveQuestion.Options);
            Dictionary<string, string> answers = FormatAnswers (objectiveQuestion.Answers);
            foreach (string option in options) {
                ObjectiveQuestionItemCtrl objectiveQuestionItemCtrl = new ObjectiveQuestionItemCtrl();
                objectiveQuestionItemCtrl.DeleteOptionClicked += new EventHandler(objectiveQuestionItemCtrl_DeleteOptionClicked);
                objectiveQuestionItemCtrl.OptionText = option;
                string optionIndex = (options.IndexOf(option) + 1).ToString();
                objectiveQuestionItemCtrl.IsAnswer = answers.ContainsKey(optionIndex);
                if (objectiveQuestionItemCtrl.IsAnswer) {
                    objectiveQuestionItemCtrl.Marks = answers[optionIndex];
                }
                pnlOptions.Controls.Add(objectiveQuestionItemCtrl);
            }

            if (objectiveQuestion.Categories != null) {
                selectQuestionCategoryCtrl1.Categories.AddRange(objectiveQuestion.Categories);
            }

            selectQuestionLevelCtrl1.LoadControl();
            selectQuestionLevelCtrl1.QuestionLevel = objectiveQuestion.DifficultyLevel;

            btnSave.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnSave.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.QuestionsPrivilege > 1;
            }
        }

        private Dictionary<string, string> FormatAnswers(string[] answers) {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            foreach (string answer in answers) {
                string[] parts = answer.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (ans.ContainsKey(parts[0]) == false) {
                    ans.Add(parts[0], parts[1]);
                }
            }

            return ans;
        }

        private void objectiveQuestionItemCtrl_DeleteOptionClicked(object sender, EventArgs e) {
            if (sender is ObjectiveQuestionItemCtrl) {
                ObjectiveQuestionItemCtrl objectiveQuestionCtrl = (ObjectiveQuestionItemCtrl)sender;
                if (pnlOptions.Controls.Contains(objectiveQuestionCtrl)) {
                    pnlOptions.Controls.Remove(objectiveQuestionCtrl);
                }
            }
        }

        private void btnAddNewOption_Click(object sender, EventArgs e) {
            ObjectiveQuestionItemCtrl objectiveQuestionItemCtrl = new ObjectiveQuestionItemCtrl();
            objectiveQuestionItemCtrl.DeleteOptionClicked += new EventHandler(objectiveQuestionItemCtrl_DeleteOptionClicked);
            pnlOptions.Controls.Add(objectiveQuestionItemCtrl);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (ValidateInput() == false) return;

            if (objectiveQuestion == null) {
                objectiveQuestion = new TestService.ObjectiveQuestion();
                objectiveQuestion.Type = TestService.QuestionType.Objective;
                objectiveQuestion.AdminId = ServiceManager.Instance.UserInfo.Id;
                objectiveQuestion.DateTimeCreated = objectiveQuestion.DateTimeModified = DateTime.Now;
                objectiveQuestion.TempId = Guid.NewGuid().ToString().Replace("-", "");
            }

            objectiveQuestion.Desc = descriptionCtrl1.Description;

            List<string> options = new List<string>();
            List<string> answers = new List<string>();
            foreach (Control ctrl in pnlOptions.Controls) {
                if (ctrl is ObjectiveQuestionItemCtrl) {
                    ObjectiveQuestionItemCtrl optionCtrl = (ObjectiveQuestionItemCtrl)ctrl;
                    options.Add(optionCtrl.OptionText);
                    if (optionCtrl.IsAnswer) {
                        answers.Add((pnlOptions.Controls.IndexOf(ctrl) + 1).ToString() + "*" + optionCtrl.Marks);
                    }
                }
            }

            objectiveQuestion.Options = options.ToArray();
            objectiveQuestion.Answers = answers.ToArray();

            objectiveQuestion.Categories = selectQuestionCategoryCtrl1.Categories.ToArray();

            objectiveQuestion.DifficultyLevel = selectQuestionLevelCtrl1.QuestionLevel;

            object response = ServiceManager.Instance.UpdateQuestion(objectiveQuestion);
            if (response != null) {
                objectiveQuestion = (TestService.ObjectiveQuestion)response;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ValidateInput() {
            if (String.IsNullOrEmpty(descriptionCtrl1.Description)) {
                MessageBox.Show("Question description cannot be empty. Please enter question description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (pnlOptions.Controls.Count < 2) {
                MessageBox.Show("Objective question contains less than two options. Please add at least two options.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // validate each input option
            foreach (Control ctrl in pnlOptions.Controls) {
                ObjectiveQuestionItemCtrl itemCtrl = (ObjectiveQuestionItemCtrl)ctrl;
                if (itemCtrl.ValidateInput() == false) { return false; }
            }
            // At least one is answer
            bool answerExists = false;
            foreach (Control ctrl in pnlOptions.Controls) {
                ObjectiveQuestionItemCtrl itemCtrl = (ObjectiveQuestionItemCtrl)ctrl;
                if (itemCtrl.IsAnswer) {
                    answerExists = true; 
                    break;
                }
            }
            if (answerExists == false) {
                MessageBox.Show("Correct option for this objective question is not selected. Please choose a correct option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
