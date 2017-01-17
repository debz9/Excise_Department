using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class model : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["wb"] == null)
            {
                red();
            }
            else
            {

                switch (Session["wb"].ToString())
                {
                    case "01":
                        GridView1.Controls.Clear();
                        admin();
                        break;
                    case "03":
                        Table1.Visible = false;
                        break;
                    case "04":
                        GridView1.Controls.Clear();
                        admin();
                        break;
                    default: red();
                        break;
                }
            }        
    }
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (ViewState["controlsadded"] == null)
        {
            DataSet chng = dbaccess.FetchData("select b.Vehicle_Model_Code,a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No,b.Delete_Status,a.Vehicle_Make_Code from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code");
            Vehiclemake(chng);
        }  
    }
    protected void admin()
    {
        DataSet chng = dbaccess.FetchData("select b.Vehicle_Model_Code,a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No,b.Delete_Status,a.Vehicle_Make_Code from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code");
        Vehiclemake(chng);
        ViewState["controlsadded"] = null;
    }
    private void Vehiclemake(DataSet users)
    {
        Table1.Controls.Clear();
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.Controls.Add(new LiteralControl("<b>Serial No.</b>"));
        UserId.CssClass = "SNO";
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("<b>Vehicle Make Description</b>"));
        que.CssClass = "SNO";
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("<b>Vehicle Model Description</b>"));
        ya.CssClass = "SNO";
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("<b>Vehicle Gross Weight (kg)</b>"));
        t4.CssClass = "SNO";
        title.Cells.Add(t4);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("<b>Registration No.</b>"));
        t6.CssClass = "SNO";
        title.Cells.Add(t6);
        //TableCell ya1 = new TableCell();
        //ya1.Controls.Add(new LiteralControl("<b>Last Updated By</b>"));
        //title.Cells.Add(ya1);
        //TableCell t41 = new TableCell();
        //t41.Controls.Add(new LiteralControl("<b>Updated On</b>"));
        //title.Cells.Add(t41);
        TableCell t61 = new TableCell();
        t61.Controls.Add(new LiteralControl("<b>Status</b>"));
        t61.CssClass = "SNO";
        title.Cells.Add(t61);
        TableCell t62 = new TableCell();
        t62.Controls.Add(new LiteralControl("<b>Edit</b>"));
        t62.CssClass = "SNO";
        title.Cells.Add(t62);
        Table1.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();
            TableCell b = new TableCell();
            b.CssClass = "SNO";
            b.Controls.Add(new LiteralControl((i+1).ToString()));
            row.Cells.Add(b);
            for (int j = 1; j < 5; j++)
            {

                TableCell c = new TableCell();
                switch(j)
                {
                    case 1:
                        c.CssClass = "MAKEDESC";
                        break;
                    case 2:
                        c.CssClass = "DESC";
                        break;
                    case 3:
                        c.CssClass = "WGT";
                        break;
                    case 4:
                        c.CssClass = "RNO";
                        break;
                    case 5:
                        c.CssClass = "LUB";
                        break;
                    case 6:
                        c.CssClass = "UO";
                        break;
                }
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                row.Cells.Add(c);
            }
            TableCell c6 = new TableCell();
            Button stat =new Button();
            stat.ID = users.Tables[0].Rows[i][6].ToString()+"."+users.Tables[0].Rows[i][0].ToString()+".id";
            switch (users.Tables[0].Rows[i][5].ToString())
            {
                case "E":
                    stat.Click += new System.EventHandler(enanble);
                    stat.Text = "ENABLED";
                    c6.Controls.Add(stat);
                    row.Cells.Add(c6);
                    TableCell c7 = new TableCell();
                    Button dynamicbutton = new Button();
                    dynamicbutton.ID = users.Tables[0].Rows[i][6].ToString() + "." + users.Tables[0].Rows[i][0].ToString();
                    dynamicbutton.Click += new System.EventHandler(vehiclemakerclick);
                    dynamicbutton.Text = "Edit";
                    c7.Controls.Add(dynamicbutton);
                    row.Cells.Add(c7);
                    break;
                case "D":
                    stat.Click += new System.EventHandler(disable);
                    stat.Text = "DISABLED";
                    c6.Controls.Add(stat);
                    row.Cells.Add(c6);
                    TableCell c8 = new TableCell();
                    row.Controls.Add(c8);
                    break;
            }
            Table1.Rows.Add(row);
        }
      ViewState["controlsadded"] = null;
    }
    private void vehiclemakerclick(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        char[] delimiterChars = {'.' };
        string []words=button.ID.Split(delimiterChars);
        Session["r"] = words[0];
        Session["s"] = words[1];
        DataSet chng = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Model_Code,Vehicle_Model_Desc,Vehicle_GVW_Kg,Vehicle_Reg_No from Vehicle_Model_Master where Vehicle_Model_Code='" + words[1] + "' and Vehicle_Make_Code='"+words[0]+"'");
        TextBox2.Text = chng.Tables[0].Rows[0][2].ToString();
        TextBox3.Text = chng.Tables[0].Rows[0][3].ToString();
        TextBox4.Text = chng.Tables[0].Rows[0][4].ToString();
        DropDownList3.SelectedValue = chng.Tables[0].Rows[0][0].ToString();
        Button2.Text = "UPDATE";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "UPDATE")
        {
            if (dbaccess.inputcheck(TextBox2.Text) && dbaccess.inputcheck(TextBox3.Text) && dbaccess.inputcheck(TextBox4.Text))
            {
                if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || DropDownList3.SelectedValue==null)
                    Response.Write("<script>confirm('None of the fields may be left blank. Please provide a valid input')</script>");
                else
                {
                    try
                    {
                        DataSet upload = dbaccess.UpdateData("update Vehicle_Model_Master set Vehicle_Model_Desc='" + TextBox2.Text + "',Vehicle_GVW_kg=" + TextBox3.Text + ",Vehicle_Reg_No='" + TextBox4.Text + "',User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()) where Vehicle_Model_Code='" + Session["s"].ToString() + "'and Vehicle_Make_Code='" + Session["r"].ToString() + "'");
                        Button2.Text = "ADD MODEL";
                        TextBox2.Text = TextBox3.Text = TextBox4.Text = null;
                        Response.Write("<script>confirm('Data updated Succesfully')</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>confirm('Data cannot be updated')</script>");
                    }
                }
            }
            else
                Response.Write("<script>confirm('Avoid the use of special characters.')</script>");
        }
        else
        {
            if (dbaccess.inputcheck(TextBox2.Text) && dbaccess.inputcheck(TextBox3.Text) && dbaccess.inputcheck(TextBox4.Text))
            {
                if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || DropDownList3.SelectedValue == null)
                    Response.Write("<script>confirm('None of the fields may be left blank. Please provide a valid input')</script>");
                else
                {
                    try
                    {
                        bool r = dbaccess.savedatauser("insert into Vehicle_Model_Master values('" + DropDownList3.SelectedValue + "',(select count(Vehicle_Make_Code) from Vehicle_Model_Master where Vehicle_Make_Code=" + DropDownList3.SelectedValue + ")+1,'" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','" + Session["id"].ToString() + "',CONVERT(datetime,GETDATE()),'E')");
                        TextBox2.Text = null;
                        TextBox3.Text = TextBox4.Text = null;
                        if (Session["wb"].ToString() == "03")
                        {
                            GridView1.DataBind();
                        }
                        Response.Write("<script>confirm('Vehicle Model saved succesfully ')</script>");
                    }
                    catch(Exception)
                    {
                        Response.Write("<script>confirm('Vehicle Model cannot be saved')</script>");
                    }
                }
            }
            else
                Response.Write("<script>confirm('Avoid the use of special characters.')</script>");
        }
        if (Session["wb"].ToString() != "03")
        {
            DataSet searched = dbaccess.FetchData("select b.Vehicle_Model_Code,a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No,b.Delete_Status,a.Vehicle_Make_Code from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code");
            Vehiclemake(searched);
            ViewState["controlsadded"] = true;
        }
    }
    protected void red()
    {
        Response.Write("<script>confirm('Your session has expired. Please login again.')</script>");
        Response.Redirect("Log_in.aspx");
    }
    private void enanble(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        char[] delimiterChars = { '.' };
        string[] words = button.ID.ToString().Split(delimiterChars);
        Session["r"] = words[0];
        Session["s"] = words[1];
        DataSet chng = dbaccess.UpdateData("update Vehicle_Model_Master set User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()),Delete_Status='D' where Vehicle_Model_Code='" + Session["s"].ToString() + "' and Vehicle_Make_Code='"+Session["r"].ToString()+"' ");
        DataSet chng1 = dbaccess.FetchData("select b.Vehicle_Model_Code,a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No,b.Delete_Status,a.vehicle_make_code from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code");
        Vehiclemake(chng1);
        ViewState["controlsadded"] = true;
        Button2.Text = "ADD MODEL";
        TextBox2.Text = null;
        TextBox3.Text = null;
        TextBox4.Text = null;
    }
    private void disable(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        char[] delimiterChars = { '.' };
        string[] words = button.ID.ToString().Split(delimiterChars);
        Session["r"] = words[0];
        Session["s"] = words[1];
        DataSet chng = dbaccess.UpdateData("update Vehicle_Model_Master set User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()),Delete_Status='E' where Vehicle_Model_Code='" + Session["s"].ToString() + "' and Vehicle_Make_Code='" + Session["r"].ToString() + "'");
        DataSet chng1 = dbaccess.FetchData("select b.Vehicle_Model_Code,a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No,b.Delete_Status,a.vehicle_make_code from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code");
        Vehiclemake(chng1);
        ViewState["controlsadded"] = true;
        Button2.Text = "ADD MODEL";
        //Label4.Text = null;
        TextBox2.Text = null;
        TextBox3.Text = null;
        TextBox4.Text = null;
    }
    protected void CANCEL_Click(object sender, EventArgs e)
    {
        TextBox2.Text = TextBox3.Text = TextBox4.Text = null;
        Button2.Text = "ADD MAKER";
    }
}