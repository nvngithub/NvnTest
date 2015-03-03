using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using NvnTest.Common;
using System.Diagnostics;

namespace NvnTest.Employer {
    public partial class ExeLaunchForm : Form {
        private TestService.TestAnswerBase answer;

        private string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;

        public ExeLaunchForm() {
            InitializeComponent();

            syntaxDocument1.SyntaxFile = appPath + "syntax\\C.syn";
        }

        public TestService.TestAnswerBase Answer {
            get { return answer; }
            set { answer = value; }
        }

        public void LoadForm() {
            if (answer != null) {
                switch (answer.Type) {
                    case TestService.QuestionType.Programming:
                        TestService.ProgrammingQuestionTestAnswer programming_answer = (TestService.ProgrammingQuestionTestAnswer)answer;
                        switch (programming_answer.AnswerType) {
                            case TestService.ProgrammingAnswerType.C:
                                syntaxDocument1.SyntaxFile = appPath + "syntax\\C.syn";
                                break;
                            case TestService.ProgrammingAnswerType.CPP:
                                syntaxDocument1.SyntaxFile = appPath + "syntax\\CPP.syn";
                                break;
                            case TestService.ProgrammingAnswerType.CSharp:
                                syntaxDocument1.SyntaxFile = appPath + "syntax\\CSharp.syn";
                                break;
                            case TestService.ProgrammingAnswerType.Java:
                                syntaxDocument1.SyntaxFile = appPath + "syntax\\Java.syn";
                                break;
                        }

                        codeEditorCtrl.Document.Text = programming_answer.ExeCode;
                        break;
                }
            }
        }

        // TODO: both employer and candidate have similar code for executing application. Can be moved to Common library
        private void btnRun_Click(object sender, EventArgs e) {
            if (answer != null) {
                
                switch (answer.Type) {
                    case TestService.QuestionType.Programming:
                        TestService.ProgrammingQuestionTestAnswer programming_answer = (TestService.ProgrammingQuestionTestAnswer)answer;
                        string exePath = appPath + "out\\app.exe";
                        string className = string.Empty;
                        if (programming_answer.AnswerType == TestService.ProgrammingAnswerType.Java) {
                            className = Common.Common.GetJavaClassName(programming_answer.ExeCode);
                            exePath = appPath + "out\\" + className + ".class";
                        }

                        if (File.Exists(exePath)) {
                            File.Delete(exePath);
                        }

                        StringBinaryConverter.StringToBinary(exePath, programming_answer.Exe);

                        if (programming_answer.AnswerType == TestService.ProgrammingAnswerType.Java) {
                            ExecuteJavaApp(exePath, className);
                        } else {
                            ExecuteWin32App();
                        }
                        break;
                }
            }
        }

        private void ExecuteWin32App() {
            Execute("cmd.exe", "/C " + "\"" + appPath + "run.bat" + "\"");
        }

        private void ExecuteJavaApp(string outJavaFile, string className) {
            if (String.IsNullOrEmpty(PrerequisitesAdapter.JavaPath)) {
                PrerequisitesAdapter.Analyze();
            }

            string outPath = appPath + @"out\";
            if (File.Exists(PrerequisitesAdapter.JavaPath) && File.Exists(outJavaFile)) {
                string bat = File.ReadAllText(appPath + "runjava.bat");

                bat = bat.Replace("[exe]", "\"" + PrerequisitesAdapter.JavaPath + "\"");
                bat = bat.Replace("[classpath]", "\"" + appPath + "out" + "\"");
                bat = bat.Replace("[classname]", className);

                File.WriteAllText(outPath + "runjava.bat", bat);

                Execute("cmd.exe", "/C " + "\"" + outPath + "runjava.bat" + "\"");
            }
        }

        private static void Execute(string exe, string args) {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = exe;
            info.Arguments = args;

            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = info;
            process.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
        }
    }
}
