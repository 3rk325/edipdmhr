<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="monitorpdbudget.aspx.vb" Inherits="monitorpdbudget" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%">
        <tr>
            <td class="auto-style2">
                <strong>
                <asp:Label ID="Label2" runat="server" CssClass="auto-style3" style="color: #FF3300"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Btn_Calcu" runat="server" Text="Calculate" Width="133px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="PD_GridView01" runat="server">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#FF9900" BorderColor="#33CC33" BorderStyle="Outset" ForeColor="White" />
                    <RowStyle Font-Bold="True" ForeColor="Black" />
                </asp:GridView>

                <asp:GridView ID="Gv_MoniBudget" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Height="233px" Width="1261px" AllowPaging="True" AllowSorting="True" PageSize="12" Visible="False">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="schoolname" HeaderText="School Name" SortExpression="schoolname">
        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:BoundField>
        <asp:BoundField DataField="pdneedyear" HeaderText="PD Need Year" SortExpression="pdneedyear">
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="overallbudget" HeaderText="Overall Budget" SortExpression="overallbudget">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="allocatedtrvamt" HeaderText="Allocated (Travel)" SortExpression="allocatedtrvamt">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="allocatedlocamt" HeaderText="Allocated (Local)" SortExpression="allocatedlocamt">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="budgetedloc" HeaderText="Local Budgeted" SortExpression="budgetedloc">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="allocatedloc" HeaderText="Local Allocated" SortExpression="allocatedloc">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="balanceloc" HeaderText="Balance (Local)" SortExpression="balanceloc">
        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
        </asp:BoundField>
        <asp:BoundField DataField="budgetedtrv" HeaderText="Travel Budgeted" SortExpression="budgetedtrv" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="allocatedtrv" HeaderText="Travel Allocated" SortExpression="allocatedtrv" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="balancetrv" HeaderText="Balance (Travel)" SortExpression="balancetrv" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Total" Visible="False">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server"/></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" Visible="False" />
    </Columns>
    <HeaderStyle BackColor="Silver" ForeColor="#000099" />
</asp:GridView>

            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#0000CC" Text="School Name : "></asp:Label>
                <asp:Label ID="lbl_SchName" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Total Number of Staff : " Font-Bold="True" ForeColor="#0000CC"></asp:Label>
                <asp:Label ID="lbl_TotnoStaff" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#0000CC" Text="Total Number of Staff with Allocated : "></asp:Label>
                <asp:Label ID="lbl_nuofPDstaff" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Total Number of Staff with Budgeted : " Font-Bold="True" ForeColor="#0000CC"></asp:Label>
                <asp:Label ID="lbl_StaffnoPD" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label8" runat="server" Text="Total Number of No PD Staff : " Font-Bold="True" ForeColor="#0000CC"></asp:Label>
                <asp:Label ID="Lbl_NoPDstaff" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><asp:Label ID="Label5" runat="server" Text="Number of PD entries by category" CssClass="auto-style3" Font-Bold="True" ForeColor="#006600"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<div>
                <asp:GridView ID="GV_PDentries" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Available." EnableModelValidation="True" ForeColor="#0033CC" Width="483px">
                    <Columns>
                        <asp:BoundField DataField="Expr1" HeaderText="PD Category" SortExpression="Expr1">
                        <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Expr2" HeaderText="Number of entries" SortExpression="Expr2">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#CC3300" ForeColor="White" />
                </asp:GridView>
                </div>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="Txt_SchoolName" runat="server" Visible="False" Width="10px" Height="10px"></asp:TextBox>
                <asp:TextBox ID="txtUser" runat="server" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtUsrN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtSchN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtRolE" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtPdYr" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>





</asp:Content>
