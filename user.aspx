<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ConfirmAddUser() {
            if (confirm("Are you sure you want to create/update this new user?") == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="fill">
        <br />
            <b>
                <table style="text-align:left">
                    <tr>
                        <td colspan="1">User Role:</td>
                        <td colspan="1">
                            <asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="00">Select Role</asp:ListItem>
                                <asp:ListItem value="01">Administrator</asp:ListItem>
                                <asp:ListItem value="02">MIS</asp:ListItem>
                                <asp:ListItem value="03">Operator</asp:ListItem>
                                <asp:ListItem value="04">Supervisor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>User ID:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>User Password:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" CausesValidation="True"  TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>User Name:</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" MaxLength="100"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>User Email:</td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server"  TextMode="Email" MaxLength="100"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>User Mobile:</td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server"  TextMode="Phone" MaxLength="10"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>STATUS:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Value="E">ACTIVE</asp:ListItem>
                                <asp:ListItem Value="D">INACTIVE</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="2" style="text-align:center"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="return ConfirmAddUser()" Text="Submit" />&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Button ID="cancel" runat="server" OnClick="cancel_Click" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </b>
        <br />
    </div>
    <br />
    <center>
        <asp:Table ID="Table1" runat="server" Width="80%" BackColor="White" BorderColor="Black" BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
        </asp:Table>
    </center>
</asp:Content>

