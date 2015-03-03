using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class TestCaseCtrl : UserControl {
        private List<TestService.AutoQuestionTestCase> testCases = new List<TestService.AutoQuestionTestCase>();
        private TestService.AutoQuestionSignatureConfig config;

        public TestCaseCtrl() {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestService.AutoQuestionTestCase> TestCases {
            get { return testCases; }
            set { testCases = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestService.AutoQuestionSignatureConfig Config {
            set { config = value; }
        }
        
        public void LoadControl() {
            pnlTestCases.Controls.Clear();

            // TODO: validate test cases with function signature and prompt message
            
            LoadTestCases();
        }

        private void LoadTestCases() {
            if (testCases != null && testCases.Count > 0) {
                foreach (TestService.AutoQuestionTestCase testCase in testCases) {
                    AddTestCaseToPanel(testCase);
                }
            }
        }

        private void AddTestCaseToPanel(TestService.AutoQuestionTestCase testCase) {            
            TestCaseItemCtrl ctrl = new TestCaseItemCtrl();
            ctrl.EditTestCase += new EventHandler(Ctrl_EditTestCase);
            ctrl.DeleteTestCase += new EventHandler(Ctrl_DeleteTestCase);
            ctrl.Config = config;
            ctrl.TestCase = testCase;
            ctrl.LoadControl();

            pnlTestCases.Controls.Add(ctrl);
        }

        private void Ctrl_EditTestCase(object sender, EventArgs e) {
            TestCaseItemCtrl itemCtrl = (TestCaseItemCtrl)sender;

            AddEditTestCaseForm addEditTestCaseForm = new AddEditTestCaseForm();
            addEditTestCaseForm.TestCase = ((TestCaseItemCtrl)sender).TestCase;
            addEditTestCaseForm.Config = config;
            addEditTestCaseForm.LoadForm();
            if (addEditTestCaseForm.ShowDialog() == DialogResult.OK) {
                itemCtrl.TestCase = addEditTestCaseForm.TestCase;
                itemCtrl.LoadControl();
            }
        }

        private void Ctrl_DeleteTestCase(object sender, EventArgs e) {
            TestCaseItemCtrl ctrl = (TestCaseItemCtrl)sender;
            if (testCases.Contains(ctrl.TestCase)) {
                testCases.Remove(ctrl.TestCase);
            }
            pnlTestCases.Controls.Remove(ctrl);
        }

        private void btnAddNewTestCase_Click(object sender, EventArgs e) {
            AddEditTestCaseForm addEditTestCaseForm = new AddEditTestCaseForm();
            addEditTestCaseForm.Config = config;
            addEditTestCaseForm.LoadForm();
            if (addEditTestCaseForm.ShowDialog() == DialogResult.OK) {
                AddTestCaseToPanel(addEditTestCaseForm.TestCase);
                testCases.Add(addEditTestCaseForm.TestCase);
            }
        }
    }
}
