<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="superv.aspx.cs" Inherits="superv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:Table ID="Table1" runat="server" Width="60%" BackColor="White" BorderColor="Black" BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid"></asp:Table>
    </center>
    <p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="PRINT" />
    </p>
</asp:Content>

