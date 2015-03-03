using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NvnTest.Candidate.TestService;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class WebCtrl : UserControl, INvnTestControl {
        private TestService.WebProgrammingQuestion webProgrammingQuestion;

        public WebCtrl() {
            InitializeComponent();

            webFilesCtrl.WebFileSelectionChanging += new EventHandler(webFilesCtrl_WebFileSelectionChanging);
            webFilesCtrl.WebFileSelectionChanged += new EventHandler(webFilesCtrl_WebFileSelectionChanged);

            webCmdCtrl.RunClicked += new EventHandler(webCmdCtrl_RunClicked);
            webCmdCtrl.SaveClicked += new EventHandler(webCmdCtrl_SaveClicked);
        }

        public TestService.WebProgrammingQuestion WebProgrammingQuestion {
            get { return webProgrammingQuestion; }
            set { webProgrammingQuestion = value; }
        }

        public void LoadControl() {
            TextCtrl ctrl = new TextCtrl();
            ctrl.Text = webProgrammingQuestion.Desc;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
            ctrl.Width = splitContainerMain.Panel1.Width - 30;
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ctrl.Location = new Point(10, 10);
            ctrl.ScrollBars = RichTextBoxScrollBars.Both;
            ctrl.ResizeControl();

            splitContainerMain.Panel1.Controls.Add(ctrl);

            // set splitter distance
            splitContainerMain.SplitterDistance = ctrl.Height > 150 ? 150 : (ctrl.Height);
            ctrl.Height = ctrl.Height > 150 ? 150 : ctrl.Height;

            webFilesCtrl.LoadControl();

            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(webProgrammingQuestion)) {
                TestService.WebProgrammingQuestionTestAnswer programmingQuestionAnswer = (TestService.WebProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[webProgrammingQuestion];
                webFilesCtrl.LoadWebNodeHierarchy(programmingQuestionAnswer.WebNode);
            }
        }

        private void webFilesCtrl_WebFileSelectionChanging(object sender, EventArgs e) {
            SaveCurrentNodeContent();
        }

        private void webFilesCtrl_WebFileSelectionChanged(object sender, EventArgs e) {
            WebNode selectedWebNode = webFilesCtrl.SelectedNode;
            if (selectedWebNode != null) {
                webEditorCtrl1.Type = selectedWebNode.Type;
                webEditorCtrl1.Source = selectedWebNode.Content;
                webEditorCtrl1.LoadControl();
            }
        }

        private void webCmdCtrl_RunClicked(object sender, EventArgs e) {
            SaveCurrentNodeContent();

            WebNode rootNode = webFilesCtrl.GetWebNodeHierarchy();

            // Show viewer window
            WebViewerForm viewerForm = new WebViewerForm();
            viewerForm.RootNode = rootNode;
            ServiceManager.Instance.SaveWebPages(rootNode);
            viewerForm.LoadForm();
            viewerForm.ShowDialog();
        }

        private void webCmdCtrl_SaveClicked(object sender, EventArgs e) {
            SaveAnswer();
        }

        private void SaveCurrentNodeContent() {
            // save current node content
            WebNode selectedWebNode = webFilesCtrl.SelectedNode;
            if (selectedWebNode != null) {
                selectedWebNode.Content = webEditorCtrl1.Source;
            }
        }

        #region INvnTestControl Members

        public void SaveAnswer() {
            SaveCurrentNodeContent();

            if (ServiceManager.Instance.TestQuestionsAndAnswers.ContainsKey(webProgrammingQuestion)) {
                TestService.WebProgrammingQuestionTestAnswer programmingQuestionAnswer = (TestService.WebProgrammingQuestionTestAnswer)ServiceManager.Instance.TestQuestionsAndAnswers[webProgrammingQuestion];
                programmingQuestionAnswer.WebNode = webFilesCtrl.GetWebNodeHierarchy(); // Root node

                ServiceManager.Instance.SaveTestAnswersLocal();
            }
        }

        #endregion
    }
}