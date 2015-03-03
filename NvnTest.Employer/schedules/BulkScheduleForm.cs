using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NvnTest.Employer {
    public partial class BulkScheduleForm : Form {
        public BulkScheduleForm() {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnImport_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "CSV files|*csv";
            if (dlg.ShowDialog() == DialogResult.OK) {
                ImportCSV(dlg.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (rbSimple.Checked) {
                Thread bulkScheduleThread = new Thread(new ThreadStart(CreateTestSchedules_Simple));
                bulkScheduleThread.IsBackground = true;
                bulkScheduleThread.Start();
            }
        }

        private void CreateTestSchedules_Simple() {
            List<uint> paperIds = GetPaperIds();

            int delay = Convert.ToInt32(txtDelay.Text) * 1000;
            int paperIdex = 0;
            foreach (DataGridViewRow row in dgrData.Rows) {
                TestService.TestSchedule testSchedule = new TestService.TestSchedule();
                testSchedule.TempId = Guid.NewGuid().ToString().Replace("-", "");
                testSchedule.AdminId = ServiceManager.Instance.UserInfo.Id;

                testSchedule.FirstName = (string)row.Cells[0].Value;
                testSchedule.LastName = (string)row.Cells[1].Value;
                testSchedule.Email = (string)row.Cells[2].Value;
                testSchedule.DaysLimit = Convert.ToUInt32(row.Cells[3].Value);
                testSchedule.Duration = Convert.ToUInt32(row.Cells[4].Value);

                testSchedule.PaperId = paperIds[paperIdex];
                paperIdex = paperIdex + 1;
                if (paperIdex == paperIds.Count) paperIdex = 0;

                testSchedule.LiveImage = ((string)row.Cells[5].Value) == "1";
                testSchedule.WebReference = ((string)row.Cells[6].Value) == "1";

                object response = ServiceManager.Instance.UpdateTestSchedule(testSchedule);
                if (response != null) {
                    testSchedule = (TestService.TestSchedule)response;
                    if (ServiceManager.Instance.Schedules.ContainsKey(testSchedule.Id) == false) {
                        ServiceManager.Instance.Schedules.Add(testSchedule.Id, testSchedule);
                    }
                }

                lblStatus.Text = testSchedule.Email;

                // Delay
                Thread.Sleep(delay);
            }

            lblStatus.Text = string.Empty;
        }

        private List<uint> GetPaperIds() {
            List<uint> ids = new List<uint>();
            foreach (uint id in ServiceManager.Instance.Papers.Keys) { ids.Add(id); }

            return ids;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ImportCSV(string filename) {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length >= 3) {
                // Create headers
                string[] headers = lines[0].Split(",".ToCharArray());
                dgrData.Columns.Clear();
                foreach (string header in headers) {
                    dgrData.Columns.Add(header, header);
                }
                // Load data
                for (int i = 2; i < lines.Length; i++) {
                    string[] data = lines[i].Split(",".ToCharArray());
                    int index = dgrData.Rows.Add(data);
                }
            } else {
                MessageBox.Show("CSV file with atleast 3 line is expected. First line header, second line blank and data starts from third line", "Error", MessageBoxButtons.OK);
            }
        }

        private bool ValidInput() {
            // TODO: do validation
            return true;
        }
    }
}
