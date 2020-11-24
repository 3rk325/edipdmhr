<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="logindetails.aspx.vb" Inherits="Default2" title="Login Credentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="BtnGet" runat="server" Text="User(s) List" Height="33px" Font-Bold="True" />
    <asp:Button ID="BtnCourseList" runat="server" Height="33px" TabIndex="1" Text="Course List" Font-Bold="True" Visible="False" />
    <asp:Button ID="Btn_EmpHistory" runat="server" Font-Bold="True" Height="33px" Text="History Of Recs." Visible="False" />
    <asp:Button ID="Btn_WRpt" runat="server" Text="Weekly Report" Font-Bold="True" Height="33px" Visible="False" />
    <asp:Button ID="Btn_StatiscalRpt" runat="server" Text="Statistical Report" Font-Bold="True" Height="33px" Visible="False" />
    <asp:Button ID="Btn_MicroRpt" runat="server" Text="Employee Rec. Status" Font-Bold="True" Height="33px" Visible="False" />
    <asp:Button ID="Button1" runat="server" Text="Testing Form" Visible="False" />
    <asp:Label ID="Lbl_NoData" runat="server" Text="No Data........." Visible="False"></asp:Label>
    <br />
    <br />
    <br />
</asp:Content>
