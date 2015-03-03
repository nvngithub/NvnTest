using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class QuestionCategoriesForm : Form {
        public QuestionCategoriesForm() {
            InitializeComponent();
        }

        public void LoadForm() {
            dgrQuestionCategories.Rows.Clear();
            foreach (uint key in ServiceManager.Instance.QuestionCategories.Keys) {
                TestService.QuestionCategory questionCategory = ServiceManager.Instance.QuestionCategories[key];

                AddQuestionCategoryToGrid(questionCategory);
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void AddQuestionCategoryToGrid(TestService.QuestionCategory questionCategory) {
            int index = dgrQuestionCategories.Rows.Add();
            dgrQuestionCategories[NameColumn.Index, index].Value = questionCategory.Name;
            dgrQuestionCategories[EditColumn.Index, index].Value = imageList.Images[0];
            dgrQuestionCategories[DeleteColumn.Index, index].Value = imageList.Images[1];
            dgrQuestionCategories.Rows[index].Tag = questionCategory;
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e) {
            AddEditQuestionCategoryForm questionCategoryForm = new AddEditQuestionCategoryForm();
            if (questionCategoryForm.ShowDialog() == DialogResult.OK) {
                TestService.QuestionCategory questionCategory = new TestService.QuestionCategory();
                questionCategory.Name = questionCategoryForm.Category;
                questionCategory.AdminId = ServiceManager.Instance.UserInfo.Id;
                questionCategory.TempId = Guid.NewGuid().ToString().Replace("-", "");

                object response = ServiceManager.Instance.UpdateQuestionCategory(questionCategory);
                if (response != null) {
                    questionCategory = (TestService.QuestionCategory)response;
                    ServiceManager.Instance.QuestionCategories.Add(questionCategory.Id, questionCategory);

                    AddQuestionCategoryToGrid(questionCategory);
                }
            }
        }



        private void dgrQuestionCategories_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            if (dgrQuestionCategories.Columns[e.ColumnIndex].Name == EditColumn.Name) {
                AddEditQuestionCategoryForm questionCategoryForm = new AddEditQuestionCategoryForm();
                questionCategoryForm.Category = (string)dgrQuestionCategories[NameColumn.Index, e.RowIndex].Value;
                questionCategoryForm.LoadForm();
                if (questionCategoryForm.ShowDialog() == DialogResult.OK) {
                    TestService.QuestionCategory questionCategory = (TestService.QuestionCategory)dgrQuestionCategories.Rows[e.RowIndex].Tag;
                    questionCategory.Name = questionCategoryForm.Category;
                    object response = ServiceManager.Instance.UpdateQuestionCategory(questionCategory);
                    if (response != null) {
                        questionCategory = (TestService.QuestionCategory)response;
                        if (ServiceManager.Instance.QuestionCategories.ContainsKey(questionCategory.Id)) {
                            ServiceManager.Instance.QuestionCategories[questionCategory.Id] = questionCategory;
                        }

                        dgrQuestionCategories[NameColumn.Index, e.RowIndex].Value = questionCategoryForm.Category;
                    }
                }
            } else if (dgrQuestionCategories.Columns[e.ColumnIndex].Name == DeleteColumn.Name) {
                if (MessageBox.Show("Do you really want to delete this category ? All questions assigned to this category is set to none.", "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK) {
                    TestService.QuestionCategory questionCategory = (TestService.QuestionCategory)dgrQuestionCategories.Rows[e.RowIndex].Tag;
                    object response = ServiceManager.Instance.RemoveQuestionCategory(questionCategory);
                    if (response != null) {
                        // Remove from cache
                        questionCategory = (TestService.QuestionCategory)response;
                        if (ServiceManager.Instance.QuestionCategories.ContainsKey(questionCategory.Id)) {
                            ServiceManager.Instance.QuestionCategories.Remove(questionCategory.Id);
                        }

                        // Remove row
                        dgrQuestionCategories.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
