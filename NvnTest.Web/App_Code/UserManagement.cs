using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

public class User
{
    private uint id;
    private string email;
    private string password;

    public uint Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public User() { }

    public User(uint id, string email, string password)
    {
        this.id = id;
        this.email = email;
        this.password = password;
    }
}

public class UserInfo
{
    private uint id;
    private string email;
    private string password;
    private string firstName;
    private string lastName;
    private string companyName;
    private bool varified = false;
    private UserExtension userExtension;
    private string tempId;

    public uint Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

    public bool Varified
    {
        get { return varified; }
        set { varified = value; }
    }

    public UserExtension UserExtension
    {
        get { return userExtension; }
        set { userExtension = value; }
    }

    public string TempId
    {
        get { return tempId; }
        set { tempId = value; }
    }
}

public class UserExtension
{
    private uint adminId;
    private string email;
    private string password;
    private string firstName;
    private string lastName;
    private string note;
    private PrivilegeType questionsPrivilege;
    private PrivilegeType papersPrivilege;
    private PrivilegeType schedulesPrivilege;

    public uint AdminId
    {
        get { return adminId; }
        set { adminId = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Note
    {
        get { return note; }
        set { note = value; }
    }

    public PrivilegeType QuestionsPrivilege
    {
        get { return questionsPrivilege; }
        set { questionsPrivilege = value; }
    }

    public PrivilegeType PapersPrivilege
    {
        get { return papersPrivilege; }
        set { papersPrivilege = value; }
    }

    public PrivilegeType SchedulesPrivilege
    {
        get { return schedulesPrivilege; }
        set { schedulesPrivilege = value; }
    }

    internal void Fill(DataRow row)
    {
        adminId = (uint)row["AdminId"];
        email = (string)row["Email"];
        password = (string)row["Password"];
        firstName = (string)row["FirstName"];
        lastName = (string)row["LastName"];
        note = (string)row["Note"];
        questionsPrivilege = (PrivilegeType)((ushort)row["QuestionsPrivilege"]);
        papersPrivilege = (PrivilegeType)((ushort)row["PapersPrivilege"]);
        schedulesPrivilege = (PrivilegeType)((ushort)row["SchedulesPrivilege"]);
    }

    internal SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "UsereExtension";
        cmd.Sql = "REPLACE INTO `userextension` VALUES(@AdminId, @Email, @Password, @FirstName, @LastName, @Note, @QuestionsPrivilege, @PapersPrivilege, @SchedulesPrivilege)";
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);
        Db.AddParam(cmd, "@Password", MySqlDbType.VarChar, password);
        Db.AddParam(cmd, "@FirstName", MySqlDbType.VarChar, firstName);
        Db.AddParam(cmd, "@LastName", MySqlDbType.VarChar, lastName);
        Db.AddParam(cmd, "@Note", MySqlDbType.VarChar, note);
        Db.AddParam(cmd, "@QuestionsPrivilege", MySqlDbType.UInt16, questionsPrivilege);
        Db.AddParam(cmd, "@PapersPrivilege", MySqlDbType.UInt16, papersPrivilege);
        Db.AddParam(cmd, "@SchedulesPrivilege", MySqlDbType.UInt16, schedulesPrivilege);

        return cmd;
    }

    internal SQLCommand GetRemoveQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "UserExtension";
        cmd.Sql = "DELETE FROM `userextension` WHERE Email=@Email";
        // Parameters
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);

        return cmd;
    }
}

// TODO: dont cache complete user info
internal class UserManager
{
    private static Dictionary<string, UserInfo> users = new Dictionary<string, UserInfo>();

    public static Dictionary<string, UserInfo> Users { get { return users; } }

    internal static bool ValidateUser(User user)
    {
        bool valid = false;
        bool userExists = UserExists(user.Email);
        if (userExists)
        {
            valid = users[user.Email].Password.Equals(EncryptDecrypt.Decrypt(user.Password), StringComparison.OrdinalIgnoreCase);
        }

        // password might have changed. So cache again
        if (valid == false)
        {
            CacheUser(user.Email);
            userExists = UserExists(user.Email);
            if (userExists)
            {
                valid = users[user.Email].Password.Equals(EncryptDecrypt.Decrypt(user.Password), StringComparison.OrdinalIgnoreCase);
            }
        }

        return valid;
    }

    internal static UserInfo Authenticate(string email, string password)
    {
        UserInfo userInfo = null;
        if (MatchEmailAndPassword(email, password))
        {
            userInfo = users[email];
        }

        // password might have changed. So cache again
        if (userInfo == null)
        {
            CacheUser(email);
            if (MatchEmailAndPassword(email, password))
            {
                userInfo = users[email];
            }
        }

        return userInfo;
    }

    private static bool MatchEmailAndPassword(string email, string password)
    {
        if (UserExists(email))
        {
            if (users[email].UserExtension == null)
            {
                return users[email].Password.Equals(EncryptDecrypt.Decrypt(password), StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return users[email].UserExtension.Password.Equals(EncryptDecrypt.Decrypt(password), StringComparison.OrdinalIgnoreCase);
            }
        }

        return false;
    }

    internal static bool ForgotPassword(string email)
    {
        if (UserExists(email))
        {
            uint id = users[email].Id;
            string newPassword = Guid.NewGuid().ToString().Split("-".ToCharArray())[0];
            // reset password
            SQLCommand cmd = new SQLCommand();
            cmd.Sql = String.Format("UPDATE `user` SET Password = @Password WHERE Id={0}", id);
            cmd.TableName = "User";
            Db.AddParam(cmd, "@Password", MySqlDbType.VarChar, newPassword);

            (new Db()).ExecuteNonQuery(cmd);

            if (cmd.RowsAffected > 0)
            {
                if (users.ContainsKey(email))
                {
                    users[email].Password = newPassword;
                }

                Postman.Send_PasswordReset_Mail(email, newPassword);
                return true; // only when password updated in database and mail is sent 
            }
        }

        return false;
    }

    internal static string GetEmail(uint id)
    {
        foreach (UserInfo user in users.Values)
        {
            if (user.Id == id) { return user.Email; }
        }
        return string.Empty;
    }

    internal static UserInfo GetUserInfo(string email)
    {
        bool userExists = UserExists(email);
        if (userExists) { return users[email]; }
        return null;
    }

    internal static UserInfo GetUserInfo(uint id)
    {
        foreach (UserInfo user in users.Values)
        {
            if (user.Id == id) { return user; }
        }

        CacheUser(id);

        foreach (UserInfo user in users.Values)
        {
            if (user.Id == id) { return user; }
        }

        return null;
    }

    internal static UserInfo UpdateUserInfo(UserInfo userInfo)
    {
        bool tempIdSet = String.IsNullOrEmpty(userInfo.TempId) == false;
        SQLCommand cmd = new SQLCommand();
        cmd.TempId = userInfo.TempId;
        cmd.Sql = String.Format("REPLACE INTO `user` VALUES({0}, @FirstName, @LastName, @Email, @Password, @CompanyName, @Varified)", (tempIdSet ? "NULL" : userInfo.Id.ToString()));
        cmd.TableName = "User";
        Db.AddParam(cmd, "@FirstName", MySqlDbType.VarChar, userInfo.FirstName);
        Db.AddParam(cmd, "@LastName", MySqlDbType.VarChar, userInfo.LastName);
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, userInfo.Email);
        Db.AddParam(cmd, "@Password", MySqlDbType.VarChar, userInfo.Password);
        Db.AddParam(cmd, "@CompanyName", MySqlDbType.VarChar, userInfo.CompanyName);
        Db.AddParam(cmd, "@Varified", MySqlDbType.UInt16, userInfo.Varified);

        (new Db()).ExecuteNonQuery(cmd);

        if (cmd.RowsAffected > 0)
        {
            if (tempIdSet)
            {
                userInfo.Id = (uint)cmd.InsertId;

                // Varification code
                string varificationCode = CreateNewVarificationCode(userInfo.Email);
                // Send mail
                Postman.Send_NewUser_Mail(userInfo, varificationCode);
            }
            if (users.ContainsKey(userInfo.Email)) { users[userInfo.Email] = userInfo; }
        }

        return userInfo;
    }

    internal static string CreateNewVarificationCode(string email)
    {
        string code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5);
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO `varificationcode` VALUES(@Email, @Code)";
        cmd.TableName = "varify";
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);
        Db.AddParam(cmd, "@Code", MySqlDbType.VarChar, code);

        (new Db()).ExecuteNonQuery(cmd);

        if (cmd.RowsAffected < 1)
        {
            // TODO: error handling
        }

        return code;
    }

    internal static bool CheckUserExists(string email)
    {
        return UserExists(email);
    }

    private static bool UserExists(string email)
    {
        if (users.ContainsKey(email) == false)
        {
            CacheUser(email);
        }

        return users.ContainsKey(email);
    }

    internal static void CacheUser(string email)
    {
        CacheUser(email, 0);
    }

    private static void CacheUser(uint id)
    {
        CacheUser("", id);
    }

    private static void CacheUser(string email, uint id)
    {
        // clear cache
        if (users.Count > 1000)
        {
            users.Clear();
        }

        // Try to load User Info
        UserInfo userInfo = LoadUserInfo(email, id);

        if (userInfo == null)
        {
            // Try to load User Extension and User Info
            UserExtension userExtension = LoadUserExtension(email);
            if (userExtension != null)
            {
                userInfo = LoadUserInfo("", userExtension.AdminId);
                userInfo.UserExtension = userExtension;
            }
        }

        if (userInfo != null)
        {
            string key = String.IsNullOrEmpty(email) ? userInfo.Email : email;

            if (users.ContainsKey(key)) users[key] = userInfo;
            else users.Add(key, userInfo);
        }
    }

    private static UserInfo LoadUserInfo(string email, uint id)
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "User";
        if (String.IsNullOrEmpty(email))
        {
            cmd.Sql = "SELECT * FROM user WHERE Id = @Id";
            Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        }
        else
        {
            cmd.Sql = "SELECT * FROM user WHERE Email = @Email";
            Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);
        }

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("User") && ds.Tables["User"].Rows.Count == 1)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = (uint)ds.Tables["User"].Rows[0]["Id"];
            userInfo.Email = (string)ds.Tables["User"].Rows[0]["Email"];
            userInfo.Password = (string)ds.Tables["User"].Rows[0]["Password"];
            userInfo.FirstName = (string)ds.Tables["User"].Rows[0]["FirstName"];
            userInfo.LastName = (string)ds.Tables["User"].Rows[0]["LastName"];
            userInfo.CompanyName = (string)ds.Tables["User"].Rows[0]["CompanyName"];
            userInfo.Varified = (bool)ds.Tables["User"].Rows[0]["Varified"];

            return userInfo;
        }

        return null;
    }

    private static UserExtension LoadUserExtension(string email)
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "UserExtension";
        cmd.Sql = "SELECT * FROM userextension WHERE Email = @Email";
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("UserExtension") && ds.Tables["UserExtension"].Rows.Count == 1)
        {
            UserExtension userExtension = new UserExtension();
            userExtension.Fill(ds.Tables["UserExtension"].Rows[0]);

            return userExtension;
        }

        return null;
    }
}