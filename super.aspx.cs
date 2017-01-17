using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class super : System.Web.UI.Page
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
                        check();
                        admin();
                        break;
                    case"03":
                        Table1.Visible = false;
                        break;
                    case "04":
                        check();
                        admin();
                        break;
                    default: red();
                        break;
                }
            }
    }
    protected void check()
    {
        GridView1.Controls.Clear();
    }
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (ViewState["controlsadded"] == null)
        {
            DataSet chng = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Make_desc,Delete_status from Vehicle_Make_Master order by cast(vehicle_make_code as int)");
            Vehiclemake(chng);
        }
            
    }
    protected void admin()
    {
        DataSet chng = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Make_desc,Delete_status from Vehicle_Make_Master order by cast(vehicle_make_code as int)");
        Vehiclemake(chng);
        ViewState["controlsadded"] = null;
    }
    private void Vehiclemake(DataSet users)
    {
        Table1.Controls.Clear();
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.CssClass = "SNO";
        UserId.Controls.Add(new LiteralControl("<b><center>Serial No.</center></b>"));
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.CssClass = "MAKERDESC";
        que.Controls.Add(new LiteralControl("<b><center>Vehicle Make Description</center></b>"));
        title.Cells.Add(que);
        TableCell t6 = new TableCell();
        t6.CssClass = "ENABLE";
        t6.Controls.Add(new LiteralControl("<b><center>Status</center></b>"));
        title.Cells.Add(t6);
        TableCell ya = new TableCell();
        ya.CssClass = "EDIT";
        ya.Controls.Add(new LiteralControl("<b><center>Click To</center></b>"));
        title.Cells.Add(ya);
        Table1.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < 2; j++)
            {
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                switch (j)
                {
                    case 0:
                        c.CssClass = "SNO";
                        break;
                    case 1:
                        c.CssClass = "MAKERDESC";
                        break;
                    case 2:
                        c.CssClass = "LUB";
                        break;
                    case 3:
                        c.CssClass = "UO";
                        break;
                }
                row.Cells.Add(c);
            }
            switch (users.Tables[0].Rows[i][2].ToString())
            {
                case "E": 
                    TableCell c6 = new TableCell();
                    c6.CssClass = "ENABLE";
                    Button dynamicbutton = new Button();
                    dynamicbutton.ID = (Convert.ToInt16(users.Tables[0].Rows[i][0].ToString())*100).ToString();
                    dynamicbutton.Click += new System.EventHandler(enanble);
                    dynamicbutton.Text = "ENABLED";
                    c6.Controls.Add(dynamicbutton);
                    row.Cells.Add(c6);

                    TableCell c7 = new TableCell();
                    c7.CssClass = "EDIT";
                    Button edit =new Button();
                    edit.ID=users.Tables[0].Rows[i][0].ToString();
                    edit.Click +=new System.EventHandler(vehiclemakerclick);
                    edit.Text = "EDIT";
                    c7.Controls.Add(edit);
                    row.Cells.Add(c7);
                    break;
                case "D": TableCell c61 = new TableCell();
                    c61.CssClass = "DISABLE";
                    Button dynamicbutton2 = new Button();
                    dynamicbutton2.ID = (Convert.ToInt16(users.Tables[0].Rows[i][0].ToString()) * 100).ToString();
                    dynamicbutton2.Click += new System.EventHandler(disable);
                    dynamicbutton2.Text = "DISABLED";
                    c61.Controls.Add(dynamicbutton2);
                    row.Cells.Add(c61);

                    TableCell c62 = new TableCell();
                    row.Cells.Add(c62);
                    break;
            }
            Table1.Rows.Add(row);
        }
      ViewState["controlsadded"] = null;
    }
    private void vehiclemakerclick(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        DataSet chng = dbaccess.FetchData("Select Vehicle_Make_Desc from Vehicle_Make_Master where Vehicle_Make_Code='" + Convert.ToInt16(button.ID).ToString() + "'");
        TextBox2.Text = chng.Tables[0].Rows[0][0].ToString();
        Button2.Text = "UPDATE";
        Session["r"] = Convert.ToInt16(button.ID).ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (dbaccess.inputcheck(TextBox2.Text))
        {
            if (TextBox2.Text != "")
            {
                if (Button2.Text == "UPDATE")
                {
                    try
                    {
                        DataSet upload = dbaccess.UpdateData("update Vehicle_Make_Master set Vehicle_Make_Desc='" + TextBox2.Text + "',User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()) where Vehicle_Make_Code='" + Convert.ToInt16(Session["r"].ToString()) + "'");
                        Button2.Text = "ADD MAKE";
                        TextBox2.Text = null;
                    }
                    catch (Exception)
                    {

                    }
                    ViewState["controlsadded"] = true;
                }
                else
                {
                    try
                    {
                        bool r = dbaccess.savedatauser("insert into Vehicle_Make_Master values((SELECT ISNULL(MAX(cast(Vehicle_Make_Code as int)), 0) AS MaxVehicle_Make_Code FROM Vehicle_Make_Master)+1,'" + TextBox2.Text + "','" + Session["id"].ToString() + "',CONVERT(datetime,GETDATE()),'E')");
                        TextBox2.Text = null;
                        if (Session["wb"].ToString() == "03")
                        {
                            GridView1.DataBind();
                            Table1.Visible = false;
                            ViewState["controlsadded"] = null;
                        }
                        else
                        {

                            ViewState["controlsadded"] = true;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                Response.Write("<script>confirm('Please provide a Make Description')</script>");
            }
        }
        else
        {
            Response.Write("<script>confirm('Avoid the use of special characters.')</script>");
        }
            Session["r"] = "Vehicle_Make_Code";
            DataSet chng = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Make_desc,Delete_status from Vehicle_Make_Master order by cast(vehicle_make_code as int)");
            Vehiclemake(chng);
    }
    protected void red()
    {
        Response.Write("<script>confirm('Your session has expired. Please login again.')</script>");
        Response.Redirect("Log_in.aspx");
    }
    private void enanble(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        DataSet chng = dbaccess.UpdateData("update Vehicle_Make_Master set User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()),Delete_Status='D' where Vehicle_Make_Code='" + Convert.ToInt16(button.ID)/100 + "'");
        DataSet chng1 = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Make_desc,Delete_status from Vehicle_Make_Master order by cast(vehicle_make_code as int)");
        Vehiclemake(chng1);
        ViewState["controlsadded"] = true;
        Button2.Text = "ADD MAKE";
        TextBox2.Text = null;
    }
    private void disable(Object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        DataSet chng = dbaccess.UpdateData("update Vehicle_Make_Master set User_Id='" + Session["id"].ToString() + "',Opr_Date=CONVERT(datetime, GETDATE()),Delete_Status='E' where Vehicle_Make_Code='" + Convert.ToInt16(button.ID) / 100 + "'");
        DataSet chng1 = dbaccess.FetchData("Select Vehicle_Make_Code,Vehicle_Make_desc,Delete_status from Vehicle_Make_Master order by cast(vehicle_make_code as int)");
        Vehiclemake(chng1);
        ViewState["controlsadded"] = true;
        Button2.Text = "ADD MAKE";
        TextBox2.Text = null;
    }
    protected void CANCEL_Click(object sender, EventArgs e)
    {
        TextBox2.Text = null;
        Button2.Text = "ADD MAKE";
    }
}