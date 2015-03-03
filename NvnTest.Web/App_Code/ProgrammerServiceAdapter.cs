using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

public class ProgrammerServiceAdapter
{
    private const double profilesPerPage = 3;

    public string GetNumberOfPages()
    {
        long count = 0;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "SELECT count(*) FROM `profile`";
        cmd.TableName = "NumberOfProfiles";

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("NumberOfProfiles"))
        {
            count = (long)ds.Tables["NumberOfProfiles"].Rows[0][0];
        }

        return Math.Ceiling(count/profilesPerPage).ToString("0");
    }

    public List<Profile> GetProfiles(string index)
    {
        List<Profile> profiles = new List<Profile>();

        int currentIndex = 0;
        Int32.TryParse(index, out currentIndex);

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = @"SELECT t.Id, t.FirstName, t.LastName, t.Email,  t.TestTakenDateTime, p.Experience, p.LocationPreference, p.TechnologyPreference
                        FROM `testschedule` t 
                        INNER JOIN `profile` p ON p.TestId = t.Id LIMIT " + (currentIndex * profilesPerPage) + "," + ((currentIndex + 1) * profilesPerPage);
        cmd.TableName = "Profiles";

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("Profiles"))
        {
            foreach (DataRow row in ds.Tables["Profiles"].Rows)
            {
                Profile profile = new Profile();
                profile.TestId = Convert.ToString(row["Id"]);
                profile.Name = row["FirstName"] + " " + row["LastName"];

                float experience = (float)row["Experience"];
                profile.Experience = experience == 0 ? "Fresher" : (experience + " years");

                profile.LocationPreference = (string)row["LocationPreference"];
                profile.TechnologyPreference = (string)row["TechnologyPreference"];
                profile.DateimeTestTaken = ((DateTime)row["TestTakenDateTime"]).ToString("dd-MMM-yyyy");

                profiles.Add(profile);
            }
        }

        return profiles;
    }

    public Profile GetProfile(string testId)
    {
        Profile profile = new Profile();

        uint iTestId = 0;
        UInt32.TryParse(testId, out iTestId);

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = @"SELECT t.Id, t.FirstName, t.LastName, t.Email, t.Duration,  t.TestTakenDateTime, p.Experience
                        FROM `testschedule` t 
                        INNER JOIN `profile` p ON p.TestId = t.Id WHERE t.Id = @TestId";
        cmd.TableName = "Profile";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, iTestId);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("Profile") && ds.Tables["Profile"].Rows.Count > 0)
        {
            DataRow row = ds.Tables["Profile"].Rows[0];

            profile.TestId = testId;
            profile.Name = (string)row["FirstName"] + " " + (string)row["LastName"]; ;

            float experience = (float)row["Experience"];
            profile.Experience = experience == 0 ? "Fresher" : (experience + " years");

            profile.DateimeTestTaken = ((DateTime)row["TestTakenDateTime"]).ToString("dd-MMM-yyyy");
            profile.TestDuration = (uint)row["Duration"] + " minutes";

            uint questionId = 0;
            profile.Answer = GetAnwer(iTestId, ref questionId);
            profile.QuestionAsked = GetQuestion(questionId);
        }

        return profile;
    }

    private string GetAnwer(uint testId, ref uint questionId)
    {
        string answer = string.Empty;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "SELECT Code, QuestionId FROM `a_programming` WHERE TestId=@TestId";
        cmd.TableName = "ProgrammingAnswer";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("ProgrammingAnswer") && ds.Tables["ProgrammingAnswer"].Rows.Count > 0)
        {
            DataRow row = ds.Tables["ProgrammingAnswer"].Rows[0];
            answer = (string)row["Code"];
            questionId = (uint)row["QuestionId"];
        }

        return answer;
    }

    private string GetQuestion(uint questionId)
    {
        string question = string.Empty;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "SELECT q.Desc FROM `q_programming` q WHERE Id=@QuestionId";
        cmd.TableName = "ProgrammingQuestion";
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("ProgrammingQuestion") && ds.Tables["ProgrammingQuestion"].Rows.Count > 0)
        {
            question = (string)ds.Tables["ProgrammingQuestion"].Rows[0]["Desc"];
        }

        return question;
    }

    public string ScheduleTest(string email, string firstName, string lastName, string experience, string locationPreference, string technologyPreference, string challenge, string response)
    {
        List<string> errorMessages = new List<string>();
        if (ValidEmailFormat(email) == false)
        {
            errorMessages.Add("* Email:" + email + " not in valid format.");
        }

        if (String.IsNullOrEmpty(firstName))
        {
            errorMessages.Add("* Please enter your first name");
        }

        if (String.IsNullOrEmpty(lastName))
        {
            errorMessages.Add("* Please enter your last name");
        }

        int iExperience = 0;
        if (Int32.TryParse(experience, out iExperience) == false)
        {
            errorMessages.Add("* Please enter your total years of work experience (0 if fresher).");
        }

        if (String.IsNullOrEmpty(locationPreference))
        {
            errorMessages.Add("* Please eneter your location preference.");
        }

        if (String.IsNullOrEmpty(technologyPreference))
        {
            errorMessages.Add("* Please eneter your technology preference.");
        }

        if (errorMessages.Count > 0)
        {
            return String.Join("<br/>", errorMessages.ToArray());
        }

        Recaptcha.RecaptchaValidator recaptcha = new Recaptcha.RecaptchaValidator();
        recaptcha.Challenge = challenge;
        recaptcha.Response = response;
        recaptcha.RemoteIP = HttpContext.Current.Request.UserHostAddress;

        recaptcha.PrivateKey = "6Lec_MsSAAAAAIxs4dj-GeGqpIUf1sG0K3cTYgb4";

        Recaptcha.RecaptchaResponse recaptchaResponse = recaptcha.Validate();
        if (recaptchaResponse.IsValid)
        {
            Postman.Send_TestSchedule_Request_Mail(email, firstName, lastName, experience, locationPreference, technologyPreference);
        }

        return recaptchaResponse.IsValid ? "" : "CAPTCHA value entered is incorrect. Please try again.";
    }

    public string ContactProgrammer(string message, string testId, string challenge, string response)
    {
        
        if (String.IsNullOrEmpty(message))
        {
            return "Please enter your message";
        }

        if (message.Length < 50)
        {
            return "The message you have entered is too short. Please lengthen your message to at least 50 characters.";
        }

        if (message.Length > 500)
        {
            return "Please limit your message length to 500 characters";
        }

        Recaptcha.RecaptchaValidator recaptcha = new Recaptcha.RecaptchaValidator();
        recaptcha.Challenge = challenge;
        recaptcha.Response = response;
        recaptcha.RemoteIP = HttpContext.Current.Request.UserHostAddress;

        recaptcha.PrivateKey = "6Lec_MsSAAAAAIxs4dj-GeGqpIUf1sG0K3cTYgb4";

        Recaptcha.RecaptchaResponse recaptchaResponse = recaptcha.Validate();
        if (recaptchaResponse.IsValid)
        {
            uint iTestId = 0;
            UInt32.TryParse(testId, out iTestId);

            string email = GetEmailByTestId(iTestId);
            if (String.IsNullOrEmpty(email) == false)
            {
                Postman.Send_Contact_Programmer_Mail(message, email);
            }
        }

        return recaptchaResponse.IsValid ? "" : "CAPTCHA value entered is incorrect. Please try again.";
    }

    private string GetEmailByTestId(uint testId)
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "SELECT Email FROM `testschedule` WHERE Id=@TestId";
        cmd.TableName = "Profiles";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("Profiles"))
        {
            string emaill = (string)ds.Tables["Profiles"].Rows[0][0];
            return emaill;
        }

        return string.Empty;
    }

    private bool ValidEmailFormat(string email)
    {
        bool isValid = System.Text.RegularExpressions.Regex.IsMatch(email,
          @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

        return isValid;
    }
}

public class Profile
{
    private string testId;
    private string name;
    private string experience;
    private string locationPreference;
    private string technologyPreference;
    private string datetimeTestTaken;
    private string testDuration;
    private string questionAsked;
    private string answer;

    public string TestId
    {
        get { return testId; }
        set { testId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Experience
    {
        get { return experience; }
        set { experience = value; }
    }

    public string LocationPreference
    {
        get { return locationPreference; }
        set { locationPreference = value; }
    }

    public string TechnologyPreference
    {
        get { return technologyPreference; }
        set { technologyPreference = value; }
    }

    public string DateimeTestTaken
    {
        get { return datetimeTestTaken; }
        set { datetimeTestTaken = value; }
    }

    public string TestDuration
    {
        get { return testDuration; }
        set { testDuration = value; }
    }

    public string QuestionAsked
    {
        get { return questionAsked; }
        set { questionAsked = value; }
    }

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }
}
