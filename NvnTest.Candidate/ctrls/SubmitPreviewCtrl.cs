using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class SubmitPreviewCtrl : UserControl {
        public event EventHandler SubmitTestAnswersClicked;
        public event EventHandler HomeClicked;
        public event EventHandler WebReferenceClicked;
        public event EventHandler<ViewQuestionEventArgs> ViewQuestionClicked;
        private int questionIndex = 0;

        public SubmitPreviewCtrl() {
            InitializeComponent();

            ShowLogo();

            TestTimer.Instance.TimeRemainingReceived += new EventHandler(Instance_TimeRemainingReceived);
        }

        private void ShowLogo() {
            Control ctrl = new LogoCtrl();
            switch (Common.Common.LogoType) {
                case Common.LogoType.Eduji: ctrl = new EdujiniLogoCtrl(); break;
            }

            ctrl.Dock = DockStyle.Fill;
            pnlLogo.Controls.Add(ctrl);
        }

        private void Instance_TimeRemainingReceived(object sender, EventArgs e) {
            DateTime timeLeft = (DateTime)sender;
            lblTimeLeft.Text = timeLeft.Hour + ":" + timeLeft.Minute + ":" + timeLeft.Second;
        }

        public void LoadControl() {
            dgrQuestions.Rows.Clear();
            questionIndex = 0;

            AddToPreview(ServiceManager.Instance.Questions.ObjectiveQuestions);
            AddToPreview(ServiceManager.Instance.Questions.SQLQuestions);
            AddToPreview(ServiceManager.Instance.Questions.ProgrammingQuestions);
            AddToPreview(ServiceManager.Instance.Questions.AutoProgrammingQuestions);
            AddToPreview(ServiceManager.Instance.Questions.WebProgrammingQuestions);

            testInfoCtrl1.LoadControl();
        }

        private void AddToPreview<T>(T[] questions) where T : TestService.QuestionBase {
            foreach (TestService.QuestionBase question in questions) {
                questionIndex++;

                CreateDescription(question);
                
                CreateAnswer(question);                
            }
        }

        private void CreateDescription(TestService.QuestionBase question) {
            string desc = question.Desc;
            switch (question.Type) {
                case TestService.QuestionType.Objective:
                    TestService.ObjectiveQuestion objectiveQuestion = (TestService.ObjectiveQuestion)question;
                    for (int i = 0; i < objectiveQuestion.Options.Length; i++) {
                        desc += Environment.NewLine + (i + 1) + " " + objectiveQuestion.Options[i];
                    }
                    break;
                case TestService.QuestionType.Sql: break;
                case TestService.QuestionType.Programming: break;
                case TestService.QuestionType.AutoProgramming: break;
                case TestService.QuestionType.WebProgramming: break;
            }

            AddDescription(desc, question);
        }

        private void CreateAnswer(TestService.QuestionBase question) {
            string answer = string.Empty;
            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(question)) {
                switch (question.Type) {
                    case TestService.QuestionType.Objective:
                        TestService.ObjectiveQuestionTestAnswer objectiveTestAnswer = (TestService.ObjectiveQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[question];
                        TestService.ObjectiveQuestion objectiveQuestion = (TestService.ObjectiveQuestion)question;
                        if (objectiveTestAnswer.SelectedOptions != null && objectiveTestAnswer.SelectedOptions.Length > 0) {
                            foreach (int selectedOption in objectiveTestAnswer.SelectedOptions) {
                                answer += objectiveQuestion.Options[selectedOption] + ", ";
                            }
                            answer = answer.Trim(", ".ToCharArray());
                        }
                        AddAnswer(answer, Color.Gray);
                        break;
                    case TestService.QuestionType.Sql:
                        answer = ((TestService.SqlQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[question]).Sql;
                        AddAnswer(answer, Color.Gray);
                        break;
                    case TestService.QuestionType.Programming:
                        answer = ((TestService.ProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[question]).Code;
                        AddAnswer(answer, Color.Gray);
                        break;
                    case TestService.QuestionType.AutoProgramming:
                        answer = ((TestService.AutoProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[question]).Code;
                        AddAnswer(answer, Color.Gray);
                        break;
                    case TestService.QuestionType.WebProgramming:
                        CreateWebProgrammingQuestionAnswer(((TestService.WebProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[question]).WebNode);
                        break;
                }
            }
        }

        private void CreateWebProgrammingQuestionAnswer(TestService.WebNode rootNode) {
            if (rootNode == null) return;
            foreach (TestService.WebNode node in rootNode.Nodes) {
                switch (node.Type) {
                    case TestService.WebNodeType.Directory: CreateWebProgrammingQuestionAnswer(node); break;
                    case TestService.WebNodeType.HTML:
                    case TestService.WebNodeType.CSS:
                    case TestService.WebNodeType.JavaScript:
                    case TestService.WebNodeType.ASP_DOT_NET:
                        if (String.IsNullOrEmpty(node.Content) == false) {
                            AddFileName(node.Name, Color.Gray);
                            AddAnswer(node.Content, Color.Gray);
                        }
                        break;
                }
            }
        }

        private void AddDescription(string desc, TestService.ServiceDataBase question) {
            int index = dgrQuestions.Rows.Add();
            dgrQuestions[IndexCol.Index, index].Value = questionIndex;
            dgrQuestions[DescCol.Index, index].Value = desc;
            switch (((TestService.QuestionBase)question).Type) {
                case TestService.QuestionType.Objective: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.objective; break;
                case TestService.QuestionType.Sql: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.database; break;
                case TestService.QuestionType.Programming: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.algo; break;
                case TestService.QuestionType.WebProgramming: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.internet; break;
            }
            dgrQuestions[EditCol.Index, index].Value = global::NvnTest.Candidate.Properties.Resources.edit;
            dgrQuestions.Rows[index].Tag = question;
        }

        private void AddAnswer(string answer, Color color) {
            int index = dgrQuestions.Rows.Add();
            dgrQuestions[DescCol.Index, index].Value = String.IsNullOrEmpty(answer) ? "No answer" : answer;
            dgrQuestions[DescCol.Index, index].Style.ForeColor = dgrQuestions[DescCol.Index, index].Style.SelectionForeColor = String.IsNullOrEmpty(answer) ? Color.Red : color;
        }

        private void AddFileName(string filename, Color color) {
            int index = dgrQuestions.Rows.Add();
            dgrQuestions[DescCol.Index, index].Value = filename;
            dgrQuestions[DescCol.Index, index].Style.Font = new Font(dgrQuestions.DefaultCellStyle.Font, FontStyle.Bold);
            dgrQuestions[DescCol.Index, index].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgrQuestions[DescCol.Index, index].Style.ForeColor = dgrQuestions[DescCol.Index, index].Style.SelectionForeColor = color;
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            SubmitForm submitForm = new SubmitForm();
            if (submitForm.ShowDialog() == DialogResult.OK) {
                if (SubmitTestAnswersClicked != null) SubmitTestAnswersClicked(this, null);
            }
        }

        private void btnHome_Click(object sender, EventArgs e) {
            if (HomeClicked != null) HomeClicked(this, null);
        }

        private void dgrQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == EditCol.Index) {
                if (ViewQuestionClicked != null) ViewQuestionClicked(this, new ViewQuestionEventArgs((TestService.QuestionBase)dgrQuestions.Rows[e.RowIndex].Tag));
            }
        }

        private void btnWebReference_Click(object sender, EventArgs e) {
            if (WebReferenceClicked != null) WebReferenceClicked(this, null);
        }
    }
}
