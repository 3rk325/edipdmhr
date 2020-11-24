Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Default2
    Inherits System.Web.UI.Page
    Dim permitedusr As String = ""

    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGet.Click
        Try
            'Response.Redirect("LoginAmd.aspx")
            If Session("UserName") = "" Then
                Response.Redirect("default.aspx")
            Else
                permitedusr = Session.Item("UserName").ToString
                If (permitedusr = "mehdi" Or permitedusr = "dana") Then
                    Response.Redirect("usercredentials.aspx")
                Else
                    Response.Redirect("pwdchange.aspx")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "" Then
                Response.Redirect("default.aspx")
            End If
            If Not Me.IsPostBack Then
                'BtnGet.Visible = True
                'permitedusr = Session.Item("UserName").ToString
                'If (permitedusr = "mehdi" Or permitedusr = "mohan") Then
                '    BtnGet.Visible = True
                'Else
                '    BtnGet.Visible = False
                'End If

                'Dim RestrictUsr As String = ""
                'RestrictUsr = Session.Item("UserName").ToString
                ''Session.Item("UserName").ToString = "puefinance" Or Session.Item("UserName").ToString = "puehumanr"
                'If (RestrictUsr = "puefinance" Or RestrictUsr = "puehumanr") Then
                '    BtnGet.Visible = False
                '    BtnCourseList.Visible = False
                '    Btn_WRpt.Visible = False
                '    Btn_EmpHistory.Visible = False
                '    Btn_StatiscalRpt.Visible = False
                '    Btn_MicroRpt.Visible = False
                '    Lbl_NoData.Visible = True
                'End If
            End If

        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub
    Protected Sub BtnCourseList_Click(sender As Object, e As EventArgs) Handles BtnCourseList.Click
        Try
            Response.Redirect("CourseAmd.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Btn_WRpt_Click(sender As Object, e As EventArgs) Handles Btn_WRpt.Click
        Try
            Response.Redirect("weeklyrpt01.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Btn_EmpHistory_Click(sender As Object, e As EventArgs) Handles Btn_EmpHistory.Click
        Try
            Response.Redirect("pdhistory.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Btn_StatiscalRpt_Click(sender As Object, e As EventArgs) Handles Btn_StatiscalRpt.Click
        Try
            Response.Redirect("StatisticalRptForm.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Response.Redirect("testing.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Btn_MicroRpt_Click(sender As Object, e As EventArgs) Handles Btn_MicroRpt.Click
        Try
            Response.Redirect("PDMicroanalysisrpt.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
