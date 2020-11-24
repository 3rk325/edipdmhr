Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web.UI.WebControls

Partial Class monitorpdbudget
    Inherits System.Web.UI.Page
    Public Actn As String = ""
    Public sCHnAME As String = ""

    Protected Sub Btn_Calcu_Click(sender As Object, e As EventArgs) Handles Btn_Calcu.Click
        Dim PermitedUsr As String = "" & Session.Item("UserName").ToString
        If PermitedUsr = "puehumanr" Then Exit Sub
        Dim EmpRole As String
        EmpRole = Session("Role")
        If (Txt_SchoolName.Text.Trim.ToString = "ALL" Or EmpRole = "Admin") Then
            Actn = "ALL"
            sCHnAME = ""
        Else
            Actn = "SEARCH"
            sCHnAME = Txt_SchoolName.Text.Trim.ToString()
        End If
        Call BoundData2Gridview(Actn, sCHnAME)
    End Sub
    Protected Sub BoundData2Gridview(ByVal actn As String, ByVal school_Name As String)
        Dim TotItems As Integer = 0
        Dim I As Integer = 0
        Dim SchShotName As String = ""
        Dim SchFname As String = ""
        Dim pdNeedYear As String = Session.Item("pdneedyr").ToString
        Dim GetUserdetails As careerDb = New careerDb()
        Dim Ds0 As DataSet = New DataSet()

        If actn = "ALL" Then
            Dim TResult01 As String = ""
            Dim Dt As DataTable = New DataTable
            Dt.Columns.Add("Sno.", GetType(String))
            Dt.Columns.Add("School Name", GetType(String))
            Dt.Columns.Add("PD Need Year", GetType(String))
            Dt.Columns.Add("Over All Budgeted Amount", GetType(String))
            Dt.Columns.Add(" ", GetType(String))
            Dt.Columns.Add("Allocated Amount For Local", GetType(String))
            Dt.Columns.Add("Local with Budgeted", GetType(String))
            Dt.Columns.Add("Local with Allocated", GetType(String))
            Dt.Columns.Add("Balance For Local", GetType(String))
            Dt.Columns.Add("  ", GetType(String))
            Dt.Columns.Add("Allocated Amount For Travel", GetType(String))
            Dt.Columns.Add("Travel with Budgeted", GetType(String))
            Dt.Columns.Add("Travel with Allocated", GetType(String))
            Dt.Columns.Add("Balance For Travel", GetType(String))

            Ds0 = GetUserdetails.GetSchoolname()
            Dim DV0 As New DataView(Ds0.Tables("schoolname"))
            TotItems = DV0.Table.Rows.Count
            For I = 0 To (TotItems - 1)
                SchShotName = DV0.Table.Rows(I)("code")
                SchFname = DV0.Table.Rows(I)("schoolname")
                TResult01 = GetUserdetails.GetPDBalanceBothLTsummary(SchShotName, TxtPdYr.Text.Trim)
                Dt.Rows.Add()
                Dt.Rows(I)("Sno.") = I
                Dt.Rows(I)("School Name") = SchShotName
                Dt.Rows(I)("PD Need Year") = TxtPdYr.Text.Trim
                Dt.Rows(I)("Over All Budgeted Amount") = GetUserdetails.OvallBudgeted.ToString()
                Dt.Rows(I)(" ") = ""
                Dt.Rows(I)("Allocated Amount For Local") = GetUserdetails.AllocatedLocAmt.ToString()
                Dt.Rows(I)("Local with Budgeted") = GetUserdetails.LocalBudgeted.ToString()
                Dt.Rows(I)("Local with Allocated") = GetUserdetails.LocalAllocated.ToString()
                If (SchShotName = "ABCD" Or SchShotName = "EFGH") Then
                    Dt.Rows(I)("Balance For Local") = GetUserdetails.Balance.ToString()
                Else
                    Dt.Rows(I)("Balance For Local") = GetUserdetails.LocalBal.ToString()
                End If
                Dt.Rows(I)("  ") = ""
                Dt.Rows(I)("Allocated Amount For Travel") = GetUserdetails.AllocatedTrvAmt.ToString()
                Dt.Rows(I)("Travel with Budgeted") = GetUserdetails.TravelBudgeted.ToString()
                Dt.Rows(I)("Travel with Allocated") = GetUserdetails.TravelAllocated.ToString()
                If (SchShotName = "ABCD" Or SchShotName = "EFGH") Then
                    Dt.Rows(I)("Balance For Travel") = GetUserdetails.Balance.ToString()
                Else
                    Dt.Rows(I)("Balance For Travel") = GetUserdetails.TrvBal.ToString()
                End If
            Next
            PD_GridView01.DataSource = Dt
            PD_GridView01.DataBind()
        Else

        End If

        Call Summary_Report(actn, school_Name)

        'Ds3 = GetUserdetails1.Get_BudgetMonitoringData(actn, school_Name)
        'Dim dV7 As New DataView(Ds3.Tables("bUDdATA4mONI"))
        'Gv_MoniBudget.DataSource = dV7
        'Gv_MoniBudget.DataBind()
        'dV7.Dispose()
        'Ds3.Dispose()

        'For Each dvRow In dv
        '    'DrpDwn = dvRow.Item("edistatus").ToString()
        '    'MsgBox1 = MessageBox.Show(DrpDwn)
        '    DDL_Text = dvRow.Item("edistatus").ToString()
        '    'DDL_Value = dvRow.Item("edistatus").ToString()
        '    DDL_Text = DDL_Text.Replace(vbCrLf, String.Empty)
        '    'DDL_Value = DDL_Value.Replace(vbCrLf, String.Empty)
        '    dvRow("edistatus") = DDL_Text
        '    dvRow.EndEdit()
        'Next

        'TotItems = dv.Table.Rows.Count
        'For Each dvRow In dv
        '    DrpDwn = dvRow.Item("edistatus").ToString()
        '    MsgBox1 = MessageBox.Show(DrpDwn)
        'Next

    End Sub

    Private Sub Gv_MoniBudget_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles Gv_MoniBudget.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim budgetted01 As Integer = 0
            Dim attended01 As Integer = 0
            Dim Balcamt As Integer = 0
            Dim lblTotal As Label
            budgetted01 = Convert.ToInt32(IIf(e.Row.Cells(3).Text = "", 0, e.Row.Cells(3).Text))
            attended01 = Convert.ToInt32(IIf(e.Row.Cells(4).Text = "", 0, e.Row.Cells(4).Text))
            Balcamt = Convert.ToInt32(IIf(e.Row.Cells(5).Text = "", 0, e.Row.Cells(5).Text))
            lblTotal = e.Row.Cells(6).FindControl("Label1")
            lblTotal.Text = Convert.ToString((budgetted01 + attended01 + Balcamt))
        End If
    End Sub

    Private Sub Gv_MoniBudget_Sorting(sender As Object, e As GridViewSortEventArgs) Handles Gv_MoniBudget.Sorting
        'Dim DaSt As DataSet = New DataSet
        'Dim Dv As DataView = New DataView
        'Dim GetBudgetData As careerDb = New careerDb
        'DaSt = GetBudgetData.Get_BudgetMonitoringData(Actn, sCHnAME, txtUser.Text.Trim.ToString())
        'Dv = DaSt.Tables("bUDdATA4mONI").DefaultView
        ''Dim dV7 As New DataView(DaSt.Tables("bUDdATA4mONI"))
        'If Not IsNothing(Dv) Then
        '    Dv.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
        '    'DtaView.Sort = e.SortExpression & " " & GetSortDirection(e.SortExpression)
        '    Gv_MoniBudget.DataSource = Dv
        '    Gv_MoniBudget.DataBind()
        'End If
    End Sub
    Private Function GetSortDirection(ByVal column As String) As String
        'Code added by Mohan on 12/4/2017
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

    Private Sub monitorpdbudget_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Username") = "" Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If

        If Not Page.IsPostBack Then
            Txt_SchoolName.Text = "" & Session.Item("school").ToString
            txtUser.Text = "" & Session.Item("Username").ToString

            TxtUsrN.Text = "" & Session.Item("UserName").ToString
            TxtSchN.Text = "" & Session.Item("school").ToString
            TxtRolE.Text = "" & Session.Item("Role").ToString
            TxtPdYr.Text = "" & Session.Item("pdneedyr").ToString

            'ViewState("username") = "" & Session.Item("UserName").ToString
            'ViewState("schname") = "" & Session.Item("school").ToString
            'ViewState("role") = "" & Session.Item("Role").ToString
            'ViewState("pdneedyr") = "" & Session.Item("pdneedyr").ToString

            'Monitoring PD Budget (School Year 2017-2018)
            Label2.Text = "Monitoring PD Budget (School Year " & TxtPdYr.Text & ")"
        End If
    End Sub
    Protected Sub Summary_Report(ByVal actn2 As String, ByVal school_NamE As String)
        Dim GetUserDetails As careerDb = New careerDb

        If actn2 = "ALL" Then
            lbl_SchName.Text = "ALL"

            'Find Total number of staff
            Dim TnoOfStaff As Integer = 0
            Dim Ds0 As DataSet = New DataSet
            Ds0 = GetUserDetails.GetToTnoFemp(actn2, school_NamE)
            Dim dV0 As DataView = New DataView(Ds0.Tables("TotNuOfEmp"))
            lbl_TotnoStaff.Text = "" & dV0.Table.Rows(0)("Expr1")
            TnoOfStaff = Convert.ToInt32(lbl_TotnoStaff.Text)
            dV0.Dispose()
            Ds0.Dispose()

            'Find Total number of staff with PD
            Dim TnoOfAllocated As Integer = 0
            Dim Ds2 As DataSet = New DataSet
            Ds2 = GetUserDetails.GetNoofPDStaff(actn2, school_NamE, TxtPdYr.Text)
            Dim dV2 As DataView = New DataView(Ds2.Tables("TotNuOfpdStaff"))
            lbl_nuofPDstaff.Text = "" & dV2.Table.Rows(0)("Expr1")
            TnoOfAllocated = Convert.ToInt32(lbl_nuofPDstaff.Text)
            dV2.Dispose()
            Ds2.Dispose()

            'Find without PD Staff
            Dim TnoOfBudgeted As Integer = 0
            Dim Ds1 As DataSet = New DataSet
            Ds1 = GetUserDetails.GetNoofnoPDStaff(actn2, school_NamE, TxtPdYr.Text)
            Dim dV1 As DataView = New DataView(Ds1.Tables("TotNuOfNopdStaff"))
            lbl_StaffnoPD.Text = "" & dV1.Table.Rows(0)("Expr1")
            TnoOfBudgeted = Convert.ToInt32(lbl_StaffnoPD.Text)
            dV1.Dispose()
            Ds1.Dispose()

            Dim NuOfStaffnoPD As Integer = 0
            NuOfStaffnoPD = (TnoOfStaff - (TnoOfAllocated + TnoOfBudgeted))
            Lbl_NoPDstaff.Text = NuOfStaffnoPD.ToString()

            'Find number of PD entries by category - All School
            Dim Ds4 As DataSet = New DataSet
            Ds4 = GetUserDetails.NuofPDentriesBycategory(actn2, school_NamE, TxtPdYr.Text)
            Dim dV4 As DataView = New DataView(Ds4.Tables("TotNuOfPDEntries"))
            GV_PDentries.DataSource = dV4
            GV_PDentries.DataBind()
            dV4.Dispose()
            dV4.Dispose()
        Else

        End If
    End Sub

    Private Sub monitorpdbudget_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("UserName") = TxtUsrN.Text.Trim.ToString()
        Session("school") = TxtSchN.Text.Trim.ToString()
        Session("Role") = TxtRolE.Text.Trim.ToString()
        Session("pdneedyr") = TxtPdYr.Text.Trim.ToString()

        'Session("UserName") = ViewState("username").ToString()
        'Session("school") = ViewState("schname").ToString()
        'Session("Role") = ViewState("role").ToString()
        'Session("pdneedyr") = ViewState("pdneedyr").ToString()
    End Sub
End Class
