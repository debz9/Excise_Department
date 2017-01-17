<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Log_in.aspx.cs" Inherits="Log_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="Login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <br />
            <CENTER><asp:Button ID="Button1" runat="server" Text="GO TO HOME" OnClick="Button1_Click" /></CENTER>
            <br />
            <div id="container1">
               <center>
                   <div style="color:#ff6a00;font-size:30px"><b>e-আবগারি</b></div>
                   a digital wokspace solution
                   <br />
                   <br />
                   <br /><br /><br />
                   <div style="color:white;font-size:20px">
                       Excise Department
                       <br />
                       Government of West Bengal
                   </div>
                </center>
            </div>
            <div style="margin-left:230px">
                <br />
                <br />
             User Name:
            <asp:TextBox ID="TextBox1" runat="server" Width="140px" BackColor="#000E1C" BorderColor="#3399FF" ForeColor="White" MaxLength="100"></asp:TextBox>
            <br /> &nbsp; Password : <asp:TextBox ID="TextBox2" runat="server" Width="140px" BackColor="#000E1C" BorderColor="#3399FF" ForeColor="White" TextMode="Password"></asp:TextBox>
           &nbsp;&nbsp;
           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/savebuttonex.png" OnClick="ImageButton1_Click" />
                <asp:LinkButton ID="LinkButton1" style="color: #FFFFFF" runat="server" OnClick="LinkButton1_Click">Login</asp:LinkButton></div></div>
       <div style="text-align:center;color:#1c65e9"> Site Designed, hosted and maintained by  National Informatics Centre <br />
        Best viewed with Internet Explorer 10.0 / 11.0 or later . Legal Disclaimer </div>
    </form>
</body>
</html>



