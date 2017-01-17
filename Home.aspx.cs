using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Enabled = false;
        Label2.Enabled = false;
        if (!IsPostBack)
        {
            if (Session["wb"] == null)
            {
                Response.Write("<script>confirm('Your session has expired. Please login again.')</script>");
                Response.Redirect("Log_in.aspx");
            }
            else
            {
                switch (Session["wb"].ToString())
                {
                    case"01":
                        Label1.Text = " an administrator";
                        break;
                    case"02":
                        Label1.Text = "a MIS";
                        break;
                    case"03":
                        Label1.Text = "an operator";
                        break;
                    case"04":
                        Label1.Text = "a supervisor";
                        break;
                }
                Label2.Text = Session["name"].ToString();
            }
        }


    }
}