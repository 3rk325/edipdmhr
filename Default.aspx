<%@ Page Language="VB" MasterPageFile="~/Login.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="EDI PD Plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:Login ID="txtLogin" runat="server" Font-Names="Calibri" ForeColor="Blue" UserNameLabelText="Username:">
     </asp:Login>
    </center>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>

