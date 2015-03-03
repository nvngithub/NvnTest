using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Employer {
    public partial class SchedulesCtrl : UserControl {
        private uint testsAvailable = 0;
        private Timer timer;
        private TimeZone timezone = TimeZone.CurrentTimeZone;
        private uint currentIndex = 0;
        private uint maxPages = 0;
        private bool filterChanged = true;

        public SchedulesCtrl() {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e) {
            lblUtcTime.Text = timezone.ToUniversalTime(DateTime.Now).ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        public void LoadControl() {
            dgrTestSchedules.Rows.Clear();

            List<string> filters = GetFilters();
            if (filters.Count > 0) {
                ServiceManager.Instance.LoadTestSchedules(filters, currentIndex);
            } else {
                ServiceManager.Instance.LoadTestSchedules(currentIndex);
            }

            foreach (uint id in ServiceManager.Instance.Schedules.Keys) {
                TestService.TestSchedule testSchedule = ServiceManager.Instance.Schedules[id];
                int index = dgrTestSchedules.Rows.Add();
                UpdateGridRowData(testSchedule, index);
            }

            lblIndex.Text = (currentIndex + 1).ToString();

            maxPages = (uint)ServiceManager.Instance.GetNumberOfTestSchedulePages();

            CalculateTestsAvailable();

            btnAssignToYourself.Enabled = btnCreateTestSchedule.Enabled = ServiceManager.Instance.UserInfo.UserExtension == null;
        }

        private void UpdateGridRowData(TestService.TestSchedule testSchedule, int index) {

            dgrTestSchedules[NameCol.Index, index].Value = testSchedule.FirstName + " " + testSchedule.LastName;
            dgrTestSchedules[EmailCol.Index, index].Value = testSchedule.Email;
            dgrTestSchedules[ScheduleDateCol.Index, index].Value = testSchedule.ScheduleDateTime.ToString("dd-MMM-yyyy hh:mm tt");
            if (testSchedule.Status == TestService.TestStatus.Taken) {
                dgrTestSchedules[ExpiryDateCol.Index, index].Value = "";
            } else {
                if (testSchedule.ScheduleDateTime.AddDays(testSchedule.DaysLimit) < timezone.ToUniversalTime(DateTime.Now)) {
                    dgrTestSchedules[ExpiryDateCol.Index, index].Value = "Already Expired";
                } else {
                    dgrTestSchedules[ExpiryDateCol.Index, index].Value = testSchedule.ScheduleDateTime.AddDays(testSchedule.DaysLimit).ToString("dd-MMM-yyyy hh:mm tt");
                }
            }
            // Status
            if (testSchedule.Status == TestService.TestStatus.Submitted) {
                dgrTestSchedules[StatusCol.Index, index].Value = "Submitted";
            } else if (testSchedule.Status == TestService.TestStatus.Taken) {
                dgrTestSchedules[StatusCol.Index, index].Value = "Taken";
            } else if (testSchedule.Status == TestService.TestStatus.New && testSchedule.ScheduleDateTime.AddDays(testSchedule.DaysLimit) < DateTime.Now) {
                dgrTestSchedules[StatusCol.Index, index].Value = "Expired";
            } else if (testSchedule.Status == TestService.TestStatus.Disqualified) {
                dgrTestSchedules[StatusCol.Index, index].Value = "Disqualified";
            } else {
                dgrTestSchedules[StatusCol.Index, index].Value = "Scheduled";
            }
            dgrTestSchedules[ViewResultCol.Index, index].Value = (testSchedule.Status == TestService.TestStatus.Submitted) ? "View" : "";
            dgrTestSchedules.Rows[index].Tag = testSchedule;
        }

        private void dgrTestSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            TestService.TestSchedule testSchedule = (TestService.TestSchedule)dgrTestSchedules.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == EditCol.Index) {
                EditTestSchedule(testSchedule, e.RowIndex);
            } else if (e.ColumnIndex == DeleteCol.Index) {
                // Extension users are not allowed to delete
                if (ServiceManager.Instance.UserInfo.UserExtension != null) {
                    MessageBox.Show("You do not have enough privilege to delete test schedule.", "Delete test schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (testSchedule.Status == TestService.TestStatus.Submitted) {
                    MessageBox.Show("Currently you cannot remove test schedule which is already taken and submitted !!!", "Remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                } else {
                    if (MessageBox.Show("Are you sure you want to remove this test schdule?", "Remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                        object response = ServiceManager.Instance.RemoveTestSchedule(testSchedule);
                        ServiceManager.Instance.Schedules.Remove((uint)response);
                        dgrTestSchedules.Rows.RemoveAt(e.RowIndex);
                    }
                }

                CalculateTestsAvailable();
            } else if (e.ColumnIndex == ViewResultCol.Index) {
                TestResultForm testResultForm = new TestResultForm();
                testResultForm.TestSchedule = testSchedule;
                testResultForm.LoadForm();
                testResultForm.ShowDialog();
            }
        }

        private void dgrTestSchedules_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            TestService.TestSchedule testSchedule = (TestService.TestSchedule)dgrTestSchedules.Rows[e.RowIndex].Tag;
            EditTestSchedule(testSchedule, e.RowIndex);
        }

        private void EditTestSchedule(TestService.TestSchedule testSchedule, int index) {
            if (testSchedule.Status == TestService.TestStatus.Taken) {
                MessageBox.Show("This test schedule cannot be edited as this test is already taken by " + testSchedule.FirstName + " " + testSchedule.LastName, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (testSchedule.ScheduleDateTime.AddDays(testSchedule.DaysLimit) < DateTime.Now) {
                MessageBox.Show("This test schedule cannot be edited as it is already expired.", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AddEditTestScheduleForm testScheduleForm = new AddEditTestScheduleForm();
            testScheduleForm.TestSchedule = ObjectCopier.Clone<TestService.TestSchedule>(testSchedule);
            testScheduleForm.LoadForm();
            if (testScheduleForm.ShowDialog() == DialogResult.OK) {
                TestService.TestSchedule schedule = testScheduleForm.TestSchedule;
                UpdateGridRowData(schedule, index);
            }
        }

        private void btnCreateTestSchedule_Click(object sender, EventArgs e) {
            if (ServiceManager.Instance.Papers.Count == 0) {
                MessageBox.Show("Test papers not found. Please define a test paper to create a test schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool assignToYourself = false;
            if (testsAvailable == 0) {
                TestPurchaseForm testPurchaseForm = new TestPurchaseForm();
                testPurchaseForm.ShowDialog();
                assignToYourself = testPurchaseForm.AssignToYourself;
            }

            if (testsAvailable > 0 || assignToYourself) {
                AddEditTestScheduleForm testScheduleForm = new AddEditTestScheduleForm();
                testScheduleForm.AssignToYourself = assignToYourself;
                testScheduleForm.LoadForm();
                if (testScheduleForm.ShowDialog() == DialogResult.OK) {
                    int index = dgrTestSchedules.Rows.Add();
                    UpdateGridRowData(testScheduleForm.TestSchedule, index);
                    CalculateTestsAvailable();
                }
            }
        }

        private void btnBulkSchedule_Click(object sender, EventArgs e) {
            BulkScheduleForm bulkScheduleForm = new BulkScheduleForm();
            bulkScheduleForm.ShowDialog();
        }

        private void btnAssignToYourself_Click(object sender, EventArgs e) {
            AddEditTestScheduleForm testScheduleForm = new AddEditTestScheduleForm();
            testScheduleForm.AssignToYourself = true;
            testScheduleForm.LoadForm();
            if (testScheduleForm.ShowDialog() == DialogResult.OK) {
                int index = dgrTestSchedules.Rows.Add();
                UpdateGridRowData(testScheduleForm.TestSchedule, index);
                CalculateTestsAvailable();
            }
        }

        private void btnRefreshTestsAvailable_Click(object sender, EventArgs e) {
            CalculateTestsAvailable();
        }

        private void CalculateTestsAvailable() {
            object response = ServiceManager.Instance.GetTestsPurchased();
            testsAvailable = (uint)response;
            //Available = Purchased - Taken - Scheduled (expired are not considered)
            foreach (uint id in ServiceManager.Instance.Schedules.Keys) {
                TestService.TestSchedule testSchedule = ServiceManager.Instance.Schedules[id];
                // Ignore test assigned to yourself
                if (testSchedule.Email == ServiceManager.Instance.UserInfo.Email) {
                    continue;
                }

                if (testSchedule.Status == TestService.TestStatus.Taken) {
                    testsAvailable -= 1;
                } else if (testSchedule.Status == TestService.TestStatus.Submitted) {
                    testsAvailable -= 1;
                } else if (testSchedule.Status == TestService.TestStatus.New && testSchedule.ScheduleDateTime.AddDays(testSchedule.DaysLimit) >= timezone.ToUniversalTime(DateTime.Now)) {
                    // Assigned but not expired
                    testsAvailable -= 1;
                }
            }
            lblTestsAvailable.Text = "" + testsAvailable;
        }

        private void pbFirst_Click(object sender, EventArgs e) {
            currentIndex = 0;
            LoadControl();
        }

        private void pbPrevious_Click(object sender, EventArgs e) {
            if (currentIndex > 0) {
                currentIndex--;
                LoadControl();
            }
        }

        private void pbNext_Click(object sender, EventArgs e) {
            if (currentIndex < maxPages - 1) {
                currentIndex++;
                LoadControl();
            }
        }

        private void pbLast_Click(object sender, EventArgs e) {
            currentIndex = maxPages - 1;
            LoadControl();
        }

        private List<string> GetFilters() {
            List<string> filters = new List<string>();

            if (chkScheduled.Checked) { filters.Add("Scheduled"); }
            if (chkTaken.Checked) { filters.Add("Taken"); }
            if (chkSubmitted.Checked) { filters.Add("Submitted"); }
            if (chkDisqualified.Checked) { filters.Add("Disqualified"); }

            return filters;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e) {
            if (filterChanged) {
                filterChanged = false;

                chkExpired.Checked = chkScheduled.Checked = chkSubmitted.Checked = chkTaken.Checked = chkDisqualified.Checked = false;
                LoadControl();

                filterChanged = true;
            }
        }

        private void FilterOption_Checked(object sender, EventArgs e) {
            if (filterChanged) {
                filterChanged = false;
                
                chkAll.Checked = false;
                LoadControl();

                filterChanged = true;
            }
        }
    }
}
