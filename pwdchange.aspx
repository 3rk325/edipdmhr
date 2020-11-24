<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="pwdchange.aspx.vb" Inherits="pwdchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="Panel1" runat="server" Height="198px" Width="1261px">
        <table style="width: 44%" align="center">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="#FF9900" Text="Password Change Page"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td class="auto-style2" style="text-align: right">
                                <asp:Label ID="Label8" runat="server" Text="Username : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_UsrName" runat="server" ReadOnly="True" Width="207px"></asp:TextBox>
                                <asp:TextBox ID="Txt_Id" runat="server" Visible="False" Width="22px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label9" runat="server" Text="New Password : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_Pwd" runat="server" Width="207px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="Btn_Update" runat="server" Font-Bold="True" Text="Modify" Width="106px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblErMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />

</asp:Content>
