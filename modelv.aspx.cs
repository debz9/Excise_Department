using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SelectPdf;
using System.Net;
using System.IO;
//using iTextSharp.text;
//sing iTextSharp.text.pdf;
//using iTextSharp;

public partial class modelv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["wb"] == null)
        {
            Response.Write("<script>confirm('Your session has expired. Please login again.')</script>");
            Response.Redirect("Log_in.aspx");
        }
        else
        {
            tab(datas());
        }

    }
    protected void tab(DataSet user)
    {
        TableHeaderRow hr = new TableHeaderRow();
        TableHeaderCell hc1 = new TableHeaderCell();
        hc1.Text = "Serial No.";
        hr.Cells.Add(hc1);
        TableHeaderCell hc2 = new TableHeaderCell();
        hc2.Text = "Vehicle Make Description";
        hr.Cells.Add(hc2);
        TableHeaderCell hc4 = new TableHeaderCell();
        hc4.Text = "Vehicle Model Description";
        hr.Cells.Add(hc4);
        TableHeaderCell hc5 = new TableHeaderCell();
        hc5.Text = "Gross Vehicle Weight (kg)";
        hr.Cells.Add(hc5);
        TableHeaderCell hc6 = new TableHeaderCell();
        hc6.Text = "Registration No.";
        hr.Cells.Add(hc6);
        Table1.Rows.Add(hr);
        for (int i = 1; i <= user.Tables[0].Rows.Count; i++)
        {
            TableRow r = new TableRow();
            TableCell c1 = new TableCell();
            c1.Text = i.ToString();
            c1.CssClass = "SNO";
            r.Cells.Add(c1);
            for (int j = 0; j < 4; j++)
            {
                TableCell cn = new TableCell();
                cn.Text = user.Tables[0].Rows[i - 1][j].ToString();
                switch(j)
                {
                    case 0:
                        cn.CssClass = "MAKERDESC";
                        break;
                    case 1:
                        cn.CssClass = "MODELDESC";
                        break;
                    case 2:
                        cn.CssClass = "WGT";
                        break;
                    case 3:
                        cn.CssClass = "RNO";
                        break;
                }
                r.Cells.Add(cn);
            }
            Table1.Rows.Add(r);
        }
    }
    protected DataSet datas()
    {
        DataSet get = dbaccess.FetchData("select a.Vehicle_Make_Desc, b.Vehicle_Model_Desc,b.Vehicle_GVW_Kg,b.Vehicle_Reg_No from Vehicle_Make_Master a , Vehicle_Model_Master b where a.Vehicle_Make_Code=b.Vehicle_Make_Code and a.Delete_Status='E' and b.delete_status='E' order by b.Vehicle_Model_Code");
        return get;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string c = "<tr><th><b>SERIAL NO.</b></th><th><b>MAKER DESCRIPTION</b></th><th><b>MODEL DESCRIPTION</b></th><th><b>WEIGHT</b></th><th><b>REGISTRATION NO</b></th></tr>";
        DataSet use = datas();
        for (int i = 0; i < use.Tables[0].Rows.Count;i++ )
        {
            c = c + "<tr><td style='text-align:center; padding:1px 10px 1px 10px'>" + (i + 1).ToString() + "</td><td style=\"padding:1px 10px 1px 10px\">" + use.Tables[0].Rows[i][0].ToString() + "</td><td style=\"padding:1px 10px 1px 10px\">" + use.Tables[0].Rows[i][1].ToString() + "</td><td style='text-align:right; padding:1px 10px 1px 10px'>" + use.Tables[0].Rows[i][2].ToString() + "</td><td style=\"padding:1px 10px 1px 10px\">" + use.Tables[0].Rows[i][3].ToString() + "</td></tr>";
        }
        string s = "<html><body><table border=1 width=100% >"+ c +"</table></body></html>";
        HtmlToPdf converter = new HtmlToPdf();
        SelectPdf.PdfDocument doc = converter.ConvertHtmlString(s);
        doc.Save(Server.MapPath("~/pdf/model.pdf"));
        Session["viewmodel"] = 1;
        Response.Redirect("viewmodel.aspx");

    }
}