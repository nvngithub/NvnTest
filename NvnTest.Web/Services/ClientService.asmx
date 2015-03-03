<%@ WebService Language="C#" Class="ClientService" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ClientService
/// </summary>
[WebService(Namespace = "http://www.coderlabz.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ClientService : System.Web.Services.WebService
{
    ClientManager m = new ClientManager();

    [WebMethod]
    public TestSchedule Authenticate(string email, string password)
    {
        return m.Authenticate(email, password);
    }

    [WebMethod]
    public Questions GetQuestions(uint paperId, string email, string password)
    {
        return m.GetQuestions(paperId, email, password);
    }

    [WebMethod]
    public bool UpdateTestStarted(uint testId, string email, string password)
    {
        return m.UpdateTestStarted(testId, email, password);
    }

    [WebMethod]
    public bool SetCandidateDisqualified(TestSchedule schedule, string email, string password)
    {
        return m.SetCandidateDisqualified(schedule, email, password);
    }

    [WebMethod]
    public TestInfo GetTestInfo(string email, string password)
    {
        return m.GetTestInfo(email, password);
    }

    [WebMethod]
    public CompilerMessage CompileCode(string code, string sessionId, ProgrammingAnswerType answerType, string email, string password)
    {
        return m.CompileCode(code, sessionId, answerType, email, password);
    }

    [WebMethod]
    public CompilerMessage AutoCompileCode(AutoProgrammingQuestion question, string code, string sessionId, ProgrammingAnswerType answerType, string email, string password)
    {
        return m.AutoCompileCode(question, code, sessionId, answerType, email, password);
    }

    [WebMethod]
    public string GetTemplateCode(AutoProgrammingQuestion question, ProgrammingAnswerType answerType, string email, string password)
    {
        return m.GetTemplateCode(question, answerType, email, password);
    }

    [WebMethod]
    public bool SubmitAnswers(TestAnswers answers, TestSchedule schedule, string email, string password)
    {
        return m.SubmitAnswers(answers, schedule, email, password);
    }

    [WebMethod]
    public bool UpdateWebsitesVisited(uint testId, string urls, string email, string password)
    {
        return m.UpdateWebsitesVisited(testId, urls, email, password);
    }

    [WebMethod]
    public bool UpdateApplicationsIgnored(uint testId, string apps, string email, string password)
    {
        return m.UpdateApplicationsIgnored(testId, apps, email, password);
    }

    [WebMethod]
    public void SendErrorMessage(string message, string email, string password)
    {
        m.SendErrorMessage(message, email, password);
    }

    [WebMethod]
    public bool SubmitTestImages(TestImage[] testImages, uint testId, string email, string password)
    {
        return m.SubmitTestImages(testImages, testId, email, password);
    }

    [WebMethod]
    public bool SaveWebPages(WebNode webNode, string uniqueId, string email, string password)
    {
        return m.SaveWebPages(webNode, uniqueId, email, password);
    }
}