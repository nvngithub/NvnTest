using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class PapersCtrl : UserControl {
        private TestService.Paper[] papers;
        private TestService.AutoPaper[] autoPapers;

        public PapersCtrl() {
            InitializeComponent();
        }

        public void LoadControl() {
            dgrPapers.Rows.Clear();

            object response = ServiceManager.Instance.LoadPapers();
            papers = (TestService.Paper[])response;
            foreach (TestService.Paper paper in papers) {
                AddPaperToGrid(paper);
            }

            response = ServiceManager.Instance.LoadAutoPapers();
            autoPapers = (TestService.AutoPaper[])response;
            foreach (TestService.AutoPaper autoPaper in autoPapers) {
                AddAutoPaperToGrid(autoPaper);
            }

            btnAddNewPaper.Enabled = true;
            if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                btnAddNewPaper.Enabled = (int)ServiceManager.Instance.UserInfo.UserExtension.PapersPrivilege > 1;
            }
        }

        private void AddPaperToGrid(TestService.Paper paper) {
            if (chkShowAutoPapers.Checked == false && paper.IsAuto) return;

            int index = dgrPapers.Rows.Add();
            dgrPapers[IndexCol.Name, index].Value = index + 1;
            dgrPapers[NameCol.Name, index].Value = paper.Name;
            dgrPapers[DescCol.Name, index].Value = paper.Desc;
            dgrPapers[PaperTypeColumn.Name, index].Value = "Manual";
            dgrPapers.Rows[index].Tag = paper;
        }

        private void AddAutoPaperToGrid(TestService.AutoPaper paper) {
            int index = dgrPapers.Rows.Add();
            dgrPapers[IndexCol.Name, index].Value = index + 1;
            dgrPapers[NameCol.Name, index].Value = paper.Name;
            dgrPapers[DescCol.Name, index].Value = paper.Desc;
            dgrPapers[PaperTypeColumn.Name, index].Value = "Auto";
            dgrPapers.Rows[index].Tag = paper;
        }

        private void dgrPapers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            
            if (e.ColumnIndex == DeleteCol.Index) {
                if (ServiceManager.Instance.UserInfo.UserExtension != null && (int)ServiceManager.Instance.UserInfo.UserExtension.PapersPrivilege <= 1) {
                    MessageBox.Show("You do not have enough privilege to delete papers.", "Delete paper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this test paper ?", "Delete paper", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                    if (dgrPapers.Rows[e.RowIndex].Tag is TestService.Paper) {
                        TestService.Paper paper = (TestService.Paper)dgrPapers.Rows[e.RowIndex].Tag;
                        ServiceManager.Instance.RemovePaper(paper);
                    } else if (dgrPapers.Rows[e.RowIndex].Tag is TestService.AutoPaper) {
                        TestService.AutoPaper autoPaper = (TestService.AutoPaper)dgrPapers.Rows[e.RowIndex].Tag;
                        ServiceManager.Instance.RemoveAutoPaper(autoPaper);
                    }

                    dgrPapers.Rows.RemoveAt(e.RowIndex);
                }
            } else if (e.ColumnIndex == EditCol.Index) {
                if (dgrPapers.Rows[e.RowIndex].Tag is TestService.Paper) {
                    TestService.Paper paper = (TestService.Paper)dgrPapers.Rows[e.RowIndex].Tag;
                    EditPaper(paper, e.RowIndex);
                } else if (dgrPapers.Rows[e.RowIndex].Tag is TestService.AutoPaper) {
                    TestService.AutoPaper paper = (TestService.AutoPaper)dgrPapers.Rows[e.RowIndex].Tag;
                    EditAutoPaper(paper, e.RowIndex);
                }
            }
        }

        private void dgrPapers_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            if (dgrPapers.Rows[e.RowIndex].Tag is TestService.Paper) {
                TestService.Paper paper = (TestService.Paper)dgrPapers.Rows[e.RowIndex].Tag;
                EditPaper(paper, e.RowIndex);
            } else if (dgrPapers.Rows[e.RowIndex].Tag is TestService.AutoPaper) {
                TestService.AutoPaper paper = (TestService.AutoPaper)dgrPapers.Rows[e.RowIndex].Tag;
                EditAutoPaper(paper, e.RowIndex);
            }
        }

        private void EditPaper(TestService.Paper paper, int index) {
            AddEditPaperForm addEditPaperForm = new AddEditPaperForm();
            addEditPaperForm.Paper = ObjectCopier.Clone<TestService.Paper>(paper);
            addEditPaperForm.LoadForm();
            if (addEditPaperForm.ShowDialog() == DialogResult.OK) {
                dgrPapers[NameCol.Name, index].Value = addEditPaperForm.Paper.Name;
                dgrPapers[DescCol.Name, index].Value = addEditPaperForm.Paper.Desc;
                dgrPapers.Rows[index].Tag = addEditPaperForm.Paper;
            }
        }

        private void EditAutoPaper(TestService.AutoPaper paper, int index) {
            AddEditAutoPaperForm addEditAutoPaperForm = new AddEditAutoPaperForm();
            addEditAutoPaperForm.Paper = ObjectCopier.Clone<TestService.AutoPaper>(paper);
            addEditAutoPaperForm.LoadForm();
            if (addEditAutoPaperForm.ShowDialog() == DialogResult.OK) {
                dgrPapers[NameCol.Name, index].Value = addEditAutoPaperForm.Paper.Name;
                dgrPapers[DescCol.Name, index].Value = addEditAutoPaperForm.Paper.Desc;
                dgrPapers.Rows[index].Tag = addEditAutoPaperForm.Paper;
            }
        }

        private void btnAddNewPaper_Click(object sender, EventArgs e) {
            AddEditPaperForm addEditPaperForm = new AddEditPaperForm();
            addEditPaperForm.LoadForm();
            if (addEditPaperForm.ShowDialog() == DialogResult.OK) {
                AddPaperToGrid(addEditPaperForm.Paper);
            }
        }

        private void btnAddNewAutoPaper_Click(object sender, EventArgs e) {
            AddEditAutoPaperForm addEditPaperForm = new AddEditAutoPaperForm();
            addEditPaperForm.LoadForm();
            if (addEditPaperForm.ShowDialog() == DialogResult.OK) {
                AddAutoPaperToGrid(addEditPaperForm.Paper);
            }
        }

        private void chkShowAutoPapers_CheckedChanged(object sender, EventArgs e) {
            LoadControl();
        }
    }
}