<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_master1.aspx.cs" Inherits="user_master1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 257px; width: 557px">
    
        User_id:
        <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Provide valid USER_ID"></asp:RequiredFieldValidator>
        <br />
        User_Pass: <asp:TextBox ID="TextBox2" runat="server" CausesValidation="True"  TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="You can do better"></asp:RequiredFieldValidator>
        <br />
        User_Role_ID:&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" CausesValidation="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Role Id must be 2 character long"></asp:RequiredFieldValidator>
        <br />
        User_Name:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Provide name"></asp:RequiredFieldValidator>
        <br />
        User_Email:&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" CausesValidation="True" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Provide valid email"></asp:RequiredFieldValidator>
        <br />
        User_Mobile:&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" CausesValidation="True" TextMode="Phone"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="provide 10 digit phone number" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
