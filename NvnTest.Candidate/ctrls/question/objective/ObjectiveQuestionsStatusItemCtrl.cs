using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ObjectiveQuestionsStatusItemCtrl : UserControl {
        public event EventHandler ViewQuestionClicked;

        public ObjectiveQuestionsStatusItemCtrl() {
            InitializeComponent();
        }

        public bool IsFlagged {
            set {
                pbFlagged.Visible = value;
            }
        }

        public int Index {
            get {
                return Int32.Parse(lblIndex.Text);
            }
            set {
                lblIndex.Text = value.ToString();
            }
        }

        public ObjectiveQuestionStatus Status {
            set {
                switch (value) {
                    case ObjectiveQuestionStatus.Current:
                        pnlStatus.BackColor = Color.BlueViolet;
                        break;
                    case ObjectiveQuestionStatus.Answered:
                        pnlStatus.BackColor = Color.YellowGreen;
                        break;
                    case ObjectiveQuestionStatus.Unanswered:
                        pnlStatus.BackColor = Color.LightGray;
                        break;
                }
            }
        }

        private void lblIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (ViewQuestionClicked != null) ViewQuestionClicked(this, null);
        }
    }

 
}
