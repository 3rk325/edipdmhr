﻿<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="pdplanview.aspx.vb" Inherits="pdplanview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" class="TFtable" width="100%">
    
        <tr>
            <td align="center">
                <asp:ImageButton ID="Btn_Home" runat="server" Height="47px" ImageUrl="~/images/home01.png" Width="45px" />
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text="PD Year : "></asp:Label>
                <asp:DropDownList ID="drp_PDYear" runat="server">
                </asp:DropDownList>
&nbsp;
                <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Text="School: "></asp:Label>&nbsp;<asp:DropDownList ID="drp_schoolname" runat="server" AutoPostBack="True" Width="176px">
    </asp:DropDownList>
                &nbsp;<asp:Label ID="Label7" runat="server" Font-Names="Calibri" Text="Dept: "></asp:Label>
                &nbsp;<asp:DropDownList ID="drp_Dept" runat="server" AutoPostBack="True" Width="176px">
                </asp:DropDownList>
            
                &nbsp;<asp:Label ID="Label12" runat="server" Text="Dept. Status : "></asp:Label>
                <asp:DropDownList ID="ddl_DeptStus" runat="server" Width="150px">
                </asp:DropDownList>
                <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Text="PD Type : "></asp:Label>:
                <asp:DropDownList ID="drp_PDType" runat="server" TabIndex="12" Width="152px" Font-Names="Calibri">
                </asp:DropDownList>
                &nbsp;
        
            <asp:Button ID="but_submit" runat="server" CssClass="butlayout" Text="Apply Filter" Font-Names="Calibri" BackColor="#8080FF" Font-Bold="True" Font-Size="Small" ForeColor="White" />
            <asp:Button ID="BtnClear" runat="server" CssClass="butlayout" Text="Clear" Font-Names="Calibri" BackColor="#8080FF" Font-Bold="True" Font-Size="Small" ForeColor="White" ToolTip=" " />&nbsp;<asp:Button
                ID="BtnExport" runat="server" BackColor="#8080FF" CssClass="butlayout" Font-Bold="True"
                Font-Names="Calibri" Font-Size="Small" ForeColor="White" Text="Export" />
                <asp:Button ID="Btn_Test" runat="server" Text="Test" Width="85px" Visible="False" />
        </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Local : " Visible="False"></asp:Label>
                <asp:TextBox ID="Txt_Local" runat="server" Width="50px" Visible="False" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Text="Travel : " Visible="False"></asp:Label>
                <asp:TextBox ID="Txt_Travel" runat="server" Width="50px" Visible="False" ReadOnly="True"></asp:TextBox>
        </td>
                    </tr>
       <tr>
            <td>
                Last Name</td><td>
               <asp:TextBox ID="txt_LastName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Emp Email : <asp:TextBox ID="txt_Email" runat="server" Width="176px" Font-Names="Calibri" BorderStyle="None"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Text="Course Code: "></asp:Label>
                    <asp:TextBox ID="txt_CourseCode" runat="server" BorderStyle="None" Font-Names="Calibri"
                        Width="128px"></asp:TextBox>
                <asp:TextBox ID="txt_ediStatus" runat="server" BorderStyle="None" Enabled="False"
                    Font-Names="Calibri" Width="32px" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txt_Schname" runat="server" Enabled="False" Width="24px" Font-Names="Calibri" BorderStyle="None" Visible="False">ALL</asp:TextBox>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Text="Emp. No. : "></asp:Label>
                    <asp:TextBox ID="txt_EmpNo" runat="server" BorderStyle="None" Font-Names="Calibri"
                        Width="93px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label15" runat="server" Text="Group ID : "></asp:Label>
                <asp:TextBox ID="Txt_GpID" runat="server"></asp:TextBox>
                </td>
           <td>
               <asp:TextBox ID="TxtUsrN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtSchN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtRolE" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
               <asp:TextBox ID="TxtPdYr" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px" Height="10px"></asp:TextBox>
            </td>
       </tr>
    </table>

    &nbsp;<asp:Label ID="lblErrMsg" runat="server"></asp:Label>
    <asp:GridView ID="GV_PDplan" runat="server" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="pdid" EmptyDataText="No data available." PageSize="25">
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:CommandField HeaderText="Action" ShowCancelButton="False" ShowSelectButton="True" />
            <asp:BoundField DataField="pdid" HeaderText="Update" SortExpression="pdid" Visible="False" />
            <asp:BoundField DataField="schoolname" HeaderText="School Name" SortExpression="schoolname" />
            <asp:BoundField DataField="empno" HeaderText="EmpNo" SortExpression="empno" />
            <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
            <asp:BoundField DataField="position" HeaderText="Position" SortExpression="position" />
            <asp:BoundField DataField="cstartdate" HeaderText="C Start Date" SortExpression="cstartdate" />
            <asp:BoundField DataField="edistatus" HeaderText="EDI Status" SortExpression="edistatus" Visible="False" />
            <asp:BoundField DataField="pdcategory" HeaderText="PD Category" SortExpression="pdcategory" />
            <asp:BoundField DataField="pdneed" HeaderText="PD Title" SortExpression="pdneed">
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="pdcoursecode" HeaderText="PD Course Code" SortExpression="pdcoursecode" />
            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
            <asp:BoundField DataField="deptstus" HeaderText="Status" SortExpression="deptstus" />
            <asp:BoundField DataField="deptcomns" HeaderText="Comments" SortExpression="deptcomns" />
            <asp:BoundField DataField="reqtype" HeaderText="TypeOfRec." SortExpression="reqtype" />
            <asp:BoundField DataField="tbllink" HeaderText="Group ID" SortExpression="tbllink" />
            <asp:BoundField HeaderText="No. of participants" SortExpression="nofparticipants" DataField="nofparticipants">
            <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="totalcost" HeaderText="Total Cost" SortExpression="totalcost" />
            <asp:BoundField DataField="cventreg" HeaderText="Cvent Reg. Status" SortExpression="cventreg" />
            <asp:TemplateField HeaderText="Delete">
    <ItemTemplate>
         <asp:ImageButton id="DeleteButton" CommandName="Delete" ImageUrl="~/images/erase.ico" runat="server" CommandArgument='<%#Eval("pdid")%>' OnClientClick='return confirm("Are you sure you want to delete this item?");' />
    </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:BoundField DataField="pdid" HeaderText="pdid" SortExpression="pdid" Visible="False" />
        </Columns>
        <HeaderStyle BackColor="#999999" ForeColor="White" />
        <PagerSettings Position="Top" />
</asp:GridView>
<br />
<asp:TextBox ID="txt_SchoolID" runat="server" Width="36px" Visible="False"></asp:TextBox>
<asp:TextBox ID="txt_user" runat="server" Width="39px" Visible="False"></asp:TextBox>


</asp:Content>