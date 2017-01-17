using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Text.RegularExpressions;

public partial class Log_in : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.RemoveAll();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (dbaccess.inputcheck(TextBox1.Text) && dbaccess.inputcheck(TextBox2.Text))
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                Response.Write("<script>confirm('You have failed to provide a User Id or Password, please provide them to proceed.')</script>");
            }
            else
            {
                string source = TextBox2.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    DataSet r = dbaccess.FetchData("select User_Id,User_Role_Id,User_Name,User_Email,User_Mobile from User_Master where User_Id='" + TextBox1.Text + "'and User_Pass='" + hash + "'and User_Status= 'E'");
                    if (r.Tables[0].Rows.Count == 1)
                    {
                        Session["id"] = r.Tables[0].Rows[0][0].ToString();
                        Session["wb"] = r.Tables[0].Rows[0][1].ToString();
                        Session["name"] = r.Tables[0].Rows[0][2].ToString();
                        Session["email"] = r.Tables[0].Rows[0][3].ToString();
                        Session["mobile"] = r.Tables[0].Rows[0][4].ToString();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Write("<script>confirm('Please check your User ID Or Password')</script>");
                        TextBox1.Text = TextBox2.Text = null;
                    }

                }
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (dbaccess.inputcheck(TextBox1.Text) && dbaccess.inputcheck(TextBox2.Text))
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                Response.Write("<script>confirm('You have failed to provide a User Id or Password, please provide them to proceed.')</script>");
            }
            else
            {
                string source = TextBox2.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    DataSet r = dbaccess.FetchData("select User_Id,User_Role_Id,User_Name,User_Email,User_Mobile from User_Master where User_Id='" + TextBox1.Text + "'and User_Pass='" + hash + "'and User_Status= 'E'");
                    if (r.Tables[0].Rows.Count == 1)
                    {
                        Session["id"] = r.Tables[0].Rows[0][0].ToString();
                        Session["wb"] = r.Tables[0].Rows[0][1].ToString();
                        Session["name"] = r.Tables[0].Rows[0][2].ToString();
                        Session["email"] = r.Tables[0].Rows[0][3].ToString();
                        Session["mobile"] = r.Tables[0].Rows[0][4].ToString();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Write("<script>confirm('Please check your User ID Or Password')</script>");
                        TextBox1.Text = TextBox2.Text = null;
                    }

                }
            }
        }
        else
        {
            Response.Write("<script>confirm('Avoid the use of special characters.')</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
}
