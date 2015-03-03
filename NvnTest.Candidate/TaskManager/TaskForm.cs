using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class TaskForm : Form {
        public event EventHandler SkipTaskManagerClicked;
        public event EventHandler CandidateDisqualified;
        private bool isVisible = false;
        private List<string> applicationsIgnored = new List<string>();
        private int attemptsLeft = 3;
        private int secondsLeft = 45;
        private Timer timer;

        public TaskForm() {
            InitializeComponent();

            TaskManager.Instance.ApplicationsListed += new EventHandler(TaskManager_ApplicationsListed);
        }

        void TaskManager_ApplicationsListed(object sender, EventArgs e) {
            ListApplications();
        }

        public List<string> ApplicationsIgnored {
            get { return applicationsIgnored; }
        }

        public bool IsVisible {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public void LoadForm() {
            lblAttemptsLeft.Visible = lblAttemptsRemainingLabel.Visible = lblSecondsLabel.Visible = lblSecondsLeft.Visible = lblTimeLimitLabel.Visible = false;
            lblInstruction.Text = "Following applications need to be closed to continue with your test.";
            if (ServiceManager.Instance.Email == Globals.DemoEmail) {
                this.lnkSkipTaskManager.Visible = true;
            }

            ListApplications();
        }

        private void ListApplications() {
            if (isVisible && TaskManager.Instance.Apps.Count > 0) {
                pnlTasks.Controls.Clear();
                foreach (App app in TaskManager.Instance.Apps) {
                    AddNewApp(app);
                }
            } else {
                this.DialogResult = DialogResult.OK;
            }
        }

        public void StartTimer() {
            StopTimer(); // Stop timer if any already running

            lblAttemptsLeft.Visible = lblAttemptsRemainingLabel.Visible = lblSecondsLabel.Visible = lblSecondsLeft.Visible = lblTimeLimitLabel.Visible = true;
            lblInstruction.Text = "Following applications need to be closed to continue with your test. You will be disqualified from the test if listed applications are not closed in the given time frame.";
            secondsLeft = 45;
            attemptsLeft = attemptsLeft - 1;
            if (attemptsLeft < 0) {
                if (CandidateDisqualified != null) {
                    CandidateDisqualified(this, null);
                }
            }

            if (attemptsLeft == 0) {
                lblAttemptsLeft.Text = "Last";
            } else {
                lblAttemptsLeft.Text = attemptsLeft.ToString();
            }

            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void StopTimer() {
            if (timer != null) {
                timer.Stop();
                timer.Enabled = false;
                timer = null;
            }
            lblAttemptsLeft.Text = string.Empty;
        }

        void timer_Tick(object sender, EventArgs e) {
            secondsLeft = secondsLeft - 1;
            // Another attempt
            if (secondsLeft < 0) {
                secondsLeft = 45;
                attemptsLeft = attemptsLeft - 1;
                if (attemptsLeft < 0) {
                    if (CandidateDisqualified != null) {
                        CandidateDisqualified(this, null);
                    }
                }

                if (attemptsLeft == 0) {
                    lblAttemptsLeft.Text = "Last";
                } else {
                    lblAttemptsLeft.Text = attemptsLeft.ToString();
                }
            }

            lblSecondsLeft.Text = secondsLeft.ToString();
        }

        private void AddNewApp(App app) {
            if (applicationsIgnored.Contains(app.Name) == false) {
                TaskItemCtrl taskItemCtrl = new TaskItemCtrl();
                taskItemCtrl.ApplicationIgnored += new EventHandler<IgnoredAppEventArgs>(taskItemCtrl_ApplicationIgnored);
                taskItemCtrl.TaskName = app.Name;
                taskItemCtrl.TaskIcon = app.Icon;
                taskItemCtrl.Process = app.Process;
                pnlTasks.Controls.Add(taskItemCtrl);
            }
        }

        private void taskItemCtrl_ApplicationIgnored(object sender, IgnoredAppEventArgs e) {
            if (applicationsIgnored.Contains(e.ApplicationName) == false) {
                applicationsIgnored.Add(e.ApplicationName);
            }
        }

        private void lnkSkipTaskManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (SkipTaskManagerClicked != null) {
                SkipTaskManagerClicked(this, null);
            }
        }
    }
}