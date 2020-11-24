<%@ Page Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" Debug="true" CodeFile="pdentryTrvUpd.aspx.vb" Inherits="Default2" title="EDI PD Plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div><p><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"
        Height="32px" Text="PD New Request Form (Travel) - Edit" Width="546px"></asp:Label><strong><asp:Label ID="Label10" runat="server" Text="PD New Request - Travel" CssClass="auto-style3" ForeColor="Red"></asp:Label></strong></p>
    </div>
    <table border="0">
    
    <tr>
    <td valign="top" style="width: 650px" >
    <table border="0" style="width:645px;" class="TFtable">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblErrMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="2" style="width:400px;">
    <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Text="Emp. Email * :  "></asp:Label>
                <asp:TextBox
                    ID="txt_SEmail" runat="server" BorderStyle="None" Font-Names="Calibri" Width="120px" Enabled="False"></asp:TextBox>&nbsp;
                or &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Calibri" Text="Emp. No.:"></asp:Label>
                <asp:TextBox
                    ID="txt_SEmpNo" runat="server" BorderStyle="None" Font-Names="Calibri" Width="48px" TabIndex="1" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_SEmpNo"
                    ErrorMessage="*" ValidationGroup="ss"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>                    
                    </td>
                    <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                        
                        <asp:Button ID="btn_Getrecord" runat="server" BackColor="#8080FF" CssClass="butlayout"
                    Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Text="Get Emp details" ValidationGroup="" Width="128px" TabIndex="2" Enabled="False"/>
                    <asp:Button
                        ID="btnSclear" runat="server" BackColor="#8080FF" CssClass="butlayout" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Text="Clear" TabIndex="3" Enabled="False" />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                        </td>
        </tr>
      <tr>
      <td colspan="3"><br />
      <table border="0" style="width: 600px; font-family:Calibri" class="TFtable">
        <tr>
            <td>Department Status : </td>
            <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:DropDownList ID="drp_DeptStatus" runat="server" Width="150px" AutoPostBack="True" TabIndex="4">
                </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Travel Balance (QR) : "></asp:Label>
                <asp:TextBox ID="Txt_TrvBal" runat="server" Width="82px" ReadOnly="True" TabIndex="5"></asp:TextBox>
                </td>
        </tr>
          <tr>
              <td>Department Comments
              <td colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                  <asp:TextBox ID="Txt_DeptComnts" runat="server" Width="350px" TabIndex="6"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
              </td>
          </tr>
        <tr>
            <td style="width: 261px">Category *   <td colspan="2" >
    <div>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:DropDownList ID="drp_Category" runat="server" TabIndex="7" Width="220px" Enabled="False">
                </asp:DropDownList>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                </td>
        </tr>
        <tr><td>PD Need ( PD Title ) *</td>
        <td colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">            
            <asp:TextBox ID="txt_pdneed" runat="server" Width="360px" TabIndex="8" BorderStyle="Solid" BorderWidth="1px" Enabled="False"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvPN"  ValidationGroup="ss"  runat="server" ControlToValidate="txt_pdneed"  ErrorMessage="Please enter the value!"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                </td></tr>
        <tr>
            <td style="width: 261px">CityCity &amp; Country *</td>
            <td style="width: 360px" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:TextBox ID="Txt_City" runat="server" TabIndex="9" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="drp_CountryNames" runat="server" TabIndex="10" Width="152px" Enabled="False">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCity"  ValidationGroup="ss"  runat="server" ControlToValidate="Txt_City"  ErrorMessage="Please enter the value!"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                </td>
        </tr>
 <!--       <tr>
            <td style="width: 261px; ">PD Priority</td>
            <td ><asp:TextBox ID="txt_priority" runat="server" TabIndex="4" BorderStyle="Solid" BorderWidth="1px" MaxLength="2">0</asp:TextBox>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_priority" Type="Integer"
   Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" Width="176px" Font-Size="Small" /></td>
        </tr> -->
        <tr>
<td style="width: 163px; text-align: left;">PD Start Date (DD/MM/YYYY) </td>
            <td style="width: 500px">
    <div>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                    <asp:TextBox ID="TStartDte" runat="server" Width="87px" TabIndex="11" Enabled="False"></asp:TextBox>
                    &nbsp;<asp:Button ID="BtnStartDte" runat="server" Text="Calender" TabIndex="12" Enabled="False" />
                    &nbsp;<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Visible="False" Width="200px" TabIndex="13">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
            <td style="width: 500px">
     <div>
        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="TxtSemester" runat="server" Enabled="False" TabIndex="14"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
<!--        <tr>
            <td style="width: 261px">School Imp Plan</td>
            <td style="width: 151px"><asp:TextBox ID="txt_simpplan" runat="server" Width="360px" TabIndex="6" BorderStyle="Solid" MaxLength="500" BorderWidth="1px"></asp:TextBox></td>
        </tr> 
        <tr>
            <td style="width: 261px">Suggested Provider / Location</td>
            <td style="width: 151px"><asp:TextBox ID="txt_SProvider" runat="server" Width="360px" TabIndex="7" BorderStyle="Solid" MaxLength="150" BorderWidth="1px"></asp:TextBox></td>
        </tr> -->
        <tr>
            <td style="width: 261px">FeesFees (QR)
            <td colspan="2" >
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_SFees" runat="server" Width="152px" TabIndex="15" BorderStyle="Solid" MaxLength="8" BorderWidth="1px" AutoPostBack="True" Enabled="False" >0</asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvcv"  ValidationGroup="ss"  runat="server" ControlToValidate="txt_SFees" ErrorMessage="Value must be an integer!"></asp:RequiredFieldValidator>
                    </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td style="width: 261px">Ticket Cost (QR) </td>
            <td colspan="2" >
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_STravelCost" runat="server" Width="152px" TabIndex="13" BorderStyle="Solid" MaxLength="8" BorderWidth="1px" AutoPostBack="True" Enabled="False" >0</asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSt" ValidationGroup="ss"  runat="server" ControlToValidate="txt_STravelCost" ErrorMessage="Value must be an integer!"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
   </td>
        </tr>
        <tr>
            <td style="width: 261px">&nbsp;Per Diem (QR) </td>
            <td colspan="2" >
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_Sperdiem" runat="server" Width="152px" TabIndex="17" BorderStyle="Solid" MaxLength="8" BorderWidth="1px" AutoPostBack="True" Enabled="False" >0</asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSpd" ValidationGroup="ss"  runat="server" ControlToValidate="txt_Sperdiem" ErrorMessage="Value must be an integer!"></asp:RequiredFieldValidator>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
   </td>
        </tr>
        <tr>
            <td style="width: 261px">Total Cost (QR) </td>
            <td style="width: 500px" colspan="2">
    <div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:TextBox ID="txt_TotCost" runat="server" Width="152px" TabIndex="18" BorderStyle="Solid" MaxLength="20" BorderWidth="1px" ReadOnly="True" Enabled="False">0</asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td style="width: 261px">
                <asp:TextBox ID="txtUser" runat="server" Font-Names="Calibri"
                    ReadOnly="True" Width="16px" Visible="False" TabIndex="25" Height="16px"></asp:TextBox>
                <asp:TextBox ID="TxtUsrN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
                <asp:TextBox ID="TxtSchN" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
                <asp:TextBox ID="TxtRolE" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
                <asp:TextBox ID="TxtPdYr" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
                * - Mandatory Field</td>
            <td style="width: 600px" colspan="2">
                <asp:Button id="but_submit" ValidationGroup="ss" runat="server" Text="Submit" CssClass="butlayout" TabIndex="19" BorderStyle="None" BackColor="#8080FF" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Enabled="False"></asp:Button>  
                <asp:Button id="BtnClear" runat="server" Text="Clear" CssClass="butlayout" CausesValidation="false" TabIndex="20" BorderStyle="None" BackColor="#8080FF" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Visible="False" Enabled="False"></asp:Button>
                        <asp:Button ID="btn_Close" runat="server" Text="Close" Width="70px" TabIndex="21" BackColor="#8080FF" />
                        <asp:Button ID="BtnEmail" runat="server" Text="Email" Width="46px" Enabled="False" Visible="False" TabIndex="22" />
                        <asp:TextBox ID="txt_pdid" runat="server" Visible="False" Width="16px"></asp:TextBox>
                <asp:TextBox ID="txt_RtnForm" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        <asp:TextBox ID="txt_OldDeptStus" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        <asp:TextBox ID="Txt_OldTotCost" runat="server" Visible="False" Width="16px"></asp:TextBox>
                <asp:TextBox ID="Txt_ParaM" runat="server" Visible="False" Width="16px"></asp:TextBox>
                        <asp:TextBox ID="txt_SchoolID" runat="server" Visible="False" Width="17px"></asp:TextBox>
                        </td>
        </tr>
    </table>
      </td>
      </tr>
    </table>
    
    </td>
    <td rowspan="2" valign="top">
   
    <table border="0" class="TFtable" style="width: 350px; font-family: Calibri; font-size: 10pt;">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" Font-Names="Calibri" ForeColor="Blue" Text="Employee details"></asp:Label></td>
                
                </tr>
                <tr>
                    <td>School</td>
                <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                    
                    <asp:TextBox ID="txt_SchoolName" runat="server" BorderStyle="None" Enabled="False" TabIndex="17" Width="184px"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                </td>
       
  </tr>
                <tr>
                
            <td ><asp:Label ID="Label6" runat="server" Font-Names="Calibri" Text="First Name"></asp:Label></td>
            <td >
    <div>
        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:TextBox ID="txt_firstName" runat="server" BorderStyle="None" Font-Names="Calibri" Width="184px" Enabled="False" TabIndex="21"></asp:TextBox>&nbsp;
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
            </tr>
                <tr>
            <td ><asp:Label ID="Label8" runat="server" Font-Names="Calibri" Text="Last Name" Width="64px"></asp:Label></td>
            <td >
    <div>
        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">
                <asp:TextBox ID="txt_lastname" runat="server" BorderStyle="None" Font-Names="Calibri" Width="184px" Height="18px" Enabled="False" TabIndex="22"></asp:TextBox>&nbsp;
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
            </tr>
                <tr>
        
            <td >Emp No.</td>
            <td >
    <div>
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_empno" runat="server" Width="48px" TabIndex="23" BorderStyle="None"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
                </td>
                    </tr>
                <tr>
            <td><asp:Label ID="Label7" runat="server" Font-Names="Calibri" Text="Position"></asp:Label></td>
            <td >
    <div>
        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_Position" runat="server" BorderStyle="None" Font-Names="Calibri" Width="184px" Height="18px" Enabled="False" TabIndex="24"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr>
            <td>
                Email</td>
            <td>
    <div>
        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
            <ContentTemplate>
                <fieldset style="border:none">                
                <asp:TextBox ID="txt_Email" runat="server" BorderStyle="None" Font-Names="Calibri" Width="184px" Enabled="False" TabIndex="25"></asp:TextBox>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
            </td>
        </tr>
        <tr><td></td>
        <td>
            <asp:Button id="BtnPDHistory" runat="server" Text="View PD Request History" Font-Bold="True" ForeColor="White" BackColor="#8080FF" CssClass="butlayout" CausesValidation="false" Width="184px" Enabled="False" Font-Names="Calibri" TabIndex="26"></asp:Button>
        </td></tr>
        <tr><td colspan="2"><asp:Panel ID="Panel1" runat="server" Visible="False">
    <table  id="tblpdhistory" class="TFtable"  width="100%" style="font-family:Calibri"><tr>
    <td colspan="2" style="width: 195px">PD Request History</td></tr>
                    <tr><td colspan="2" style="width: 195px">
                        <asp:GridView ID="grd_pdhistory" runat="server" Font-Size="Small" TabIndex="27">
                        </asp:GridView>
                    </td></tr>
    </table>
    </asp:Panel>
        </td></tr>
    </table>
    
    </td>
    </tr>
    
    
    </table>
    
    
    
    
    
    
    
</asp:Content>

