Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports System.Math

Partial Class pdplanview
    Inherits System.Web.UI.Page
    Dim QryStr As String = ""
    Public TScid1 As String = ""
    Public Temailid1 As String = ""
    Public TediStus1 As String = ""
    Public Tdeptstus1 As String = ""
    Public TLname1 As String = ""
    Public TDept1 As String = ""
    Public TCCode1 As String = ""
    Public tEmpNo As String = ""
    Public TPgNo As Integer = 0
    Public GrdPgNo As Integer = 0
    Public TtGrdPgNo As Integer = 0
    Public GrdPgSize As Integer = 1
    Public TPgSize As Integer = 0
    Public Tpdtype1 As String = ""
    Public TpdYr As String = ""

    Protected Sub but_submit_Click(sender As Object, e As EventArgs) Handles but_submit.Click
        If drp_PDYear.SelectedIndex = 0 Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Select PD Year...........</font></b></p>" : Exit Sub
        lblErrMsg.Text = ""
        Call Refresh_DataGrid()
        Call Session_Var()
        Call Bindgrid()
    End Sub

    Private Sub pdplanview_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Username") = "" Then
            Response.Redirect("default.aspx")
            txt_SchoolID.Text = ""
        End If

        If Not Me.IsPostBack Then
            QryStr = "" & Request.QueryString("Fname")
            txt_SchoolID.Text = "" & Session.Item("school").ToString
            txt_user.Text = "" & Session.Item("UserName").ToString

            TxtUsrN.Text = "" & Session.Item("UserName").ToString
            TxtSchN.Text = "" & Session.Item("school").ToString
            TxtRolE.Text = "" & Session.Item("Role").ToString
            TxtPdYr.Text = "" & Session.Item("pdneedyr").ToString

            'ViewState("username") = "" & Session.Item("UserName").ToString
            'ViewState("schname") = "" & Session.Item("school").ToString
            'ViewState("role") = "" & Session.Item("Role").ToString
            'ViewState("pdneedyr") = "" & Session.Item("pdneedyr").ToString

            'Load PD Year
            Load_PDYear()

            'Load Department Status
            Dim GetUserdetails1 As careerDb = New careerDb()
            Dim Ds4 As DataSet = New DataSet()
            Ds4 = GetUserdetails1.GetDeptStatus(TxtRolE.Text.Trim)
            Dim dv4 As New DataView(Ds4.Tables("deptstatus"))
            ddl_DeptStus.DataSource = dv4
            ddl_DeptStus.DataTextField = "deptstatus"
            ddl_DeptStus.DataValueField = "deptstatus"
            ddl_DeptStus.DataBind()
            ddl_DeptStus.Items.Insert(0, String.Empty)
            ddl_DeptStus.SelectedIndex = 0
            Ds4.Dispose()
            dv4.Dispose()

            Dim Des2 As DataSet = New DataSet()
            Des2 = GetUserdetails1.GetDept(txt_SchoolID.Text.ToString.Trim())
            Dim dv2 As New DataView(Des2.Tables("dept"))
            drp_Dept.DataSource = dv2
            drp_Dept.DataTextField = "Department"
            drp_Dept.DataValueField = "Department"
            drp_Dept.DataBind()
            drp_Dept.Items.Insert(0, String.Empty)
            Des2.Dispose()
            dv2.Dispose()

            Dim Ds1 As DataSet = New DataSet()
            Ds1 = GetUserdetails1.GetPDType()
            Dim dv As New DataView(Ds1.Tables("pdType"))
            drp_PDType.DataSource = dv
            drp_PDType.DataTextField = "notes"
            drp_PDType.DataValueField = "pdtype"
            drp_PDType.DataBind()
            'drp_PDType.Items.Add(String.Empty)
            drp_PDType.Items.Insert(0, String.Empty)
            drp_PDType.SelectedIndex = -1
            Ds1.Dispose()
            dv.Dispose()

            'Call EDI_DDL_Clean()
            'txt_ediStatus.Text = ""

            'Load Balance amount
            'Call GetUserdetails1.GetBudgetData(txt_SchoolID.Text.Trim.ToString)
            Call GetUserdetails1.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Txt_Local.Text = GetUserdetails1.LocTotAmt
            Txt_Travel.Text = GetUserdetails1.TrvTotAmt

            'Modified by Mohan 11/03/2017
            If QryStr = "pdplan" Then
                Me.Bindgrid()
            End If
        End If
    End Sub
    Protected Sub EDI_DDL_Clean()
        'Dim DDL_Text As String = ""
        'Dim GetUserdetails1 As careerDb = New careerDb()
        'Dim Ds1 As DataSet = New DataSet()
        'Ds1 = GetUserdetails1.GetEdiStatus()
        'Dim dv As New DataView(Ds1.Tables("edistatus"))
        'Dim dvRow As DataRowView = dv.AddNew
        'For Each dvRow In dv
        '    DDL_Text = dvRow.Item("edistatus").ToString()
        '    DDL_Text = DDL_Text.Replace(vbCrLf, String.Empty)
        '    dvRow("edistatus") = DDL_Text
        '    dvRow.EndEdit()
        'Next
        'drp_PDType.DataSource = dv
        'drp_PDType.DataTextField = "edistatus"
        'drp_PDType.DataValueField = "edistatus"
        'drp_PDType.DataBind()
        'drp_PDType.Items.Insert(0, String.Empty)

    End Sub

    Protected Sub Bindgrid()
        Dim TtblCnt As Integer = 0
        Dim TrecCnt As Integer = 0
        Dim TpgSize2 As Double = 0
        Dim pdType As String = ""

        Try
            Dim GetUserdetails As careerDb = New careerDb()
            If (QryStr = String.Empty) Then
                If drp_PDType.SelectedValue.Trim.ToString = "Local" Then
                    pdType = "Local"
                ElseIf drp_PDType.SelectedValue.Trim.ToString = "Travel" Then
                    pdType = "Travel"
                Else
                    pdType = ""
                End If
                'pdType = drp_PDType.SelectedValue.Trim.ToString
                Dim Ds As DataSet = New DataSet()

                Ds = GetUserdetails.Getpdplandetails4EUS02(txt_SchoolID.Text.ToString, drp_Dept.SelectedItem.Value.ToString.Trim(), ddl_DeptStus.SelectedItem.Value.ToString.Trim(), drp_PDType.SelectedValue.Trim.ToString, txt_LastName.Text.ToString.Trim(), txt_Email.Text.ToString, txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDYear.SelectedItem.Text)

                'Ds = GetUserdetails.Getpdplandetails4EUS(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, ddl_DeptStus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, pdType)
                'Ds = GetUserdetails.Getpdplandetails4EUS(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, ddl_DeptStus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDType.SelectedValue.Trim.ToString)
                Dim DaV As DataView = New DataView(Ds.Tables("pdPlanView"))
                GV_PDplan.DataSource = DaV
                GV_PDplan.DataBind()
            ElseIf (QryStr = "pdplan") Then
                Dim DtaSt As New DataSet()
                TpdYr = "" & Session("TPDYear")
                TScid1 = "" & Session("TScid")
                Temailid1 = "" & Session("Temailid")
                txt_Email.Text = Temailid1
                'TediStus1 = "" & Session("TediStus")
                Tdeptstus1 = "" & Session("Tdeptstus")
                ddl_DeptStus.SelectedIndex = ddl_DeptStus.Items.IndexOf(ddl_DeptStus.Items.FindByValue(Tdeptstus1))
                'drp_EdiStatus.SelectedIndex = drp_EdiStatus.Items.IndexOf(drp_EdiStatus.Items.FindByValue(TediStus1))
                TtGrdPgNo = Session("GrdPgNo")
                TLname1 = "" & Session("TLname")
                txt_LastName.Text = TLname1
                TDept1 = "" & Session("TDept")
                drp_Dept.SelectedIndex = drp_Dept.Items.IndexOf(drp_Dept.Items.FindByValue(TDept1))
                TCCode1 = "" & Session("TCCode")
                txt_CourseCode.Text = TCCode1
                tEmpNo = "" & Session("Tempno")
                txt_EmpNo.Text = tEmpNo
                Tpdtype1 = "" & Session("Tpdtype")
                drp_PDType.SelectedIndex = drp_PDType.Items.IndexOf(drp_PDType.Items.FindByValue(Tpdtype1))

                DtaSt = GetUserdetails.Getpdplandetails4EUS02(TScid1, TDept1, Tdeptstus1, Tpdtype1, TLname1, Temailid1, TCCode1, tEmpNo, TpdYr)

                'DtaSt = GetUserdetails.Getpdplandetails4EUS(TScid1, Temailid1, TediStus1, TLname1, TDept1, TCCode1, tEmpNo, Tpdtype1)
                'DtaSt = GetUserdetails.Getpddetails(TScid1, Temailid1, TediStus1, TLname1, TDept1, TCCode1, tEmpNo)

                TtblCnt = DtaSt.Tables.Count
                TrecCnt = DtaSt.Tables(0).Rows.Count
                If (TrecCnt >= 1) Then
                    TPgSize = (TrecCnt / GrdPgSize)
                Else
                    TPgSize = 0
                End If
                TpgSize2 = Math.Ceiling(TPgSize)
                If TtGrdPgNo > TpgSize2 Then TtGrdPgNo = TpgSize2
                GV_PDplan.DataSource = DtaSt
                GV_PDplan.PageIndex = TtGrdPgNo
                GV_PDplan.DataBind()
            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub index_changed(sender As Object, e As EventArgs) Handles drp_PDType.SelectedIndexChanged
        'Try
        '    If drp_PDType.SelectedItem.Text.ToString = "" Then
        '        txt_ediStatus.Text = ""
        '    Else
        '        txt_ediStatus.Text = "" & drp_PDType.SelectedItem.Text.ToString
        '    End If

        'Catch ex As Exception
        '    Response.Write(ex.Message.ToString)
        'End Try
    End Sub
    Private Function GetSortDirection(ByVal column As String) As String
        'Code Added by Mohan on 12/4/2017
        Dim sortDirection As String = "ASC"
        Dim sortExpression As String = TryCast(ViewState("SortExpression"), String)
        If Not IsNothing(sortExpression) Then
            If sortExpression = column Then
                Dim lastDirection As String = TryCast(ViewState("SortDirection"), String)
                If (Not IsNothing(lastDirection) AndAlso (lastDirection = "ASC")) Then
                    sortDirection = "DESC"
                End If
            End If
        End If
        ViewState("SortDirection") = sortDirection
        ViewState("SortExpression") = column
        Return sortDirection
    End Function

    Private Sub GV_PDplan_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GV_PDplan.Sorting
        Dim sortDir As String = ""
        Dim GetUserdetails As careerDb = New careerDb()
        Dim Ds As DataSet = New DataSet()
        Ds = GetUserdetails.Getpdplandetails4EUS02(txt_SchoolID.Text.ToString, drp_Dept.SelectedItem.Value.ToString.Trim(), ddl_DeptStus.SelectedItem.Value.ToString.Trim(), drp_PDType.SelectedValue.Trim.ToString, txt_LastName.Text.ToString.Trim(), txt_Email.Text.ToString, txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDYear.SelectedItem.Text)

        'Ds = GetUserdetails.Getpdplandetails4EUS(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, ddl_DeptStus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDType.SelectedValue.Trim.ToString)
        Dim DtaView As New DataView(Ds.Tables("pdPlanView"))
        If Not IsNothing(DtaView) Then
            sortDir = GetSortDirection(e.SortExpression)
            'DtaView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
            DtaView.Sort = e.SortExpression & " " & sortDir
            GV_PDplan.DataSource = DtaView
            GV_PDplan.DataBind()
        End If

        'If sortDir = "ASC" Then
        '    lblErrMsg.Text = "Sorting by " & e.SortExpression.ToString() & " in ascending order."
        'Else
        '    lblErrMsg.Text = "Sorting by " & e.SortExpression.ToString() & " in descending order."
        'End If
        ''lblErrMsg.Text = "Sorting by " & e.SortExpression.ToString() & " in " & sortDir & " order."
        ''lblErrMsg.Text = "Sorting by " & GV_PDplan.SortExpression.ToString() & " in " & GV_PDplan.SortDirection.ToString() & " order."
    End Sub

    Private Sub GV_PDplan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GV_PDplan.PageIndexChanging
        GV_PDplan.PageIndex = e.NewPageIndex
        TPgNo = e.NewPageIndex
        Session("GrdPgNo") = TPgNo
        Call Bindgrid()
    End Sub
    Protected Sub GV_PDplan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GV_PDplan.SelectedIndexChanged
        Dim TkeyValue As String = GV_PDplan.DataKeys(GV_PDplan.SelectedRow.RowIndex).Value.ToString()
        Dim Tkey4CD As String = TkeyValue.Trim
        If TkeyValue.Trim.ToString() = "" Then lblErrMsg.Text = "<p><b><font color='#FF0000'>No key data.</font></b></p>" : Exit Sub
        TkeyValue = TkeyValue & "&RtnPath=pdplanviewEUS.aspx"

        Dim sTaTuS As String = GV_PDplan.SelectedRow.Cells(12).Text.ToString
        If (sTaTuS.Trim = "Allocated") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Record has been locked.</font></b></p>" : Exit Sub

        Dim tYpeofRec As String = ""
        tYpeofRec = GV_PDplan.SelectedRow.Cells(14).Text.ToString
        If (tYpeofRec = "ST") Then
            Response.Redirect("pdentryTrvUpd.aspx?pdid=" & TkeyValue)
        ElseIf (tYpeofRec = "SL") Then
            Response.Redirect("pdentryLocalUpd.aspx?pdid=" & TkeyValue)
        ElseIf (tYpeofRec = "PT") Then
            Response.Redirect("pdeditPROVtrv.aspx?pdid=" & TkeyValue)
        ElseIf (tYpeofRec = "PL") Then
            Response.Redirect("pdeditPROVloc.aspx?pdid=" & TkeyValue)
        ElseIf tYpeofRec = "CD" Then
            Dim GetDetails As careerDb = New careerDb
            Dim Ds As DataSet = New DataSet
            Dim Precid As String = ""
            Dim RecType As String = ""
            Ds = GetDetails.GetParentRec(Tkey4CD)
            Dim dV As New DataView(Ds.Tables("ParentRecID"))
            Precid = dV.Table.Rows(0)("pdid").ToString
            RecType = dV.Table.Rows(0)("reqtype").ToString
            If Precid.Trim = "" Then Exit Sub
            Precid = Precid & "&RtnPath=pdplanviewEUS.aspx"
            If (RecType = "PT") Then
                Response.Redirect("pdeditPROVtrv.aspx?pdid=" & Precid)
            ElseIf (RecType = "PL") Then
                Response.Redirect("pdeditPROVloc.aspx?pdid=" & Precid)
            End If
        End If

    End Sub
    Protected Sub Session_Var()
        'Code added by Mohan on 10/04/2017
        'Session("GrdPgNo") = TPgNo
        Session("TPDYear") = IIf(drp_PDYear.SelectedValue.ToString.Trim() = String.Empty, "", drp_PDYear.SelectedValue.ToString.Trim())
        Session("TScid") = IIf(txt_SchoolID.Text.ToString.Trim() = String.Empty, "", txt_SchoolID.Text.ToString.Trim)
        Session("Temailid") = IIf(txt_Email.Text.ToString.Trim() = String.Empty, "", txt_Email.Text.ToString.Trim)
        'Session("TediStus") = IIf(drp_EdiStatus.SelectedItem.Value.ToString.Trim() = String.Empty, "", drp_EdiStatus.SelectedItem.Value.ToString.Trim())
        Session("Tdeptstus") = IIf(ddl_DeptStus.SelectedItem.Value.ToString.Trim() = String.Empty, "", ddl_DeptStus.SelectedItem.Value.ToString.Trim())
        Session("TLname") = IIf(txt_LastName.Text.ToString.Trim() = String.Empty, "", txt_LastName.Text.ToString.Trim())
        Session("TDept") = IIf(drp_Dept.SelectedItem.Value.ToString.Trim() = String.Empty, "", drp_Dept.SelectedItem.Value.ToString.Trim())
        Session("TCCode") = IIf(txt_CourseCode.Text.ToString().Trim = String.Empty, "", txt_CourseCode.Text.ToString().Trim)
        Session("Tempno") = IIf(txt_EmpNo.Text.ToString().Trim = String.Empty, "", txt_EmpNo.Text.ToString().Trim)
        Session("Tpdtype") = IIf(drp_PDType.SelectedItem.Value.ToString.Trim() = String.Empty, "", drp_PDType.SelectedItem.Value.ToString.Trim())
        QryStr = ""
        'TPgNo = 0
    End Sub
    Protected Sub Refresh_DataGrid()
        Try
            GV_PDplan.DataSource = Nothing
            GV_PDplan.PageIndex = 0
            GV_PDplan.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        Try
            lblErrMsg.Text = ""
            txt_Email.Text = ""
            'txt_ediStatus.Text = ""
            drp_PDType.SelectedIndex = -1
            txt_LastName.Text = ""
            drp_Dept.SelectedIndex = -1
            ddl_DeptStus.SelectedIndex = -1
            QryStr = ""
            txt_CourseCode.Text = ""
            txt_EmpNo.Text = ""
            TPgNo = 0
            drp_PDYear.SelectedIndex = drp_PDYear.Items.IndexOf(drp_PDYear.Items.FindByValue(TxtPdYr.Text.Trim))
            'Call Bindgrid()
            'dg_pdedit.Page.Focus = 0
            'dg_pdedit.CurrentPageIndex = 0
            Call Refresh_DataGrid()
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
    End Sub
    Protected Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Try
            Call exportgrid()
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
    End Sub
    Private Sub dataexport()
        'Dim sb As StringBuilder = New StringBuilder()
        'Dim SW As System.IO.StringWriter = New System.IO.StringWriter(sb)
        'Dim htw As HtmlTextWriter = New HtmlTextWriter(SW)
        'Dim Page As Page = New Page()
        'Dim form As HtmlForm = New HtmlForm()
        'Me.GV_PDplan.EnableViewState = False
        'Page.EnableEventValidation = False
        'Me.GV_PDplan.AllowPaging = False
        'Page.DesignerInitialize()
        'Page.Controls.Add(form)
        'form.Controls.Add(Me.GV_PDplan)
        'Page.RenderControl(htw)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/vnd.ms-excel"
        'Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
        '' Response.Charset = "UTF-8"
        'Response.ContentEncoding = Encoding.Default
        'Response.Write(sb.ToString())
        'Response.End()
    End Sub

    Private Sub exportgrid()
        Try
            Dim GetUserdetails As careerDb = New careerDb()
            Dim Ds As DataSet = New DataSet()
            'Ds = GetUserdetails.Getpddetails(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, drp_EdiStatus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim())
            'Ds = GetUserdetails.Getpddetails(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, drp_EdiStatus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.ToString().Trim, txt_EmpNo.Text.ToString.Trim)
            'Ds = GetUserdetails.Getpdplandetails(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, drp_EdiStatus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim)
            'Ds = GetUserdetails.Getpdplandetails(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, drp_PDType.SelectedValue.Trim.ToString, txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim)
            'dg_pdedit.DataSource = Ds
            'dg_pdedit.DataBind()

            Ds = GetUserdetails.Getpdplandetails4EUS02(txt_SchoolID.Text.ToString, drp_Dept.SelectedItem.Value.ToString.Trim(), ddl_DeptStus.SelectedItem.Value.ToString.Trim(), drp_PDType.SelectedValue.Trim.ToString, txt_LastName.Text.ToString.Trim(), txt_Email.Text.ToString, txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDYear.SelectedItem.Text)
            'Ds = GetUserdetails.Getpdplandetails4EUSExport(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, ddl_DeptStus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDType.SelectedValue.Trim.ToString)
            'Ds = GetUserdetails.Getpdplandetails4EUS(txt_SchoolID.Text.ToString, txt_Email.Text.ToString, ddl_DeptStus.SelectedItem.Value.ToString.Trim(), txt_LastName.Text.ToString.Trim(), drp_Dept.SelectedItem.Value.ToString.Trim(), txt_CourseCode.Text.Trim.ToString(), txt_EmpNo.Text.ToString.Trim, drp_PDType.SelectedValue.Trim.ToString)
            Dim sb As StringBuilder = New StringBuilder()
            Dim SW As System.IO.StringWriter = New System.IO.StringWriter(sb)
            Dim htw As HtmlTextWriter = New HtmlTextWriter(SW)
            'Dim Page As Page = New Page()
            'Dim form As HtmlForm = New HtmlForm()

            Dim dg As GridView = New GridView()
            dg.DataSource = Ds.Tables(0)
            dg.DataBind()

            'Page.DesignerInitialize()
            'Page.Controls.Add(form)
            'form.Controls.Add(Me.dg)
            'Page.RenderControl(htw)
            dg.RenderControl(htw)
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
            ' Response.Charset = "UTF-8"
            HttpContext.Current.Response.ContentEncoding = Encoding.Default
            HttpContext.Current.Response.Write(sb.ToString())
            HttpContext.Current.Response.End()
        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GV_PDplan_DataBound(sender As Object, e As EventArgs) Handles GV_PDplan.DataBound
        '' Get the header row.
        'Dim headerRow As GridViewRow = GV_PDplan.HeaderRow

        '' Get the footer row.
        'Dim footerRow As GridViewRow = GV_PDplan.FooterRow

        '' Set the font color of the header and footer rows
        '' based on the sort direction. 
        'Select Case GV_PDplan.SortDirection

        '    Case SortDirection.Ascending
        '        headerRow.ForeColor = System.Drawing.Color.Green
        '        footerRow.ForeColor = System.Drawing.Color.Green
        '    Case SortDirection.Descending
        '        headerRow.ForeColor = System.Drawing.Color.Red
        '        footerRow.ForeColor = System.Drawing.Color.Red
        '    Case Else
        '        headerRow.ForeColor = System.Drawing.Color.Black
        '        footerRow.ForeColor = System.Drawing.Color.Black
        'End Select

        '' Display the sort order in the footer row.
        'footerRow.Cells(0).Text = "Sort Order = " & GV_PDplan.SortDirection.ToString()
    End Sub

    Private Sub GV_PDplan_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GV_PDplan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim row As System.Data.DataRow = DirectCast(e.Row.DataItem, System.Data.DataRowView).Row
            If (row("reqtype").ToString() = "ST" Or row("reqtype").ToString() = "SL") Then
                e.Row.BackColor = System.Drawing.Color.LightSkyBlue
            ElseIf (row("reqtype").ToString() = "PT" Or row("reqtype").ToString() = "PL") Then
                e.Row.BackColor = System.Drawing.Color.DeepPink
            ElseIf (row("reqtype").ToString() = "CD") Then
                e.Row.BackColor = System.Drawing.Color.LightPink
            End If
            If row("cventreg").ToString() = "No" Then
                'e.Row.Cells(18).BackColor = System.Drawing.Color.Red
                e.Row.Cells(18).ForeColor = System.Drawing.Color.Red
            ElseIf row("cventreg").ToString() = "Yes" Then
                'e.Row.Cells(18).BackColor = System.Drawing.Color.Green
                e.Row.Cells(18).ForeColor = System.Drawing.Color.Green
            End If
            Dim myImageBtn As ImageButton = e.Row.Cells(19).Controls(1)
            If (row("deptstus").ToString() = "Budgeted") Then
                myImageBtn.ImageUrl = "~/images/erase.ico"
            ElseIf (row("deptstus").ToString() = "Allocated") Then
                myImageBtn.ImageUrl = "~/images/block_01.png"
            ElseIf (row("deptstus").ToString() = "") Then
                myImageBtn.ImageUrl = ""
            End If
        End If
    End Sub

    Private Sub GV_PDplan_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GV_PDplan.RowDeleting
        Dim Tst As String
        Tst = ""
        Refresh_DataGrid()
        Bindgrid()
        'lblErrMsg.Text = "Grid Refreshed."
    End Sub

    Private Sub GV_PDplan_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GV_PDplan.RowCommand
        If (e.CommandName = "Delete") Then
            Dim refno As Integer = Convert.ToInt32(e.CommandArgument)
            Dim GetUsrData As careerDb = New careerDb
            Dim Dset As DataSet = New DataSet
            Dset = GetUsrData.GetPDPlanTblDetails(refno)
            Dim Dv As New DataView(Dset.Tables("GetEmprec4PrvT"))
            Dim TotRec As Int32 = 0
            TotRec = Dv.Table.Rows.Count
            If TotRec = 0 Then Exit Sub

            Dim tOtaMt As Integer = 0
            Dim tBlLink As String = ""
            Dim TblParaM As String = ""
            Dim UsrSchName As String = ""
            Dim TdeptStus As String = ""
            Dim TpdType As String = ""

            tOtaMt = Dv.Table.Rows(0)("totalcost")
            tBlLink = "" & Dv.Table.Rows(0)("tbllink")
            TblParaM = "" & Dv.Table.Rows(0)("reqtype")
            UsrSchName = "" & Dv.Table.Rows(0)("schoolname")
            TdeptStus = "" & Dv.Table.Rows(0)("deptstus")
            TpdType = "" & Dv.Table.Rows(0)("pdtype")
            Dv.Dispose()
            Dset.Dispose()

            'If (TblParaM.Trim = "" Or TblParaM.Trim = "CD") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Not able to delete, permission denied.</font></b></p>" : Exit Sub
            If (TdeptStus.Trim = "Allocated") Then lblErrMsg.Text = "<p><b><font color='#FF0000'>Not able to delete, permission denied.</font></b></p>" : Exit Sub

            '1. Add amount to total amount
            Dim Ds As DataSet = New DataSet
            Dim Rst As Boolean = False
            Dim rECsTATUS As String = ""

            'If (tOtaMt > 0) Then
            '    If (txt_SchoolID.Text.Trim.ToString = "RENAD" Or txt_SchoolID.Text.Trim.ToString = "TLC") Then
            '        Ds = GetUsrData.UpdateBudgetTbl4RENADnTLC(txt_SchoolID.Text.Trim.ToString, tOtaMt, "Add")
            '        Ds.Dispose()
            '    Else
            '        ''''''Start
            '        If TblParaM = "CD" Then
            '            If TpdType = "Local" Then
            '                Rst = GetUsrData.UpdateBudgetTbl02("PL", "Add", UsrSchName, tOtaMt)
            '            Else
            '                Rst = GetUsrData.UpdateBudgetTbl02("PT", "Add", UsrSchName, tOtaMt)
            '            End If
            '        Else
            '            Rst = GetUsrData.UpdateBudgetTbl02(TblParaM, "Add", UsrSchName, tOtaMt)
            '        End If
            '        ''''''End
            '        'Add balance amount to PT/PL's total amount straight away
            '        'Rst = GetUsrData.UpdateBudgetTbl02(TblParaM, "Add", UsrSchName, tOtaMt)
            '        'Add into Trans Tbl this transactions
            '        'Txt_OldTotCost.Text = txt_TotCost.Text
            '    End If
            '    'Rst = GetUsrData.UpdateBudgetTbl02(TblParaM, "Add", UsrSchName, tOtaMt)
            'End If

            'Delete using tbllink data
            If TblParaM = "PL" Or TblParaM = "PT" Then
                Dim Dset2 As DataSet = New DataSet
                Dset2 = GetUsrData.deletepdrecbytbllink(tBlLink)
                Dset2.Dispose()

                ''2. Delete members if any
                'Dim Dset2 As DataSet = New DataSet
                'Dset2 = GetUsrData.GetChidsDetails(tBlLink)
                'Dim Dv2 As New DataView(Dset2.Tables("ChildDetails01"))
                'Dim TotItems As Integer = Dv2.Table.Rows.Count
                'Dim PdID(TotItems) As String
                'Dim I As Integer = 0
                'For I = 0 To (TotItems - 1)
                '    PdID(I) = Dv2.Table.Rows(I)("pdid")
                'Next

                'For I = 0 To (TotItems - 1)
                '    rECsTATUS = GetUsrData.DeletePDbyid02(PdID(I))
                'Next

                '3 Delete main record PL/PT
                'rECsTATUS = GetUsrData.DeletePDbyid02(refno)

            ElseIf TblParaM.Trim = "CD" Then
                'Reduce Number of Participants and total cost
                Dim Ttotcost As Integer = 0
                Dim TnumofP As Integer = 0
                Dim TnumofP02 As String = ""
                'Dim GetDetails As careerDb = New careerDb
                Dim Ds0 As DataSet = New DataSet
                Dim Precid As String = ""
                Dim RecType As String = ""
                Ds0 = GetUsrData.GetParentRec(refno)
                Dim dV0 As New DataView(Ds0.Tables("ParentRecID"))
                Precid = dV0.Table.Rows(0)("pdid").ToString
                RecType = dV0.Table.Rows(0)("reqtype").ToString
                TnumofP = dV0.Table.Rows(0)("nofparticipants").ToString
                Ttotcost = dV0.Table.Rows(0)("totalcost").ToString
                If Precid.Trim = "" Then Exit Sub

                TnumofP = (TnumofP - 1)
                Ttotcost = (Ttotcost - tOtaMt)

                Dim Ds01 As DataSet = New DataSet
                'Update parent record
                Ds01 = GetUsrData.UpdandDeleteCDRec("update", Precid, TnumofP, Ttotcost)

                Dim Ds02 As DataSet = New DataSet
                'Delete CD record
                Ds02 = GetUsrData.UpdandDeleteCDRec("delete", refno, "0", "0")
                'Ds01 = GetUsrData.GetMinusParticipants(refno)
                Ds01.Dispose()
                Ds02.Dispose()
                dV0.Dispose()
                Ds0.Dispose()

            ElseIf (TblParaM.Trim = "ST" Or TblParaM.Trim = "SL") Then

                '3 Delete main record PL/PT
                rECsTATUS = GetUsrData.DeletePDbyid02(refno)
            End If
            '24 Oct 2017''''END


            'lblErrMsg.Text = "<p><b><font color='#006400'>Record (" & refno & ") Deleted.</font></b></p>"
            lblErrMsg.Text = "<p><b><font color='#006400'>Record Deleted.</font></b></p>"

            'Call GetUsrData.GetBudgetData(UsrSchName)
            'Call GetUsrData.GetPDBalanceBothLT(txt_SchoolID.Text, TxtPdYr.Text.ToString.Trim)
            Call GetUsrData.GetPDBalanceBothLT(UsrSchName, TxtPdYr.Text.ToString.Trim)
            Txt_Local.Text = GetUsrData.LocTotAmt
            Txt_Travel.Text = GetUsrData.TrvTotAmt

        End If
    End Sub

    Private Sub pdplanview_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("UserName") = TxtUsrN.Text.Trim.ToString()
        Session("school") = TxtSchN.Text.Trim.ToString()
        Session("Role") = TxtRolE.Text.Trim.ToString()
        Session("pdneedyr") = TxtPdYr.Text.Trim.ToString()

        'Session("UserName") = ViewState("username").ToString()
        'Session("school") = ViewState("schname").ToString()
        'Session("Role") = ViewState("role").ToString()
        'Session("pdneedyr") = ViewState("pdneedyr").ToString()
    End Sub

    Protected Sub Load_PDYear()
        Try
            Dim GetUserdetails As careerDb = New careerDb()
            Dim dS As DataSet = New DataSet
            dS = GetUserdetails.QFSchoolYear("SELECT", 0, String.Empty, String.Empty)
            Dim DaV As DataView = New DataView(dS.Tables("qfSchYrData"))
            drp_PDYear.DataSource = DaV
            drp_PDYear.DataTextField = "schoolyear"
            drp_PDYear.DataValueField = "schoolyear"
            drp_PDYear.DataBind()
            drp_PDYear.Items.Insert(0, String.Empty)
            DaV.Dispose()
            dS.Dispose()
            drp_PDYear.SelectedIndex = drp_PDYear.Items.IndexOf(drp_PDYear.Items.FindByValue(TxtPdYr.Text.Trim))
        Catch ex As Exception
            'lblErrMsg.Text = "<p><b><font color='#FF0000'>" & Err.Number & " : " & Err.Description & "</font></b></p>"
            lblErrMsg.Text = "" & Err.Number & " : " & Err.Description & ""
            lblErrMsg.BackColor = System.Drawing.Color.White
        End Try
    End Sub

End Class