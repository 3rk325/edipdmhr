Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms

Partial Class pdeditPROVloc
    Inherits System.Web.UI.Page
    Dim TsuCat As String = ""
    Dim PDType As String = "Local"
    Dim Rst As Boolean = False
    Dim VofMoMsgBx As Integer = 0
    Dim GetUserdetails As careerDb = New careerDb()

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
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
                    Response.Redirect("pdplanviewEUS.aspx?Fname=pdplan")
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
            Dim tcdToTcost As String = GV_Childs.SelectedRow.Cells(9).Text.ToString
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
            Txt_LocBal.Text = GetUserdetails.LocTotAmt

            txt_NoOfParti.Text = TnumofP
            txt_TotCost.Text = Ttotcost

            'Load CD records
            Call Load_MembersRec(Txt_tblink.Text.Trim.ToString)
            UpdatePanel14.Update()

            'Refresh Page or Re-Load Page
            'Response.Redirect(Request.RawUrl.ToString()) 'redirect on itself
            'Response.Write(Request.RawUrl.ToString())
            lblErrMsg.Text = "<p><b><font color='#006400'>Record (CD) Deleted.</font></b></p>"
            'End If
        Catch ex As Exception
            lblErrMsg.Text = "<p><b><font color='#FF0000'>" & Err.Number & " : " & Err.Description & "</font></b></p>"
        End Try

        ''GV_PDplan.DataKeys(GV_PDplan.SelectedRow.RowIndex).Value.ToString()
        'Dim TkeyValue As String = GV_Childs.DataKeys(GV_Childs.SelectedRow.RowIndex).Value.ToString
        'If TkeyValue.Trim.ToString() = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>No key data.</font></b></p>" : Exit Sub
        'TkeyValue = TkeyValue & "&RtnPath=pdeditPROVloc.aspx&RTpdid=" & txt_pdid.Text.Trim.ToString
        ''TkeyValue = TkeyValue & "&RtnPath=pdeditPROVtrv.aspx"
        'Response.Redirect("pdedit4ChildRec.aspx?pdid=" & TkeyValue)
        ''Response.Redirect("pdedit4ChildRec.aspx?pdid=" & TkeyValue)
    End Sub

    Private Sub pdeditPROVloc_Load(sender As Object, e As EventArgs) Handles Me.Load
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

                'Load Department Status
                Dim Ds4 As DataSet = New DataSet()
                Ds4 = GetUserdetails.GetDeptStatus(TxtRolE.Text.Trim)
                Dim dv4 As New DataView(Ds4.Tables("deptstatus"))
                ddl_DeptStus.DataSource = dv4
                ddl_DeptStus.DataTextField = "deptstatus"
                ddl_DeptStus.DataValueField = "deptstatus"
                'ddl_DeptStus.Items.Insert(0, String.Empty)
                ddl_DeptStus.SelectedIndex = 1
                'ddl_DeptStus.Items.FindByText("Budgted").Selected = True
                ddl_DeptStus.DataBind()

                ' load Category
                Dim Ds1 As DataSet = New DataSet()
                Dim Pmtr As String = "pdtype"
                Ds1 = GetUserdetails.Getpdcategory02(Pmtr, PDType, "")
                Dim dv1 As New DataView(Ds1.Tables("cat"))
                drp_Category.DataSource = dv1
                drp_Category.DataTextField = "category"
                drp_Category.DataValueField = "category"
                drp_Category.DataBind()
                Ds1.Dispose()
                dv1.Dispose()
                drp_Category.Items.Insert(0, "Select an Item")
                drp_Category.SelectedIndex = 0

                'Load data to the form
                Dim Ds0 As DataSet = New DataSet()
                Ds0 = GetUserdetails.GetPDPlanTblDetails(txt_pdid.Text.Trim.ToString)
                Dim dv0 As New DataView(Ds0.Tables("GetEmprec4PrvT"))
                drp_Category.SelectedIndex = drp_Category.Items.IndexOf(drp_Category.Items.FindByValue(dv0.Table.Rows(0)("pdcategory")))
                LoadData_SubCategory(drp_Category.SelectedItem.Text)
                ddl_SubCat.SelectedIndex = ddl_SubCat.Items.IndexOf(ddl_SubCat.Items.FindByValue(dv0.Table.Rows(0)("subcategory")))

                Dim TsuCat As String = ""
                TsuCat = ddl_SubCat.SelectedItem.Text.Trim()
                If (TsuCat = "QF-IB Event" Or TsuCat = "Cluster") Then
                    TsuCat = "Travel: IB-Workshop"
                End If

                'LoadData_CourseCode(ddl_SubCat.SelectedItem.Text)
                LoadData_CourseCode(TsuCat)
                CcodeDDList.SelectedIndex = CcodeDDList.Items.IndexOf(CcodeDDList.Items.FindByValue(dv0.Table.Rows(0)("pdcoursecode")))
                Load_CourseCode_Description(CcodeDDList.SelectedItem.Text)
                Txt_FInfo.Text = dv0.Table.Rows(0)("furtherinfo")
                'ddl_StartDate.SelectedIndex = ddl_StartDate.Items.IndexOf(ddl_StartDate.Items.FindByValue(dv0.Table.Rows(0)("semester")))

                ' Load Course Start Date
                Dim Ds5 As DataSet = New DataSet()
                Ds5 = GetUserdetails.GetCourseStartDate(CcodeDDList.SelectedValue.ToString)
                Dim dv5 As New DataView(Ds5.Tables("CourseStartDte"))
                dv5.Sort = "csdate ASC"
                ddl_CStartDte.DataSource = dv5
                ddl_CStartDte.DataTextField = "csdate"
                ddl_CStartDte.DataValueField = "csdate"
                ddl_CStartDte.DataBind()
                Ds5.Dispose()
                dv5.Dispose()

                Dim CsDate01 As String = "" & dv0.Table.Rows(0)("cstartdte")
                If (Not Convert.IsDBNull(CsDate01)) Then
                    If (CsDate01 = "1/1/1900" Or CsDate01 = "1/1/1900 12:00:00 AM" Or CsDate01 = "") Then
                        ddl_CStartDte.Items.Clear()
                    Else
                        Dim CsDate02 As Date = Convert.ToDateTime(CsDate01)
                        Dim CsDate03 As String = CsDate02.ToString("dd MMM yyyy")
                        ddl_CStartDte.SelectedIndex = ddl_CStartDte.Items.IndexOf(ddl_CStartDte.Items.FindByValue(CsDate03))
                    End If
                Else
                    ddl_CStartDte.Items.Clear()
                End If

                TxtSemester.Text = "" & dv0.Table.Rows(0)("semester")

                txt_NoOfParti.Text = "" & dv0.Table.Rows(0)("nofparticipants")
                txt_OldnofPart.Text = "" & dv0.Table.Rows(0)("nofparticipants")
                txt_SFees.Text = "" & dv0.Table.Rows(0)("fees")
                txt_TotCost.Text = "" & dv0.Table.Rows(0)("totalcost")
                Txt_OldTotCost.Text = "" & dv0.Table.Rows(0)("totalcost")
                Txt_tblink.Text = "" & dv0.Table.Rows(0)("tbllink")
                ddl_DeptStus.SelectedIndex = ddl_DeptStus.Items.IndexOf(ddl_DeptStus.Items.FindByValue(dv0.Table.Rows(0)("deptstus")))
                txt_OldDeptStus.Text = "" & dv0.Table.Rows(0)("deptstus")
                txt_DeptComns.Text = "" & dv0.Table.Rows(0)("deptcomns")
                Txt_ParaM.Text = "" & dv0.Table.Rows(0)("reqtype")
                'Txt_SchName.Text = "" & dv0.Table.Rows(0)("schoolname")
                txt_SchoolID.Text = "" & dv0.Table.Rows(0)("schoolname")
                dv0.Dispose()
                Ds0.Dispose()

                'Load child records
                Call Load_MembersRec(Txt_tblink.Text.Trim.ToString)

                If (txt_OldDeptStus.Text.Trim.ToString = "Allocated") Then
                    Lock_Fields4Approval()
                    Lock_Fields4Attended()
                End If

                'And TxtRolE.Text.Trim <> "Admin"
                'If (txt_OldDeptStus.Text.Trim.ToString = "Allocated") Then
                '    Lock_Fields4Approval()
                '    Lock_Fields4Attended()
                'End If

                If (txt_OldDeptStus.Text.Trim = "Allocated" Or ddl_DeptStus.SelectedItem.Text = "Allocated") Then
                    'Lock_Fields()
                    'Lock_Fields4Allocated()
                ElseIf (TxtUsrN.Text.ToLower = "puefinance" Or TxtUsrN.Text.ToLower = "puehumanr") Then
                    Lock_Fields()
                    'Lock_Fields4Allocated()
                End If

                'Capture course fee value for DeptStus manipulations
                If (txt_SFees.Text.Trim <> "" And txt_SFees.Text.Trim <> "0") Then
                    ViewState("OldFee") = txt_SFees.Text.Trim
                End If

                'If (txt_TotCost.Text.Trim <> "" And txt_TotCost.Text.Trim <> "0") Then
                '    ViewState("OldTotcost") = txt_TotCost.Text.Trim
                'End If

            End If
            Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_LocBal.Text = GetUserdetails.LocTotAmt
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub LoadData_SubCategory(ByVal cATeGorY As String)
        ' load Category
        Dim getUserDetails As careerDb = New careerDb
        Dim Ds1 As DataSet = New DataSet()
        Dim Pmtr As String = "Search"
        Ds1 = getUserDetails.Getpdcategory02(Pmtr, "", cATeGorY)
        Dim dv1 As New DataView(Ds1.Tables("cat"))
        ddl_SubCat.DataSource = dv1
        ddl_SubCat.DataTextField = "subcategory"
        ddl_SubCat.DataValueField = "subcategory"
        ddl_SubCat.DataBind()
        Ds1.Dispose()
        dv1.Dispose()
    End Sub

    Protected Sub LoadData_CourseCode(ByVal SubCateGory As String)
        Dim GetUserdetails1 As careerDb = New careerDb()
        Dim Ds2 As DataSet = New DataSet()
        Dim Pmtr As String = "Search"
        Ds2 = GetUserdetails1.GetCoursecategory(Pmtr, SubCateGory)
        'Ds2 = GetUserdetails1.GetCoursecategory(Pmtr, ddl_SubCat.SelectedItem.Text)
        Dim dv As New DataView(Ds2.Tables("cCode"))
        CcodeDDList.DataSource = dv
        CcodeDDList.DataTextField = "CourseDetails"
        CcodeDDList.DataValueField = "CourseCode"
        CcodeDDList.DataBind()
        CcodeDDList.Items.Insert(0, String.Empty)
        Ds2.Dispose()
        dv.Dispose()
    End Sub

    Protected Sub Load_CourseCode_Description(ByVal CourseCode As String)
        Dim TotItems As Integer = 0
        Dim GetCourseDetails As careerDb = New careerDb()
        Dim Dset As New DataSet
        Dset = GetCourseDetails.GetCcodeDescription(CcodeDDList.SelectedValue.ToString)
        Dim DaView As New DataView(Dset.Tables("CcDescription"))
        Dim drv As DataRowView
        TotItems = DaView.Table.Rows.Count
        For Each drv In DaView
            txt_pdDes.Text = IIf(drv("Description") = String.Empty, "", drv("Description"))
            txt_SFees.Text = drv("Fees")
            txt_TotCost.Text = txt_SFees.Text
        Next
        DaView.Dispose()
        Dset.Clear()
    End Sub
    Protected Sub Load_MembersRec(ByVal Tbl As String)
        Dim GetUsrdetails As careerDb = New careerDb
        Dim Ds6 As DataSet = New DataSet()
        Ds6 = GetUsrdetails.GetChidsDetails(Tbl)
        Dim dV6 As New DataView(Ds6.Tables("ChildDetails01"))
        GV_Childs.DataSource = dV6
        GV_Childs.DataBind()
        dV6.Dispose()
        Ds6.Dispose()
    End Sub
    Protected Sub CcodeDDList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CcodeDDList.SelectedIndexChanged
        Txt_FldChanges.Text = "Yes"
        'Dim TsuCat As String = ""
        Dim TotItems As Integer = 0
        Dim GetCourseDetails As careerDb = New careerDb()
        Dim Dset As New DataSet
        Dset = GetCourseDetails.GetCcodeDescription(CcodeDDList.SelectedValue.ToString)
        Dim DaView As New DataView(Dset.Tables("CcDescription"))
        Dim drv As DataRowView
        TotItems = DaView.Table.Rows.Count
        TsuCat = ddl_SubCat.SelectedItem.Text.Trim
        For Each drv In DaView
            txt_pdDes.Text = IIf(drv("Description") = String.Empty, "", drv("Description"))
            If (TsuCat = "QF-IB Event") Then
                txt_SFees.Text = "3968"
            ElseIf (TsuCat = "Cluster") Then
                txt_SFees.Text = "2500"
            Else
                txt_SFees.Text = drv("Fees")
            End If

            'txt_SFees.Text = drv("Fees")
            'txt_TotCost.Text = txt_SFees.Text
        Next
        DaView.Dispose()
        Dset.Clear()

        ''''''''Start : Code inserted on 14th Nov 2017''''''''''
        'If (TsuCat = "QF-IB Event") Then
        '    txt_SFees.Text = "3968"
        'ElseIf TsuCat = "Cluster" Then
        '    txt_SFees.Text = "2500"
        'End If
        ''''''''End''''''''''

        If (txt_SFees.Text.Trim.ToString = "0") Then
            txt_TotCost.Text = txt_SFees.Text
        Else
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) * Convert.ToInt32(txt_NoOfParti.Text))
        End If

        ' Load Course Start Date
        Dim Ds1 As DataSet = New DataSet()
        Ds1 = GetCourseDetails.GetCourseStartDate(CcodeDDList.SelectedValue.ToString)
        Dim dv1 As New DataView(Ds1.Tables("CourseStartDte"))
        dv1.Sort = "csdate ASC"
        ddl_CStartDte.DataSource = dv1
        ddl_CStartDte.DataTextField = "csdate"
        ddl_CStartDte.DataValueField = "csdate"
        ddl_CStartDte.DataBind()
        Ds1.Dispose()
        dv1.Dispose()

        Dim SemNumber As String = ""
        If ddl_CStartDte.SelectedValue.ToString() = "" Then
            TxtSemester.Text = ""
        Else
            SemNumber = GetCourseDetails.GetSemesterNo(ddl_CStartDte.SelectedValue.ToString())
            TxtSemester.Text = SemNumber
        End If

    End Sub

    Protected Sub txt_SFees_TextChanged(sender As Object, e As EventArgs) Handles txt_SFees.TextChanged
        If (txt_SFees.Text.Trim <> "") Then
            txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) * Convert.ToInt32(txt_NoOfParti.Text))
            Txt_FldChanges.Text = "Yes"
        End If
    End Sub
    Protected Sub but_submit_Click(sender As Object, e As EventArgs) Handles but_submit.Click
        If (Txt_LocBal.Text.ToString.Trim = "" Or Txt_LocBal.Text.ToString() = 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Can't accept your request. Please check the balance.</font></b></p>" : Exit Sub
        If drp_Category.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose Category...........</font></b></p>" : Exit Sub

        'If ddl_CStartDte.SelectedValue.ToString() = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date.</font></b></p>" : Exit Sub
        'If CcodeDDList.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose PDCode...........</font></b></p>" : Exit Sub
        'If txt_SuggDate.Text.Trim.ToString() = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select Date...........</font></b></p>" : Exit Sub
        'If (txt_NoOfParti.Text.Trim.ToString = 0 Or txt_NoOfParti.Text.Trim.ToString = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Number of participants field can't be empty...........</font></b></p>" : Exit Sub
        'If ((ddl_DeptStus.SelectedItem.Text = "Approved") Or (ddl_DeptStus.SelectedItem.Text = "Attended")) Then Lock_Fields() : Exit Sub
        'If TStartDte.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date.</font></b></p>" : Exit Sub
        'If CcodeDDList.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose PDCode...........</font></b></p>" : Exit Sub

        Try
            Dim updatepdinfo As careerDb = New careerDb()
            ' Validation - Start
            Dim RgLastDate As Date = "1/1/1900"
            Dim TcStartD As Date = "1/1/1900"
            If (ddl_CStartDte.SelectedValue.ToString().Trim <> "") Then
                TcStartD = ddl_CStartDte.SelectedValue.ToString()
            Else
                TcStartD = "1/1/1900"
            End If

            RgLastDate = updatepdinfo.GetDeadLine("DLDate", CcodeDDList.SelectedValue.ToString(), TcStartD)
            Dim Ndays As Integer = 0
            Ndays = DateDiff(DateInterval.Day, Now.Date, RgLastDate)
            If (Ndays < 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Registration Closed.</font></b></p>" : Exit Sub

            Dim TotCap As Integer = 0
            TotCap = updatepdinfo.GetTotalCapacity("TPax", CcodeDDList.SelectedValue.ToString(), "1/1/1900")

            'Dim TotRdUser As Integer = 0
            'TotRdUser = updatepdinfo.GetRegdTotParti("NuOfPax", CcodeDDList.SelectedValue.ToString(), TxtPdYr.Text, TcStartD)
            'If (TotRdUser > TotCap) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Registration Full (reached maximum capacity).</font></b></p>" : Exit Sub
            ' Validation - End

            Dim CourseStartDate As Date = "1/1/1900"
            If ddl_CStartDte.SelectedValue.ToString() = "" Then
                CourseStartDate = "1/1/1900"
                TxtSemester.Text = ""
            Else
                'If (Not updatepdinfo.DateChk(ddl_CStartDte.SelectedValue.ToString())) Then
                '    lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date (DD/MM/YYYY).</font></b></p>"
                '    Exit Sub
                'End If
                'CourseStartDate = Format(CDate(ddl_CStartDte.SelectedValue.ToString()), "dd/MM/yyyy")
                CourseStartDate = ddl_CStartDte.SelectedValue
            End If

            ''If drp_Category.SelectedValue = "" Then drp_Category.Items.Insert(0, String.Empty)
            ''If ddl_SubCat.SelectedValue = "" Then ddl_SubCat.Items.Insert(0, String.Empty)
            ''If CcodeDDList.SelectedValue = "" Then CcodeDDList.Items.Insert(0, String.Empty)
            ''If txt_pdDes.Text.Trim.ToString = "" Then txt_pdDes.Text = String.Empty
            ''If Txt_FInfo.Text.Trim.ToString = "" Then Txt_FInfo.Text = String.Empty
            ''If txt_SuggDate.Text.Trim.ToString = "" Then txt_SuggDate.Text = System.Data.SqlTypes.SqlDateTime.MinValue.Value
            ''If txt_SuggDate.Text.Trim.ToString = "" Then txt_SuggDate.Text = "1/1/0001"
            'If txt_SFees.Text.Trim.ToString = "" Then txt_SFees.Text = 0
            'If txt_TotCost.Text.Trim.ToString = "" Then txt_TotCost.Text = 0

            If (txt_TotCost.Text.Trim.ToString = 0.0 Or txt_TotCost.Text.Trim.ToString = 0) Then
                If Decimal.Parse(txt_SFees.Text) > 0 Then
                    txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) * Convert.ToInt32(txt_NoOfParti.Text))
                End If
            End If

            Dim TotNofRow As Integer = 0
            Dim A As Integer = 0

            Rst = updatepdinfo.UpdatePDprovisionLoc(txt_pdid.Text.Trim.ToString(), drp_Category.SelectedItem.Value.Trim.ToString, CcodeDDList.SelectedValue.Trim.ToString, Txt_FInfo.Text.Trim.ToString(), TxtSemester.Text.Trim.ToString(), txt_NoOfParti.Text.Trim.ToString(), txt_SFees.Text.Trim.ToString(), txt_TotCost.Text.Trim.ToString(), txtUser.Text.Trim.ToString(), ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.Trim.ToString(), ddl_SubCat.SelectedValue.Trim.ToString, CourseStartDate)
            If Rst = True Then
                lblErrMsg.Text = "<p><b><font color='#006400'>Record updated.</font></b></p>"
                Txt_FldChanges.Text = "No"
            Else
                lblErrMsg.Text = "<p><b><font color='#FF0000'>Record not updated, due to unknown issue. Please check.</font></b></p>"
                Exit Sub
            End If

            TotNofRow = GV_Childs.Rows.Count
            If TotNofRow > 0 Then
                Dim PdID(TotNofRow) As String
                Dim NuOfPartici As Integer = 1
                For A = 0 To (TotNofRow - 1)
                    PdID(A) = GV_Childs.Rows(A).Cells(0).Text.ToString()
                Next
                For A = 0 To (TotNofRow - 1)
                    Rst = updatepdinfo.UpdatePDprovisionLoc(PdID(A), drp_Category.SelectedItem.Text, CcodeDDList.SelectedValue.Trim.ToString, Txt_FInfo.Text.Trim.ToString(), TxtSemester.Text.Trim.ToString(), NuOfPartici, txt_SFees.Text.Trim.ToString(), txt_SFees.Text.Trim.ToString(), txtUser.Text.Trim.ToString(), ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.Trim.ToString(), ddl_SubCat.SelectedValue.Trim.ToString, CourseStartDate)
                    'If Rst = False Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Member(s) record not updated. Please check.</font></b></p>" : Exit Sub
                Next
                Call Load_MembersRec(Txt_tblink.Text.Trim.ToString)
            End If

            Call updatepdinfo.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_LocBal.Text = updatepdinfo.LocTotAmt

            If (txt_OldDeptStus.Text.Trim = "Allocated" Or ddl_DeptStus.SelectedItem.Text = "Allocated") Then
                Lock_Fields()
                Lock_Fields4Allocated()
            ElseIf (TxtUsrN.Text.ToLower = "puefinance" Or TxtUsrN.Text.ToLower = "puehumanr") Then
                Lock_Fields()
                'Lock_Fields4Allocated()
            End If

        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try

    End Sub

    Public Sub Lock_Fields()
        drp_Category.Enabled = False
        ddl_SubCat.Enabled = False
        CcodeDDList.Enabled = False
        txt_pdDes.Enabled = False
        Txt_FInfo.Enabled = False
        ddl_CStartDte.Enabled = False
        TxtSemester.Enabled = False
        txt_NoOfParti.Enabled = False
        txt_SFees.Enabled = False
        txt_TotCost.Enabled = False
        txt_SEmail.Enabled = False
        txt_SEmpNo.Enabled = False
        btn_Getrecord.Enabled = False
        btnSclear.Enabled = False
        btn_Getrecord.Enabled = False
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
    End Sub

    Public Sub Release_Fields()
        drp_Category.Enabled = True
        CcodeDDList.Enabled = True
        txt_pdDes.ReadOnly = False
        Txt_FInfo.ReadOnly = False
        'ddl_StartDate.Enabled = True
        txt_NoOfParti.ReadOnly = False
        txt_SFees.ReadOnly = False
        txt_TotCost.ReadOnly = False
        txt_DeptComns.ReadOnly = False
        GV_Childs.Enabled = True
    End Sub

    Protected Sub drp_Category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drp_Category.SelectedIndexChanged
        If drp_Category.SelectedItem.Text = "Select an Item" Then Exit Sub
        Txt_FldChanges.Text = "Yes"
        ' load Category
        Dim getUserDetails As careerDb = New careerDb
        Dim Ds1 As DataSet = New DataSet()
        Dim TotItems As Integer = 0
        Dim Pmtr As String = "Search"
        Ds1 = getUserDetails.Getpdcategory02(Pmtr, "", drp_Category.SelectedItem.Text)
        Dim dv1 As New DataView(Ds1.Tables("cat"))
        TotItems = dv1.Table.Rows.Count

        ''''Checking Whether record(s) available or not
        Dim drv As DataRowView
        Dim EmptyRec As String = ""
        For Each drv In dv1
            EmptyRec = drv("subcategory")
        Next

        If (TotItems = 0 Or TotItems = 1) Then
            If EmptyRec.Trim = "" Then
                ddl_SubCat.Items.Clear()
                CcodeDDList.Items.Clear()
                txt_pdDes.Text = ""
                txt_SFees.Text = "0"
                txt_TotCost.Text = "0"
                ddl_SubCat.DataSource = Nothing
                ddl_SubCat.DataBind()
                CcodeDDList.DataSource = Nothing
                CcodeDDList.DataBind()
                'Exit Sub
            Else
                ddl_SubCat.DataSource = dv1
                ddl_SubCat.DataTextField = "subcategory"
                ddl_SubCat.DataValueField = "subcategory"
                ddl_SubCat.DataBind()
                'CcodeDDList.Items.Insert(0, String.Empty)
                ddl_SubCat.Items.Insert(0, String.Empty)
            End If
        Else
            ddl_SubCat.DataSource = dv1
            ddl_SubCat.DataTextField = "subcategory"
            ddl_SubCat.DataValueField = "subcategory"
            ddl_SubCat.DataBind()
            ddl_SubCat.Items.Insert(0, String.Empty)
        End If

        'ddl_SubCat.DataSource = dv1
        'ddl_SubCat.DataTextField = "subcategory"
        'ddl_SubCat.DataValueField = "subcategory"
        'ddl_SubCat.DataBind()
        Ds1.Dispose()
        dv1.Dispose()
    End Sub
    Protected Sub ddl_SubCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_SubCat.SelectedIndexChanged
        If ddl_SubCat.SelectedItem.Text.Trim = "" Then Exit Sub
        Txt_FldChanges.Text = "Yes"
        Dim GetUserdetails1 As careerDb = New careerDb()
        Dim Ds2 As DataSet = New DataSet()
        Dim TotItems As Integer = 0
        Dim Pmtr As String = "Search"

        'Dim TsuCat As String = ""
        TsuCat = ddl_SubCat.SelectedItem.Text.Trim
        If (TsuCat = "QF-IB Event" Or TsuCat = "Cluster") Then
            TsuCat = "Travel: IB-Workshop"
        End If
        Ds2 = GetUserdetails1.GetCoursecategory(Pmtr, TsuCat)
        Dim dv As New DataView(Ds2.Tables("cCode"))
        TotItems = dv.Table.Rows.Count

        ''''Checking Whether record(s) available or not
        Dim drv As DataRowView
        Dim EmptyRec As String = ""
        For Each drv In dv
            EmptyRec = drv("CourseCode")
        Next

        If (TotItems = 0 Or TotItems = 1) Then
            If EmptyRec.Trim = "" Then
                CcodeDDList.Items.Clear()
                txt_pdDes.Text = ""
                txt_SFees.Text = "0"
                txt_TotCost.Text = "0"
                CcodeDDList.DataSource = Nothing
                CcodeDDList.DataBind()
            Else
                CcodeDDList.DataSource = dv
                CcodeDDList.DataTextField = "CourseDetails"
                CcodeDDList.DataValueField = "CourseCode"
                CcodeDDList.DataBind()
                CcodeDDList.Items.Insert(0, String.Empty)
            End If
        Else
            CcodeDDList.DataSource = dv
            CcodeDDList.DataTextField = "CourseDetails"
            CcodeDDList.DataValueField = "CourseCode"
            CcodeDDList.DataBind()
            CcodeDDList.Items.Insert(0, String.Empty)
        End If

        'CcodeDDList.DataSource = dv
        'CcodeDDList.DataTextField = "CourseDetails"
        'CcodeDDList.DataValueField = "CourseCode"
        'CcodeDDList.DataBind()
        'CcodeDDList.Items.Insert(0, String.Empty)
        Ds2.Dispose()
        dv.Dispose()
    End Sub
    Protected Sub ddl_DeptStus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_DeptStus.SelectedIndexChanged
        Txt_FldChanges.Text = "Yes"
        Try
            'If (txt_SFees.Text.Trim <> "" And txt_SFees.Text.Trim <> "0") Then
            '    ViewState("OldFee") = txt_SFees.Text.Trim
            'End If

            'If (txt_TotCost.Text.Trim <> "" And txt_TotCost.Text.Trim <> "0") Then
            '    ViewState("OldTotcost") = txt_TotCost.Text.Trim
            'End If

            If (ddl_DeptStus.SelectedItem.Text.Trim = "Cancelled By EDI") Then
                txt_SFees.Text = 0
                txt_TotCost.Text = 0
                'txt_SFees.Enabled = False
                'txt_TotCost.Enabled = False
            ElseIf (ddl_DeptStus.SelectedItem.Text.Trim = "Cancelled By User") Then
                txt_SFees.Text = ViewState("OldFee")
                If (txt_SFees.Text.Trim <> "" And txt_SFees.Text.Trim <> "0") Then
                    Dim Tfee As Integer = 0
                    Dim RtnAmt As Integer = 0
                    Dim Totamt As Integer = 0
                    Tfee = txt_SFees.Text.Trim
                    RtnAmt = (Tfee * 0.25)
                    Totamt = (Tfee - RtnAmt)
                    txt_SFees.Text = Totamt
                    txt_SFees_TextChanged(sender, e)
                    'txt_TotCost.Text = Totamt
                End If
            Else
                'txt_SFees.Enabled = True
                'txt_TotCost.Enabled = True
                txt_SFees.Text = ViewState("OldFee")
                txt_SFees_TextChanged(sender, e)
                'txt_TotCost.Text = ViewState("OldFee")
                'txt_TotCost.Text = ViewState("OldTotcost")
                'txt_TotCost.Text = txt_SFees.Text
            End If
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try

        'If ddl_DeptStus.SelectedItem.Text = "Allocated" Then
        '    Dim updatepdinfo As careerDb = New careerDb()
        '    Dim Ds As DataSet = New DataSet
        '    Dim TotNofRow As Integer = 0
        '    Dim A As Integer = 0
        '    Ds = updatepdinfo.UpdatePDinfobyDept02(txt_pdid.Text.ToString, ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.ToString, txtUser.Text.Trim.ToString)
        '    'update member record as well
        '    TotNofRow = GV_Childs.Rows.Count
        '    Dim PdID2(TotNofRow) As String
        '    For A = 0 To (TotNofRow - 1)
        '        PdID2(A) = GV_Childs.Rows(A).Cells(1).Text.ToString()
        '    Next
        '    For A = 0 To (TotNofRow - 1)
        '        Ds = updatepdinfo.UpdatePDinfobyDept02(PdID2(A), ddl_DeptStus.SelectedItem.Text, txt_DeptComns.Text.ToString, txtUser.Text.Trim.ToString)
        '    Next
        '    'End member record update
        '    lblErrMsg.Text = "<p><b><font color='#006400'>Record updated.</font></b></p>"
        '    Lock_Fields4Approval()
        '    Lock_Fields4Attended()
        '    Exit Sub
        'End If
    End Sub
    Protected Sub txt_NoOfParti_TextChanged(sender As Object, e As EventArgs) Handles txt_NoOfParti.TextChanged
        'Txt_FldChanges.Text = "Yes"
        'If (txt_NoOfParti.Text.Trim <> "") Then
        '    txt_TotCost.Text = (Decimal.Parse(txt_SFees.Text) * Convert.ToInt32(txt_NoOfParti.Text))
        'End If
    End Sub

    Private Sub pdeditPROVloc_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("UserName") = TxtUsrN.Text.Trim.ToString()
        Session("school") = TxtSchN.Text.Trim.ToString()
        Session("Role") = TxtRolE.Text.Trim.ToString()
        Session("pdneedyr") = TxtPdYr.Text.Trim.ToString()

        'Session("UserName") = ViewState("username").ToString()
        'Session("school") = ViewState("schname").ToString()
        'Session("Role") = ViewState("role").ToString()
        'Session("pdneedyr") = ViewState("pdneedyr").ToString()

        'Dim MboxRst As Integer = 0
        ''MboxRst = MessageBox.Show("Do you want to save data?", "Confirmation Window", "Caption", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, DialogResult.Yes)
        'If Txt_FldChanges.Text = "Yes" Then
        '    If (System.Windows.Forms.MessageBox.Show("Do you want to save data?", "Confirmation Window.", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes) Then
        '        but_submit_Click(sender, e)
        '    End If
        'End If
    End Sub
    Protected Sub btnSclear_Click(sender As Object, e As EventArgs) Handles btnSclear.Click
        Try
            lblErrMsg.Text = ""
            txt_firstName.Text = ""
            txt_LastName.Text = ""
            'txt_empno.Text = ""
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
                txt_Position.Text = "" & dv.Table.Rows(0)("position")
                txt_firstName.Text = "" & dv.Table.Rows(0)("firstname")
                txt_LastName.Text = "" & dv.Table.Rows(0)("lastname")
                txt_Dept.Text = "" & dv.Table.Rows(0)("department")
                txt_Center.Text = "" & dv.Table.Rows(0)("centername")
                txt_SEmpNo.Text = "" & dv.Table.Rows(0)("empno")
                txt_SEmail.Text = "" & dv.Table.Rows(0)("email")
                lblErrMsg.Text = ""
            Else
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

    Protected Sub Btn_AddCDRec_Click(sender As Object, e As EventArgs) Handles Btn_AddCDRec.Click
        If drp_Category.SelectedItem.Text.ToString.Trim() = "Select an Item" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Open and Choose Category...........</font></b></p>" : Exit Sub
        If txt_SEmpNo.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Choose Employee number.</font></b></p>" : Exit Sub
        If txt_SEmail.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Choose Employee email address.</font></b></p>" : Exit Sub
        If txt_firstName.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's First Name Field Empty.</font></b></p>" : Exit Sub
        If txt_LastName.Text.Trim = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Employee's Last Name Field Empty.</font></b></p>" : Exit Sub
        If Txt_EmpNo_PrevRec.Text.Trim = txt_SEmpNo.Text.Trim Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Duplicate entry.</font></b></p>" : Exit Sub
        If Txt_FldChanges.Text = "Yes" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Update the changes before add any record(s).</font></b></p>" : Exit Sub

        Try
            ' Validation - Start
            Dim RgLastDate As Date = "1/1/1900"
            Dim TcStartD As Date = "1/1/1900"
            If (ddl_CStartDte.SelectedValue.ToString().Trim <> "") Then
                TcStartD = ddl_CStartDte.SelectedValue.ToString()
            Else
                TcStartD = "1/1/1900"
            End If

            RgLastDate = GetUserdetails.GetDeadLine("DLDate", CcodeDDList.SelectedValue.ToString(), TcStartD)
            Dim Ndays As Integer = 0
            Ndays = DateDiff(DateInterval.Day, Now.Date, RgLastDate)
            If (Ndays < 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Registration Closed.</font></b></p>" : Exit Sub

            Dim TotCap As Integer = 0
            TotCap = GetUserdetails.GetTotalCapacity("TPax", CcodeDDList.SelectedValue.ToString(), "1/1/1900")

            Dim TotRdUser As Integer = 0
            TotRdUser = GetUserdetails.GetRegdTotParti("NuOfPax", CcodeDDList.SelectedValue.ToString(), TxtPdYr.Text, TcStartD)
            If (TotRdUser > TotCap) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Registration Full (reached maximum capacity).</font></b></p>" : Exit Sub
            ' Validation - End

            Dim CourseStartDate As Date = "1/1/1900"
            If ddl_CStartDte.SelectedValue.ToString() = "" Then
                CourseStartDate = "1/1/1900"
                TxtSemester.Text = ""
            Else
                'If (Not GetUserdetails.DateChk(ddl_CStartDte.SelectedValue.ToString())) Then
                '    lblErrMsg.Text = "<p><b><font color='#FF0000'>Enter module start date (DD/MM/YYYY).</font></b></p>"
                '    Exit Sub
                'End If
                'CourseStartDate = Format(CDate(ddl_CStartDte.SelectedValue.ToString()), "dd/MM/yyyy")
                CourseStartDate = ddl_CStartDte.SelectedValue
            End If

            Dim TempNoPart As Integer = 1
            Dim ReqType02 As String = "CD"

            Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_LocBal.Text = GetUserdetails.LocTotAmt

            Dim Tfees As Decimal = 0.0
            'Tfees = Integer.Parse(txt_SFees.Text)
            Tfees = Decimal.Parse(txt_SFees.Text)
            Dim TLocBal As Decimal = 0.0
            TLocBal = Decimal.Parse(Txt_LocBal.Text)

            'Check whether balance available or not
            If (Txt_LocBal.Text.ToString.Trim = "" Or Txt_LocBal.Text.ToString() = 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Can't accept your request. Please check the balance.</font></b></p>" : Exit Sub
            If (txt_SFees.Text = "") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Please check the fees.</font></b></p>" : Exit Sub
            'If (Tfees < 0) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Please check the fees.</font></b></p>" : Exit Sub
            If (Tfees > TLocBal) Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Insufficient balance. Please check the balance amount.</font></b></p>" : Exit Sub

            Rst = GetUserdetails.InsertPDProvisionLocal(txt_SEmpNo.Text.ToString.Trim(), drp_Category.SelectedItem.Value.Trim.ToString(), CcodeDDList.SelectedValue.Trim.ToString(), Txt_FInfo.Text.Trim.ToString(), TxtSemester.Text.Trim.ToString(), TempNoPart, txt_SFees.Text.ToString.Trim(), txt_SFees.Text.ToString.Trim(), Txt_tblink.Text.ToString.Trim, ReqType02, txtUser.Text.ToString.Trim(), txt_SchoolID.Text, ddl_SubCat.SelectedValue.Trim.ToString, TxtPdYr.Text, PDType, CourseStartDate)
            If (Rst = True) Then
                lblErrMsg.Text = "<p><b><font color='#006400'>Record (CD) Added.</font></b></p>"
            Else
                lblErrMsg.Text = "<p><b><font color='#FF0000'>Due to an error, record (cd) not added. Please check.</font></b></p>"
            End If

            'update Total no of participants and Total cost
            Dim Ttotcost As Integer = 0
            Dim TnumofP As Integer = 0
            TnumofP = Integer.Parse(txt_NoOfParti.Text)
            Ttotcost = Decimal.Parse(txt_TotCost.Text)
            TnumofP = (TnumofP + 1)
            Ttotcost = (Ttotcost + Tfees)
            Dim Ds01 As DataSet = New DataSet
            Ds01 = GetUserdetails.UpdandDeleteCDRec("update", txt_pdid.Text, TnumofP, Ttotcost)

            Call GetUserdetails.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_LocBal.Text = GetUserdetails.LocTotAmt

            txt_NoOfParti.Text = TnumofP
            txt_TotCost.Text = Ttotcost

            'Load CD records
            Call Load_MembersRec(Txt_tblink.Text.Trim.ToString)
            UpdatePanel14.Update()

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
        Call Load_MembersRec(Txt_tblink.Text.Trim.ToString)
    End Sub
    Protected Sub Txt_FInfo_TextChanged(sender As Object, e As EventArgs) Handles Txt_FInfo.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub txt_DeptComns_TextChanged(sender As Object, e As EventArgs) Handles txt_DeptComns.TextChanged
        Txt_FldChanges.Text = "Yes"
    End Sub
    Protected Sub ddl_CStartDte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CStartDte.SelectedIndexChanged
        Try
            Dim GetUsrDetail As careerDb = New careerDb
            Dim SemNumber As String = ""
            If ddl_CStartDte.SelectedValue.ToString() = "" Then
                TxtSemester.Text = ""
            Else
                SemNumber = GetUsrDetail.GetSemesterNo(ddl_CStartDte.SelectedValue.ToString())
                TxtSemester.Text = SemNumber
            End If
        Catch ex As Exception
            lblErrMsg.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Overloads Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)
        Dim strDisAbleBackButton As String
        strDisAbleBackButton = "<script language=" & """javascript""" & ">" & vbLf
        strDisAbleBackButton += "history.pushState(null, null, location.href);" & vbLf
        strDisAbleBackButton += "window.onpopstate = function () { history.go(1); };" & vbLf
        strDisAbleBackButton += vbLf & "</script>"
        ClientScript.RegisterClientScriptBlock(Me.Page.[GetType](), "clientScript", strDisAbleBackButton)
    End Sub

    Public Sub Lock_Fields4Approval()
        drp_Category.Enabled = False
        ddl_SubCat.Enabled = False
        CcodeDDList.Enabled = False
        txt_pdDes.Enabled = False
        Txt_FInfo.Enabled = False
        ddl_CStartDte.Enabled = False
        TxtSemester.Enabled = False
        txt_NoOfParti.Enabled = False
        txt_SFees.Enabled = False
        txt_TotCost.Enabled = False
        txt_DeptComns.Enabled = False
        GV_Childs.Enabled = False
        btn_Getrecord.Enabled = False
        btnSclear.Enabled = False
        Btn_AddCDRec.Enabled = False
        txt_SEmail.Enabled = False
        txt_SEmpNo.Enabled = False
    End Sub

    Public Sub Lock_Fields4Attended()
        ddl_DeptStus.Enabled = False
        but_submit.Enabled = False
    End Sub


End Class
