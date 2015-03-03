using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class ArgumentItemCtrl : UserControl {
        private TestService.FunctionInput input = new TestService.FunctionInput();

        public event EventHandler DeleteClicked;
        public event EventHandler ArgumentNameChanged;
        public event EventHandler ArgumentTypeChanged;

        public ArgumentItemCtrl() {
            InitializeComponent();
        }

        private void ArgumentItemCtrl_Load(object sender, EventArgs e) {
            cmbValueType.DataSource = Enum.GetValues(typeof(TestService.AutoQuestionValueType));
        }

        public TestService.FunctionInput Input {
            get { return input; }
            set { input = value; }
        }

        public void LoadControl() {
            if (input != null) {
                cmbValueType.SelectedItem = input.ArgType;
                txtName.Text = input.Name;
            }
        }

        private void btnDeleteArgument_Click(object sender, EventArgs e) {
            if (DeleteClicked != null) {
                DeleteClicked(this, null);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e) {
            input.Name = txtName.Text;
            if (ArgumentNameChanged != null) {
                ArgumentNameChanged(this, null);
            }
        }

        private void cmbValueType_SelectedValueChanged(object sender, EventArgs e) {
            input.ArgType = (TestService.AutoQuestionValueType)cmbValueType.SelectedItem;
            if (ArgumentTypeChanged != null) {
                ArgumentTypeChanged(this, null);
            }
        }
    }
}
