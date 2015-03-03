using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class TestCaseItemCtrl : UserControl {
        public event EventHandler EditTestCase;
        public event EventHandler DeleteTestCase;
        private TestService.AutoQuestionTestCase testCase;
        private TestService.AutoQuestionSignatureConfig config;

        public TestCaseItemCtrl() {
            InitializeComponent();
        }

        public TestService.AutoQuestionSignatureConfig Config {
            get { return config; }
            set { config = value; }
        }

        public TestService.AutoQuestionTestCase TestCase {
            get { return testCase; }
            set { testCase = value; }
        }

        public void LoadControl() {
            lblFunctionCall.Text = GetFunctionCall();
            lblReturns.Text = "Returns: " + testCase.ExpectedValue;
            if (testCase.IsAllowedInTestMode) {
                lblIsAllowedInTestMode.Text = "This test case will run in test mode";
                lblIsAllowedInTestMode.ForeColor = Color.Green;
            } else {
                lblIsAllowedInTestMode.Text = "This test case will not run in test mode";
                lblIsAllowedInTestMode.ForeColor = Color.Blue;
            }
        }

        private string GetFunctionCall() {
            return config.FunctionName + "(" + String.Join(", ", testCase.InputValues) + ")";
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (EditTestCase != null) {
                EditTestCase(this, null);
            }
        }

        private void btnDeleteTestCase_Click(object sender, EventArgs e) {
            if (DeleteTestCase != null) {
                DeleteTestCase(this, null);
            }
        }
    }
}
