using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Security.Cryptography;
using System.Text;

public partial class chng_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        if (Session["wb"] == null)
        {
            Response.Write("<script>confirm('Your session has expired. Please login again.')</script>");
            Response.Redirect("Log_in.aspx");
        }
        TextBox1.Text = Session["id"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dbaccess.inputcheck(TextBox1.Text))
        {
            if (TextBox3.Text != "")
            {
                string source = TextBox2.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);

                    DataSet r = dbaccess.FetchData("select User_Id,User_Pass from User_Master where User_Id='" + Session["id"] + "'and User_Pass='" + hash + "'");

                    if (r.Tables[0].Rows.Count == 1)
                    {
                        string source1 = TextBox3.Text;
                        using (MD5 md5Hash1 = MD5.Create())
                        {
                            string hash1 = GetMd5Hash(md5Hash1, source1);
                            try
                            {
                                DataSet ds1 = dbaccess.UpdateData("update User_Master set User_Pass='" + hash1 + "' where User_Id='" + Session["id"] + "'");
                                Response.Write("<script>confirm('Password has been updted.')</script>");
                            }
                            catch
                            {
                                Response.Write("<script>confirm ('Unable to change password.')</script>");
                            }
                        }

                    }
                    else
                    {
                        Response.Write("<script>confirm('Please Check your User Id Or Password')</script>");
                        TextBox2.Text = TextBox3.Text = null;
                    }

                }
            }
            else
            {
                Response.Write("<script>confirm('Please provide a new password.')</script>");
            }
        }
        else
        {
            Response.Write("<script>confirm('Avoid the use of special characters.')</script>");
        }
    }
    static string GetMd5Hash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}