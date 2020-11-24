Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms

Partial Class pdeditPROV
    Inherits System.Web.UI.Page
    Dim Rst As String = ""
    Dim PDType As String = "Travel"
    Dim VofMoMsgBx As Integer = 0
    Dim GetUserdetails As careerDb = New careerDb()

    Private Sub pdeditPROV_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Username") = "" Then
            Response.Redirect("default.aspx")
        End If

        Try
            If Not Page.IsPostBack Then
                txt_pdid.Text = Request.QueryString("pdid")
                txt_SchoolID.Text = "" & Session.Item("school").ToString
                txtUser.Text = "" & Session.Item("Username").ToString
                txt_RtnForm.Text = Request.QueryString("RtnPath")
                'txt_RTpdid.Text = Request.QueryString("RTpdid")

                TxtUsrN.Text = "" & Session.Item("UserName").ToString
                TxtSchN.Text = "" & Session.Item("school").ToString
                TxtRolE.Text = "" & Session.Item("Role").ToString
                TxtPdYr.Text = "" & Session.Item("pdneedyr").ToString

                'ViewState("username") = "" & Session.Item("UserName").ToString
                'ViewState("schname") = "" & Session.Item("school").ToString
                'ViewState("role") = "" & Session.Item("Role").ToString
                'ViewState("pdneedyr") = "" & Session.Item("pdneedyr").ToString

                'load Category
                Dim Ds2 As DataSet = New DataSet()
                Dim Pmtr As String = "pdtype"
                Ds2 = GetUserdetails.Getpdcategory02(Pmtr, PDType, "")
                Dim dv2 As New DataView(Ds2.Tables("cat"))
                drp_Category.DataSource = dv2
                drp_Category.DataTextField = "category"
                drp_Category.DataValueField = "category"
                drp_Category.DataBind()
                Ds2.Dispose()
                dv2.Dispose()
                drp_Category.Items.Insert(0, "Select an Item")
                drp_Category.SelectedIndex = 0

                'Load Countries Names
                Dim Ds1 As DataSet = New DataSet
                Ds1 = GetUserdetails.GetpdmsCountries()
                Dim Dv1 As DataView = New DataView(Ds1.Tables("CountriesList"))
                drp_CountryNames.DataSource = Dv1
                drp_CountryNames.DataTextField = "country_name"
                drp_CountryNames.DataValueField = "country_name"
                drp_CountryNames.DataBind()
                drp_CountryNames.Items.Insert(0, "Open")
                drp_CountryNames.SelectedIndex = 0
                Dv1.Dispose()
                Ds1.Dispose()

                'Load Department Status
                Dim Ds4 As DataSet = New DataSet()
                Ds4 = GetUserdetails.GetDeptStatus(TxtRolE.Text.Trim)
                Dim dv4 As New DataView(Ds4.Tables("deptstatus"))
                ddl_DeptStus.DataSource = dv4
                ddl_DeptStus.DataTextField = "deptstatus"
                ddl_DeptStus.DataValueField = "deptstatus"
                ddl_DeptStus.Items.Insert(0, String.Empty)
                ddl_DeptStus.DataBind()

                'Dim Ds5 As DataSet = New DataSet()
                'Ds5 = GetUserdetails.GetSemesterData()
                'Dim dv5 As New DataView(Ds5.Tables("SemData"))
                'ddl_StartDate.DataSource = dv5
                'ddl_StartDate.DataTextField = "des"
                'ddl_StartDate.DataValueField = "des"
                'ddl_StartDate.Items.Insert(0, String.Empty)
                'ddl_StartDate.DataBind()

                ''Refresh Travel Balance amount
                ''Call GetUserdetails.GetBudgetData(txt_SchoolID.Text.ToString.Trim)
                'Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
                'Txt_TrvBal.Text = GetUserdetails.TrvTotAmt

                Dim Ds As DataSet = New DataSet()
                Ds = GetUserdetails.GetPDPlanTblDetails(txt_pdid.Text.Trim.ToString)
                Dim dv As New DataView(Ds.Tables("GetEmprec4PrvT"))

                Dim Tpdcat As String = "" & dv.Table.Rows(0)("pdcategory")

                If (Not IsDBNull(dv.Table.Rows(0)("pdcategory"))) Then
                    drp_Category.SelectedIndex = drp_Category.Items.IndexOf(drp_Category.Items.FindByValue(dv.Table.Rows(0)("pdcategory")))
                Else
                    drp_Category.SelectedIndex = -1
                End If

                'drp_Category.SelectedIndex = drp_Category.Items.IndexOf(drp_Category.Items.FindByValue(dv.Table.Rows(0)("pdcategory")))
                txt_pdneed.Text = "" & dv.Table.Rows(0)("pdneed")
                Txt_City.Text = "" & dv.Table.Rows(0)("city")
                Dim TcntyName As String = "" & dv.Table.Rows(0)("country")
                drp_CountryNames.SelectedIndex = drp_CountryNames.Items.IndexOf(drp_CountryNames.Items.FindByValue(TcntyName))
                'txt_SuggDate.Text = "" & Format(dv.Table.Rows(0)("pdsdate"), "dd-MMM-yyyy")
                'ddl_StartDate.SelectedIndex = ddl_StartDate.Items.IndexOf(ddl_StartDate.Items.FindByValue(dv.Table.Rows(0)("semester")))

                If (Not Convert.IsDBNull(dv.Table.Rows(0)("cstartdte"))) Then
                    If (dv.Table.Rows(0)("cstartdte").ToString() = "1/1/1900" Or dv.Table.Rows(0)("cstartdte").ToString() = "1/1/1900 12:00:00 AM") Then
                        TStartDte.Text = String.Empty
                    Else
                        TStartDte.Text = "" & Format(CDate(dv.Table.Rows(0)("cstartdte")), "dd/MM/yyyy")
                    End If
                Else
                    TStartDte.Text = String.Empty
                End If
                TxtSemester.Text = "" & dv.Table.Rows(0)("semester")

                txt_NoOfParti.Text = "" & dv.Table.Rows(0)("nofparticipants")
                txt_SFees.Text = "" & dv.Table.Rows(0)("fees")
                txt_STravelCost.Text = "" & dv.Table.Rows(0)("ticketcost")
                txt_Sperdiem.Text = "" & dv.Table.Rows(0)("perdiem")
                txt_TotCost.Text = "" & dv.Table.Rows(0)("totalcost")
                Txt_tblink.Text = "" & dv.Table.Rows(0)("tbllink")
                ddl_DeptStus.SelectedIndex = ddl_DeptStus.Items.IndexOf(ddl_DeptStus.Items.FindByValue(dv.Table.Rows(0)("deptstus")))
                'Dim TDeptStus As String = ddl_DeptStus.SelectedItem.Text.Trim
                Dim TDeptStus As String = "" & dv.Table.Rows(0)("deptstus")
                txt_DeptComns.Text = "" & dv.Table.Rows(0)("deptcomns")

                Txt_OldTotCost.Text = "" & dv.Table.Rows(0)("totalcost")
                'Txt_SchName.Text = "" & dv.Table.Rows(0)("schoolname")
                txt_SchoolID.Text = "" & dv.Table.Rows(0)("schoolname")
                Txt_ParaM.Text = "" & dv.Table.Rows(0)("reqtype")
                txt_OldnofPart.Text = "" & dv.Table.Rows(0)("nofparticipants")

                dv.Dispose()
                Ds.Dispose()
                'PDdate_Calender1.Visible = False

                'Load child records
                Call Load_MemberRec(Txt_tblink.Text.Trim.ToString)
                'ddl_DeptStus.SelectedItem.Text = "Allocated"

                If (TDeptStus.Trim = "Allocated") Then
                    Lock_Fields()
                    Lock_Fields4Allocated()
                ElseIf (TxtUsrN.Text.ToLower = "puefinance" Or TxtUsrN.Text.ToLower = "puehumanr") Then
                    Lock_Fields()
                    'Lock_Fields4Allocated()
                End If

                Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
                Txt_TrvBal.Text = GetUserdetails.TrvTotAmt

            End If

        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub Load_MemberRec(ByVal Tbl As String)
        Dim Ds3 As DataSet = New DataSet()
        Ds3 = GetUserdetails.GetChidsDetails(Tbl)
        Dim dV3 As New DataView(Ds3.Tables("ChildDetails01"))
        GV_Childs.DataSource = dV3
        GV_Childs.DataBind()
        dV3.Dispose()
        Ds3.Dispose()
    End Sub
    Protected Sub Btn_GetRec_Click(sender As Object, e As EventArgs) Handles Btn_GetRec.Click
        'Dim Tempno As String = ""
        'Dim GetPDDetails As careerDb = New careerDb()
        'Dim Ds As DataSet = New DataSet()
        'Ds = GetPDDetails.GetEmpInfo02(DDL_EmpInfo.SelectedItem.Value.ToString)
        'Dim dv As New DataView(Ds.Tables("GetEmprec"))
        'Tempno = "" & dv.Table.Rows(0)("empno")
        ''txt_firstName.Text = "" & dv.Table.Rows(0)("firstname")

        'Dim Dset As DataSet = New DataSet()
        'Dset = GetPDDetails.UpdEmpNo2PDPlanTbl(txt_pdid.Text.Trim.ToString, DDL_EmpInfo.SelectedItem.Value.Trim.ToString)
        'lblErrMsg.Text = "<p><b><font color='#006400'>Record updated.</font></b></p>"
    End Sub
    Protected Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
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

    Private Sub GV_Childs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GV_Childs.SelectedIndexChanged
        Try
            Dim tcdPDid As String = GV_Childs.SelectedRow.Cells(0).Text.ToString
            If tcdPDid.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>CD's PDID is empty.</font></b></p>" : Exit Sub
            Dim tEmpNo As String = GV_Childs.SelectedRow.Cells(1).Text.ToString
            If tEmpNo.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Emp. No. is empty.</font></b></p>" : Exit Sub
            Dim tcdToTcost As String = GV_Childs.SelectedRow.Cells(10).Text.ToString
            If tcdToTcost.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>CD's Total cost is empty.</font></b></p>" : Exit Sub
            Dim tcdToTcost02 As Integer = Decimal.Parse(tcdToTcost)

            ''If (System.Windows.Forms.MessageBox.Show("Do you want to delete employee of " & tEmpNo.ToString() & "?", "Confirmation Window.", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes) Then
            'VofMoMsgBx = TopMostMessageBox.Show("Do you want to delete employee of " & tEmpNo.ToString() & "?", "Confirmation Window!", MessageBoxButtons.YesNo)
            'If VofMoMsgBx = 6 Then

            Dim Ttotcost As Integer = 0
            Dim TnumofP As Integer = 0
            TnumofP = Integer.Parse(txt_NoOfParti.Text)
            Ttotcost = Decimal.Parse(txt_TotCost.Text)
            TnumofP = (TnumofP - 1)
            Ttotcost = (Ttotcost - tcdToTcost02)

            'Update Parent record
            Dim Ds01 As DataSet = New DataSet
            Ds01 = GetUserdetails.UpdandDeleteCDRec("update", txt_pdid.Text, TnumofP, Ttotcost)
            Ds01.Dispose()

            'Delete CD record
            Dim Ds02 As DataSet = New DataSet
            Ds02 = GetUserdetails.UpdandDeleteCDRec("delete", tcdPDid, "0", "0")
            Ds01.Dispose()

            Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_TrvBal.Text = GetUserdetails.TrvTotAmt

            txt_NoOfParti.Text = TnumofP
            txt_TotCost.Text = Ttotcost

            Call Load_MemberRec(Txt_tblink.Text.Trim.ToString)
            UpdatePanel13.Update()

            'Refresh Page or Re-Load Page
            'Response.Redirect(Request.RawUrl.ToString()) 'redirect on itself
            'Response.Write(Request.RawUrl.ToString())
            lblErrMsg.Text = "<p><b><font color='#006400'>Record (CD) Deleted.</font></b></p>"

            'End If
        Catch ex As Exception
            lblErrMsg.Text = "<p><b><font color='#FF0000'>" & Err.Number & " : " & Err.Description & "</font></b></p>"
        End Try

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''GV_PDplan.DataKeys(GV_PDplan.SelectedRow.RowIndex).Value.ToString()
        'Dim TkeyValue As String = GV_Childs.DataKeys(GV_Childs.SelectedRow.RowIndex).Value.ToString
        'If TkeyValue.Trim.ToString() = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>No key data.</font></b></p>" : Exit Sub
        'TkeyValue = TkeyValue & "&RtnPath=pdeditPROVtrv.aspx&RTpdid=" & txt_pdid.Text.Trim.ToString
        ''TkeyValue = TkeyValue & "&RtnPath=pdeditPROVtrv.aspx"
        'Response.Redirect("pdedit4ChildRec.aspx?pdid=" & TkeyValue)
        ''Response.Redirect("pdedit4ChildRec.aspx?pdid=" & TkeyValue)
    End Sub

    Protected Sub txt_SFees_TextChanged(sender As Object, e As EventArgs) Handles txt_SFees.TextChanged
        Txt_FldChanges.Text = "Yes"
        If (txt_SFees.Text.Trim <> "") Then
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_TotCost.Text = (Decimal.Parse(txt_TotCost.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            txt_STravelCost.Focus()
        End If
    End Sub
    Protected Sub txt_STravelCost_TextChanged(sender As Object, e As EventArgs) Handles txt_STravelCost.TextChanged
        Txt_FldChanges.Text = "Yes"
        If (txt_STravelCost.Text.Trim <> "") Then
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_TotCost.Text = (Decimal.Parse(txt_TotCost.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            txt_Sperdiem.Focus()
        End If
    End Sub
    Protected Sub txt_Sperdiem_TextChanged(sender As Object, e As EventArgs) Handles txt_Sperdiem.TextChanged
        Txt_FldChanges.Text = "Yes"
        If (txt_Sperdiem.Text.Trim <> "") Then
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            txt_TotCost.Text = (Decimal.Parse(txt_TotCost.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            txt_TotCost.Focus()
        End If
    End Sub
    Protected Sub but_submit_Click(sender As Object, e As EventArgs) Handles but_submit.Click
        'If (Txt_TrvBal.Text.ToString.Trim = "" Or Txt_TrvBal.Text.ToString() = 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Can't accept your request. Please check the balance.</font></b></p>" : Exit Sub
        If txt_pdneed.Text.Trim.ToString = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>PD Need (or PD Title) column can not be empty...........</font></b></p>" : Exit Sub
        If Txt_City.Text.Trim.ToString = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>City column can not be empty...........</font></b></p>" : Exit Sub
        If drp_CountryNames.SelectedIndex = 0 Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select country name...........</font></b></p>" : Exit Sub
        'If (txt_NoOfParti.Text.Trim.ToString = 0 Or txt_NoOfParti.Text.Trim.ToString = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Number of participants field can't be empty...........</font></b></p>" : Exit Sub
        'If txt_SuggDate.Text.Trim.ToString = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select Date...........</font></b></p>" : Exit Sub
        'If TStartDte.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date.</font></b></p>" : Exit Sub
        'If CcodeDDList.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose PDCode...........</font></b></p>" : Exit Sub

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

        'If txt_SuggDate.Text.Trim.ToString = "" Then txt_SuggDate.Text = System.Data.SqlTypes.SqlDateTime.MinValue.Value
        'If txt_SuggDate.Text.Trim.ToString = "" Then txt_SuggDate.Text = "1/1/1753"
        If txt_SFees.Text.Trim.ToString = "" Then txt_SFees.Text = 0
        If txt_STravelCost.Text.Trim.ToString = "" Then txt_STravelCost.Text = 0
        If txt_Sperdiem.Text.Trim.ToString = "" Then txt_Sperdiem.Text = 0
        If txt_TotCost.Text.Trim.ToString = "" Then txt_TotCost.Text = 0

        Dim Ds As DataSet = New DataSet
        Dim Rst As Boolean = True
        Dim A As Integer = 0
        Dim TotNofRow As Integer = 0
        Dim Tot4Individual As Decimal = 0
        Tot4Individual = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))

        Rst = updatepdinfo.UpdatePDprovisionTrv(txt_pdid.Text.Trim.ToString(), drp_Category.SelectedItem.Text, txt_pdneed.Text.Trim.ToString(), Txt_City.Text.Trim.ToString(), drp_CountryNames.SelectedItem.Text, TxtSemester.Text.Trim, txt_NoOfParti.Text.Trim.ToString(), txt_SFees.Text.Trim.ToString(), txt_STravelCost.Text.Trim.ToString(), txt_Sperdiem.Text.Trim.ToString(), txt_TotCost.Text.Trim.ToString(), txtUser.Text.Trim.ToString(), ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.Trim.ToString(), CourseStartDate)

        'Update member records
        Dim RecStus1 As Boolean = False
        Dim NuOfPartici As Integer = 1
        Dim I As Integer = 0
        TotNofRow = GV_Childs.Rows.Count
        Dim PdID(TotNofRow) As String

        For I = 0 To (TotNofRow - 1)
            PdID(I) = GV_Childs.Rows(I).Cells(0).Text.ToString()
        Next
        For I = 0 To (TotNofRow - 1)
            RecStus1 = updatepdinfo.UpdatePDprovisionTrv(PdID(I), drp_Category.SelectedItem.Text, txt_pdneed.Text.Trim.ToString(), Txt_City.Text.Trim.ToString(), drp_CountryNames.SelectedItem.Text, TxtSemester.Text.Trim, NuOfPartici, txt_SFees.Text.Trim.ToString(), txt_STravelCost.Text.Trim.ToString(), txt_Sperdiem.Text.Trim.ToString(), Tot4Individual, txtUser.Text.Trim.ToString(), ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.Trim.ToString(), CourseStartDate)
            If RecStus1 = False Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Member(s) record not updated. Please check.</font></b></p>" : Exit Sub
        Next
        Call Load_MemberRec(Txt_tblink.Text.Trim.ToString)

        Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
        Txt_TrvBal.Text = updatepdinfo.TrvTotAmt
        Txt_FldChanges.Text = "No"

        lblErrMsg.Text = "<p><b><font color='#006400'>Record Saved.</font></b></p>"

        If (ddl_DeptStus.SelectedItem.Text = "Allocated") Then
            Lock_Fields()
            Lock_Fields4Allocated()
        ElseIf (TxtUsrN.Text.ToLower = "puefinance" Or TxtUsrN.Text.ToLower = "puehumanr") Then
            Lock_Fields()
            'Lock_Fields4Allocated()
        End If

    End Sub
    Public Sub Lock_Fields()
        'ddl_DeptStus.Enabled = False
        drp_Category.Enabled = False
        txt_pdneed.Enabled = False
        Txt_City.Enabled = False
        drp_CountryNames.Enabled = False
        TStartDte.Enabled = False
        BtnStartDte.Enabled = False
        TxtSemester.Enabled = False
        txt_NoOfParti.Enabled = False
        'txt_DeptComns.Enabled = False
        txt_SFees.Enabled = False
        txt_STravelCost.Enabled = False
        txt_Sperdiem.Enabled = False
        txt_TotCost.Enabled = False
        txt_SEmail.Enabled = False
        txt_SEmpNo.Enabled = False
        btn_Getrecord.Enabled = False
        btnSclear.Enabled = False
        Btn_GetRec.Enabled = False
        txt_firstName.Enabled = False
        txt_LastName.Enabled = False
        txt_Position.Enabled = False
        txt_Dept.Enabled = False
        txt_Center.Enabled = False
        Btn_AddCDRec.Enabled = False
        GV_Childs.Enabled = False
    End Sub
    Public Sub Lock_Fields4Allocated()
        ddl_DeptStus.Enabled = False
        txt_DeptComns.Enabled = False
        'but_submit.Enabled = False
    End Sub

    Private Sub pdeditPROV_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("UserName") = TxtUsrN.Text.Trim.ToString()
        Session("school") = TxtSchN.Text.Trim.ToString()
        Session("Role") = TxtRolE.Text.Trim.ToString()
        Session("pdneedyr") = TxtPdYr.Text.Trim.ToString()

        'Session("UserName") = ViewState("username").ToString()
        'Session("school") = ViewState("schname").ToString()
        'Session("Role") = ViewState("role").ToString()
        'Session("pdneedyr") = ViewState("pdneedyr").ToString()

        ''Dim MboxRst As Integer = 0
        ''MboxRst = MessageBox.Show("Do you want to save data?", "Confirmation Window", "Caption", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, DialogResult.Yes)
        'If Txt_FldChanges.Text = "Yes" Then
        '    If (System.Windows.Forms.MessageBox.Show("Do you want to save data?", "Confirmation Window.", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes) Then
        '        but_submit_Click(sender, e)
        '    End If
        'End If

        'If Txt_FldChanges.Text = "Yes" Then
        '    VofMoMsgBx = TopMostMessageBox.Show("Do you want to save data?", "Confirmation Window!", MessageBoxButtons.YesNo)
        '    If VofMoMsgBx = 6 Then
        '        but_submit_Click(sender, e)
        '        Txt_FldChanges.Text = "No"
        '    End If
        'End If

    End Sub

    Protected Sub btn_Getrecord_Click(sender As Object, e As EventArgs) Handles btn_Getrecord.Click
        If (txt_SEmail.Text.ToString.Trim = "" And txt_SEmpNo.Text.ToString.Trim = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's email and number can't be Empty...........</font></b></p>" : Exit Sub
        Call getempdetails()
    End Sub
    Private Sub getempdetails()
        Try
            lblErrMsg.Text = ""
            Dim GetUserdetails As careerDb = New careerDb()
            Dim Ds As DataSet = New DataSet()
            Ds = GetUserdetails.getempdetails(txt_SchoolID.Text.ToString.Trim(), txt_SEmpNo.Text.ToString.Trim(), txt_SEmail.Text.ToString.Trim())
            Dim dv As New DataView(Ds.Tables("empdetails"))
            If dv.Table.Rows.Count > 0 Then
                'txt_empno.Text = "" & dv.Table.Rows(0)("empno")
                txt_Position.Text = "" & dv.Table.Rows(0)("position")
                txt_firstName.Text = "" & dv.Table.Rows(0)("firstname")
                txt_LastName.Text = "" & dv.Table.Rows(0)("lastname")
                txt_Dept.Text = "" & dv.Table.Rows(0)("department")
                txt_Center.Text = "" & dv.Table.Rows(0)("centername")
                txt_SEmpNo.Text = "" & dv.Table.Rows(0)("empno")
                txt_SEmail.Text = "" & dv.Table.Rows(0)("email")
                lblErrMsg.Text = ""
            Else
                'txt_empno.Text = ""
                txt_Position.Text = ""
                txt_firstName.Text = ""
                txt_LastName.Text = ""
                txt_Dept.Text = ""
                txt_Center.Text = ""
            End If
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnSclear_Click(sender As Object, e As EventArgs) Handles btnSclear.Click
        Try
            lblErrMsg.Text = ""
            txt_firstName.Text = ""
            txt_LastName.Text = ""
            txt_Position.Text = ""
            txt_Center.Text = ""
            txt_Dept.Text = ""
            txt_SEmpNo.Text = ""
            txt_SEmail.Text = ""
            txt_SEmail.Focus()
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub Btn_AddCDRec_Click(sender As Object, e As EventArgs) Handles Btn_AddCDRec.Click
        If (Txt_TrvBal.Text.ToString.Trim = "" Or Txt_TrvBal.Text.ToString() = 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Can't accept your request. Please check the balance.</font></b></p>" : Exit Sub
        If drp_Category.SelectedItem.Text.Trim = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select a Category...........</font></b></p>" : Exit Sub
        If txt_pdneed.Text.Trim.ToString = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>PD Title column can not be empty...........</font></b></p>" : Exit Sub
        If Txt_City.Text.Trim.ToString = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>City column can not be empty...........</font></b></p>" : Exit Sub
        If drp_CountryNames.SelectedIndex = 0 Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select country name...........</font></b></p>" : Exit Sub
        If txt_SEmpNo.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Choose Employee number.</font></b></p>" : Exit Sub
        If txt_SEmail.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Choose Employee email address.</font></b></p>" : Exit Sub
        If txt_firstName.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's First Name Field Empty.</font></b></p>" : Exit Sub
        If txt_LastName.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's Last Name Field Empty.</font></b></p>" : Exit Sub
        If Txt_EmpNo_PrevRec.Text.Trim = txt_SEmpNo.Text.Trim Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Duplicate entry.</font></b></p>" : Exit Sub
        If Txt_FldChanges.Text = "Yes" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Update the changes before add any record(s).</font></b></p>" : Exit Sub

        If txt_SFees.Text.Trim.ToString = "" Then txt_SFees.Text = 0
        If txt_STravelCost.Text.Trim.ToString = "" Then txt_STravelCost.Text = 0
        If txt_Sperdiem.Text.Trim.ToString = "" Then txt_Sperdiem.Text = 0
        If txt_TotCost.Text.Trim.ToString = "" Then txt_TotCost.Text = 0

        If txt_SFees.Text.Trim.ToString = "0" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Please check the fees.</font></b></p>" : Exit Sub
        If txt_STravelCost.Text.Trim.ToString = "0" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Please check the travel cost.</font></b></p>" : Exit Sub
        If txt_Sperdiem.Text.Trim.ToString = "0" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Please check the perdiem.</font></b></p>" : Exit Sub
        'If txt_TotCost.Text.Trim.ToString = "0" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's Last Name Field Empty.</font></b></p>" : Exit Sub

        Try
            Dim Userdetails As careerDb = New careerDb()
            Dim CourseStartDate As Date = "1/1/1900"
            If TStartDte.Text.Trim.ToString = "" Then
                CourseStartDate = "1/1/1900"
                TxtSemester.Text = ""
            Else
                If (Not GetUserdetails.DateChk(TStartDte.Text.Trim)) Then
                    lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date (DD/MM/YYYY).</font></b></p>"
                    Exit Sub
                End If
                CourseStartDate = Format(CDate(TStartDte.Text.Trim), "dd/MM/yyyy")
            End If

            Dim Tot4Individual As Decimal = 0
            Dim TempNoPart As Integer = 1
            Dim ReqType02 As String = "CD"
            Dim Ttotcost As Integer = 0
            Dim TnumofP As Integer = 0
            Dim TtrvBal As Decimal = 0.0

            Call Userdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_TrvBal.Text = Userdetails.TrvTotAmt

            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) + Decimal.Parse(txt_STravelCost.Text) + Decimal.Parse(txt_Sperdiem.Text))
            Tot4Individual = Decimal.Parse(txt_TotCost.Text)
            'txt_TotCost.Text = (Decimal.Parse(txt_TotCost.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            TnumofP = Integer.Parse(txt_NoOfParti.Text)
            TnumofP = (TnumofP + 1)
            txt_NoOfParti.Text = TnumofP.ToString()
            Ttotcost = Decimal.Parse(txt_TotCost.Text)
            Ttotcost = (Ttotcost * TnumofP)
            txt_TotCost.Text = Ttotcost.ToString()
            TtrvBal = Decimal.Parse(Txt_TrvBal.Text.Trim)
            'If (Decimal.Parse(txt_TotCost.Text) > Decimal.Parse(Txt_TrvBal.Text.Trim)) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to insufficient balance can't accept your request. Please check the balance amount.</font></b></p>" : Exit Sub
            If (Tot4Individual > TtrvBal) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to insufficient balance can't accept your request. Please check the balance amount.</font></b></p>" : Exit Sub

            Rst = Userdetails.InsertPDProvisionTravel(txt_SEmpNo.Text.Trim(), drp_Category.SelectedItem.Value.ToString.Trim(), txt_pdneed.Text.ToString.Trim(), Txt_City.Text.ToString.Trim(), drp_CountryNames.SelectedItem.Value.ToString.Trim(), TxtSemester.Text.Trim.Trim.ToString, TempNoPart, txt_SFees.Text.ToString.Trim(), txt_STravelCost.Text.ToString.Trim(), txt_Sperdiem.Text.ToString.Trim(), Tot4Individual, Txt_tblink.Text.Trim.ToString, ReqType02, txtUser.Text.ToString.Trim(), txt_SchoolID.Text.Trim.ToString(), TxtPdYr.Text.Trim(), PDType, CourseStartDate)
            If (Rst = True) Then
                lblErrMsg.Text = "<p><b><font color='#006400'>Record (CD) Added.</font></b></p>"
            Else
                lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to an error, record (cd) not added. Please check.</font></b></p>"
            End If

            ''update Total no of participants and Total cost
            'TnumofP = Integer.Parse(txt_NoOfParti.Text)
            'TnumofP = (TnumofP + 1)
            'txt_NoOfParti.Text = TnumofP.ToString()
            'Ttotcost = Decimal.Parse(txt_TotCost.Text)
            'Ttotcost = (Ttotcost * TnumofP)
            'txt_TotCost.Text = Ttotcost.ToString()
            ''txt_TotCost.Text = (Decimal.Parse(txt_TotCost.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            ''Ttotcost = Decimal.Parse(txt_TotCost.Text)

            Dim Ds01 As DataSet = New DataSet
            Ds01 = Userdetails.UpdandDeleteCDRec("update", txt_pdid.Text, TnumofP, Ttotcost)

            'Load CD records
            Call Load_MemberRec(Txt_tblink.Text.Trim.ToString)
            UpdatePanel13.Update()

            Call Userdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_TrvBal.Text = Userdetails.TrvTotAmt

            'Refresh Page or Re-Load Page
            'Response.Redirect(Request.RawUrl.ToString()) 'redirect on itself
            'Response.Write(Request.RawUrl.ToString())
            lblErrMsg.Text = "<p><b><font color='#006400'>Record Added.</font></b></p>"
            Txt_EmpNo_PrevRec.Text = txt_SEmpNo.Text

        Catch ex As Exception
            lblErrMsg.Text = "<p><b><font color='#FF0000'>" & Err.Number & " : " & Err.Description & "</font></b></p>"
        End Try
    End Sub

    Private Sub GV_Childs_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_Childs.RowDeleting
        Call Load_MemberRec(Txt_tblink.Text.Trim.ToString)
    End Sub
    Protected Sub ddl_DeptStus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_DeptStus.SelectedIndexChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub drp_Category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_Category.SelectedIndexChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub txt_pdneed_TextChanged(sender As Object, e As EventArgs) Handles txt_pdneed.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub Txt_City_TextChanged(sender As Object, e As EventArgs) Handles Txt_City.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub drp_CountryNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_CountryNames.SelectedIndexChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub txt_NoOfParti_TextChanged(sender As Object, e As EventArgs) Handles txt_NoOfParti.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub txt_DeptComns_TextChanged(sender As Object, e As EventArgs) Handles txt_DeptComns.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub Btn_MoMsgBx_Click(sender As Object, e As EventArgs) Handles Btn_MoMsgBx.Click
        'TopMostMessageBox.Show("This will appear in a message box that is a topmost window","Title", MessageBoxButtons.AbortRetryIgnore)
        'Dim VofMoMsgBx As Integer = 0
        'VofMoMsgBx = TopMostMessageBox.Show("I'm Top Most Window!.", "Information", MessageBoxButtons.YesNo)
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