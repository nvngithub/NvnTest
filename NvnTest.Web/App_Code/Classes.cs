#define LIVE
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;

public abstract class ServiceDataBase
{
    protected uint id = uint.MaxValue;
    protected uint adminId;
    protected string tempId = string.Empty;

    public uint Id
    {
        get { return id; }
        set { id = value; }
    }

    public uint AdminId
    {
        get { return adminId; }
        set { adminId = value; }
    }

    public string TempId
    {
        get { return tempId; }
        set { tempId = value; }
    }

    internal abstract SQLCommand GetUpdateQuery();

    internal abstract SQLCommand GetRemoveQuery();

    internal SQLCommand GetRemoveQuery(string questionTableName, string answerTableName, string dependentIdColumnName)
    {
        // Remove if unused or else mark deleted = true
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Remove";
        if (CanDelete(answerTableName, dependentIdColumnName, id))
        {
            cmd.Sql = String.Format("DELETE FROM `{0}` WHERE Id = @Id AND AdminId = @AdminId", questionTableName); // Admin Id needed to avoid injection attacks
        }
        else
        {
            cmd.Sql = String.Format("UPDATE `{0}` SET Deleted = 1 WHERE Id = @Id AND AdminId = @AdminId", questionTableName);
        }
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);

        return cmd;
    }

    private bool CanDelete(string tableName, string idColumnName, uint id)
    {
        bool delete = false;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Remove";
        cmd.Sql = String.Format("SELECT COUNT(*) FROM `{0}` WHERE {1} = @Id", tableName, idColumnName);
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("Remove") && ds.Tables["Remove"].Rows.Count == 1)
        {
            long count = (long)ds.Tables["Remove"].Rows[0][0];
            delete = count <= 0;
        }

        return delete;
    }
}

public class Questions
{
    private List<ObjectiveQuestion> objectiveQuestions = new List<ObjectiveQuestion>();
    private List<SqlQuestion> sqlQuestions = new List<SqlQuestion>();
    private List<ProgrammingQuestion> programmingQuestions = new List<ProgrammingQuestion>();
    private List<AutoProgrammingQuestion> autoProgrammingQuestions = new List<AutoProgrammingQuestion>();
    private List<WebProgrammingQuestion> webProgrammingQuestions = new List<WebProgrammingQuestion>();

    public List<ObjectiveQuestion> ObjectiveQuestions
    {
        get { return objectiveQuestions; }
    }

    public List<SqlQuestion> SQLQuestions
    {
        get { return sqlQuestions; }
    }

    public List<ProgrammingQuestion> ProgrammingQuestions
    {
        get { return programmingQuestions; }
    }

    public List<AutoProgrammingQuestion> AutoProgrammingQuestions
    {
        get { return autoProgrammingQuestions; }
    }

    public List<WebProgrammingQuestion> WebProgrammingQuestions
    {
        get { return webProgrammingQuestions; }
    }

    internal void Fill(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            switch (table.TableName)
            {
                case "objective":
                    ObjectiveQuestion objectiveQuestion = new ObjectiveQuestion();
                    objectiveQuestion.Fill(row);
                    objectiveQuestions.Add(objectiveQuestion);
                    break;
                case "sql":
                    SqlQuestion sqlQuestion = new SqlQuestion();
                    sqlQuestion.Fill(row);
                    sqlQuestions.Add(sqlQuestion);
                    break;
                case "programming":
                    ProgrammingQuestion programmingQuestion = new ProgrammingQuestion();
                    programmingQuestion.Fill(row);
                    programmingQuestions.Add(programmingQuestion);
                    break;
                case "auto_programming":
                    AutoProgrammingQuestion autoProgrammingQuestion = new AutoProgrammingQuestion();
                    autoProgrammingQuestion.Fill(row);
                    autoProgrammingQuestions.Add(autoProgrammingQuestion);
                    break;
                case "webprogramming":
                    WebProgrammingQuestion webProgrammingQuestion = new WebProgrammingQuestion();
                    webProgrammingQuestion.Fill(row);
                    webProgrammingQuestions.Add(webProgrammingQuestion);
                    break;
            }
        }
    }
}

public abstract class QuestionBase : ServiceDataBase
{
    protected QuestionType type;
    protected string desc = string.Empty;
    protected List<string> categories;
    protected uint difficultyLevel;
    protected DateTime dateTimeCreated;
    protected DateTime dateTimeModified;
    protected bool deleted = false;

    public QuestionType Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public List<string> Categories
    {
        get { return categories; }
        set { categories = value; }
    }

    public uint DifficultyLevel
    {
        get { return difficultyLevel; }
        set { difficultyLevel = value; }
    }

    public DateTime DateTimeCreated
    {
        get { return dateTimeCreated; }
        set { dateTimeCreated = value; }
    }

    public DateTime DateTimeModified
    {
        get { return dateTimeModified; }
        set { dateTimeModified = value; }
    }

    public bool Deleted
    {
        get { return deleted; }
        set { deleted = value; }
    }

    internal abstract void Fill(DataRow row);
}

public class ObjectiveQuestion : QuestionBase
{
    private List<string> options;
    private List<string> answers;

    public ObjectiveQuestion() { this.type = QuestionType.Objective; }

    public List<string> Options
    {
        get { return options; }
        set { options = value; }
    }

    public List<string> Answers
    {
        get { return answers; }
        set { answers = value; }
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        desc = (string)row["Desc"];
        string[] opts = ((string)row["Options"]).Split("~".ToCharArray());
        options = new List<string>(opts);
        string[] ans = ((string)row["Answers"]).Split("~".ToCharArray());
        answers = new List<string>(ans);
        string[] cats = ((string)row["Categories"]).Split("~".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        categories = new List<string>(cats);
        difficultyLevel = (uint)row["DifficultyLevel"];
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Objective";
        cmd.Sql = String.Format("REPLACE INTO `q_objective` VALUES({0}, @AdminId, @Desc, @Options, @Answers, @Categories, @DifficultyLevel, @DateTimeCreated, @DateTimeModified, @Deleted)", (id == uint.MaxValue ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@Options", MySqlDbType.Text, String.Join("~", options.ToArray()));
        Db.AddParam(cmd, "@Answers", MySqlDbType.VarChar, String.Join("~", answers.ToArray()));
        Db.AddParam(cmd, "@Categories", MySqlDbType.VarChar, String.Join("~", categories.ToArray()));
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("q_objective", "a_objective", "QuestionId");
    }
}

public class SqlQuestion : QuestionBase
{    
    private List<SqlTable> tables;
    private string expectedResultSql;

    public SqlQuestion() { this.type = QuestionType.Sql; }

    public List<SqlTable> Tables
    {
        get { return tables; }
        set { tables = value; }
    }

    public string ExpectedResultSql
    {
        get { return expectedResultSql; }
        set { expectedResultSql = value; }
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        desc = (string)row["Desc"];
        
        string tablesXml = (string)row["Tables"];
        tablesXml = tablesXml.Trim("?".ToCharArray());// TODO: '?' charecter automatically added to xml like text
        tables = (List<SqlTable>)Serializer.DeSerialize(tablesXml, typeof(List<SqlTable>));
        
        expectedResultSql = (string)row["ExpectedResult"];

        string[] cats = ((string)row["Categories"]).Split("~".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        categories = new List<string>(cats);

        difficultyLevel = (uint)row["DifficultyLevel"];
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "SQL";
        cmd.Sql = String.Format("REPLACE INTO `q_sql` VALUES({0}, @AdminId, @Desc, @Tables, @ExpectedResult, @Categories, @DifficultyLevel, @DateTimeCreated, @DateTimeModified, @Deleted)", (id == uint.MaxValue ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@Tables", MySqlDbType.Text, Serializer.Serialize(tables, typeof(List<SqlTable>)));
        Db.AddParam(cmd, "@ExpectedResult", MySqlDbType.Text, expectedResultSql);
        Db.AddParam(cmd, "@Categories", MySqlDbType.VarChar, String.Join("~", categories.ToArray()));
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("q_sql", "a_sql", "QuestionId");
    }
}

public class ProgrammingQuestion : QuestionBase
{
    public ProgrammingQuestion() { this.type = QuestionType.Programming; }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        desc = (string)row["Desc"];
        string[] cats = ((string)row["Categories"]).Split("~".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        categories = new List<string>(cats);
        difficultyLevel = (uint)row["DifficultyLevel"];
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Programming";
        cmd.Sql = String.Format("REPLACE INTO `q_programming` VALUES({0}, @AdminId, @Desc, @Categories, @DifficultyLevel, @DateTimeCreated, @DateTimeModified, @Deleted)", (id == uint.MaxValue ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@Categories", MySqlDbType.VarChar, String.Join("~", categories.ToArray()));
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("q_programming", "a_programming", "QuestionId");
    }
}

#region Auto Programming
public class AutoProgrammingQuestion : QuestionBase
{
    private AutoQuestionSignatureConfig config = new AutoQuestionSignatureConfig();
    private List<AutoQuestionTestCase> testCases = new List<AutoQuestionTestCase>();

    public AutoProgrammingQuestion() { this.type = QuestionType.AutoProgramming; }

    public AutoQuestionSignatureConfig Config
    {
        get { return config; }
        set { config = value; }
    }

    public List<AutoQuestionTestCase> TestCases
    {
        get { return testCases; }
        set { testCases = value; }
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        desc = (string)row["Desc"];

        // ReturnType|FunctionName|arg^argName#arg^argName
        string rawConfig = (string)row["Config"];
        config.UpdateConfig(rawConfig);
        
        // AllowedInTestMode|ExpectedValue|input1^input2#AllowedInTestCase|ExpectedValue|input1^input2
        string  rawTestCases = (string)row["TestCases"];
        if (String.IsNullOrEmpty(rawTestCases) == false)
        {
            string[] testCasesList = rawTestCases.Split("#".ToCharArray());
            foreach (string testCase in testCasesList)
            {
                AutoQuestionTestCase autoQuestionTestCase= new AutoQuestionTestCase ();
                autoQuestionTestCase.UpdateTestCase(testCase);

                TestCases.Add(autoQuestionTestCase);
            }
        }

        string[] cats = ((string)row["Categories"]).Split("~".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        categories = new List<string>(cats);
        difficultyLevel = (uint)row["DifficultyLevel"];
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "AutoProgramming";
        cmd.Sql = String.Format("REPLACE INTO `q_auto_programming` VALUES({0}, @AdminId, @Desc, @Config, @TestCases, @Categories, @DifficultyLevel, @DateTimeCreated, @DateTimeModified, @Deleted)", (id == uint.MaxValue ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);

        // Encoded config
        Db.AddParam(cmd, "@Config", MySqlDbType.Text, config.ToString());

        // Encoded testcases list
        List<string> testCasesList = new List<string>();
        foreach (AutoQuestionTestCase testCase in testCases)
        {
            testCasesList.Add(testCase.ToString());
        }
        Db.AddParam(cmd, "@TestCases", MySqlDbType.Text, String.Join("#", testCasesList.ToArray()));
        
        Db.AddParam(cmd, "@Categories", MySqlDbType.VarChar, String.Join("~", categories.ToArray()));
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("q_auto_programming", "a_auto_programming", "QuestionId");
    }
}

public class AutoQuestionTestCase
{
    private bool isAllowedInTestMode = true; // true - Test cases available during test, false - Test cases will not be available during test, only available at the backend
    private string expectedValue = string.Empty;
    private List<string> inputValues = new List<string>();

    public bool IsAllowedInTestMode
    {
        get { return isAllowedInTestMode; }
        set { isAllowedInTestMode = value; }
    }

    public string ExpectedValue
    {
        get { return expectedValue; }
        set { expectedValue = value; }
    }

    public List<string> InputValues
    {
        get { return inputValues; }
        set { inputValues = value; }
    }

    internal void UpdateTestCase(string testCase)
    {
        string[] testCaseParts = testCase.Split("|".ToCharArray());
        this.IsAllowedInTestMode = testCaseParts[0] == "1";
        this.ExpectedValue = testCaseParts[1];

        string[] inputs = testCaseParts[2].Split("^".ToCharArray());
        this.InputValues.AddRange(inputs);
    }

    public override string ToString()
    {
        return (isAllowedInTestMode ? "1" : "0") + "|" + expectedValue + "|" + String.Join("^", inputValues.ToArray());
    }
}

public class AutoQuestionSignatureConfig
{
    private AutoQuestionValueType returnType;
    private string functionName;
    private List<FunctionInput> inputs = new List<FunctionInput>();

    public AutoQuestionValueType ReturnType
    {
        get { return returnType; }
        set { returnType = value; }
    }

    public string FunctionName
    {
        get { return functionName; }
        set { functionName = value; }
    }

    public List<FunctionInput> Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    internal void UpdateConfig(string config)
    {
        if (String.IsNullOrEmpty(config) == false)
        {
            string[] configItems = config.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            this.ReturnType = (AutoQuestionValueType)Enum.Parse(typeof(AutoQuestionValueType), configItems[0]);
            this.FunctionName = configItems[1];

            string[] parameters = configItems[2].Split("#".ToCharArray());
            foreach (string parameter in parameters)
            {
                string[] parameterParts = parameter.Split("^".ToCharArray());
                FunctionInput input = new FunctionInput();
                input.ArgType = (AutoQuestionValueType)Enum.Parse(typeof(AutoQuestionValueType), parameterParts[0]);
                input.Name = parameterParts[1];

                this.Inputs.Add(input);
            }
        }
    }

    public override string ToString()
    {
        List<string> args = new List<string>();
        foreach (FunctionInput arg in inputs)
        {
            args.Add(arg.ToString());
        }
        return returnType.ToString() + "|" + functionName + "|" + String.Join("#", args.ToArray());
    }
}

public class FunctionInput
{
    private AutoQuestionValueType argType;
    private string name;

    public AutoQuestionValueType ArgType
    {
        get { return argType; }
        set { argType = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return argType + "^" + name;
    }
}
#endregion

public class WebProgrammingQuestion : QuestionBase
{
    public WebProgrammingQuestion() { this.type = QuestionType.WebProgramming; }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        desc = (string)row["Desc"];
        string[] cats = ((string)row["Categories"]).Split("~".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        categories = new List<string>(cats);
        difficultyLevel = (uint)row["DifficultyLevel"];
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "WebProgramming";
        cmd.Sql = String.Format("REPLACE INTO `q_webprogramming` VALUES({0}, @AdminId, @Desc, @Categories, @DifficultyLevel, @DateTimeCreated, @DateTimeModified, @Deleted)", (id == uint.MaxValue ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@Categories", MySqlDbType.VarChar, String.Join("~", categories.ToArray()));
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("q_webprogramming", "a_webprogramming", "QuestionId");
    }
}

public class QuestionCategory : ServiceDataBase
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    internal void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        name = (string)row["Name"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        // Update paper table
        bool tempIdSet = String.IsNullOrEmpty(tempId) == false;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Category";
        cmd.Sql = String.Format("REPLACE INTO `category` VALUES({0}, @AdminId, @Name)", (tempIdSet ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Name", MySqlDbType.VarChar, name);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Category";
        cmd.Sql = String.Format("DELETE FROM `category` WHERE Id=@Id AND AdminId=@AdminId");
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);

        return cmd;
    }
}

public class QuestionLevel : ServiceDataBase
{
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    internal void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        description = (string)row["Description"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        // Update paper table
        bool tempIdSet = String.IsNullOrEmpty(tempId) == false;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "DifficultyLevel";
        cmd.Sql = String.Format("REPLACE INTO `difficulty_level` VALUES({0}, @AdminId, @Description)", (tempIdSet ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Description", MySqlDbType.VarChar, description);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "DifficultyLevel";
        cmd.Sql = String.Format("DELETE FROM `difficulty_level` WHERE Id=@Id AND AdminId=@AdminId");
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);

        return cmd;
    }
}

[Serializable]
public class SqlTable
{
    private string tableName;
    private string createTableSql;
    private string tableDataSql;

    public string TableName
    {
        get { return tableName; }
        set { tableName = value; }
    }

    public string CreateTableSql
    {
        get { return createTableSql; }
        set { createTableSql = value; }
    }

    public string TableDataSql
    {
        get { return tableDataSql; }
        set { tableDataSql = value; }
    }
}

public class WebNode
{
    private WebNodeType type;
    private string name;
    private string content;
    private List<WebNode> nodes = new List<WebNode>();

    public WebNodeType Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<WebNode> Nodes
    {
        get { return nodes; }
        set { nodes = value; }
    }

    public string Content
    {
        get { return content; }
        set { content = value; }
    }
}

public class Paper : ServiceDataBase
{
    private string name;
    private string desc;
    private string questionIds; // Id|Type|Index
    private DateTime dateTimeCreated;
    private DateTime dateTimeModified;
    private bool isAuto;
    private bool deleted;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public string QuestionIds
    {
        get { return questionIds; }
        set { questionIds = value; }
    }

    public DateTime DateCreated
    {
        get { return dateTimeCreated; }
        set { dateTimeCreated = value; }
    }

    public DateTime DateModified
    {
        get { return dateTimeModified; }
        set { dateTimeModified = value; }
    }

    public bool IsAuto
    {
        get { return isAuto; }
        set { isAuto = value; }
    }

    public bool Deleted
    {
        get { return deleted; }
        set { deleted = value; }
    }

    internal void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        name = (string)row["Name"];
        desc = (string)row["Desc"];
        questionIds = (string)row["QuestionIds"]; // QuestionId|QuestionType|Index,QuestionId|QuestionType|Index
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
        isAuto = (bool)row["Auto"];
        deleted = (bool)row["Deleted"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        // Update paper table
        bool tempIdSet = String.IsNullOrEmpty(tempId) == false;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Paper";
        cmd.Sql = String.Format("REPLACE INTO `paper` VALUES({0}, @AdminId, @Name, @Desc, @QuestionIds, @DateTimeCreated, @DateTimeModified, @Auto, @Deleted)", (tempIdSet ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Name", MySqlDbType.VarChar, name);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@QuestionIds", MySqlDbType.Text, questionIds);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, dateTimeModified);
        Db.AddParam(cmd, "@Auto", MySqlDbType.Int16, isAuto);
        Db.AddParam(cmd, "@Deleted", MySqlDbType.Int16, deleted);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        return base.GetRemoveQuery("paper", "testschedule", "PaperId");
    }
}

public class AutoPaper : ServiceDataBase
{
    private string name;
    private string desc;
    private string configs; // Id|Type|Index
    private DateTime dateTimeCreated;
    private DateTime dateTimeModified;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public string Configs
    {
        get { return configs; }
        set { configs = value; }
    }

    public DateTime DateCreated
    {
        get { return dateTimeCreated; }
        set { dateTimeCreated = value; }
    }

    public DateTime DateModified
    {
        get { return dateTimeModified; }
        set { dateTimeModified = value; }
    }

    internal void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        name = (string)row["Name"];
        desc = (string)row["Desc"];
        configs = (string)row["Configs"]; // QuestionType|Count|DifficultyLevel|Category~QuestionType|Count|DifficultyLevel|Category
        dateTimeCreated = (DateTime)row["DateTimeCreated"];
        dateTimeModified = (DateTime)row["DateTimeModified"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        // Update paper table
        bool tempIdSet = String.IsNullOrEmpty(tempId) == false;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Paper_Auto";
        cmd.Sql = String.Format("REPLACE INTO `paper_auto` VALUES({0}, @AdminId, @Name, @Desc, @Configs, @DateTimeCreated, @DateTimeModified)", (tempIdSet ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@Name", MySqlDbType.VarChar, name);
        Db.AddParam(cmd, "@Desc", MySqlDbType.Text, desc);
        Db.AddParam(cmd, "@Configs", MySqlDbType.Text, configs);
        Db.AddParam(cmd, "@DateTimeCreated", MySqlDbType.DateTime, dateTimeCreated);
        Db.AddParam(cmd, "@DateTimeModified", MySqlDbType.DateTime, dateTimeModified);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Paper_Auto";
        cmd.Sql = String.Format("DELETE FROM `paper_auto` WHERE Id=@Id AND AdminId=@AdminId");
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);

        return cmd;
    }
}

public class TestSchedule : ServiceDataBase
{
    private uint paperId;
    private string firstName;
    private string lastName;
    private string email;
    private string password;
    private DateTime scheduleDateTime;
    private uint daysLimit;
    private uint duration;
    private DateTime testTakenDateTime;
    private TestStatus status;
    private bool liveImage = false;
    private bool webReference = false;
    private TestAnswers testAnswers;

    public uint PaperId
    {
        get { return paperId; }
        set { paperId = value; }
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

    public DateTime ScheduleDateTime
    {
        get { return scheduleDateTime; }
        set { scheduleDateTime = value; }
    }

    public uint DaysLimit
    {
        get { return daysLimit; }
        set { daysLimit = value; }
    }

    public uint Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public DateTime TestTakenDateTime
    {
        get { return testTakenDateTime; }
        set { testTakenDateTime = value; }
    }

    public TestStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public bool LiveImage
    {
        get { return liveImage; }
        set { liveImage = value; }
    }

    public bool WebReference
    {
        get { return webReference; }
        set { webReference = value; }
    }

    public TestAnswers TestAnswers
    {
        get { return testAnswers; }
        set { testAnswers = value; }
    }

    internal void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        adminId = (uint)row["AdminId"];
        paperId = (uint)row["PaperId"];
        firstName = (string)row["FirstName"];
        lastName = (string)row["LastName"];
        email = (string)row["Email"];
        password = (string)row["Password"];
        scheduleDateTime = (DateTime)row["ScheduleDateTime"];
        daysLimit = (uint)row["DaysLimit"];
        duration = (uint)row["Duration"];
        testTakenDateTime = (DateTime)row["TestTakenDateTime"];
        status = (TestStatus)((UInt16)row["Status"]);
        liveImage = (bool)row["LiveImage"];
        webReference = (bool)row["WebReference"];
    }

    internal override SQLCommand GetUpdateQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";
        cmd.Sql = String.Format("REPLACE INTO `testschedule` VALUES({0}, @AdminId, @PaperId, @FirstName, @LastName, @Email, @Password, @ScheduleDateTime, @DaysLimit, @Duration, @TestTakenDateTime, @Status, @LiveImage, @WebReference)", (String.IsNullOrEmpty(tempId) == false ? "NULL" : id.ToString()));
        // Parameters
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);
        Db.AddParam(cmd, "@PaperId", MySqlDbType.UInt32, paperId);
        Db.AddParam(cmd, "@FirstName", MySqlDbType.VarChar, firstName);
        Db.AddParam(cmd, "@LastName", MySqlDbType.VarChar, lastName);
        Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);
        Db.AddParam(cmd, "@Password", MySqlDbType.VarChar, password);
        Db.AddParam(cmd, "@ScheduleDateTime", MySqlDbType.DateTime, scheduleDateTime);
        Db.AddParam(cmd, "@DaysLimit", MySqlDbType.UInt32, daysLimit);
        Db.AddParam(cmd, "@Duration", MySqlDbType.UInt32, duration);
        Db.AddParam(cmd, "@TestTakenDateTime", MySqlDbType.DateTime, testTakenDateTime);
        Db.AddParam(cmd, "@Status", MySqlDbType.Int16, status);
        Db.AddParam(cmd, "@LiveImage", MySqlDbType.Int16, liveImage);
        Db.AddParam(cmd, "@WebReference", MySqlDbType.Int16, webReference);

        return cmd;
    }

    internal override SQLCommand GetRemoveQuery()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";
        cmd.Sql = String.Format("DELETE FROM `testschedule` WHERE Id=@Id AND AdminId=@AdminId");
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, id);
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, adminId);

        return cmd;
    }
}

public class TestImage
{
    private string name;
    private string stream;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Stream
    {
        get { return stream; }
        set { stream = value; }
    }
}

public class TestAnswers
{
    private uint testId; 

    public uint TestId
    {
        get { return testId; }
        set { testId = value; }
    }

    private List<ObjectiveQuestionTestAnswer> objectiveQuestionTestAnswers = new List<ObjectiveQuestionTestAnswer>();
    private List<SqlQuestionTestAnswer> sqlQuestionTestAnswers = new List<SqlQuestionTestAnswer>();
    private List<ProgrammingQuestionTestAnswer> programmingQuestionTestAnswers = new List<ProgrammingQuestionTestAnswer>();
    private List<AutoProgrammingQuestionTestAnswer> autoProgrammingQuestionTestAnswers = new List<AutoProgrammingQuestionTestAnswer>();
    private List<WebProgrammingQuestionTestAnswer> webPogrammingQuestionTestAnswers = new List<WebProgrammingQuestionTestAnswer>();

    public List<ObjectiveQuestionTestAnswer> ObjectiveQuestionTestAnswers
    {
        get { return objectiveQuestionTestAnswers; }
        set { objectiveQuestionTestAnswers = value; }
    }

    public List<SqlQuestionTestAnswer> SqlQuestionTestAnswers
    {
        get { return sqlQuestionTestAnswers; }
        set { sqlQuestionTestAnswers = value; }
    }

    public List<ProgrammingQuestionTestAnswer> ProgrammingQuestionTestAnswers
    {
        get { return programmingQuestionTestAnswers; }
        set { programmingQuestionTestAnswers = value; }
    }

    public List<AutoProgrammingQuestionTestAnswer> AutoProgrammingQuestionTestAnswers
    {
        get { return autoProgrammingQuestionTestAnswers; }
        set { autoProgrammingQuestionTestAnswers = value; }
    }

    public List<WebProgrammingQuestionTestAnswer> WebPogrammingQuestionTestAnswers
    {
        get { return webPogrammingQuestionTestAnswers; }
        set { webPogrammingQuestionTestAnswers = value; }
    }

    internal void Fill(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            switch (table.TableName)
            {
                case "objective":
                    ObjectiveQuestionTestAnswer objectiveQuestionAnswer = new ObjectiveQuestionTestAnswer();
                    objectiveQuestionAnswer.Fill(row);
                    objectiveQuestionTestAnswers.Add(objectiveQuestionAnswer);
                    break;
                case "sql":
                    SqlQuestionTestAnswer sqlQuestionAnswer = new SqlQuestionTestAnswer();
                    sqlQuestionAnswer.Fill(row);
                    sqlQuestionTestAnswers.Add(sqlQuestionAnswer);
                    break;
                case "programming":
                    ProgrammingQuestionTestAnswer programmingQuestionAnswer = new ProgrammingQuestionTestAnswer();
                    programmingQuestionAnswer.Fill(row);
                    programmingQuestionTestAnswers.Add(programmingQuestionAnswer);
                    break;
                case "auto_programming":
                    AutoProgrammingQuestionTestAnswer autoProgrammingQuestionAnswer = new AutoProgrammingQuestionTestAnswer();
                    autoProgrammingQuestionAnswer.Fill(row);
                    autoProgrammingQuestionTestAnswers.Add(autoProgrammingQuestionAnswer);
                    break;
                case "webprogramming":
                    WebProgrammingQuestionTestAnswer webProgrammingQuestionAnswer = new WebProgrammingQuestionTestAnswer();
                    webProgrammingQuestionAnswer.Fill(row);
                    webPogrammingQuestionTestAnswers.Add(webProgrammingQuestionAnswer);
                    break;
            }
        }
    }
}

public abstract class TestAnswerBase
{
    protected uint id;
    protected uint testId;
    protected uint questionId;
    protected QuestionType type;

    public uint Id
    {
        get { return id; }
        set { id = value; }
    }

    public uint TestId
    {
        get { return testId; }
        set { testId = value; }
    }

    public uint QuestionId
    {
        get { return questionId; }
        set { questionId = value; }
    }

    public QuestionType Type
    {
        get { return type; }
        set { type = value; }
    }

    internal abstract SQLCommand GetInsertCmd();

    internal abstract void Fill(DataRow row);
}

public class ObjectiveQuestionTestAnswer : TestAnswerBase
{
    private List<int> selectedOptions = new List<int> ();

    public List<int> SelectedOptions
    {
        get { return selectedOptions; }
        set { selectedOptions = value; }
    }

    public ObjectiveQuestionTestAnswer()
    {
        this.type = QuestionType.Objective;
    }

    internal override SQLCommand GetInsertCmd()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO a_objective VALUES(NULL, @TestId, @QuestionId, @SelectedOptions)";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);

        List<string> userSelectedOptions = new List<string> ();
        foreach (int selectedOption in selectedOptions) { userSelectedOptions.Add(selectedOption.ToString()); }
        Db.AddParam(cmd, "@SelectedOptions", MySqlDbType.VarChar, String.Join("|", userSelectedOptions.ToArray()));

        return cmd;
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        testId = (uint)row["TestId"];
        questionId = (uint)row["QuestionId"];
        string selectedOptions = (string)row["SelectedOptions"];
        string[] options = selectedOptions.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string option in options)
        {
            this.selectedOptions.Add(Int32.Parse(option));
        }
    }
}

public class SqlQuestionTestAnswer : TestAnswerBase
{
    private string sql;

    public string Sql
    {
        get { return sql; }
        set { sql = value; }
    }

    public SqlQuestionTestAnswer()
    {
        this.type = QuestionType.Sql;
    }

    internal override SQLCommand GetInsertCmd()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO a_sql VALUES(NULL, @TestId, @QuestionId, @Sql)";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);
        Db.AddParam(cmd, "@Sql", MySqlDbType.Text, sql == null ? string.Empty : sql);

        return cmd;
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        testId = (uint)row["TestId"];
        questionId = (uint)row["QuestionId"];
        sql = (string)row["Sql"];
    }
}

public class ProgrammingQuestionTestAnswer : TestAnswerBase
{
    private string code;
    private string exe;
    private string exeCode;
    private ProgrammingAnswerType answerType;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public string Exe
    {
        get { return exe; }
        set { exe = value; }
    }

    public string ExeCode
    {
        get { return exeCode; }
        set { exeCode = value; }
    }

    public ProgrammingAnswerType AnswerType
    {
        get { return answerType; }
        set { answerType = value; }
    }

    public ProgrammingQuestionTestAnswer()
    {
        this.type = QuestionType.Programming;
    }

    internal override SQLCommand GetInsertCmd()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO `a_programming` VALUES(NULL, @TestId, @QuestionId, @Code, @Exe, @ExeCode, @AnswerType)";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);
        Db.AddParam(cmd, "@Code", MySqlDbType.Text, code == null ? string.Empty : code);
        Db.AddParam(cmd, "@Exe", MySqlDbType.Text, exe == null ? string.Empty : exe);
        Db.AddParam(cmd, "@ExeCode", MySqlDbType.Text, exeCode == null ? string.Empty : exeCode);
        Db.AddParam(cmd, "@AnswerType", MySqlDbType.VarChar, answerType.ToString());

        return cmd;
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        testId = (uint)row["TestId"];
        questionId = (uint)row["QuestionId"];
        code = (string)row["Code"];
        exe = (string)row["Exe"];
        exeCode = (string)row["ExeCode"];
        answerType = (ProgrammingAnswerType)Enum.Parse(typeof(ProgrammingAnswerType), (string)row["AnswerType"]);
    }
}

public class AutoProgrammingQuestionTestAnswer : TestAnswerBase
{
    private string code;
    private string exe;
    private string exeCode;
    private ProgrammingAnswerType answerType;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public string Exe
    {
        get { return exe; }
        set { exe = value; }
    }

    public string ExeCode
    {
        get { return exeCode; }
        set { exeCode = value; }
    }

    public ProgrammingAnswerType AnswerType
    {
        get { return answerType; }
        set { answerType = value; }
    }

    public AutoProgrammingQuestionTestAnswer()
    {
        this.type = QuestionType.AutoProgramming;
    }

    internal override SQLCommand GetInsertCmd()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO `a_auto_programming` VALUES(NULL, @TestId, @QuestionId, @Code, @Exe, @ExeCode, @AnswerType)";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);
        Db.AddParam(cmd, "@Code", MySqlDbType.Text, code == null ? string.Empty : code);
        Db.AddParam(cmd, "@Exe", MySqlDbType.Text, exe == null ? string.Empty : exe);
        Db.AddParam(cmd, "@ExeCode", MySqlDbType.Text, exeCode == null ? string.Empty : exeCode);
        Db.AddParam(cmd, "@AnswerType", MySqlDbType.VarChar, answerType.ToString());

        return cmd;
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        testId = (uint)row["TestId"];
        questionId = (uint)row["QuestionId"];
        code = (string)row["Code"];
        exe = (string)row["Exe"];
        exeCode = (string)row["ExeCode"];
        answerType = (ProgrammingAnswerType)Enum.Parse(typeof(ProgrammingAnswerType), (string)row["AnswerType"]);
    }
}

public class WebProgrammingQuestionTestAnswer : TestAnswerBase
{
    private WebNode webNode;

    public WebNode WebNode
    {
        get { return webNode; }
        set { webNode = value; }
    }

    public WebProgrammingQuestionTestAnswer()
    {
        this.type = QuestionType.WebProgramming;
    }

    internal override SQLCommand GetInsertCmd()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE INTO a_webprogramming VALUES(NULL, @TestId, @QuestionId, @WebFiles)";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@QuestionId", MySqlDbType.UInt32, questionId);
        string webFiles = Serializer.Serialize(webNode, typeof(WebNode));
        Db.AddParam(cmd, "@WebFiles", MySqlDbType.Text, (String.IsNullOrEmpty(webFiles) ? "" : webFiles));

        return cmd;
    }

    internal override void Fill(DataRow row)
    {
        id = (uint)row["Id"];
        testId = (uint)row["TestId"];
        questionId = (uint)row["QuestionId"];
        string webFiles = (string)row["WebFiles"];
        webNode = (WebNode)Serializer.DeSerialize(webFiles, typeof(WebNode));
    }
}

public class TestInfo
{
    private string employerName;
    private int questionsCount;

    public string EmployerName
    {
        get { return employerName; }
        set { employerName = value; }
    }

    public int QuestionsCount
    {
        get { return questionsCount; }
        set { questionsCount = value; }
    }
}

internal class WebFileManager
{
    internal void Save(WebNode webNode, string uniqueId)
    {
        string path = String.Format(@"C:\Inetpub\subdomains\WebProgramming\{0}\", uniqueId);
        if (Directory.Exists(path)) Directory.Delete(path, true);
        if (Directory.Exists(path) == false) Directory.CreateDirectory(path);

        SaveNode(webNode, path);
    }

    private void SaveNode(WebNode webNode, string path)
    {
        foreach (WebNode node in webNode.Nodes)
        {
            if (node.Type == WebNodeType.Directory)
            {
                string dir = path + node.Name + Path.DirectorySeparatorChar;
                Directory.CreateDirectory(dir);
                SaveNode(node, dir);
            }
            else
            {
                string filename = path + node.Name;
                File.WriteAllText(filename, node.Content);
            }
        }
    }
}

internal static class DemoAccounts
{
    private static List<string> accounts = new List<string>();

    public static List<string> Accounts
    {
        get { return accounts; }
    }

    static DemoAccounts()
    {
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = @"SELECT * FROM demo_accounts";
        cmd.TableName = "DemoAccounts";

        DataSet dsDemoAccounts = (new Db()).GetDataset(cmd);
        if (dsDemoAccounts != null && dsDemoAccounts.Tables.Contains("DemoAccounts") && dsDemoAccounts.Tables["DemoAccounts"].Rows.Count > 0)
        {
            foreach (DataRow row in dsDemoAccounts.Tables["DemoAccounts"].Rows)
            {
                string email = (string)row["Email"];
                accounts.Add(email);
            }
        }
    }
}

public class AdminManager
{
#if LIVE
    private uint pageSize = 25;
#else
    private uint pageSize = 2;
#endif

    #region Manage users
    public UserInfo Authenticate(string email, string password)
    {
        return UserManager.Authenticate(email, password);
    }

    public UserInfo UpdateUserInfo(UserInfo userInfo)
    {
        return UserManager.UpdateUserInfo(userInfo);
    }

    public bool ForgotPassword(string email)
    {
        return UserManager.ForgotPassword(email);
    }

    public bool CheckUserExists(string email)
    {
        return UserManager.CheckUserExists(email);
    }

    public bool VarifyCode(string email, string code)
    {
        bool correct = false;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "SELECT * FROM `varificationcode` WHERE Email=@email";
        cmd.TableName = "varify";
        Db.AddParam(cmd, "@email", MySqlDbType.VarChar, email);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("varify") && ds.Tables["varify"].Rows.Count != 0)
        {
            string actualCode = (string)ds.Tables["varify"].Rows[0]["Code"];
            correct = actualCode.Equals(code, StringComparison.OrdinalIgnoreCase);
            if (correct)
            {
                // Update user table
                SQLCommand userCmd = new SQLCommand();
                userCmd.Sql = "UPDATE `user` SET Varified = 1 WHERE Email=@email";
                userCmd.TableName = "user";
                Db.AddParam(userCmd, "@email", MySqlDbType.VarChar, email);

                (new Db()).ExecuteNonQuery(userCmd);
                if (userCmd.RowsAffected < 1)
                {
                    // TODO: error handling
                }
                // update if it is in cache
                UserManager.Users[email].Varified = true;
            }
        }

        return correct;
    }

    public bool CreateNewCode(string email)
    {
        string code = UserManager.CreateNewVarificationCode(email);
        Postman.Send_NewVarificationCode_Mail(email, code);
        return true;
    }

    public List<UserExtension> GetUserExtensions(User user)
    {
        List<UserExtension> extensions = new List<UserExtension>();

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "UserExtension";
        cmd.Sql = "SELECT * FROM `userextension` WHERE AdminId=@Id";
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, user.Id);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("UserExtension") && ds.Tables["UserExtension"].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables["UserExtension"].Rows)
            {
                UserExtension userExtension = new UserExtension();
                userExtension.Fill(row);

                extensions.Add(userExtension);
            }
        }

        return extensions;
    }

    public bool UpdateUserExtension(UserExtension userExtension, User user)
    {
        if (UserManager.ValidateUser(user) == false) return false;

        SQLCommand cmd = userExtension.GetUpdateQuery();
        (new Db()).ExecuteNonQuery(cmd);

        bool success = cmd.RowsAffected > 0;
        if (success && UserManager.Users.ContainsKey(userExtension.Email))
        {
            UserManager.CacheUser(userExtension.Email);
        }

        return success;
    }

    public bool RemoveUserExtension(UserExtension userExtension, User user)
    {
        if (UserManager.ValidateUser(user) == false) return false;

        SQLCommand cmd = userExtension.GetRemoveQuery();
        (new Db()).ExecuteNonQuery(cmd);

        return cmd.RowsAffected > 0;
    }

    #endregion

    #region Question categories
    public List<QuestionCategory> GetQuestionCategories(User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "QuestionCategory";
        cmd.Sql = "SELECT * FROM `category` WHERE AdminId=@Id";
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, user.Id);

        List<QuestionCategory> categories = new List<QuestionCategory>();
        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("QuestionCategory") && ds.Tables["QuestionCategory"].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables["QuestionCategory"].Rows)
            {
                QuestionCategory questionCategory = new QuestionCategory();
                questionCategory.Fill(row);

                categories.Add(questionCategory);
            }
        }

        return categories;
    }

    public QuestionCategory UpdateQuestionCategory(QuestionCategory category, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = category.GetUpdateQuery();
        cmd.TempId = category.TempId;
        (new Db()).ExecuteNonQuery(cmd);
        if (String.IsNullOrEmpty(category.TempId) == false && cmd.RowsAffected > 0)
        {
            category.Id = (uint)cmd.InsertId;
            category.TempId = string.Empty;
        }

        return category;
    }

    public QuestionCategory RemoveQuestionCategory(QuestionCategory category, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(category.GetRemoveQuery());
        return category;
    }

    #endregion

    #region Question levels
    public List<QuestionLevel> GetQuestionLevels(User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "QuestionLevel";
        cmd.Sql = "SELECT * FROM `difficulty_level` WHERE AdminId=@Id";
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, user.Id);

        List<QuestionLevel> levels = new List<QuestionLevel>();
        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("QuestionLevel") && ds.Tables["QuestionLevel"].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables["QuestionLevel"].Rows)
            {
                QuestionLevel questionLevel = new QuestionLevel();
                questionLevel.Fill(row);

                levels.Add(questionLevel);
            }
        }

        return levels;
    }

    public QuestionLevel UpdateQuestionLevel(QuestionLevel questionLevel, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = questionLevel.GetUpdateQuery();
        cmd.TempId = questionLevel.TempId;
        (new Db()).ExecuteNonQuery(cmd);
        if (String.IsNullOrEmpty(questionLevel.TempId) == false && cmd.RowsAffected > 0)
        {
            questionLevel.Id = (uint)cmd.InsertId;
            questionLevel.TempId = string.Empty;
        }

        return questionLevel;
    }

    public QuestionLevel RemoveQuestionLevel(QuestionLevel questionLevel, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(questionLevel.GetRemoveQuery());
        return questionLevel;
    }
    #endregion

    #region Get / Update / Remove auto papers
    public List<AutoPaper> GetAutoPapers(User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Paper_Auto";
        cmd.Sql = "SELECT * FROM `paper_auto` WHERE AdminId=@Id";
        // Parameters
        Db.AddParam(cmd, "@Id", MySqlDbType.UInt32, user.Id);

        List<AutoPaper> autoPapers = new List<AutoPaper>();
        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("Paper_Auto") && ds.Tables["Paper_Auto"].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables["Paper_Auto"].Rows)
            {
                AutoPaper autoPaper = new AutoPaper();
                autoPaper.Fill(row);

                autoPapers.Add(autoPaper);
            }
        }

        return autoPapers;
    }

    public AutoPaper UpdateAutoPaper(AutoPaper paper, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = paper.GetUpdateQuery();
        cmd.TempId = paper.TempId;
        (new Db()).ExecuteNonQuery(cmd);
        if (String.IsNullOrEmpty(paper.TempId) == false && cmd.RowsAffected > 0)
        {
            paper.Id = (uint)cmd.InsertId;
            paper.TempId = string.Empty;
        }

        return paper;
    }

    public AutoPaper RemoveAutoPaper(AutoPaper paper, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(paper.GetRemoveQuery());
        return paper;
    }

    public long GetQuestionsCountByCategoryLevelType(QuestionType questionType, uint count, uint category, uint difficultyLevel, User user)
    {
        if (UserManager.ValidateUser(user) == false) return 0;

        string tableName = string.Empty;
        switch (questionType)
        {
            case QuestionType.Objective: tableName = "q_objective"; break;
            case QuestionType.Programming: tableName = "q_programming"; break;
            case QuestionType.Sql: tableName = "q_sql"; break;
            case QuestionType.WebProgramming: tableName = "q_webprogramming"; break;
        }

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "GetQuestionsCount";
        cmd.Sql = String.Format("SELECT COUNT(*) FROM {0} WHERE AdminId = @AdminId AND (Categories = {1} OR Categories LIKE '%~{1}%' OR Categories LIKE '%{1}~%' OR Categories LIKE '%~{1}~%') AND DifficultyLevel=@DifficultyLevel AND Deleted = 0", tableName, category.ToString());
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);
        Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("GetQuestionsCount") && ds.Tables["GetQuestionsCount"].Rows.Count == 1)
        {
            return (long)ds.Tables["GetQuestionsCount"].Rows[0][0];
        }

        return 0;
    }

    public Paper CreatePaperByAutoPaper(AutoPaper paper, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        List<string> questionIds = new List<string>();

        string[] configs = paper.Configs.Split("~".ToCharArray());
        foreach (string config in configs)
        {
            // Extract config
            string[] items = config.Split("|".ToCharArray());
            QuestionType questionType = (QuestionType)Enum.Parse(typeof(QuestionType), items[0]);
            uint count = Convert.ToUInt32(items[1]);
            uint difficultyLevel = Convert.ToUInt32(items[2]);
            uint category = Convert.ToUInt32(items[3]);

            string tableName = string.Empty;
            switch (questionType)
            {
                case QuestionType.Objective: tableName = "q_objective"; break;
                case QuestionType.Programming: tableName = "q_programming"; break;
                case QuestionType.Sql: tableName = "q_sql"; break;
                case QuestionType.WebProgramming: tableName = "q_webprogramming"; break;
            }

            // Get question ids from database for the corresponding table name, category and difficulty level
            SQLCommand cmd = new SQLCommand();
            cmd.TableName = "QuestionIds";
            cmd.Sql = String.Format("SELECT Id FROM {0} WHERE AdminId = @AdminId AND Categories = @Category AND DifficultyLevel=@DifficultyLevel AND Deleted = 0", tableName);
            Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);
            Db.AddParam(cmd, "@Category", MySqlDbType.VarChar, category.ToString());
            Db.AddParam(cmd, "@DifficultyLevel", MySqlDbType.UInt32, difficultyLevel);

            List<uint> ids = new List<uint>();

            DataSet ds = (new Db()).GetDataset(cmd);
            if (ds != null && ds.Tables.Contains("QuestionIds") && ds.Tables["QuestionIds"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables["QuestionIds"].Rows)
                {
                    uint id = (uint)row["Id"];
                    ids.Add(id);
                }
            }

            // TODO: check for repeated questions

            // TODO: what if count from database does not match with config count

            // Get random ids
            List<int> randomIds = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                while (true) // Dangerous !!!!!!!
                {
                    int index = random.Next(0, ids.Count);
                    if (randomIds.Contains(index) == false)
                    {
                        randomIds.Add((int)ids[index]);
                        break;
                    }
                }
            }

            // Frame QuestionIds
            string questionId = string.Empty;
            foreach (int id in randomIds)
            {
                questionId = id + "|" + questionType + "|" + "0";
                questionIds.Add(questionId);
            }
        }

        // Create new paper
        Paper newPaper = new Paper();
        newPaper.AdminId = user.Id;
        newPaper.TempId = Guid.NewGuid().ToString().Replace("-", "");
        newPaper.Name = newPaper.Desc = Guid.NewGuid().ToString();
        newPaper.QuestionIds = String.Join(",", questionIds.ToArray());
        newPaper.IsAuto = true;

        // Add to database
        newPaper = UpdatePaper(newPaper, user);

        return newPaper;
    }

    #endregion

    #region Get / Update / Remove questions
    public uint GetNumberOfQuestionPages(User user)
    {
        if (UserManager.ValidateUser(user) == false) return 0;

        uint questionsCount = 0;
        questionsCount += GetQuestionsCount(QuestionType.Objective, user.Id);
        questionsCount += GetQuestionsCount(QuestionType.Sql, user.Id);
        questionsCount += GetQuestionsCount(QuestionType.Programming, user.Id);
        questionsCount += GetQuestionsCount(QuestionType.AutoProgramming, user.Id);
        questionsCount += GetQuestionsCount(QuestionType.WebProgramming, user.Id);

        return (uint)Math.Ceiling(questionsCount / (double)pageSize);
    }

    public uint GetNumberOfQuestionPagesByQuestionType(QuestionType questionType, User user)
    {
        if (UserManager.ValidateUser(user) == false) return 0;

        uint questionsCount = GetQuestionsCount(questionType, user.Id);

        return (uint)Math.Ceiling(questionsCount / (double)pageSize);
    }

    private uint GetQuestionsCount(QuestionType questionType, uint userId)
    {
        long count = 0;

        string tableName = string.Empty;
        switch (questionType)
        {
            case QuestionType.Objective: tableName = "q_objective"; break;
            case QuestionType.Sql: tableName = "q_sql"; break;
            case QuestionType.Programming: tableName = "q_programming"; break;
            case QuestionType.AutoProgramming: tableName = "q_auto_programming"; break;
            case QuestionType.WebProgramming: tableName = "q_webprogramming"; break;
        }

        string sql = String.Format("SELECT COUNT(*) FROM {0} WHERE AdminId = @AdminId AND Deleted = 0", tableName);

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "Questions";
        cmd.Sql = sql;
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, userId);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("Questions") && ds.Tables["Questions"].Rows.Count == 1)
        {
            count = (long)ds.Tables["Questions"].Rows[0][0];
        }

        return (uint)count;
    }

    public Questions GetQuestions(uint index, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        Questions questions = new Questions();

        FillQuestions(user.Id, questions, QuestionType.Objective, 0, 10000);

        FillQuestions(user.Id, questions, QuestionType.Sql, 0, 10000);

        FillQuestions(user.Id, questions, QuestionType.Programming, 0, 10000);

        FillQuestions(user.Id, questions, QuestionType.AutoProgramming, 0, 10000);

        FillQuestions(user.Id, questions, QuestionType.WebProgramming, 0, 10000);

        // TODO: Slow method. Optimize
        int startIndex = (int)pageSize * (int)index;
        List<QuestionBase> allQuestions = new List<QuestionBase>();
        allQuestions.AddRange(questions.ObjectiveQuestions.ToArray());
        allQuestions.AddRange(questions.SQLQuestions.ToArray());
        allQuestions.AddRange(questions.ProgrammingQuestions.ToArray());
        allQuestions.AddRange(questions.AutoProgrammingQuestions.ToArray());
        allQuestions.AddRange(questions.WebProgrammingQuestions.ToArray());
        
        Questions filteredQuestions = new Questions();
        for (int i = startIndex; i < allQuestions.Count && i < startIndex + pageSize; i++)
        {
            switch (allQuestions[i].Type)
            {
                case QuestionType.Objective:
                    filteredQuestions.ObjectiveQuestions.Add((ObjectiveQuestion)allQuestions[i]);
                    break;
                case QuestionType.Sql:
                    filteredQuestions.SQLQuestions.Add((SqlQuestion)allQuestions[i]);
                    break;
                case QuestionType.Programming:
                    filteredQuestions.ProgrammingQuestions.Add((ProgrammingQuestion)allQuestions[i]);
                    break;
                case QuestionType.AutoProgramming:
                    filteredQuestions.AutoProgrammingQuestions.Add((AutoProgrammingQuestion)allQuestions[i]);
                    break;
                case QuestionType.WebProgramming:
                    filteredQuestions.WebProgrammingQuestions.Add((WebProgrammingQuestion)allQuestions[i]);
                    break;
            }
        }

        return filteredQuestions;
    }

    public Questions GetQuestions(QuestionType questionType, uint index, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        
        Questions questions = new Questions ();
        
        FillQuestions(user.Id, questions, questionType, index);

        return questions;
    }

    private Questions FillQuestions(uint userId, Questions question, QuestionType questionType, uint index)
    {
        return FillQuestions(userId, question, questionType, index, pageSize);
    }

    private Questions FillQuestions(uint userId, Questions questions, QuestionType questionType, uint index, uint pageSize)
    {
        uint startIndex = pageSize * index;

        switch (questionType)
        {
            case QuestionType.Objective:
                SQLCommand objectiveQuestionCmd = new SQLCommand();
                objectiveQuestionCmd.Sql = String.Format("SELECT * FROM q_objective WHERE AdminId = {0} AND Deleted = 0 LIMIT {1}, {2}", userId, startIndex, pageSize);
                objectiveQuestionCmd.TableName = "objective";

                DataSet dsObjectiveQuestions = (new Db()).GetDataset(objectiveQuestionCmd);
                if (dsObjectiveQuestions != null)
                {
                    if (dsObjectiveQuestions.Tables.Contains("objective")) { questions.Fill(dsObjectiveQuestions.Tables["objective"]); }
                }
                break;
            case QuestionType.Sql:
                SQLCommand sqlQuestionCmd = new SQLCommand();
                sqlQuestionCmd.Sql = String.Format("SELECT * FROM q_sql WHERE AdminId = {0} AND Deleted = 0 LIMIT {1}, {2}", userId, startIndex, pageSize);
                sqlQuestionCmd.TableName = "sql";

                DataSet dsSqlQuestions = (new Db()).GetDataset(sqlQuestionCmd);
                if (dsSqlQuestions != null)
                {
                    if (dsSqlQuestions.Tables.Contains("sql")) { questions.Fill(dsSqlQuestions.Tables["sql"]); }
                }
                break;
            case QuestionType.Programming:
                SQLCommand programmingQuestionCmd = new SQLCommand();
                programmingQuestionCmd.Sql = String.Format("SELECT * FROM q_programming WHERE AdminId = {0} AND Deleted = 0 LIMIT {1}, {2}", userId, startIndex, pageSize);
                programmingQuestionCmd.TableName = "programming";

                DataSet dsProgrammingQuestions = (new Db()).GetDataset(programmingQuestionCmd);
                if (dsProgrammingQuestions != null)
                {
                    if (dsProgrammingQuestions.Tables.Contains("programming")) { questions.Fill(dsProgrammingQuestions.Tables["programming"]); }
                }
                break;
            case QuestionType.AutoProgramming:
                SQLCommand autoProgrammingQuestionCmd = new SQLCommand();
                autoProgrammingQuestionCmd.Sql = String.Format("SELECT * FROM q_auto_programming WHERE AdminId = {0} AND Deleted = 0 LIMIT {1}, {2}", userId, startIndex, pageSize);
                autoProgrammingQuestionCmd.TableName = "auto_programming";

                DataSet dsAutoProgrammingQuestions = (new Db()).GetDataset(autoProgrammingQuestionCmd);
                if (dsAutoProgrammingQuestions != null)
                {
                    if (dsAutoProgrammingQuestions.Tables.Contains("auto_programming")) { questions.Fill(dsAutoProgrammingQuestions.Tables["auto_programming"]); }
                }
                break;
            case QuestionType.WebProgramming:
                SQLCommand webProgrammingQuestionCmd = new SQLCommand();
                webProgrammingQuestionCmd.Sql = String.Format("SELECT * FROM q_webprogramming WHERE AdminId = {0} AND Deleted = 0 LIMIT {1}, {2}", userId, startIndex, pageSize);
                webProgrammingQuestionCmd.TableName = "webprogramming";

                DataSet dsWebProgrammingQuestions = (new Db()).GetDataset(webProgrammingQuestionCmd);
                if (dsWebProgrammingQuestions != null)
                {
                    if (dsWebProgrammingQuestions.Tables.Contains("webprogramming")) { questions.Fill(dsWebProgrammingQuestions.Tables["webprogramming"]); }
                }
                break;
        }

        return questions;
    }

    public ObjectiveQuestion LoadObjectiveQuestion(uint id, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        ObjectiveQuestion question = new ObjectiveQuestion ();

        SQLCommand objectiveQuestionCmd = new SQLCommand();
        objectiveQuestionCmd.Sql = String.Format("SELECT * FROM q_objective WHERE AdminId = {0} AND Id = {1} AND Deleted = 0", user.Id, id);
        objectiveQuestionCmd.TableName = "objective";

        DataSet dsObjectiveQuestions = (new Db()).GetDataset(objectiveQuestionCmd);
        if (dsObjectiveQuestions != null && dsObjectiveQuestions.Tables.Contains("objective") && dsObjectiveQuestions.Tables["objective"].Rows.Count > 0)
        {
            question.Fill(dsObjectiveQuestions.Tables["objective"].Rows[0]);            
        }

        return question;
    }

    public ObjectiveQuestion UpdateObjectiveQuestion(ObjectiveQuestion objectiveQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        return UpdateQuestion<ObjectiveQuestion>(objectiveQuestion);
    }

    public ObjectiveQuestion RemoveObjectiveQuestion(ObjectiveQuestion objectiveQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(objectiveQuestion.GetRemoveQuery());
        return objectiveQuestion;
    }

    public SqlQuestion LoadSqlQuestion(uint id, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SqlQuestion question = new SqlQuestion();

        SQLCommand sqlQuestionCmd = new SQLCommand();
        sqlQuestionCmd.Sql = String.Format("SELECT * FROM q_sql WHERE AdminId = {0} AND Id = {1} AND Deleted = 0", user.Id, id);
        sqlQuestionCmd.TableName = "sql";

        DataSet dsSqlQuestions = (new Db()).GetDataset(sqlQuestionCmd);
        if (dsSqlQuestions != null && dsSqlQuestions.Tables.Contains("sql") && dsSqlQuestions.Tables["sql"].Rows.Count > 0)
        {
            question.Fill(dsSqlQuestions.Tables["sql"].Rows[0]);
        }

        return question;
    }

    public SqlQuestion UpdateSqlQuestion(SqlQuestion sqlQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        return UpdateQuestion<SqlQuestion>(sqlQuestion);
    }

    public SqlQuestion RemoveSqlQuestion(SqlQuestion sqlQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(sqlQuestion.GetRemoveQuery());
        return sqlQuestion;
    }

    public ProgrammingQuestion LoadProgrammingQuestion(uint id, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        ProgrammingQuestion question = new ProgrammingQuestion();

        SQLCommand programmingQuestionCmd = new SQLCommand();
        programmingQuestionCmd.Sql = String.Format("SELECT * FROM q_programming WHERE AdminId = {0} AND Id = {1} AND Deleted = 0", user.Id, id);
        programmingQuestionCmd.TableName = "programming";

        DataSet dsProgrammingQuestions = (new Db()).GetDataset(programmingQuestionCmd);
        if (dsProgrammingQuestions != null && dsProgrammingQuestions.Tables.Contains("programming") && dsProgrammingQuestions.Tables["programming"].Rows.Count > 0)
        {
            question.Fill(dsProgrammingQuestions.Tables["programming"].Rows[0]);
        }

        return question;
    }

    public ProgrammingQuestion UpdateProgrammingQuestion(ProgrammingQuestion programmingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        return UpdateQuestion<ProgrammingQuestion>(programmingQuestion);
    }

    public ProgrammingQuestion RemoveProgrammingQuestion(ProgrammingQuestion programmingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(programmingQuestion.GetRemoveQuery());
        return programmingQuestion;
    }

    public AutoProgrammingQuestion LoadAutoProgrammingQuestion(uint id, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        AutoProgrammingQuestion question = new AutoProgrammingQuestion();

        SQLCommand autoProgrammingQuestionCmd = new SQLCommand();
        autoProgrammingQuestionCmd.Sql = String.Format("SELECT * FROM q_auto_programming WHERE AdminId = {0} AND Id = {1} AND Deleted = 0", user.Id, id);
        autoProgrammingQuestionCmd.TableName = "auto_programming";

        DataSet dsAutoProgrammingQuestions = (new Db()).GetDataset(autoProgrammingQuestionCmd);
        if (dsAutoProgrammingQuestions != null && dsAutoProgrammingQuestions.Tables.Contains("auto_programming") && dsAutoProgrammingQuestions.Tables["auto_programming"].Rows.Count > 0)
        {
            question.Fill(dsAutoProgrammingQuestions.Tables["auto_programming"].Rows[0]);
        }

        return question;
    }

    public AutoProgrammingQuestion UpdateAutoProgrammingQuestion(AutoProgrammingQuestion autoProgrammingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        return UpdateQuestion<AutoProgrammingQuestion>(autoProgrammingQuestion);
    }

    public AutoProgrammingQuestion RemoveAutoProgrammingQuestion(AutoProgrammingQuestion autoProgrammingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(autoProgrammingQuestion.GetRemoveQuery());
        return autoProgrammingQuestion;
    }

    public WebProgrammingQuestion LoadWebProgrammingQuestion(uint id, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        WebProgrammingQuestion question = new WebProgrammingQuestion();

        SQLCommand webProgrammingQuestionCmd = new SQLCommand();
        webProgrammingQuestionCmd.Sql = String.Format("SELECT * FROM q_webprogramming WHERE AdminId = {0} AND Id = {1} AND Deleted = 0", user.Id, id);
        webProgrammingQuestionCmd.TableName = "web_programming";

        DataSet dsWebProgrammingQuestions = (new Db()).GetDataset(webProgrammingQuestionCmd);
        if (dsWebProgrammingQuestions != null && dsWebProgrammingQuestions.Tables.Contains("web_programming") && dsWebProgrammingQuestions.Tables["web_programming"].Rows.Count > 0)
        {
            question.Fill(dsWebProgrammingQuestions.Tables["web_programming"].Rows[0]);
        }

        return question;
    }

    public WebProgrammingQuestion UpdateWebProgrammingQuestion(WebProgrammingQuestion webProgrammingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        return UpdateQuestion<WebProgrammingQuestion>(webProgrammingQuestion);
    }

    public WebProgrammingQuestion RemoveWebProgrammingQuestion(WebProgrammingQuestion webProgrammingQuestion, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;
        (new Db()).ExecuteNonQuery(webProgrammingQuestion.GetRemoveQuery());
        return webProgrammingQuestion;
    }

    private T UpdateQuestion<T>(T question) where T : QuestionBase
    {
        SQLCommand cmd = question.GetUpdateQuery();
        cmd.TempId = question.TempId;
        (new Db()).ExecuteNonQuery(cmd);

        if (String.IsNullOrEmpty(question.TempId) == false)
        {
            question.Id = (uint)cmd.InsertId;
            question.TempId = string.Empty;
        }

        return question;
    }
    #endregion

    #region Get / Update / Remove papers
    public List<Paper> GetPapers(User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = @"SELECT * FROM paper WHERE AdminId=@AdminId AND Deleted = 0";
        cmd.TableName = "papers";
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);

        List<Paper> papers = new List<Paper>();
        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables.Contains("papers"))
        {
            foreach (DataRow row in ds.Tables["papers"].Rows)
            {
                Paper paper = new Paper();
                paper.Fill(row);
                papers.Add(paper);
            }
        }

        return papers;
    }

    public Paper UpdatePaper(Paper paper, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        SQLCommand cmd = paper.GetUpdateQuery();
        cmd.TempId = paper.TempId;
        (new Db()).ExecuteNonQuery(cmd);
        if (String.IsNullOrEmpty(paper.TempId) == false && cmd.RowsAffected > 0)
        {
            paper.Id = (uint)cmd.InsertId;
            paper.TempId = string.Empty;
        }

        return paper;
    }

    public uint RemovePaper(Paper paper, User user)
    {
        if (UserManager.ValidateUser(user) == false) return 0; 

        (new Db()).ExecuteNonQuery(paper.GetRemoveQuery());

        return paper.Id;
    }
    #endregion

    #region Get / Update / Remove Test Schedules
    public uint GetNumberOfTestSchedulePages(User user)
    {
        long pageCount = 0;

        if (UserManager.ValidateUser(user) == false) return 0;

        string sql = "SELECT COUNT(*) FROM testschedule WHERE AdminId = @AdminId";

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";
        cmd.Sql = sql;
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("TestSchedule") && ds.Tables["TestSchedule"].Rows.Count == 1)
        {
            pageCount = (long)ds.Tables["TestSchedule"].Rows[0][0];
        }

        return (uint)Math.Ceiling(pageCount / (double)pageSize);
    }

    public List<TestSchedule> GetTestSchedules(User user, uint index)
    {
        uint startIndex = pageSize * index;

        if (UserManager.ValidateUser(user) == false) return null;

        string sql = String.Format("SELECT * FROM testschedule WHERE AdminId = @AdminId ORDER BY ScheduleDateTime DESC LIMIT {0}, {1}", startIndex, pageSize);

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";
        cmd.Sql = sql;
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);

        DataSet ds = (new Db()).GetDataset(cmd);

        List<TestSchedule> testSchedules = new List<TestSchedule>();
        if (ds != null && ds.Tables.Contains("TestSchedule"))
        {
            foreach (DataRow row in ds.Tables["TestSchedule"].Rows)
            {
                TestSchedule testSchedule = new TestSchedule();
                testSchedule.Fill(row);
                testSchedules.Add(testSchedule);
            }
        }

        return testSchedules;
    }

    public List<TestSchedule> GetTestSchedulesByFilters(User user, List<string> filters, uint index)
    {
        uint startIndex = pageSize * index;

        if (UserManager.ValidateUser(user) == false) return null;

        // Filters 
        List<string> filterSqls = new List<string>();
        if (filters.Contains("Scheduled"))
        {
            filterSqls.Add("Status = 0");
        }

        if (filters.Contains("Taken"))
        {
            filterSqls.Add("Status = 1");
        }

        if (filters.Contains("Submitted"))
        {
            filterSqls.Add("Status = 2");
        }

        if (filters.Contains("Disqualified"))
        {
            filterSqls.Add("Status = 3");
        }

        string filter = string.Empty;
        if (filterSqls.Count > 0)
        {
            filter = " AND (" + String.Join(" OR ", filterSqls.ToArray()) + ")";
        }

        string sql = String.Format("SELECT * FROM testschedule WHERE AdminId = @AdminId {2} ORDER BY ScheduleDateTime DESC LIMIT {0}, {1}", startIndex, pageSize, filter);

        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";
        cmd.Sql = sql;
        Db.AddParam(cmd, "@AdminId", MySqlDbType.UInt32, user.Id);

        DataSet ds = (new Db()).GetDataset(cmd);

        List<TestSchedule> testSchedules = new List<TestSchedule>();
        if (ds != null && ds.Tables.Contains("TestSchedule"))
        {
            foreach (DataRow row in ds.Tables["TestSchedule"].Rows)
            {
                TestSchedule testSchedule = new TestSchedule();
                testSchedule.Fill(row);
                testSchedules.Add(testSchedule);
            }
        }

        return testSchedules;
    }

    public TestSchedule UpdateTestSchdule(TestSchedule testSchedule, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        bool tempIdSet = String.IsNullOrEmpty(testSchedule.TempId) == false;

        if (tempIdSet)
        {
            // Check whether any test is already assigned 
            SQLCommand alreadyAssignedCmd = new SQLCommand();
            alreadyAssignedCmd.Sql = "SELECT * FROM `testschedule` t WHERE t.Email=@Email AND t.Status < 2";
            alreadyAssignedCmd.TableName = "AlreadyAssigned";
            Db.AddParam(alreadyAssignedCmd, "@Email", MySqlDbType.VarChar, testSchedule.Email);

            DataSet ds = (new Db()).GetDataset(alreadyAssignedCmd);
            if (ds != null && ds.Tables.Contains("AlreadyAssigned") && ds.Tables["AlreadyAssigned"].Rows.Count > 0)
            {
                // Already some test is scheduled
                throw new Exception(String.Format("$New test cannnot be scheduled for the email address:{0} as another test was scheduled to the same email address and either test was not taken or test was taken but not submitted.$", testSchedule.Email));
            }
        }
        
        testSchedule.Password = Guid.NewGuid().ToString().Split("-".ToCharArray())[0];
        TimeZone timezone = TimeZone.CurrentTimeZone;
        testSchedule.ScheduleDateTime = timezone.ToUniversalTime(DateTime.Now);

        SQLCommand cmd = testSchedule.GetUpdateQuery();
        cmd.TempId = testSchedule.TempId;
        (new Db()).ExecuteNonQuery(cmd);

        if (cmd.RowsAffected > 0)
        {
            if (tempIdSet)
            {
                testSchedule.Id = (uint)cmd.InsertId;
                testSchedule.TempId = string.Empty;
            }

            Postman.Send_Schedule_Mail(testSchedule, tempIdSet == false);
        }

        return testSchedule;
    }

    public uint RemoveTestSchedule(TestSchedule testSchedule, User user)
    {
        if (UserManager.ValidateUser(user) == false) return 0;

        (new Db()).ExecuteNonQuery(testSchedule.GetRemoveQuery());
        Postman.Send_Cancel_Mail(testSchedule);

        return testSchedule.Id;
    }

    public TestAnswers GetTestAnswers(uint testId, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        TestAnswers testAnswers = new TestAnswers();
        testAnswers.TestId = testId;

        // 1. Create commands
        // Objective question
        SQLCommand objectiveQuestionAnswerCmd = new SQLCommand();
        objectiveQuestionAnswerCmd.Sql = String.Format("SELECT * FROM a_objective WHERE TestId = {0}", testId);
        objectiveQuestionAnswerCmd.TableName = "objective";
        // SQL question
        SQLCommand sqlQuestionAnswerCmd = new SQLCommand();
        sqlQuestionAnswerCmd.Sql = String.Format("SELECT * FROM a_sql WHERE TestId = {0}", testId);
        sqlQuestionAnswerCmd.TableName = "sql";
        // Programming question
        SQLCommand programmingQuestionAnswerCmd = new SQLCommand();
        programmingQuestionAnswerCmd.Sql = String.Format("SELECT * FROM a_programming WHERE TestId = {0}", testId);
        programmingQuestionAnswerCmd.TableName = "programming";
        // Programming question
        SQLCommand autoProgrammingQuestionAnswerCmd = new SQLCommand();
        autoProgrammingQuestionAnswerCmd.Sql = String.Format("SELECT * FROM a_auto_programming WHERE TestId = {0}", testId);
        autoProgrammingQuestionAnswerCmd.TableName = "auto_programming";
        // Web programming question
        SQLCommand webProgrammingQuestionAnswerCmd = new SQLCommand();
        webProgrammingQuestionAnswerCmd.Sql = String.Format("SELECT * FROM a_webprogramming WHERE TestId = {0}", testId);
        webProgrammingQuestionAnswerCmd.TableName = "webprogramming";

        // 2. Create command list
        List<SQLCommand> cmds = new List<SQLCommand>();
        cmds.Add(objectiveQuestionAnswerCmd);
        cmds.Add(sqlQuestionAnswerCmd);
        cmds.Add(programmingQuestionAnswerCmd);
        cmds.Add(autoProgrammingQuestionAnswerCmd);
        cmds.Add(webProgrammingQuestionAnswerCmd);

        // 3. Data from Database
        DataSet ds = (new Db()).GetDataset(cmds);
        if (ds != null)
        {
            // Objective questions
            if (ds.Tables.Contains("objective")) { testAnswers.Fill(ds.Tables["objective"]); }

            // SQL questions
            if (ds.Tables.Contains("sql")) { testAnswers.Fill(ds.Tables["sql"]); }

            // Programming questions
            if (ds.Tables.Contains("programming")) { testAnswers.Fill(ds.Tables["programming"]); }

            // Auto programming questions
            if (ds.Tables.Contains("auto_programming")) { testAnswers.Fill(ds.Tables["auto_programming"]); }

            // Web programming questions
            if (ds.Tables.Contains("webprogramming")) { testAnswers.Fill(ds.Tables["webprogramming"]); }
        }

        return testAnswers;
    }

    public CompilerMessage AutoCompileCode(AutoProgrammingQuestion question, string code, string sessionId, ProgrammingAnswerType answerType, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        AutoCompilerBase compiler = null;
        switch (answerType)
        {
            case ProgrammingAnswerType.C: compiler = new AutoCCompiler(); break;
            case ProgrammingAnswerType.CPP: compiler = new AutoCPPCompiler(); break;
            case ProgrammingAnswerType.CSharp: compiler = new AutoCSharpDotNetCompiler(); break;
            case ProgrammingAnswerType.VBNET: compiler = new AutoVBDotNetCompiler(); break;
            case ProgrammingAnswerType.Java: compiler = new AutoJavaCompiler(); break;
        }

        if (compiler != null)
        {
            return compiler.Compile(question, code, sessionId, false);
        }

        return null;
    }

    public string GetWebsitesVisited(uint testId, User user)
    {
        string urls = string.Empty;

        if (UserManager.ValidateUser(user))
        {
            SQLCommand cmd = new SQLCommand();
            cmd.Sql = "SELECT w.Urls FROM websitesvisited w WHERE w.TestId=@TestId";
            cmd.TableName = "WebsitesVisited";
            Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);

            DataSet ds = (new Db()).GetDataset(cmd);
            if (ds != null && ds.Tables.Contains("WebsitesVisited") && ds.Tables["WebsitesVisited"].Rows.Count == 1)
            {
                urls = (string)ds.Tables["WebsitesVisited"].Rows[0][0];
            }
        }

        return urls;
    }

    public string GetApplicationsIgnored(uint testId, User user)
    {
        string apps = string.Empty;

        if (UserManager.ValidateUser(user))
        {
            SQLCommand cmd = new SQLCommand();
            cmd.Sql = "SELECT a.Apps FROM appsignored a WHERE a.TestId=@TestId";
            cmd.TableName = "ApplicationsIgnored";
            Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);

            DataSet ds = (new Db()).GetDataset(cmd);
            if (ds != null && ds.Tables.Contains("ApplicationsIgnored") && ds.Tables["ApplicationsIgnored"].Rows.Count == 1)
            {
                apps = (string)ds.Tables["ApplicationsIgnored"].Rows[0][0];
            }
        }

        return apps;
    }

    public uint GetTestsPurchased(User user)
    {
        uint testsPurchased = 0;

        if (UserManager.ValidateUser(user))
        {
            SQLCommand cmd = new SQLCommand();
            cmd.Sql = "SELECT t.Purchased FROM testpurchase t WHERE t.Email=@Email";
            cmd.TableName = "TestsPurchased";
            Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, user.Email);

            DataSet ds = (new Db()).GetDataset(cmd);
            if (ds != null && ds.Tables.Contains("TestsPurchased") && ds.Tables["TestsPurchased"].Rows.Count == 1)
            {
                testsPurchased = Convert.ToUInt32(ds.Tables["TestsPurchased"].Rows[0][0]);
            }
        }

        return testsPurchased;
    }

    public bool UpdateTestPurchase(string email, uint qty, string token)
    {
        if (token == "UOIASU=OAWEUOPRUPOIAEURP$OUQEWOIUROIUOIQWEROIQWUER#VOIQWEURIOEW")
        {
            SQLCommand selectCmd = new SQLCommand();
            selectCmd.Sql = "SELECT * FROM `testpurchase` WHERE Email=@Email";
            selectCmd.TableName = "testpurchase";
            Db.AddParam(selectCmd, "@Email", MySqlDbType.VarChar, email);
            DataSet ds = (new Db()).GetDataset(selectCmd);

            uint alreadyPurchased = 0;
            if (ds != null && ds.Tables.Contains("testpurchase") && ds.Tables["testpurchase"].Rows.Count > 0)
            {
                alreadyPurchased = (uint)ds.Tables["testpurchase"].Rows[0]["Purchased"];
            }

            SQLCommand cmd = new SQLCommand();
            cmd.Sql = "REPLACE INTO `testpurchase` VALUES(@email, @qty)";
            cmd.TableName = "Purchase";
            Db.AddParam(cmd, "@email", MySqlDbType.VarChar, email);
            Db.AddParam(cmd, "@qty", MySqlDbType.UInt32, alreadyPurchased + (qty*100));

            (new Db()).ExecuteNonQuery(cmd);

            return cmd.RowsAffected > 0;
        }
        return false;
    }

    public TestImage[] GetTestImages(uint testId, User user)
    {
        if (UserManager.ValidateUser(user) == false) return null;

        List<TestImage> images = new List<TestImage> ();
        string imagesPath = HttpContext.Current.Server.MapPath(String.Format("~/Images/{0}/{1}/{2}/", testId / 1000, (testId % 1000) / 100, testId));
        if(Directory.Exists(imagesPath)){
            string[] files = Directory.GetFiles(imagesPath);
            foreach(string file in files){
                TestImage testImage = new TestImage ();
                testImage.Name = Path.GetFileName(file);
                testImage.Stream = ImageToString(file);

                images.Add(testImage);
            }
        }

        return images.ToArray();
    }

    private string ImageToString(string filename)
    {
        string exeStream = string.Empty;
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
                exeStream = Convert.ToBase64String(bin);
            }
        }

        return exeStream;
    }

    #endregion

    public bool SaveWebPages(WebNode webNode, string uniqueId, User user)
    {
        if (UserManager.ValidateUser(user) == false) return false;

        WebFileManager m = new WebFileManager();
        m.Save(webNode, uniqueId);

        return true;
    }

    public void SendErrorMessage(string message, User user)
    {
        Postman.Send_Error_Mail(message);
    }
}

// TODO: Every call try to authenticate.. Database call is made everytime
public class ClientManager
{
    public TestSchedule Authenticate(string email, string password)
    {
        TestSchedule testSchedule = null;
        SQLCommand cmd = new SQLCommand();
        cmd.TableName = "TestSchedule";

        if (DemoAccounts.Accounts.Contains(email))
        {
            cmd.Sql = "SELECT * FROM testschedule WHERE Id = 1";
        }
        else
        {
            cmd.Sql = "SELECT * FROM testschedule WHERE Email=@Email AND Password=@Password ORDER BY status";
            Db.AddParam(cmd, "@Email", MySqlDbType.VarChar, email);
            Db.AddParam(cmd, "@Password", MySqlDbType.VarChar, password);
        }

        DataSet ds = (new Db()).GetDataset(cmd);
        if (ds != null && ds.Tables.Contains("TestSchedule") && ds.Tables["TestSchedule"].Rows.Count == 1)
        {
            testSchedule = new TestSchedule();
            testSchedule.Fill(ds.Tables["TestSchedule"].Rows[0]);
        }

        return testSchedule;
    }

    public Questions GetQuestions(uint paperId, string email, string password)
    {
        if (Authenticate(email, password) == null) return null;

        // Get paperId and question ids
        SQLCommand questionIdsCmd = new SQLCommand();
        questionIdsCmd.Sql = @"SELECT * FROM paper WHERE Id = @PaperId";
        questionIdsCmd.TableName = "QuestionIds";
        Db.AddParam(questionIdsCmd, "@PaperId", MySqlDbType.UInt32, paperId);

        DataSet dsQuestionIds = (new Db()).GetDataset(questionIdsCmd);
        Dictionary<QuestionType, List<string>> ids = new Dictionary<QuestionType,List<string>> ();
        if (dsQuestionIds != null && dsQuestionIds.Tables.Contains("QuestionIds") && dsQuestionIds.Tables["QuestionIds"].Rows.Count == 1)
        {
            string questionIds = (string)dsQuestionIds.Tables["QuestionIds"].Rows[0]["QuestionIds"];
            string[] mappingIds = questionIds.Split(",".ToCharArray());
            foreach (string mappingId in mappingIds)
            {
                string[] mappingItems = mappingId.Split("|".ToCharArray());
                QuestionType type = (QuestionType)Enum.Parse(typeof(QuestionType), mappingItems[1]);
                if (ids.ContainsKey(type) == false)
                {
                    ids[type] = new List<string> ();
                }

                ids[type].Add(mappingItems[0]);
            }
        }

        // Get questions
        Questions questions = new Questions();

        // 1. Create commands
        // Objective question
        SQLCommand objectiveQuestionCmd = new SQLCommand();
        objectiveQuestionCmd.Sql = String.Format("SELECT * FROM q_objective WHERE Id IN ({0})", ids.ContainsKey(QuestionType.Objective) ? String.Join(",", ids[QuestionType.Objective].ToArray()) : "''");
        objectiveQuestionCmd.TableName = "objective";
        // SQL question
        SQLCommand sqlQuestionCmd = new SQLCommand();
        sqlQuestionCmd.Sql = String.Format("SELECT * FROM q_sql WHERE Id IN ({0})", ids.ContainsKey(QuestionType.Sql) ? String.Join(",", ids[QuestionType.Sql].ToArray()) : "''");
        sqlQuestionCmd.TableName = "sql";
        // Programming question
        SQLCommand programminQuestionCmd = new SQLCommand();
        programminQuestionCmd.Sql = String.Format("SELECT * FROM q_programming WHERE Id IN ({0})", ids.ContainsKey(QuestionType.Programming) ? String.Join(",", ids[QuestionType.Programming].ToArray()) : "''");
        programminQuestionCmd.TableName = "programming";
        // Auto programming question
        SQLCommand autoProgramminQuestionCmd = new SQLCommand();
        autoProgramminQuestionCmd.Sql = String.Format("SELECT * FROM q_auto_programming WHERE Id IN ({0})", ids.ContainsKey(QuestionType.AutoProgramming) ? String.Join(",", ids[QuestionType.AutoProgramming].ToArray()) : "''");
        autoProgramminQuestionCmd.TableName = "auto_programming";
        // web programming question
        SQLCommand webProgramminQuestionCmd = new SQLCommand();
        webProgramminQuestionCmd.Sql = String.Format("SELECT * FROM q_webprogramming WHERE Id IN ({0})", ids.ContainsKey(QuestionType.WebProgramming) ? String.Join(",", ids[QuestionType.WebProgramming].ToArray()) : "''");
        webProgramminQuestionCmd.TableName = "webprogramming";

        // 2. Create command list
        List<SQLCommand> cmds = new List<SQLCommand>();
        cmds.Add(objectiveQuestionCmd);
        cmds.Add(sqlQuestionCmd);
        cmds.Add(programminQuestionCmd);
        cmds.Add(autoProgramminQuestionCmd);
        cmds.Add(webProgramminQuestionCmd);

        // 3. Data from Database
        DataSet ds = (new Db()).GetDataset(cmds);
        if (ds != null)
        {
            // Objective questions
            if (ds.Tables.Contains("objective")) { questions.Fill(ds.Tables["objective"]); }

            // SQL questions
            if (ds.Tables.Contains("sql")) { questions.Fill(ds.Tables["sql"]); }

            // Programming questions
            if (ds.Tables.Contains("programming")) { questions.Fill(ds.Tables["programming"]); }

            // Auto programming questions
            if (ds.Tables.Contains("auto_programming")) { questions.Fill(ds.Tables["auto_programming"]); }

            // Web programming questions
            if (ds.Tables.Contains("webprogramming")) { questions.Fill(ds.Tables["webprogramming"]); }
        }

        return questions;
    }

    public bool UpdateTestStarted(uint testId, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "UPDATE testschedule SET Status = 1, TestTakenDateTime = @TestTakenDateTime WHERE Id = @TestId";
        cmd.TableName = "UpdateTestStarted";
        Db.AddParam(cmd, "@TestTakenDateTime", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);

        (new Db()).ExecuteNonQuery(cmd);

        return cmd.RowsAffected > 0;
    }

    public bool SetCandidateDisqualified(TestSchedule schedule, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "UPDATE testschedule SET Status = 3 WHERE Id = @TestId";
        cmd.TableName = "Disqualified";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, schedule.Id);

        (new Db()).ExecuteNonQuery(cmd);

        Postman.Send_CandidateDisqualified_Mail(schedule);

        return cmd.RowsAffected > 0;
    }

    public TestInfo GetTestInfo(string email, string password)
    {
        TestSchedule testSchedule = Authenticate(email, password);
        if (testSchedule != null)
        {
            SQLCommand cmd = new SQLCommand();
            cmd.Sql = String.Format("SELECT QuestionIds FROM paper WHERE Id = {0}", testSchedule.PaperId);
            cmd.TableName = "papers";

            DataSet ds = (new Db()).GetDataset(cmd);
            if (ds != null && ds.Tables.Count == 1 && ds.Tables.Contains("papers") && ds.Tables["papers"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["papers"].Rows[0];
                string ids = (string)dr["QuestionIds"];

                TestInfo testInfo = new TestInfo();
                testInfo.EmployerName = UserManager.GetUserInfo(testSchedule.AdminId).CompanyName;
                testInfo.QuestionsCount = ids.Split(",".ToCharArray()).Length;

                return testInfo;
            }
        }

        return null;
    }

    public CompilerMessage CompileCode(string code, string sessionId, ProgrammingAnswerType answerType, string email, string password)
    {
        if (Authenticate(email, password) == null) return null;

        CompilerBase compiler = null;
        switch (answerType)
        {
            case ProgrammingAnswerType.C: compiler = new CCompiler(); break;
            case ProgrammingAnswerType.CPP: compiler = new CPPCompiler(); break;
            case ProgrammingAnswerType.CSharp: compiler = new CSharpDotNetCompiler(); break;
            case ProgrammingAnswerType.VBNET: compiler = new VBDotNetCompiler(); break;
            case ProgrammingAnswerType.Java: compiler = new JavaCodeCompiler(); break;
        }

        if (compiler != null)
        {
            return compiler.Compile(code, sessionId);
        }

        return null;
    }

    public CompilerMessage AutoCompileCode(AutoProgrammingQuestion question, string code, string sessionId, ProgrammingAnswerType answerType, string email, string password)
    {
        if (Authenticate(email, password) == null) return null;

        AutoCompilerBase compiler = null;
        switch (answerType)
        {
            case ProgrammingAnswerType.C: compiler = new AutoCCompiler(); break;
            case ProgrammingAnswerType.CPP: compiler = new AutoCPPCompiler(); break;
            case ProgrammingAnswerType.CSharp: compiler = new AutoCSharpDotNetCompiler(); break;
            case ProgrammingAnswerType.VBNET: compiler = new AutoVBDotNetCompiler(); break;
            case ProgrammingAnswerType.Java: compiler = new AutoJavaCompiler(); break;
        }

        if (compiler != null)
        {
            return compiler.Compile(question, code, sessionId, true);
        }

        return null;
    }

    public string GetTemplateCode(AutoProgrammingQuestion question, ProgrammingAnswerType answerType, string email, string password)
    {
        if (Authenticate(email, password) == null) return null;

        AutoCompilerBase compiler = null;
        switch (answerType)
        {
            case ProgrammingAnswerType.C: compiler = new AutoCCompiler(); break;
            case ProgrammingAnswerType.CPP: compiler = new AutoCPPCompiler(); break;
            case ProgrammingAnswerType.CSharp: compiler = new AutoCSharpDotNetCompiler(); break;
            case ProgrammingAnswerType.VBNET: compiler = new AutoVBDotNetCompiler(); break;
            case ProgrammingAnswerType.Java: compiler = new AutoJavaCompiler(); break;
        }

        if (compiler != null)
        {
            return compiler.GetTemplateCode(question);
        }

        return string.Empty;
    }

    public bool SubmitAnswers(TestAnswers answers, TestSchedule schedule, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        List<SQLCommand> cmds = new List<SQLCommand>();
        cmds.AddRange(GetInsertCmds(answers.ObjectiveQuestionTestAnswers));
        cmds.AddRange(GetInsertCmds(answers.SqlQuestionTestAnswers));
        cmds.AddRange(GetInsertCmds(answers.ProgrammingQuestionTestAnswers));
        cmds.AddRange(GetInsertCmds(answers.AutoProgrammingQuestionTestAnswers));
        cmds.AddRange(GetInsertCmds(answers.WebPogrammingQuestionTestAnswers));

        (new Db()).ExecuteNonQuery(cmds);

        // Update test submitted state
        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "UPDATE testschedule SET Status = 2, TestTakenDateTime = @TestTakenDateTime WHERE Id = @TestId";
        cmd.TableName = "SubmitTestAnswers";
        Db.AddParam(cmd, "@TestTakenDateTime", MySqlDbType.DateTime, DateTime.Now);
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, answers.TestId);

        (new Db()).ExecuteNonQuery(cmd);

        // Send test submitted mail
        Postman.Send_TestSubmitted_Mail(schedule);

        return true;
    }

    public bool UpdateWebsitesVisited(uint testId, string urls, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE websitesvisited SET TestId = @TestId, Urls = @Urls";
        cmd.TableName = "WebsitesVisited";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@Urls", MySqlDbType.Text, urls);

        (new Db()).ExecuteNonQuery(cmd);

        return cmd.RowsAffected > 0;
    }

    public bool UpdateApplicationsIgnored(uint testId, string apps, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        SQLCommand cmd = new SQLCommand();
        cmd.Sql = "REPLACE appsignored SET TestId = @TestId, Apps = @Apps";
        cmd.TableName = "ApplicationsIgnored";
        Db.AddParam(cmd, "@TestId", MySqlDbType.UInt32, testId);
        Db.AddParam(cmd, "@Apps", MySqlDbType.Text, apps);

        (new Db()).ExecuteNonQuery(cmd);

        return cmd.RowsAffected > 0;
    }

    public void SendErrorMessage(string message, string email, string password)
    {
        Postman.Send_Error_Mail(message);
    }

    public bool SubmitTestImages(TestImage[] testImages, uint testId, string email, string password)
    {
        if (DemoAccounts.Accounts.Contains(email)) return true;

        if (Authenticate(email, password) == null) return false;

        string imagesPath = HttpContext.Current.Server.MapPath(String.Format("~/Images/{0}/{1}/{2}/", testId / 1000, (testId % 1000) / 100, testId));
        if (Directory.Exists(imagesPath) == false) Directory.CreateDirectory(imagesPath);

        foreach (TestImage testImage in testImages)
        {
            string filename = imagesPath + testImage.Name;
            byte[] binary = Convert.FromBase64String(testImage.Stream);
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(binary);
                }
            }
        }
        return true;
    }

    public bool SaveWebPages(WebNode webNode, string uniqueId, string email, string password)
    {
        if (Authenticate(email, password) == null) return false;

        WebFileManager m = new WebFileManager();
        m.Save(webNode, uniqueId);

        return true;
    }

    private List<SQLCommand> GetInsertCmds<T>(List<T> answers) where T : TestAnswerBase
    {
        List<SQLCommand> cmds = new List<SQLCommand>();
        foreach (TestAnswerBase answer in answers)
        {
            cmds.Add(answer.GetInsertCmd());
        }

        return cmds;
    }
}