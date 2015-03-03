using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NvnTest.Candidate {
    public partial class MainForm : Form {
        private InstructionsCtrl instructionCtrl = new InstructionsCtrl();
        private QuestionsSummaryCtrl questionsSummaryCtrl = new QuestionsSummaryCtrl();
        private ObjectiveCtrl objectiveCtrl = new ObjectiveCtrl();
        private QuestionsListCtrl questionListCtrl = new QuestionsListCtrl();
        private QuestionViewCtrl questionViewCtrl = new QuestionViewCtrl();
        private SubmitPreviewCtrl answersPreviewCtrl = new SubmitPreviewCtrl();

        private BrowserForm browserForm = new BrowserForm();

        private TaskForm taskForm = new TaskForm();
        private bool skipTaskManager = false;
        private bool isStarted = false;

        private bool timeUp = false;

        public MainForm() {
            InitializeComponent();

            TestTimer.Instance.TimeUpReceived += new EventHandler(TestTimer_TimeUpReceived);

            instructionCtrl.StartClicked += new EventHandler(instructionCtrl_StartClicked);
            instructionCtrl.CancelClicked += new EventHandler(instructionCtrl_CancelClicked);

            questionsSummaryCtrl.ViewObjectiveQuestionsClicked += new EventHandler(questionsSummaryCtrl_ViewObjectiveQuestionsClicked);
            questionsSummaryCtrl.ViewProgrammingQuestionsClicked += new EventHandler(questionsSummaryCtrl_ViewProgrammingQuestionsClicked);
            questionsSummaryCtrl.SubmitPreviewClicked += new EventHandler(questionsSummaryCtrl_SubmitPreviewClicked);

            objectiveCtrl.SubmitPreviewClicked += new EventHandler(objectiveCtrl_SubmitPreviewClicked);
            objectiveCtrl.WebReferenceClicked += new EventHandler(objectiveCtrl_WebReferenceClicked);
            objectiveCtrl.HomeClicked += new EventHandler(objectiveCtrl_HomeClicked);

            questionListCtrl.SubmitTestClicked += new EventHandler(questionListCtrl_SubmitTestClicked);
            questionListCtrl.HomeClicked += new EventHandler(questionListCtrl_HomeClicked);
            questionListCtrl.ViewQuestionClicked += new EventHandler<ViewQuestionEventArgs>(questionListCtrl_ViewQuestionClicked);
            questionListCtrl.WebReferenceClicked += new EventHandler(questionListCtrl_WebReferenceClicked);

            questionViewCtrl.ViewProgrammingQuestionsClicked += new EventHandler(questionViewCtrl_ViewProgrammingQuestionsClicked);
            questionViewCtrl.HomeClicked += new EventHandler(questionViewCtrl_HomeClicked);
            questionViewCtrl.SubmitPreviewClicked += new EventHandler(questionViewCtrl_SubmitPreviewClicked);
            questionViewCtrl.WebReferenceClicked += new EventHandler(questionViewCtrl_WebReferenceClicked);

            answersPreviewCtrl.SubmitTestAnswersClicked += new EventHandler(answersPreviewCtrl_SubmitTestAnswersClicked);
            answersPreviewCtrl.HomeClicked += new EventHandler(answersPreviewCtrl_HomeClicked);
            answersPreviewCtrl.ViewQuestionClicked += new EventHandler<ViewQuestionEventArgs>(answersPreviewCtrl_ViewQuestionClicked);
            answersPreviewCtrl.WebReferenceClicked += new EventHandler(answersPreviewCtrl_WebReferenceClicked);

            taskForm.SkipTaskManagerClicked += new EventHandler(taskForm_SkipTaskManagerClicked);
            taskForm.CandidateDisqualified += new EventHandler(taskForm_CandidateDisqualified);
            TaskManager.Instance.ApplicationsListed += new EventHandler(TaskManager_ApplicationsListed);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            instructionCtrl.LoadControl();
            LoadControl(instructionCtrl);
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            if (ServiceManager.Instance.TestSchedule.LiveImage) {
                VideoPreviewForm videoStreamForm = new VideoPreviewForm();
                videoStreamForm.LoadForm();
                if (WebCamManager.Instance.IsConnected) {
                    if (videoStreamForm.ShowDialog() == DialogResult.No) {
                        this.Close();
                    }
                } else {
                    // Ignore if demo user
                    if (ServiceManager.Instance.Email != Globals.DemoEmail) {
                        WebcamRequiredMessageForm webcamRequiredMessageForm = new WebcamRequiredMessageForm();
                        if (webcamRequiredMessageForm.ShowDialog() == DialogResult.No) {
                            this.Close();
                        }
                    }
                }
            }

            TaskManager.Instance.Start();
        }

        private void LoadControl(Control ctrl) {
            this.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            this.Controls.Add(ctrl);
        }

        private void TestTimer_TimeUpReceived(object sender, EventArgs e) {
            timeUp = true;
            // Save currently editing question
            if (this.Controls.Count == 1) {
                Control ctrl = this.Controls[0];
                if (ctrl.GetType() == typeof(QuestionViewCtrl)) {
                    ((QuestionViewCtrl)ctrl).SaveAnswer();
                }
            }
            // Directly go to answers preview if timeup
            answersPreviewCtrl.LoadControl();
            LoadControl(answersPreviewCtrl);
        }

        private void taskForm_SkipTaskManagerClicked(object sender, EventArgs e) {
            skipTaskManager = true;
            taskForm.DialogResult = DialogResult.OK;
        }

        private void taskForm_CandidateDisqualified(object sender, EventArgs e) {
            if (ServiceManager.Instance.Email == Globals.DemoEmail) return; // Do nothing if user logged in with demo account

            ServiceManager.Instance.SetCandidateDisqualified();

            taskForm.Visible = false;
            // Show disqualify form
            DisqualifiedForm disqualifiedForm = new DisqualifiedForm();
            disqualifiedForm.ShowDialog();

            this.Close(); // close application
        }

        private void TaskManager_ApplicationsListed(object sender, EventArgs e) {
            if (taskForm.IsVisible == false && TaskManager.Instance.Apps.Count > 0 && IsUnignoredAppExists() && skipTaskManager == false) {
                taskForm.IsVisible = true;
                taskForm.LoadForm();
                if (isStarted) {
                    taskForm.StartTimer();
                }
                taskForm.ShowDialog();
                taskForm.StopTimer();
                taskForm.IsVisible = false;
            }
        }

        private bool IsUnignoredAppExists() {
            foreach (App app in TaskManager.Instance.Apps) {
                if (taskForm.ApplicationsIgnored.Contains(app.Name) == false) {
                    return true;
                }
            }

            return false;
        }

        private void instructionCtrl_StartClicked(object sender, EventArgs e) {
            // Download test questions from server
            if (ServiceManager.Instance.LoadQuestions()) {
                if (ServiceManager.Instance.UpdateTestStarted()) {
                    TestTimer.Instance.Start(ServiceManager.Instance.TestSchedule.Duration);
                    isStarted = true;

                    if (ServiceManager.Instance.TestSchedule.LiveImage) {
                        ImageCaptureForm imageCaptureForm = new ImageCaptureForm ();
                        imageCaptureForm.LoadForm();
                        imageCaptureForm.Show();
                    }

                    questionsSummaryCtrl.LoadControl();
                    LoadControl(questionsSummaryCtrl);
                } else {
                    MessageBox.Show("Unexpected error occured while starting the test. Please try agin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Unexpected error occured while downloading questions from the server. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void instructionCtrl_CancelClicked(object sender, EventArgs e) {
            this.Close();
        }

        private void questionsSummaryCtrl_ViewObjectiveQuestionsClicked(object sender, EventArgs e) {
            objectiveCtrl.LoadControl();
            LoadControl(objectiveCtrl);
        }

        private void questionsSummaryCtrl_ViewProgrammingQuestionsClicked(object sender, EventArgs e) {
            questionListCtrl.LoadControl();
            LoadControl(questionListCtrl);
        }

        private void questionsSummaryCtrl_SubmitPreviewClicked(object sender, EventArgs e) {
            answersPreviewCtrl.LoadControl();
            LoadControl(answersPreviewCtrl);
        }

        private void objectiveCtrl_HomeClicked(object sender, EventArgs e) {
            questionsSummaryCtrl.LoadControl();
            LoadControl(questionsSummaryCtrl);
        }

        private void objectiveCtrl_WebReferenceClicked(object sender, EventArgs e) {
            ShowBrowser();
        }

        private void objectiveCtrl_SubmitPreviewClicked(object sender, EventArgs e) {
            answersPreviewCtrl.LoadControl();
            LoadControl(answersPreviewCtrl);
        }

        private void questionListCtrl_HomeClicked(object sender, EventArgs e) {
            questionsSummaryCtrl.LoadControl();
            LoadControl(questionsSummaryCtrl);
        }

        private void questionListCtrl_ViewQuestionClicked(object sender, ViewQuestionEventArgs e) {
            questionViewCtrl.LoadQuestion(e.Question);
            LoadControl(questionViewCtrl);
        }

        private void questionListCtrl_SubmitTestClicked(object sender, EventArgs e) {
            answersPreviewCtrl.LoadControl();
            LoadControl(answersPreviewCtrl);
        }

        private void questionListCtrl_WebReferenceClicked(object sender, EventArgs e) {
            ShowBrowser();
        }

        private void questionViewCtrl_HomeClicked(object sender, EventArgs e) {
            questionsSummaryCtrl.LoadControl();
            LoadControl(questionsSummaryCtrl);
        }

        private void questionViewCtrl_ViewProgrammingQuestionsClicked(object sender, EventArgs e) {
            questionViewCtrl.SaveAnswer();
            LoadControl(questionListCtrl);
        }

        private void questionViewCtrl_SubmitPreviewClicked(object sender, EventArgs e) {
            questionViewCtrl.SaveAnswer();
            answersPreviewCtrl.LoadControl();
            LoadControl(answersPreviewCtrl);
        }

        private void questionViewCtrl_WebReferenceClicked(object sender, EventArgs e) {
            ShowBrowser();
        }

        private void answersPreviewCtrl_SubmitTestAnswersClicked(object sender, EventArgs e) {
            bool submitted = ServiceManager.Instance.SubmitTestAnswers();

            if (taskForm.ApplicationsIgnored.Count > 0) {
                ServiceManager.Instance.UpdateApplicationsIgnored(String.Join("|", taskForm.ApplicationsIgnored.ToArray()));
            }

            if (ServiceManager.Instance.TestSchedule.WebReference) {
                ServiceManager.Instance.UpdateWebsitesVisited(String.Join("|", browserForm.Urls.ToArray()));
            }

            if (ServiceManager.Instance.TestSchedule.LiveImage) {
                ServiceManager.Instance.SubmitTestImages();
            }

            if (submitted) {
                MessageBox.Show("Test answers successfully submitted", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                MessageBox.Show("Submitting test answers failed", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void answersPreviewCtrl_HomeClicked(object sender, EventArgs e) {
            if (timeUp) {
                MessageBox.Show("No time left. Now you can only submit test.", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                questionsSummaryCtrl.LoadControl();
                LoadControl(questionsSummaryCtrl);
            }
        }

        private void answersPreviewCtrl_ViewQuestionClicked(object sender, ViewQuestionEventArgs e) {
            if (timeUp) {
                MessageBox.Show("No time left. Now you can only submit test.", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                if (e.Question.Type == TestService.QuestionType.Objective) {
                    objectiveCtrl.LoadControl();
                    objectiveCtrl.ViewQuestion((TestService.ObjectiveQuestion)e.Question);
                    LoadControl(objectiveCtrl);
                } else {
                    questionViewCtrl.LoadQuestion(e.Question);
                    LoadControl(questionViewCtrl);
                }
            }
        }

        private void answersPreviewCtrl_WebReferenceClicked(object sender, EventArgs e) {
            ShowBrowser();
        }

        private void ShowBrowser() {
            if (ServiceManager.Instance.TestSchedule.WebReference) {
                browserForm.Show();
            } else {
                MessageBox.Show("Internet access not enabled!", "Web reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}