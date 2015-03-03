using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class FunctionSignatureCtrl : UserControl {
        public event EventHandler FunctionSignatureChanged;
        private TestService.AutoQuestionSignatureConfig config = new TestService.AutoQuestionSignatureConfig();
        private bool loading = false;

        public FunctionSignatureCtrl() {
            InitializeComponent();

            cmbReturnType.DataSource = Enum.GetValues(typeof(TestService.AutoQuestionValueType));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestService.AutoQuestionSignatureConfig Config {
            get { return config; }
            set { config = value; }
        }

        public void LoadControl() {
            pnlArgs.Controls.Clear();

            if (config != null) {
                loading = true;
                cmbReturnType.SelectedItem = config.ReturnType;
                txtFunctionName.Text = config.FunctionName;

                foreach (TestService.FunctionInput input in config.Inputs) {
                    ArgumentItemCtrl argCtrl = new ArgumentItemCtrl();
                    argCtrl.Input = input;
                    argCtrl.LoadControl();

                    argCtrl.DeleteClicked += new EventHandler(ArgCtrl_DeleteClicked);
                    argCtrl.ArgumentNameChanged += new EventHandler(argCtrl_ArgumentNameChanged);
                    argCtrl.ArgumentTypeChanged += new EventHandler(argCtrl_ArgumentTypeChanged);

                    pnlArgs.Controls.Add(argCtrl);
                }

                loading = false;
                UpdateFunctionSignature();
            }
        }

        private void ArgCtrl_DeleteClicked(object sender, EventArgs e) {
            ArgumentItemCtrl ctrl = (ArgumentItemCtrl)sender;
            if (pnlArgs.Controls.Contains(ctrl)) {
                pnlArgs.Controls.Remove(ctrl);
            }

            UpdateFunctionSignature();
        }

        private void argCtrl_ArgumentNameChanged(object sender, EventArgs e) {
            UpdateFunctionSignature();
        }

        private void argCtrl_ArgumentTypeChanged(object sender, EventArgs e) {
            UpdateFunctionSignature();
        }

        private void btnAddArgument_Click(object sender, EventArgs e) {
            ArgumentItemCtrl argCtrl = new ArgumentItemCtrl();
            argCtrl.DeleteClicked += new EventHandler(ArgCtrl_DeleteClicked);
            argCtrl.ArgumentNameChanged += new EventHandler(argCtrl_ArgumentNameChanged);
            argCtrl.ArgumentTypeChanged += new EventHandler(argCtrl_ArgumentTypeChanged);

            pnlArgs.Controls.Add(argCtrl);
        }

        private void txtFunctionName_TextChanged(object sender, EventArgs e) {
            UpdateFunctionSignature();
        }

        private void UpdateFunctionSignature() {
            if (loading) return;

            config.FunctionName = txtFunctionName.Text;
            config.ReturnType = (TestService.AutoQuestionValueType)cmbReturnType.SelectedItem;
            List<TestService.FunctionInput> functionInputs = new List<TestService.FunctionInput>();
            
            List<string> args = new List<string>();
            foreach (ArgumentItemCtrl ctrl in pnlArgs.Controls) {
                string name = ctrl.Input.Name;
                if (String.IsNullOrEmpty(name) == false) {
                    TestService.AutoQuestionValueType type = ctrl.Input.ArgType;

                    functionInputs.Add(ctrl.Input);
                    args.Add(type.ToString() + " " + name);
                }
            }

            config.Inputs = functionInputs.ToArray();

            if (String.IsNullOrEmpty(txtFunctionName.Text) == false) {
                lblSignaturePreview.Text = cmbReturnType.SelectedItem.ToString() + " " + txtFunctionName.Text + "(" + String.Join(", ", args.ToArray()) + ")";
            } else {
                lblSignaturePreview.Text = "Function signature undefined";
            }

            if (FunctionSignatureChanged != null) {
                FunctionSignatureChanged(this, null);
            }
        }
    }
}
