using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ObjectiveQuestionsStatusCtrl : UserControl {
        internal event EventHandler<ViewObjectiveQuestionEventArgs> ViewQuestionClicked;

        public ObjectiveQuestionsStatusCtrl() {
            InitializeComponent();
        }

        public void LoadControl(List<ObjectiveQuestionLocal> questions) {
            pnlItems.Controls.Clear();

            for (int i = 0; i < questions.Count; i++) {
                ObjectiveQuestionLocal question = questions[i];
                ObjectiveQuestionsStatusItemCtrl ctrl = new ObjectiveQuestionsStatusItemCtrl();
                ctrl.ViewQuestionClicked += new EventHandler(ctrl_ViewQuestionClicked);
                ctrl.Index = i + 1;
                ctrl.Status = question.Status;
                ctrl.IsFlagged = question.IsFlagged;

                pnlItems.Controls.Add(ctrl);
            }
        }

        public void UpdateStatus(List<ObjectiveQuestionLocal> questions) {
            for (int i = 0; i < questions.Count; i++) {
                ObjectiveQuestionLocal question = questions[i];
                ObjectiveQuestionsStatusItemCtrl ctrl = (ObjectiveQuestionsStatusItemCtrl)pnlItems.Controls[i];
                ctrl.Status = question.Status;
                ctrl.IsFlagged = question.IsFlagged;
            }
        }

        private void ctrl_ViewQuestionClicked(object sender, EventArgs e) {
            ObjectiveQuestionsStatusItemCtrl ctrl = (ObjectiveQuestionsStatusItemCtrl)sender;

            if (ViewQuestionClicked != null) ViewQuestionClicked(this, new ViewObjectiveQuestionEventArgs(ctrl.Index - 1));
        }
    }

    internal class ViewObjectiveQuestionEventArgs : EventArgs {
        private int index;

        public int Index {
            get { return index; }
        }

        public ViewObjectiveQuestionEventArgs(int index) {
            this.index = index;
        }
    }
}
