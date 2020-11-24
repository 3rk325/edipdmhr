Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Configuration
Imports System.Net.Mail
Imports System.Windows.Forms

Partial Class Default2
    Inherits System.Web.UI.Page
    'Public smtpSection As SmtpSection = (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection))
    Public SchName As String = ""
    Public PdYear As String = ""
    Public TrvTotAmt As Integer = 0
    Public LocTotAmt As Integer = 0

    Protected Sub but_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles but_submit.Click
        If (Txt_TrvBal.Text.ToString.Trim = "" Or Txt_TrvBal.Text.ToString() = 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Can't accept your request. Please check the balance.</font></b></p>" : Exit Sub
        If (txt_empno.Text.ToString.Trim = "" And txt_empno.Text.ToString.Trim = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee number can't be Empty...........</font></b></p>" : Exit Sub
        If (txt_Email.Text.ToString.Trim = "" And txt_Email.Text.ToString.Trim = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's email and number can't be Empty...........</font></b></p>" : Exit Sub
        If (txt_pdneed.Text.Trim.ToString = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter PD Need information...........</font></b></p>" : Exit Sub
        'If (txt_SEmail.Text.ToString.Trim = "" And txt_SEmpNo.Text.ToString.Trim = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's email and number can't be Empty...........</font></b></p>" : Exit Sub
        If drp_Category.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose Category...........</font></b></p>" : Exit Sub
        If (Txt_City.Text.Trim.ToString = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter City and Country...........</font></b></p>" : Exit Sub

        'If TStartDte.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date.</font></b></p>" : Exit Sub
        'If Not updatepdinfo.DateChk(TStartDte.Text.Trim) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date (DD/MM/YYYY).</font></b></p>" : Exit Sub

        Try
            If (txt_SFees.Text.Trim.ToString) = "" Then txt_SFees.Text = "0"
            If (txt_STravelCost.Text.Trim.ToString = "") Then txt_STravelCost.Text = "0"
            If (txt_Sperdiem.Text.Trim.ToString = "") Then txt_Sperdiem.Text = "0"

            Dim updatepdinfo As careerDb = New careerDb()
            Dim CourseStartDate As Date = "1/1/1900"
            If TStartDte.Text.Trim.ToString = "" Then
                CourseStartDate = "1/1/1900"
                TxtSemester.Text = ""
            Else
                If (Not updatepdinfo.DateChk(TStartDte.Text.Trim)) Then
                    lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date (DD/MM/YYYY).</font></b></p>"
                    Exit Sub
                End If
                CourseStartDate = Format(CDate(TStartDte.Text.Trim), "dd/MM/yyyy")
            End If

            Dim Ds As DataSet = New DataSet
            Dim Rst As Boolean = True
            'Dim A As Integer = 0

            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))

            ''Call updatepdinfo.GetBudgetData(txt_SchoolID.Text.ToString.Trim)
            'Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            'Txt_TrvBal.Text = updatepdinfo.TrvTotAmt

            '23 oct 2017'''''Start
            'If (Decimal.Parse(txt_TotCost.Text) > Decimal.Parse(Txt_TrvBal.Text.Trim)) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to insufficient balance can't accept your request. Please check the balance amount.</font></b></p>" : Exit Sub
            '23 oct 2017'''''End

            'If drp_DeptStatus.SelectedItem.Text = "Allocated" Then
            '    Ds = updatepdinfo.UpdatePDinfobyDept02(txt_pdid.Text.ToString, drp_DeptStatus.SelectedItem.Text, Txt_DeptComnts.Text.ToString, txtUser.Text.Trim.ToString)
            '    lblErrMsg.Text = "<p><b><font color='#006400'>Record updated.</font></b></p>"
            '    Lock_Fields4Approval()
            '    'Lock_Fields4Attended()
            '    Exit Sub
            'End If

            'Dim Amt2add As Decimal = 0.0
            'Dim Amt2minus As Decimal = 0.0
            Dim AmtDifference01 As Decimal = 0.0
            Dim AmtDifference02 As Decimal = 0.0
            Dim NuOfPartici As Integer = 1

            '1. Check total amount changes if any
            If (Txt_OldTotCost.Text.Trim.ToString() <> txt_TotCost.Text.Trim.ToString()) Then
                If (Decimal.Parse(Txt_OldTotCost.Text.Trim.ToString()) > Decimal.Parse(txt_TotCost.Text.Trim.ToString())) Then
                    'Amt2add = (Decimal.Parse(Txt_OldTotCost.Text.Trim.ToString()) - Decimal.Parse(txt_TotCost.Text.Trim.ToString()))
                    AmtDifference01 = (Decimal.Parse(Txt_OldTotCost.Text.Trim.ToString()) - Decimal.Parse(txt_TotCost.Text.Trim.ToString()))
                Else
                    'Amt2minus = (Decimal.Parse(txt_TotCost.Text.Trim.ToString()) - Decimal.Parse(Txt_OldTotCost.Text.Trim.ToString()))
                    AmtDifference02 = (Decimal.Parse(txt_TotCost.Text.Trim.ToString()) - Decimal.Parse(Txt_OldTotCost.Text.Trim.ToString()))
                End If

                Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
                Txt_TrvBal.Text = updatepdinfo.TrvTotAmt
                If (AmtDifference02 > Decimal.Parse(Txt_TrvBal.Text.Trim)) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to insufficient balance can't accept your request. Please check the balance amount.</font></b></p>" : Exit Sub
                Txt_OldTotCost.Text = txt_TotCost.Text

                ''23 Oct 2017'''''Start
                'If (Amt2add > 0) Then
                '    If (txt_SchoolName.Text.Trim.ToString = "RENAD" Or txt_SchoolName.Text.Trim.ToString = "TLC") Then
                '        Ds = updatepdinfo.UpdateBudgetTbl4RENADnTLC(txt_SchoolName.Text.Trim.ToString, Amt2add, "Add")
                '    Else
                '        'Add balance amount to PT/PL's total amount straight away
                '        Rst = updatepdinfo.UpdateBudgetTbl02(Txt_ParaM.Text.Trim.ToString, "Add", txt_SchoolName.Text.Trim.ToString, Amt2add)
                '        'Add into Trans Tbl this transactions
                '    End If
                '    Txt_OldTotCost.Text = txt_TotCost.Text
                'Else
                '    If (txt_SchoolName.Text.Trim.ToString = "RENAD" Or txt_SchoolName.Text.Trim.ToString = "TLC") Then
                '        Ds = updatepdinfo.UpdateBudgetTbl4RENADnTLC(txt_SchoolName.Text.Trim.ToString, Amt2minus, "Minus")
                '    Else
                '        'Deduct need amount from PT/PL's total amount
                '        Rst = updatepdinfo.UpdateBudgetTbl02(Txt_ParaM.Text.Trim.ToString, "Minus", txt_SchoolName.Text.Trim.ToString, Amt2minus)
                '        'Add into Trans Tbl this transactions
                '    End If
                '    Txt_OldTotCost.Text = txt_TotCost.Text
                'End If
                ''23 Oct 2017'''''End

                ''Refresh Travel Balance amount
                ''Call updatepdinfo.GetBudgetData(txt_SchoolID.Text.ToString.Trim)
                'Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
                'Txt_TrvBal.Text = updatepdinfo.TrvTotAmt
            End If

            Rst = updatepdinfo.UpdPDNewReqTravel(txt_pdid.Text.Trim.ToString, txt_empno.Text.ToString.Trim(), drp_Category.SelectedItem.Value.ToString.Trim(), txt_pdneed.Text.ToString.Trim(), Txt_City.Text.ToString.Trim(), drp_CountryNames.SelectedItem.Value.ToString.Trim(), TxtSemester.Text.Trim.ToString(), txt_SFees.Text.ToString.Trim(), txt_STravelCost.Text.ToString.Trim(), txt_Sperdiem.Text.ToString.Trim(), txt_TotCost.Text.ToString.Trim(), Txt_ParaM.Text.ToString, drp_DeptStatus.SelectedItem.Text, Txt_DeptComnts.Text.Trim.ToString, txtUser.Text.ToString.Trim(), txt_SchoolID.Text.Trim.ToString(), CourseStartDate)
            If Rst = False Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Record Not Updated. Please check.</font></b></p>" : Exit Sub

            'Refresh Travel Balance amount
            'Call updatepdinfo.GetBudgetData(txt_SchoolID.Text.ToString.Trim)
            Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_TrvBal.Text = updatepdinfo.TrvTotAmt

            'Refresh_TrvTotBal()
            lblErrMsg.Text = "<p><b><font color='#006400'>Record Saved.</font></b></p>"

            '' Check whether record exist or not
            'pdidNO = Userdetails.GetUserPDIDNo(txt_empno.Text.Trim.ToString, drp_Category.SelectedItem.Value.ToString.Trim())
            'If (pdidNO.Trim <> String.Empty) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Duplicate record found. Please check again.</font></b></p>" : Exit Sub

            'RecStus1 = Userdetails.InsertPDNewReqTravel(txt_empno.Text.ToString.Trim(), drp_Category.SelectedItem.Value.ToString.Trim(), txt_pdneed.Text.ToString.Trim(), Txt_City.Text.ToString.Trim(), drp_CountryNames.SelectedItem.Value.ToString.Trim(), txt_SuggDate.Text.ToString.Trim(), txt_SFees.Text.ToString.Trim(), txt_STravelCost.Text.ToString.Trim(), txt_Sperdiem.Text.ToString.Trim(), txt_TotCost.Text.ToString.Trim(), ReqType, txtUser.Text.ToString.Trim(), txt_SchoolName.Text.Trim.ToString())
            'If RecStus1 = False Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Record Not Updated. Please check.</font></b></p>" : Exit Sub

            ''Total amount deduction from Travel budget
            'rEcStus2 = Userdetails.UpdateBudgetTbl(ReqType, txt_SchoolName.Text.ToString.Trim, Convert.ToInt32(txt_TotCost.Text.Trim))
            'If rEcStus2 = False Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Not able to deduct from main balance. Please check the balance amount.</font></b></p>" : Exit Sub

            ''Retrive record from PDPlanTbl table to store into BudgetedTbl
            'pdidNO = Userdetails.GetUserPDIDNo(txt_empno.Text.Trim.ToString, drp_Category.SelectedItem.Value.ToString.Trim())
            'If (pdidNO.Trim = String.Empty) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Record not found in PDPlanTbl table (" & txt_empno.Text.Trim.ToString & "). Please check again.</font></b></p>" : Exit Sub

            ''Store record into BudgetedTbl table
            'recStus3 = Userdetails.BudgetTblAmendments(pdidNO.Trim, txt_empno.Text.Trim.ToString, txt_SchoolName.Text.Trim.ToString, "New Request", drp_Category.SelectedItem.Value.ToString.Trim(), txt_TotCost.Text, txtUser.Text.Trim.ToString)
            ''If recStus3 = False Then
            ''    Dim MsgBox1 As Integer = 0
            ''    Dim Tst As String = ""
            ''    Tst = Userdetails.ErrDetails.ToString
            ''    MsgBox1 = MessageBox.Show(Tst)
            ''End If

            'If recStus3 = False Then lblErrMsg.Text = Userdetails.ErrDetails.ToString & "---" & "<p><b><font color='#FF0000'>Not able to register into Budgeted table (" & txt_empno.Text.Trim.ToString & "). Please check again.</font></b></p>" : Exit Sub

            ''Call Userdetails.GetBudgetData(txt_SchoolName.Text.ToString.Trim)
            ''Txt_TrvBal.Text = Userdetails.TrvTotAmt

            ''Refresh_TrvTotBal()
            'lblErrMsg.Text = "<p><b><font color='#006400'>Record Saved.</font></b></p>"

        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub Lock_Fields()
        txt_SEmail.Enabled = False
        txt_SEmpNo.Enabled = False
        txt_empno.Enabled = False
        txt_firstName.Enabled = False
        txt_lastname.Enabled = False
        txt_Position.Enabled = False
        txt_SchoolID.Enabled = False
        'drp_DeptStatus.Enabled = False
        txt_TotCost.Enabled = False
        txt_pdneed.Enabled = False
        drp_Category.Enabled = False
        'Txt_DeptComnts.Enabled = False
        txt_Email.Enabled = False
        Txt_City.Enabled = False
        drp_CountryNames.Enabled = False
        txt_SFees.Enabled = False
        txt_STravelCost.Enabled = False
        txt_Sperdiem.Enabled = False
        'ddl_StartDate.Enabled = False
        TStartDte.Enabled = False
        BtnStartDte.Enabled = False
        TxtSemester.Enabled = False
        btn_Getrecord.Enabled = False
        btnSclear.Enabled = False
        'Btn_Calender.Enabled = False
        but_submit.Enabled = False
        BtnClear.Enabled = False
    End Sub
    Public Sub Lock_Fields4Allocated()
        drp_DeptStatus.Enabled = False
        Txt_DeptComnts.Enabled = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Username") = "" Then
            Response.Redirect("default.aspx")
        End If

        Try
            If Not Page.IsPostBack Then
                txt_SchoolID.Text = "" & Session.Item("school").ToString
                txtUser.Text = "" & Session.Item("Username").ToString
                txt_pdid.Text = Request.QueryString("pdid")
                txt_RtnForm.Text = Request.QueryString("RtnPath")

                TxtUsrN.Text = "" & Session.Item("UserName").ToString
                TxtSchN.Text = "" & Session.Item("school").ToString
                TxtRolE.Text = "" & Session.Item("Role").ToString
                TxtPdYr.Text = "" & Session.Item("pdneedyr").ToString

                'ViewState("username") = "" & Session.Item("UserName").ToString
                'ViewState("schname") = "" & Session.Item("school").ToString
                'ViewState("role") = "" & Session.Item("Role").ToString
                'ViewState("pdneedyr") = "" & Session.Item("pdneedyr").ToString

                'txtUser.Text = "" & Session.Item("Username").ToString
                txt_SFees.Attributes.Add("onblur", "findtotalamt()")
                txt_STravelCost.Attributes.Add("onblur", "findtotalamt()")
                txt_Sperdiem.Attributes.Add("onblur", "findtotalamt()")

                'txt_SFees.Attributes.Add("onchange", "findtotalamt()")
                'txt_STravelCost.Attributes.Add("onchange", "findtotalamt()")
                'txt_Sperdiem.Attributes.Add("onchange", "findtotalamt()")

                Dim GetUserdetails As careerDb = New careerDb()
                ' load Category
                Dim Ds1 As DataSet = New DataSet()
                Dim Pmtr As String = "pdtype"
                Dim PDType As String = "Travel"
                Ds1 = GetUserdetails.Getpdcategory02(Pmtr, PDType, "")
                Dim dv1 As New DataView(Ds1.Tables("cat"))
                drp_Category.DataSource = dv1
                drp_Category.DataTextField = "category"
                drp_Category.DataValueField = "category"
                drp_Category.DataBind()
                drp_Category.Items.Insert(0, "Select an Item")
                drp_Category.SelectedIndex = 0
                'PDdate_Calender1.Visible = False

                'Load Countries Names
                Dim Ds As DataSet = New DataSet
                Ds = GetUserdetails.GetpdmsCountries()
                Dim Dv As DataView = New DataView(Ds.Tables("CountriesList"))
                drp_CountryNames.DataSource = Dv
                drp_CountryNames.DataTextField = "country_name"
                drp_CountryNames.DataValueField = "country_name"
                drp_CountryNames.DataBind()
                drp_CountryNames.Items.Insert(0, "Open")
                drp_CountryNames.SelectedIndex = 0

                Dim Ds3 As DataSet = New DataSet()
                Ds3 = GetUserdetails.GetDeptStatus(TxtRolE.Text.Trim)
                Dim dv3 As New DataView(Ds3.Tables("deptstatus"))
                drp_DeptStatus.DataSource = dv3
                drp_DeptStatus.DataTextField = "deptstatus"
                drp_DeptStatus.DataValueField = "deptstatus"
                'drp_DeptStatus.Items.Insert(0, String.Empty)
                drp_DeptStatus.DataBind()

                'Dim Ds5 As DataSet = New DataSet()
                'Ds5 = GetUserdetails.GetSemesterData()
                'Dim dv5 As New DataView(Ds5.Tables("SemData"))
                'ddl_StartDate.DataSource = dv5
                'ddl_StartDate.DataTextField = "des"
                'ddl_StartDate.DataValueField = "des"
                'ddl_StartDate.Items.Insert(0, String.Empty)
                'ddl_StartDate.DataBind()

                'Retrive records
                Dim Ds2 As DataSet = New DataSet()
                Ds2 = GetUserdetails.Getpddetailbypdid02(txt_pdid.Text.ToString.Trim())
                Dim dv2 As New DataView(Ds2.Tables("pdPlanViewEdit"))
                txt_empno.Text = "" & dv2.Table.Rows(0)("empno")
                txt_SEmpNo.Text = txt_empno.Text
                txt_firstName.Text = "" & dv2.Table.Rows(0)("firstname")
                txt_lastname.Text = "" & dv2.Table.Rows(0)("lastname")
                txt_Position.Text = "" & dv2.Table.Rows(0)("position")
                'txt_SchoolName.Text = "" & dv2.Table.Rows(0)("centername")
                'txt_SchoolName.Text = "" & dv2.Table.Rows(0)("schoolname")
                txt_SchoolID.Text = "" & dv2.Table.Rows(0)("schoolname")
                drp_DeptStatus.SelectedIndex = drp_DeptStatus.Items.IndexOf(drp_DeptStatus.Items.FindByValue(dv2.Table.Rows(0)("deptstus")))
                txt_OldDeptStus.Text = "" & dv2.Table.Rows(0)("deptstus")
                Txt_DeptComnts.Text = "" & dv2.Table.Rows(0)("deptcomns")
                txt_pdneed.Text = "" & dv2.Table.Rows(0)("pdneed")
                drp_Category.SelectedIndex = drp_Category.Items.IndexOf(drp_Category.Items.FindByValue(dv2.Table.Rows(0)("pdcategory")))
                txt_Email.Text = "" & dv2.Table.Rows(0)("email")
                txt_SEmail.Text = txt_Email.Text
                Txt_City.Text = "" & dv2.Table.Rows(0)("city")
                drp_CountryNames.SelectedIndex = drp_CountryNames.Items.IndexOf(drp_CountryNames.Items.FindByValue(dv2.Table.Rows(0)("country")))
                'txt_SFees.Text = "" & dv2.Table.Rows(0)("fees")
                txt_SFees.Text = "" & dv2.Table.Rows(0)("Expr4")
                If txt_SFees.Text = "" Then txt_SFees.Text = "0"
                txt_STravelCost.Text = "" & dv2.Table.Rows(0)("ticketcost")
                If txt_STravelCost.Text = "" Then txt_STravelCost.Text = "0"
                txt_Sperdiem.Text = "" & dv2.Table.Rows(0)("perdiem")
                If txt_Sperdiem.Text = "" Then txt_Sperdiem.Text = "0"
                txt_TotCost.Text = "" & dv2.Table.Rows(0)("totalcost")
                If txt_TotCost.Text = "" Then txt_TotCost.Text = "0"
                Txt_OldTotCost.Text = txt_TotCost.Text
                'txt_SuggDate.Text = "" & dv2.Table.Rows(0)("pdsdate")
                'ddl_StartDate.SelectedIndex = ddl_StartDate.Items.IndexOf(ddl_StartDate.Items.FindByValue(dv2.Table.Rows(0)("semester")))

                TxtSemester.Text = "" & dv2.Table.Rows(0)("semester")
                If (Not Convert.IsDBNull(dv2.Table.Rows(0)("cstartdte"))) Then
                    If (dv2.Table.Rows(0)("cstartdte").ToString() = "1/1/1900" Or dv2.Table.Rows(0)("cstartdte").ToString() = "1/1/1900 12:00:00 AM") Then
                        TStartDte.Text = String.Empty
                    Else
                        'TStartDte.Text = "" & dv2.Table.Rows(0)("cstartdte").ToString()
                        TStartDte.Text = "" & Format(CDate(dv2.Table.Rows(0)("cstartdte")), "dd/MM/yyyy")
                    End If
                Else
                    TStartDte.Text = String.Empty
                End If

                Txt_ParaM.Text = "" & dv2.Table.Rows(0)("reqtype")

                'txt_OldDeptStus.Text.Trim = "Allocated" Or 
                If (drp_DeptStatus.SelectedItem.Text = "Allocated") Then
                    Lock_Fields()
                    Lock_Fields4Allocated()
                ElseIf (TxtUsrN.Text.ToLower = "puefinance" Or TxtUsrN.Text.ToLower = "puehumanr") Then
                    Lock_Fields()
                    'Lock_Fields4Allocated()
                End If

                'Refresh Travel Balance amount
                'Call GetUserdetails.GetBudgetData(txt_SchoolID.Text.ToString.Trim)
                Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
                Txt_TrvBal.Text = GetUserdetails.TrvTotAmt

            End If
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try

    End Sub
    Private Sub getempdetails()
        Try
            lblErrMsg.Text = ""
            Dim GetUserdetails As careerDb = New careerDb()
            Dim Ds As DataSet = New DataSet()

            'Ds = GetUserdetails.Getpddetails(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, drp_EdiStatus.SelectedItem.Value.ToString.Trim())
            Ds = GetUserdetails.getempdetails(txt_SchoolID.Text.ToString.Trim(), txt_SEmpNo.Text.ToString.Trim(), txt_SEmail.Text.ToString.Trim())
            Dim dv As New DataView(Ds.Tables("empdetails"))
            If dv.Table.Rows.Count > 0 Then
                txt_empno.Text = "" & dv.Table.Rows(0)("empno")
                txt_Position.Text = "" & dv.Table.Rows(0)("position")
                txt_firstName.Text = "" & dv.Table.Rows(0)("firstname")
                txt_lastname.Text = "" & dv.Table.Rows(0)("lastname")
                txt_Email.Text = "" & dv.Table.Rows(0)("email")
                txt_SEmpNo.Text = "" & dv.Table.Rows(0)("empno")
                txt_SEmail.Text = "" & dv.Table.Rows(0)("email")
                BtnPDHistory.Enabled = True
                lblErrMsg.Text = ""
            Else
                txt_empno.Text = ""
                txt_Position.Text = ""
                txt_firstName.Text = ""
                txt_lastname.Text = ""
                txt_Email.Text = ""
                BtnPDHistory.Enabled = False
            End If
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btn_Getrecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Getrecord.Click
        If (txt_SEmail.Text.ToString.Trim = "" And txt_SEmpNo.Text.ToString.Trim = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's email and number can't be Empty...........</font></b></p>" : Exit Sub
        Call getempdetails()
    End Sub

    Protected Sub btnSclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSclear.Click
        Try
            Dim getUsrDetails As careerDb = New careerDb()
            Call getUsrDetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_TrvBal.Text = getUsrDetails.TrvTotAmt

            txt_SEmpNo.Text = ""
            txt_SEmail.Text = ""
            lblErrMsg.Text = ""

            ''txt_SchoolID.Text = ""
            'txt_firstName.Text = ""
            'txt_lastname.Text = ""
            'txt_empno.Text = ""
            'txt_Position.Text = ""
            'txt_Email.Text = ""
            'Panel1.Visible = False
            'BtnPDHistory.Enabled = False
            'txt_SEmail.Focus()

            drp_DeptStatus.SelectedIndex = 0
            Txt_DeptComnts.Text = ""
            txt_pdneed.Text = ""
            drp_Category.SelectedIndex = 0
            Txt_City.Text = ""
            drp_CountryNames.SelectedIndex = 0
            'ddl_StartDate.SelectedIndex = 0
            txt_SFees.Text = 0
            txt_STravelCost.Text = 0
            txt_Sperdiem.Text = 0
            txt_TotCost.Text = 0
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub BtnPDHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPDHistory.Click
        Try
            Panel1.Visible = True
            Dim I As Integer = 0
            Dim TotRec As Integer = 0
            Dim GetUserdetails As careerDb = New careerDb()
            Dim Ds As DataSet = New DataSet()
            'Ds = GetUserdetails.getpdneedhistory02(txt_Email.Text.Trim())
            Ds = GetUserdetails.getpdneedhistory02(txt_empno.Text.Trim.ToString, "pdplantbl", txt_Email.Text.Trim.ToString)
            Dim dV As New DataView(Ds.Tables("pdhistory"))
            TotRec = dV.Table.Rows.Count
            Dim drv As DataRowView
            ' If TotRec = 0 Then Exit Sub

            Dim Dt As DataTable = New DataTable
            Dt.Columns.Add("PD Category")
            Dt.Columns.Add("PD Need")
            Dt.Columns.Add("PD Need Year")
            Dt.Columns.Add("Department Status")
            'Dt.Columns.Add("Sno.")
            For Each drv In dV
                Dt.Rows.Add()
                Dt.Rows(I)("PD Category") = dV.Table.Rows(I)("pdcategory").ToString
                Dt.Rows(I)("PD Need") = dV.Table.Rows(I)("pdneed").ToString
                Dt.Rows(I)("PD Need Year") = dV.Table.Rows(I)("pdneedyear").ToString
                Dt.Rows(I)("Department Status") = dV.Table.Rows(I)("deptstus").ToString
                'Dt.Rows(I)("Sno.") = I
                I = I + 1
            Next
            dV.Dispose()
            Ds.Dispose()

            Dim TotRec02 As Integer = 0
            Dim Ds02 As DataSet = New DataSet()
            Ds02 = GetUserdetails.getpdneedhistory02(txt_empno.Text.Trim.ToString, "pdplan", txt_Email.Text.Trim.ToString)
            Dim dV02 As New DataView(Ds02.Tables("pdhistory"))
            TotRec02 = dV02.Table.Rows.Count
            Dim drv02 As DataRowView

            Dim J As Integer = 0
            For Each drv02 In dV02
                Dt.Rows.Add()
                Dt.Rows(I)("PD Category") = dV02.Table.Rows(J)("pdcategory").ToString
                Dt.Rows(I)("PD Need") = dV02.Table.Rows(J)("pdneed").ToString
                Dt.Rows(I)("PD Need Year") = dV02.Table.Rows(J)("pdneedyear").ToString
                Dt.Rows(I)("Department Status") = dV02.Table.Rows(J)("deptstatus").ToString
                'Dt.Rows(I)("Sno.") = I
                J = J + 1
                I = I + 1
            Next

            grd_pdhistory.DataSource = Dt
            grd_pdhistory.DataBind()

            dV02.Dispose()
            Ds02.Dispose()

            'Panel1.Visible = True
            'Dim GetUserdetails As careerDb = New careerDb()
            'Dim Ds As DataSet = New DataSet()
            ''Ds = GetUserdetails.getpdneedhistory02(txt_Email.Text.Trim())
            'Ds = GetUserdetails.getpdneedhistory02(txt_empno.Text.Trim.ToString, "pdplantbl")
            'grd_pdhistory.DataSource = Ds
            'grd_pdhistory.DataBind()
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        'Try
        '    txt_pdneed.Text = ""
        '    drp_Category.SelectedIndex = 0
        '    Txt_City.Text = ""
        '    drp_CountryNames.SelectedIndex = 0
        '    'txt_priority.Text = 0
        '    ddl_StartDate.SelectedIndex = 0
        '    'txt_simpplan.Text = ""
        '    'txt_SProvider.Text = ""
        '    txt_SFees.Text = 0
        '    txt_STravelCost.Text = 0
        '    txt_Sperdiem.Text = 0
        '    txt_TotCost.Text = 0
        'Catch ex As Exception
        '    lblErrMsg.Text = ex.Message.ToString
        'End Try
    End Sub

    Private Sub Default2_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        ' Modified by Mohan 11/03/2017
        ' You can handle any errors that occur outside of your structured
        ' error handling here.  This Sub is automatically called in the
        ' event of an unhandled run-time error.

        Dim strErrorMessage As String
        strErrorMessage = Request.Url.ToString() & vbCrLf _
         & "<pre>" & Server.GetLastError().ToString() & "</pre>"
        Response.Write(strErrorMessage)
        Server.ClearError()
        Response.Write("<p>Click <a href=""pdentry.aspx"">here</a> to go back to the original page.</p>")

    End Sub

    Private Sub Send_Email_Office(ByVal RecSts As String)

        Dim strRefNo As Integer = 1
        Dim strFromName As String = ""
        Dim strFremail As String = ""
        Dim strToName As String = ""
        Dim strToemail As String = ""
        Dim strCC As String = ""
        Dim strBC As String = ""
        Dim strSubject As String = ""
        Dim strBodyMsg As String = ""
        Dim strBodyMsg2 As String = ""
        'Dim mySmtpClient As SmtpClient
        Dim mm As MailMessage
        'Dim imageResource As LinkedResource
        'Dim htmlView As AlternateView
        Dim i As Integer

        Dim EmpFName As String = ""
        Dim EmpLName As String = ""
        Dim EmpNo As String = ""
        Dim EmpPosition As String = ""
        Dim EmpEmailAdd As String = ""
        Dim EmpSchName As String = ""
        Dim EmpPDNeed As String = ""
        Dim EmpCategory As String = ""
        Dim EmpPDNeedYr As String = ""

        'Dim EmpFName As String = "Madhan"
        'Dim EmpLName As String = "Mohan"
        'Dim EmpNo As String = "18935"
        'Dim EmpPosition As String = "DBA"
        'Dim EmpEmailAdd As String = "smohan@qf.org.qa"
        'Dim EmpSchName As String = "QAD"
        'Dim EmpPDNeed As String = "PD Need"
        'Dim EmpCategory As String = "PD Category"
        'Dim EmpPDNeedYr As String = "2017 - 2018"

        Try
            ''Collecting Employee's details for email
            EmpSchName = txt_SchoolID.Text.ToString.Trim
            EmpFName = txt_firstName.Text.ToString.Trim
            EmpLName = txt_lastname.Text.ToString.Trim
            EmpNo = txt_empno.Text.ToString.Trim
            EmpPosition = txt_Position.Text.ToString.Trim
            EmpEmailAdd = txt_Email.Text.ToString.Trim
            EmpPDNeed = txt_pdneed.Text.ToString.Trim
            EmpCategory = drp_Category.SelectedItem.Text.ToString.Trim
            EmpPDNeedYr = drp_CountryNames.SelectedItem.Text.ToString.Trim

            Dim GetEmailDetail As New careerDb
            Dim Ds As DataSet = New DataSet()
            Ds = GetEmailDetail.ReadEmailDetails(strRefNo)
            Dim dv As New DataView(Ds.Tables("emailvalue"))
            strFromName = "" & dv.Table.Rows(0)("frmname")
            strFremail = "" & dv.Table.Rows(0)("frmemadd")
            strToName = "" & dv.Table.Rows(0)("toname")
            strToemail = "" & dv.Table.Rows(0)("toemadd")
            strCC = "" & dv.Table.Rows(0)("ccadd")
            strBC = "" & dv.Table.Rows(0)("bcadd")
            strSubject = "" & dv.Table.Rows(0)("subj")
            strBodyMsg = "" & dv.Table.Rows(0)("bodymsg")

            Dim [from] As New MailAddress(strFremail, strFromName)
            Dim [to] As New MailAddress(strToemail, strToName)
            mm = New MailMessage([from], [to])
            mm.IsBodyHtml = True

            'System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(txtBody.Text.Trim() + "<image src=cid:HDIImage>", null, "text/html");
            'System.Net.Mail.LinkedResource imageResource = New System.Net.Mail.LinkedResource(Server.MapPath("~/Path/To/YourImage.png"));

            'htmlView = AlternateView.CreateAlternateViewFromString("<image src=cid:HDIImage>", Nothing, "text/html")
            'imageResource = New LinkedResource(Server.MapPath("images/edilogopng.png"))
            ''imageResource = New LinkedResource(Server.MapPath("~/images/edilogopng.png"))
            'htmlView.LinkedResources.Add(imageResource)
            'imageResource.ContentId = "HDIImage"
            'mm.AlternateViews.Add(htmlView)

            'mm.CC = New MailMessage(strCC)
            'mm.Bcc = New MailMessage(strBC)

            If Trim(strCC) <> "" Then
                Dim CCemList As String() = strCC.Split(";")
                For i = 0 To CCemList.Length - 1
                    'myMessage.CC.Add(New MailAddress(CCemList(i)))
                    mm.CC.Add(strCC)
                Next
            End If
            If Trim(strBC) <> "" Then
                Dim BCemList As String() = strBC.Split(";")
                For i = 0 To BCemList.Length - 1
                    'myMessage.Bcc.Add(New MailAddress(BCemList(i)))
                    mm.Bcc.Add(strBC)
                Next
            End If

            'mm.CC.Add(strCC)
            'mm.Bcc.Add(strBC)

            Dim Ttxt As String = String.Empty
            Ttxt = FormatDateTime(Now, DateFormat.LongDate) & " - " & FormatDateTime(Now, DateFormat.LongTime) & "."

            'strBodyMsg2 = "<html>" &
            '"<head>" &
            '"<title>E-Mail Alert Message</title>" &
            '"<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>" &
            '"</head>" &
            '"<body>" &
            '"<p><strong><font color='#07A703'>Hi Officer-In-Charge,</font></strong></p>" &
            '"<p><font color='#800000'><strong>New Service Request has been created into our PD system and it's details are given below.</strong></font></p>" &
            '"<table width='53%' border='1' bordercolor='#6633CC'>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><strong>Employee Name : </strong></font></div></td>" &
            '"<td><strong><font color='#000000'>" & EmpFName & " " & EmpLName & "</font></strong></td>" &
            '"</tr>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><strong>School Name : </strong></font></div></td>" &
            '"<td><strong><font color='#000000'>" & EmpSchName & "</font></strong></td>" &
            '"</tr>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><strong>PD Need : </strong></font></div></td>" &
            '"<td><strong><font color='#000000'>" & EmpPDNeed & "</font></strong></td>" &
            '"</tr>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><strong>Category : </strong></font></div></td>" &
            '"<td><strong><font color='#000000'>" & EmpCategory & "</font></strong></td>" &
            '"</tr>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><strong>PD Need Year : </strong></font></div></td>" &
            '"<td><strong><font color='#000000'>" & EmpPDNeedYr & "</font></strong></td>" &
            '"</tr>" &
            '"<tr>" &
            '"<td><div align='right'><font color='#0000FF'><img src=""edi_icon_1.png"" alt3=""Logo"" /></font></div></td>" &
            '"<td><img src=""~/Images/edi_icon.GIF"" alt2=""Logo2"" />&nbsp;</td>" &
            '"</tr>" &
            '"</table><br><br>" &
            '"<p><strong><font color='#FF0000'>This is system generated email on " & Ttxt.ToString & "</font></strong></p>" &
            '"</body>" &
            '"</html>"

            ''<img src=""~/Images/edilogopng.png"" alt=""Logo"" />
            ''<img src=""edi_icon_1.png"" alt3=""Logo"" />

            ''mm = New MailMessage([from], [to])
            ''mm.From = New MailAddress(smtpSection.From)
            ''mm.To.Add("smohan@qf.org.qa")

            ''If Trim(strCC) <> "" Then
            ''    Dim CCemList As String() = strCC.Split(";")
            ''    For i = 0 To CCemList.Length - 1
            ''        myMessage.CC.Add(New MailAddress(CCemList(i)))
            ''    Next
            ''End If
            ''If Trim(strBC) <> "" Then
            ''    Dim BCemList As String() = strBC.Split(";")
            ''    For i = 0 To BCemList.Length - 1
            ''        myMessage.Bcc.Add(New MailAddress(BCemList(i)))
            ''    Next
            ''End If

            mm.Subject = RecSts
            mm.Body = strBodyMsg2

            'mySmtpClient = New SmtpClient
            'mySmtpClient.Host = smtpSection.Network.Host
            'mySmtpClient.EnableSsl = True
            'Dim NetworkCred As NetworkCredential
            'NetworkCred = New NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password)
            'mySmtpClient.UseDefaultCredentials = True
            'mySmtpClient.Credentials = NetworkCred
            'mySmtpClient.Port = 587
            'mySmtpClient.Send(mm)
            lblErrMsg.Text = "<p><b><font color='#006400'>Saved your request and Email Sent.</font></b></p>"

            ''Dim secObj As SmtpSection()
            ''secObj = New SmtpSection() = ConfigurationManager.GetSection("system.net/mailSettings/smtp")

            '''''''''''''The below setting will read all the data from web.config file through "smtpSection" variable
            'mm = New MailMessage()
            'mm.From = New MailAddress(smtpSection.From)
            'mm.To.Add("smohan@qf.org.qa")
            'mm.Subject = "Hai, Test email"
            'mm.Body = "Hello this is test email from PD System"
            'mySmtpClient = New SmtpClient
            'mySmtpClient.Host = smtpSection.Network.Host
            'mySmtpClient.EnableSsl = True
            'Dim NetworkCred As NetworkCredential
            'NetworkCred = New NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password)
            'mySmtpClient.UseDefaultCredentials = True
            'mySmtpClient.Credentials = NetworkCred
            'mySmtpClient.Port = 587
            'mySmtpClient.Send(mm)
            'lblErrMsg.Text = "Email Sent...."
            '''''''''''''''''''''End reading from web.config file''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Response.Write("An error has occurred: " & ex.ToString())
        Finally
        End Try

    End Sub
    Protected Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles BtnEmail.Click
        'Dim Tle4Email1 As String = ""
        ''Tle4Email = "New Request Created (" & empno & ")"
        ''Tle4Email1 = "New Request Created (18935)"
        ''Tle4Email1 = "New Request Created - " & txt_lastname.Text & " (" & empno & ")"
        'Tle4Email1 = "New Request Created - Madhan Mohan (18935) - End user email"
        ''Send_Email_Office(Tle4Email1)
        'Send_Email_EndUser(Tle4Email1)

    End Sub

    Private Sub Send_Email_EndUser(ByVal Stus As String)
        'Dim strRefNo As Integer = 1
        Dim strFromName As String = ""
        Dim strFremail As String = ""
        Dim strToName As String = ""
        Dim strToemail As String = ""
        'Dim strCC As String = "qf.pdsystem@gmail.com"
        'Dim strBC As String = "qf.pdsystem@gmail.com"
        Dim strSubject As String = ""
        Dim strBodyMsg As String = ""
        Dim strBodyMsg2 As String = ""
        'Dim mySmtpClient As SmtpClient
        Dim mm As MailMessage
        'Dim imageResource As LinkedResource
        'Dim htmlView As AlternateView
        'Dim i As Integer

        Dim EmpFName As String = ""
        Dim EmpLName As String = ""
        Dim EmpNo As String = ""

        Try
            'Collecting Employee's details for email
            'EmpSchName = txt_SchoolID.Text.ToString.Trim
            EmpFName = txt_firstName.Text.ToString.Trim
            EmpLName = txt_lastname.Text.ToString.Trim
            EmpNo = txt_empno.Text.ToString.Trim

            'EmpFName = "Madhan"
            'EmpLName = "Mohan"
            'EmpNo = "18935"
            'txt_lastname.Text = "Mohan"
            'txt_Email.Text = "smohan@qf.org.qa"

            strFromName = "PD Admin System."
            'strFremail = smtpSection.From
            strToName = "" & txt_lastname.Text.Trim
            strToemail = "" & txt_Email.Text.ToString.Trim

            Dim [from] As New MailAddress(strFremail, strFromName)
            Dim [to] As New MailAddress(strToemail, strToName)
            mm = New MailMessage([from], [to])
            'mm.CC.Add(smtpSection.From)
            'mm.Bcc.Add(smtpSection.From)
            mm.IsBodyHtml = True

            Dim Ttxt As String = String.Empty
            Ttxt = FormatDateTime(Now, DateFormat.LongDate) & " - " & FormatDateTime(Now, DateFormat.LongTime) & "."

            'strBodyMsg2 = "<html>" &
            '"<head>" &
            '"<title>E-Mail Alert Message</title>" &
            '"<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>" &
            '"</head>" &
            '"<body>" &
            '"<p><strong><font color='#07A703'>Respected " & EmpLName & ",</font></strong></p>" &
            '"<p><font color='#696969'><strong>Your request has been submitted to EDI department, they will review your request and then revert back to you soon.<br><br>Thank you so much.<br><br>" &
            '"With Regards,<br>System Administrator." & "</strong></font></p><br><br>" &
            '"<p><strong><font color='#FF0000'>This is system generated email on " & Ttxt.ToString & "</font></strong></p>" &
            '"</body>" &
            '"</html>"

            mm.Subject = Stus
            mm.Body = strBodyMsg2

            'mySmtpClient = New SmtpClient
            'mySmtpClient.Host = smtpSection.Network.Host
            'mySmtpClient.EnableSsl = True
            'Dim NetworkCred As NetworkCredential
            'NetworkCred = New NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password)
            'mySmtpClient.UseDefaultCredentials = True
            'mySmtpClient.Credentials = NetworkCred
            'mySmtpClient.Port = 587
            'mySmtpClient.Send(mm)
            'lblErrMsg.Text = "Saved your request and Email Sent."
            lblErrMsg.Text = "<p><b><font color='#006400'>Saved your request and Email Sent.</font></b></p>"
        Catch ex As Exception
            Response.Write("An error has occurred: " & ex.ToString())
        Finally
        End Try
    End Sub

    Protected Sub txt_SFees_TextChanged(sender As Object, e As EventArgs) Handles txt_SFees.TextChanged
        If (txt_SFees.Text.Trim <> "") Then
            '(txt_SFees.Text.Trim <> 0 And txt_SFees.Text.Trim <> "")
            'Fee = Decimal.Parse(txt_SFees.Text)
            'lblTot.Text = Convert.ToString(Fee)
            'txt_TotCost.Text = Convert.ToString(Fee + TrvCost + Pdiem)
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_STravelCost.Focus()
        End If
    End Sub
    Protected Sub txt_STravelCost_TextChanged(sender As Object, e As EventArgs) Handles txt_STravelCost.TextChanged
        If (txt_STravelCost.Text.Trim <> "") Then
            '(txt_STravelCost.Text.Trim <> 0 And txt_STravelCost.Text.Trim <> "")
            'TrvCost = Decimal.Parse(txt_STravelCost.Text)
            'lblTot.Text = Convert.ToString(TrvCost)
            'txt_TotCost.Text = Convert.ToString(Fee + TrvCost + Pdiem)
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_Sperdiem.Focus()
        End If
    End Sub
    Protected Sub txt_Sperdiem_TextChanged(sender As Object, e As EventArgs) Handles txt_Sperdiem.TextChanged
        If (txt_Sperdiem.Text.Trim <> "") Then
            '(txt_Sperdiem.Text.Trim <> 0 And txt_Sperdiem.Text.Trim <> "")
            'Pdiem = Decimal.Parse(txt_Sperdiem.Text)
            'lblTot.Text = Convert.ToString(Pdiem)
            'txt_TotCost.Text = Convert.ToString(Fee + TrvCost + Pdiem)
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_TotCost.Focus()
        End If
    End Sub

    Protected Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Try
            'Response.Redirect("pdplanviewEUS.aspx?Fname=pdplan")
            Select Case txt_RtnForm.Text.Trim.ToString
                Case "pdplanview.aspx"
                    Response.Redirect("pdplanview.aspx?Fname=pdplan")
                    'Response.Redirect("pdeditPROVtrv.aspx?pdid=" & txt_RTpdid.Text.Trim.ToString)
                Case "pdplanviewEUS.aspx"
                    Response.Redirect("pdplanviewEUS.aspx?Fname=pdplan")
                    'Case "pdeditPROVloc.aspx"
                    'Response.Redirect("pdeditPROVloc.aspx?pdid=" & txt_RTpdid.Text.Trim.ToString)
                Case Else
                    'headerRow.ForeColor = System.Drawing.Color.Black
                    'footerRow.ForeColor = System.Drawing.Color.Black
            End Select
        Catch ex As Exception
            Response.Write(ex.Message.ToString.Trim())
        End Try
    End Sub
    Protected Sub drp_DeptStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_DeptStatus.SelectedIndexChanged
        'The below script for Finance And HR department for easy update
        If (drp_DeptStatus.SelectedItem.Text = "Allocated") Then
            Dim updatepdinfo As careerDb = New careerDb()
            Dim Ds As DataSet = New DataSet
            Ds = updatepdinfo.UpdatePDinfobyDept02(txt_pdid.Text.ToString, drp_DeptStatus.SelectedItem.Text, Txt_DeptComnts.Text.ToString, txtUser.Text.Trim.ToString)
            lblErrMsg.Text = "<p><b><font color='#006400'>Record updated.</font></b></p>"
            Lock_Fields()
            Lock_Fields4Allocated()
            Exit Sub
        End If
    End Sub

    Private Sub Default2_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("UserName") = TxtUsrN.Text.Trim.ToString()
        Session("school") = TxtSchN.Text.Trim.ToString()
        Session("Role") = TxtRolE.Text.Trim.ToString()
        Session("pdneedyr") = TxtPdYr.Text.Trim.ToString()

        'Session("UserName") = ViewState("username").ToString()
        'Session("school") = ViewState("schname").ToString()
        'Session("Role") = ViewState("role").ToString()
        'Session("pdneedyr") = ViewState("pdneedyr").ToString()
    End Sub
    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
        Dim Sem2 = New String() {"January", "February", "March", "April", "May", "June"}
        Dim Sem1 = New String() {"July", "August", "September", "October", "November", "December"}
        Dim UsrSctMonth As String = Calendar1.SelectedDate.ToString("MMMM")
        Dim SemNo As String = "Semester2"
        Dim I As Integer = 0
        For I = 0 To 5
            If UsrSctMonth = Sem1(I) Then
                SemNo = "Semester1"
                Exit For
            End If
            'If UsrSctMonth = Sem2(I) Then
            '    SemNo = "Semester2"
            '    Exit For
            'End If
        Next
        TStartDte.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy")
        'TxtSemester.Text = ""
        TxtSemester.Text = SemNo
        Calendar1.Visible = False
    End Sub
    Protected Sub BtnStartDte_Click(sender As Object, e As EventArgs) Handles BtnStartDte.Click
        Calendar1.Visible = True
    End Sub
End Class
