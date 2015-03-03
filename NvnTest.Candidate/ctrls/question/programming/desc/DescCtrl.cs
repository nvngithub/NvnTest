using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;

namespace NvnTest.Candidate {
    public partial class DescCtrl : UserControl, IProgrammingQuestionControl {
        private string questionText;
        private TextBox txtDesc = new TextBox();
        private object ignore; // :)

        public event EventHandler AnswerChanged;

        public DescCtrl() {
            InitializeComponent();
        }

        #region IProgrammingQuestionControl Members

        public TestService.ProgrammingAnswerType AnswerType {
            get { return TestService.ProgrammingAnswerType.Desc; }
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
            get { return txtDesc.Text; }
            set { txtDesc.Text = value; }
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
            TextCtrl ctrl = new TextCtrl();
            ctrl.Text = questionText;
            ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
            ctrl.Width = grpCtrls.Width - 30;
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ctrl.Location = new Point(10, 10);
            ctrl.ScrollBars = RichTextBoxScrollBars.Both;
            ctrl.ResizeControl();

            grpCtrls.Controls.Add(ctrl);

            ctrl.Height = ctrl.Height > 150 ? 150 : ctrl.Height;

            txtDesc.Multiline = true;
            txtDesc.ScrollBars = ScrollBars.Both;
            txtDesc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDesc.Location = new Point(ctrl.Location.X, ctrl.Location.Y + ctrl.Height + 10);
            txtDesc.Width = grpCtrls.Width - 30;
            txtDesc.Height = grpCtrls.Height - ctrl.Height - 30;
            txtDesc.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            grpCtrls.Controls.Add(txtDesc);
        }

        private void txtDesc_TextChanged(object sender, EventArgs e) {
            if (AnswerChanged != null) { AnswerChanged(this, null); }
        }
    }
}