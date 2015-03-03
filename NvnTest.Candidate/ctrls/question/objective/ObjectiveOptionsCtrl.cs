using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class ObjectiveOptionsCtrl : UserControl {
        public event EventHandler AnswerSelectionChanged;

        public ObjectiveOptionsCtrl() {
            InitializeComponent();
        }

        public int[] SelectedOptions {
            get {
                List<int> selectedOptions = new List<int>();
                for (int i = 0; i < pnlOptions.Controls.Count; i++) {
                    CheckBox chk = (CheckBox)pnlOptions.Controls[i];
                    if (chk.Checked) { selectedOptions.Add(i); }
                }
                return selectedOptions.ToArray();
            }
        }

        public void LoadControl(string[] options) {
            pnlOptions.Controls.Clear();
            foreach (string option in options) {
                CheckBox chk = new CheckBox();
                chk.AutoSize = true;
                chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
                chk.Text = option;

                this.pnlOptions.Controls.Add(chk);
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e) {
            if (AnswerSelectionChanged != null) AnswerSelectionChanged(this, null);
        }

        public void SetAnswer(int[] selectedOptions) {
            if (selectedOptions != null) {
                List<int> options = new List<int>(selectedOptions);
                for (int i = 0; i < pnlOptions.Controls.Count; i++) {
                    if (options.Contains(i)) {
                        CheckBox option = (CheckBox)pnlOptions.Controls[i];
                        option.Checked = true;
                    }
                }
            }
        }
    }
}