<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pro.aspx.cs" Inherits="pro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ConfirmOnUpdate() {
            if (confirm("Are you sure?") == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <b>
        <div id="fill">
            <br />
            <table>
                <tr style="text-align:left">
                    <td><b>User Id:</b></td>
                    <td><asp:TextBox ID="Label1" runat="server" Text="Label" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr style="text-align:left">
                    <td><b>User Name:</b></td>
                    <td><asp:TextBox ID="Label2" runat="server" Text="Label"></asp:TextBox></td>
                </tr>
                <tr style="text-align:left">
                    <td><b>User Email Id:</b></td>
                    <td><asp:TextBox ID="Label3" runat="server" Text="Label"></asp:TextBox></td>
                </tr>
                <tr style="text-align:left">
                    <td><b>User Mobile No.:</b></td>
                    <td><asp:TextBox ID="Label4" runat="server" Text="Label"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="Update Details" OnClick="Button1_Click" OnClientClick="return ConfirmOnUpdate()"/>
                        <asp:Button ID="Button2" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </b>
    <br />
</asp:Content>

