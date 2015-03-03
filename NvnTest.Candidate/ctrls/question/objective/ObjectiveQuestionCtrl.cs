using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ObjectiveQuestionCtrl : UserControl {
        private int index = 0;
        private List<ObjectiveQuestionLocal> localQuestions = new List<ObjectiveQuestionLocal>();

        public ObjectiveQuestionCtrl() {
            InitializeComponent();

            pnlCurrent.BackColor = Color.BlueViolet;
            pnlAnswered.BackColor = Color.YellowGreen;
            pnlUnanswered.BackColor = Color.LightGray;

            navigationCtrl.NextClicked += new EventHandler(navigationCtrl_NextClicked);
            navigationCtrl.PrevClicked += new EventHandler(navigationCtrl_PrevClicked);
            navigationCtrl.FlagClicked += new EventHandler(navigationCtrl_FlagClicked);

            questionsStatusCtrl.ViewQuestionClicked += new EventHandler<ViewObjectiveQuestionEventArgs>(questionsStatusCtrl_ViewQuestionClicked);

            objectiveOptionsCtrl1.AnswerSelectionChanged += new EventHandler(objectiveOptionsCtrl1_AnswerSelectionChanged);
        }

        public void LoadControl() {
            if (localQuestions.Count == 0) {
                // Load all questions into local list.. only for the first time
                foreach (TestService.ObjectiveQuestion question in ServiceManager.Instance.Questions.ObjectiveQuestions) {
                    ObjectiveQuestionLocal localQuestion = new ObjectiveQuestionLocal();
                    localQuestion.Question = question;
                    localQuestion.IsFlagged = false;
                    localQuestion.Status = ObjectiveQuestionStatus.Unanswered;

                    localQuestions.Add(localQuestion);
                }

                questionsStatusCtrl.LoadControl(localQuestions);
            }

            ViewQuestion();
        }

        private void ViewQuestion() {
            lblDescription.Text = localQuestions[index].Question.Desc;
            objectiveOptionsCtrl1.LoadControl(localQuestions[index].Question.Options);

            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(localQuestions[index].Question)) {
                TestService.ObjectiveQuestionTestAnswer answer = (TestService.ObjectiveQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[localQuestions[index].Question];
                objectiveOptionsCtrl1.SetAnswer(answer.SelectedOptions);
            }

            UpdateStatus();
        }

        public void ViewQuestion(TestService.ObjectiveQuestion question) {
            for (int i = 0; i < localQuestions.Count; i++) {
                ObjectiveQuestionLocal localQuestion = localQuestions[i];
                if (localQuestion.Question == question) {
                    index = i; break;
                }
            }

            ViewQuestion();
        }

        // TODO: All question status updated. This to be optimized
        private void UpdateStatus() {
            for (int i = 0; i < localQuestions.Count; i++) {
                if (i == index) {
                    localQuestions[i].Status = ObjectiveQuestionStatus.Current;
                    continue;
                }

                if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(localQuestions[i].Question)) {
                    TestService.ObjectiveQuestionTestAnswer answer = (TestService.ObjectiveQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[localQuestions[i].Question];
                    if (answer.SelectedOptions != null && answer.SelectedOptions.Length > 0) {
                        localQuestions[i].Status = ObjectiveQuestionStatus.Answered;
                    } else {
                        localQuestions[i].Status = ObjectiveQuestionStatus.Unanswered;
                    }
                }
            }

            questionsStatusCtrl.UpdateStatus(localQuestions);
        }
        
        private void navigationCtrl_PrevClicked(object sender, EventArgs e) {
            index--;
            if (index < 0) {
                index = 0;
            }

            ViewQuestion();
        }

        private void navigationCtrl_NextClicked(object sender, EventArgs e) {
            index++;
            if (index >= localQuestions.Count) {
                index = localQuestions.Count - 1;
            }

            ViewQuestion();
        }

        private void navigationCtrl_FlagClicked(object sender, EventArgs e) {
            localQuestions[index].IsFlagged = !localQuestions[index].IsFlagged;
            questionsStatusCtrl.UpdateStatus(localQuestions);
        }

        private void questionsStatusCtrl_ViewQuestionClicked(object sender, ViewObjectiveQuestionEventArgs e) {
            index = e.Index;
            ViewQuestion();
        }

        private void objectiveOptionsCtrl1_AnswerSelectionChanged(object sender, EventArgs e) {
            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(localQuestions[index].Question)) {
                ((TestService.ObjectiveQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[localQuestions[index].Question]).SelectedOptions = objectiveOptionsCtrl1.SelectedOptions;

                ServiceManager.Instance.SaveTestAnswersLocal();
            }
        }
    }
    
    public class ObjectiveQuestionLocal {
        private ObjectiveQuestionStatus status;
        private bool isFlagged;
        private TestService.ObjectiveQuestion question;

        public ObjectiveQuestionStatus Status {
            get { return status; }
            set { status = value; }
        }

        public bool IsFlagged {
            get { return isFlagged; }
            set { isFlagged = value; }
        }

        public TestService.ObjectiveQuestion Question {
            get { return question; }
            set { question = value; }
        }
    }

    public enum ObjectiveQuestionStatus {
        Unanswered,
        Answered,
        Current
    }
}
