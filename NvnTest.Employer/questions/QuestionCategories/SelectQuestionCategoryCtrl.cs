using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class SelectQuestionCategoryCtrl : UserControl {
        private List<string> categories = new List<string> ();

        public SelectQuestionCategoryCtrl() {
            InitializeComponent();
        }

        public List<string> Categories {
            get { return categories; }
        }

        public void LoadControl() {
            pnlCategories.Controls.Clear();
            foreach (string category in categories) {
                uint id = Convert.ToUInt32(category);
                AddQuestionCategoryItemControl(id);
            }

            List<TestService.QuestionCategory> questionCategoriesTemp = new List<TestService.QuestionCategory>();
            foreach (TestService.QuestionCategory cat in ServiceManager.Instance.QuestionCategories.Values) {
                questionCategoriesTemp.Add(cat);
            }

            cmbQuestionCategories.DataSource = questionCategoriesTemp;
            cmbQuestionCategories.DisplayMember = "Name";
            cmbQuestionCategories.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (cmbQuestionCategories.SelectedItem != null) {
                uint id = (uint)cmbQuestionCategories.SelectedValue;

                bool isAlreadyAdded = CheckIsAlreadyAdded(id);
                if (isAlreadyAdded == false) {
                    AddQuestionCategoryItemControl(id);
                    categories.Add(id.ToString());
                }
            }
        }

        private bool CheckIsAlreadyAdded(uint id) {
            foreach (QuestionCategoryItemCtrl ctrl in pnlCategories.Controls) {
                if (ctrl.Id == id) {
                    return true;
                }
            }
            return false;
        }

        private void AddQuestionCategoryItemControl(uint id) {
            if (ServiceManager.Instance.QuestionCategories.ContainsKey(id)) {
                TestService.QuestionCategory questionCategory = ServiceManager.Instance.QuestionCategories[id];
                QuestionCategoryItemCtrl ctrl = new QuestionCategoryItemCtrl();
                ctrl.CategoryUnselected += new EventHandler(ctrl_CategoryUnselected);
                ctrl.Category = questionCategory.Name;
                ctrl.Id = id;
                pnlCategories.Controls.Add(ctrl);
            }
        }

        private void ctrl_CategoryUnselected(object sender, EventArgs e) {
            QuestionCategoryItemCtrl ctrl = (QuestionCategoryItemCtrl)sender;
            string id = ctrl.Id.ToString();
            if (categories.Contains(id)) {
                categories.Remove(id);
            }

            if (pnlCategories.Controls.Contains(ctrl)) {
                pnlCategories.Controls.Remove(ctrl);
            }
        }
    }
}
