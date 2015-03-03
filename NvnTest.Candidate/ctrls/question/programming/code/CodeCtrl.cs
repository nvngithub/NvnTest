using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NvnTest.Common;
using System.IO;

namespace NvnTest.Candidate {
    public partial class CodeCtrl : UserControl, IProgrammingQuestionControl {
        private string questionText;
        private string code;
        private string exe;
        private string exeCode;
        private bool isAutoExecution;
        private TestService.ProgrammingAnswerType answerType, previousAnswerType;
        private TestService.AutoProgrammingQuestion autoProgrammingQuestion;
        string c_template, cpp_template, csharp_template, vbnet_template, java_template;

        public event EventHandler AnswerChanged;
        public event EventHandler SourceCodeCompiled;

        public CodeCtrl() {
            InitializeComponent();

            cdCmdCtrl1.RunClicked += new EventHandler(cdCmdCtrl1_RunClicked);
            cdCmdCtrl1.ClearClicked += new EventHandler(cdCmdCtrl1_ClearClicked);
            codeEditorCtrl1.AnswerChanged += new EventHandler(codeEditorCtrl1_AnswerChanged);
        }

        #region IProgrammingQuestionControl Members

        public TestService.ProgrammingAnswerType AnswerType {
            get { return answerType; }
            set { answerType = value; }
        }

        public TestService.ProgrammingAnswerType PreviousAnswerType {
            get { return previousAnswerType; }
            set { previousAnswerType = value; }
        }

        public int WindowIndex {
            get { return tabControl1.SelectedIndex; }
            set { tabControl1.SelectedIndex = value; }
        }

        public string QuestionText {
            get { return questionText; }
            set { questionText = value; }
        }

        public string Code {
            get { return codeEditorCtrl1.Source; }
            set { code = value; }
        }

        public string Exe {
            get { return exe; }
            set { exe = value; }
        }

        public string ExeCode {
            get { return exeCode; }
            set { exeCode = value; }
        }

        #endregion

        public bool IsAutoExecution {
            get { return isAutoExecution; }
            set { isAutoExecution = value; }
        }

        public TestService.AutoProgrammingQuestion AutoProgrammingQuestion {
            get { return autoProgrammingQuestion; }
            set { autoProgrammingQuestion = value; }
        }

        public void LoadControl() {
            // Load code control
            codeEditorCtrl1.AnswerType = this.answerType;
            codeEditorCtrl1.LoadControl();

            txtQuestion.Text = questionText;

            if (isAutoExecution) {
                LoadAutoCode();
            } else {
                LoadManualCode();
            }

            previousAnswerType = answerType;
        }

        private void LoadAutoCode() {
            if (String.IsNullOrEmpty(code) || IsAutoCodeMatchAnyTemplate(code)) {
                codeEditorCtrl1.Source = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, answerType);
            } else if (answerType == previousAnswerType) {
                // Code is edited. Show same source code
                codeEditorCtrl1.Source = code;
            } else {
                // Answer type changed. Retain old code
                string sourceCode = "/* Your changes retained!! " + Environment.NewLine + code + Environment.NewLine + "*/" + Environment.NewLine;

                sourceCode += ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, answerType);

                codeEditorCtrl1.Source = sourceCode;
            }
        }

        private void LoadManualCode() {
            LoadTemplates();

            if (String.IsNullOrEmpty(code) || IsCodeMatchAnyTemplate(code)) {
                // Load template code
                switch (answerType) {
                    case TestService.ProgrammingAnswerType.C: codeEditorCtrl1.Source = c_template; break;
                    case TestService.ProgrammingAnswerType.CPP: codeEditorCtrl1.Source = cpp_template; break;
                    case TestService.ProgrammingAnswerType.CSharp: codeEditorCtrl1.Source = csharp_template; break;
                    case TestService.ProgrammingAnswerType.VBNET: codeEditorCtrl1.Source = vbnet_template; break;
                    case TestService.ProgrammingAnswerType.Java: codeEditorCtrl1.Source = java_template; break;
                }
            } else if (answerType == previousAnswerType) {
                // Code is edited. Show same source code
                codeEditorCtrl1.Source = code;
            } else {
                // Answer type changed. Retain old code
                string sourceCode = "/* Your changes retained!! " + Environment.NewLine + code + Environment.NewLine + "*/" + Environment.NewLine;

                switch (answerType) {
                    case TestService.ProgrammingAnswerType.C:
                        sourceCode += codeEditorCtrl1.Source = c_template; break;
                    case TestService.ProgrammingAnswerType.CPP:
                        sourceCode += codeEditorCtrl1.Source = cpp_template; break;
                    case TestService.ProgrammingAnswerType.CSharp:
                        sourceCode += codeEditorCtrl1.Source = csharp_template; break;
                    case TestService.ProgrammingAnswerType.VBNET:
                        sourceCode += codeEditorCtrl1.Source = vbnet_template; break;
                    case TestService.ProgrammingAnswerType.Java:
                        sourceCode += codeEditorCtrl1.Source = java_template; break;
                }

                codeEditorCtrl1.Source = sourceCode;
            }
        }

        private void LoadTemplates() {
            if (String.IsNullOrEmpty(c_template)) {
                c_template = GetTemplateCode("template\\c.txt");
            }

            if (String.IsNullOrEmpty(cpp_template)) {
                cpp_template = GetTemplateCode("template\\cpp.txt");
            }

            if (String.IsNullOrEmpty(csharp_template)) {
                csharp_template = GetTemplateCode("template\\csharp.txt");
            }

            if (String.IsNullOrEmpty(vbnet_template)) {
                vbnet_template = GetTemplateCode("template\\vbnet.txt");
            }

            if (String.IsNullOrEmpty(java_template)) {
                java_template = GetTemplateCode("template\\java.txt");
            }
        }

        private string GetTemplateCode(string filename) {
            string template = string.Empty;
            using (StreamReader tr = new StreamReader(filename)) {
                template = tr.ReadToEnd();
            }
            return template;
        }

        private bool IsAutoCodeMatchAnyTemplate(string code) {
            code = code.Replace("\r", "");
            string c_template = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, TestService.ProgrammingAnswerType.C);
            string cpp_template = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, TestService.ProgrammingAnswerType.CPP);
            string csharp_template = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, TestService.ProgrammingAnswerType.CSharp);
            string vbnet_template = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, TestService.ProgrammingAnswerType.VBNET);
            string java_template = ServiceManager.Instance.GetTemplateCode(autoProgrammingQuestion, TestService.ProgrammingAnswerType.Java);

            return (code == c_template || code == cpp_template || code == csharp_template || code == vbnet_template || code == java_template);
        }

        private bool IsCodeMatchAnyTemplate(string code) {
            return (code == c_template || code == cpp_template || code == csharp_template || code == vbnet_template || code == java_template);
        }

        private void cdCmdCtrl1_RunClicked(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 2; // show output window
            if (isAutoExecution) {
                RunAutoCode();
            } else {
                RunMaualCode();
            }
        }

        private void RunMaualCode() {
            bool isCompiled = CompileCode();
            if (isCompiled) {
                switch (answerType) {
                    case TestService.ProgrammingAnswerType.C:
                    case TestService.ProgrammingAnswerType.CPP:
                    case TestService.ProgrammingAnswerType.CSharp:
                    case TestService.ProgrammingAnswerType.VBNET:
                        AppExecutor.ExecuteWin32App();
                        break;
                    case TestService.ProgrammingAnswerType.Java:
                        if (String.IsNullOrEmpty(PrerequisitesAdapter.JavaPath) == false) {
                            AppExecutor.ExecuteJavaApp();
                        } else {
                            MessageBoxEx.Show("Java Runtime", "Unable to find Java Runtime. Please install Java Runtime if you want to answer programming questions in Java.");
                        }
                        break;
                }
            }
        }

        private void RunAutoCode() {
            bool isCompiled = CompileCode();
            if (isCompiled) {
                switch (answerType) {
                    case TestService.ProgrammingAnswerType.C:
                    case TestService.ProgrammingAnswerType.CPP:
                    case TestService.ProgrammingAnswerType.CSharp:
                    case TestService.ProgrammingAnswerType.VBNET:
                        List<string> outputMessages = AppExecutor.AutoExecuteWin32App();
                        if (outputMessages != null) {
                            outputCtrl1.AppendMessage(String.Join(Environment.NewLine, outputMessages.ToArray()));
                        }
                        break;
                    case TestService.ProgrammingAnswerType.Java:
                        if (String.IsNullOrEmpty(PrerequisitesAdapter.JavaPath) == false) {
                            List<string> javaOutputMessages = AppExecutor.AutoExecuteJavaApp();
                            if (javaOutputMessages != null) {
                                outputCtrl1.AppendMessage(String.Join(Environment.NewLine, javaOutputMessages.ToArray()));
                            }
                        } else {
                            MessageBoxEx.Show("Java Runtime", "Unable to find Java Runtime. Please install Java Runtime if you want to answer programming questions in Java.");
                        }
                        break;
                }
            }
        }

        private void codeEditorCtrl1_AnswerChanged(object sender, EventArgs e) {
            if (AnswerChanged != null) { AnswerChanged(this, null); }
        }

        private void cdCmdCtrl1_ClearClicked(object sender, EventArgs e) {
            AppExecutor.Clear();
        }

        private bool CompileCode() {
            outputCtrl1.Clear();
            string appFilename = Globals.OutExePath.Trim(Path.GetInvalidFileNameChars());
            string javaClassFileName = string.Empty; // used only during auto compilation
            if (answerType == TestService.ProgrammingAnswerType.Java) {
                if (isAutoExecution) {
                    Globals.OutJavaClassName = "Program";
                    appFilename = Globals.OutJavaPath = Globals.OutPathTrim + "Program.class";
                    javaClassFileName = Globals.OutPathTrim + "Test.class";
                } else {
                    Globals.OutJavaClassName = Common.Common.GetJavaClassName(codeEditorCtrl1.Source);
                    appFilename = Globals.OutJavaPath = Globals.OutPathTrim + Globals.OutJavaClassName + ".class";
                }
            }

            // Delete existing exe file
            if (File.Exists(appFilename)) { File.Delete(appFilename); }

            // Delete files if created by auto generated code
            if (Directory.Exists(Globals.OutAutoExeOutputPath.Trim(Path.GetInvalidFileNameChars()))) { Directory.Delete(Globals.OutAutoExeOutputPath.Trim(Path.GetInvalidFileNameChars()), true); }

            TestService.CompilerMessage message = null;
            if (isAutoExecution) {
                message = ServiceManager.Instance.CompileCode(autoProgrammingQuestion, codeEditorCtrl1.Source, Common.Common.UniqueId, answerType);
            } else {
                message = ServiceManager.Instance.CompileCode(codeEditorCtrl1.Source, Common.Common.UniqueId, answerType);
            }

            string[] errorMessages = message.ErrorMessages;
            if (errorMessages.Length == 0) {
                outputCtrl1.AppendMessage("Code is compiled successfully");
                outputCtrl1.TextColor = Color.Blue;
            } else {
                outputCtrl1.AppendMessage(String.Join(Environment.NewLine, errorMessages));
                outputCtrl1.TextColor = Color.DarkRed;
            }

            if (message.Success) {
                this.exe = message.Exe;
                this.exeCode = codeEditorCtrl1.Source;
                this.code = codeEditorCtrl1.Source;

                // create EXE file
                StringBinaryConverter.StringToBinary(appFilename, message.Exe);
                if (String.IsNullOrEmpty(message.Exe1) == false) {
                    StringBinaryConverter.StringToBinary(javaClassFileName, message.Exe1);
                }

                if (SourceCodeCompiled != null) { SourceCodeCompiled(this, null); }
            }

            return message.Success;
        }
    }
}