using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class TestInfoCtrl : UserControl {
        public TestInfoCtrl() {
            InitializeComponent();
        }

        public string Duration{
            get { return lblDuration.Text; }
        }

        public void LoadControl() {
            lblEmployer.Text = ServiceManager.Instance.TestInfo.EmployerName;
            lblDuration.Text = (new DateTime(2000, 1, 1, (int)ServiceManager.Instance.TestSchedule.Duration / 60, (int)ServiceManager.Instance.TestSchedule.Duration % 60, 0)).ToString("HH:mm");
            lblNumberOfQuestions.Text = "" + ServiceManager.Instance.TestInfo.QuestionsCount;
        }
    }
}
