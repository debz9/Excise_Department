<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="model.aspx.cs" Inherits="model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ConfirmAddModel() {
            if (confirm("Are you sure that you want to add this model?") == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel ID="Panel2" runat="server">
        <div id="fill">
            <br />
            <b>
                <table>
                    <tr style="text-align:left">
                        <td>Vehicle Make Description:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="maker" DataTextField="Vehicle_Make_Desc" DataValueField="Vehicle_Make_Code">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="maker" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Vehicle_Make_Code], [Vehicle_Make_Desc] FROM [Vehicle_Make_Master] ORDER BY [Vehicle_Make_Desc]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr style="text-align:left">
                        <td>Vehicle Model Description:</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" MaxLength="50"></asp:TextBox></td>
                    </tr>
                    <tr style="text-align:left">
                        <td>Gross Vehicle Weight:</td>
                        <td><asp:TextBox ID="TextBox3" runat="server" MaxLength="18" TextMode="Number"></asp:TextBox></td>
                    </tr>
                    <tr style="text-align:left">
                        <td>Registration No.:</td>
                        <td><asp:TextBox ID="TextBox4" runat="server" MaxLength="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="return ConfirmAddModel()" Text="ADD MODEL" />
                            <asp:Button ID="CANCEL" runat="server" OnClick="CANCEL_Click" Text="CANCEL" />
                        </td>
                    </tr>
                </table>
            </b>
            <br />
        </div>
        <br />
        </asp:Panel>
        <center><asp:Table ID="Table1" runat="server" Height="23px" Width="80%" BackColor="White" BorderColor="Black" BorderWidth="2" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
        </asp:Table></center>
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="modeldb">
                <Columns>
                    <asp:TemplateField HeaderText="Serial No." >
                    <ItemTemplate>    
                     <%# ((GridViewRow)Container).RowIndex + 1%>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Vehicle_Make_Desc" HeaderText="Vehicle Make Description" SortExpression="Vehicle_Make_Desc" >
                    <ControlStyle CssClass="MAKEDESC" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vehicle_Model_Desc" HeaderText="Vehicle Model Description" SortExpression="Vehicle_Model_Desc" >
                    <ControlStyle CssClass="MODELDESC" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vehicle_GVW_Kg" HeaderText="Gross Vehicle Weight (kg)" SortExpression="Vehicle_GVW_Kg" >
                    <ControlStyle CssClass="WGT" />
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vehicle_Reg_No" HeaderText="Registration No." SortExpression="Vehicle_Reg_No" >
                    <ControlStyle CssClass="RNO" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </center>
        <asp:SqlDataSource ID="modeldb" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT a.Vehicle_Make_Desc, b.Vehicle_Model_Desc, b.Vehicle_GVW_Kg, b.Vehicle_Reg_No FROM Vehicle_Make_Master AS a INNER JOIN Vehicle_Model_Master AS b ON a.Vehicle_Make_Code = b.Vehicle_Make_Code"></asp:SqlDataSource>
    <br />    
</asp:Content>

