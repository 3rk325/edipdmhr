<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="usercredentials.aspx.vb" Inherits="usercredentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lbl_Title" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#FF9900" Text="User Credential Page"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label7" runat="server" Text="Username : "></asp:Label>
                            </strong>
                        </td>
                        <td>
                    <asp:TextBox ID="txtUsrName" runat="server" Width="200px"></asp:TextBox>
                            <asp:TextBox ID="Txt_id" runat="server" Visible="False" Width="24px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label8" runat="server" Text="Password : "></asp:Label>
                            </strong>
                        </td>
                        <td>
                    <asp:TextBox ID="txtPwd" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label9" runat="server" Text="Role : "></asp:Label>
                            </strong>
                        </td>
                        <td>
                    <asp:DropDownList ID="drp_Role" runat="server" Width="200px">
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label10" runat="server" Text="Organization : "></asp:Label>
                            </strong>
                        </td>
                        <td>
                    <asp:DropDownList ID="drp_Org" runat="server" Width="200px">
                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label11" runat="server" Text="Status : "></asp:Label>
                            </strong>
                        </td>
                        <td>
                    <asp:RadioButton ID="RBstus1" runat="server" GroupName="Stus01" Text="Yes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RBstus2" runat="server" GroupName="Stus01" Text="No" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GV_UsrCred" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="1252px">
                    <Columns>
                        <asp:CommandField HeaderText="Action" ShowSelectButton="True" />
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="email" HeaderText="Username" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                        <asp:BoundField DataField="Role" HeaderText="Role" />
                        <asp:BoundField DataField="Organization" HeaderText="Organization" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
