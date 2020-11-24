<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="pdeditPROVloc.aspx.vb" Inherits="pdeditPROVloc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td style="height: 29px" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:Label ID="lblErrMsg" runat="server" BackColor="White" BorderStyle="Groove"></asp:Label>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align: left; width: 704px;" bgcolor="#72E97A">
                <strong>
                <asp:Label ID="Label10" runat="server" Text="PD Provision (Edit) - Local Form"></asp:Label>
                </strong>
            </td>
            <td style="text-align: right" bgcolor="#72E97A">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <fieldset style="border:none">
                                <strong><asp:Label ID="Label9" runat="server" Text="Local Balance (QR) : "></asp:Label></strong>
                                <asp:TextBox ID="Txt_LocBal" runat="server" Width="82px" ReadOnly="True" TabIndex="26"></asp:TextBox>
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 31px" colspan="2" bgcolor="Silver">
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label11" runat="server" Text="Department Status : "></asp:Label>
                            </strong>
                        </td>
                        <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="ddl_DeptStus" runat="server" Width="150px" AutoPostBack="True" Height="22px">
                            </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right">
                            <strong>
                            <asp:Label ID="Label12" runat="server" Text="Department Comments : "></asp:Label>
                            </strong>
                        </td>
                        <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_DeptComns" runat="server" Width="400px" TabIndex="6"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 32px" bgcolor="Silver"><strong>PD Category : </strong> </td>
                        <td style="height: 32px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="drp_Category" runat="server" Width="200px" AutoPostBack="True" TabIndex="1" Height="22px">
                            </asp:DropDownList>
                       <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drp_Category" ErrorMessage="*" ValidationGroup="ss"></asp:RequiredFieldValidator>-->
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
<td style="width: 163px"><strong>PD Start Date (DD/MM/YYYY) :</strong></td>
            <td style="width: 500px">
    <div>
        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                    <asp:DropDownList ID="ddl_CStartDte" runat="server" Width="150px" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;<asp:TextBox ID="TxtSemester" runat="server" Enabled="False" TabIndex="9"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
                    </tr>
                    <tr>
                        <td bgcolor="Silver" style="text-align: right"><strong>Sub Category : </strong> </td>
                        <td bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="ddl_SubCat" runat="server" Width="200px" AutoPostBack="True" TabIndex="2" Height="22px">
                            </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td bgcolor="Silver" style="text-align: right"><strong>No of Participants : </strong></td>
                        <td bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_NoOfParti" runat="server" TabIndex="10" ReadOnly="True">0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_NoOfParti" runat="server" ErrorMessage="Enter No. of participants."></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 30px" bgcolor="Silver"><strong>PD Code : </strong> </td>
                        <td style="height: 30px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="CcodeDDList" runat="server" Height="22px" Width="350px" AutoPostBack="True" TabIndex="3">
                            </asp:DropDownList>
                            <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CcodeDDList" ErrorMessage="Select PD Code."></asp:RequiredFieldValidator>-->
                   </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>                     
                    </td>
                        <td style="text-align: right; height: 30px" bgcolor="Silver"><strong>Fees (QR) : </strong> </td>
                        <td style="height: 30px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_SFees" runat="server" AutoPostBack="True" TabIndex="11">0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txt_SFees" runat="server" ErrorMessage="Enter fees value"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 34px" bgcolor="Silver"><strong>PD Description : </strong> </td>
                        <td style="height: 34px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_pdDes" runat="server" Width="350px" TabIndex="4" ReadOnly="True"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right; height: 34px" bgcolor="Silver"><strong>Total Cost (QR) :</strong></td>
                        <td style="height: 34px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_TotCost" runat="server" ReadOnly="True" TabIndex="12">0</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txt_TotCost" runat="server" ErrorMessage="Total amount can not be empty."></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 28px" bgcolor="Silver"><strong>Comments :</strong></td>
                        <td style="height: 28px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="Txt_FInfo" runat="server" Width="350px" TabIndex="5"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right; height: 28px" bgcolor="Silver"><strong>&nbsp;</strong></td>
                        <td style="height: 28px" bgcolor="Silver">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" bgcolor="Silver"><strong></strong>
                            <asp:TextBox ID="Txt_tblink" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txt_pdid" runat="server" Width="10px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtUser" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txt_SchoolID" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtUsrN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtSchN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtRolE" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtPdYr" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                        </td>
                        <td class="auto-style2" bgcolor="Silver">
                            <asp:Button ID="but_submit" runat="server" Text="Update" Width="137px" TabIndex="13" />
                        </td>
                        <td style="text-align: right" bgcolor="Silver">
                            <asp:TextBox ID="Txt_EmpNo_PrevRec" runat="server" ReadOnly="True" style="margin-left: 56px" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_FldChanges" runat="server" Visible="False" Width="10px">No</asp:TextBox>
                            <asp:TextBox ID="txt_RtnForm" runat="server" Width="10px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txt_OldnofPart" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_OldTotCost" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <strong>
                            <asp:TextBox ID="txt_OldDeptStus" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            </strong>
                            <asp:TextBox ID="Txt_ParaM" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_SchName" runat="server" Visible="False" Width="10px"></asp:TextBox>
                        </td>
                        <td bgcolor="Silver" class="auto-style2">
                            <asp:Button ID="BtnClose" runat="server" Text="Close" Width="95px" TabIndex="14" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" bgcolor="#FF8000" style="height: 9px"></td>
        </tr>
        <tr>
              <td bgcolor="Silver" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
              <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Text="Emp. Email * :  "></asp:Label>
                <asp:TextBox ID="txt_SEmail" runat="server" BorderStyle="None" Font-Names="Calibri" Width="217px" TabIndex="15" Height="20px"></asp:TextBox>&nbsp;
                or &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Calibri" Text="Emp. No.:"></asp:Label>
                <asp:TextBox ID="txt_SEmpNo" runat="server" BorderStyle="None" Font-Names="Calibri" Width="116px" TabIndex="16" Height="20px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_SEmpNo"
                    ErrorMessage="*" ValidationGroup="ss"></asp:RequiredFieldValidator>
                    &nbsp;
                            <asp:Button ID="btn_Getrecord" runat="server" Text="Search" Width="113px" TabIndex="17" />
                    &nbsp;&nbsp;<asp:Button ID="btnSclear" runat="server" Text="Clear" Width="80px" TabIndex="18" />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td style="height: 43px; " bgcolor="#CCCCCC" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                &nbsp;First Name :
                <asp:TextBox ID="txt_firstName" runat="server" ReadOnly="True" TabIndex="19"></asp:TextBox>
&nbsp; Last Name :
                <asp:TextBox ID="txt_LastName" runat="server" ReadOnly="True" TabIndex="20"></asp:TextBox>
&nbsp; Position :
                <asp:TextBox ID="txt_Position" runat="server" ReadOnly="True" TabIndex="21"></asp:TextBox>
&nbsp; Dept. :
                <asp:TextBox ID="txt_Dept" runat="server" ReadOnly="True" TabIndex="22"></asp:TextBox>
&nbsp; School Name :
                <asp:TextBox ID="txt_Center" runat="server" ReadOnly="True" Width="155px" TabIndex="23"></asp:TextBox>
&nbsp;<asp:Button ID="Btn_AddCDRec" runat="server" Height="32px" Text="Add Participant(s)" Width="122px" TabIndex="24" />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td style="height: 39px" colspan="2" bgcolor="#CCCCCC">
    <div>
        <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:GridView ID="GV_Childs" runat="server" DataKeyNames="pdid" AutoGenerateColumns="False" Width="1257px" TabIndex="25" style="margin-top: 0px">
                    <Columns>
                        <asp:BoundField DataField="pdid" HeaderText="PDID" SortExpression="pdid" />
                        <asp:BoundField DataField="empno" HeaderText="Employee No." SortExpression="empno" />
                        <asp:BoundField DataField="pdcategory" HeaderText="PD Category" SortExpression="pdcategory" />
                        <asp:BoundField DataField="pdcoursecode" HeaderText="PD Code" SortExpression="pdcoursecode" />
                        <asp:BoundField HeaderText="PD Descritpion" Visible="False" />
                        <asp:BoundField DataField="furtherinfo" HeaderText="Further Information" SortExpression="furtherinfo" />
                        <asp:BoundField DataField="semester" HeaderText="Date" SortExpression="semester" />
                        <asp:BoundField DataField="nofparticipants" HeaderText="No Of Participants" SortExpression="nofparticipants" Visible="False" />
                        <asp:BoundField DataField="fees" HeaderText="Fees (QR) " SortExpression="fees" />
                        <asp:BoundField DataField="totalcost" HeaderText="Total Cost (QR) " SortExpression="totalcost" />
                        <asp:CommandField HeaderText="Delete" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/erase3.bmp" />
                    </Columns>
                </asp:GridView>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>

</asp:Content>