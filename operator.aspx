<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="operator.aspx.cs" Inherits="user_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">



    MAKER:<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        VEHICLE MAKER CODE:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        &nbsp;&nbsp; DESCRIPTION:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <br />
    </asp:Panel>
    <br />
    MODEL:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    DESCRIPTION<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    WEIGHT(IN KG):<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    REGISTRATION NO:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />



</asp:Content>


