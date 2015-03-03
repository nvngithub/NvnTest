using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace NvnTest.Candidate {
    public partial class CodeEditorCtrl : UserControl {
        private TestService.ProgrammingAnswerType answerType;

        public event EventHandler AnswerChanged;

        public CodeEditorCtrl() {
            InitializeComponent();
        }

        public TestService.ProgrammingAnswerType AnswerType {
            set { answerType = value; }
        }

        public string Source {
            get { return editorCtrl.Document.Text; }
            set { editorCtrl.Document.Text = value; }
        }

        public void LoadControl() {
            if (answerType == TestService.ProgrammingAnswerType.C) {
                syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\C.syn";
            } else if (answerType == TestService.ProgrammingAnswerType.CPP) {
                syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\CPP.syn";
            } else if (answerType == TestService.ProgrammingAnswerType.CSharp) {
                syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\CSharp.syn";
            } else if (answerType == TestService.ProgrammingAnswerType.VBNET) {
                syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\VBNET.syn";
            } else if (answerType == TestService.ProgrammingAnswerType.Java) {
                syntaxDocument1.SyntaxFile = Globals.AppPath + "syntax\\Java.syn";
            }
        }

        private void editorCtrl_TextChanged(object sender, EventArgs e) {
            if (AnswerChanged != null) AnswerChanged(this, null);
        }
    }
}