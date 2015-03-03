using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class QuestionViewCtrl : UserControl {
        public event EventHandler ViewProgrammingQuestionsClicked;
        public event EventHandler SubmitPreviewClicked;
        public event EventHandler WebReferenceClicked;
        public event EventHandler HomeClicked;

        public QuestionViewCtrl() {
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

        public void LoadQuestion(TestService.QuestionBase question) {
            testInfoCtrl1.LoadControl();

            this.SuspendLayout();
            pnlContainer.Controls.Clear();

            Control ctrl = null;
            switch (question.Type) {
                case TestService.QuestionType.Sql:
                    SqlCtrl sqlCtrl = new SqlCtrl();
                    sqlCtrl.SqlQuestion = (TestService.SqlQuestion)question;
                    sqlCtrl.LoadControl();
                    ctrl = sqlCtrl;
                    break;
                case TestService.QuestionType.Programming:
                    ProgrammingCtrl programmingCtrl = new ProgrammingCtrl();
                    programmingCtrl.IsAutoExecution = false;
                    programmingCtrl.AutoProgrammingQuestion = null;
                    programmingCtrl.ProgrammingQuestion = (TestService.ProgrammingQuestion)question;
                    programmingCtrl.LoadControl();
                    ctrl = programmingCtrl;
                    break;
                case TestService.QuestionType.AutoProgramming:
                    ProgrammingCtrl autoProgrammingCtrl = new ProgrammingCtrl();
                    autoProgrammingCtrl.IsAutoExecution = true;
                    autoProgrammingCtrl.AutoProgrammingQuestion = (TestService.AutoProgrammingQuestion)question;
                    autoProgrammingCtrl.ProgrammingQuestion = null;
                    autoProgrammingCtrl.LoadControl();
                    ctrl = autoProgrammingCtrl;
                    break;
                case TestService.QuestionType.WebProgramming:
                    WebCtrl webProgrammingCtrl = new WebCtrl();
                    webProgrammingCtrl.WebProgrammingQuestion = (TestService.WebProgrammingQuestion)question;
                    webProgrammingCtrl.LoadControl();
                    ctrl = webProgrammingCtrl;
                    break;
            }

            ctrl.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(ctrl);
            this.ResumeLayout();
        }

        public void SaveAnswer() {
            foreach (Control ctrl in pnlContainer.Controls) {
                if (ctrl is INvnTestControl) {
                    ((INvnTestControl)ctrl).SaveAnswer();
                }
            }
        }

        private void btnViewProgrammingQuestions_Click(object sender, EventArgs e) {
            if (ViewProgrammingQuestionsClicked != null) ViewProgrammingQuestionsClicked(this, null);
        }

        private void btnSubmitPreview_Click(object sender, EventArgs e) {
            if (SubmitPreviewClicked != null) SubmitPreviewClicked(this, null);
        }

        private void btnWebReference_Click(object sender, EventArgs e) {
            if (WebReferenceClicked != null) WebReferenceClicked(this, null);
        }

        private void btnHome_Click(object sender, EventArgs e) {
            if (HomeClicked != null) HomeClicked(this, null);
        }
    }
}