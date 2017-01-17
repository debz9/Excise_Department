using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        //string[] separators = { ";", "xp_", "'", "--", "/* ... */" };
       // string[] words = TextBox1.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
       // TextBox2.Text = words.Length.ToString();
        if (TextBox1.Text.Contains("xp_") || TextBox1.Text.Contains(";") || TextBox1.Text.Contains("--") || TextBox1.Text.Contains("/*")&&TextBox1.Text.Contains("*/"))
        {
            TextBox2.Text = "Avoid use of special characters";
        }
    }
}