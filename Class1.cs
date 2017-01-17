using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class dbaccess
{
    public static bool savedatauser(string qry)
    {
        SqlConnection con = new SqlConnection(@ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.ExecuteNonQuery();
        con.Close();
        return true;
    }
    public static DataSet FetchData(string qry)
    {
        SqlConnection con = new SqlConnection(@ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(qry, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }
    public static DataSet UpdateData(string qry2)
    {
        SqlConnection con = new SqlConnection(@ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(qry2, con);
        DataSet ds1 = new DataSet();
        da.Fill(ds1);
        con.Close();
        return ds1;
    }
    public static bool inputcheck(string s)
    {
        if (s.Contains("xp_") || s.Contains(";") || s.Contains("--") || s.Contains("/*") && s.Contains("*/"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}