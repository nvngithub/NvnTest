using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class QuestionsSummaryCtrl : UserControl {
        public event EventHandler ViewObjectiveQuestionsClicked;
        public event EventHandler ViewProgrammingQuestionsClicked;
        public event EventHandler SubmitPreviewClicked;

        public QuestionsSummaryCtrl() {
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
            int objectiveQuestionsCount = ServiceManager.Instance.Questions.ObjectiveQuestions.Length;
            lblObjectiveQuestionsCount.Text = "Number of questions: " + objectiveQuestionsCount;

            if (objectiveQuestionsCount == 0) {
                grpObjectiveQuestions.Visible = false;
            }

            int programmingQuestionsCount = ServiceManager.Instance.Questions.SQLQuestions.Length;
            programmingQuestionsCount += ServiceManager.Instance.Questions.ProgrammingQuestions.Length;
            programmingQuestionsCount += ServiceManager.Instance.Questions.AutoProgrammingQuestions.Length;
            programmingQuestionsCount += ServiceManager.Instance.Questions.WebProgrammingQuestions.Length;
            lblProgrammingQuestionsCount.Text = "Number of questions: " + programmingQuestionsCount;

            if (programmingQuestionsCount == 0) {
                grpProgrammingQuestions.Visible = false;
            }

            testInfoCtrl1.LoadControl();
        }

        private void btnViewObjectiveQuestions_Click(object sender, EventArgs e) {
            if (ViewObjectiveQuestionsClicked != null) ViewObjectiveQuestionsClicked(this, null);
        }

        private void btnViewProgrammingQuestions_Click(object sender, EventArgs e) {
            if (ViewProgrammingQuestionsClicked != null) ViewProgrammingQuestionsClicked(this, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (SubmitPreviewClicked != null) SubmitPreviewClicked(this, null);
        }
    }
}
