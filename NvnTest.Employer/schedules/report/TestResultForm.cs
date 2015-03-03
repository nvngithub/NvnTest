using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using NvnTest.Common;
using RTF = NvnTest.Employer.Rtf;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace NvnTest.Employer {
    public partial class TestResultForm : Form {
        private PrintingDataGridViewProvider printProvider;
        private PrintDocument printDocument = new PrintDocument();
        private RTF.RtfDocument rtfDocument;
        private string rtfReport;
        private TestService.TestSchedule testSchedule;
        private TestService.TestAnswers testAnswers;

        private Color descColor = Color.Black;
        private Color answerColor = Color.Gray;
        private int questionIndex = 0;
        private int questionsCount = 0;
        private int score = 0;
        private int reportMode = 0; // 0 = Grid, 1 = RTF

        public TestResultForm() {
            InitializeComponent();
        }

        public TestService.TestSchedule TestSchedule {
            get { return testSchedule; }
            set { testSchedule = value; }
        }

        public void LoadForm() {
            object response = ServiceManager.Instance.LoadTestAnswersRemote(testSchedule.Id);
            testAnswers = (TestService.TestAnswers)response;

            CreateReport(0);
        }

        private void CreateReport(int mode) {
            reportMode = mode;

            if (mode == 1) {
                rtfDocument = new RTF.RtfDocument(RTF.PaperSize.A4, RTF.PaperOrientation.Portrait, RTF.Lcid.English);
            }

            AddTestDetails();

            questionIndex = questionsCount = score = 0;
            AddDescription("Questions and Answers", Color.Black, true, 0, null);
            AddToReport<TestService.ObjectiveQuestionTestAnswer>(testAnswers.ObjectiveQuestionTestAnswers);
            AddToReport<TestService.SqlQuestionTestAnswer>(testAnswers.SqlQuestionTestAnswers);
            AddToReport<TestService.ProgrammingQuestionTestAnswer>(testAnswers.ProgrammingQuestionTestAnswers);
            AddToReport<TestService.AutoProgrammingQuestionTestAnswer>(testAnswers.AutoProgrammingQuestionTestAnswers);
            AddToReport<TestService.WebProgrammingQuestionTestAnswer>(testAnswers.WebPogrammingQuestionTestAnswers);

            if (mode == 0) {
                dgrResult[DescCol.Index, 3].Value = ((string)dgrResult[DescCol.Index, 3].Value).Replace("[count]", questionsCount.ToString());
                dgrResult[DescCol.Index, 4].Value = ((string)dgrResult[DescCol.Index, 4].Value).Replace("[marks]", score.ToString());
            } else if (mode == 1) {
                // Save to local folder
                string localRtfReportPath = Common.Common.LocalPath + "report.rtf";
                rtfDocument.save(localRtfReportPath);
                // Read report stored in local folder and replace count and marks
                rtfReport = File.ReadAllText(localRtfReportPath);
                rtfReport = rtfReport.Replace(": [count]", "    :" + questionsCount.ToString());
                rtfReport = rtfReport.Replace("[marks]", score.ToString());
            }
        }

        private void AddTestDetails() {
            AddDescription("Name".PadRight(28, ' ') + ": " + testSchedule.FirstName + " " + testSchedule.LastName, Color.Maroon, true, 0, null);
            AddDescription("Email".PadRight(30, ' ') + ": " + testSchedule.Email, Color.Maroon, true, 0, null);
            AddDescription("Test Date".PadRight(27, ' ') + ": " + testSchedule.TestTakenDateTime.ToString("dd-MM-yyyy"), Color.Maroon, true, 0, null);
            AddDescription("Number of questions".PadRight(22, ' ') + ": [count]", Color.Maroon, true, 0, null);
            AddDescription("Total marks".PadRight(27, ' ') + ": [marks]" + " (Only objective type of questions considered)", Color.Maroon, true, 0, null);
            AddDescription("   ", Color.Black, 0);
        }

        private void AddToReport<T>(T[] answers) where T : TestService.TestAnswerBase {
            foreach (TestService.TestAnswerBase answer in answers) {
                object response = (TestService.QuestionBase)ServiceManager.Instance.LoadQuestion(answer.Type, answer.QuestionId);

                if (response == null) {
                    AddDescription("Unable to retrieve question and answer", Color.Red, 0);
                    continue;
                }

                TestService.QuestionBase question = (TestService.QuestionBase)response;

                questionsCount++;
                switch (answer.Type) {
                    case TestService.QuestionType.Objective:
                        // Show question
                        TestService.ObjectiveQuestion objectiveQuestion = (TestService.ObjectiveQuestion)question;
                        Dictionary<string, string> q_answers = new Dictionary<string, string>();
                        foreach (string q_answer in objectiveQuestion.Answers) {
                            string[] q_answerParts = q_answer.Split("*".ToCharArray());
                            q_answers.Add(q_answerParts[0], q_answerParts[1]);
                        }
                        AddDescription(objectiveQuestion.Desc, descColor, ++questionIndex);
                        string objectiveQuestionOptions = string.Empty;
                        for (int i = 0; i < objectiveQuestion.Options.Length; i++) {
                            objectiveQuestionOptions += "    " + (i + 1) + ". " + objectiveQuestion.Options[i];
                            if (i < objectiveQuestion.Options.Length - 1) objectiveQuestionOptions += Environment.NewLine;
                        }
                        AddDescription(objectiveQuestionOptions, descColor, 0);
                        AddQuestionModifiedInstruction(question);
                        // Show answer
                        List<string> selectedOptions = new List<string>();
                        TestService.ObjectiveQuestionTestAnswer objectiveQuestionTestAnswer = (TestService.ObjectiveQuestionTestAnswer)answer;
                        foreach (int selectedOption in objectiveQuestionTestAnswer.SelectedOptions) {
                            if (selectedOption >= objectiveQuestion.Options.Length) continue;
                            selectedOptions.Add(objectiveQuestion.Options[selectedOption] + (q_answers.ContainsKey((selectedOption + 1).ToString()) ? " [Correct]" : " [Incorrect]"));
                        }
                        AddDescription("Answer: " + Environment.NewLine + String.Join(Environment.NewLine, selectedOptions.ToArray()), answerColor, 0);
                        // Blank line
                        AddDescription("   ", Color.Black, 0);
                        // Calculate score
                        int questionScore = 0;
                        foreach (int selectedOption in objectiveQuestionTestAnswer.SelectedOptions) {
                            if (q_answers.ContainsKey((selectedOption + 1).ToString())) {
                                questionScore += Convert.ToInt32(q_answers[(selectedOption + 1).ToString()]);
                            } else {
                                questionScore = 0;// Wrong option choosen. So zero mark!!!!
                                break;
                            }
                        }
                        score += questionScore;
                        break;
                    case TestService.QuestionType.Sql:
                        AddDescription(question.Desc, descColor, ++questionIndex);
                        AddQuestionModifiedInstruction(question);
                        TestService.SqlQuestionTestAnswer sqlAnswer = (TestService.SqlQuestionTestAnswer)answer;
                        AddDescription("Answer: " + Environment.NewLine + sqlAnswer.Sql, answerColor, 0);
                        // Blank line
                        AddDescription("   ", Color.Black, 0);
                        break;
                    case TestService.QuestionType.Programming:
                        AddDescription(question.Desc, descColor, ++questionIndex);
                        AddQuestionModifiedInstruction(question);
                        TestService.ProgrammingQuestionTestAnswer csharp_Answer = (TestService.ProgrammingQuestionTestAnswer)answer;
                        AddDescription("Answer: " + Environment.NewLine + csharp_Answer.Code, answerColor, 0, csharp_Answer);
                        // Blank line
                        AddDescription("   ", Color.Black, 0);
                        break;
                    case TestService.QuestionType.AutoProgramming:
                        AddDescription(question.Desc, descColor, ++questionIndex);
                        AddQuestionModifiedInstruction(question);
                        TestService.AutoProgrammingQuestionTestAnswer auto_csharp_Answer = (TestService.AutoProgrammingQuestionTestAnswer)answer;
                        AddDescription("Answer: " + Environment.NewLine + auto_csharp_Answer.Code, answerColor, 0, auto_csharp_Answer);
                        // Blank line
                        AddDescription("   ", Color.Black, 0);
                        // Compile and run test cases
                        string testCasesOutput = RunAutoCode((TestService.AutoProgrammingQuestion)question, auto_csharp_Answer.AnswerType, auto_csharp_Answer.Code);
                        AddDescription("Test cases: " + Environment.NewLine + testCasesOutput, answerColor, 0);
                        break;
                    case TestService.QuestionType.WebProgramming:
                        AddDescription(question.Desc, descColor, ++questionIndex);
                        AddQuestionModifiedInstruction(question);
                        TestService.WebProgrammingQuestionTestAnswer webprogramming_Answer = (TestService.WebProgrammingQuestionTestAnswer)answer;
                        AddDescription("Answer: ", answerColor, 0, webprogramming_Answer);
                        AddDescription(webprogramming_Answer.WebNode, "/");
                        // Blank line
                        AddDescription("   ", Color.Black, 0);
                        break;
                }
            }
        }

        private void AddQuestionModifiedInstruction(TestService.QuestionBase question) {
            if (testSchedule.TestTakenDateTime < question.DateTimeModified) {
                AddDescription("(This question is modified after this test has been taken)", Color.Maroon, 0);
            }
        }

        private void AddDescription(string desc, Color color, int questionIndex) {
            AddDescription(desc, color, false, questionIndex, null);
        }

        private void AddDescription(string desc, Color color, int questionIndex, TestService.TestAnswerBase answer) {
            AddDescription(desc, color, false, questionIndex, answer);
        }

        private void AddDescription(TestService.WebNode webNode, string path) {
            if (webNode == null) return;
            foreach (TestService.WebNode node in webNode.Nodes) {
                if (node.Type == TestService.WebNodeType.Directory) {
                    AddDescription(node, path + node.Name + "/");
                } else {
                    AddDescription(path + node.Name, answerColor, true, 0, null);
                    AddDescription(node.Content, answerColor, false, 0, null);
                }
            }
        }

        private void AddDescription(string desc, Color color, bool bold, int questionIndex, TestService.TestAnswerBase answer) {
            if (reportMode == 0) {
                AddGridDescription(desc, color, bold, questionIndex, answer);
            } else if (reportMode == 1) {
                AddRtfDescription(desc, color, bold, questionIndex);
            }
        }

        private void AddGridDescription(string desc, Color color, bool bold, int questionIndex, TestService.TestAnswerBase answer) {
            int index = dgrResult.Rows.Add();
            dgrResult[DescCol.Index, index].Value = (questionIndex > 0 ? questionIndex + ". " : "") + desc;
            dgrResult[DescCol.Index, index].Style.ForeColor = String.IsNullOrEmpty(desc) ? Color.Red : color;
            if (bold) dgrResult[DescCol.Index, index].Style.Font = new Font(dgrResult.Font, FontStyle.Bold);
            if (answer != null) {
                if (answer.GetType() == typeof(TestService.ProgrammingQuestionTestAnswer)) {
                    dgrResult[ExeCol.Index, index].Value = "Run application";
                    dgrResult.Rows[index].Tag = answer;
                } else if (answer.GetType() == typeof(TestService.WebProgrammingQuestionTestAnswer)) {
                    dgrResult[ExeCol.Index, index].Value = "View in browser";
                    dgrResult.Rows[index].Tag = answer;
                }
            }
        }

        private void AddRtfDescription(string desc, Color color, bool bold, int questionIndex) {
            RTF.RtfParagraph para = rtfDocument.addParagraph();
            para.Text = (questionIndex > 0 ? questionIndex + ". " : "") + desc;
            para.DefaultCharFormat.FgColor = String.IsNullOrEmpty(desc) ? (rtfDocument.createColor(new RTF.Color(ColorToHexString(Color.Red)))) : (rtfDocument.createColor(new RTF.Color(ColorToHexString(color))));
            if (bold) para.DefaultCharFormat.FontStyle.addStyle(RTF.FontStyleFlag.Bold);
        }

        private string ColorToHexString(Color color) {
            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++) {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        private void btnSaveAsRtf_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "rtf";
            dlg.FileName = "report.rtf";
            dlg.Filter = "RTF document|*.rtf";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dlg.ShowDialog() == DialogResult.OK) {
                CreateReport(1);

                File.WriteAllText(dlg.FileName, rtfReport);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            printDocument.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);
            printProvider = PrintingDataGridViewProvider.Create(printDocument, dgrResult, true, false, false, null, null, null);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.ShowNetwork = false;
            printDialog.UseEXDialog = true;

            // Set exeCol cells to empty
            foreach (DataGridViewRow row in dgrResult.Rows) {
                dgrResult[ExeCol.Index, row.Index].Value = "";
            }

            if (printDialog.ShowDialog(this) == DialogResult.OK) {
                printDocument.Print();
            }

            // Set exeCol cells "exe" if needed
            foreach (DataGridViewRow row in dgrResult.Rows) {
                if (dgrResult.Rows[row.Index].Tag != null) {
                    dgrResult[ExeCol.Index, row.Index].Value = "Run application";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }

        private void dgrResult_SelectionChanged(object sender, EventArgs e) {
            dgrResult.ClearSelection();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Export_Executables(testAnswers.ProgrammingQuestionTestAnswers, dlg.SelectedPath);
                Export_WebFiles(testAnswers.WebPogrammingQuestionTestAnswers, dlg.SelectedPath);
            }
        }

        private void Export_Executables(TestService.ProgrammingQuestionTestAnswer[] answers, string path) {
            for (int i = 0; i < answers.Length; i++) {
                TestService.ProgrammingQuestionTestAnswer answer = answers[i];

                object response = ServiceManager.Instance.LoadQuestion(answer.Type, answer.QuestionId);
                if (response == null) {
                    continue;
                }

                TestService.QuestionBase question = (TestService.QuestionBase)response;

                string exeString = ((TestService.ProgrammingQuestionTestAnswer)answer).Exe;
                string exeCode = ((TestService.ProgrammingQuestionTestAnswer)answer).ExeCode;

                string dir = path + Path.DirectorySeparatorChar + "Application_" + (i + 1);
                if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);

                // Create exe file
                StringBinaryConverter.StringToBinary(dir + Path.DirectorySeparatorChar + "app.exe", exeString);
                // Save code to file
                string codeFileName = string.Empty;
                switch (answer.AnswerType) {
                    case TestService.ProgrammingAnswerType.CSharp: codeFileName = "Code.cs"; break;
                    case TestService.ProgrammingAnswerType.C: codeFileName = "Code.c"; break;
                    case TestService.ProgrammingAnswerType.Algo: 
                    case TestService.ProgrammingAnswerType.Desc: codeFileName = "Code.txt"; break;
                }
                WriteToFile(dir + Path.DirectorySeparatorChar + codeFileName, exeCode);
                // Save question to text file
                WriteToFile(dir + Path.DirectorySeparatorChar + "Question.txt", question.Desc);
            }
        }

        private void Export_WebFiles(TestService.WebProgrammingQuestionTestAnswer[] answers, string path) {
            for (int i = 0; i < answers.Length; i++) {
                TestService.WebProgrammingQuestionTestAnswer answer = answers[i];

                string dir = path + Path.DirectorySeparatorChar + "WebApplication_" + (i + 1) + Path.DirectorySeparatorChar;
                if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);

                // Get question description
                object response = ServiceManager.Instance.LoadQuestion(answer.Type, answer.QuestionId);
                if (response == null) {
                    continue;
                }

                TestService.QuestionBase question = (TestService.QuestionBase)response;

                File.WriteAllText(dir + "Question.txt", question.Desc);

                // Save all web pages
                WebContentSaver.Save(answer.WebNode, dir, false);
            }
        }

        private void WriteToFile(string filename, string content) {
            using (StreamWriter writer = new StreamWriter(filename)) {
                writer.Write(content);
            }
        }

        private void dgrResult_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == ExeCol.Index) {
                TestService.TestAnswerBase answer = (TestService.TestAnswerBase)dgrResult.Rows[e.RowIndex].Tag;
                if (answer != null) {
                    if (answer.GetType() == typeof(TestService.ProgrammingQuestionTestAnswer)) {
                        ExeLaunchForm exeLaunchForm = new ExeLaunchForm();
                        exeLaunchForm.Answer = answer;
                        exeLaunchForm.LoadForm();
                        exeLaunchForm.ShowDialog();
                    } else if (answer.GetType() == typeof(TestService.WebProgrammingQuestionTestAnswer)) {
                        TestService.WebProgrammingQuestionTestAnswer webProgrammingAnswer = (TestService.WebProgrammingQuestionTestAnswer)answer;
                        TestService.WebNode rootNode = webProgrammingAnswer.WebNode;

                        WebViewerForm viewerForm = new WebViewerForm();
                        viewerForm.RootNode = rootNode;
                        ServiceManager.Instance.SaveWebPages(rootNode);
                        viewerForm.LoadForm();
                        viewerForm.ShowDialog();
                    }
                }
            }
        }

        private void btnWebReference_Click(object sender, EventArgs e) {
            object response = ServiceManager.Instance.GetWebsitesVisited(testSchedule.Id);
            string urls = (string)response;
            if (String.IsNullOrEmpty(urls) == false) {
                string[] websitesVisited = urls.Split("|".ToCharArray());
                if (websitesVisited.Length > 0) {
                    WebsitesVisitedForm websitesVisitedForm = new WebsitesVisitedForm();
                    websitesVisitedForm.LoadForm(websitesVisited);
                    websitesVisitedForm.ShowDialog();
                }
            }
        }

        private void btnImagesCaptured_Click(object sender, EventArgs e) {
            if (testSchedule.LiveImage == false) {
                MessageBox.Show("Live image capture was not enabled for this test. Hence no image is available.", "Image capture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object response = ServiceManager.Instance.GetTestImages(testSchedule.Id);
            TestService.TestImage[] images = (TestService.TestImage[])response;
            if (images != null && images.Length > 0) {
                TestImagesPreviewForm imagesPreviewForm = new TestImagesPreviewForm();
                imagesPreviewForm.TestImages = images;
                imagesPreviewForm.LoadForm();

                imagesPreviewForm.ShowDialog();
            } else {
                MessageBox.Show("No images found! Please report bug this to support@coderlabz.com. We apologise for any inconvenience caused", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnApplicationsIgnored_Click(object sender, EventArgs e) {
            object response = ServiceManager.Instance.GetApplicationsIgnored(testSchedule.Id);
            string apps = (string)response;
            if (String.IsNullOrEmpty(apps) == false) {
                string[] applicationNames = apps.Split("|".ToCharArray());
                if (applicationNames.Length > 0) {
                    ApplicationsIgnoredForm applicationsIgnoredForm = new ApplicationsIgnoredForm();
                    applicationsIgnoredForm.LoadForm(applicationNames);
                    applicationsIgnoredForm.ShowDialog();
                }
            } else {
                MessageBox.Show("No application was marked as important by the candidate while taking the test", "Applications ignored", MessageBoxButtons.OK);
            }
        }



        /******************* TODO: move to another dll. make execution common in both in test mode and admin mode **************************/

        private string RunAutoCode(TestService.AutoProgrammingQuestion question, TestService.ProgrammingAnswerType answerType, string code) {
            string output = string.Empty;

            bool isCompiled = CompileCode(question, answerType, code, true/*change me*/);
            if (isCompiled) {
                switch (answerType) {
                    case TestService.ProgrammingAnswerType.C:
                    case TestService.ProgrammingAnswerType.CPP:
                    case TestService.ProgrammingAnswerType.CSharp:
                    case TestService.ProgrammingAnswerType.VBNET:
                        List<string> outputMessages = AppExecutor.AutoExecuteWin32App();
                        if (outputMessages != null) {
                            output += String.Join(Environment.NewLine, outputMessages.ToArray());
                        }
                        break;
                    case TestService.ProgrammingAnswerType.Java:
                        if (String.IsNullOrEmpty(PrerequisitesAdapter.JavaPath) == false) {
                            List<string> javaOutputMessages = AppExecutor.AutoExecuteJavaApp();
                            if (javaOutputMessages != null) {
                                output += String.Join(Environment.NewLine, javaOutputMessages.ToArray());
                            }
                        } else {
                            output += "Unable to find Java Runtime. Please install Java Runtime if you want to answer programming questions in Java.";
                        }
                        break;
                }
            }

            return output;
        }

        /******************* TODO: move to another dll. make execution common in both in test mode and admin mode **************************/
        private bool CompileCode(TestService.AutoProgrammingQuestion question, TestService.ProgrammingAnswerType answerType, string code, bool isAutoExecution) {
            string messages = string.Empty;

            string appFilename = Globals.OutExePath.Trim(Path.GetInvalidFileNameChars());
            string javaClassFileName = string.Empty; // used only during auto compilation
            if (answerType == TestService.ProgrammingAnswerType.Java) {
                if (isAutoExecution) {
                    Globals.OutJavaClassName = "Program";
                    appFilename = Globals.OutJavaPath = Globals.OutPathTrim + "Program.class";
                    javaClassFileName = Globals.OutPathTrim + "Test.class";
                } else {
                    Globals.OutJavaClassName = Common.Common.GetJavaClassName(code);
                    appFilename = Globals.OutJavaPath = Globals.OutPathTrim + Globals.OutJavaClassName + ".class";
                }
            }

            // Delete existing exe file
            if (File.Exists(appFilename)) { File.Delete(appFilename); }

            // Delete files if created by auto generated code
            if (Directory.Exists(Globals.OutAutoExeOutputPath.Trim(Path.GetInvalidFileNameChars()))) { Directory.Delete(Globals.OutAutoExeOutputPath.Trim(Path.GetInvalidFileNameChars()), true); }

            TestService.CompilerMessage message = null;
            if (isAutoExecution) {
                message = (TestService.CompilerMessage)ServiceManager.Instance.AutoCompileCode(question, code, Common.Common.UniqueId, answerType);
            } else {
                //message = ServiceManager.Instance.CompileCode(codeEditorCtrl1.Source, Common.Common.UniqueId, answerType);
            }

            string[] errorMessages = message.ErrorMessages;
            if (errorMessages.Length > 0) {
                messages += String.Join(Environment.NewLine, errorMessages);
            }

            if (message.Success) {
                // create EXE file
                StringBinaryConverter.StringToBinary(appFilename, message.Exe);
                if (String.IsNullOrEmpty(message.Exe1) == false) {
                    StringBinaryConverter.StringToBinary(javaClassFileName, message.Exe1);
                }
            }

            return message.Success;
        }
    }

    /******************* TODO: move to another dll. make execution common in both in test mode and admin mode **************************/
    public class AppExecutor {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private static List<Process> runningProcesses = new List<Process>();

        public static void ExecuteWin32App() {
            if (File.Exists(Globals.OutExePath.Trim(Path.GetInvalidFileNameChars()))) {
                Execute("cmd.exe", "/C " + "\"" + Globals.AppPath + "run.bat" + "\"");
            }
        }

        public static List<string> AutoExecuteWin32App() {
            if (File.Exists(Globals.OutExePath.Trim(Path.GetInvalidFileNameChars()))) {
                return AutoExecute(Globals.OutExePath, string.Empty);
            }

            return null;
        }

        public static void ExecuteJavaApp() {
            if (File.Exists(PrerequisitesAdapter.JavaPath) && File.Exists(Globals.OutJavaPath)) {
                string bat = File.ReadAllText(Globals.AppPath + "runjava.bat");

                bat = bat.Replace("[exe]", "\"" + PrerequisitesAdapter.JavaPath + "\"");
                bat = bat.Replace("[classpath]", Globals.OutPath);
                bat = bat.Replace("[classname]", Globals.OutJavaClassName);
                bat = bat.Replace("[pause]", "pause");

                File.WriteAllText(Globals.OutPathTrim + "runjava.bat", bat);

                Execute("cmd.exe", "/C " + "\"" + Globals.OutPathTrim + "runjava.bat" + "\"");
            }
        }

        public static List<string> AutoExecuteJavaApp() {
            if (File.Exists(PrerequisitesAdapter.JavaPath) && File.Exists(Globals.OutJavaPath)) {
                string bat = File.ReadAllText(Globals.AppPath + "runjava.bat");

                bat = bat.Replace("[exe]", "\"" + PrerequisitesAdapter.JavaPath + "\"");
                bat = bat.Replace("[classpath]", Globals.OutPath);
                bat = bat.Replace("[classname]", Globals.OutJavaClassName);
                bat = bat.Replace("[pause]", "");

                File.WriteAllText(Globals.OutPathTrim + "runjava.bat", bat);

                return AutoExecute("cmd.exe", "/C " + "\"" + Globals.OutPathTrim + "runjava.bat" + "\"");
            }

            return null;
        }

        private static void Execute(string exe, string args) {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = exe;
            info.Arguments = args;

            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
            process.StartInfo = info;
            process.Start();

            BringToFront(@"C:\Windows\System32\cmd.exe");

            runningProcesses.Add(process);
        }

        private static List<string> AutoExecute(string exe, string args) {
            ProcessStartInfo info = new ProcessStartInfo();
            info.CreateNoWindow = false;
            info.UseShellExecute = true;
            info.FileName = exe;
            info.Arguments = args;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            List<string> messages = new List<string>();
            using (Process exeProcess = Process.Start(info)) {
                // Execute only for 10 seconds
                if (exeProcess.WaitForExit(10000) == false) {
                    exeProcess.Kill();
                    messages.Add("Application aborted automatically as it took longer time to execute.");

                    return messages;
                }
            }

            // Read and send it back to the client.
            string outDirectory = Globals.OutAutoExeOutputPath.Trim(Path.GetInvalidFileNameChars());
            if (Directory.Exists(outDirectory)) {
                string[] files = Directory.GetFiles(outDirectory);
                foreach (string file in files) {
                    messages.Add(File.ReadAllText(file));
                }
            }

            return messages;
        }

        public static void BringToFront(string title) {
            IntPtr handle = FindWindow(null, title);

            if (handle == IntPtr.Zero) {
                return;
            }

            SetForegroundWindow(handle);
        }

        public static void Clear() {
            foreach (Process process in runningProcesses.ToArray()) {
                if (process.HasExited == false) {
                    process.CloseMainWindow();
                }
            }

            runningProcesses.Clear();
        }

        static void process_Exited(object sender, EventArgs e) {
            for (int i = runningProcesses.Count - 1; i >= 0; i--) {
                if (runningProcesses[i].HasExited) {
                    runningProcesses.Remove(runningProcesses[i]);
                }
            }
        }
    }

    /******************* TODO: move to another dll. make execution common in both in test mode and admin mode **************************/
    public class Globals {
        public static string AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;

        public static string OutPath = "\"" + AppPath + "out" + "\"";
        public static string OutPathTrim = AppPath + "out" + @"\";
        public static string CodePath = "\"" + AppPath + "out\\code" + "\"";
        public static string OutExePath = "\"" + AppPath + "out\\app.exe" + "\"";
        public static string OutExePathTrim = AppPath + "out\\app.exe";
        public static string OutAutoExeOutputPath = "\"" + AppPath + "out\\out" + "\"";

        public static string OutJavaPath = string.Empty;
        public static string OutJavaClassName = string.Empty;

        public static string TccCompilerPath = "\"" + AppPath + "tcc\\tcc.exe" + "\"";

        public static string DemoEmail = "demo@coderlabz.com";
    }
}