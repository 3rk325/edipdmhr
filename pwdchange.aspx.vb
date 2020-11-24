Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Partial Class pwdchange
    Inherits System.Web.UI.Page
    Public Rst As String = ""

    Protected Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Try
            If Txt_UsrName.Text.ToString.Trim() = "" Then lblErMsg.Text = "<p><b><font color='#FF0000'>Enter Username.</font></b></p>" : Exit Sub
            If Txt_Pwd.Text.ToString.Trim() = "" Then lblErMsg.Text = "<p><b><font color='#FF0000'>Enter Password.</font></b></p>" : Exit Sub

            Dim GetUserName As careerDb = New careerDb
            Rst = GetUserName.LoginSAMD4ro("PwdRst", "", Txt_UsrName.Text.Trim.ToString, Txt_Pwd.Text.Trim.ToString, "", "", "")

            If Trim(Rst) = "0" Then
                lblErMsg.Text = "Password modified."
                lblErMsg.Font.Bold = True
                lblErMsg.ForeColor = System.Drawing.Color.Green
                lblErMsg.BackColor = System.Drawing.Color.Yellow
            Else
                lblErMsg.Text = "Error :" & " ** " & Rst
                lblErMsg.Font.Bold = True
                lblErMsg.ForeColor = System.Drawing.Color.Red
                lblErMsg.BackColor = System.Drawing.Color.Yellow
            End If
        Catch ex As Exception
            lblErMsg.Text = "An error has occurred in Page_Load() Module : " & ex.ToString()
            lblErMsg.Font.Bold = True
            lblErMsg.ForeColor = System.Drawing.Color.Red
            lblErMsg.BackColor = System.Drawing.Color.Yellow
            'Response.Write("An error has occurred in btnUpdate_Click() Module : " & ex.ToString())
        End Try
    End Sub

    Private Sub pwdchange_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("default.aspx")
        End If
        If Not Page.IsPostBack Then
            'Txt_Id.Text = "" & Session.Item("Username").ToString
            Txt_UsrName.Text = "" & Session.Item("Username").ToString
            'Txt_Pwd.Text = "" & Session.Item("Username").ToString
        End If

    End Sub
End Class
