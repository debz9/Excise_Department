<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <font size="13" face="AR Destine">
            <p>
                 Welcome,
                <asp:Label ID="Label2" runat="server" Text="Label">
                </asp:Label>!
            </p>
            <p>
                You are 
                <asp:Label ID="Label1" runat="server" Text="Label">
                </asp:Label>..
            </p>
        </font>
    </center>
</asp:Content>