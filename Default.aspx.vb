Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub txtLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles txtLogin.Authenticate
        Dim UserName As String = txtLogin.UserName()
        Dim Password As String = txtLogin.Password.ToString()
        Dim GetUserdetails As careerDb = New careerDb()
        Dim Result As String
        Dim Tschname As String = ""
        Dim Ds As DataSet = New DataSet

        'Result = GetUserdetails.CheckUser(UserName, Password)
        Result = GetUserdetails.checkROuser(UserName, Password)
        If Result <> "" Then
            Session("UserName") = UserName
            Session("school") = Result
            Session("Role") = GetUserdetails.URole

            Dim PDNeedYear As String
            Dim Ds0 As DataSet = New DataSet()
            Ds0 = GetUserdetails.GetQFSchoolYear()
            Dim dv0 As New DataView(Ds0.Tables("qfSchY"))
            If dv0.Table.Rows.Count <> 0 Then
                PDNeedYear = dv0.Table.Rows(0)("schoolyear")
                'PDNeedYear = "2017-2018"
                Session("pdneedyr") = PDNeedYear
            Else
                'Response.Write("Please set default PD Need Year to start.")
                'Response.End()

                'Dim VofMoMsgBx As Integer = TopMostMessageBox.Show("Not Found PD Year.", "Message Window!", MessageBoxButtons.OK)
                ''Response.Redirect("schoolyear.aspx")
                ''insert into qfschoolyear(schoolyear,curschyear) values('2017-2018','Yes')

                If (Session.Item("Role").ToString <> "Admin") Then
                    Response.Write("Please set default PD Need Year to start.")
                    Response.End()

                    Response.Redirect("Default.aspx", True)
                    Exit Sub
                End If

            End If
            Ds0.Dispose()
            dv0.Dispose()

            'Get School full name
            If Result = "ALL" Then
                Tschname = "ALL"
            Else
                Ds = GetUserdetails.GetFullSchoolname(Result)
                Dim dv As New DataView(Ds.Tables("schoolname01"))
                'SchShotName = dv.Table.Rows("code")
                Tschname = dv.Table.Rows(0)("schoolname")
                dv.Dispose()
                Ds.Dispose()
            End If
            Session("SchFullName") = Tschname

            'Call GetUserdetails.GetBudgetData(Result)
            'Dim Test1 As String = ""
            'Dim Test2 As String = ""
            'Dim Test3 As Integer = 0
            'Dim Test4 As Integer = 0
            'Test1 = GetUserdetails.SchName
            'Test2 = GetUserdetails.PdYear
            'Test3 = GetUserdetails.TrvTotAmt
            'Test4 = GetUserdetails.LocTotAmt

            'If ((Session.Item("Role")) = "Admin" Or (Session.Item("school")) = "ALL") Then
            If (Session.Item("Role").ToString = "Admin" Or Session.Item("school").ToString = "ALL") Then
                Response.Redirect("pdplanview.aspx", True)
            Else
                Response.Redirect("pdplanviewEUS.aspx", True)
            End If

        Else
            GetUserdetails.User = ""
            GetUserdetails.School = ""
            Session("pdneedyr") = ""
            Response.Write("Incorrect Username or Password. Please try again.")
            Response.End()
            'Dim VofMoMsgBx As Integer = TopMostMessageBox.Show("Incorrect Username or Password.", "Message Window!", MessageBoxButtons.OK)
            'Response.Redirect("Default.aspx", True)
        End If
        'response.Redirect 
    End Sub

    Private Sub _Default_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        ' You can handle any errors that occur outside of your structured
        ' error handling here.  This Sub is automatically called in the
        ' event of an unhandled run-time error.

        Dim strErrorMessage As String
        strErrorMessage = Request.Url.ToString() & vbCrLf _
         & "<pre>" & Server.GetLastError().ToString() & "</pre>"
        Response.Write(strErrorMessage)
        Server.ClearError()
        Response.Write("<p>Click <a href=""Default.aspx"">here</a> to go back to the original page.</p>")

    End Sub

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session.Clear()
        'Session.Contents.RemoveAll()
        'Session.Abandon()

        'HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'HttpContext.Current.Response.Cache.SetNoServerCaching()
        'HttpContext.Current.Response.Cache.SetNoStore()

        Chk_Session_State()

    End Sub
    'Private Sub GetBudgetData()
    '    'txt_SchoolName.Text = "" & Session.Item("school").ToString
    '    Dim GetUserdetails As careerDb = New careerDb()
    '    Dim Ds As DataSet = New DataSet()
    '    Ds = GetUserdetails.GetBudgetAmt(Session("school"))
    '    Dim dv As New DataView(Ds.Tables("budgetAmt"))
    '    GetUserdetails.SchName = "" & dv.Table.Rows(0)("schoolname")
    '    GetUserdetails.PdYear = "" & dv.Table.Rows(0)("pdyear")
    '    GetUserdetails.TrvTotAmt = "" & dv.Table.Rows(0)("travelamt")
    '    GetUserdetails.LocTotAmt = "" & dv.Table.Rows(0)("localamt")
    '    dv.Dispose()
    '    Ds.Clear()
    'End Sub
    Protected Sub Chk_Session_State()
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        If Page.IsPostBack Then
            If isPageExpired() Then
                Response.Redirect("Default.aspx")
            Else
                Session("TimeStamp") = Now.ToString
                ViewState("TimeStamp") = Now.ToString
            End If
        End If
        '...........
        'your own function here
    End Sub

    Private Function isPageExpired() As [Boolean]
        If Session("TimeStamp") Is Nothing OrElse ViewState("TimeStamp") Is Nothing Then
            Return False
        ElseIf Session("TimeStamp") = ViewState("TimeStamp") Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
