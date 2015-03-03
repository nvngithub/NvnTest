using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AutoPaperConfigItemCtrl : UserControl {
        public event EventHandler DeleteItemClicked;
        private string config;

        public AutoPaperConfigItemCtrl() {
            InitializeComponent();

            LoadCategoriesAndLevels();
        }

        public string Config {
            get {
                bool isValid = UpdateConfigValue();
                if (isValid == false) return string.Empty;
                else return config;
            }
            set { config = value; }
        }

        public void LoadControl() {
            string[] configItems = config.Split("|".ToCharArray());
            // Question type
            TestService.QuestionType questionType = (TestService.QuestionType)Enum.Parse(typeof(TestService.QuestionType), configItems[0]);
            switch (questionType) {
                case TestService.QuestionType.Objective: rbMCQ.Checked = true; break;
                case TestService.QuestionType.Programming: rbProgramming.Checked = true; break;
                case TestService.QuestionType.WebProgramming: rbWebProgramming.Checked = true; break;
            }
            // Number of questions
            txtQuestionsCount.Text = configItems[1];
            // Difficulty level
            cmbDifficultyLevel.SelectedValue = Convert.ToUInt32(configItems[2]);
            // Question category
            cmbQuestionCategories.SelectedValue = Convert.ToUInt32(configItems[3]);
        }

        private void LoadCategoriesAndLevels() {
            // Load question categories
            List<TestService.QuestionCategory> questionCategoriesTemp = new List<TestService.QuestionCategory>();
            foreach (TestService.QuestionCategory cat in ServiceManager.Instance.QuestionCategories.Values) {
                questionCategoriesTemp.Add(cat);
            }

            cmbQuestionCategories.DataSource = questionCategoriesTemp;
            cmbQuestionCategories.DisplayMember = "Name";
            cmbQuestionCategories.ValueMember = "Id";
            
            // Load question difficulty levels
            List<TestService.QuestionLevel> questionLevelsTemp = new List<TestService.QuestionLevel>();
            foreach (TestService.QuestionLevel level in ServiceManager.Instance.QuestionLevels.Values) {
                questionLevelsTemp.Add(level);
            }

            cmbDifficultyLevel.DataSource = questionLevelsTemp;
            cmbDifficultyLevel.DisplayMember = "Description";
            cmbDifficultyLevel.ValueMember = "Id";
        }

        private bool UpdateConfigValue() {
            if (IsValidInput() == false) return false;

            string questionType = string.Empty;
            if (rbMCQ.Checked) {
                questionType = TestService.QuestionType.Objective.ToString();
            } else if (rbProgramming.Checked) {
                questionType = TestService.QuestionType.Programming.ToString();
            } else if (rbWebProgramming.Checked) {
                questionType = TestService.QuestionType.WebProgramming.ToString();
            }

            config = questionType + "|" + txtQuestionsCount.Text + "|" + cmbDifficultyLevel.SelectedValue + "|" + cmbQuestionCategories.SelectedValue;
            
            return true;
        }        

        private void btnDelete_Click(object sender, EventArgs e) {
            if (DeleteItemClicked != null) {
                DeleteItemClicked(this, null);
            }
        }

        private bool IsValidInput() {
            if (String.IsNullOrEmpty(txtQuestionsCount.Text)) {
                MessageBox.Show("Questions count is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check for valid number
            uint count;
            bool parsed = UInt32.TryParse(txtQuestionsCount.Text, out count);
            if (parsed == false) {
                MessageBox.Show("Questions count:" + txtQuestionsCount.Text + " is not in valid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (count == 0) {
                MessageBox.Show("Questions count cannot be zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDifficultyLevel.SelectedValue == null) {
                MessageBox.Show("Please select questions difficulty level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbQuestionCategories.SelectedValue == null) {
                MessageBox.Show("Please select questions category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check whether number of questions given exists for the given category and level
            TestService.QuestionType type = TestService.QuestionType.Objective;
            if (rbMCQ.Checked) {
                type = TestService.QuestionType.Objective;
            } else if (rbProgramming.Checked) {
                type = TestService.QuestionType.Programming;
            } else if (rbWebProgramming.Checked) {
                type = TestService.QuestionType.WebProgramming;
            }
            long actualCount = (long)ServiceManager.Instance.GetQuestionsCountByCategoryLevelType(type, count, (uint)cmbQuestionCategories.SelectedValue, (uint)cmbDifficultyLevel.SelectedValue);
            if (actualCount < count) {
                string selectedCategory = cmbQuestionCategories.Text;
                string selectedLevel = cmbDifficultyLevel.Text;
                string questionType = string.Empty;
                if (rbMCQ.Checked) {
                    questionType = "multiple choice questions";
                } else if (rbProgramming.Checked) {
                    questionType = "programming";
                } else if (rbWebProgramming.Checked) {
                    questionType = "web programming";
                }

                MessageBox.Show(String.Format("Questions count: {0} is invalid because only {1} {2} questions available in database for difficulty level: {3} and category: {4} .", count, actualCount, questionType, selectedLevel, selectedCategory), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}
