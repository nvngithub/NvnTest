using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using NvnTest.Common;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using System.Net;
using System.Management;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Deployment.Application;

namespace NvnTest.Candidate {

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

    #region Capture web cam image
    internal class WebCamCapture : IDisposable {
        /* Those contants are used to overload the unmanaged code functions each constant represent a state*/

        private const short WM_CAP = 0x400;
        private const int WM_CAP_DRIVER_CONNECT = 0x40a;
        private const int WM_CAP_DRIVER_DISCONNECT = 0x40b;
        private const int WM_CAP_EDIT_COPY = 0x41e;
        private const int WM_CAP_SET_PREVIEW = 0x432;
        private const int WM_CAP_SET_OVERLAY = 0x433;
        private const int WM_CAP_SET_PREVIEWRATE = 0x434;
        private const int WM_CAP_SET_SCALE = 0x435;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const short SWP_NOMOVE = 0x2;
        private short SWP_NOZORDER = 0x4;
        private short HWND_BOTTOM = 1;

        //This function enables enumerate the web cam devices
        [DllImport("avicap32.dll")]
        protected static extern bool capGetDriverDescriptionA(short wDriverIndex, [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        //This function enables create a  window child with so that you can display it in a picturebox for example
        [DllImport("avicap32.dll")]
        protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //This function enables set changes to the size, position, and Z order of a child window
        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //This function enables send the specified message to a window or windows
        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);

        //This function enable destroy the window child
        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);

        // Normal device ID
        int DeviceID = 0;
        // Handle value to preview window
        int hHwnd = 0;
        //The devices list
        ArrayList ListOfDevices = new ArrayList();

        //The picture to be displayed
        public PictureBox Container { get; set; }

        int isConnected = 0;

        public bool IsConnected { get { return isConnected != 0; } }

        // Connect to the device.
        /// <summary>
        /// This function is used to load the list of the devices
        /// </summary>
        public void Load() {
            string Name = String.Empty.PadRight(100);
            string Version = String.Empty.PadRight(100);
            bool EndOfDeviceList = false;
            short index = 0;

            // Load name of all avialable devices into the lstDevices .
            do {
                // Get Driver name and version
                EndOfDeviceList = capGetDriverDescriptionA(index, ref Name, 100, ref Version, 100);
                // If there was a device add device name to the list
                if (EndOfDeviceList) ListOfDevices.Add(Name.Trim());
                index += 1;
            }
            while (!(EndOfDeviceList == false));
        }

        /// <summary>
        /// Function used to display the output from a video capture device, you need to create
        /// a capture window.
        /// </summary>
        public void OpenConnection() {
            string DeviceIndex = Convert.ToString(DeviceID);
            IntPtr oHandle = Container.Handle;

            // Open Preview window in picturebox .
            // Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

            hHwnd = capCreateCaptureWindowA(ref DeviceIndex, WS_VISIBLE | WS_CHILD, 0, 0, 640, 480, oHandle.ToInt32(), 0);

            // Connect to device
            isConnected = SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, DeviceID, 0);
            if (isConnected != 0) {
                // Set the preview scale
                SendMessage(hHwnd, WM_CAP_SET_SCALE, -1, 0);
                // Set the preview rate in terms of milliseconds
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);

                // Start previewing the image from the camera
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, -1, 0);

                // Resize window to fit in picturebox
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, Container.Height, Container.Width, SWP_NOMOVE | SWP_NOZORDER);

            } else {
                // Error connecting to device close window
                DestroyWindow(hHwnd);
            }
        }

        //Close windows
        public void CloseConnection() {
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, DeviceID, 0);
            // close window
            DestroyWindow(hHwnd);
        }

        //Save image
        public Image GetSnapShot() {
            IDataObject data = null;
            Image oImage = null;
            // Copy image to clipboard
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

            // Get image from clipboard and convert it to a bitmap
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(System.Drawing.Bitmap))) {
                oImage = (Image)data.GetData(typeof(System.Drawing.Bitmap));
                Container.Image = oImage;
            }

            return oImage;
        }

        /// <summary>
        /// This function is used to dispose the connection to the device
        /// </summary>
        #region IDisposable Members

        public void Dispose() {
            CloseConnection();
        }
        #endregion
    }

    internal class WebCamManager {
        private Timer imageCaptureTimer = new Timer();
        private WebCamCapture webcam;
        private static WebCamManager instance;

        public static WebCamManager Instance {
            get {
                if (instance == null) instance = new WebCamManager();
                return instance;
            }
        }

        public bool IsConnected {
            get { return webcam != null && webcam.IsConnected; }
        }

        public void StartImageCapture(PictureBox pbLiveImage) {
            webcam = new WebCamCapture();
            webcam.Container = pbLiveImage;
            webcam.OpenConnection();

            // start timer
            imageCaptureTimer.Interval = 5000;
            imageCaptureTimer.Tick += new EventHandler(ImageCaptureTimer_Tick);
            imageCaptureTimer.Start();
        }

        public void StopImageCapture() {
            webcam.CloseConnection();
            imageCaptureTimer.Stop();
        }

        public void StartVideoStreaming(PictureBox videoStreamingPictureBox) {
            webcam = new WebCamCapture();
            webcam.Container = videoStreamingPictureBox;
            webcam.OpenConnection();
        }

        public void StopVideoStreaming() {
            webcam.CloseConnection();
        }

        internal List<string> GetRandomImages() {
            string imagesPath = Common.Common.LocalImagesPath + ServiceManager.Instance.TestSchedule.Id + Path.DirectorySeparatorChar;
            int maxCount = 20;
            List<string> files = new List<string>();

            if (Directory.Exists(imagesPath)) {
                string[] imageFiles = Directory.GetFiles(imagesPath, "*.jpeg");
                if (imageFiles.Length <= maxCount) {
                    files.AddRange(imageFiles);
                } else {
                    for (int i = 0; i < maxCount; i++) {
                        bool added = false;
                        while (added == false) {
                            Random rand = new Random();
                            int index = rand.Next(0, imageFiles.Length);

                            if (files.Contains(imageFiles[index]) == false) {
                                files.Add(imageFiles[index]);
                                added = true;
                            }
                        }
                    }
                }
            }

            return files;
        }

        public void ClearImages() {
            string imagesPath = Common.Common.LocalImagesPath + ServiceManager.Instance.TestSchedule.Id + Path.DirectorySeparatorChar;
            if (Directory.Exists(imagesPath)) {
                Directory.Delete(imagesPath, true);
            }
        }

        private void ImageCaptureTimer_Tick(object sender, EventArgs e) {
            // TODO: sometimes object reference not set exception is thown
            try {
                string imagesPath = Common.Common.LocalImagesPath + ServiceManager.Instance.TestSchedule.Id + Path.DirectorySeparatorChar;
                if (Directory.Exists(imagesPath) == false) Directory.CreateDirectory(imagesPath);
                string imageFilename = imagesPath + DateTime.Now.ToString("HH_mm_ss") + ".jpeg";

                Image image = webcam.GetSnapShot();
                image.Save(imageFilename, ImageFormat.Jpeg);
            } catch { }
        }
    }
    #endregion

    #region Task manager
    internal class TaskManager {
        private List<App> apps = new List<App>();
        private Timer timer;
        private static TaskManager instance;

        public event EventHandler ApplicationsListed;

        public static TaskManager Instance {
            get {
                if (instance == null) instance = new TaskManager();
                return instance;
            }
        }

        public List<App> Apps {
            get { return apps; }
        }

        private TaskManager() { }

        public void Start() {
            timer = new Timer();
            timer.Interval = 3000; // 3 seconds
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void Stop() {
            if (timer != null) timer.Stop();
        }

        private void ListApps() {
            apps.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes) {
                if (process.MainWindowHandle.ToInt32() > 0) {
                    if (IsValidApp(process) == false) {
                        try {
                            App app = new App();
                            app.Name = String.IsNullOrEmpty(process.MainWindowTitle) ? process.ProcessName : (process.MainWindowTitle + "(" + process.ProcessName + ")");
                            app.Icon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                            app.Process = process;

                            apps.Add(app);
                        } catch {
                            // Exceptions occured for applications like "regedit"
                        }
                    }
                }
            }
        }

        private bool IsValidApp(Process process) {
            bool isValid = false;

            isValid = isValid || process.ProcessName.Equals("explorer", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals(Assembly.GetExecutingAssembly().GetName().Name, StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("cmd", StringComparison.OrdinalIgnoreCase);
#if !LIVE
            isValid = isValid || process.ProcessName.Equals("airtel", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("DCSHelper", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("Skype", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("NvnTest.Candidate.vshost", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("mysqlquerybrowser", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("chrome", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("vcsexpress", StringComparison.OrdinalIgnoreCase);
            isValid = isValid || process.ProcessName.Equals("vwdexpress", StringComparison.OrdinalIgnoreCase);

#endif
            return isValid;
        }

        void timer_Tick(object sender, EventArgs e) {
            ListApps();
            if (ApplicationsListed != null) ApplicationsListed(this, null);
        }
    }

    internal class App {
        private string name;
        private Icon icon;
        private Process process;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Icon Icon {
            get { return icon; }
            set { icon = value; }
        }

        public Process Process {
            get { return process; }
            set { process = value; }
        }
    }
    #endregion

    static class Program {
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            NameValueCollection vals = GetQueryStringParameters();
            if (vals != null && vals.Count > 0) {
                switch (vals[0]) {
                    case "edujini": 
                        Common.Common.LogoType = LogoType.Eduji;
                        Globals.DemoEmail = "demo@edujini.com";
                        break;
                }
            }

            // Check whether application is running 
            string model = GetComputerModel();
            // VMWare = vmware virtual platform
            // Microsoft virtual pc = virtual machine
            if (model.Contains("vmware") || model.Contains("virtual")) {
                MessageBox.Show("You are not allowed to run NvnTest on a Virtual machine !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoginForm loginForm = new LoginForm();
            loginForm.Activate();
            if (loginForm.ShowDialog() == DialogResult.OK) {
                string message = PrerequisitesAdapter.Analyze();
                if (String.IsNullOrEmpty(message) == false) {
                    MessageBoxEx.Show("Pre-requisites", message);
                }

                Application.Run(new MainForm());
            }
        }

        private static NameValueCollection GetQueryStringParameters() {
            NameValueCollection vals = new NameValueCollection();

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) {
                ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
                if (deployment != null && deployment.ActivationUri != null) {
                    string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                    vals = System.Web.HttpUtility.ParseQueryString(queryString);
                }
            }

            return vals;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            LogException((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            LogException(e.Exception);
        }

        static void LogException(Exception exc) {
            ExceptionForm exceptionForm = new ExceptionForm();
            exceptionForm.LoadForm(exc.Message);
            if (exceptionForm.ShowDialog() == DialogResult.OK) {
                ServiceManager.Instance.SendErrorMessage(exc.Message + Environment.NewLine + exc.StackTrace);
            }
        }

        static string GetComputerModel() {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");

            foreach (ManagementObject wmi in searcher.Get()) {
                try {
                    return wmi.GetPropertyValue("Model").ToString().ToLower();
                } catch { }
            }
            return string.Empty;
        }
    }

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

    public class TestTimer {
        public event EventHandler TimeRemainingReceived; // TODO: check performance issue
        public event EventHandler TimeUpReceived;

        private uint duration = 0;
        private int timeSpent = 0;
        private Timer timer;
        private static TestTimer instance;

        private TestTimer() { }

        public static TestTimer Instance {
            get {
                if (instance == null) instance = new TestTimer();
                return instance;
            }
        }

        public void Start(uint duration) {
            if (timer != null) {
                timer.Stop();
                timer = null;
            }

            this.duration = duration;
            timeSpent = 0;

            timer = new Timer();
            timer.Interval = 1000; // 1 Second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }

        void timer_Tick(object sender, EventArgs e) {
            timeSpent += 1;
            if (timeSpent > duration * 60) {
                timer.Stop();
                if (TimeUpReceived != null) TimeUpReceived(this, null);
            } else {
                DateTime timeRemaining = new DateTime(2001, 01, 01, 0, 0, 0);
                timeRemaining = timeRemaining.AddSeconds(duration * 60 - timeSpent);
                if (TimeRemainingReceived != null) TimeRemainingReceived(timeRemaining, null);
            }
        }
    }

    internal interface INvnTestControl {
        void SaveAnswer();
    }

    internal interface IProgrammingQuestionControl {
        TestService.ProgrammingAnswerType AnswerType { get; set; }
        TestService.ProgrammingAnswerType PreviousAnswerType { get; set; }
        int WindowIndex { get; set; }
        string QuestionText { get; set; }
        string Code { get; set; }
        string Exe { get; set; }
        string ExeCode { get; set; }

        void LoadControl();
    }

    public class ServiceManager {
        private static ServiceManager instance;
        private TestService.Questions questions;
        private TestService.TestSchedule testSchedule;
        private TestService.TestInfo testInfo;
        private TestService.TestAnswers testAnswers = new TestService.TestAnswers();
        private Dictionary<TestService.QuestionBase, TestService.TestAnswerBase> testQuestionsAndAnswers = new Dictionary<TestService.QuestionBase, TestService.TestAnswerBase>();
        private string email = string.Empty;
        private string password = string.Empty;

        public static ServiceManager Instance {
            get {
                if (instance == null) instance = new ServiceManager();
                return instance;
            }
        }

        public TestService.Questions Questions {
            get { return questions; }
        }

        public TestService.TestAnswers TestAnswers {
            get { return testAnswers; }
        }

        public Dictionary<TestService.QuestionBase, TestService.TestAnswerBase> TestQuestionsAndAnswers {
            get { return testQuestionsAndAnswers; }
        }

        public string Email {
            get { return email; }
            set { email = value; }
        }

        public string Password {
            get { return password; }
            set { password = value; }
        }

        public TestService.TestSchedule TestSchedule {
            get { return testSchedule; }
        }

        public TestService.TestInfo TestInfo {
            get { return this.testInfo; }
        }

        public bool Authenticate(string email, string password) {
            testSchedule = (TestService.TestSchedule)Invoker.Invoke(WebServiceFunctionType.Authenticate, email, password);
            return testSchedule != null;
        }

        public bool LoadQuestions() {
            questions = (TestService.Questions)Invoker.Invoke(WebServiceFunctionType.GetQuestions, testSchedule.PaperId, email, password);

            if (questions != null) {
                testAnswers.ObjectiveQuestionTestAnswers = AddTestAnswers<TestService.ObjectiveQuestion, TestService.ObjectiveQuestionTestAnswer>(questions.ObjectiveQuestions, TestService.QuestionType.Objective, (new List<TestService.ObjectiveQuestionTestAnswer>()));
                testAnswers.SqlQuestionTestAnswers = AddTestAnswers<TestService.SqlQuestion, TestService.SqlQuestionTestAnswer>(questions.SQLQuestions, TestService.QuestionType.Sql, (new List<TestService.SqlQuestionTestAnswer>()));
                testAnswers.ProgrammingQuestionTestAnswers = AddTestAnswers<TestService.ProgrammingQuestion, TestService.ProgrammingQuestionTestAnswer>(questions.ProgrammingQuestions, TestService.QuestionType.Programming, (new List<TestService.ProgrammingQuestionTestAnswer>()));
                testAnswers.AutoProgrammingQuestionTestAnswers = AddTestAnswers<TestService.AutoProgrammingQuestion, TestService.AutoProgrammingQuestionTestAnswer>(questions.AutoProgrammingQuestions, TestService.QuestionType.AutoProgramming, (new List<TestService.AutoProgrammingQuestionTestAnswer>()));
                testAnswers.WebPogrammingQuestionTestAnswers = AddTestAnswers<TestService.WebProgrammingQuestion, TestService.WebProgrammingQuestionTestAnswer>(questions.WebProgrammingQuestions, TestService.QuestionType.WebProgramming, (new List<TestService.WebProgrammingQuestionTestAnswer>()));
            }

            return questions != null;
        }

        public bool UpdateTestStarted() {
            return (bool)Invoker.Invoke(WebServiceFunctionType.UpdateTestStarted, testSchedule.Id, email, password);
        }

        public bool SetCandidateDisqualified() {
            return (bool)Invoker.Invoke(WebServiceFunctionType.SetCandidateDisqualified, testSchedule, email, password);
        }

        public bool GetEmployerInfo() {
            testInfo = (TestService.TestInfo)Invoker.Invoke(WebServiceFunctionType.GetTestInfo, email, password);

            return testInfo != null;
        }

        public void SaveTestAnswersLocal() {
            testAnswers.TestId = testSchedule.Id;
            string filename = Common.Common.LocalPath + testSchedule.Id.ToString();
            LoadSave.Save(testAnswers, typeof(TestService.TestAnswers), filename);
        }

        public TestService.CompilerMessage CompileCode(string code, string sessionId, TestService.ProgrammingAnswerType answerType) {
            return (TestService.CompilerMessage)Invoker.Invoke(WebServiceFunctionType.CompileCode, code, sessionId, answerType, email, password);
        }

        public TestService.CompilerMessage CompileCode(TestService.AutoProgrammingQuestion question, string code, string sessionId, TestService.ProgrammingAnswerType answerType) {
            return (TestService.CompilerMessage)Invoker.Invoke(WebServiceFunctionType.AutoCompileCode, question, code, sessionId, answerType, email, password);
        }

        public string GetTemplateCode(TestService.AutoProgrammingQuestion question, TestService.ProgrammingAnswerType answerType) {
            return (string)Invoker.Invoke(WebServiceFunctionType.GetTemplateCode, question, answerType, email, password);
        }

        public bool SubmitTestAnswers() {
            string filename = Common.Common.LocalPath + testSchedule.Id.ToString();
            testAnswers = (TestService.TestAnswers)LoadSave.Load(typeof(TestService.TestAnswers), filename);

            return (bool)Invoker.Invoke(WebServiceFunctionType.SubmitAnswers, testAnswers, testSchedule, email, password);
        }

        public bool UpdateWebsitesVisited(string urls) {
            return (bool)Invoker.Invoke(WebServiceFunctionType.UpdateWebsitesVisited, testSchedule.Id, urls,  email, password);
        }

        public bool UpdateApplicationsIgnored(string apps) {
            return (bool)Invoker.Invoke(WebServiceFunctionType.UpdateApplicationsIgnored, testSchedule.Id, apps, email, password);
        }

        public void SendErrorMessage(string message) {
            Invoker.Invoke(WebServiceFunctionType.SendErrorMessage, message, email, password);
        }

        public void SubmitTestImages() {
            if (testSchedule.Email == Globals.DemoEmail) return;

            List<string> imageFiles = WebCamManager.Instance.GetRandomImages();
            if (imageFiles.Count > 0) {
                List<TestService.TestImage> images = new List<TestService.TestImage>();
                foreach (string imageFile in imageFiles) {
                    TestService.TestImage image = new NvnTest.Candidate.TestService.TestImage();
                    image.Name = Path.GetFileName(imageFile);
                    image.Stream = StringBinaryConverter.BinaryToString(imageFile);

                    images.Add(image);
                }
                Invoker.Invoke(WebServiceFunctionType.SubmitTestImages, images.ToArray(), testSchedule.Id, email, password);
            }
        }

        public void SaveWebPages(TestService.WebNode webNode) {
            Invoker.Invoke(WebServiceFunctionType.SaveWebPages, webNode, Common.Common.UniqueId, email, password);
        }

        private Y[] AddTestAnswers<T, Y>(T[] questions, TestService.QuestionType type, List<Y> ans) where T : TestService.QuestionBase where Y : TestService.TestAnswerBase, new() {
            foreach (T question in questions) {
                Y answer = new Y();
                answer.TestId = testSchedule.Id;
                answer.QuestionId = question.Id;
                answer.Type = type;

                testQuestionsAndAnswers.Add(question, answer);
                ans.Add(answer);
            }

            return ans.ToArray();
        }

        // Nested invoker class
        static class Invoker {
            #region Delegate declaration
            private delegate TestService.TestSchedule AuthenticateDelegate(string email, string password);
            private delegate TestService.Questions GetQuestionsDelegate(uint paperId, string email, string password);
            private delegate bool UpdateTestStartedDelegate(uint testId, string email, string password);
            private delegate bool SetCandidateDisqualifiedDelegate(TestService.TestSchedule schedule, string email, string password);
            private delegate TestService.TestInfo GetTestInfoDelegate(string email, string password);
            private delegate TestService.CompilerMessage CompileCodeDelegate(string code, string sessionId, TestService.ProgrammingAnswerType answerType, string email, string password);
            private delegate TestService.CompilerMessage AutoCompileCodeDelegate(TestService.AutoProgrammingQuestion question, string code, string sessionId, TestService.ProgrammingAnswerType answerType, string email, string password);
            private delegate string GetTemplateCodeDelegate(TestService.AutoProgrammingQuestion question, TestService.ProgrammingAnswerType answerType, string email, string password);
            private delegate bool SubmitAnswersDelegate(TestService.TestAnswers answers, TestService.TestSchedule schedule, string email, string password);
            private delegate bool UpdateWebsitesVisitedDelegate(uint testId, string urls, string email, string password);
            private delegate bool UpdateApplicationsIgnoredDelegate(uint testId, string apps, string email, string password);
            private delegate bool SubmitTestImagesDelegate(TestService.TestImage[] testImages, uint testId, string email, string password);
            private delegate void SendErrorMessageDelegate(string message, string email, string password);
            private delegate bool SaveWebPagesDelegate(TestService.WebNode webNode, string uniqueId, string email, string password);
            
            #endregion

            private static TestService.ClientService service;

            static Invoker() {
                service = new TestService.ClientService();
#if LIVE
                service.Url = "http://www.coderlabz.com/Services/ClientService.asmx";
#endif
            }

            public static object Invoke(WebServiceFunctionType functionType, params object[] args) {
                object response = null;
                Waiter.Instance.Start();

                Delegate del = null;
                try {
                    switch (functionType) {
                        case WebServiceFunctionType.Authenticate:
                            del = new AuthenticateDelegate(service.Authenticate); break;
                        case WebServiceFunctionType.GetQuestions:
                            del = new GetQuestionsDelegate(service.GetQuestions); break;
                        case WebServiceFunctionType.UpdateTestStarted:
                            del = new UpdateTestStartedDelegate(service.UpdateTestStarted); break;
                        case WebServiceFunctionType.SetCandidateDisqualified:
                            del = new SetCandidateDisqualifiedDelegate(service.SetCandidateDisqualified); break;
                        case WebServiceFunctionType.GetTestInfo:
                            del = new GetTestInfoDelegate(service.GetTestInfo); break;
                        case WebServiceFunctionType.CompileCode:
                            del = new CompileCodeDelegate(service.CompileCode); break;
                        case WebServiceFunctionType.AutoCompileCode:
                            del = new AutoCompileCodeDelegate(service.AutoCompileCode); break;
                        case WebServiceFunctionType.GetTemplateCode:
                            del = new GetTemplateCodeDelegate(service.GetTemplateCode); break;
                        case WebServiceFunctionType.SubmitAnswers:
                            del = new SubmitAnswersDelegate(service.SubmitAnswers); break;
                        case WebServiceFunctionType.UpdateWebsitesVisited:
                            del = new UpdateWebsitesVisitedDelegate(service.UpdateWebsitesVisited); break;
                        case WebServiceFunctionType.UpdateApplicationsIgnored:
                            del = new UpdateWebsitesVisitedDelegate(service.UpdateApplicationsIgnored); break;
                        case WebServiceFunctionType.SubmitTestImages:
                            del = new SubmitTestImagesDelegate(service.SubmitTestImages); break;
                        case WebServiceFunctionType.SendErrorMessage:
                            del = new SendErrorMessageDelegate(service.SendErrorMessage); break;
                        case WebServiceFunctionType.SaveWebPages:
                            del = new SaveWebPagesDelegate(service.SaveWebPages); break;
                    }

                    response = Invoke(0, del, args);
                } catch (Exception exc) {
                    string excMessage = string.Empty;
                    if (exc.InnerException != null) {
                        string[] messageParts = exc.InnerException.Message.Split("$".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (messageParts.Length > 1) {
                            excMessage = messageParts[1];
                        }
                    }
                    Waiter.Instance.Stop();
                    if (String.IsNullOrEmpty(excMessage)) {
                        ExceptionForm exceptionForm = new ExceptionForm();
                        exceptionForm.LoadForm(exc.Message);
                        if (exceptionForm.ShowDialog() == DialogResult.OK) {
                            ServiceManager.Instance.SendErrorMessage(exc.Message + Environment.NewLine + (exc.InnerException != null ? exc.InnerException.Message : "") + exc.StackTrace);
                        }
                    } else {
                        MessageBox.Show(excMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } finally {
                    Waiter.Instance.Stop();
                }

                return response;
            }

            private static object Invoke(int trial, Delegate del, params object[] args) {
                object response = null;
                try {
                    response = del.DynamicInvoke(args);
                } catch (Exception exc) {
                    if (exc.InnerException != null && exc.InnerException.GetType() == typeof(WebException) && ((System.Net.WebException)exc.InnerException).Response != null) {
                        if (((System.Net.HttpWebResponse)((System.Net.WebException)exc.InnerException).Response).StatusCode == HttpStatusCode.RequestTimeout && trial < 2) {
                            return Invoke(trial + 1, del, args); // Try to reconnect 3 times if timeout occurs
                        }
                    }

                    throw;
                }
                return response;
            }
        }
    }

    internal enum WebServiceFunctionType {
        Authenticate,
        GetQuestions,
        UpdateTestStarted,
        SetCandidateDisqualified,
        GetTestInfo,
        CompileCode,
        AutoCompileCode,
        GetTemplateCode,
        SubmitAnswers,
        UpdateWebsitesVisited,
        UpdateApplicationsIgnored,
        SubmitTestImages,
        SendErrorMessage,
        SaveWebPages
    }
}