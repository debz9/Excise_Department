<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="super.aspx.cs" Inherits="super" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ConfirmAddMake() {
            if (confirm("Are you sure that you want to add this make?") == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="fill">
            <br />
            <table>
                <tr style="text-align:left">
                    <td style="font-weight:bold">Vehicle Make Description:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="return ConfirmAddMake()" Text="Add Make" />
                        <asp:Button ID="CANCEL" runat="server" OnClick="CANCEL_Click" Text="Cancel" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
            <br />
            <center>
            <asp:Table ID="Table1" runat="server" Height="23px" Width="75%" BackColor="White" BorderColor="Black" BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
            </asp:Table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField HeaderText="Serial No." >
                    <ItemTemplate>    
                     <%# ((GridViewRow)Container).RowIndex + 1%>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Vehicle_Make_Desc" HeaderText="Vehicle Make Description" SortExpression="Vehicle_Make_Desc" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Vehicle_Make_Desc FROM Vehicle_Make_Master WHERE (Delete_Status = @Delete_Status)">
            <SelectParameters>
                <asp:Parameter DefaultValue="E" Name="Delete_Status" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
</asp:Content>

