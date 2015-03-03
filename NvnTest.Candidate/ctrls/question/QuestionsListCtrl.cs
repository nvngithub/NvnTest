using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class QuestionsListCtrl : UserControl {
        public event EventHandler SubmitTestClicked;
        public event EventHandler<ViewQuestionEventArgs> ViewQuestionClicked;
        public event EventHandler WebReferenceClicked;
        public event EventHandler HomeClicked;

        public QuestionsListCtrl() {
            InitializeComponent();

            ShowLogo();

            dgrQuestions.RowTemplate.Height = 55;

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
            AddToGrid(ServiceManager.Instance.Questions.SQLQuestions);
            AddToGrid(ServiceManager.Instance.Questions.ProgrammingQuestions);
            AddToGrid(ServiceManager.Instance.Questions.AutoProgrammingQuestions);
            AddToGrid(ServiceManager.Instance.Questions.WebProgrammingQuestions);

            testInfoCtrl1.LoadControl();
        }

        private void AddToGrid<T>(T[] questions) where T : TestService.QuestionBase {
            foreach (TestService.QuestionBase question in questions) {
                int index = dgrQuestions.Rows.Add();
                dgrQuestions[IndexCol.Index, index].Value = index + 1;
                dgrQuestions[DescCol.Index, index].Value = question.Desc;
                switch (question.Type) {
                    case TestService.QuestionType.Sql: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.database; break;
                    case TestService.QuestionType.Programming: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.algo; break;
                    case TestService.QuestionType.AutoProgramming: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.algo; break;
                    case TestService.QuestionType.WebProgramming: dgrQuestions[QuestionTypeCol.Index, index].Value = Properties.Resources.internet; break;
                }
                
                dgrQuestions.Rows[index].Tag = question;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ViewSelectedQuestion();
        }

        private void btnViewSelectedQuestion_Click(object sender, EventArgs e) {
            ViewSelectedQuestion();
        }

        private void ViewSelectedQuestion() {
            if (dgrQuestions.SelectedRows.Count > 0) {
                if (ViewQuestionClicked != null) ViewQuestionClicked(this, new ViewQuestionEventArgs((TestService.QuestionBase)dgrQuestions.SelectedRows[0].Tag));
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (SubmitTestClicked != null) SubmitTestClicked(this, null);
        }

        private void btnWebReference_Click(object sender, EventArgs e) {
            if (WebReferenceClicked != null) WebReferenceClicked(this, null);
        }

        private void btnHome_Click(object sender, EventArgs e) {
            if (HomeClicked != null) HomeClicked(this, null);
        }
    }

    public class ViewQuestionEventArgs : EventArgs {
        private TestService.QuestionBase question;

        public TestService.QuestionBase Question {
            get { return question; }
            set { question = value; }
        }

        public ViewQuestionEventArgs(TestService.QuestionBase question) {
            this.question = question;
        }
    }
}
