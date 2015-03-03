using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

internal class Db
{
    private const string connectionString = "Server=localhost;Database=nvntest;Uid=nvntest;Pwd=<your database password here>;";

    internal DataSet GetDataset(List<SQLCommand> cmds)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        DataSet ds = new DataSet();
        try
        {
            foreach (SQLCommand cmd in cmds)
            {
                FillDataSet(ds, connection, cmd);
            }
        }
        finally
        {
            connection.Close();
        }

        return ds;
    }

    internal DataSet GetDataset(SQLCommand cmd)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        DataSet ds = new DataSet();
        try
        {
            FillDataSet(ds, connection, cmd);
        }
        finally
        {
            connection.Close();
        }

        return ds;
    }

    private void FillDataSet(DataSet ds, MySqlConnection connection, SQLCommand cmd)
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        // Command
        MySqlCommand command = new MySqlCommand();
        command.CommandText = cmd.Sql;
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.Parameters.AddRange(cmd.Parameters.ToArray());
        adapter.SelectCommand = command;

        adapter.Fill(ds, cmd.TableName);
    }

    internal void ExecuteNonQuery(List<SQLCommand> cmds)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        try
        {
            foreach (SQLCommand cmd in cmds)
            {
                ExecuteNonQuery(connection, cmd);
            }
        }
        finally { connection.Close(); }
    }

    internal void ExecuteNonQuery(SQLCommand cmd)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();

        try
        {
            ExecuteNonQuery(connection, cmd);
        }
        finally { connection.Close(); }
    }

    private void ExecuteNonQuery(MySqlConnection connection, SQLCommand cmd)
    {
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = cmd.Sql;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(cmd.Parameters.ToArray());

            cmd.RowsAffected = command.ExecuteNonQuery();

            if (String.IsNullOrEmpty(cmd.TempId) == false && cmd.RowsAffected > 0)
            {
                cmd.InsertId = GetLastInsertId(connection);
            }
        }
        catch (Exception exc)
        {
            string parameters = string.Empty;
            foreach (MySqlParameter param in cmd.Parameters)
            {
                parameters += "Name=" + param.ParameterName + " Value=" + param.Value + ",";
            }

            Postman.Send_Error_Mail("SQL exception: " + Environment.NewLine + "SQL: " + cmd.Sql + Environment.NewLine + "Parameters:" + parameters
                + Environment.NewLine + exc.Message + Environment.NewLine + exc.StackTrace);
        }
    }

    private long GetLastInsertId(MySqlConnection connection)
    {
        long lastInsertId = 0;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        // Command
        MySqlCommand command = new MySqlCommand();
        command.CommandText = "SELECT LAST_INSERT_ID();";
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();
        adapter.Fill(ds);

        if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
        {
            lastInsertId = (long)ds.Tables[0].Rows[0][0];
        }

        return lastInsertId;
    }

    internal static void AddParam(SQLCommand cmd, string name, MySqlDbType type, object value)
    {
        MySqlParameter parameter = new MySqlParameter(name, type);
        parameter.Value = value;
        cmd.Parameters.Add(parameter);
    }
}

internal class SQLCommand
{
    private string sql;
    private string tableName;
    private List<MySqlParameter> parameters = new List<MySqlParameter>();
    private long insertId = -1;
    private string tempId;
    private int rowsAffected;

    public string Sql
    {
        get { return sql; }
        set { sql = value; }
    }

    public string TableName
    {
        get { return tableName; }
        set { tableName = value; }
    }

    public List<MySqlParameter> Parameters
    {
        get { return parameters; }
    }

    public long InsertId
    {
        get { return insertId; }
        set { insertId = value; }
    }

    public string TempId
    {
        get { return tempId; }
        set { tempId = value; }
    }

    public int RowsAffected
    {
        get { return rowsAffected; }
        set { rowsAffected = value; }
    }
}