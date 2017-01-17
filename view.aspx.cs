using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

public partial class view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Enabled = false;
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel1.Enabled = false;
            Table1.Enabled = false;
            Table1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }
    }
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (ViewState["controsladded"] == null)
            AddControls();
        if (ViewState["controsl"] == null)
            Vehiclemake();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Table1.Visible = false;
        Table1.Enabled = false;
        Table2.Visible = false;
        Table2.Enabled = false;
        string source = TextBox2.Text;
        using (MD5 md5Hash = MD5.Create())
        {
            string hash = GetMd5Hash(md5Hash, source);
            DataSet r = dbaccess.FetchData("select User_Id,User_Role_Id,User_Name,User_Email,User_Mobile,User_Status from User_Master where User_Id='" + Convert.ToInt16(TextBox1.Text) + "'and User_Pass='" + hash + "'and User_Status= 'E'");
            if (r.Tables[0].Rows.Count == 1)
            {
                switch(r.Tables[0].Rows[0][1].ToString())
                {
                    case "01": Session["wb"] = 01;
                        break;
                    case "02": MISview();
                        break;
                    case "03": operate();
                        break;
                    case "04": Session["v-s"]=1;
                        Session["Id"] = TextBox1.Text;
                        Response.Redirect("super.aspx");
                        break;                   
                }
            }
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
    private void dynamicbutton_Click(Object sender, System.EventArgs e)
    {
        Table1.Visible = false;
        Panel1.Enabled = true;
        Panel1.Visible = true;
        Button button = sender as Button;
        TextBox9.Text = Convert.ToInt16(button.ID).ToString();
        TextBox9.Enabled = false;
        DataSet chng = dbaccess.FetchData("Select * from User_Master where User_Id='"+TextBox9.Text+"'");
        TextBox3.Text = "";
        DropDownList1.SelectedValue = chng.Tables[0].Rows[0][2].ToString();
        TextBox5.Text = chng.Tables[0].Rows[0][3].ToString();
        TextBox6.Text = chng.Tables[0].Rows[0][4].ToString();
        TextBox7.Text = chng.Tables[0].Rows[0][5].ToString();
        DropDownList2.SelectedValue = chng.Tables[0].Rows[0][6].ToString();
    }
    private void vehiclemakerclick(Object sender, System.EventArgs e)
    {
        Table1.Visible = false;
        Panel1.Enabled = true;
        Panel1.Visible = true;
        Button button = sender as Button;
        TextBox9.Text = Convert.ToInt16(button.ID).ToString();
        TextBox9.Enabled = false;
        DataSet chng = dbaccess.FetchData("Select * from Vehicle_Make_Code where Vehicle_Make_Code='" + TextBox9.Text + "'");
        TextBox3.Visible=false;
        DropDownList1.Visible = false;
        TextBox5.Text = chng.Tables[0].Rows[0][1].ToString();
        TextBox6.Visible = false;
        TextBox7.Visible=false;
        DropDownList2.SelectedValue = chng.Tables[0].Rows[0][4].ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Table1.Controls.Clear();
        Panel1.Visible = false;
        Panel1.Enabled = false;
        if (TextBox3.Text == "")
        {
            DataSet update = dbaccess.UpdateData("update User_Master set User_Role_Id='" + DropDownList1.SelectedValue + "',User_Name='" + TextBox5.Text + "',User_Email='" + TextBox6.Text + "',User_Mobile='" + TextBox7.Text + "',User_Status='" + DropDownList2.SelectedValue + "' where User_Id='" + TextBox9.Text + "'");
        }
        else
        {
            string source = TextBox3.Text;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);
                DataSet update = dbaccess.UpdateData("update User_Master set User_Pass='"+hash+"', User_Role_Id='" + DropDownList1.SelectedValue + "',User_Name='" + TextBox5.Text + "',User_Email='" + TextBox6.Text + "',User_Mobile='" + TextBox7.Text + "',User_Status='" + DropDownList2.SelectedValue + "' where User_Id='" + TextBox9.Text + "'");
            }
        }
        AddControls();
    }
    private void AddControls()
    {
        Table1.Controls.Clear();
        Table1.Visible = true;
        Table1.Enabled = true;
        DataSet users = dbaccess.FetchData("select User_Id,User_Role_Id,User_Name,User_Email,User_Mobile,User_Status from User_Master");
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.Controls.Add(new LiteralControl("UserId"));
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Role"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Name"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Email"));
        title.Cells.Add(t4);
        TableCell t5 = new TableCell();
        t5.Controls.Add(new LiteralControl("Mobile"));
        title.Cells.Add(t5);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("Status"));
        title.Cells.Add(t6);
        Table1.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();
            TableCell c0 = new TableCell();
            c0.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][0].ToString()));
            row.Cells.Add(c0);
            TableCell c1 = new TableCell();
            switch (users.Tables[0].Rows[i][1].ToString())
            {
                case "01": c1.Controls.Add(new LiteralControl("Admin"));
                    break;
                case "02": c1.Controls.Add(new LiteralControl("MIS"));
                    break;
                case "03": c1.Controls.Add(new LiteralControl("Operator"));
                    break;
                case "04": c1.Controls.Add(new LiteralControl("Supervisor"));
                    break;
            }
            row.Cells.Add(c1);
            for (int j = 2; j < 5; j++)
            {

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                row.Cells.Add(c);

            }
            TableCell c6 = new TableCell();
            switch (users.Tables[0].Rows[i][5].ToString())
            {
                case "E": c6.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            row.Cells.Add(c6);
            TableCell c7 = new TableCell();
            Button dynamicbutton = new Button();
            dynamicbutton.ID = users.Tables[0].Rows[i][0].ToString().ToString();
            dynamicbutton.Click += new System.EventHandler(dynamicbutton_Click);
            dynamicbutton.Text = "Edit";
            c7.Controls.Add(dynamicbutton);
            row.Cells.Add(c7);
            Table1.Rows.Add(row);
        }
       ViewState["controlsadded"] = true;
    }
    private void vehicle_model()
    {
        Table1.Visible = true;
        DataSet users = dbaccess.FetchData("select * from Vehicle_Model_Master");
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.Controls.Add(new LiteralControl("Maker"));
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Model"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Description"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Weight in kg"));
        title.Cells.Add(t4);
        TableCell t5 = new TableCell();
        t5.Controls.Add(new LiteralControl("Registration No"));
        title.Cells.Add(t5);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("Last Updated By"));
        title.Cells.Add(t6);
        TableCell t7 = new TableCell();
        t7.Controls.Add(new LiteralControl("Last Update Date"));
        title.Cells.Add(t7);
        TableCell t8 = new TableCell();
        t8.Controls.Add(new LiteralControl("Status"));
        title.Cells.Add(t8);
        Table1.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < 7; j++)
            {

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                row.Cells.Add(c);

            }
            TableCell c8 = new TableCell();
            switch (users.Tables[0].Rows[i][7].ToString())
            {
                case "E": c8.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c8.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            row.Cells.Add(c8);
            TableCell c9 = new TableCell();
            Button dynamicbutton = new Button();
            dynamicbutton.ID = users.Tables[0].Rows[i][0].ToString().ToString();
            dynamicbutton.Click += new System.EventHandler(dynamicbutton_Click);
            dynamicbutton.Text = "Edit";
            c9.Controls.Add(dynamicbutton);
            row.Cells.Add(c9);
            Table1.Rows.Add(row);
        }
        ViewState["mis"] = true;
    }
    private void operate()
    {
        Session["id"] = TextBox1.Text;
        Session["v-o"] = 1;
        Response.Redirect("operator.aspx");
    }
    private void MISview()
    {
        Table1.Visible = false;
        Table1.Enabled = false;
        Table2.Visible = false;
        Table2.Enabled = false;
        Table3.Visible = false;
        Table3.Enabled = false;
        Panel1.Enabled = false;
        Panel1.Visible = false;
        Panel2.Enabled = false;
        Panel2.Visible = false;
        Panel3.Enabled = true;
        Panel3.Visible = true;
        Table4.Enabled = true;
        Table4.Visible = true;
        Table5.Enabled = true;
        Table5.Visible = true;
        Session["Id"] = TextBox1.Text;
        Session["view"] = 2;
        MISviewModel();
        MISviewMaker();
    }
    private void Vehiclemake()
    {
        Table2.Controls.Clear();
        DataSet users = dbaccess.FetchData("select * from Vehicle_Make_Master");
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.Controls.Add(new LiteralControl("Maker Code"));
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Maker Descibtion"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Last Updated By"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Last Updated On"));
        title.Cells.Add(t4);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("Status"));
        title.Cells.Add(t6);
        Table2.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();
            
            for (int j = 0; j < 4; j++)
            {

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                row.Cells.Add(c);

            }
            TableCell c6 = new TableCell();
            switch (users.Tables[0].Rows[i][4].ToString())
            {
                case "E": c6.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            row.Cells.Add(c6);
            TableCell c7 = new TableCell();
            Button dynamicbutton = new Button();
            dynamicbutton.ID = users.Tables[0].Rows[i][0].ToString().ToString();
            dynamicbutton.Click += new System.EventHandler(vehiclemakerclick);
            dynamicbutton.Text = "Edit";
            c7.Controls.Add(dynamicbutton);
            row.Cells.Add(c7);
            Table2.Rows.Add(row);
        }
        ViewState["controls"] = true;
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    private void MISviewModel()
    {
        Table4.Controls.Clear();
        DataSet mis = dbaccess.FetchData("select * from Vehicle_Model_Master");
        TableRow title = new TableRow();
        TableCell Maker = new TableCell();
        Maker.Controls.Add(new LiteralControl("Maker Code"));
        title.Cells.Add(Maker);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Model"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Description"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Weight in Kg"));
        title.Cells.Add(t4);
        TableCell t5 = new TableCell();
        t5.Controls.Add(new LiteralControl("Registration No"));
        title.Cells.Add(t5);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("last updated by"));
        title.Cells.Add(t6);
        TableCell t7 = new TableCell();
        t7.Controls.Add(new LiteralControl("last updated on"));
        title.Cells.Add(t7);
        TableCell t8 = new TableCell();
        t8.Controls.Add(new LiteralControl("status"));
        title.Cells.Add(t8);
        Table4.Rows.Add(title);
        for (int i = 0; i < mis.Tables[0].Rows.Count; i++)
        {
            TableRow t = new TableRow();
            for (int j = 0; j < 7; j++)
            {
                TableCell t9 = new TableCell();
                t9.Controls.Add(new LiteralControl(mis.Tables[0].Rows[i][j].ToString()));
                t.Cells.Add(t9);
            }
            TableCell c6 = new TableCell();
            switch (mis.Tables[0].Rows[i][7].ToString())
            {
                case "E": c6.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            t.Cells.Add(c6);
            Table4.Rows.Add(t);
        }
    }
    private void MISviewMaker()
    {
        Table5.Controls.Clear();
        DataSet users = dbaccess.FetchData("select * from Vehicle_Make_Master");
        TableRow title = new TableRow();
        TableCell UserId = new TableCell();
        UserId.Controls.Add(new LiteralControl("Maker Code"));
        title.Cells.Add(UserId);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Maker Descibtion"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Last Updated By"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Last Updated On"));
        title.Cells.Add(t4);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("Status"));
        title.Cells.Add(t6);
        Table5.Rows.Add(title);
        for (int i = 0; i < users.Tables[0].Rows.Count; i++)
        {
            TableRow row = new TableRow();

            for (int j = 0; j < 4; j++)
            {

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                row.Cells.Add(c);

            }
            TableCell c6 = new TableCell();
            switch (users.Tables[0].Rows[i][4].ToString())
            {
                case "E": c6.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            row.Cells.Add(c6);
            TableCell c7 = new TableCell();
            Table5.Rows.Add(row);
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("view.aspx");
        }
        DataSet s4 = dbaccess.FetchData("select * from Vehicle_Model_Master where " + DropDownList3.SelectedValue + " = '" + TextBox10.Text + "'");
        Table4.Controls.Clear();
        TableRow title = new TableRow();
        TableCell Maker = new TableCell();
        Maker.Controls.Add(new LiteralControl("Maker Code"));
        title.Cells.Add(Maker);
        TableCell que = new TableCell();
        que.Controls.Add(new LiteralControl("Model"));
        title.Cells.Add(que);
        TableCell ya = new TableCell();
        ya.Controls.Add(new LiteralControl("Description"));
        title.Cells.Add(ya);
        TableCell t4 = new TableCell();
        t4.Controls.Add(new LiteralControl("Weight in Kg"));
        title.Cells.Add(t4);
        TableCell t5 = new TableCell();
        t5.Controls.Add(new LiteralControl("Registration No"));
        title.Cells.Add(t5);
        TableCell t6 = new TableCell();
        t6.Controls.Add(new LiteralControl("last updated by"));
        title.Cells.Add(t6);
        TableCell t7 = new TableCell();
        t7.Controls.Add(new LiteralControl("last updated on"));
        title.Cells.Add(t7);
        TableCell t8 = new TableCell();
        t8.Controls.Add(new LiteralControl("status"));
        title.Cells.Add(t8);
        Table4.Rows.Add(title);
        for (int i = 0; i < s4.Tables[0].Rows.Count; i++)
        {
            TableRow t = new TableRow();
            for (int j = 0; j < 7; j++)
            {
                TableCell t9 = new TableCell();
                t9.Controls.Add(new LiteralControl(s4.Tables[0].Rows[i][j].ToString()));
                t.Cells.Add(t9);
            }
            TableCell c6 = new TableCell();
            switch (s4.Tables[0].Rows[i][7].ToString())
            {
                case "E": c6.Controls.Add(new LiteralControl("Active"));
                    break;
                case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                    break;
            }
            t.Cells.Add(c6);
            Table4.Rows.Add(t);
        }
        if (DropDownList3.SelectedValue == "Vehicle_Make_Code")
        {
            Table5.Controls.Clear();
            DataSet users = dbaccess.FetchData("select * from Vehicle_Make_Master where Vehicle_Make_Code='"+TextBox10.Text+"'");
            TableRow title1 = new TableRow();
            TableCell UserId = new TableCell();
            UserId.Controls.Add(new LiteralControl("Maker Code"));
            title1.Cells.Add(UserId);
            TableCell que1 = new TableCell();
            que1.Controls.Add(new LiteralControl("Maker Descibtion"));
            title1.Cells.Add(que1);
            TableCell ya1 = new TableCell();
            ya1.Controls.Add(new LiteralControl("Last Updated By"));
            title1.Cells.Add(ya1);
            TableCell t41 = new TableCell();
            t41.Controls.Add(new LiteralControl("Last Updated On"));
            title1.Cells.Add(t41);
            TableCell t61 = new TableCell();
            t61.Controls.Add(new LiteralControl("Status"));
            title1.Cells.Add(t61);
            Table5.Rows.Add(title1);
            for (int i = 0; i < users.Tables[0].Rows.Count; i++)
            {
                TableRow row = new TableRow();

                for (int j = 0; j < 4; j++)
                {

                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(users.Tables[0].Rows[i][j].ToString()));
                    row.Cells.Add(c);

                }
                TableCell c6 = new TableCell();
                switch (users.Tables[0].Rows[i][4].ToString())
                {
                    case "E": c6.Controls.Add(new LiteralControl("Active"));
                        break;
                    case "D": c6.Controls.Add(new LiteralControl("Deleted"));
                        break;
                }
                row.Cells.Add(c6);
                TableCell c7 = new TableCell();
                Table5.Rows.Add(row);
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("view.aspx");
        }
        MISview();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("view.aspx");
    }
}