using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class AlgoCtrl : UserControl, IProgrammingQuestionControl {
        private string questionText;
        private object ignore; // :)

        public event EventHandler AnswerChanged;

        public AlgoCtrl() {
            InitializeComponent();

            syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\C.syn";
        }

        #region IProgrammingQuestionControl Members

        public TestService.ProgrammingAnswerType AnswerType {
            get { return TestService.ProgrammingAnswerType.Algo; }
            set { ignore = value; }
        }

        public TestService.ProgrammingAnswerType PreviousAnswerType {
            get { return TestService.ProgrammingAnswerType.Desc; }
            set { ignore = value; }
        }

        public int WindowIndex {
            get { return 0; }
            set { int val = value; /*Ignored*/  }
        }


        public string QuestionText {
            get { return questionText; }
            set { questionText = value; }
        }

        public string Code {
            get { return algoText.Document.Text; }
            set { algoText.Document.Text = value; }
        }

        public string Exe {
            get { return string.Empty; }
            set { ignore = value; }
        }

        public string ExeCode {
            get { return string.Empty; }
            set { ignore = value; }
        }

        #endregion

        public void LoadControl() {
            // Load question description
            TextCtrl ctrl = new TextCtrl();
            ctrl.Text = questionText;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
            ctrl.Width = splitContainerMain.Panel1.Width - 30;
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ctrl.Location = new Point(10, 10);
            ctrl.ScrollBars = RichTextBoxScrollBars.Both;
            ctrl.ResizeControl();

            splitContainerMain.Panel1.Controls.Add(ctrl);

            ctrl.Height = ctrl.Height > 150 ? 150 : ctrl.Height;

            // Set splitter distance
            splitContainerMain.SplitterDistance = ctrl.Height + 10;
        }

        private void algoText_TextChanged(object sender, EventArgs e) {
            if (AnswerChanged != null) { AnswerChanged(this, null); }
        }
    }
}
