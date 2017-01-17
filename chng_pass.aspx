<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chng_pass.aspx.cs" Inherits="chng_pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ConfirmOnDelete() {
            if (confirm("Do yo want to change password?") == true)
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
                    <tr>
                        <td style="text-align:left">User Id:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="text-align:left">
                        <td>Enter Old Password:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="text-align:left">
                        <td>Enter New Password:</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="return ConfirmOnDelete()" Text="Change Password" /></td>
                    </tr>
                </table>
                <br />
            </div>
        </b>
        <br />
</asp:Content>