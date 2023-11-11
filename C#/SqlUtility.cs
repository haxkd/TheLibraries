using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
class SqlUtility
{
    /*
        int ExecuteQuery
        string ExecuteQueryScaler
        DataSet ExecuteQueryDataSet
        DataTable ExecuteQueryDataTable
        SqlDataReader ExecuteQueryReader

        int ExecuteProcedure
        string ExecuteProcedureScaler
        DataSet ExecuteProcedureDataSet
        DataTable ExecuteProcedureDataTable
        SqlDataReader ExecuteProcedureReader

        
    */
    SqlConnection con;
    SqlDataAdapter adap;
    SqlCommand cmd;
    DataSet ds;
    SqlDataReader dr;
    public SqlUtility()
    {
        string str = "connection string";
        con = new SqlConnection(str);
    }
    public void ConnectionOpen()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }

    public void ConnectionClose()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
    public int ExecuteQuery(string query)
    {
        int i;
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand(query, con);
        i = cmd.ExecuteNonQuery();

        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return i;
    }
    public string ExecuteQueryScaler(string query)
    {
        string S = string.Empty;
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand(query, con);
        S = cmd.ExecuteScalar().ToString();

        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return S;
    }
    public DataSet ExecuteQueryDataSet(string query)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        adap = new SqlDataAdapter(query, con);
        ds = new DataSet();
        adap.Fill(ds);
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return ds;
    }
    public DataTable ExecuteQueryDataTable(string query)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        adap = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        adap.Fill(dt);

        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return dt;
    }
    public SqlDataReader ExecuteQueryReader(string query)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();

        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return dr;
    }


    public int ExecuteProcedure(String procname, dynamic[] para, dynamic[] value)
    {
        int i;
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = procname;
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < para.Length; i++)
        {
            cmd.Parameters.AddWithValue(para[i], value[i]);
        }
        i = cmd.ExecuteNonQuery();
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return i;
    }

    public string ExecuteProcedureScaler(String procname, dynamic[] para, dynamic[] value)
    {
        string s;
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = procname;
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < para.Length; i++)
        {
            cmd.Parameters.AddWithValue(para[i], value[i]);
        }
        s = cmd.ExecuteScalar().ToString();
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return s;
    }
    public DataSet ExecuteProcedureDataSet(String procname, dynamic[] para, dynamic[] value)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procname;
        cmd.Parameters.Clear();
        for (int i = 0; i < para.Length; i++)
        {
            cmd.Parameters.AddWithValue(para[i], value[i]);
        }
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(dt);
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return ds;
    }
    public DataTable ExecuteProcedureDataTable(String procname, dynamic[] para, dynamic[] value)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procname;
        cmd.Parameters.Clear();
        for (int i = 0; i < para.Length; i++)
        {
            cmd.Parameters.AddWithValue(para[i], value[i]);
        }
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return dt;
    }
    public SqlDataReader ExecuteProcedureReader(String procname, dynamic[] para, dynamic[] value)
    {
        if (con.State == ConnectionState.Closed)
        {
            ConnectionOpen();
        }
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procname;
        cmd.Parameters.Clear();
        for (int i = 0; i < para.Length; i++)
        {
            cmd.Parameters.AddWithValue(para[i], value[i]);
        }
        dr = cmd.ExecuteReader();
        if (con.State == ConnectionState.Open)
        {
            ConnectionClose();
        }
        return dr;
    }
}