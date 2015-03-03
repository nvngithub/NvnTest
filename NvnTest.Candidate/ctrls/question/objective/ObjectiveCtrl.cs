using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class ObjectiveCtrl : UserControl {
        public event EventHandler SubmitPreviewClicked;
        public event EventHandler WebReferenceClicked;
        public event EventHandler HomeClicked;

        public ObjectiveCtrl() {
            InitializeComponent();

            ShowLogo();

            TestTimer.Instance.TimeRemainingReceived += new EventHandler(Instance_TimeRemainingReceived);
        }

        private void Instance_TimeRemainingReceived(object sender, EventArgs e) {
            DateTime timeLeft = (DateTime)sender;
            lblTimeLeft.Text = timeLeft.Hour + ":" + timeLeft.Minute + ":" + timeLeft.Second;
        }

        private void ShowLogo() {
            Control ctrl = new LogoCtrl();
            switch (Common.Common.LogoType) {
                case Common.LogoType.Eduji: ctrl = new EdujiniLogoCtrl(); break;
            }

            ctrl.Dock = DockStyle.Fill;
            pnlLogo.Controls.Add(ctrl);
        }

        public void LoadControl() {
            objectiveQuestionCtrl1.LoadControl();

            testInfoCtrl1.LoadControl();
        }

        public void ViewQuestion(TestService.ObjectiveQuestion question) {
            objectiveQuestionCtrl1.ViewQuestion(question);
        }

        private void btnWebReference_Click(object sender, EventArgs e) {
            if (WebReferenceClicked != null) WebReferenceClicked(this, null);
        }

        private void btnHome_Click(object sender, EventArgs e) {
            if (HomeClicked != null) HomeClicked(this, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (SubmitPreviewClicked != null) SubmitPreviewClicked(this, null);
        }
    }
}
