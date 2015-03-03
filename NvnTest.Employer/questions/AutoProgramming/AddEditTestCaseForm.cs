using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class AddEditTestCaseForm : Form {
        private TestService.AutoQuestionTestCase testCase;
        private TestService.AutoQuestionSignatureConfig config;

        public AddEditTestCaseForm() {
            InitializeComponent();
        }

        public TestService.AutoQuestionTestCase TestCase {
            get { return testCase; }
            set { testCase = value; }
        }

        public TestService.AutoQuestionSignatureConfig Config {
            get { return config; }
            set { config = value; }
        }

        public void LoadForm() {
            if (testCase != null) {
                chkIsAllowedInTestMode.Checked = testCase.IsAllowedInTestMode;
                txtExpectedValue.Text = testCase.ExpectedValue;
                if (testCase.InputValues != null && testCase.InputValues.Length > 0) {
                    for(int i=0;i<testCase.InputValues.Length;i++) {
                        string input = testCase.InputValues[i];
                        TestCaseInputCtrl inputCtrl = new TestCaseInputCtrl();
                        inputCtrl.ArgumentName = config.Inputs[i].Name;
                        inputCtrl.Input = input;
                        
                        pnlInputs.Controls.Add(inputCtrl);
                    }
                }
            } else if (config != null) {
                // Show list of arguments with empty values
                foreach (TestService.FunctionInput input in config.Inputs) {
                    TestCaseInputCtrl inputCtrl = new TestCaseInputCtrl();
                    inputCtrl.ArgumentName = input.Name;

                    pnlInputs.Controls.Add(inputCtrl);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            // TODO: validate - 1. number of agruments, 2. type of arguments, 3. Empty value or default value

            if (testCase == null) {
                testCase = new TestService.AutoQuestionTestCase();
            }

            testCase.ExpectedValue = txtExpectedValue.Text;
            testCase.IsAllowedInTestMode = chkIsAllowedInTestMode.Checked;
            List<string> inputs = new List<string>();
            foreach (TestCaseInputCtrl ctrl in pnlInputs.Controls) {
                inputs.Add(ctrl.Input);
            }

            testCase.InputValues = inputs.ToArray();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
