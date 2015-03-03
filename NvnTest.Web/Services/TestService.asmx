<%@ WebService Language="C#" Class="TestService" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://www.coderlabz.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// [System.Web.Script.Services.ScriptService]
public class TestService : System.Web.Services.WebService
{
    AdminManager m = new AdminManager();

    public TestService()
    {
        //InitializeComponent(); 
    }

    #region Manage user
    [WebMethod]
    public UserInfo Authenticate(string email, string password)
    {
        return m.Authenticate(email, password);
    }

    // create and update user info
    [WebMethod]
    public UserInfo UpdateUserInfo(UserInfo userInfo)
    {
        return m.UpdateUserInfo(userInfo);
    }

    [WebMethod]
    public bool ForgotPassword(string email)
    {
        return m.ForgotPassword(email);
    }

    [WebMethod]
    public bool CheckUserExists(string email)
    {
        return m.CheckUserExists(email);
    }

    [WebMethod]
    public bool VarifyCode(string email, string code)
    {
        return m.VarifyCode(email, code);
    }

    [WebMethod]
    public bool CreateNewCode(string email)
    {
        return m.CreateNewCode(email);
    }

    [WebMethod]
    public List<UserExtension> GetUserExtensions(User user)
    {
        return m.GetUserExtensions(user);
    }

    [WebMethod]
    public bool UpdateUserExtension(UserExtension userExtension, User user)
    {
        return m.UpdateUserExtension(userExtension, user);
    }

    [WebMethod]
    public bool RemoveUserExtension(UserExtension userExtension, User user)
    {
        return m.RemoveUserExtension(userExtension, user);
    }

    #endregion

    #region Get / Update / Remove categories

    [WebMethod]
    public List<QuestionCategory> GetQuestionCategories(User user)
    {
        return m.GetQuestionCategories(user);
    }

    [WebMethod]
    public QuestionCategory UpdateQuestionCategory(QuestionCategory category, User user)
    {
        return m.UpdateQuestionCategory(category, user);
    }

    [WebMethod]
    public QuestionCategory RemoveQuestionCategory(QuestionCategory category, User user)
    {
        return m.RemoveQuestionCategory(category, user);
    }
    
    #endregion

    #region Get / Update / Remove difficulty level

    [WebMethod]
    public List<QuestionLevel> GetQuestionLevels(User user)
    {
        return m.GetQuestionLevels(user);
    }

    [WebMethod]
    public QuestionLevel UpdateQuestionLevel(QuestionLevel questionLevel, User user)
    {
        return m.UpdateQuestionLevel(questionLevel, user);
    }

    [WebMethod]
    public QuestionLevel RemoveQuestionLevel(QuestionLevel questionLevel, User user)
    {
        return m.RemoveQuestionLevel(questionLevel, user);
    }

    #endregion

    #region Get / Update / Remove questions
    [WebMethod]
    public uint GetNumberOfQuestionPages(User user)
    {
        return m.GetNumberOfQuestionPages(user);
    }

    [WebMethod]
    public uint GetNumberOfQuestionPageByQuestionType(QuestionType questionType, User user)
    {
        return m.GetNumberOfQuestionPagesByQuestionType(questionType, user);
    }
    
    [WebMethod]
    public Questions GetQuestions(uint index, User user)
    {
        return m.GetQuestions(index, user);
    }

    [WebMethod]
    public Questions GetQuestionsByQuestionType(QuestionType questionType, uint index, User user)
    {
        return m.GetQuestions(questionType, index, user);
    }

    [WebMethod]
    public ObjectiveQuestion LoadObjectiveQuestion(uint id, User user)
    {
        return m.LoadObjectiveQuestion(id, user);
    }
    
    [WebMethod]
    public ObjectiveQuestion UpdateObjectiveQuestion(ObjectiveQuestion objectiveQuestion, User user)
    {
        return m.UpdateObjectiveQuestion(objectiveQuestion, user);
    }

    [WebMethod]
    public ObjectiveQuestion RemoveObjectiveQuestion(ObjectiveQuestion objectiveQuestion, User user)
    {
        return m.RemoveObjectiveQuestion(objectiveQuestion, user);
    }

    [WebMethod]
    public SqlQuestion LoadSqlQuestion(uint id, User user)
    {
        return m.LoadSqlQuestion(id, user);
    }

    [WebMethod]
    public SqlQuestion UpdateSqlQuestion(SqlQuestion sqlQuestion, User user)
    {
        return m.UpdateSqlQuestion(sqlQuestion, user);
    }

    [WebMethod]
    public SqlQuestion RemoveSqlQuestion(SqlQuestion sqlQuestion, User user)
    {
        return m.RemoveSqlQuestion(sqlQuestion, user);
    }

    [WebMethod]
    public ProgrammingQuestion LoadProgrammingQuestion(uint id, User user)
    {
        return m.LoadProgrammingQuestion(id, user);
    }
    
    [WebMethod]
    public ProgrammingQuestion UpdateProgrammingQuestion(ProgrammingQuestion programmingQuestion, User user)
    {
        return m.UpdateProgrammingQuestion(programmingQuestion, user);
    }

    [WebMethod]
    public ProgrammingQuestion RemoveProgrammingQuestion(ProgrammingQuestion programmingQuestion, User user)
    {
        return m.RemoveProgrammingQuestion(programmingQuestion, user);
    }

    [WebMethod]
    public AutoProgrammingQuestion LoadAutoProgrammingQuestion(uint id, User user)
    {
        return m.LoadAutoProgrammingQuestion(id, user);
    }

    [WebMethod]
    public AutoProgrammingQuestion UpdateAutoProgrammingQuestion(AutoProgrammingQuestion autoProgrammingQuestion, User user)
    {
        return m.UpdateAutoProgrammingQuestion(autoProgrammingQuestion, user);
    }

    [WebMethod]
    public AutoProgrammingQuestion RemoveAutoProgrammingQuestion(AutoProgrammingQuestion autoProgrammingQuestion, User user)
    {
        return m.RemoveAutoProgrammingQuestion(autoProgrammingQuestion, user);
    }

    [WebMethod]
    public WebProgrammingQuestion LoadWebProgrammingQuestion(uint id, User user)
    {
        return m.LoadWebProgrammingQuestion(id, user);
    }
    
    [WebMethod]
    public WebProgrammingQuestion UpdateWebProgrammingQuestion(WebProgrammingQuestion webProgrammingQuestion, User user)
    {
        return m.UpdateWebProgrammingQuestion(webProgrammingQuestion, user);
    }

    [WebMethod]
    public WebProgrammingQuestion RemoveWebProgrammingQuestion(WebProgrammingQuestion webProgrammingQuestion, User user)
    {
        return m.RemoveWebProgrammingQuestion(webProgrammingQuestion, user);
    }
    #endregion

    #region Get / Update / Remove papers
    [WebMethod]
    public List<Paper> GetPapers(User user)
    {
        return m.GetPapers(user);
    }

    [WebMethod]
    public Paper UpdatePaper(Paper paper, User user)
    {
        return m.UpdatePaper(paper, user);
    }

    [WebMethod]
    public uint RemovePaper(Paper paper, User user)
    {
        return m.RemovePaper(paper, user);
    }
    #endregion

    #region Get / Update / Remove auto papers
    [WebMethod]
    public List<AutoPaper> GetAutoPapers(User user)
    {
        return m.GetAutoPapers(user);
    }

    [WebMethod]
    public AutoPaper UpdateAutoPaper(AutoPaper paper, User user)
    {
        return m.UpdateAutoPaper(paper, user);
    }

    [WebMethod]
    public AutoPaper RemoveAutoPaper(AutoPaper paper, User user)
    {
        return m.RemoveAutoPaper(paper, user);
    }

    [WebMethod]
    public long GetQuestionsCountByCategoryLevelType(QuestionType questionType, uint count, uint category, uint difficultyLevel, User user)
    {
        return m.GetQuestionsCountByCategoryLevelType(questionType, count, category, difficultyLevel, user);
    }
    
    [WebMethod]
    public Paper CreatePaperByAutoPaper(AutoPaper paper, User user)
    {
        return m.CreatePaperByAutoPaper(paper, user);
    }
    #endregion

    #region Get / Update / Remove Test Schedules
    [WebMethod]
    public uint GetNumberOfTestSchedulePages(User user)
    {
        return m.GetNumberOfTestSchedulePages(user);
    }
    
    [WebMethod]
    public List<TestSchedule> GetTestSchedules(User user, uint index)
    {
        return m.GetTestSchedules(user, index);
    }

    [WebMethod]
    public List<TestSchedule> GetTestSchedulesByFilters(User user, List<string> filters, uint index)
    {
        return m.GetTestSchedulesByFilters(user, filters, index);
    }

    [WebMethod]
    public TestSchedule UpdateTestSchedule(TestSchedule testSchedule, User user)
    {
        return m.UpdateTestSchdule(testSchedule, user);
    }

    [WebMethod]
    public uint RemoveTestSchedule(TestSchedule testSchedule, User user)
    {
        return m.RemoveTestSchedule(testSchedule, user);
    }

    [WebMethod]
    public TestAnswers GetTestAnswers(uint testId, User user)
    {
        return m.GetTestAnswers(testId, user);
    }

    [WebMethod]
    public CompilerMessage AutoCompileCode(AutoProgrammingQuestion question, string code, string sessionId, ProgrammingAnswerType answerType, User user)
    {
        return m.AutoCompileCode(question, code, sessionId, answerType, user);
    }

    [WebMethod]
    public string GetWebsitesVisited(uint testId, User user)
    {
        return m.GetWebsitesVisited(testId, user);
    }

    [WebMethod]
    public string GetApplicationsIgnored(uint testId, User user)
    {
        return m.GetApplicationsIgnored(testId, user);
    }

    [WebMethod]
    public uint GetTestsPurchased(User user)
    {
        return m.GetTestsPurchased(user);
    }

    [WebMethod]
    public bool UpdateTestPurchase(string email, uint qty, string token)
    {
        return m.UpdateTestPurchase(email, qty, token);
    }

    [WebMethod]
    public TestImage[] GetTestImages(uint testId, User user)
    {
        return m.GetTestImages(testId, user);
    }
    #endregion

    [WebMethod]
    public bool SaveWebPages(WebNode webNode, string uniqueId, User user)
    {
        return m.SaveWebPages(webNode, uniqueId, user);
    }

    [WebMethod]
    public void SendErrorMessage(string message, User user)
    {
        m.SendErrorMessage(message, user);
    }
}
