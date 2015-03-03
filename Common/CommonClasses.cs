using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;

#if Admin
using TestService = NvnTest.Employer.TestService;
using System.Data.SQLite;
#elif Client
using TestService = NvnTest.Candidate.TestService;
#endif

namespace NvnTest.Common {

    #region Database \ SQL

    internal class Db {
        private IDbConnection connection;
        private IDbConnection readOnlyconnection;
        private IDbCommand command;
        private IDbDataAdapter adapter;
        private const string connectionString = "Data Source=db;Version=3;";
        private const string readOnlyconnectionString = "Data Source=db;Version=3;Read Only=True;";

        public Db() {

// Now database questions supported only in admin.. because SQL Lite does not work in 64 bit environment
#if Admin
            connection = new SQLiteConnection(connectionString);
            readOnlyconnection = new SQLiteConnection(readOnlyconnectionString);
            command = new SQLiteCommand();
            adapter = new SQLiteDataAdapter();
#endif
        }

        public void ExecuteNonQuery(string sql) {
            try {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                command.ExecuteNonQuery();
            } catch { } finally {
                connection.Close();
            }
        }

        public DbResult ExecuteSQL(string sql) {
            DbResult result = new DbResult();
            try {
                readOnlyconnection.Open();

                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Connection = readOnlyconnection;
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables.Count == 1) {
                    result.Data = ds.Tables[0];
                    int rows = ds.Tables[0].Rows.Count;
                    result.Message = String.Format("{0} row{1} fetched", rows, (rows == 1 ? "" : "s"));
                    result.ResultStatus = DbResultStatus.Success;
                }
            } catch (Exception e) {
                result.Data = null;
                string message = e.Message.Replace("SQLite error", "").Trim(Environment.NewLine.ToCharArray());
                string[] lines = message.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length == 2) {
                    result.Message = lines[0];
                } else {
                    result.Message = message;
                }
                result.ResultStatus = DbResultStatus.Error;
            } finally { readOnlyconnection.Close(); }

            return result;
        }
    }

    internal class DbManager {
        private static DbManager instance;
        private Db db = new Db();

        //public event EventHandler TablesCreated;
        //public event EventHandler TableCreated;

        public static DbManager Instance {
            get {
                if (instance == null) instance = new DbManager();
                return instance;
            }
        }

        public DbResult GetSqlResult(string sql) {
            return db.ExecuteSQL(sql);
        }

        public void CreateTable(TestService.SqlTable[] tables) {
            foreach (TestService.SqlTable table in tables) {
                CreateTable(table);
            }

            //if (TablesCreated != null) TablesCreated(this, null);
        }

        public void CreateTable(TestService.SqlTable table) {
            // Drop table
            DropTable(table.TableName);
            // Create tables
            if (String.IsNullOrEmpty(table.CreateTableSql) == false) {
                db.ExecuteNonQuery(table.CreateTableSql);

                // Insert test data
                if (String.IsNullOrEmpty(table.TableDataSql) == false) {
                    string[] insertQueries = table.TableDataSql.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string insertQuery in insertQueries) {
                        db.ExecuteNonQuery(insertQuery);
                    }
                }
            }

            //if (TableCreated != null) TableCreated(this, null);
        }

        private void DropTable(string tableName) {
            string sql = "DROP TABLE "+ tableName;
            db.ExecuteNonQuery(sql);
        }        
    }

    internal class DbResult {
        private DataTable data;
        private string message;
        private DbResultStatus resultStatus;

        public DataTable Data {
            get { return data; }
            set { data = value; }
        }

        public string Message {
            get { return message; }
            set { message = value; }
        }

        public DbResultStatus ResultStatus {
            get { return resultStatus; }
            set { resultStatus = value; }
        }
    }

    internal enum DbResultStatus {
        Error, Success
    }

    internal class SqlHistory {
        private string sql;
        private DateTime datetimeExecuted;
        private static Dictionary<TestService.SqlQuestion, List<SqlHistory>> histories = new Dictionary<TestService.SqlQuestion, List<SqlHistory>>();

        public string Sql {
            get { return sql; }
            set { sql = value; }
        }

        public DateTime DateTimeExecuted {
            get { return datetimeExecuted; }
            set { datetimeExecuted = value; }
        }

        public static void AddHist(TestService.SqlQuestion question, string sql) {
            SqlHistory history = new SqlHistory();
            history.sql = sql;
            history.datetimeExecuted = DateTime.Now;

            if (histories.ContainsKey(question) == false) {
                histories.Add(question, new List<SqlHistory>());
            }

            histories[question].Add(history);
        }

        public static List<SqlHistory> GetHistory(TestService.SqlQuestion question) {
            List<SqlHistory> history = null;
            if (histories.ContainsKey(question)) {
                history = histories[question];
            }
            return history;
        }
    }

    #endregion

    public class WebContentSaver {
        public static void Save(TestService.WebNode webNode, string path) {
            Save(webNode, path, true);
        }

        public static void Save(TestService.WebNode webNode, string path, bool deleteDir) {
            if (deleteDir && Directory.Exists(path)) {
                Directory.Delete(path, true);
                Thread.Sleep(2000);
            }

            if (Directory.Exists(path) == false) {
                Directory.CreateDirectory(path);
            }

            foreach (TestService.WebNode node in webNode.Nodes) {
                if (node.Type == TestService.WebNodeType.Directory) {
                    Save(node, path + node.Name + Path.DirectorySeparatorChar);
                } else {
                    SaveToFile(node.Content, path + node.Name);
                }
            }
        }

        private static void SaveToFile(string content, string filename) {
            File.WriteAllText(filename, content);
        }
    }
}