<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pdf.aspx.cs" Inherits="pdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True">
    </asp:DropDownList>

    <asp:Button ID="btnReport" runat="server" Text="Generate Report" OnClick = "GenerateReport" />

</asp:Content>


