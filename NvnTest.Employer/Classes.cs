using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Threading;
using System.Drawing;
using System.Data.SQLite;
using System.Data;
using NvnTest.Common;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Text.RegularExpressions;

namespace NvnTest.Employer {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            bool exit = false;
            LoginForm loginForm = new LoginForm();
            MainForm mainForm = new MainForm();

            while (exit == false) {
                loginForm.Activate();
                if (loginForm.ShowDialog() == DialogResult.OK) {
                    mainForm.Activate();
                    exit = mainForm.ShowDialog() != DialogResult.OK;
                } else {
                    exit = true;
                }
            }
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
    }

    internal class ServiceManager {
        private static ServiceManager instance;
        private TestService.User user = null;
        private TestService.UserInfo userInfo = null;

        // <Id, Paper>
        private Dictionary<uint, TestService.Paper> papers = new Dictionary<uint, TestService.Paper>();
        // <Id, AutoPaper>
        private Dictionary<uint, TestService.AutoPaper> autoPapers = new Dictionary<uint, TestService.AutoPaper>();
        // <Id, Test schedule>
        private Dictionary<uint, TestService.TestSchedule> schedules = new Dictionary<uint, TestService.TestSchedule>();

        // Question categories
        private Dictionary<uint, TestService.QuestionCategory> questionCategories = new Dictionary<uint, TestService.QuestionCategory>();

        // Question levels
        private Dictionary<uint, TestService.QuestionLevel> questionLevels = new Dictionary<uint, TestService.QuestionLevel>();

        private ServiceManager() { }

        public static ServiceManager Instance {
            get {
                if (instance == null) instance = new ServiceManager();
                return instance;
            }
        }

        public void LoadData() { }

        public TestService.UserInfo UserInfo {
            get { return userInfo; }
        }

        public Dictionary<uint, TestService.Paper> Papers {
            get { return papers; }
        }

        public Dictionary<uint, TestService.AutoPaper> AutoPapers {
            get { return autoPapers; }
        }

        public Dictionary<uint, TestService.TestSchedule> Schedules {
            get { return schedules; }
        }

        public Dictionary<uint, TestService.QuestionCategory> QuestionCategories {
            get { return questionCategories; }
        }

        public Dictionary<uint, TestService.QuestionLevel> QuestionLevels {
            get { return questionLevels; }
        }

        #region Authenticate / Update user details / User Extensions
        public object Authenticate(string email, string password) {
            object response = Invoker.Invoke(WebServiceFunctionType.Authenticate, email, Encrypter.Encrypt(password));

            userInfo = (TestService.UserInfo)response;
            if (userInfo != null) {
                user = new TestService.User();
                user.Id = userInfo.Id;
                user.Email = userInfo.Email;
                user.Password = Encrypter.Encrypt(userInfo.Password);
            }
            return response;
        }

        public object ForgotPassword(string email) {
            return Invoker.Invoke(WebServiceFunctionType.ForgotPassword, email);
        }

        public object UpdateUserInfo(TestService.UserInfo userInfo) {
            return Invoker.Invoke(WebServiceFunctionType.UpdateUserInfo, userInfo);
        }

        public object CheckUserExists(string email) {
            return Invoker.Invoke(WebServiceFunctionType.CheckUserExists, email);
        }

        public object VarifyCode(string email, string code) {
            return Invoker.Invoke(WebServiceFunctionType.VarifyCode, email, code);
        }

        public object CreateNewCode(string email) {
            return Invoker.Invoke(WebServiceFunctionType.CreateNewCode, email);
        }

        public object GetUserExtensions() {
            return Invoker.Invoke(WebServiceFunctionType.GetUserExtensions, user);
        }

        public bool UpdateUserExtension(TestService.UserExtension userExtension) {
            return (bool)Invoker.Invoke(WebServiceFunctionType.UpdateUserExtension, userExtension, user);
        }

        public bool RemoveUserExtension(TestService.UserExtension userExtension) {
            return (bool)Invoker.Invoke(WebServiceFunctionType.RemoveUserExtension, userExtension, user);
        }

        #endregion

        #region Load / Update / Remove question  categories
        public object LoadQuestionCategories() {
            questionCategories.Clear();

            object response = Invoker.Invoke(WebServiceFunctionType.GetQuestionCategories, user);
            if (response != null) {
                TestService.QuestionCategory[] categories = (TestService.QuestionCategory[])response;
                foreach (TestService.QuestionCategory questionCategory in categories) {
                    questionCategories.Add(questionCategory.Id, questionCategory);
                }
            }
            return response;
        }

        public object UpdateQuestionCategory(TestService.QuestionCategory questionCategory) {
            return Invoker.Invoke(WebServiceFunctionType.UpdateQuestionCategory, questionCategory, user);
        }

        public object RemoveQuestionCategory(TestService.QuestionCategory questionCategory) {
            return Invoker.Invoke(WebServiceFunctionType.RemoveQuestionCategory, questionCategory, user);
        }
        #endregion

        #region Load / Update / Remove question levels
        public object LoadQuestionLevels() {
            questionLevels.Clear();

            object response = Invoker.Invoke(WebServiceFunctionType.GetQuestionLevels, user);
            if (response != null) {
                TestService.QuestionLevel[] levels = (TestService.QuestionLevel[])response;
                foreach (TestService.QuestionLevel questionLevel in levels) {
                    questionLevels.Add(questionLevel.Id, questionLevel);
                }
            }
            return response;
        }

        public object UpdateQuestionLevel(TestService.QuestionLevel questionLevel) {
            return Invoker.Invoke(WebServiceFunctionType.UpdateQuestionLevel, questionLevel, user);
        }

        public object RemoveQuestionLevel(TestService.QuestionLevel questionLevel) {
            return Invoker.Invoke(WebServiceFunctionType.RemoveQuestionLevel, questionLevel, user);
        }
        #endregion

        #region Load / Update / Remove Questions
        public object GetNumberOfQuestionPages() {
            return Invoker.Invoke(WebServiceFunctionType.GetNumberOfQuestionPages, user);
        }

        public object GetNumberOfQuestionPages(TestService.QuestionType questionType) {
            return Invoker.Invoke(WebServiceFunctionType.GetNumberOfQuestionPagesByQuestionType, questionType, user);
        }
        public object LoadQuestions(uint currentIndex) {
            return Invoker.Invoke(WebServiceFunctionType.GetQuestions, currentIndex, user);
        }

        public object LoadQuestions(TestService.QuestionType questionType, uint currentIndex) {
            return Invoker.Invoke(WebServiceFunctionType.GetQuestionsByType, questionType, currentIndex, user);
        }

        public object LoadQuestion(TestService.QuestionType questionType, uint id) {
            object response = null;

            switch (questionType) {
                case TestService.QuestionType.Objective:
                    response = Invoker.Invoke(WebServiceFunctionType.LoadObjectiveQuestion, id, user); break;
                case TestService.QuestionType.Sql:
                    response = Invoker.Invoke(WebServiceFunctionType.LoadSqlQuestion, id, user); break;
                case TestService.QuestionType.Programming:
                    response = Invoker.Invoke(WebServiceFunctionType.LoadProgrammingQuestion, id, user); break;
                case TestService.QuestionType.AutoProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.LoadAutoProgrammingQuestion, id, user); break;
                case TestService.QuestionType.WebProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.LoadWebProgrammingQuestion, id, user); break;
            }

            return response;
        }

        public object UpdateQuestion(TestService.QuestionBase question) {
            object response = null;

            switch (question.Type) {
                case TestService.QuestionType.Objective:
                    response = Invoker.Invoke(WebServiceFunctionType.UpdateObjectiveQuestion, question, user); break;
                case TestService.QuestionType.Sql:
                    response = Invoker.Invoke(WebServiceFunctionType.UpdateSqlQuestion, question, user); break;
                case TestService.QuestionType.Programming:
                    response = Invoker.Invoke(WebServiceFunctionType.UpdateProgrammingQuestion, question, user); break;
                case TestService.QuestionType.AutoProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.UpdateAutoProgrammingQuestion, question, user); break;
                case TestService.QuestionType.WebProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.UpdateWebProgrammingQuestion, question, user); break;
            }

            return response;
        }

        public object RemoveQuestion(TestService.QuestionBase question) {
            object response = null;

            switch (question.Type) {
                case TestService.QuestionType.Objective:
                    response = Invoker.Invoke(WebServiceFunctionType.RemoveObjectiveQuestion, question, user); break;
                case TestService.QuestionType.Sql:
                    response = Invoker.Invoke(WebServiceFunctionType.RemoveSqlQuestion, question, user); break;
                case TestService.QuestionType.Programming:
                    response = Invoker.Invoke(WebServiceFunctionType.RemoveProgrammingQuestion, question, user); break;
                case TestService.QuestionType.AutoProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.RemoveAutoProgrammingQuestion, question, user); break;
                case TestService.QuestionType.WebProgramming:
                    response = Invoker.Invoke(WebServiceFunctionType.RemoveWebProgrammingQuestion, question, user); break;
            }

            return response;
        }
        #endregion

        #region Load / Update / Remove papers
        public object LoadPapers() {
            object response = Invoker.Invoke(WebServiceFunctionType.GetPapers, user);
            // Add papers to dictionary
            this.papers.Clear();
            if (response != null) {
                TestService.Paper[] papers = (TestService.Paper[])response;
                foreach (TestService.Paper paper in papers) {
                    this.papers.Add(paper.Id, paper);
                }
            }
            return response;
        }

        public object UpdatePaper(TestService.Paper paper) {
            return Invoker.Invoke(WebServiceFunctionType.UpdatePaper, paper, user);
        }

        public object RemovePaper(TestService.Paper paper) {
            return Invoker.Invoke(WebServiceFunctionType.RemovePaper, paper, user);
        }
        #endregion

        #region Load / Update / Remove auto papers
        public object LoadAutoPapers() {
            object response = Invoker.Invoke(WebServiceFunctionType.GetAutoPapers, user);
            // Add papers to dictionary
            this.autoPapers.Clear();
            if (response != null) {
                TestService.AutoPaper[] papers = (TestService.AutoPaper[])response;
                foreach (TestService.AutoPaper paper in papers) {
                    this.autoPapers.Add(paper.Id, paper);
                }
            }
            return response;
        }

        public object UpdateAutoPaper(TestService.AutoPaper paper) {
            return Invoker.Invoke(WebServiceFunctionType.UpdateAutoPaper, paper, user);
        }

        public object RemoveAutoPaper(TestService.AutoPaper paper) {
            return Invoker.Invoke(WebServiceFunctionType.RemoveAutoPaper, paper, user);
        }

        public object GetQuestionsCountByCategoryLevelType(TestService.QuestionType type, uint count, uint category, uint difficultyLevel) {
            return Invoker.Invoke(WebServiceFunctionType.GetQuestionsCountByCategoryLevelType, type, count, category, difficultyLevel, user);
        }

        public object CreatePaperByAutoPaper(TestService.AutoPaper paper) {
            return Invoker.Invoke(WebServiceFunctionType.CreatePaperByAutoPaper, paper, user);
        }
        #endregion

        #region Load / Update / Remove test schedules
        public object GetNumberOfTestSchedulePages() {
            return Invoker.Invoke(WebServiceFunctionType.GetNumberOfTestSchedulePages, user);
        }

        public void LoadTestSchedules(uint index) {
            object response = Invoker.Invoke(WebServiceFunctionType.GetTestSchedules, user, index);
            // Add test schedules to dictionary
            this.schedules.Clear();
            if (response != null) {
                TestService.TestSchedule[] schedules = (TestService.TestSchedule[])response;
                foreach (TestService.TestSchedule schedule in schedules) {
                    this.schedules.Add(schedule.Id, schedule);
                }
            }
        }

        public void LoadTestSchedules(List<string> filters, uint index) {
            object response = Invoker.Invoke(WebServiceFunctionType.GetTestSchedulesByFilters, user, filters.ToArray(), index);
            // Add test schedules to dictionary
            this.schedules.Clear();
            if (response != null) {
                TestService.TestSchedule[] schedules = (TestService.TestSchedule[])response;
                foreach (TestService.TestSchedule schedule in schedules) {
                    this.schedules.Add(schedule.Id, schedule);
                }
            }
        }

        public object UpdateTestSchedule(TestService.TestSchedule testSchedule) {
            return Invoker.Invoke(WebServiceFunctionType.UpdateTestSchedule, testSchedule, user);
        }

        public object RemoveTestSchedule(TestService.TestSchedule testSchedule) {
            return Invoker.Invoke(WebServiceFunctionType.RemoveTestSchedule, testSchedule, user);
        }

        public object LoadTestAnswersRemote(uint testId) {
            return Invoker.Invoke(WebServiceFunctionType.GetTestAnswers, testId, user);
        }

        public object AutoCompileCode(TestService.AutoProgrammingQuestion question, string code, string sessionId, TestService.ProgrammingAnswerType answerType) {
            return Invoker.Invoke(WebServiceFunctionType.AutoCompileCode, question, code, sessionId, answerType, user);
        }

        public object GetWebsitesVisited(uint testId) {
            return Invoker.Invoke(WebServiceFunctionType.GetWebsitesVisited, testId, user);
        }

        public object GetApplicationsIgnored(uint testId) {
            return Invoker.Invoke(WebServiceFunctionType.GetApplicationsIgnored, testId, user);
        }

        public object GetTestImages(uint testId) {
            return Invoker.Invoke(WebServiceFunctionType.GetTestImages, testId, user);
        }

        public object GetTestsPurchased() {
            return Invoker.Invoke(WebServiceFunctionType.GetTestsPurchased, user);
        }
        #endregion

        public void SendErrorMessage(string message) {
            Invoker.Invoke(WebServiceFunctionType.SendErrorMessage, message, user);
        }

        public void SaveWebPages(TestService.WebNode webNode) {
            Invoker.Invoke(WebServiceFunctionType.SaveWebPages, webNode, Common.Common.UniqueId , user);
        }

        // Nested class
        static class Invoker {
            #region Delegate declaration
            private delegate TestService.UserInfo AuthenticateDelegate(string email, string password);
            private delegate bool ForgotPasswordDelegate(string email);
            private delegate TestService.UserInfo UpdateUserInfoDelegate(TestService.UserInfo userInfo);
            private delegate bool CheckUserExistsDelegate(string email);
            private delegate bool VarifyCodeDelegate(string email, string code);
            private delegate bool CreateNewCodeDelegate(string email);
            private delegate TestService.UserExtension[] GetUserExtensionsDelegate(TestService.User user);
            private delegate bool UpdateUserExtensionDelegate(TestService.UserExtension userExtension, TestService.User user);
            private delegate bool RemoveUserExtensionDelegate(TestService.UserExtension userExtension, TestService.User user);
            // Question categories
            private delegate TestService.QuestionCategory[] GetQuestionCategoriesDelegate(TestService.User user);
            private delegate TestService.QuestionCategory UpdateQuestionCategoryDelegate(TestService.QuestionCategory questionCategory, TestService.User user);
            private delegate TestService.QuestionCategory RemoveQuestionCategoryDelegate(TestService.QuestionCategory questionCategory, TestService.User user);
            // Question levels
            private delegate TestService.QuestionLevel[] GetQuestionLevelsDelegate(TestService.User user);
            private delegate TestService.QuestionLevel UpdateQuestionLevelDelegate(TestService.QuestionLevel questionLevel, TestService.User user);
            private delegate TestService.QuestionLevel RemoveQuestionLevelDelegate(TestService.QuestionLevel questionLevel, TestService.User user);
            // Questions
            private delegate uint GetNumberOfQuestionPagesDelegate(TestService.User user);
            private delegate uint GetNumberOfQuestionPageByQuestionTypeDelegate(TestService.QuestionType questionType, TestService.User user);
            private delegate TestService.Questions GetQuestionsDelegate(uint index, TestService.User user);
            private delegate TestService.Questions GetQuestionsByTypeDelegate(TestService.QuestionType questionType, uint index, TestService.User user);

            private delegate TestService.ObjectiveQuestion LoadObjectiveQuestionDelegate(uint id, TestService.User user);
            private delegate TestService.SqlQuestion LoadSqlQuestionDelegate(uint id, TestService.User user);
            private delegate TestService.ProgrammingQuestion LoadProgrammingQuestionDelegate(uint id, TestService.User user);
            private delegate TestService.AutoProgrammingQuestion LoadAutoProgrammingQuestionDelegate(uint id, TestService.User user);
            private delegate TestService.WebProgrammingQuestion LoadWebProgrammingQuestionDelegate(uint id, TestService.User user);

            private delegate TestService.ObjectiveQuestion UpdateObjectiveQuestionDelegate(TestService.ObjectiveQuestion question, TestService.User user);
            private delegate TestService.SqlQuestion UpdateSqlQuestionDelegate(TestService.SqlQuestion question, TestService.User user);
            private delegate TestService.ProgrammingQuestion UpdateProgrammingQuestionDelegate(TestService.ProgrammingQuestion question, TestService.User user);
            private delegate TestService.AutoProgrammingQuestion UpdateAutoProgrammingQuestionDelegate(TestService.AutoProgrammingQuestion question, TestService.User user);
            private delegate TestService.WebProgrammingQuestion UpdateWebProgrammingQuestionDelegate(TestService.WebProgrammingQuestion question, TestService.User user);
            
            private delegate TestService.ObjectiveQuestion RemoveObjectiveQuestionDelegate(TestService.ObjectiveQuestion question, TestService.User user);
            private delegate TestService.SqlQuestion RemoveSqlQuestionDelegate(TestService.SqlQuestion question, TestService.User user);
            private delegate TestService.ProgrammingQuestion RemoveProgrammingQuestionDelegate(TestService.ProgrammingQuestion question, TestService.User user);
            private delegate TestService.AutoProgrammingQuestion RemoveAutoProgrammingQuestionDelegate(TestService.AutoProgrammingQuestion question, TestService.User user);
            private delegate TestService.WebProgrammingQuestion RemoveWebProgrammingQuestionDelegate(TestService.WebProgrammingQuestion question, TestService.User user);
            // papers
            private delegate TestService.Paper[] GetPapersDelegate(TestService.User user);
            private delegate TestService.Paper UpdatePaperDelegate(TestService.Paper paper, TestService.User user);
            private delegate uint RemovePaperDelegate(TestService.Paper paper, TestService.User user);
            // auto papers
            private delegate TestService.AutoPaper[] GetAutoPapersDelegate(TestService.User user);
            private delegate TestService.AutoPaper UpdateAutoPaperDelegate(TestService.AutoPaper paper, TestService.User user);
            private delegate TestService.AutoPaper RemoveAutoPaperDelegate(TestService.AutoPaper paper, TestService.User user);
            private delegate long GetQuestionsCountByCategoryLevelTypeDelegate(TestService.QuestionType type, uint count, uint category, uint difficultyLevel, TestService.User user);
            private delegate TestService.Paper CreatePaperByAutoPaperDelegate(TestService.AutoPaper paper, TestService.User user);
            // test schedules
            private delegate uint GetNumberOfTestSchedulePagesDelegate(TestService.User user);
            private delegate TestService.TestSchedule[] GetTestSchedulesDelegate(TestService.User user, uint index);
            private delegate TestService.TestSchedule[] GetTestSchedulesByFiltersDelegate(TestService.User user, string[] filters, uint index);
            private delegate TestService.TestSchedule UpdateTestScheduleDelegate(TestService.TestSchedule testSchedule, TestService.User user);
            private delegate uint RemoveTestScheduleDelegate(TestService.TestSchedule testSchedule, TestService.User user);
            private delegate TestService.TestAnswers GetTestAnswersDelegate(uint testId, TestService.User user);
            private delegate TestService.CompilerMessage AutoCompileCodeDelegate(TestService.AutoProgrammingQuestion question, string code, string sessionId, TestService.ProgrammingAnswerType answerType, TestService.User user);
            private delegate string GetWebsitesVisitedDelegate(uint testId, TestService.User user);
            private delegate string GetApplicationsIgnoredDelegate(uint testId, TestService.User user);
            private delegate TestService.TestImage[] GetTestImagesDelegate(uint testId, TestService.User user);
            private delegate uint GetTestsPurchasedDelegate(TestService.User user);
            // Error message
            private delegate void SendErrorMessageDelegate(string message, TestService.User user);
            // Save Web pages
            private delegate bool SaveWebPagesDelegate(TestService.WebNode webNode, string uniqueId, TestService.User user);
            #endregion

            private static TestService.TestService service;

            static Invoker() {
                service = new TestService.TestService();
#if LIVE
                service.Url = "http://www.coderlabz.com/Services/TestService.asmx";
#endif
            }

            public static object Invoke(WebServiceFunctionType functionType, params object[] args) {
                object response = null;
                Waiter.Instance.Start();

                Delegate del = null;
                try {
                    switch (functionType) {
                        // user management
                        case WebServiceFunctionType.Authenticate:
                            del = new AuthenticateDelegate(service.Authenticate); break;
                        case WebServiceFunctionType.ForgotPassword:
                            del = new ForgotPasswordDelegate(service.ForgotPassword); break;
                        case WebServiceFunctionType.UpdateUserInfo:
                            del = new UpdateUserInfoDelegate(service.UpdateUserInfo); break;
                        case WebServiceFunctionType.CheckUserExists:
                            del = new CheckUserExistsDelegate(service.CheckUserExists); break;
                        case WebServiceFunctionType.VarifyCode:
                            del = new VarifyCodeDelegate(service.VarifyCode); break;
                        case WebServiceFunctionType.CreateNewCode:
                            del = new CreateNewCodeDelegate(service.CreateNewCode); break;
                        case WebServiceFunctionType.GetUserExtensions:
                            del = new GetUserExtensionsDelegate(service.GetUserExtensions); break;
                        case WebServiceFunctionType.UpdateUserExtension:
                            del = new UpdateUserExtensionDelegate(service.UpdateUserExtension); break;
                        case WebServiceFunctionType.RemoveUserExtension:
                            del = new RemoveUserExtensionDelegate(service.RemoveUserExtension); break;
                        // Categories
                        case WebServiceFunctionType.GetQuestionCategories:
                            del = new GetQuestionCategoriesDelegate(service.GetQuestionCategories); break;
                        case WebServiceFunctionType.UpdateQuestionCategory:
                            del = new UpdateQuestionCategoryDelegate(service.UpdateQuestionCategory); break;
                        case WebServiceFunctionType.RemoveQuestionCategory:
                            del = new RemoveQuestionCategoryDelegate(service.RemoveQuestionCategory); break;
                        // Level
                        case WebServiceFunctionType.GetQuestionLevels:
                            del = new GetQuestionLevelsDelegate(service.GetQuestionLevels); break;
                        case WebServiceFunctionType.UpdateQuestionLevel:
                            del = new UpdateQuestionLevelDelegate(service.UpdateQuestionLevel); break;
                        case WebServiceFunctionType.RemoveQuestionLevel:
                            del = new RemoveQuestionLevelDelegate(service.RemoveQuestionLevel); break;
                        // Questions
                        case WebServiceFunctionType.GetNumberOfQuestionPages:
                            del = new GetNumberOfQuestionPagesDelegate(service.GetNumberOfQuestionPages); break;
                        case WebServiceFunctionType.GetNumberOfQuestionPagesByQuestionType:
                            del = new GetNumberOfQuestionPageByQuestionTypeDelegate(service.GetNumberOfQuestionPageByQuestionType); break;
                        case WebServiceFunctionType.GetQuestions:
                            del = new GetQuestionsDelegate(service.GetQuestions); break;
                        case WebServiceFunctionType.GetQuestionsByType:
                            del = new GetQuestionsByTypeDelegate(service.GetQuestionsByQuestionType); break;
                        // load questions
                        case WebServiceFunctionType.LoadObjectiveQuestion:
                            del = new LoadObjectiveQuestionDelegate(service.LoadObjectiveQuestion); break;
                        case WebServiceFunctionType.LoadSqlQuestion:
                            del = new LoadSqlQuestionDelegate(service.LoadSqlQuestion); break;
                        case WebServiceFunctionType.LoadProgrammingQuestion:
                            del = new LoadProgrammingQuestionDelegate(service.LoadProgrammingQuestion); break;
                        case WebServiceFunctionType.LoadAutoProgrammingQuestion:
                            del = new LoadAutoProgrammingQuestionDelegate(service.LoadAutoProgrammingQuestion); break;
                        case WebServiceFunctionType.LoadWebProgrammingQuestion:
                            del = new LoadWebProgrammingQuestionDelegate(service.LoadWebProgrammingQuestion); break;
                        // update questions
                        case WebServiceFunctionType.UpdateObjectiveQuestion:
                            del = new UpdateObjectiveQuestionDelegate(service.UpdateObjectiveQuestion); break;
                        case WebServiceFunctionType.UpdateSqlQuestion:
                            del = new UpdateSqlQuestionDelegate(service.UpdateSqlQuestion); break;
                        case WebServiceFunctionType.UpdateProgrammingQuestion:
                            del = new UpdateProgrammingQuestionDelegate(service.UpdateProgrammingQuestion); break;
                        case WebServiceFunctionType.UpdateAutoProgrammingQuestion:
                            del = new UpdateAutoProgrammingQuestionDelegate(service.UpdateAutoProgrammingQuestion); break;
                        case WebServiceFunctionType.UpdateWebProgrammingQuestion:
                            del = new UpdateWebProgrammingQuestionDelegate(service.UpdateWebProgrammingQuestion); break;
                        // remove questions
                        case WebServiceFunctionType.RemoveObjectiveQuestion:
                            del = new RemoveObjectiveQuestionDelegate(service.RemoveObjectiveQuestion); break;
                        case WebServiceFunctionType.RemoveSqlQuestion:
                            del = new RemoveSqlQuestionDelegate(service.RemoveSqlQuestion); break;
                        case WebServiceFunctionType.RemoveProgrammingQuestion:
                            del = new RemoveProgrammingQuestionDelegate(service.RemoveProgrammingQuestion); break;
                        case WebServiceFunctionType.RemoveAutoProgrammingQuestion:
                            del = new RemoveAutoProgrammingQuestionDelegate(service.RemoveAutoProgrammingQuestion); break;
                        case WebServiceFunctionType.RemoveWebProgrammingQuestion:
                            del = new RemoveWebProgrammingQuestionDelegate(service.RemoveWebProgrammingQuestion); break;
                        // papers
                        case WebServiceFunctionType.GetPapers:
                            del = new GetPapersDelegate(service.GetPapers); break;
                        case WebServiceFunctionType.UpdatePaper:
                            del = new UpdatePaperDelegate(service.UpdatePaper); break;
                        case WebServiceFunctionType.RemovePaper:
                            del = new RemovePaperDelegate(service.RemovePaper); break;
                        // auto papers
                        case WebServiceFunctionType.GetAutoPapers:
                            del = new GetAutoPapersDelegate(service.GetAutoPapers); break;
                        case WebServiceFunctionType.UpdateAutoPaper:
                            del = new UpdateAutoPaperDelegate(service.UpdateAutoPaper); break;
                        case WebServiceFunctionType.RemoveAutoPaper:
                            del = new RemoveAutoPaperDelegate(service.RemoveAutoPaper); break;
                        case WebServiceFunctionType.GetQuestionsCountByCategoryLevelType:
                            del = new GetQuestionsCountByCategoryLevelTypeDelegate(service.GetQuestionsCountByCategoryLevelType); break;
                        case WebServiceFunctionType.CreatePaperByAutoPaper:
                            del = new CreatePaperByAutoPaperDelegate(service.CreatePaperByAutoPaper); break;
                        // test schedules
                        case WebServiceFunctionType.GetNumberOfTestSchedulePages:
                            del = new GetNumberOfTestSchedulePagesDelegate(service.GetNumberOfTestSchedulePages); break;
                        case WebServiceFunctionType.GetTestSchedules:
                            del = new GetTestSchedulesDelegate(service.GetTestSchedules); break;
                        case WebServiceFunctionType.GetTestSchedulesByFilters:
                            del = new GetTestSchedulesByFiltersDelegate(service.GetTestSchedulesByFilters); break;
                        case WebServiceFunctionType.UpdateTestSchedule:
                            del = new UpdateTestScheduleDelegate(service.UpdateTestSchedule); break;
                        case WebServiceFunctionType.RemoveTestSchedule:
                            del = new RemoveTestScheduleDelegate(service.RemoveTestSchedule); break;
                        case WebServiceFunctionType.GetTestAnswers:
                            del = new GetTestAnswersDelegate(service.GetTestAnswers); break;
                        case WebServiceFunctionType.AutoCompileCode:
                            del = new AutoCompileCodeDelegate(service.AutoCompileCode); break;
                        case WebServiceFunctionType.GetWebsitesVisited:
                            del = new GetWebsitesVisitedDelegate(service.GetWebsitesVisited); break;
                        case WebServiceFunctionType.GetApplicationsIgnored:
                            del = new GetApplicationsIgnoredDelegate(service.GetApplicationsIgnored); break;
                        case WebServiceFunctionType.GetTestImages:
                            del = new GetTestImagesDelegate(service.GetTestImages); break;
                        case WebServiceFunctionType.GetTestsPurchased:
                            del = new GetTestsPurchasedDelegate(service.GetTestsPurchased); break;
                        // Send error message
                        case WebServiceFunctionType.SendErrorMessage:
                            del = new SendErrorMessageDelegate(service.SendErrorMessage); break;
                        // Save web pages
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
        ForgotPassword,
        UpdateUserInfo,
        CheckUserExists,
        VarifyCode,
        CreateNewCode,
        GetUserExtensions,
        UpdateUserExtension,
        RemoveUserExtension,
        GetQuestionCategories,
        UpdateQuestionCategory,
        RemoveQuestionCategory,
        GetQuestionLevels,
        UpdateQuestionLevel,
        RemoveQuestionLevel,
        GetNumberOfQuestionPages,
        GetNumberOfQuestionPagesByQuestionType,
        GetQuestions,
        GetQuestionsByType,
        LoadObjectiveQuestion,
        LoadSqlQuestion,
        LoadProgrammingQuestion,
        LoadAutoProgrammingQuestion,
        LoadWebProgrammingQuestion,
        UpdateObjectiveQuestion,
        UpdateSqlQuestion,
        UpdateProgrammingQuestion,
        UpdateAutoProgrammingQuestion,
        UpdateWebProgrammingQuestion,
        RemoveObjectiveQuestion,
        RemoveSqlQuestion,
        RemoveProgrammingQuestion,
        RemoveAutoProgrammingQuestion,
        RemoveWebProgrammingQuestion,
        GetPapers,
        UpdatePaper,
        RemovePaper,
        GetAutoPapers,
        UpdateAutoPaper,
        RemoveAutoPaper,
        GetQuestionsCountByCategoryLevelType,
        CreatePaperByAutoPaper,
        GetNumberOfTestSchedulePages,
        GetTestSchedules,
        GetTestSchedulesByFilters,
        UpdateTestSchedule,
        RemoveTestSchedule,
        GetTestAnswers,
        AutoCompileCode,
        GetWebsitesVisited,
        GetApplicationsIgnored,
        GetTestImages,
        GetTestsPurchased,
        SendErrorMessage,
        SaveWebPages
    }

    public static class ObjectCopier {
        public static T Clone<T>(T source) {
            if (!typeof(T).IsSerializable) {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null)) {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream) {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    public class InputValidator {
        public static bool ValidEmailFormat(string email) {
            bool isValid = Regex.IsMatch(email,
              @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (isValid == false) {
                MessageBox.Show(String.Format("Email: {0} is not in valid format. Please enter valid email address", email), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        public static bool CompareValues(string label, string val1, string val2) {
            bool isValid = val1.Equals(val2, StringComparison.OrdinalIgnoreCase);
            if (isValid == false) {
                MessageBox.Show(String.Format("{0} {1} and {2} does not match.", label, val1, val2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        public static bool ValueNotEmpty(string label, string val) {
            bool isValid = String.IsNullOrEmpty(val) == false;
            if (isValid == false) {
                MessageBox.Show(String.Format("{0} is empty. Please enter a valid value.", label), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        public static bool ValidStringLength(string label, string str, int length) {
            bool isValid = str.Length <= length;
            if (isValid == false) {
                MessageBox.Show(String.Format("{0} length is {1} which more than expected length: {2}", label, str.Length, length), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        public static bool ValidRange(string name, int min, int max, int val) {
            bool isValid = val >= min && val <= max;
            if (isValid == false) {
                MessageBox.Show(String.Format("{0}: {1} is invalid. Valid value range is - Min : {2}. Max : {3}", name, val, min, max), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }
    }
}