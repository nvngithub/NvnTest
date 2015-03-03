using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class SelectQuestionLevelCtrl : UserControl {
        private bool isLoaded = false;

        public SelectQuestionLevelCtrl() {
            InitializeComponent();
        }

        public uint QuestionLevel {
            get {
                if (cmbQuestionLevel.SelectedValue != null) {
                    return (uint)cmbQuestionLevel.SelectedValue;
                } else {
                    return 0;
                }
            }
            set { cmbQuestionLevel.SelectedValue = value; }
        }

        public bool IsLoaded{
            get { return isLoaded; }
        }

        public void LoadControl() {
            List<TestService.QuestionLevel> questionLevelsTemp = new List<TestService.QuestionLevel>();
            foreach (TestService.QuestionLevel level in ServiceManager.Instance.QuestionLevels.Values) {
                questionLevelsTemp.Add(level);
            }

            cmbQuestionLevel.DataSource = questionLevelsTemp;
            cmbQuestionLevel.DisplayMember = "Description";
            cmbQuestionLevel.ValueMember = "Id";

            cmbQuestionLevel.SelectedIndex = -1;

            isLoaded = true;
        }
    }
}
