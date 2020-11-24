<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="pdeditPROVtrv.aspx.vb" Inherits="pdeditPROV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td style="height: 29px" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="text-align: left; width: 704px;" bgcolor="#00CC00">
                <strong>
                <asp:Label ID="Label10" runat="server" Text="PD Provision (Edit) - Travel Form"></asp:Label>
                </strong>
            </td>
            <td style="text-align: right" bgcolor="#00CC00">
            <div>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <fieldset style="border:none">
                        <strong><asp:Label ID="Label9" runat="server" Text="Travel Balance (QR) : "></asp:Label></strong>
                        <asp:TextBox ID="Txt_TrvBal" runat="server" Width="82px" ReadOnly="True"></asp:TextBox>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </td>
        </tr>
        <tr>
            <td style="height: 31px" colspan="2">
                <table style="width: 100%" bgcolor="Silver">
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Department Status : "></asp:Label>
                        </td>
                        <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="ddl_DeptStus" runat="server" Width="150px" Height="22px" TabIndex="1">
                            </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Department Comments : "></asp:Label>
                        </td>
                        <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_DeptComns" runat="server" Width="400px" TabIndex="11"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                     <tr>
                        <td style="text-align: right">
                            <strong>PD Category : </strong>
                        </td>
                        <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:DropDownList ID="drp_Category" runat="server" Width="273px" Height="22px" TabIndex="2">
                            </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 32px" bgcolor="Silver"><strong>PD Need : </strong> </td>
                        <td style="height: 32px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_pdneed" runat="server" Width="500px" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_pdneed" runat="server" ErrorMessage="Enter PD Need."></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right; height: 32px" bgcolor="Silver"><strong>Fees (QR) : </strong> </td>
                        <td style="height: 32px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_SFees" runat="server" AutoPostBack="True" TabIndex="12"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 30px" bgcolor="Silver"><strong>City &amp; Country : </strong> </td>
                        <td style="height: 30px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="Txt_City" runat="server" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_City" ErrorMessage="Enter City Name. "></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="drp_CountryNames" runat="server" Height="22px" Width="217px" TabIndex="5">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drp_CountryNames" ErrorMessage="Select Country."></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right; height: 30px" bgcolor="Silver"><strong>Ticket Cost (QR): </strong> </td>
                        <td style="height: 30px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_STravelCost" runat="server" AutoPostBack="True" TabIndex="13"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
<td style="width: 163px; text-align: right;"><strong>PD Start Date :&nbsp; (DD/MM/YYYY) </strong> </td>
            <td style="width: 500px">
    <div>
        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                    <asp:TextBox ID="TStartDte" runat="server" Width="87px" TabIndex="6"></asp:TextBox>
                    &nbsp;<asp:Button ID="BtnStartDte" runat="server" Text="Calender" TabIndex="7" />
                    &nbsp;<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Visible="False" Width="200px" TabIndex="8">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:TextBox ID="TxtSemester" runat="server" Enabled="False" TabIndex="9"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
                        <td style="text-align: right; height: 34px" bgcolor="Silver"><strong>Per Diem (QR) : </strong></td>
                        <td style="height: 34px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_Sperdiem" runat="server" AutoPostBack="True" TabIndex="14"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 28px" bgcolor="Silver"><strong>No of Participants :</strong></td>
                        <td style="height: 28px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_NoOfParti" runat="server" TabIndex="10" ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_NoOfParti" ErrorMessage="Enter No. of participants."></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                        <td style="text-align: right; height: 28px" bgcolor="Silver"><strong>Total Cost (QR) : </strong> </td>
                        <td style="height: 28px" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                            <asp:TextBox ID="txt_TotCost" runat="server" ReadOnly="True" TabIndex="15"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right" bgcolor="Silver"><strong></strong>
                            <asp:TextBox ID="txt_RtnForm" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_tblink" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txt_pdid" runat="server" Width="10px" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtUser" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txt_SchoolID" runat="server" Visible="False" Width="10px"></asp:TextBox>
                        </td>
                        <td class="auto-style2" bgcolor="Silver">
                            <asp:Button ID="but_submit" runat="server" Text="Update" Width="137px" TabIndex="16" />
                        </td>
                        <td style="text-align: right" bgcolor="Silver">
                            <asp:Button ID="Btn_MoMsgBx" runat="server" Text="Mo Msg Box" Visible="False" />
                            <asp:TextBox ID="Txt_EmpNo_PrevRec" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_FldChanges" runat="server" Visible="False" Width="10px">No</asp:TextBox>
                            <strong>
                            <asp:TextBox ID="TxtUsrN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtSchN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtRolE" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="TxtPdYr" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="10px"></asp:TextBox>
                            </strong></td>
                        <td bgcolor="Silver">
                            <asp:TextBox ID="Txt_OldTotCost" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_ParaM" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="Txt_SchName" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:TextBox ID="txt_OldnofPart" runat="server" Visible="False" Width="10px"></asp:TextBox>
                            <asp:Button ID="BtnClose" runat="server" Text="Close" Width="95px" TabIndex="17" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" bgcolor="#FF9900" style="height: 9px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
              <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Text="Emp. Email * :  "></asp:Label>
                <asp:TextBox ID="txt_SEmail" runat="server" BorderStyle="None" Font-Names="Calibri" Width="217px" TabIndex="18" Height="20px"></asp:TextBox>&nbsp;
                or &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Calibri" Text="Emp. No.:"></asp:Label>
                <asp:TextBox ID="txt_SEmpNo" runat="server" BorderStyle="None" Font-Names="Calibri" Width="116px" TabIndex="19" Height="20px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_SEmpNo"
                    ErrorMessage="*" ValidationGroup="ss"></asp:RequiredFieldValidator>
                    &nbsp;
                            <asp:Button ID="btn_Getrecord" runat="server" Text="Search" Width="113px" TabIndex="20" />
                    &nbsp;&nbsp;<asp:Button ID="btnSclear" runat="server" Text="Clear" Width="80px" TabIndex="21" />
                <asp:Button ID="Btn_GetRec" runat="server" Text="Add Record (Old)" Width="133px" Visible="False" TabIndex="22" />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td style="height: 43px; width: 704px;" bgcolor="Silver" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                First Name :
                <asp:TextBox ID="txt_firstName" runat="server" ReadOnly="True" TabIndex="23"></asp:TextBox>
&nbsp; Last Name :
                <asp:TextBox ID="txt_LastName" runat="server" ReadOnly="True" TabIndex="24"></asp:TextBox>
&nbsp; Position :
                <asp:TextBox ID="txt_Position" runat="server" ReadOnly="True" TabIndex="25"></asp:TextBox>
&nbsp; Dept. :
                <asp:TextBox ID="txt_Dept" runat="server" ReadOnly="True" TabIndex="26"></asp:TextBox>
&nbsp; School Name :
                <asp:TextBox ID="txt_Center" runat="server" ReadOnly="True" Width="155px" TabIndex="27"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Btn_AddCDRec" runat="server" Height="32px" Text="Add Participant(s)" Width="118px" TabIndex="28" />
                &nbsp;
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                    </td>
        </tr>
        <tr>
            <td style="height: 39px" colspan="2" bgcolor="Silver">
    <div>
        <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:GridView ID="GV_Childs" runat="server" DataKeyNames="pdid" AutoGenerateColumns="False" Width="1257px" TabIndex="29">
                    <Columns>
                        <asp:BoundField DataField="pdid" HeaderText="PDID" SortExpression="pdid" />
                        <asp:BoundField DataField="empno" HeaderText="Employee No." SortExpression="empno" />
                        <asp:BoundField DataField="pdneed" HeaderText="PD Need" SortExpression="pdneed" />
                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                        <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country" />
                        <asp:BoundField DataField="semester" HeaderText="Date" SortExpression="semester" />
                        <asp:BoundField DataField="nofparticipants" HeaderText="No Of Participants" SortExpression="nofparticipants" Visible="False" />
                        <asp:BoundField DataField="fees" HeaderText="Fees (QR)" SortExpression="fees" />
                        <asp:BoundField DataField="ticketcost" HeaderText="Ticket Cost (QR)" SortExpression="ticketcost" />
                        <asp:BoundField DataField="perdiem" HeaderText="Per Diem (QR)" SortExpression="perdiem" />
                        <asp:BoundField DataField="totalcost" HeaderText="Total Cost (QR)" SortExpression="totalcost" />
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