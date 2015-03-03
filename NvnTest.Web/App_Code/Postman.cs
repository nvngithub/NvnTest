#define MAIL
#define GOOGLE_MAIL_NO
#define NAMECHEAP_MAIL
#define LIVE

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

public class Postman
{
    private static SmtpPostman postman = new SmtpPostman();

    internal static void Send_Schedule_Mail(TestSchedule testSchedule, bool reschedule)
    {
        postman.Send_Schedule_Mail(testSchedule, reschedule);
    }

    internal static void Send_Cancel_Mail(TestSchedule testSchedule)
    {
        postman.Send_Cancel_Mail(testSchedule);
    }

    internal static void Send_TestSubmitted_Mail(TestSchedule testSchedule)
    {
        postman.Send_TestSubmitted_Mail(testSchedule);
    }

    internal static void Send_CandidateDisqualified_Mail(TestSchedule testSchedule)
    {
        postman.Send_CandidateDisqualified_Mail(testSchedule);
    }

    internal static void Send_NewUser_Mail(UserInfo userInfo, string varificationCode)
    {
        postman.Send_NewUser_Mail(userInfo, varificationCode);
    }

    internal static void Send_PasswordReset_Mail(string email, string newPassword)
    {
        postman.Send_PasswordReset_Mail(email, newPassword);
    }

    internal static void Send_NewVarificationCode_Mail(string email, string code)
    {
        postman.Send_NewVarificationCode_Mail(email, code);
    }

    internal static void Send_Error_Mail(string message)
    {
        postman.Send_Error_Mail(message);
    }

    public static void Send_TestSchedule_Request_Mail(string email, string firstName, string lastName, string experience, string locationPreference, string technologyPreference)
    {
        postman.Send_TestSchedule_Request_Mail(email, firstName, lastName, experience, locationPreference, technologyPreference);
    }

    public static void Send_Contact_Programmer_Mail(string message, string to)
    {
        postman.Send_Contact_Programmer_Mail(message, to);
    }

    public static void Recruiter_Job_Description_Mail(string companyName, string position, string body, string to, string filename)
    {
        postman.Recruiter_Job_Description_Mail(companyName, position, body, to, filename);
    }

    public static void Recruiter_Assignment_Mail(string companyName, string position, string body, string to, string filename)
    {
        postman.Recruiter_Assignment_Mail(companyName, position, body, to, filename);
    }
}

internal class SmtpPostman
{
    internal void Send_Schedule_Mail(TestSchedule testSchedule, bool reschedule)
    {
        string subject = reschedule ? "Coderlabz: Test re-scheduled" : "Coderlabz: Test schedule";
        string adminEmail = UserManager.GetEmail(testSchedule.AdminId);
        string message = MailTemplates.ScheduleMail;
        TimeZone timezone = TimeZone.CurrentTimeZone;
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);

        message = message.Replace("[candidate_name]", testSchedule.FirstName + " " + testSchedule.LastName);
        message = message.Replace("[admin_name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[company_name]", String.IsNullOrEmpty(userInfo.CompanyName) ? "Unknown" : userInfo.CompanyName);
        message = message.Replace("[schedule_date]", timezone.ToUniversalTime(DateTime.Now).ToString("dd-MMM-yyyy"));
        message = message.Replace("[days_left]", testSchedule.DaysLimit.ToString());
        message = message.Replace("[utc_datetime]", timezone.ToUniversalTime(DateTime.Now.AddDays(testSchedule.DaysLimit)).ToString("dd-MMM-yyyy hh:mm tt"));
        message = message.Replace("[duration]", testSchedule.Duration.ToString());
        message = message.Replace("[email]", testSchedule.Email);
        message = message.Replace("[password]", testSchedule.Password);
        message = message.Replace("[link]", "<a href='http://www.coderlabz.com/docs/Candidate_Guide.pdf' target='_blank'>http://www.coderlabz.com/docs/Candidate_Guide.pdf</a>");
        message = message.Replace("[faq]", "<a href='http://www.coderlabz.com/docs/faq.pdf' target='_blank'>http://www.coderlabz.com/docs/faq.pdf</a>");

        SendMail(subject, testSchedule.Email, adminEmail, message, true);
    }

    internal void Send_Cancel_Mail(TestSchedule testSchedule)
    {
        string adminEmail = UserManager.GetEmail(testSchedule.AdminId);
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);
        string subject = "Coderlabz: Test schedule cancelled";
        string message = MailTemplates.ScheduleCancelMail;

        message = message.Replace("[name]", testSchedule.FirstName + " " + testSchedule.LastName);
        message = message.Replace("[employer]", userInfo.CompanyName);

        SendMail(subject, testSchedule.Email, adminEmail, message, false);
    }

    internal void Send_TestSubmitted_Mail(TestSchedule testSchedule)
    {
        string adminEmail = UserManager.GetEmail(testSchedule.AdminId);
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);
        string subject = "Coderlabz: Test submitted";
        string message = MailTemplates.TestSubmitMail;

        TimeZone localZone = TimeZone.CurrentTimeZone;
        message = message.Replace("[admin_name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[name]", testSchedule.FirstName + " " + testSchedule.LastName);
        message = message.Replace("[date]", localZone.ToUniversalTime(DateTime.Now).ToString("dd-MMM-yyyy"));

        SendMail(subject, adminEmail, "", message, false);
    }

    internal void Send_CandidateDisqualified_Mail(TestSchedule testSchedule)
    {
        string adminEmail = UserManager.GetEmail(testSchedule.AdminId);
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);
        string subject = "Coderlabz: Candidate disqualified";
        string message = MailTemplates.CandidateDisqualifiedMail;

        message = message.Replace("[admin_name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[name]", testSchedule.FirstName + " " + testSchedule.LastName);

        SendMail(subject, adminEmail, "", message, false);
    }

    internal void Send_NewUser_Mail(UserInfo userInfo, string varificationCode)
    {
        string subject = "Welcome to Coderlabz";
        string message = MailTemplates.NewUserMail;

        message = message.Replace("[admin_name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[username]", userInfo.Email);
        message = message.Replace("[password]", userInfo.Password);
        message = message.Replace("[code]", varificationCode);

        SendMail(subject, userInfo.Email, "", message, false);
    }

    internal void Send_PasswordReset_Mail(string email, string newPassword)
    {
        UserInfo userInfo = UserManager.GetUserInfo(email);
        string subject = "Coderlabz: Password reset";
        string message = MailTemplates.PasswordResetMail;

        message = message.Replace("[admin_name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[username]", email);
        message = message.Replace("[newpasssword]", newPassword);

        SendMail(subject, email, "", message, false);
    }

    internal void Send_NewVarificationCode_Mail(string email, string code)
    {
        string subject = "Coderlabz: New varification code";
        string message = MailTemplates.NewVarificationMail;

        UserInfo userInfo = UserManager.GetUserInfo(email);
        message = message.Replace("[name]", userInfo.FirstName + " " + userInfo.LastName);
        message = message.Replace("[code]", code);

        SendMail(subject, email, "", message, true);
    }

    internal void Send_Error_Mail(string message)
    {
        SendMail("Unexpected error!!!", "support@coderlabz.com", "", message, false);
    }

    internal void Send_TestSchedule_Request_Mail(string email, string firstName, string lastName, string experience, string locationPreference, string technologyPreference)
    {
        string message = "Email: " + email + "<br/>";
        message += "FistName:" + firstName + "<br/>";
        message += "LastName:" + lastName + "<br/>";
        message += "Experience:" + experience + "<br/>";
        message += "Location Preference:" + locationPreference + "<br/>";
        message += "Technology Preference:" + technologyPreference + "<br/>";

        SendMail("Schedule a test", "naveen@coderlabz.com", "", message, true);
    }

    internal void Send_Contact_Programmer_Mail(string message, string to)
    {
        string subject = "Coderlabz: Correspondence message";
        SendMail(subject, to, "", message, true);
    }

    internal void Recruiter_Job_Description_Mail(string companyName, string position, string body, string to, string filename)
    {
        string subject = "Job description: " + companyName + " - " + position;
        SendMail(subject, to, "", body, false, filename);
    }

    internal void Recruiter_Assignment_Mail(string companyName, string position, string body, string to, string filename)
    {
        string subject = "Assignment: " + companyName + " - " + position;
        SendMail(subject, to, "", body, false, filename);
    }

    private void SendMail(string subject, string to, string cc, string body, bool isHtml)
    {
        SendMail(subject, to, cc, body, isHtml, "");
    }

    private void SendMail(string subject, string to, string cc, string body, bool isHtml, string filename)
    {
#if GOOGLE_MAIL
        string sender = "your email address here";
#endif

#if NAMECHEAP_MAIL
        string sender = "your email address here";
#endif

        string password = "your password here"; //TODO: NOT secure

        SendMail(subject, to, cc, body, isHtml, sender, password, filename);
    }

    private void SendMail(string subject, string to, string cc, string body, bool isHtml, string sender, string password, string filename)
    {
        // Create message
        MailMessage mail = new MailMessage();
        mail.IsBodyHtml = isHtml;
        mail.Subject = subject;
        mail.To.Add(to);
        mail.From = new MailAddress(sender);
        if (String.IsNullOrEmpty(cc) == false) { mail.CC.Add(cc); }
        mail.Body = body;

        if (String.IsNullOrEmpty(filename) == false)
        {
            mail.Attachments.Add(new Attachment(filename));
        }

#if MAIL
#if GOOGLE_MAIL
        // Send mail using Gmail account
        SmtpClient sc = new SmtpClient("smtp.gmail.com", 587); // Use account to avoid spam filters
        sc.Credentials = new NetworkCredential(sender, password);
        sc.EnableSsl = true;
        sc.Send(mail);
#endif

#if NAMECHEAP_MAIL
        try
        {
            mail.Bcc.Add("support@coderlabz.com"); // BCC is sent only while using namecheap email address, becuase namecheap does  not maintain emails sent

            SmtpClient smtpClient = new SmtpClient("oxmail.registrar-servers.com");
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("noreply@nvntest.net", password);
            smtpClient.Send(mail);
        }
        catch (Exception exc)
        {
        }
#endif
#endif
    }    
}

internal class GoogleAppsEnginePostman
{
    private string token = "test";
    internal void Send_Schedule_Mail(TestSchedule testSchedule, bool reschedule)
    {
        TimeZone timezone = TimeZone.CurrentTimeZone;
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);

        //http://localhost:8080/sd?s=1&t=test&e=hegde.naveen@yahoo.com&n=candidatename&r=1&an=adminname&cn=companyname&d=2001-jan-1&dl=3&ud=2011-11-11 20-10-10&dr=60&se=test@test.com&sp=adfdfq3434
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + testSchedule.Email;
        querystring += "&n=" + testSchedule.FirstName + " " + testSchedule.LastName;
        querystring += "&r=" + (reschedule ? "1" : "0");
        querystring += "&an=" + userInfo.FirstName + " " + userInfo.LastName;
        querystring += "&cn=" + (String.IsNullOrEmpty(userInfo.CompanyName) ? "Unknown" : userInfo.CompanyName);
        querystring += "&d=" + timezone.ToUniversalTime(DateTime.Now).ToString("dd-MMM-yyyy");
        querystring += "&dl=" + testSchedule.DaysLimit.ToString();
        querystring += "&ud=" + timezone.ToUniversalTime(DateTime.Now.AddDays(testSchedule.DaysLimit)).ToString("dd-MMM-yyyy hh:mm tt");
        querystring += "&dr=" + testSchedule.Duration.ToString();
        querystring += "&se=" + testSchedule.Email;
        querystring += "&sp=" + testSchedule.Password;

        SendMail("sd", querystring);
    }

    internal void Send_Cancel_Mail(TestSchedule testSchedule)
    {
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);

        //http://localhost:8080/sc?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&emp=tester
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + UserManager.GetEmail(testSchedule.AdminId);
        querystring += "&n=" + testSchedule.FirstName + " " + testSchedule.LastName;
        querystring += "&emp=" + userInfo.CompanyName;

        SendMail("sc", querystring);
    }

    internal void Send_TestSubmitted_Mail(TestSchedule testSchedule)
    {
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);
        TimeZone localZone = TimeZone.CurrentTimeZone;

        //http://localhost:8080/ts?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&emp=tester&d=2001-324-234
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + UserManager.GetEmail(testSchedule.AdminId);
        querystring += "&n=" + testSchedule.FirstName + " " + testSchedule.LastName;
        querystring += "&emp=" + userInfo.FirstName + " " + userInfo.LastName;
        querystring += "&d=" + localZone.ToUniversalTime(DateTime.Now).ToString("dd-MMM-yyyy");

        SendMail("ts", querystring);
    }

    internal void Send_CandidateDisqualified_Mail(TestSchedule testSchedule)
    {
        UserInfo userInfo = UserManager.GetUserInfo(testSchedule.AdminId);

        //http://localhost:8080/dq?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&emp=tester
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + UserManager.GetEmail(testSchedule.AdminId);
        querystring += "&n=" + testSchedule.FirstName + " " + testSchedule.LastName;
        querystring += "&emp=" + userInfo.FirstName + " " + userInfo.LastName;

        SendMail("dq", querystring);
    }

    internal void Send_NewUser_Mail(UserInfo userInfo, string varificationCode)
    {
        //http://localhost:8080/nu?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&u=username&p=password&c=jhk324234
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + userInfo.Email;
        querystring += "&n=" + userInfo.FirstName + " " + userInfo.LastName;
        querystring += "&u=" + userInfo.Email;
        querystring += "&p=" + userInfo.Password;
        querystring += "&c=" + varificationCode;

        SendMail("nu", querystring);
    }

    internal void Send_PasswordReset_Mail(string email, string newPassword)
    {
        UserInfo userInfo = UserManager.GetUserInfo(email);

        //http://localhost:8080/pr?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&u=username&p=password
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + email;
        querystring += "&n=" + userInfo.FirstName + " " + userInfo.LastName;
        querystring += "&u=" + email;
        querystring += "&p=" + newPassword;

        SendMail("pr", querystring);
    }

    internal void Send_NewVarificationCode_Mail(string email, string code)
    {
        UserInfo userInfo = UserManager.GetUserInfo(email);

        //http://localhost:8080/vc?s=1&t=test&e=hegde.naveen@yahoo.com&n=naveen&c=lewrklr234
        string querystring = "s=1&t=" + token;
        querystring += "&e=" + email;
        querystring += "&n=" + userInfo.FirstName + " " + userInfo.LastName;
        querystring += "&c=" + code;

        SendMail("vc", querystring);
    }

    private void SendMail(string name, string querystring)
    {
#if LIVE
        string url = "http://nvntestmailer.appspot.com/";
#else
        string url = "http://localhost:8080/";
#endif

        url += name + "?" + querystring;

#if MAIL
        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            // Message sending failed
            SmtpPostman errorPostman = new SmtpPostman();
            errorPostman.Send_Error_Mail("Message sending failed. Please check your google apps engine as soon as possible.");
        }
#endif
    }
}

public class MailTemplates
{
    #region Schedule Mail
    public static string ScheduleMail =
        @"Hi [candidate_name]<br/><br/>
[admin_name] of [company_name] has registered you to take assessment as show below<br/>
<br/>
<b>1. Test details</b><br/>
<br/>
Date assigned       : [schedule_date] Coordinated Universal Time (UTC)<br/>
Number of days left : [days_left] i.e you are required to take test before [utc_datetime] Coordinated Universal Time (UTC)<br/>
Test duration       : [duration] minutes<br/>
<br/>
<b>2. Login details</b><br/>
<br/>
Please use following user name and password to take your test.<br/>
<br/>
User name : [email]<br/>
Password  : [password]<br/>
<br/>
<b>3. Information to take test</b><br/>
<br/>
Download comprehensive guide of Coderlabz.Candidate by clicking following link or directly pasting it in any well know web browser. You can also find this document in Coderlabz website<br/>
<br/>
[link]<br/>
<br/>
We recommend you to try demo and get familiar with the test system before taking your actual test. <br/>
<br/>
Demo user name : demo@coderlabz.com<br/>
Password       : demo<br/>
<br/>
Yours sincerely,<br/>
Coderlabz Administrator
";
    #endregion

    #region Schedule cancel mail
    public static string ScheduleCancelMail =
@"Dear [name]

Test assigned to you by [employer] is cancelled upon their request. Please contact respective employer for more details.

Yours sincerely,
Coderlabz Administrator
";
    #endregion

    #region Test submit mail
    public static string TestSubmitMail =
@"Dear [admin_name]

Test assigned to [name] by you is submitted by him/her on [date](Coordinated Universal Time (UTC)). Please login to Coderlabz administrator to see complete test report.

Yours sincerely,
Coderlabz Administrator";
    #endregion

    #region Candidate disqualified mail
    public static string CandidateDisqualifiedMail =
@"Dear [admin_name]

Candidate [name] is disqualified from the test assigned by you.

Yours sincerely,
Coderlabz Administrator";
    #endregion

    #region New user mail
    public static string NewUserMail =
@"Dear [admin_name]

Welcome to Coderlabz, Pre-employment testing service for software companies.

Following is your login details

User name         : [username]
password          : [password]
Varification Code : [code]

Yours sincerely,
Coderlabz Administrator
";
    #endregion

    #region Password reset mail
    public static string PasswordResetMail =
@"Dear [admin_name]

Your password reset request is successfully processed. Following is your new login details

User name: [username]
password: [newpasssword]

Yours sincerely,
Coderlabz Administrator";
    #endregion

    #region New varification code mail
    public static string NewVarificationMail =
@"Dear [name]<br/>
<br/>
Your new varification code request is successfully processed. Following is the new varification code.<br/>
<br/>
<b>[code]</b><br/>
<br/>
Yours sincerely,<br/>
Coderlabz Administrator";
    #endregion
}
