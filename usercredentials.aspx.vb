Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class usercredentials
    Inherits System.Web.UI.Page
    Public Rst As String = ""

    Private Sub usercredentials_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("default.aspx")
        End If
        If Not Page.IsPostBack Then
            Try
                lblMsg.Text = ""

                Dim GetUserdetails1 As careerDb = New careerDb()
                Dim Ds1 As DataSet = New DataSet()
                Ds1 = GetUserdetails1.GetSchoolname()
                Dim dv1 As New DataView(Ds1.Tables("schoolname"))
                drp_Org.DataSource = dv1
                drp_Org.DataTextField = "schoolname"
                drp_Org.DataValueField = "code"
                drp_Org.DataBind()
                drp_Org.SelectedIndex = 1
                drp_Org.Items.Insert(0, "ALL")

                'Dim Ds2 As DataSet = New DataSet()
                'Ds2 = GetUserdetails1.Getallusers()
                'Dim dv2 As New DataView(Ds2.Tables("users"))
                'drp_User.DataSource = dv2
                'drp_User.DataTextField = "email"
                'drp_User.DataValueField = "email"
                'drp_User.DataBind()

                BindUserNames()
            Catch ex As Exception
                lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Red
                lblMsg.BackColor = System.Drawing.Color.Yellow
                'Response.Write("An error has occurred in Page_Load() Module : " & ex.ToString())
            End Try
        End If
    End Sub

    Private Sub BindUserNames()
        Try
            Dim Status As String = ""
            Dim GetUserName As careerDb = New careerDb
            Dim Ds As DataSet = New DataSet
            Ds = GetUserName.LoginRoSAMD4GridV("ALL", Txt_id.Text.Trim.ToString, txtUsrName.Text.Trim.ToString, txtPwd.Text.Trim.ToString, Status, drp_Role.SelectedValue.Trim.ToString, drp_Org.SelectedValue.Trim.ToString)
            Dim Dv As DataView = New DataView(Ds.Tables("LoginList4ro"))
            GV_UsrCred.DataSource = Dv
            GV_UsrCred.DataBind()
            Dv.Dispose()
            Ds.Dispose()
        Catch ex As Exception
            lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblMsg.Font.Bold = True
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in BindCourseData() Module : " & ex.ToString())
        End Try
    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            If txtUsrName.Text.ToString.Trim() = "" Then Exit Sub
            'If txtUsrName.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Username.</font></b></p>" : Exit Sub
            If txtPwd.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Password.</font></b></p>" : Exit Sub
            'If (Find_Dup_Rec(txtUsrName.Text.ToString.Trim) > 0) Then lblMsg.Text = "<p><b><font color='#FF0000'>Duplicate record found.</font></b></p>" : Exit Sub

            'Dim RecUpdateStatus As Integer = 0
            'Dim IsAdded As Boolean = False
            'Dim UsrName As String = txtUsrName.Text.Trim()
            'Dim Pwd As String = txtPwd.Text.Trim()
            'Dim Role As String = "" & drp_Role.Text.Trim()
            'Dim Orga As String = drp_Org.Text

            Dim Status As String = "Yes"
            If (RBstus2.Checked = True) Then Status = "No"
            Dim GetUserName As careerDb = New careerDb
            Rst = GetUserName.LoginSAMD4ro("Insert", Txt_id.Text.ToString.Trim, txtUsrName.Text.Trim.ToString, txtPwd.Text.Trim.ToString, Status, drp_Role.SelectedValue.Trim.ToString, drp_Org.SelectedValue.Trim.ToString)
            If Trim(Rst) = "0" Then
                lblMsg.Text = "User Name Saved."
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Green
                lblMsg.BackColor = System.Drawing.Color.Yellow
                ResetAll()
                BindUserNames()
                Exit Sub
            Else
                'lblMsg.Text = "Error :" & " ** " & Rst
                lblMsg.Text = "Duplicate record found."
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Red
                lblMsg.BackColor = System.Drawing.Color.Yellow
            End If
        Catch ex As NullReferenceException
            Response.Write("<p>NullReferenceException error occured.</p>")
            Response.Write("<pre>" & ex.ToString() & "</pre>")
        Catch ex As HttpException
            Response.Write("<p>HttpException error occured.</p>")
            Response.Write("<pre>" & ex.ToString() & "</pre>")
        Catch ex As Exception When 1 = 1
            Response.Write("<p> Error occured.</p>")
            Response.Write("<pre>" & ex.ToString() & "</pre>")
            Response.Write("<pre>" & Err.Number.ToString() & " *** " & Err.Description.ToString() & "</pre>")
            lblMsg.Text = "<b><font color='#FF0000'>Please Check the Error Message..........</font></b>"
        End Try
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtUsrName.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Username.</font></b></p>" : Exit Sub
            If txtPwd.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Password.</font></b></p>" : Exit Sub
            'If Find_Dup_Rec(txtUsrName.Text.ToString.Trim) > 0 Then lblMsg.Text = "<p><b><font color='#FF0000'>Record not found. Please check.</font></b></p>" : Exit Sub

            'If String.IsNullOrEmpty(txtUsrName.Text) Then
            '    lblMsg.Text = "ID not found, Please select next record to update."
            '    lblMsg.Font.Bold = True
            '    lblMsg.ForeColor = System.Drawing.Color.Red
            '    lblMsg.BackColor = System.Drawing.Color.Yellow
            '    Return
            'End If

            Dim Status As String = "Yes"
            If (RBstus2.Checked = True) Then Status = "No"
            Dim GetUserName As careerDb = New careerDb
            Rst = GetUserName.LoginSAMD4ro("Update", Txt_id.Text.ToString.Trim, txtUsrName.Text.Trim.ToString, txtPwd.Text.Trim.ToString, Status, drp_Role.SelectedValue.Trim.ToString, drp_Org.SelectedValue.Trim.ToString)
            If Trim(Rst) = "0" Then
                lblMsg.Text = "User Name Updated."
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Green
                lblMsg.BackColor = System.Drawing.Color.Yellow
                BindUserNames()
            Else
                lblMsg.Text = "Error :" & " ** " & Rst
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Red
                lblMsg.BackColor = System.Drawing.Color.Yellow
            End If
        Catch ex As Exception
            lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblMsg.Font.Bold = True
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in btnUpdate_Click() Module : " & ex.ToString())
        End Try
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtUsrName.Text.ToString.Trim() = "" Then Exit Sub
            'If txtUsrName.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Username.</font></b></p>" : Exit Sub
            'If txtPwd.Text.ToString.Trim() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>Enter Password.</font></b></p>" : Exit Sub
            'If Find_Dup_Rec(txtUsrName.Text.ToString.Trim) > 0 Then lblMsg.Text = "<p><b><font color='#FF0000'>Record not found. Please check.</font></b></p>" : Exit Sub
            'If String.IsNullOrEmpty(txtUsrName.Text) Then
            '    lblMsg.Text = "ID not found, Please select next record to delete."
            '    lblMsg.Font.Bold = True
            '    lblMsg.ForeColor = System.Drawing.Color.Red
            '    lblMsg.BackColor = System.Drawing.Color.Yellow
            '    Return
            'End If

            Dim Status As String = "Yes"
            If (RBstus2.Checked = True) Then Status = "No"
            Dim GetUserName As careerDb = New careerDb
            Rst = GetUserName.LoginSAMD4ro("Delete", Txt_id.Text.ToString.Trim, txtUsrName.Text.Trim.ToString, txtPwd.Text.Trim.ToString, Status, drp_Role.SelectedValue.Trim.ToString, drp_Org.SelectedValue.Trim.ToString)
            If Trim(Rst) = "0" Then
                lblMsg.Text = "User Name Deleted."
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Green
                lblMsg.BackColor = System.Drawing.Color.Yellow
                BindUserNames()
                ResetAll()
                Exit Sub
            Else
                lblMsg.Text = "Error :" & " ** " & Rst
                lblMsg.Font.Bold = True
                lblMsg.ForeColor = System.Drawing.Color.Red
                lblMsg.BackColor = System.Drawing.Color.Yellow
            End If
        Catch ex As Exception
            lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblMsg.Font.Bold = True
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in btnUpdate_Click() Module : " & ex.ToString())
        End Try
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            lblMsg.Text = ""
            ResetAll()
        Catch ex As Exception
            lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblMsg.Font.Bold = True
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in btnCancel_Click() Module : " & ex.ToString())
        End Try
    End Sub

    Private Sub ResetAll()
        Try
            Txt_id.Text = ""
            btnInsert.Visible = True
            txtUsrName.Text = ""
            txtPwd.Text = ""
            drp_Role.SelectedIndex = 0
            drp_Org.SelectedIndex = 0
            RBstus1.Checked = False
            RBstus2.Checked = False
            txtUsrName.ReadOnly = False
            txtUsrName.Enabled = True
        Catch ex As Exception
            lblMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblMsg.Font.Bold = True
            lblMsg.ForeColor = System.Drawing.Color.Red
            lblMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in ResetAll() Module : " & ex.ToString())
        End Try
    End Sub
    Function Find_Dup_Rec(ByVal Ccode As String) As Integer
        Try
            Find_Dup_Rec = 0
            If Ccode.Trim = "" Then Exit Function
            If String.IsNullOrEmpty(Ccode.Trim) Then
                lblMsg.Text = "No Course Code found."
                lblMsg.ForeColor = System.Drawing.Color.Red
                Exit Function
            End If
            Dim Status As String = "Yes"
            If (RBstus2.Checked = True) Then Status = "No"
            Dim GetUserName As careerDb = New careerDb
            Rst = GetUserName.LoginSAMD4ro("Select", Txt_id.Text.ToString.Trim, txtUsrName.Text.Trim.ToString, txtPwd.Text.Trim.ToString, Status, drp_Role.SelectedValue.Trim.ToString, drp_Org.SelectedValue.Trim.ToString)
            Find_Dup_Rec = Convert.ToInt32(Rst)
        Catch ex As Exception
            lblMsg.Text = Rst & " ** " & "An error has occurred in Find_Dup_Rec() Module : " & ex.ToString()
            lblMsg.ForeColor = System.Drawing.Color.Red
            'Response.Write("An error has occurred in Find_Dup_Rec() Module : " & ex.ToString())
        End Try
        Return Find_Dup_Rec
    End Function

    Protected Sub GV_UsrCred_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GV_UsrCred.SelectedIndexChanged
        Dim TkeyValue As String = GV_UsrCred.DataKeys(GV_UsrCred.SelectedRow.RowIndex).Value.ToString()
        If TkeyValue.Trim.ToString() = "" Then lblMsg.Text = "<p><b><font color='#FF0000'>No key data.</font></b></p>" : Exit Sub
        lblMsg.Text = ""
        Txt_id.Text = TkeyValue.Trim.ToString

        'Dim Tid As String = GV_UsrCred.SelectedRow.Cells(1).Text.ToString.Trim
        'Txt_id.Text = Tid
        'Dim TUsrName As String = GV_UsrCred.SelectedRow.Cells(2).Text.ToString.Trim
        'Dim TPwd As String = GV_UsrCred.SelectedRow.Cells(3).Text.ToString.Trim
        'Dim TRole As String = GV_UsrCred.SelectedRow.Cells(4).Text.ToString.Trim
        'Dim TOrg As String = GV_UsrCred.SelectedRow.Cells(5).Text.ToString.Trim
        'Dim TStatus As String = GV_UsrCred.SelectedRow.Cells(6).Text.ToString.Trim

        Dim GetDetails As careerDb = New careerDb
        Dim Ds As DataSet = New DataSet
        Ds = GetDetails.GetUsrCredRec(TkeyValue)
        Dim dV As New DataView(Ds.Tables("UsrCredRec"))
        'Txt_id.Text = dV.Table.Rows(0)("id").ToString
        txtUsrName.Text = dV.Table.Rows(0)("email").ToString
        txtPwd.Text = dV.Table.Rows(0)("password").ToString
        drp_Role.SelectedIndex = drp_Role.Items.IndexOf(drp_Role.Items.FindByValue(dV.Table.Rows(0)("role")))
        drp_Org.SelectedIndex = drp_Org.Items.IndexOf(drp_Org.Items.FindByValue(dV.Table.Rows(0)("organization")))
        Dim Tstatus02 As String = ""
        Tstatus02 = dV.Table.Rows(0)("status").ToString
        If Tstatus02 = "Yes" Then
            RBstus1.Checked = True
        Else
            RBstus2.Checked = True
        End If

        'make invisible Insert button during update/delete
        btnInsert.Visible = False
        'txtUsrName.ReadOnly = True
        'txtUsrName.Enabled = False

        'Changing background color
        For Each row As GridViewRow In GV_UsrCred.Rows
            If row.RowIndex = GV_UsrCred.SelectedIndex Then
                row.BackColor = System.Drawing.Color.Yellow
            Else
                row.BackColor = System.Drawing.Color.White
            End If
        Next
    End Sub
End Class
