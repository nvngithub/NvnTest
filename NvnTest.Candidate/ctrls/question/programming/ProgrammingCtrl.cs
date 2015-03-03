using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class ProgrammingCtrl : UserControl, INvnTestControl {
        private TestService.ProgrammingQuestion programmingQuestion;
        private TestService.AutoProgrammingQuestion autoProgrammingQuestion;
        private bool isAutoExecution;
        private static IProgrammingQuestionControl currentCtrl;

        public ProgrammingCtrl() {
            InitializeComponent();
        }

        public TestService.ProgrammingQuestion ProgrammingQuestion {
            get { return programmingQuestion; }
            set { programmingQuestion = value; }
        }

        public TestService.AutoProgrammingQuestion AutoProgrammingQuestion {
            get { return autoProgrammingQuestion; }
            set { autoProgrammingQuestion = value; }
        }

        public bool IsAutoExecution {
            get { return isAutoExecution; }
            set { isAutoExecution = value; }
        }

        public void LoadControl() {
            currentCtrl = null;
            if (isAutoExecution == false && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(programmingQuestion)) {
                TestService.ProgrammingQuestionTestAnswer answer = (TestService.ProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[programmingQuestion];
                cmbAnswerType.SelectedIndex = (int)answer.AnswerType;
            } else if (isAutoExecution && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(autoProgrammingQuestion)) {
                TestService.AutoProgrammingQuestionTestAnswer answer = (TestService.AutoProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[autoProgrammingQuestion];
                cmbAnswerType.SelectedIndex = (int)answer.AnswerType;
            } else {
                cmbAnswerType.SelectedIndex = 0;
            }
        }

        private void cmbAnswerType_SelectedIndexChanged(object sender, EventArgs e) {
            int windowIndex = 0;
            if (currentCtrl != null) {
                windowIndex = currentCtrl.WindowIndex;
                SaveAnswer();
            }

            switch (cmbAnswerType.SelectedIndex) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // C, C++, C#, VB.NET, Java programming
                    if (cmbAnswerType.SelectedIndex == 4 && String.IsNullOrEmpty(PrerequisitesAdapter.JavaPath)) {
                        MessageBoxEx.Show("Java Runtime", "Unable to find Java Runtime. Please install Java Runtime if you want to answer programming questions in Java.");
                    }

                    CodeCtrl codeCtrl = new CodeCtrl();
                    codeCtrl.WindowIndex = windowIndex; 
                    codeCtrl.IsAutoExecution = isAutoExecution;
                    if (isAutoExecution) {
                        codeCtrl.AutoProgrammingQuestion = autoProgrammingQuestion;
                    }

                    if (currentCtrl != null) {
                        codeCtrl.PreviousAnswerType = currentCtrl.AnswerType;
                    } else {
                        codeCtrl.PreviousAnswerType = (TestService.ProgrammingAnswerType)cmbAnswerType.SelectedIndex;
                    }

                    codeCtrl.AnswerType = (TestService.ProgrammingAnswerType)cmbAnswerType.SelectedIndex;
                    
                    codeCtrl.AnswerChanged += new EventHandler(ProgrammingAnswerCtrl_AnswerChanged);
                    codeCtrl.SourceCodeCompiled += new EventHandler(codeCtrl_SourceCodeCompiled);
                    LoadAnswerControl(codeCtrl);
                    break;
                case 5:
                    // Algorithmic
                    AlgoCtrl algoCtrl = new AlgoCtrl();
                    algoCtrl.AnswerChanged += new EventHandler(ProgrammingAnswerCtrl_AnswerChanged);
                    LoadAnswerControl(algoCtrl);
                    break;
                case 6:
                    // Descriptive
                    DescCtrl descCtrl = new DescCtrl();
                    descCtrl.AnswerChanged += new EventHandler(ProgrammingAnswerCtrl_AnswerChanged);
                    LoadAnswerControl(descCtrl);
                    break;
            }
        }

        private void LoadAnswerControl(Control ctrl) {
            pnlContainer.Controls.Clear();

            ctrl.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(ctrl);

            IProgrammingQuestionControl programmingCtrl = (IProgrammingQuestionControl)ctrl;
            if (isAutoExecution == false) {
                programmingCtrl.QuestionText = programmingQuestion.Desc;
            } else if (isAutoExecution) {
                programmingCtrl.QuestionText = autoProgrammingQuestion.Desc;
            }

            if (isAutoExecution == false && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(programmingQuestion)) {
                TestService.ProgrammingQuestionTestAnswer answer = (TestService.ProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[programmingQuestion];
                programmingCtrl.Code = answer.Code;
                programmingCtrl.Exe = answer.Exe;
                programmingCtrl.ExeCode = answer.ExeCode;
            } else if (isAutoExecution && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(autoProgrammingQuestion)) {
                TestService.AutoProgrammingQuestionTestAnswer answer = (TestService.AutoProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[autoProgrammingQuestion];
                programmingCtrl.Code = answer.Code;
                programmingCtrl.Exe = answer.Exe;
                programmingCtrl.ExeCode = answer.ExeCode;
            }

            programmingCtrl.LoadControl();

            currentCtrl = programmingCtrl;
        }

        private void codeCtrl_SourceCodeCompiled(object sender, EventArgs e) {
            SaveAnswer();
            btnSave.Enabled = false;
        }

        private void ProgrammingAnswerCtrl_AnswerChanged(object sender, EventArgs e) {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveAnswer();
        }

        #region INvnTestControl Members

        public void SaveAnswer() {
            if (isAutoExecution == false && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(programmingQuestion)) {
                TestService.ProgrammingQuestionTestAnswer programmingQuestionAnswer = (TestService.ProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[programmingQuestion];
                programmingQuestionAnswer.AnswerType = currentCtrl.AnswerType;
                programmingQuestionAnswer.Code = currentCtrl.Code;
                programmingQuestionAnswer.Exe = currentCtrl.Exe;
                programmingQuestionAnswer.ExeCode = currentCtrl.ExeCode;

                ServiceManager.Instance.SaveTestAnswersLocal();
            } else if (isAutoExecution && ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(autoProgrammingQuestion)) {
                TestService.AutoProgrammingQuestionTestAnswer autoProgrammingQuestionAnswer = (TestService.AutoProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[autoProgrammingQuestion];
                autoProgrammingQuestionAnswer.AnswerType = currentCtrl.AnswerType;
                autoProgrammingQuestionAnswer.Code = currentCtrl.Code;
                autoProgrammingQuestionAnswer.Exe = currentCtrl.Exe;
                autoProgrammingQuestionAnswer.ExeCode = currentCtrl.ExeCode;

                ServiceManager.Instance.SaveTestAnswersLocal();
            }
        }

        #endregion

        private void cmbAnswerType_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            if (e.Index != -1) {
                Bitmap img = Properties.Resources.csharp;
                switch (e.Index) {
                    case 0: img = Properties.Resources.c; break;
                    case 1: img = Properties.Resources.cpp; break;
                    case 2: img = Properties.Resources.csharp; break;
                    case 3: img = Properties.Resources.vbnet; break;
                    case 4: img = Properties.Resources.java; break;
                    case 5: img = Properties.Resources.algo; break;
                    case 6: img = Properties.Resources.desc; break;
                }

                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y, 20, 20);
                e.Graphics.DrawString(cmbAnswerType.Items[e.Index].ToString(), cmbAnswerType.Font, Brushes.Black, new RectangleF(e.Bounds.X + 30, e.Bounds.Y + 3, 200, 25));
            }

            e.DrawFocusRectangle();
        }
    }
}
