Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Globalization

Public Class careerDb
    Public User As String
    Public School As String
    Public URole As String
    Public RefNo As Integer = 0
    Public SchName As String = ""
    Public PdYear As String = ""
    Public TrvTotAmt As Decimal = 0
    Public LocTotAmt As Decimal = 0
    Public MsgStus As String = ""
    Public ErrNo As String = "0"
    Public ErrDetails As String = ""
    Public TravelBudgeted As Decimal = 0
    Public TravelAllocated As Decimal = 0
    Public LocalBudgeted As Decimal = 0
    Public LocalAllocated As Decimal = 0
    Public Balance As Decimal = 0
    Public OvallBudgeted As Decimal = 0
    Public AllocatedLocAmt As Decimal = 0
    Public AllocatedTrvAmt As Decimal = 0
    Public LocalBal As Decimal = 0
    Public TrvBal As Decimal = 0
    'Public Cntr As Integer = 0

    Public Function GetUserinfo(ByVal qatarid As String, ByVal txtfirstname As String, ByVal txtdob As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("selectcandetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim canid As SqlParameter = New SqlParameter("@qatar_id", qatarid)
        sda.SelectCommand.Parameters.Add(canid)

        Dim canfirstname As SqlParameter = New SqlParameter("@txt_firstname", txtfirstname)
        sda.SelectCommand.Parameters.Add(canfirstname)

        Dim candob As SqlParameter = New SqlParameter("@txt_dob", txtdob)
        sda.SelectCommand.Parameters.Add(candob)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "uservalue")
        Return ds
    End Function

    Public Function GetLogindetails() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getlogindetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "uservalue")
        Return ds
    End Function

    Public Function GetQFSchoolYear() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetQFSchoolYear", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "qfSchY")
        Return ds
    End Function

    Public Function GetDeptStatus(ByVal param As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getdeptstatus", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParam As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParam)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "deptstatus")
        Return ds
    End Function
    Public Function GetSemesterData() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSemesterData", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SemData")
        Return ds
    End Function

    Public Function GetPDType() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPDType", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdType")
        Return ds
    End Function

    Public Function GetEmpInfo(ByVal sHoolname As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetEmpInfo", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", sHoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "EmpInfo4CD")
        Return ds
    End Function

    Public Function GetCoursecategory(ByVal Param As String, ByVal pdCatry As String) As DataSet
        'ByVal type As String,
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getcoursecategory", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        'Dim txtpdtype As SqlParameter = New SqlParameter("@type", Type)
        'sda.SelectCommand.Parameters.Add(txtpdtype)

        Dim txtpdCategory As SqlParameter = New SqlParameter("@category", pdCatry)
        sda.SelectCommand.Parameters.Add(txtpdCategory)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "cCode")
        Return ds
    End Function

    Public Function Getpddetails(ByVal Schoolname As String, ByVal email As String, ByVal edistatus As String, ByVal lastname As String, ByVal dePartMent As String, ByVal coUrSecode As String, ByVal TempNo As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpddetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtEdistatus As SqlParameter = New SqlParameter("@edistatus", edistatus)
        sda.SelectCommand.Parameters.Add(txtEdistatus)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "uservalue")
        Return ds
    End Function

    Public Function Getpdplandetails(ByVal Schoolname As String, ByVal email As String, ByVal edistatus As String, ByVal lastname As String, ByVal dePartMent As String, ByVal coUrSecode As String, ByVal TempNo As String) As DataSet
        'This for old pdms
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtEdistatus As SqlParameter = New SqlParameter("@edistatus", edistatus)
        sda.SelectCommand.Parameters.Add(txtEdistatus)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        'Dim Qry As String = ""
        'Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and edistatus like " & edistatus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by Lastupdatedon"
        'Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and edistatus like " & edistatus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by pdid"

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanView")
        Return ds
    End Function

    Public Function Getpdplandetails4AdminExport(ByVal Schoolname As String, ByVal email As String, ByVal deptstus As String, ByVal lastname As String, ByVal dePartMent As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal Tpdtype As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails4AdminExport", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtDeptstus As SqlParameter = New SqlParameter("@deptstus", deptstus)
        sda.SelectCommand.Parameters.Add(txtDeptstus)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        Dim txtTpdtype As SqlParameter = New SqlParameter("@reqtype", Tpdtype)
        sda.SelectCommand.Parameters.Add(txtTpdtype)

        Dim Qry As String = ""
        Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and deptstus like " & deptstus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by Lastupdatedon"
        'Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and edistatus like " & edistatus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by pdid"

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanAdminView4Export")
        Return ds
    End Function

    Public Function Getpdplandetails4EUSExport(ByVal Schoolname As String, ByVal email As String, ByVal deptstus As String, ByVal lastname As String, ByVal dePartMent As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal pDtype As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails4EUSExport", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtDeptstus As SqlParameter = New SqlParameter("@deptstus", deptstus)
        sda.SelectCommand.Parameters.Add(txtDeptstus)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        Dim txtpDtype As SqlParameter = New SqlParameter("@reqtype", pDtype)
        sda.SelectCommand.Parameters.Add(txtpDtype)

        'Dim Qry As String = ""
        'Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and deptstus like " & deptstus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by Lastupdatedon"
        ''Qry = "select pdid,empno,schoolname,firstname,lastname,position,department,edistatus,email,pdcategory,pdcoursecode,Description,totalcost from pdplantbl_view where empno Like " & TempNo & "% and schoolname like " & Schoolname & "% and email like " & email & "% and edistatus like " & edistatus & "% and lastname like " & lastname & "% and department like " & dePartMent & "% order by pdid"

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanViewEUSexport")
        Return ds
    End Function

    Public Function ViewPDProvisions(ByVal Schoolname As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdprovision", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "vprovision")
        Return ds
    End Function
    Public Function ViewPDProvisions02(ByVal ReqType As String, ByVal Schoolname As String, ByVal pdYr As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdprovisionPTandPL", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtReqType As SqlParameter = New SqlParameter("@reqtype", ReqType)
        sda.SelectCommand.Parameters.Add(txtReqType)

        Dim txtpdYr As SqlParameter = New SqlParameter("@pdyr", pdYr)
        sda.SelectCommand.Parameters.Add(txtpdYr)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "PDprovisionPTpl")
        Return ds
    End Function
    Public Function getempdetails(ByVal Schoolname As String, ByVal empno As String, ByVal email As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getempdetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtempno As SqlParameter = New SqlParameter("@empno", empno)
        sda.SelectCommand.Parameters.Add(txtempno)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "empdetails")
        Return ds
    End Function
    Public Function getempdetailsadmin(ByVal empno2 As String, ByVal email2 As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getempdetailsadmin", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtempno2 As SqlParameter = New SqlParameter("@empno", empno2)
        sda.SelectCommand.Parameters.Add(txtempno2)

        Dim txtEmail2 As SqlParameter = New SqlParameter("@email", email2)
        sda.SelectCommand.Parameters.Add(txtEmail2)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "empdetails02")
        Return ds

    End Function
    Public Function getschoolemp(ByVal Schoolname As String, ByVal empno As String, ByVal email As String, ByVal lastname As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getschoolemp", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtempno As SqlParameter = New SqlParameter("@empno", empno)
        sda.SelectCommand.Parameters.Add(txtempno)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "empdetails")
        Return ds
    End Function

    Public Function Coursedetails(ByVal Coursecode As String, ByVal CourseDesc As String, ByVal category As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("coursedetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtCoursecode As SqlParameter = New SqlParameter("@Coursecode", Coursecode)
        sda.SelectCommand.Parameters.Add(txtCoursecode)

        Dim txtCourseDesc As SqlParameter = New SqlParameter("@CourseDesc", CourseDesc)
        sda.SelectCommand.Parameters.Add(txtCourseDesc)

        Dim txtCategory As SqlParameter = New SqlParameter("@Category", category)
        sda.SelectCommand.Parameters.Add(txtCategory)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "empdetails")
        Return ds
    End Function
    Public Function getpdhistory(ByVal email As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getpdhistory", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdhistory")
        Return ds
    End Function
    Public Function getFAQ() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getfaq", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "faq")
        Return ds
    End Function
    Public Function getpdneedhistory(ByVal email As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getpdneedhistory", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdhistory")
        Return ds
    End Function
    Public Function getpdneedhistory02(ByVal empno As String, ByVal param As String, ByVal email As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("getpdneedhistory02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim txtEmpno As SqlParameter = New SqlParameter("@empno", empno)
        sda.SelectCommand.Parameters.Add(txtEmpno)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdhistory")

        'If param = "pdplantbl" Then
        '    Dim ds As DataSet = New DataSet()
        '    sda.Fill(ds, "pdhistory")
        '    Return ds
        'Else
        '    Dim ds As DataSet = New DataSet()
        '    sda.Fill(ds, "pdhistory02")
        '    Return ds
        'End If
        Return ds
    End Function

    Public Function Getpddetailbypdid(ByVal pdid As Long) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpddetailbypdid", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "uservalue")
        Return ds
    End Function

    Public Function Getpddetailbypdid02(ByVal pdid As Long) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpddetailbypdid02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanViewEdit")
        Return ds
    End Function

    Public Function GetEmpInfo02(ByVal eMpNu As Long) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetEmpInfo02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@empno", eMpNu)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "GetEmprec")
        Return ds
    End Function

    Public Function GetPDPlanTblDetails(ByVal PdId As Integer) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPDPlanTblDetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", PdId)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "GetEmprec4PrvT")
        Return ds
    End Function

    Public Function DeletePDbyid(ByVal pdid As Long) As String
        Dim sda As SqlDataAdapter = New SqlDataAdapter("deletepdbyid", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "Delete")
        Return "Delete"
    End Function

    Public Function DeletePDbyid02(ByVal pdid As Long) As String

        Dim sda As SqlDataAdapter = New SqlDataAdapter("deletepdbyid02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "Delete02")
        Return "Delete"
    End Function

    Public Function UpdatePDinfobyDept(ByVal pdid As Long, ByVal deptstatus As String, ByVal requestorcomments As String, ByVal lastupdatedby As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdatePDinfobyDept", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim txtdeptstatus As SqlParameter = New SqlParameter("@deptstatus", deptstatus)
        sda.SelectCommand.Parameters.Add(txtdeptstatus)

        Dim txtrequestorcomments As SqlParameter = New SqlParameter("@requestorcomments", requestorcomments)
        sda.SelectCommand.Parameters.Add(txtrequestorcomments)

        Dim txtlastupdatedby As SqlParameter = New SqlParameter("@lastupdatedby", lastupdatedby)
        sda.SelectCommand.Parameters.Add(txtlastupdatedby)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "uservalue")
        Return ds
    End Function
    Public Function UpdatePDinfobyDept02(ByVal pdid As Long, ByVal deptstatus As String, ByVal deptcomns As String, ByVal lastupdatedby As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdatePDinfobyDept02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim txtdeptstatus As SqlParameter = New SqlParameter("@deptstus", deptstatus)
        sda.SelectCommand.Parameters.Add(txtdeptstatus)

        Dim txtdeptcomns As SqlParameter = New SqlParameter("@deptcomns", deptcomns)
        sda.SelectCommand.Parameters.Add(txtdeptcomns)

        Dim txtlastupdatedby As SqlParameter = New SqlParameter("@lastupdatedby", lastupdatedby)
        sda.SelectCommand.Parameters.Add(txtlastupdatedby)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanviewEdit")
        Return ds
    End Function

    Public Function UpdEmpNo2PDPlanTbl(ByVal pdid As Long, ByVal EmpNumber As String) As DataSet
        'ByVal deptstatus As String, ByVal deptcomns As String, ByVal lastupdatedby As String

        Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdEmpNo2PDPlanTbl", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtpdid)

        Dim txtEmpNu As SqlParameter = New SqlParameter("@empno", EmpNumber)
        sda.SelectCommand.Parameters.Add(txtEmpNu)

        'Dim txtdeptcomns As SqlParameter = New SqlParameter("@deptcomns", deptcomns)
        'sda.SelectCommand.Parameters.Add(txtdeptcomns)

        'Dim txtlastupdatedby As SqlParameter = New SqlParameter("@lastupdatedby", lastupdatedby)
        'sda.SelectCommand.Parameters.Add(txtlastupdatedby)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "upDatingEmpNo")
        Return ds
    End Function

    Public Function GetSchoolname() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchoolname", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "schoolname")
        Return ds
    End Function

    Public Function GetFullSchoolname(ByVal Code As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetFullSchoolname", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtCode As SqlParameter = New SqlParameter("@code", Code)
        sda.SelectCommand.Parameters.Add(txtCode)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "schoolname01")
        Return ds
    End Function

    Public Function GetChidsDetails(ByVal TblLink As String) As DataSet
        'ByVal pDId As Integer,
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetChidsDetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        'Dim txtpDId As SqlParameter = New SqlParameter("@pdid", pDId)
        'sda.SelectCommand.Parameters.Add(txtpDId)

        Dim txtTblLink As SqlParameter = New SqlParameter("@tbllink", TblLink)
        sda.SelectCommand.Parameters.Add(txtTblLink)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "ChildDetails01")
        Return ds
    End Function

    Public Function GetpdmsCountries() As DataSet
        'Function created by Mohan on 15/4/2017
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdms_countries", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "CountriesList")
        Return ds
    End Function

    Public Function CancellationDetails(ByVal pdid As String, ByVal Stus As String, ByVal lastupdatedby As String) As Boolean
        Dim ReCsTus As Boolean = False
        Try

            Dim sda As SqlDataAdapter = New SqlDataAdapter("SPCancellationDetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pdid)
            sda.SelectCommand.Parameters.Add(txtpdid)

            Dim txtedistatus As SqlParameter = New SqlParameter("@status", Stus)
            sda.SelectCommand.Parameters.Add(txtedistatus)

            Dim txtlastupdatedby As SqlParameter = New SqlParameter("@lastupdatedby", lastupdatedby)
            sda.SelectCommand.Parameters.Add(txtlastupdatedby)

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "CancelAmt")

            'Dim dv As New DataView(ds.Tables("CancelAmt"))
            'If dv.Table.Rows.Count <> 0 Then
            '    Tpdid = "" & dv.Table.Rows(0)("pdid")
            '    Tempno = "" & dv.Table.Rows(0)("empno")
            '    Tschoolname = "" & dv.Table.Rows(0)("schoolname")
            '    Tedistatus = "" & dv.Table.Rows(0)("edistatus")
            '    Tcoursecode = "" & dv.Table.Rows(0)("coursecode")
            '    Ttotalcost = "" & dv.Table.Rows(0)("totalcost")
            '    Tlastupdatedby = "" & dv.Table.Rows(0)("lastupdatedby")
            '    Tlastupdatedon = "" & dv.Table.Rows(0)("lastupdatedon")
            'End If
            'dv.Dispose()
            'ds.Clear()
            ds.Dispose()

            If Err.Number = 0 Then
                ReCsTus = True
            Else
                ReCsTus = False
            End If

        Catch ex As Exception
            'Return False
            Dim ErrMsg As String = ""
            ErrMsg = Err.Description()
            ErrDetails = ErrMsg
        End Try
        Return ReCsTus

    End Function

    Public Function GetUserPDIDNo(ByVal EmpNu As String, ByVal pdCategory As String) As String
        'Dim sda As SqlDataAdapter = New SqlDataAdapter("GetUserPDIDNo", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        'sda.SelectCommand.CommandType = CommandType.StoredProcedure

        'Dim TxtEmpno As SqlParameter = New SqlParameter("@empno", EmpNu)
        'sda.SelectCommand.Parameters.Add(TxtEmpno)

        'Dim Txtpdcategory As SqlParameter = New SqlParameter("@pdcategory", pdCategory)
        'sda.SelectCommand.Parameters.Add(Txtpdcategory)

        Dim TPDid As String = ""
        'Dim ds As DataSet = New DataSet()
        'sda.Fill(ds, "userPDIDno")
        'Dim dv As New DataView(ds.Tables("userPDIDno"))
        'If dv.Table.Rows.Count <> 0 Then
        '    TPDid = "" & dv.Table.Rows(0)("pdid")
        'End If
        'dv.Dispose()
        'ds.Clear()
        'ds.Dispose()
        Return TPDid

    End Function

    Public Function CheckPDidNu(ByVal tEMPpdid As String) As String

        'Dim sda As SqlDataAdapter = New SqlDataAdapter("ChkPDIDnoinCancelTbl", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        'sda.SelectCommand.CommandType = CommandType.StoredProcedure

        'Dim TxtEmpno As SqlParameter = New SqlParameter("@pdid", tEMPpdid)
        'sda.SelectCommand.Parameters.Add(TxtEmpno)

        Dim OldStus As String = ""

        'Dim ds As DataSet = New DataSet()
        'sda.Fill(ds, "cancellerRecInfo")
        'Dim dv As New DataView(ds.Tables("cancellerRecInfo"))
        'If dv.Table.Rows.Count <> 0 Then
        '    OldStus = "" & dv.Table.Rows(0)("status")
        'End If
        'dv.Dispose()
        'ds.Clear()
        'ds.Dispose()

        Return OldStus
    End Function

    Public Function GetUserpdidNOusingCity(ByVal EMPno As String, ByVal CiTiName As String) As String
        'Dim sda As SqlDataAdapter = New SqlDataAdapter("GetUserpdidNOusingCity", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        'sda.SelectCommand.CommandType = CommandType.StoredProcedure

        'Dim TxtEmpno As SqlParameter = New SqlParameter("@empno", EMPno)
        'sda.SelectCommand.Parameters.Add(TxtEmpno)

        'Dim Txtpdcity As SqlParameter = New SqlParameter("@city", CiTiName)
        'sda.SelectCommand.Parameters.Add(Txtpdcity)

        Dim TPDid As String = ""
        'Dim ds As DataSet = New DataSet()
        'sda.Fill(ds, "UserpdidnOusingCiti")
        'Dim dv As New DataView(ds.Tables("UserpdidnOusingCiti"))
        'If dv.Table.Rows.Count <> 0 Then
        '    TPDid = "" & dv.Table.Rows(0)("pdid")
        'End If
        'dv.Dispose()
        'ds.Clear()
        'ds.Dispose()
        Return TPDid
    End Function
    Public Function GetPDNeedYear() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdneedyear", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdneedyear")
        Return ds
    End Function

    Public Function Getpdcategory() As DataSet
        'No need
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdcategory", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "cat")
        Return ds
    End Function

    Public Function Getpdcategory02(ByVal Param As String, ByVal type As String, ByVal pdCatry As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdcategory02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim txtpdtype As SqlParameter = New SqlParameter("@type", type)
        sda.SelectCommand.Parameters.Add(txtpdtype)

        Dim txtpdCategory As SqlParameter = New SqlParameter("@category", pdCatry)
        sda.SelectCommand.Parameters.Add(txtpdCategory)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "cat")
        Return ds
    End Function

    Public Function LoginSAMD(ByVal param As String, ByVal email As String, ByVal password As String, ByVal status As String, ByVal role As String, ByVal organization As String) As String
        Dim TotRec As Integer = 0
        Dim Emsg As String = ""
        'Dim Rst As String = "Ok"

        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("LoginSAMD", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
            sda.SelectCommand.Parameters.Add(txtParaM)

            Dim txtemail As SqlParameter = New SqlParameter("@email", email)
            sda.SelectCommand.Parameters.Add(txtemail)

            Dim txtpassword As SqlParameter = New SqlParameter("@password", password)
            sda.SelectCommand.Parameters.Add(txtpassword)

            Dim txtstatus As SqlParameter = New SqlParameter("@status", status)
            sda.SelectCommand.Parameters.Add(txtstatus)

            Dim txtrole As SqlParameter = New SqlParameter("@role", role)
            sda.SelectCommand.Parameters.Add(txtrole)

            Dim txtorganization As SqlParameter = New SqlParameter("@organization", organization)
            sda.SelectCommand.Parameters.Add(txtorganization)

            Dim Trst As String = ""
            Trst = "INSERT INTO Login (Email,Password,Status,Role,Organization) VALUES('" & email & "','" & password & "','" & status & "','" & role & "','" & organization & "')"
            'Trst = "INSERT INTO Login (Email,Password,Status,Role,Organization) VALUES(@email,@password,@status,@role,@organization)"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "LoginDetail")
            Dim dV As New DataView(ds.Tables("LoginDetail"))
            TotRec = dV.Table.Rows.Count
            'Dim dvRow As DataRowView
            'For Each dvRow In dV
            '    'DrpDwn = dvRow.Item("edistatus").ToString()
            '    'MsgBox1 = MessageBox.Show(DrpDwn)
            'Next
        Catch ex As Exception
            Emsg = Err.Description()
        End Try
        'Return Convert.ToString(TotRec)

        If Err.Number = 0 Then
            Return Convert.ToString(TotRec)
        Else
            Return Emsg
        End If

    End Function

    Public Function LoginSAMD4GridV(ByVal param As String, ByVal email As String, ByVal password As String, ByVal status As String, ByVal role As String, ByVal organization As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("LoginSAMD", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim txtemail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtemail)

        Dim txtpassword As SqlParameter = New SqlParameter("@password", password)
        sda.SelectCommand.Parameters.Add(txtpassword)

        Dim txtstatus As SqlParameter = New SqlParameter("@status", status)
        sda.SelectCommand.Parameters.Add(txtstatus)

        Dim txtrole As SqlParameter = New SqlParameter("@role", role)
        sda.SelectCommand.Parameters.Add(txtrole)

        Dim txtorganization As SqlParameter = New SqlParameter("@organization", organization)
        sda.SelectCommand.Parameters.Add(txtorganization)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "LoginList")
        Return ds

    End Function


    Public Function InsertPDNewReqTravel(ByVal eMPno As String, ByVal pdCatry As String, ByVal pdNeed As String, ByVal Citi As String, ByVal Cnty As String, ByVal Dte As String, ByVal fEEs As Decimal, ByVal ticktCost As Decimal, ByVal perDiem As Decimal, ByVal TotCost As Decimal, ByVal RqType As String, ByVal UsrName As String, ByVal Schoolname As String, ByVal pdneedYr As String, ByVal pDtype As String, ByVal cstartdte As DateTime) As Boolean

        Dim RstVar As Boolean = False
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("InsertPDNewReqTravel", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtempno As SqlParameter = New SqlParameter("@empno", eMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtpdneed As SqlParameter = New SqlParameter("@pdneed", pdNeed)
            sda.SelectCommand.Parameters.Add(txtpdneed)

            Dim txtCity As SqlParameter = New SqlParameter("@city", Citi)
            sda.SelectCommand.Parameters.Add(txtCity)

            Dim txtCountry As SqlParameter = New SqlParameter("@country", Cnty)
            sda.SelectCommand.Parameters.Add(txtCountry)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTicketCost As SqlParameter = New SqlParameter("@ticketcost", ticktCost)
            sda.SelectCommand.Parameters.Add(txtTicketCost)

            Dim txtperDiem As SqlParameter = New SqlParameter("@perdiem", perDiem)
            sda.SelectCommand.Parameters.Add(txtperDiem)

            Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", TotCost)
            sda.SelectCommand.Parameters.Add(txtTotalCost)

            Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtPDNeedYear As SqlParameter = New SqlParameter("@pdneedyear", pdneedYr)
            sda.SelectCommand.Parameters.Add(txtPDNeedYear)

            Dim txtpDtype As SqlParameter = New SqlParameter("@pdtype", pDtype)
            sda.SelectCommand.Parameters.Add(txtpDtype)
            'Or
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@pdtype", SqlDbType.VarChar)).Value = pDtype

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'Create and add an output parameter to Parameters collection.
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@scopeid", SqlDbType.VarChar, 5))
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@scopeid", SqlDbType.Int))
            'sda.SelectCommand.Parameters("@scopeid").Direction = ParameterDirection.Output
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@sid", SqlDbType.Int, 1024)).Direction = ParameterDirection.Output

            'Dim txtScopeID As SqlParameter = New SqlParameter("@sid", SqlDbType.Int)
            'sda.SelectCommand.Parameters.Add(txtScopeID)
            'txtScopeID.Direction = ParameterDirection.Output

            ''Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate(),@cstartdte)
            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon) values('" & eMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & RqType & "','" & "New Request" & "','" & "Approved" & "','" & UsrName & "','" & Date.Now() & "','" & cstartdte & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdNewReqTra")

            'Dim RtnResult As Integer = 0
            'RtnResult = sda.SelectCommand.Parameters(16).Value
            'RtnResult = sda.SelectCommand.Parameters("@scopeid").Value
            'RtnResult = txtScopeID.Value

            sda.Dispose() 'Dispose of the DataAdapter.
            'MyConnection.Close() 'Close the connection.

            'Return RtnResult

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar

    End Function

    Public Function UpdPDNewReqTravel(ByVal PdiD As String, ByVal eMPno As String, ByVal pdCatry As String, ByVal pdNeed As String, ByVal Citi As String, ByVal Cnty As String, ByVal Dte As String, ByVal fEEs As Decimal, ByVal ticktCost As Decimal, ByVal perDiem As Decimal, ByVal TotCost As Decimal, ByVal RqType As String, ByVal dEpt As String, ByVal deptcomns As String, ByVal UsrName As String, ByVal Schoolname As String, ByVal cstartdte As DateTime) As Boolean
        Dim RstVar As Boolean = False
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdPDNewReqTravel", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtPdiD As SqlParameter = New SqlParameter("@pdid", PdiD)
            sda.SelectCommand.Parameters.Add(txtPdiD)

            Dim txtempno As SqlParameter = New SqlParameter("@empno", eMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtpdneed As SqlParameter = New SqlParameter("@pdneed", pdNeed)
            sda.SelectCommand.Parameters.Add(txtpdneed)

            Dim txtCity As SqlParameter = New SqlParameter("@city", Citi)
            sda.SelectCommand.Parameters.Add(txtCity)

            Dim txtCountry As SqlParameter = New SqlParameter("@country", Cnty)
            sda.SelectCommand.Parameters.Add(txtCountry)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTicketCost As SqlParameter = New SqlParameter("@ticketcost", ticktCost)
            sda.SelectCommand.Parameters.Add(txtTicketCost)

            Dim txtperDiem As SqlParameter = New SqlParameter("@perdiem", perDiem)
            sda.SelectCommand.Parameters.Add(txtperDiem)

            Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", TotCost)
            sda.SelectCommand.Parameters.Add(txtTotalCost)

            Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtdEpt As SqlParameter = New SqlParameter("@deptstus", dEpt)
            sda.SelectCommand.Parameters.Add(txtdEpt)

            Dim txtdeptcomns As SqlParameter = New SqlParameter("@deptcomns", deptcomns)
            sda.SelectCommand.Parameters.Add(txtdeptcomns)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate())
            'Dim Tst As String = ""
            'Tst = "update PDPlanTbl set empno=@empno,pdcategory=@pdcategory,pdneed=@pdneed,city=@city,country=@country,pdsdate=@pdsdate,fees=@fees,ticketcost=@ticketcost,perdiem=@perdiem,totalcost=@totalcost,reqtype=@reqtype,deptstus=@deptstus,lastupdatedby=@lastupdatedby,lastupdatedon=getdate(),schoolname=@schoolname where pdid=@pdid"
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon) values('" & eMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & RqType & "','" & "New Request" & "','" & "Approved" & "','" & UsrName & "','" & Date.Now() & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "UpdpdNewReqTra")

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar
    End Function

    Public Function UpdPDNewReqLocal(ByVal PdiD As String, ByVal eMPno As String, ByVal deptstus As String, ByVal deptcomns As String, ByVal pdCatry As String, ByVal subCat As String, ByVal cCode As String, ByVal fInfo As String, ByVal Dte As String, ByVal fEEs As Decimal, ByVal TotCost As Decimal, ByVal UsrName As String, ByVal Schoolname As String, ByVal cstartdte As Date) As Boolean
        Dim RstVar As Boolean = False
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdPDNewReqLocal", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtPdiD As SqlParameter = New SqlParameter("@pdid", PdiD)
            sda.SelectCommand.Parameters.Add(txtPdiD)

            Dim txtempno As SqlParameter = New SqlParameter("@empno", eMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtdEpt As SqlParameter = New SqlParameter("@deptstus", deptstus)
            sda.SelectCommand.Parameters.Add(txtdEpt)

            Dim txtdeptcomns As SqlParameter = New SqlParameter("@deptcomns", deptcomns)
            sda.SelectCommand.Parameters.Add(txtdeptcomns)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtsubCat As SqlParameter = New SqlParameter("@subcategory", subCat)
            sda.SelectCommand.Parameters.Add(txtsubCat)

            Dim txtcCode As SqlParameter = New SqlParameter("@pdcoursecode", cCode)
            sda.SelectCommand.Parameters.Add(txtcCode)

            Dim txtfInfo As SqlParameter = New SqlParameter("@furtherinfo", fInfo)
            sda.SelectCommand.Parameters.Add(txtfInfo)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTotCost As SqlParameter = New SqlParameter("@totalcost", TotCost)
            sda.SelectCommand.Parameters.Add(txtTotCost)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "UpdpdNewReqTra")

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar
    End Function

    Public Function InsertPDProvisionLocal(ByVal EMPno As String, ByVal pdCatry As String, ByVal pdcodE As String, ByVal FuInfo As String, ByVal Dte As String, ByVal nofparticipants As String, ByVal fEEs As Decimal, ByVal totCosT As Decimal, ByVal Tbllink As String, ByVal RqType As String, ByVal UsrName As String, ByVal Schname As String, ByVal subCat As String, ByVal PdNeeDYr As String, ByVal PdType As String, ByVal cstartdte As DateTime) As String
        Dim RstVar As Boolean = False
        'Dim SPConfMsgToBeRtn As String = ""
        'Dim spErrNo1 As String = ""
        'Dim spErrMsg1 As String = ""

        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("InsertPDProvisionLocal", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtempno As SqlParameter = New SqlParameter("@empno", EMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtpdCode As SqlParameter = New SqlParameter("@pdcode", pdcodE)
            sda.SelectCommand.Parameters.Add(txtpdCode)

            'Dim txtDes As SqlParameter = New SqlParameter("@pdDescription", pdDes)
            'sda.SelectCommand.Parameters.Add(txtDes)

            Dim txtFuInfo As SqlParameter = New SqlParameter("@furtherinfo", FuInfo)
            sda.SelectCommand.Parameters.Add(txtFuInfo)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtnofparticipants As SqlParameter = New SqlParameter("@nofparticipants", nofparticipants)
            sda.SelectCommand.Parameters.Add(txtnofparticipants)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTotCost As SqlParameter = New SqlParameter("@totCost", totCosT)
            sda.SelectCommand.Parameters.Add(txtTotCost)

            Dim txtTbllink As SqlParameter = New SqlParameter("@tbllink", Tbllink)
            sda.SelectCommand.Parameters.Add(txtTbllink)

            'Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", totCosT)
            'sda.SelectCommand.Parameters.Add(txtTotalCost)

            Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schname", Schname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtsubCat As SqlParameter = New SqlParameter("@subcategory", subCat)
            sda.SelectCommand.Parameters.Add(txtsubCat)

            Dim txtPDNeedYear As SqlParameter = New SqlParameter("@pdneedyear", PdNeeDYr)
            sda.SelectCommand.Parameters.Add(txtPDNeedYear)

            Dim txtPdType As SqlParameter = New SqlParameter("@pdtype", PdType)
            sda.SelectCommand.Parameters.Add(txtPdType)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'sda.SelectCommand.Parameters.Add(New SqlParameter("@ConfMsgToBeRtn", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
            'sda.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

            'Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate())
            'Insert into PDPlanTbl (empno, pdcategory, pdcode, pdDescription, furtherinfo, pddate, fees, totCost, tbllink, reqtype, edistatus, lastupdatedby, lastupdatedon) values(@empno, @pdcategory, @pdcode, @pdDescription, @furtherinfo, @pddate, @fees, @totCost, @tbllink, @reqtype,@edistatus, @lastupdatedby, @lastupdatedon)
            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdcoursecode, furtherinfo, pdsdate, nofparticipants, fees, totalcost, tbllink, reqtype, edistatus, lastupdatedby, lastupdatedon) values(@empno, @pdcategory, @pdcode, @furtherinfo, @pdsdate, @fees, @totCost, @tbllink, @reqtype,'New Request', @lastupdatedby, getdate())"
            ''Tst = "Insert into PDPlanTbl (empno, pdcategory, pdcode, furtherinfo, pdsdate, fees, totCost, tbllink, reqtype, edistatus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdcodE & "','" & FuInfo & "','" & Dte & "','" & fEEs & "','" & totCosT & "','" & Tbllink & " ','" & RqType & "','" & "New Request" & "','" & UsrName & "','" & Date.Now() & "')"
            ''Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & totCosT & "','" & RqType & "','" & "New Request" & "','" & UsrName & "','" & Date.Now() & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdNewReqTra")

            'SPConfMsgToBeRtn = sda.SelectCommand.Parameters("@ConfMsgToBeRtn").Value.ToString()
            'spErrNo1 = sda.SelectCommand.Parameters("@ErrNo").Value.ToString()
            'spErrMsg1 = sda.SelectCommand.Parameters("@ErrMsg").Value.ToString()

            'Dim SpErrNo2 As String = ""
            'Dim SpErrMsg2 As String = ""
            'SpErrNo2 = sda.SelectCommand.Parameters(1).Value.ToString()
            'SpErrMsg2 = sda.SelectCommand.Parameters(2).Value.ToString()

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If

        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            'RstVar = "Error"
        End Try
        'Return SPConfMsgToBeRtn
        Return RstVar

    End Function

    Public Function InsertPDNewReqLocal(ByVal EMPno As String, ByVal pdCatry As String, ByVal SubCat As String, ByVal pdcodE As String, ByVal FuInfo As String, ByVal Dte As String, ByVal fEEs As Decimal, ByVal totCosT As Decimal, ByVal Tbllink As String, ByVal RqType As String, ByVal UsrName As String, ByVal Schoolname As String, pdneedyear As String, ByVal pdtYpe As String, ByVal cstartdte As Date) As Boolean
        Dim RstVar As Boolean = False

        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("InsertPDNewReqLocal", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtempno As SqlParameter = New SqlParameter("@empno", EMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtSubCat As SqlParameter = New SqlParameter("@subcategory", SubCat)
            sda.SelectCommand.Parameters.Add(txtSubCat)

            Dim txtpdCode As SqlParameter = New SqlParameter("@pdcode", pdcodE)
            sda.SelectCommand.Parameters.Add(txtpdCode)

            'Dim txtDes As SqlParameter = New SqlParameter("@pdDescription", pdDes)
            'sda.SelectCommand.Parameters.Add(txtDes)

            '@empno, @pdcategory, @pdcode, @pdDescription, @furtherinfo, @pddate, @fees, @totCost, @tbllink, @reqtype, @lastupdatedby

            Dim txtFuInfo As SqlParameter = New SqlParameter("@furtherinfo", FuInfo)
            sda.SelectCommand.Parameters.Add(txtFuInfo)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTotCost As SqlParameter = New SqlParameter("@totCost", totCosT)
            sda.SelectCommand.Parameters.Add(txtTotCost)

            Dim txtTbllink As SqlParameter = New SqlParameter("@tbllink", Tbllink)
            sda.SelectCommand.Parameters.Add(txtTbllink)

            'Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", totCosT)
            'sda.SelectCommand.Parameters.Add(txtTotalCost)

            Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtPDNeedYear As SqlParameter = New SqlParameter("@pdneedyear", pdneedyear)
            sda.SelectCommand.Parameters.Add(txtPDNeedYear)

            Dim txtpdtYpe As SqlParameter = New SqlParameter("@pdtype", pdtYpe)
            sda.SelectCommand.Parameters.Add(txtpdtYpe)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate(),cstartdte)
            'Insert into PDPlanTbl (empno, pdcategory, pdcode, pdDescription, furtherinfo, pddate, fees, totCost, tbllink, reqtype, edistatus, lastupdatedby, lastupdatedon) values(@empno, @pdcategory, @pdcode, @pdDescription, @furtherinfo, @pddate, @fees, @totCost, @tbllink, @reqtype,@edistatus, @lastupdatedby, @lastupdatedon,@cstartdte)
            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdcode, furtherinfo, pdsdate, fees, totCost, tbllink, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdcodE & "','" & FuInfo & "','" & Dte & "','" & fEEs & "','" & totCosT & "','" & Tbllink & " ','" & RqType & "','" & "New Request" & "','" & "Approved" & "','" & UsrName & "','" & Date.Now() & "','" & cstartdte & "')"
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & totCosT & "','" & RqType & "','" & "New Request" & "','" & UsrName & "','" & Date.Now() & "','" & cstartdte & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdNewReqTra")

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar

    End Function

    Public Function InsertPDProvisionTravel(ByVal eMPno As String, ByVal pdcategory As String, ByVal pdNeed As String, ByVal Citi As String, ByVal Cnty As String, ByVal Dte As String, ByVal nofparticipants As String, ByVal fEEs As Decimal, ByVal ticktCost As Decimal, ByVal perDiem As Decimal, ByVal TotCost As Decimal, ByVal Tbllink As String, ByVal RqType As String, ByVal UsrName As String, ByVal Schname As String, ByVal pdNeedyEar As String, ByVal pdType As String, ByVal cstartdte As DateTime) As Boolean
        Dim RstVar As Boolean = False
        Try

            Dim sda As SqlDataAdapter = New SqlDataAdapter("InsertPDProvisionTravel", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtempno As SqlParameter = New SqlParameter("@empno", eMPno)
            sda.SelectCommand.Parameters.Add(txtempno)

            Dim txtpdcategory As SqlParameter = New SqlParameter("@pdcategory", pdcategory)
            sda.SelectCommand.Parameters.Add(txtpdcategory)

            Dim txtpdneed As SqlParameter = New SqlParameter("@pdneed", pdNeed)
            sda.SelectCommand.Parameters.Add(txtpdneed)

            Dim txtCity As SqlParameter = New SqlParameter("@city", Citi)
            sda.SelectCommand.Parameters.Add(txtCity)

            Dim txtCountry As SqlParameter = New SqlParameter("@country", Cnty)
            sda.SelectCommand.Parameters.Add(txtCountry)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtnofparticipants As SqlParameter = New SqlParameter("@nofparticipants", nofparticipants)
            sda.SelectCommand.Parameters.Add(txtnofparticipants)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTicketCost As SqlParameter = New SqlParameter("@ticketcost", ticktCost)
            sda.SelectCommand.Parameters.Add(txtTicketCost)

            Dim txtperDiem As SqlParameter = New SqlParameter("@perdiem", perDiem)
            sda.SelectCommand.Parameters.Add(txtperDiem)

            Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", TotCost)
            sda.SelectCommand.Parameters.Add(txtTotalCost)

            Dim txtTbllink As SqlParameter = New SqlParameter("@tbllink", Tbllink)
            sda.SelectCommand.Parameters.Add(txtTbllink)

            Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtSchname As SqlParameter = New SqlParameter("@schname", Schname)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtPDNeedYear As SqlParameter = New SqlParameter("@pdneedyear", pdNeedyEar)
            sda.SelectCommand.Parameters.Add(txtPDNeedYear)

            Dim txtpdType As SqlParameter = New SqlParameter("@pdtype", pdType)
            sda.SelectCommand.Parameters.Add(txtpdType)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate())

            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, semester, nofparticipants, fEEs, ticketcost, perDiem, totalcost, Tbllink, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon, schoolname, pdNeedyEar) values('" & eMPno & "','" & pdcategory & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & nofparticipants & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & Tbllink & "','" & RqType & "','" & "New Request" & "','" & "Budgeted" & "','" & UsrName & "','" & Date.Now() & "','" & Schname & "','" & pdNeedyEar & "')"
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, semester, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, lastupdatedby, lastupdatedon) values('" & eMPno & "','" & pdcategory & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & RqType & "','" & "New Request" & "','" & UsrName & "','" & Date.Now() & "')"
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, semester, nofparticipants, fEEs, ticketcost, perDiem, totalcost, Tbllink, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon, schoolname, pdNeedyEar) values(@empno,@pdcategory,@pdneed,@city,@country,@semester,@nofparticipants,@fees,@ticketcost,@perdiem,@totalcost,@tbllink,@reqtype,'New Request','Budgeted',@lastupdatedby,getdate(),@schname,@pdneedyear)"
            'values(@empno,@pdcategory,@pdneed,@city,@country,@semester,@nofparticipants,@fees,@ticketcost,@perdiem,@totalcost,@tbllink,@reqtype,'New Request','Budgeted',@lastupdatedby,getdate(),@schname,@pdneedyear)
            'values('" & eMPno & "','" & pdcategory & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & nofparticipants & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & Tbllink & "','" & RqType & "','" & "New Request" & "','" & "Budgeted" & "','" & UsrName & "','" & Date.Now() & "','" & Schname & "','" & pdNeedyEar & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdNewReqTra")

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar

    End Function

    Public Function CheckUser(ByVal username As String, ByVal Password As String) As String

        Dim sda As SqlDataAdapter = New SqlDataAdapter("checkuser", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtusername As SqlParameter = New SqlParameter("@username", username)
        sda.SelectCommand.Parameters.Add(txtusername)

        Dim txtPassword As SqlParameter = New SqlParameter("@Password", Password)
        sda.SelectCommand.Parameters.Add(txtPassword)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "user")
        Dim dv As New DataView(ds.Tables("user"))
        If dv.Table.Rows.Count = 0 Then
            Return ""
            User = ""
            School = ""
            URole = ""
        Else
            User = dv.Table.Rows(0)("email")
            School = dv.Table.Rows(0)("organization")
            URole = "" & dv.Table.Rows(0)("Role")
            'Session("schoolname") = School
            Return School
        End If
        'Return ds
    End Function

    Public Function IsAvailable(ByVal conn As SqlConnection) As Boolean

        Try
            conn.Open()
            conn.Close()
        Catch ex As Exception
            Return False
            'If (conn.State <> ConnectionState.Closed) Then
            '    conn.Close()
            '    conn = Nothing
            'End If
        End Try
        Return True

    End Function

    Public Function GetBudgetStatus(ByVal Schoolname As String, ByVal pdneedyear As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetBudgetStatus", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@Schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtpdneedyear As SqlParameter = New SqlParameter("@pdneedyear", pdneedyear)
        sda.SelectCommand.Parameters.Add(txtpdneedyear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "budget")
        Return ds
    End Function
    Public Function GetDept(ByVal centername As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetDept", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtcentername As SqlParameter = New SqlParameter("@centername", centername)
        sda.SelectCommand.Parameters.Add(txtcentername)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "dept")
        Return ds
    End Function

    Public Function GetCcodeDescription(ByVal cCode As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetCcodeDescription", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtcCode As SqlParameter = New SqlParameter("@coursecode", cCode)
        sda.SelectCommand.Parameters.Add(txtcCode)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "CcDescription")
        Return ds
    End Function

    Public Function ReadEmailDetails(ByVal rEfno As Integer) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("ReadEmailDetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtrREFno As SqlParameter = New SqlParameter("@RefNo", rEfno)
        sda.SelectCommand.Parameters.Add(txtrREFno)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "emailvalue")
        Return ds

    End Function
    Public Function dELETErEC(ByVal rEfno As Integer) As Boolean
        Dim rEsUlT As Boolean = True
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("dELETErEC", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtrREFno As SqlParameter = New SqlParameter("@pdiD", rEfno)
            sda.SelectCommand.Parameters.Add(txtrREFno)

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "recDelete")
            'Return ds
            If (Err.Number <> 0) Then rEsUlT = False
        Catch ex As Exception
            Dim ErrMsg As String = ""
            ErrMsg = Err.Description()
            ErrDetails = ErrMsg
        End Try
        Return rEsUlT
    End Function

    Public Function UpdateEmailDetails(ByVal RefNo As Integer, frmname As String, frmemadd As String, toname As String, toemadd As String, ccadd As String, bcadd As String, subj As String, bodymsg As String) As Integer

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetEmailAddress", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtRefNo1 As Integer = 0
        txtRefNo1 = RefNo
        Dim txtRefNo As SqlParameter = New SqlParameter("@refno", RefNo)
        sda.SelectCommand.Parameters.Add(txtRefNo)

        Dim txtFrmname1 As String
        txtFrmname1 = "" & frmname
        Dim txtFrmname As SqlParameter = New SqlParameter("@frmname", frmname)
        sda.SelectCommand.Parameters.Add(txtFrmname)

        Dim txtFrmemadd1 As String
        txtFrmemadd1 = "" & frmemadd
        Dim txtFrmemadd As SqlParameter = New SqlParameter("@frmemadd", frmemadd)
        sda.SelectCommand.Parameters.Add(txtFrmemadd)

        Dim txtToname1 As String
        txtToname1 = "" & toname
        Dim txtToname As SqlParameter = New SqlParameter("@toname", toname)
        sda.SelectCommand.Parameters.Add(txtToname)

        Dim txtToemadd1 As String
        txtToemadd1 = "" & toemadd
        Dim txtToemadd As SqlParameter = New SqlParameter("@toemadd", toemadd)
        sda.SelectCommand.Parameters.Add(txtToemadd)

        Dim txtCcadd1 As String
        txtCcadd1 = "" & ccadd
        Dim txtCcadd As SqlParameter = New SqlParameter("@ccadd", ccadd)
        sda.SelectCommand.Parameters.Add(txtCcadd)

        Dim txtBcadd1 As String
        txtBcadd1 = "" & bcadd
        Dim txtBcadd As SqlParameter = New SqlParameter("@bcadd", bcadd)
        sda.SelectCommand.Parameters.Add(txtBcadd)

        Dim txtSubj1 As String
        txtSubj1 = "" & subj
        Dim txtSubj As SqlParameter = New SqlParameter("@subj", subj)
        sda.SelectCommand.Parameters.Add(txtSubj)

        Dim txtBodymsg1 As String
        txtBodymsg1 = "" & bodymsg
        Dim txtBodymsg As SqlParameter = New SqlParameter("@bodymsg", bodymsg)
        sda.SelectCommand.Parameters.Add(txtBodymsg)

        'Dim UpdateStm As String = ""
        'UpdateStm = "UPDATE emailaddress Set frmname ='" & txtFrmname1 & "', frmemadd ='" & txtFrmemadd1 & "', toname = '" & txtToname1 & "', toemadd = '" & txtToemadd1 & "', ccadd = '" & txtCcadd1 & "', bcadd = '" & txtBcadd1 & "', subj = '" & txtSubj1 & "', bodymsg = '" & txtBodymsg1 & "' where refno = " & txtRefNo1

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "emailupdate")

        'Dim Dv1 As New DataView(ds.Tables("emailupdate"))
        'If Dv1.Table.Rows.Count = 0 Then
        '    Return 0
        'Else
        '    Return 1
        'End If
        Return 1

    End Function

    Public Function Ins2Mbg4All(ByVal schoolname1 As String, ByVal overallbudget As Integer, ByVal budgetedloc As Integer, ByVal allocatedloc As Integer, ByVal budgetedtrv As Integer, ByVal allocatedtrv As Integer, ByVal balanceloc As Integer, ByVal balancetrv As Integer, ByVal username As String, ByVal pdneedyear As String, ByVal IniAllocTrvBg As Integer, ByVal IniAllocLocBg As Integer) As Boolean
        'schoolname,overallbudget,,,,,
        Dim RstVar As Boolean = False

        Try

            Dim sda As SqlDataAdapter = New SqlDataAdapter("Ins2Mbg4All", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", schoolname1)
            sda.SelectCommand.Parameters.Add(txtSchname)

            Dim txtoverallbudget As SqlParameter = New SqlParameter("@overallbudget", overallbudget)
            sda.SelectCommand.Parameters.Add(txtoverallbudget)

            Dim txtbudgetedloc As SqlParameter = New SqlParameter("@budgetedloc", budgetedloc)
            sda.SelectCommand.Parameters.Add(txtbudgetedloc)

            Dim txtallocatedloc As SqlParameter = New SqlParameter("@allocatedloc", allocatedloc)
            sda.SelectCommand.Parameters.Add(txtallocatedloc)

            Dim txtbudgetedtrv As SqlParameter = New SqlParameter("@budgetedtrv", budgetedtrv)
            sda.SelectCommand.Parameters.Add(txtbudgetedtrv)

            Dim txtallocatedtrv As SqlParameter = New SqlParameter("@allocatedtrv", allocatedtrv)
            sda.SelectCommand.Parameters.Add(txtallocatedtrv)

            Dim txtbalanceloc As SqlParameter = New SqlParameter("@balanceloc", balanceloc)
            sda.SelectCommand.Parameters.Add(txtbalanceloc)

            Dim txtbalancetrv As SqlParameter = New SqlParameter("@balancetrv", balancetrv)
            sda.SelectCommand.Parameters.Add(txtbalancetrv)

            Dim txtusername As SqlParameter = New SqlParameter("@username", username)
            sda.SelectCommand.Parameters.Add(txtusername)

            Dim txtpdneedyear As SqlParameter = New SqlParameter("@pdneedyear", pdneedyear)
            sda.SelectCommand.Parameters.Add(txtpdneedyear)

            Dim txtIniAllocTrvBg As SqlParameter = New SqlParameter("@allocatedtrvamt", IniAllocTrvBg)
            sda.SelectCommand.Parameters.Add(txtIniAllocTrvBg)

            Dim txtIniAllocLocBg As SqlParameter = New SqlParameter("@allocatedlocamt", IniAllocLocBg)
            sda.SelectCommand.Parameters.Add(txtIniAllocLocBg)

            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdcode, furtherinfo, pdsdate, fees, totCost, tbllink, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdcodE & "','" & FuInfo & "','" & Dte & "','" & fEEs & "','" & totCosT & "','" & Tbllink & " ','" & RqType & "','" & "New Request" & "','" & "Approved" & "','" & UsrName & "','" & Date.Now() & "')"
            ''Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, lastupdatedby, lastupdatedon) values('" & EMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & totCosT & "','" & RqType & "','" & "New Request" & "','" & UsrName & "','" & Date.Now() & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "BudgetMoni4ALL")

            If Err.Number = 0 Then
                RstVar = True
            Else
                RstVar = False
            End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            RstVar = False
        End Try
        Return RstVar

    End Function

    Public Function UpdatePDprovisionTrv(ByVal pDiD As String, ByVal PDCat As String, ByVal pdNeed As String, ByVal Citi As String, ByVal Cnty As String, ByVal Dte As String, ByVal nuOfPartici As String, ByVal fEEs As Decimal, ByVal ticktCost As Decimal, ByVal perDiem As Decimal, ByVal TotCost As Decimal, ByVal UsrName As String, ByVal dept_Stus As String, dept_Comns As String, ByVal cstartdte As DateTime) As Boolean

        Dim RstVar As Boolean = False
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdatePDprovisionTrv", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtpdid As SqlParameter = New SqlParameter("@pdid", pDiD)
            sda.SelectCommand.Parameters.Add(txtpdid)

            Dim txtpdCat As SqlParameter = New SqlParameter("@pdcategory", PDCat)
            sda.SelectCommand.Parameters.Add(txtpdCat)

            Dim txtpdneed As SqlParameter = New SqlParameter("@pdneed", pdNeed)
            sda.SelectCommand.Parameters.Add(txtpdneed)

            Dim txtCity As SqlParameter = New SqlParameter("@city", Citi)
            sda.SelectCommand.Parameters.Add(txtCity)

            Dim txtCountry As SqlParameter = New SqlParameter("@country", Cnty)
            sda.SelectCommand.Parameters.Add(txtCountry)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtpdnuOfPartici As SqlParameter = New SqlParameter("@nofparticipants", nuOfPartici)
            sda.SelectCommand.Parameters.Add(txtpdnuOfPartici)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTicketCost As SqlParameter = New SqlParameter("@ticketcost", ticktCost)
            sda.SelectCommand.Parameters.Add(txtTicketCost)

            Dim txtperDiem As SqlParameter = New SqlParameter("@perdiem", perDiem)
            sda.SelectCommand.Parameters.Add(txtperDiem)

            Dim txtTotalCost As SqlParameter = New SqlParameter("@totalcost", TotCost)
            sda.SelectCommand.Parameters.Add(txtTotalCost)

            'Dim txtRqType As SqlParameter = New SqlParameter("@reqtype", RqType)
            'sda.SelectCommand.Parameters.Add(txtRqType)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtDeptStus As SqlParameter = New SqlParameter("@deptstus", dept_Stus)
            sda.SelectCommand.Parameters.Add(txtDeptStus)

            Dim txtDeptComns As SqlParameter = New SqlParameter("@deptcomns", dept_Comns)
            sda.SelectCommand.Parameters.Add(txtDeptComns)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            'Insert into PDPlanTbl (empno,pdcategory,pdneed,city,country,pdsdate,fees,ticketcost,perdiem,totalcost,reqtype,edistatus,lastupdatedby,lastupdatedon) values(@empno,@pdcategory,@pdneed,@city,@country,@pdsdate,@fees,@ticketcost,@perdiem,@totalcost,@reqtype,'New Request',@lastupdatedby,getdate())
            'Dim Tst As String = ""
            'Tst = "Insert into PDPlanTbl (empno, pdcategory, pdNeed, city, country, pdsdate, fEEs, ticketcost, perDiem, totalcost, reqtype, edistatus, deptstus, lastupdatedby, lastupdatedon) values('" & eMPno & "','" & pdCatry & "','" & pdNeed & "','" & Citi & "','" & Cnty & "','" & Dte & "','" & fEEs & "','" & ticktCost & "','" & perDiem & "','" & TotCost & "','" & RqType & "','" & "New Request" & "','" & "Approved" & "','" & UsrName & "','" & Date.Now() & "')"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdPROvdata")

            'If Err.Number = 0 Then
            '    RstVar = True
            'Else
            '    RstVar = False
            'End If
        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            'RstVar = False
        End Try
        'Return RstVar
        Return True

    End Function

    Public Function UpdatePDprovisionLoc(ByVal PdiD As String, ByVal pdCatry As String, ByVal pdcodE As String, ByVal FuInfo As String, ByVal Dte As String, ByVal nofparticipants As String, ByVal fEEs As Decimal, ByVal totCosT As Decimal, ByVal UsrName As String, ByVal dept_Stus As String, ByVal dept_Comns As String, ByVal subCat As String, ByVal cstartdte As DateTime) As Boolean

        'Dim RstVar As Boolean = False
        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdatePDprovisionLoc", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtpdid As SqlParameter = New SqlParameter("@pdid", PdiD)
            sda.SelectCommand.Parameters.Add(txtpdid)

            Dim txtpdCategory As SqlParameter = New SqlParameter("@pdcategory", pdCatry)
            sda.SelectCommand.Parameters.Add(txtpdCategory)

            Dim txtpdcoursecode As SqlParameter = New SqlParameter("@pdcoursecode", pdcodE)
            sda.SelectCommand.Parameters.Add(txtpdcoursecode)

            Dim txtFuInfo As SqlParameter = New SqlParameter("@furtherinfo", FuInfo)
            sda.SelectCommand.Parameters.Add(txtFuInfo)

            Dim txtDate As SqlParameter = New SqlParameter("@semester", Dte)
            sda.SelectCommand.Parameters.Add(txtDate)

            Dim txtnofparticipants As SqlParameter = New SqlParameter("@nofparticipants", nofparticipants)
            sda.SelectCommand.Parameters.Add(txtnofparticipants)

            Dim txtFees As SqlParameter = New SqlParameter("@fees", fEEs)
            sda.SelectCommand.Parameters.Add(txtFees)

            Dim txtTotCost As SqlParameter = New SqlParameter("@totalcost", totCosT)
            sda.SelectCommand.Parameters.Add(txtTotCost)

            Dim txtUsrName As SqlParameter = New SqlParameter("@lastupdatedby", UsrName)
            sda.SelectCommand.Parameters.Add(txtUsrName)

            Dim txtDeptStus As SqlParameter = New SqlParameter("@deptstus", dept_Stus)
            sda.SelectCommand.Parameters.Add(txtDeptStus)

            Dim txtDeptComns As SqlParameter = New SqlParameter("@deptcomns", dept_Comns)
            sda.SelectCommand.Parameters.Add(txtDeptComns)

            Dim txtsubCat As SqlParameter = New SqlParameter("@subcategory", subCat)
            sda.SelectCommand.Parameters.Add(txtsubCat)

            Dim txtCstartDte As SqlParameter = New SqlParameter("@cstartdte", cstartdte)
            sda.SelectCommand.Parameters.Add(txtCstartDte)

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "pdPROvLocData")

            'If Err.Number = 0 Then
            '    Dim Emsg As String = Err.Description()
            '    RstVar = True
            'Else
            '    RstVar = False
            'End If
            'ds.Dispose()
            'sda.Dispose()

        Catch ex As Exception
            Dim Emsg As String = Err.Description()
            'RstVar = False
        End Try
        'Return RstVar
        Return True

    End Function
    Public Function GetToTnoFemp(ByVal PraMe02 As String, ByVal SchName As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetToTnoFemp", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe02 As SqlParameter = New SqlParameter("@param", PraMe02)
        sda.SelectCommand.Parameters.Add(txtPraMe02)

        Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", SchName)
        sda.SelectCommand.Parameters.Add(txtSchname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TotNuOfEmp")
        Return ds
    End Function
    Public Function GetNoofPDStaff(ByVal PraMe01 As String, ByVal SchName02 As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetNoofPDStaff", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe01)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName02)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TotNuOfpdStaff")
        Return ds
    End Function

    Public Function GetNoofnoPDStaff(ByVal PraMe01 As String, ByVal SchName02 As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetNoofnoPDStaff", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe01)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName02)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TotNuOfNopdStaff")
        Return ds

    End Function

    Public Function Finding_PDStaffs(ByVal PraMe01 As String, ByVal SchName02 As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Finding_PDStaffs", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe01)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName02)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "FoundTotNuOfpdStaff")
        Return ds

    End Function

    Public Function NuofPDentriesBycategory(ByVal PraMe As String, ByVal SchName01 As String, ByVal pdYr As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("NuofPDentriesBycategory", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe As SqlParameter = New SqlParameter("@param", PraMe)
        sda.SelectCommand.Parameters.Add(txtPraMe)

        Dim txtSchname As SqlParameter = New SqlParameter("@schoolname", SchName01)
        sda.SelectCommand.Parameters.Add(txtSchname)

        Dim txtpdYr As SqlParameter = New SqlParameter("@pdyr", pdYr)
        sda.SelectCommand.Parameters.Add(txtpdYr)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TotNuOfPDEntries")
        Return ds

    End Function

    Public Function PasswordChange(ByVal Email As String, ByVal Password As String) As String
        Dim sda As SqlDataAdapter = New SqlDataAdapter("PasswordChange", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtEmail As SqlParameter = New SqlParameter("@email", Email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtPassword As SqlParameter = New SqlParameter("@password", Password)
        sda.SelectCommand.Parameters.Add(txtPassword)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pchange")

        Return "OK"
    End Function

    Public Function Getallusers() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getallusers", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "users")
        Return ds
    End Function

    Public Function List0fallTravelPD4eachSch() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("List0fallTravelPD4eachSch", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "List0fallTravelPD4eachSch01")
        Return ds
    End Function

    Public Function List0fallEDImodule() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("List0fallEDImodule", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "List0fallEDImodule01")
        Return ds
    End Function

    Public Function List0fallIBworkshops() As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("List0fallIBworkshops", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "List0fallIBworkshops01")
        Return ds
    End Function

    Public Function PDStatisticalRpt(ByVal PraMe1 As String, ByVal SchName2 As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("PDStatisticalRpt", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe1)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName2)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TotNuOfpdStaffs01")
        Return ds
    End Function

    Public Function getpdhistory02(ByVal PraMe1 As String, ByVal EmpNu1 As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("getpdhistory02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe1 As SqlParameter = New SqlParameter("@param", PraMe1)
        sda.SelectCommand.Parameters.Add(txtPraMe1)

        Dim txtEmpNu1 As SqlParameter = New SqlParameter("@empnu", EmpNu1)
        sda.SelectCommand.Parameters.Add(txtEmpNu1)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "PDHistoryRpt01")
        Return ds
    End Function

    Public Function PDHistory4Emp(ByVal ParaM As String, ByVal Emp As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPdHistory4Emp", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtpRam As SqlParameter = New SqlParameter("@param", ParaM)
        sda.SelectCommand.Parameters.Add(txtpRam)

        Dim txtEmP As SqlParameter = New SqlParameter("@empno", Emp)
        sda.SelectCommand.Parameters.Add(txtEmP)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "PDhistory4emp")
        Return ds
    End Function

    Public Function Getpdplandetails4AdminTest(ByVal pARAM As String) As DataSet
        'ByVal Schoolname As String, ByVal email As String, ByVal deptstus As String, ByVal lastname As String, ByVal dePartMent As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal Tpdtype As String, ByVal TblLnk As String
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails4AdminTest", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@TableName", pARAM)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanAdminViewTest")
        Return ds
    End Function

    Public Function Getpdplandetails4AdminTest02(ByVal Schoolname As String, ByVal dePartMent As String, ByVal deptstus As String, ByVal Tpdtype As String, ByVal lastname As String, ByVal email As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal TblLnk As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails4AdminTest02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        ''ByVal pARAM As String
        'Dim TXTparam As SqlParameter = New SqlParameter("@TableName", pARAM)
        'sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtDeptstus As SqlParameter = New SqlParameter("@deptstus", deptstus)
        sda.SelectCommand.Parameters.Add(txtDeptstus)

        Dim txtTpdtype As SqlParameter = New SqlParameter("@reqtype", Tpdtype)
        sda.SelectCommand.Parameters.Add(txtTpdtype)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        Dim txtTblLnk As SqlParameter = New SqlParameter("@tbllink", TblLnk)
        sda.SelectCommand.Parameters.Add(txtTblLnk)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanAdminViewTest02")
        Return ds

    End Function

    Public Function Getpdplandetails4EUS02(ByVal Schoolname As String, ByVal dePartMent As String, ByVal deptstus As String, ByVal Tpdtype As String, ByVal lastname As String, ByVal email As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("Getpdplandetails4EUS02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtDeptstus As SqlParameter = New SqlParameter("@deptstus", deptstus)
        sda.SelectCommand.Parameters.Add(txtDeptstus)

        Dim txtTpdtype As SqlParameter = New SqlParameter("@reqtype", Tpdtype)
        sda.SelectCommand.Parameters.Add(txtTpdtype)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        'Dim txtTblLnk As SqlParameter = New SqlParameter("@tbllink", TblLnk)
        'sda.SelectCommand.Parameters.Add(txtTblLnk)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanView")
        Return ds

    End Function

    Public Function GetParentRec(ByVal pdid As String) As DataSet
        'ByVal TblLnk As String, ByVal pdType As String

        Dim TotRec As Integer = 0
        Dim Tpdid As String = ""

        'Dim sda As SqlDataAdapter = New SqlDataAdapter("GetParentRec", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetPrnPDID", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "ParentRecID")
        Dim dV As New DataView(ds.Tables("ParentRecID"))
        TotRec = dV.Table.Rows.Count
        Dim dvRow As DataRowView
        'Tpdid = dvRow.Item("pdid").ToString
        Dim V1, V2, V3, V4, V5 As String
        'SELECT pdid,reqtype,tbllink,pdtype,nofparticipants,totalcost from PDPlanTbl where tbllink=@tbllink and reqtype in ('PT','PL')
        'SELECT pdid as pd, reqtype as rt, tbllink as tl, pdtype as pdt, nofparticipants as np, totalcost as tc from PDPlanTbl where tbllink=@tbllink and reqtype in ('PT','PL')
        For Each dvRow In dV
            Tpdid = dvRow.Item("pdid").ToString()
            V1 = dvRow.Item("reqtype").ToString()
            V2 = dvRow.Item("tbllink").ToString()
            V3 = dvRow.Item("pdtype").ToString()
            V5 = dvRow.Item("totalcost").ToString()
            V4 = dvRow.Item("nofparticipants").ToString()
        Next

        'If (TotRec >= 2) Then
        '    'Dim dvRow As DataRowView
        '    'For Each dvRow In dV
        '    '    'V1 = dvRow.Item("pdid").ToString()
        '    '    'V2 = dvRow.Item("reqtype").ToString()
        '    '    'V1 = dvRow.Item("tbllink").ToString()
        '    '    'V2 = dvRow.Item("pdtype").ToString()
        '    '    'MsgBox1 = MessageBox.Show(V1)
        '    'If (db data pdtype=Local value) Then
        '    '    Return
        '    'End If
        '    'Next
        'End If

        'Return Tpdid
        Return ds

    End Function

    Public Function GetMicroData(ByVal PraMe01 As String, ByVal SchName02 As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetMicroData", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe01)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName02)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "MicroData01")
        Return ds

    End Function

    Public Function deletepdrecbytbllink(ByVal TblLink As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("deletepdrecbytbllink", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtTblLink As SqlParameter = New SqlParameter("@tbllink", TblLink)
        sda.SelectCommand.Parameters.Add(txtTblLink)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "DleRec01")
        Return ds
    End Function
    Public Function UpdandDeleteCDRec(ByVal param As String, ByVal pdid As String, ByVal numofp As String, ByVal totcost As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("UpdandDeleteCDRec", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim txtPdid As SqlParameter = New SqlParameter("@pdid", pdid)
        sda.SelectCommand.Parameters.Add(txtPdid)

        Dim txtnumofp As SqlParameter = New SqlParameter("@numofp", numofp)
        sda.SelectCommand.Parameters.Add(txtnumofp)

        Dim txttotcost As SqlParameter = New SqlParameter("@totcost", totcost)
        sda.SelectCommand.Parameters.Add(txttotcost)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "upanddele")
        Dim dV As New DataView(ds.Tables("upanddele"))

        'Dim TotRec As Integer = 0
        'TotRec = dV.Table.Rows.Count

        Return ds

    End Function

    Public Function CventData(ByVal pdCcode As String, ByVal empno As String, ByVal SchName As String, ByVal email As String) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        'Create a connection to the SQL Server.
        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())

        'Create a DataAdapter, and then provide the name of the stored procedure.
        MyDataAdapter = New SqlDataAdapter("cventdata", MyConnection)

        'Set the command type as StoredProcedure.
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@coursecode", SqlDbType.VarChar, 250))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@coursecode").Value = pdCcode.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@empno", SqlDbType.VarChar, 10))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@empno").Value = empno.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@emailadd", SqlDbType.VarChar, 100))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@emailadd").Value = email.Trim

        'Create and add an output parameter to Parameters collection. 
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsgToBeReturned", SqlDbType.VarChar, 5))

        'Set the direction for the parameter. This parameter returns the Rows returned.
        MyDataAdapter.SelectCommand.Parameters("@ErrMsgToBeReturned").Direction = ParameterDirection.Output

        '-----------------------------------------------------------------------------------------------------
        'Dim txtScopeID As SqlParameter = New SqlParameter("@sid", SqlDbType.Int)
        'MyDataAdapter.SelectCommand.Parameters.Add(txtScopeID)
        'txtScopeID.Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output
        '-----------------------------------------------------------------------------------------------------

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "SeeEvent01") 'Fill the DataSet with the rows returned.

        'Get the number of rows returned, and then assign it to the Label control.
        'lblRowCount.Text = DS.Tables(0).Rows.Count().ToString() & " Rows Found!"

        '@coursecode value
        'LblErrMsg.Text = MyDataAdapter.SelectCommand.Parameters(0).Value

        '@empno value
        'LblErrMsg.Text = MyDataAdapter.SelectCommand.Parameters(1).Value

        '@schoolname value
        'LblErrMsg.Text = MyDataAdapter.SelectCommand.Parameters(2).Value

        '@ErrMsgToBeReturned
        'LblErrMsg.Text = MyDataAdapter.SelectCommand.Parameters(3).Value

        Dim RtnResult As String = ""
        RtnResult = MyDataAdapter.SelectCommand.Parameters(4).Value
        'RtnResult = sda.SelectCommand.Parameters("@ErrMsgToBeReturned").Value

        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        ''Set the data source for the DataGrid as the DataSet that holds the rows.
        'Grdauthors.DataSource = DS.Tables("AuthorsByLastName").DefaultView

        ''Bind the DataSet to the DataGrid. 
        ''NOTE: If you do not call this method, the DataGrid is not displayed!
        'Grdauthors.DataBind()

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        Return RtnResult

    End Function
    Public Function GetPDBalanceBothLT(ByVal SchName As String, ByVal pdNeedYr As String) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        'Create a connection to the SQL Server.
        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())

        'Create a DataAdapter, and then provide the name of the stored procedure.
        MyDataAdapter = New SqlDataAdapter("sp4GetPDBalanceBothLT", MyConnection)

        'Set the command type as StoredProcedure.
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyear", SqlDbType.VarChar, 20))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@pdyear").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@TrvBal", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LocalBal", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MsgStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "LTBalance01") 'Fill the DataSet with the rows returned.

        Dim SPMsgStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""
        Dim RtnRst01 As Decimal = 0.0
        Dim RtnRst02 As Decimal = 0.0

        RtnRst01 = MyDataAdapter.SelectCommand.Parameters(2).Value
        'RtnRst01 = MyDataAdapter.SelectCommand.Parameters("@TrvBal").Value
        'TrvTotAmt = MyDataAdapter.SelectCommand.Parameters(2).Value

        RtnRst02 = MyDataAdapter.SelectCommand.Parameters(3).Value
        'RtnRst02 = MyDataAdapter.SelectCommand.Parameters("@LocalBal").Value
        'LocTotAmt = MyDataAdapter.SelectCommand.Parameters(3).Value

        SPMsgStatus = MyDataAdapter.SelectCommand.Parameters("@MsgStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        'TrvTotAmt = RtnRst01
        'LocTotAmt = RtnRst02

        MsgStus = "" & SPMsgStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        'To find out consultant's total fees
        Dim TctotAmt As Integer = 0
        TctotAmt = GetConsultantFees(SchName, pdNeedYr)

        TrvTotAmt = RtnRst01
        LocTotAmt = (RtnRst02 - TctotAmt)

        Return RtnRst01
    End Function

    Public Function GetConsultantFees(tschname As String, ByVal tpdyr As String) As Integer
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("sp4GetConsultantFees", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schname", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schname").Value = tschname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Ctotfees", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CtotFees1")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        Dim RtnRst As Decimal = 0.0
        RtnRst = MyDataAdapter.SelectCommand.Parameters("@Ctotfees").Value
        'RtnRst = MyDataAdapter.SelectCommand.Parameters(2).Value

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        'If (RtnRst <= 0) Then RtnRst = 0

        Return RtnRst

    End Function

    Public Function GetPDBalanceBothLTsummary(ByVal SchName As String, ByVal pdNeedYr As String) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        'Create a connection to the SQL Server.
        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())

        'Create a DataAdapter, and then provide the name of the stored procedure.
        MyDataAdapter = New SqlDataAdapter("sp4GetPDBalanceBothLTsummary", MyConnection)

        'Set the command type as StoredProcedure.
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyear", SqlDbType.VarChar, 20))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@pdyear").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@travelbudgeted", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@travelallocated", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@localbudgeted", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@localallocated", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@balance", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ovallbudgeted", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@allocatedlocamt", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@allocatedtrvamt", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@TrvBal", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@LocalBal", SqlDbType.Int)).Direction = ParameterDirection.Output

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@MsgStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "LTBalanceSum01") 'Fill the DataSet with the rows returned.

        Dim SPMsgStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""
        Dim RtnRst01 As Decimal = 0
        Dim RtnRst02 As Decimal = 0
        Dim RtnRst03 As Decimal = 0
        Dim RtnRst04 As Decimal = 0
        Dim RtnRst05 As Decimal = 0
        Dim RtnRst06 As Decimal = 0
        Dim RtnRst07 As Decimal = 0
        Dim RtnRst08 As Decimal = 0
        Dim RtnRst09 As Decimal = 0
        Dim RtnRst10 As Decimal = 0

        RtnRst01 = If(MyDataAdapter.SelectCommand.Parameters(2).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(2).Value)
        'RtnRst01 = MyDataAdapter.SelectCommand.Parameters("@travelbudgeted").Value
        'TravelBudgeted = MyDataAdapter.SelectCommand.Parameters(2).Value

        RtnRst02 = If(MyDataAdapter.SelectCommand.Parameters(3).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(3).Value)
        'RtnRst02 = MyDataAdapter.SelectCommand.Parameters("@travelallocated").Value
        'TravelAllocated = MyDataAdapter.SelectCommand.Parameters(3).Value

        RtnRst03 = If(MyDataAdapter.SelectCommand.Parameters(4).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(4).Value)
        'RtnRst03 = MyDataAdapter.SelectCommand.Parameters("@localbudgeted").Value
        'LocalBudgeted = MyDataAdapter.SelectCommand.Parameters(4).Value

        RtnRst04 = If(MyDataAdapter.SelectCommand.Parameters(5).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(5).Value)
        'RtnRst04 = MyDataAdapter.SelectCommand.Parameters("@localallocated").Value
        'LocalAllocated = MyDataAdapter.SelectCommand.Parameters(5).Value

        RtnRst05 = If(MyDataAdapter.SelectCommand.Parameters(6).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(6).Value)
        'RtnRst05 = MyDataAdapter.SelectCommand.Parameters("@balance").Value
        'Balance = MyDataAdapter.SelectCommand.Parameters(6).Value

        RtnRst06 = If(MyDataAdapter.SelectCommand.Parameters(7).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(7).Value)
        'RtnRst06 = MyDataAdapter.SelectCommand.Parameters("@ovallbudgeted").Value
        'Ovallbudgeted = MyDataAdapter.SelectCommand.Parameters(7).Value

        RtnRst07 = If(MyDataAdapter.SelectCommand.Parameters(8).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(8).Value)
        'RtnRst07 = MyDataAdapter.SelectCommand.Parameters("@allocatedlocamt").Value
        'AllocatedLocAmt = MyDataAdapter.SelectCommand.Parameters(8).Value

        RtnRst08 = If(MyDataAdapter.SelectCommand.Parameters(9).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(9).Value)
        'RtnRst08 = MyDataAdapter.SelectCommand.Parameters("@ovallbudgeted").Value
        'AllocatedTrvAmt = MyDataAdapter.SelectCommand.Parameters(9).Value

        RtnRst09 = If(MyDataAdapter.SelectCommand.Parameters(10).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(10).Value)
        'RtnRst09 = MyDataAdapter.SelectCommand.Parameters("@LocalBal").Value
        'LocalBal = MyDataAdapter.SelectCommand.Parameters(10).Value

        RtnRst10 = If(MyDataAdapter.SelectCommand.Parameters(11).Value Is DBNull.Value, 0, MyDataAdapter.SelectCommand.Parameters(11).Value)
        'RtnRst10 = MyDataAdapter.SelectCommand.Parameters("@TrvBal").Value
        'TrvBal = MyDataAdapter.SelectCommand.Parameters(11).Value

        SPMsgStatus = MyDataAdapter.SelectCommand.Parameters("@MsgStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        TravelBudgeted = RtnRst01
        TravelAllocated = RtnRst02
        LocalBudgeted = RtnRst03
        LocalAllocated = RtnRst04
        Balance = RtnRst05
        OvallBudgeted = RtnRst06
        AllocatedLocAmt = RtnRst07
        AllocatedTrvAmt = RtnRst08

        'LocalBal = RtnRst10
        'TrvBal = RtnRst09

        MsgStus = "" & SPMsgStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        'To find out consultant's total fees
        Dim TctotAmt As Integer = 0
        TctotAmt = GetConsultantFees(SchName, pdNeedYr)

        'TrvTotAmt = RtnRst01
        'LocTotAmt = (RtnRst02 - TctotAmt)

        LocalBal = (RtnRst10 - TctotAmt)
        TrvBal = RtnRst09

        Return RtnRst01
    End Function

    Public Function GetSchStatisticalData(ByVal Param1 As String, ByVal SchName As String, ByVal pdNeedYr As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        'Create a connection to the SQL Server.
        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())

        'Create a DataAdapter, and then provide the name of the stored procedure.
        MyDataAdapter = New SqlDataAdapter("GetSchStatisticalData", MyConnection)

        'Set the command type as StoredProcedure.
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 20))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param1

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "SchStatData") 'Fill the DataSet with the rows returned.
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        Return DS

    End Function

    Public Function GetSchStatisticalData02(ByVal Param1 As String, ByVal PDCateGory As String, ByVal SchName As String, ByVal pdNeedYr As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("GetSchStatisticalData02", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param1

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdcategory", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@pdcategory").Value = PDCateGory.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "SchStatData") 'Fill the DataSet with the rows returned.
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        Return DS

    End Function

    Public Function FindStaffByPDCcode(ByVal Param1 As String, ByVal PDCateGory As String, ByVal SchName As String, ByVal pdNeedYr As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("FindStaffByPDCcode", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param1

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdcategory", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@pdcategory").Value = PDCateGory.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "TotStaff4IBwQ") 'Fill the DataSet with the rows returned.
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        Return DS

    End Function

    Public Function QFSchoolYear(ByVal Act As String, ByVal Tid As Integer, ByVal schyr As String, ByVal cursy As String) As DataSet
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        'Create a connection to the SQL Server.
        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())

        'Create a DataAdapter, and then provide the name of the stored procedure.
        MyDataAdapter = New SqlDataAdapter("schoolyearsp", MyConnection)

        'Set the command type as StoredProcedure.
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Action", SqlDbType.VarChar, 10))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@Action").Value = Act

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@id").Value = Tid

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolyear", SqlDbType.VarChar, 12))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@schoolyear").Value = schyr.Trim

        'Create and add a parameter to Parameters collection for the stored procedure.
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@curschyear", SqlDbType.VarChar, 5))

        'Assign the search value to the parameter.
        MyDataAdapter.SelectCommand.Parameters("@curschyear").Value = cursy.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "qfSchYrData") 'Fill the DataSet with the rows returned.
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose() 'Dispose of the DataAdapter.
        MyConnection.Close() 'Close the connection.

        Return DS
        DS.Dispose()

    End Function

    Public Function EmpMasterTbl(ByVal Param As String, ByVal SchName As String, ByVal DeptName As String, ByVal Empno As String, ByVal Fullname As String, ByVal Firstname As String, ByVal Lastname As String, ByVal Catry As String, ByVal Posn As String, ByVal Emailid As String, ByVal Stus As String, ByVal id As String) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("EmpMasterSAMD", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@SchName", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@SchName").Value = SchName

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@DeptName", SqlDbType.VarChar, 30))
        MyDataAdapter.SelectCommand.Parameters("@DeptName").Value = DeptName

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Empno", SqlDbType.VarChar, 8))
        MyDataAdapter.SelectCommand.Parameters("@Empno").Value = Empno

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Fullname", SqlDbType.VarChar, 30))
        MyDataAdapter.SelectCommand.Parameters("@Fullname").Value = Fullname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Firstname", SqlDbType.VarChar, 15))
        MyDataAdapter.SelectCommand.Parameters("@Firstname").Value = Firstname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Lastname", SqlDbType.VarChar, 15))
        MyDataAdapter.SelectCommand.Parameters("@Lastname").Value = Lastname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Catry", SqlDbType.VarChar, 15))
        MyDataAdapter.SelectCommand.Parameters("@Catry").Value = Catry

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Posn", SqlDbType.VarChar, 15))
        MyDataAdapter.SelectCommand.Parameters("@Posn").Value = Posn

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Emailid", SqlDbType.VarChar, 30))
        MyDataAdapter.SelectCommand.Parameters("@Emailid").Value = Emailid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@Stus", SqlDbType.VarChar, 15))
        MyDataAdapter.SelectCommand.Parameters("@Stus").Value = Stus

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@RefID", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@RefID").Value = id

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "EmpMstrData")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus
    End Function
    Public Function CheckEmpnoFrmEmpMaster01(ByVal Emailid As String, ByVal EmpNu As String) As String
        Dim sda As SqlDataAdapter = New SqlDataAdapter("CheckEmpnoFrmEmpMaster", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TxtEmailid As SqlParameter = New SqlParameter("@Emailid", Emailid)
        sda.SelectCommand.Parameters.Add(TxtEmailid)

        Dim TxtEmpno As SqlParameter = New SqlParameter("@empno", EmpNu)
        sda.SelectCommand.Parameters.Add(TxtEmpno)

        Dim TEmpno As String = ""
        Dim TEmailid As String = ""
        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "EmpInfo1")
        Dim dv As New DataView(ds.Tables("EmpInfo1"))
        If dv.Table.Rows.Count <> 0 Then
            TEmpno = "" & dv.Table.Rows(0)("Empno")
            TEmailid = "" & dv.Table.Rows(0)("Email")
        End If
        dv.Dispose()
        ds.Clear()
        ds.Dispose()
        TEmpno = TEmpno.Trim
        TEmailid = TEmailid.Trim

        If Len(TEmpno) > 0 Then
            Return TEmpno
        ElseIf Len(TEmailid) > 0 Then
            Return TEmailid
        Else
            Return TEmpno
        End If

    End Function

    Public Function PDFundTransfer(ByVal Param As String, ByVal SchName As String, ByVal pdyear As String, ByVal usramt As String) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("sp4PDFundTransfer", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 2))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyear", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyear").Value = pdyear

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@usramt", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@usramt").Value = usramt

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "PDFT")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus
    End Function

    Public Function EmpInfo4RdModification(ByVal lastname As String, ByVal email As String, ByVal coursecode As String, ByVal empno As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("GetEmpInfo4RdModification", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@lastname", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@lastname").Value = lastname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 30))
        MyDataAdapter.SelectCommand.Parameters("@email").Value = email

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@coursecode", SqlDbType.VarChar, 500))
        MyDataAdapter.SelectCommand.Parameters("@coursecode").Value = coursecode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@empno", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@empno").Value = empno

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "EmpData4RdModi")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS
    End Function

    Public Function cventStatusModify(ByVal pdid As String) As Boolean

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("cventStatusModify", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdid", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdid").Value = pdid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CventStusModify")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As Boolean = False
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus
    End Function

    Public Function GetSchoolsPDDetails(ByVal Param As String, ByVal pdyear As String, ByVal Schoolname As String, ByVal category As String, ByVal subcategory As String, ByVal schoolFname As String) As DataSet
        ' @param, @pdyear, @schoolname, @category, @subcategory, @schoolFname

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchoolsPDDetails", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtcategory As SqlParameter = New SqlParameter("@category", category)
        sda.SelectCommand.Parameters.Add(txtcategory)

        Dim txtsubcategory As SqlParameter = New SqlParameter("@subcategory", subcategory)
        sda.SelectCommand.Parameters.Add(txtsubcategory)

        Dim txtSchFname As SqlParameter = New SqlParameter("@schoolFname", schoolFname)
        sda.SelectCommand.Parameters.Add(txtSchFname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SchPDdetails01")
        Return ds

    End Function

    Public Function GetSchoolsPDDetails02(ByVal Param As String, ByVal pdyear As String, ByVal Schoolname As String, ByVal category As String, ByVal subcategory As String, ByVal schoolFname As String) As DataSet
        ' @param, @pdyear, @schoolname, @category, @subcategory, @schoolFname

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchoolsPDDetails02", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtcategory As SqlParameter = New SqlParameter("@category", category)
        sda.SelectCommand.Parameters.Add(txtcategory)

        Dim txtsubcategory As SqlParameter = New SqlParameter("@subcategory", subcategory)
        sda.SelectCommand.Parameters.Add(txtsubcategory)

        Dim txtSchFname As SqlParameter = New SqlParameter("@schoolFname", schoolFname)
        sda.SelectCommand.Parameters.Add(txtSchFname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SchPDdetails02")
        Return ds

    End Function
    Public Function GetSchoolsPDDetails03(ByVal Param As String, ByVal pdyear As String, ByVal Schoolname As String, ByVal category As String, ByVal subcategory As String, ByVal schoolFname As String) As DataSet
        ' @param, @pdyear, @schoolname, @category, @subcategory, @schoolFname

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchoolsPDDetails03", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtcategory As SqlParameter = New SqlParameter("@category", category)
        sda.SelectCommand.Parameters.Add(txtcategory)

        Dim txtsubcategory As SqlParameter = New SqlParameter("@subcategory", subcategory)
        sda.SelectCommand.Parameters.Add(txtsubcategory)

        Dim txtSchFname As SqlParameter = New SqlParameter("@schoolFname", schoolFname)
        sda.SelectCommand.Parameters.Add(txtSchFname)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SchPDdetails03")
        Return ds

    End Function

    Public Function TempSolutions(ByVal PraMe01 As String, ByVal SchName02 As String, ByVal pdyear As String, ByVal Prame02 As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("TempSolutions", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtPraMe01 As SqlParameter = New SqlParameter("@param", PraMe01)
        sda.SelectCommand.Parameters.Add(txtPraMe01)

        Dim txtSchname02 As SqlParameter = New SqlParameter("@schoolname", SchName02)
        sda.SelectCommand.Parameters.Add(txtSchname02)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtPraMe02 As SqlParameter = New SqlParameter("@param02", Prame02)
        sda.SelectCommand.Parameters.Add(txtPraMe02)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "TempSolu")
        Return ds
    End Function

    Public Function GetSchoolsPDDetails04(ByVal Param As String, ByVal pdyear As String, ByVal Schoolname As String, ByVal category As String, ByVal subcategory As String, ByVal schoolFname As String, ByVal TBudgeted As String, ByVal TAllocated As String, ByVal pdtype As String, ByVal numbr As String) As DataSet
        '@param,@pdyear,@schoolname,@category,@subcategory,@schoolFname,@deptstusb,@deptstusa,@pdtype,@numbr

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchoolsPDDetails04", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtcategory As SqlParameter = New SqlParameter("@category", category)
        sda.SelectCommand.Parameters.Add(txtcategory)

        Dim txtsubcategory As SqlParameter = New SqlParameter("@subcategory", subcategory)
        sda.SelectCommand.Parameters.Add(txtsubcategory)

        Dim txtSchFname As SqlParameter = New SqlParameter("@schoolFname", schoolFname)
        sda.SelectCommand.Parameters.Add(txtSchFname)

        Dim txtTBudgeted As SqlParameter = New SqlParameter("@deptstusb", TBudgeted)
        sda.SelectCommand.Parameters.Add(txtTBudgeted)

        Dim txtTAllocated As SqlParameter = New SqlParameter("@deptstusa", TAllocated)
        sda.SelectCommand.Parameters.Add(txtTAllocated)

        Dim txtpdType As SqlParameter = New SqlParameter("@pdtype", pdtype)
        sda.SelectCommand.Parameters.Add(txtpdType)

        Dim txtNumbr As SqlParameter = New SqlParameter("@numbr", numbr)
        sda.SelectCommand.Parameters.Add(txtNumbr)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SchPDdetails04")
        Return ds

    End Function

    Public Function Find_PDCoursecode(ByVal param As String, ByVal schname As String, ByVal pdyr As String) As DataSet
        Dim sda As SqlDataAdapter = New SqlDataAdapter("Find_PDCoursecode", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParam As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParam)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", schname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtPDYr As SqlParameter = New SqlParameter("@pdyr", pdyr)
        sda.SelectCommand.Parameters.Add(txtPDYr)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "PDCcode")
        Return ds
    End Function

    Public Function Find_PDCoursecodeStaffs(ByVal Param1 As String, ByVal SchName As String, ByVal pdccode As String, ByVal pdNeedYr As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("Find_PDCoursecodeStaffs", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param1
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schoolname", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@schoolname").Value = SchName.Trim
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdcoursecode", SqlDbType.VarChar, 250))
        MyDataAdapter.SelectCommand.Parameters("@pdcoursecode").Value = pdccode.Trim
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = pdNeedYr.Trim

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet() 'Create a new DataSet to hold the records.
        MyDataAdapter.Fill(DS, "PDCodeStaffs") 'Fill the DataSet with the rows returned.
        'Dim Dv As New DataView(DS.Tables("PDCodeStaffs"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()

        Return DS

    End Function

    Public Function GetSchPDSummaryRpt(ByVal Param As String, ByVal pdyear As String, ByVal pdtype As String, ByVal Schoolname As String, ByVal ccode As String, ByVal TDeptstus As String, ByVal lastname As String, ByVal email As String, ByVal empno As String) As DataSet
        'LastName Email empno

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetSchPDSummaryRpt", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim TXTparam As SqlParameter = New SqlParameter("@param", Param)
        sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim txtpdType As SqlParameter = New SqlParameter("@pdtype", pdtype)
        sda.SelectCommand.Parameters.Add(txtpdType)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtccode As SqlParameter = New SqlParameter("@ccode", ccode)
        sda.SelectCommand.Parameters.Add(txtccode)

        Dim txtTDeptstus As SqlParameter = New SqlParameter("@deptstus", TDeptstus)
        sda.SelectCommand.Parameters.Add(txtTDeptstus)

        Dim TXTlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(TXTlastname)

        Dim txtemail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtemail)

        Dim txtempno As SqlParameter = New SqlParameter("@empno", empno)
        sda.SelectCommand.Parameters.Add(txtempno)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "SchPDSumRpt")
        Return ds

    End Function

    Public Function DateChk(ByVal UsrInput As String) As Boolean
        Try
            If UsrInput.Trim = "" Then
                Return True
            Else
                ''Solution 01-Start
                Dim Tdte As Date = CDate(UsrInput)
                UsrInput = Tdte.ToString("dd/MM/yyyy")
                Dim UInp As String()
                Dim TDate As Integer = 0
                Dim TMonth As Integer = 0
                Dim TYear As Integer = 0
                UInp = UsrInput.Split("/")
                Int32.TryParse(UInp(0), TDate)
                Int32.TryParse(UInp(1), TMonth)
                Int32.TryParse(UInp(2), TYear)

                If (TDate = 0 Or Len(TDate.ToString()) > 2) Then Return False
                If (TMonth = 0 Or Len(TMonth.ToString()) > 2) Then Return False
                If (TYear = 0 Or Len(TYear.ToString()) > 4) Then Return False
                'If (TYear = 0 Or Len(TYear) < 3 Or Len(TYear) > 4) Then Return False
                ''Solution 01-End

                'Solution 00-Start
                Dim Dt As Date
                If Date.TryParse(UsrInput, Dt.ToString("dd/MM/yyyy")) Then
                    Return True
                Else
                    Return False
                End If
                'Solution 00-End

            End If
        Catch ex As Exception
            Dim ErrMsg As String = ex.Message.ToString
            Return False
        End Try

    End Function

    Public Function LoginSAMD4ro(ByVal param As String, ByVal Tid As String, ByVal email As String, ByVal password As String, ByVal status As String, ByVal role As String, ByVal organization As String) As String
        Dim TotRec As Integer = 0
        Dim Emsg As String = ""
        'Dim Rst As String = "Ok"

        Try
            Dim sda As SqlDataAdapter = New SqlDataAdapter("LoginSAMD4ro", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
            sda.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
            sda.SelectCommand.Parameters.Add(txtParaM)

            Dim txtID As SqlParameter = New SqlParameter("@id", Tid)
            sda.SelectCommand.Parameters.Add(txtID)

            Dim txtemail As SqlParameter = New SqlParameter("@email", email)
            sda.SelectCommand.Parameters.Add(txtemail)

            Dim txtpassword As SqlParameter = New SqlParameter("@password", password)
            sda.SelectCommand.Parameters.Add(txtpassword)

            Dim txtstatus As SqlParameter = New SqlParameter("@status", status)
            sda.SelectCommand.Parameters.Add(txtstatus)

            Dim txtrole As SqlParameter = New SqlParameter("@role", role)
            sda.SelectCommand.Parameters.Add(txtrole)

            Dim txtorganization As SqlParameter = New SqlParameter("@organization", organization)
            sda.SelectCommand.Parameters.Add(txtorganization)

            'Dim Trst As String = ""
            'Trst = "INSERT INTO Login (Email,Password,Status,Role,Organization) VALUES('" & email & "','" & password & "','" & status & "','" & role & "','" & organization & "')"
            'Trst = "INSERT INTO Login (Email,Password,Status,Role,Organization) VALUES(@email,@password,@status,@role,@organization)"

            Dim ds As DataSet = New DataSet()
            sda.Fill(ds, "LoginDetail")
            'Dim dV As New DataView(ds.Tables("LoginDetail"))
            'TotRec = dV.Table.Rows.Count
            ''Dim dvRow As DataRowView
            'For Each dvRow In dV
            '    'DrpDwn = dvRow.Item("edistatus").ToString()
            '    'MsgBox1 = MessageBox.Show(DrpDwn)
            'Next
        Catch ex As Exception
            Emsg = Err.Description()
        End Try
        'Return Convert.ToString(TotRec)

        If Err.Number = 0 Then
            Return Convert.ToString(TotRec)
        Else
            Return Emsg
        End If

    End Function

    Public Function LoginRoSAMD4GridV(ByVal param As String, ByVal Tid As String, ByVal email As String, ByVal password As String, ByVal status As String, ByVal role As String, ByVal organization As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("LoginSAMD4ro", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@param", param)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim txtID As SqlParameter = New SqlParameter("@id", Tid)
        sda.SelectCommand.Parameters.Add(txtID)

        Dim txtemail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtemail)

        Dim txtpassword As SqlParameter = New SqlParameter("@password", password)
        sda.SelectCommand.Parameters.Add(txtpassword)

        Dim txtstatus As SqlParameter = New SqlParameter("@status", status)
        sda.SelectCommand.Parameters.Add(txtstatus)

        Dim txtrole As SqlParameter = New SqlParameter("@role", role)
        sda.SelectCommand.Parameters.Add(txtrole)

        Dim txtorganization As SqlParameter = New SqlParameter("@organization", organization)
        sda.SelectCommand.Parameters.Add(txtorganization)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "LoginList4ro")

        'Dim TotRec As Integer = 0
        'Dim dV As New DataView(ds.Tables("LoginList4ro"))
        'TotRec = dV.Table.Rows.Count
        'Dim dvRow As DataRowView
        'For Each dvRow In dV
        '    'DrpDwn = dvRow.Item("edistatus").ToString()
        '    'MsgBox1 = MessageBox.Show(DrpDwn)
        'Next

        'Dim Emsg As String = ""
        'Emsg = Err.Description()
        Return ds

    End Function

    Public Function GetUsrCredRec(ByVal id As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetUsrCredRec", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtParaM As SqlParameter = New SqlParameter("@id", id)
        sda.SelectCommand.Parameters.Add(txtParaM)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "UsrCredRec")
        Return ds

    End Function

    Public Function GetCourseStartDate(ByVal cCode As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("GetCourseStartDate", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@coursecode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@coursecode").Value = cCode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CourseStartDte")
        'Dim Dv As New DataView(DS.Tables("CourseStartDte"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS
    End Function

    Public Function GetSemesterNo(ByVal PDte As String) As String
        If PDte.Trim = "" Then Exit Function
        Try
            Dim Sem2 = New String() {"January", "February", "March", "April", "May", "June"}
            Dim Sem1 = New String() {"July", "August", "September", "October", "November", "December"}
            Dim Mnth0 As Date = Convert.ToDateTime(PDte)
            'Dim UsrSctMonth As String = MonthName(Mnth0.Month(), True)
            Dim UsrSctMonth As String = Mnth0.ToString("MMMM")

            'Imports System.Globalization
            'Mnth0 = DateTime.ParseExact(PDte, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)
            ''dd/mm/yyyy
            'TMnth = Mnth0.ToString("D", CultureInfo.CreateSpecificCulture("en-NZ"))

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
            Return SemNo
            'TxtSemester.Text = SemNo
        Catch ex As Exception
            Dim ErrMsg As String = ex.Message.ToString
            Return String.Empty
        End Try

    End Function

    Public Function CourseStartDteSAMD(ByVal Param As String, ByVal id As String, ByVal ccode As String, ByVal startdte As Date, ByVal Status As Boolean, ByVal RgDL As Date) As String

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CourseStartDteSAMD", MyConnection)

        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.VarChar, 18))
        MyDataAdapter.SelectCommand.Parameters("@id").Value = id

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ccode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@ccode").Value = ccode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@startdte", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@startdte").Value = startdte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@status", SqlDbType.Bit))
        MyDataAdapter.SelectCommand.Parameters("@status").Value = Status

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@regdeadline", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@regdeadline").Value = RgDL

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CourseStartDate")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus
    End Function

    Public Function CourseStartDteSAMD_DS(ByVal Param As String, ByVal id As String, ByVal ccode As String, ByVal startdte As Date, ByVal Status As Boolean, ByVal RgDL As Date) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CourseStartDteSAMD", MyConnection)

        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.VarChar, 18))
        MyDataAdapter.SelectCommand.Parameters("@id").Value = id

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ccode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@ccode").Value = ccode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@startdte", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@startdte").Value = startdte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@status", SqlDbType.Bit))
        MyDataAdapter.SelectCommand.Parameters("@status").Value = Status

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@regdeadline", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@regdeadline").Value = RgDL

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CourseStartDate_DS")
        'Dim Dv As New DataView(DS.Tables("SchStatData"))

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function RecValidation(ByVal Param As String, ByVal ccode As String, ByVal startdte As Date) As Boolean

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("RecValidation", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ccode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@ccode").Value = ccode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@startdte", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@startdte").Value = startdte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        Dim PDCcode As String = ""
        'Dim CstartDate As Date = "1/1/1900"
        Dim CstartDate As String = ""
        Dim Duplic As Boolean = False

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CheckingRecs")
        Dim dv As New DataView(DS.Tables("CheckingRecs"))
        If (dv.Table.Rows.Count = 0) Then
            PDCcode = ""
            CstartDate = ""
            Duplic = False
        Else
            PDCcode = "" & dv.Table.Rows(0)("coursecode").ToString()
            CstartDate = "" & dv.Table.Rows(0)("coursesdte").ToString()
            Duplic = True
        End If

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return Duplic

    End Function

    Public Function GetpdplandetailsRO(ByVal Schoolname As String, ByVal dePartMent As String, ByVal deptstus As String, ByVal Tpdtype As String, ByVal lastname As String, ByVal email As String, ByVal coUrSecode As String, ByVal TempNo As String, ByVal TblLnk As String, ByVal pdyear As String) As DataSet

        Dim sda As SqlDataAdapter = New SqlDataAdapter("GetpdplandetailsRO", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        ''ByVal pARAM As String
        'Dim TXTparam As SqlParameter = New SqlParameter("@TableName", pARAM)
        'sda.SelectCommand.Parameters.Add(TXTparam)

        Dim txtSchoolname As SqlParameter = New SqlParameter("@schoolname", Schoolname)
        sda.SelectCommand.Parameters.Add(txtSchoolname)

        Dim txtDePartment As SqlParameter = New SqlParameter("@department", dePartMent)
        sda.SelectCommand.Parameters.Add(txtDePartment)

        Dim txtDeptstus As SqlParameter = New SqlParameter("@deptstus", deptstus)
        sda.SelectCommand.Parameters.Add(txtDeptstus)

        Dim txtTpdtype As SqlParameter = New SqlParameter("@reqtype", Tpdtype)
        sda.SelectCommand.Parameters.Add(txtTpdtype)

        Dim txtlastname As SqlParameter = New SqlParameter("@lastname", lastname)
        sda.SelectCommand.Parameters.Add(txtlastname)

        Dim txtEmail As SqlParameter = New SqlParameter("@email", email)
        sda.SelectCommand.Parameters.Add(txtEmail)

        Dim txtCourSecode As SqlParameter = New SqlParameter("@coursecode", coUrSecode)
        sda.SelectCommand.Parameters.Add(txtCourSecode)

        Dim txtEmpNO As SqlParameter = New SqlParameter("@empno", TempNo)
        sda.SelectCommand.Parameters.Add(txtEmpNO)

        Dim txtTblLnk As SqlParameter = New SqlParameter("@tbllink", TblLnk)
        sda.SelectCommand.Parameters.Add(txtTblLnk)

        Dim txtPDYear As SqlParameter = New SqlParameter("@pdyear", pdyear)
        sda.SelectCommand.Parameters.Add(txtPDYear)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "pdPlanViewRO")
        Return ds

    End Function

    Public Function CRelatedQueries(ByVal Param As String, ByVal ccode As String, ByVal CstartD As Date) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CourseRelatedQueries", MyConnection)

        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ccode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@ccode").Value = ccode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@startdte", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@startdte").Value = CstartD

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CRelatedQuery")
        'Dim Dv As New DataView(DS.Tables("CRelatedQuery"))
        'Return DS

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function NumOfPax(ByVal Param As String, ByVal ccode As String, ByVal pdyr As String, ByVal startdte As Date) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("NumberOfPax", MyConnection)

        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ccode", SqlDbType.VarChar, 100))
        MyDataAdapter.SelectCommand.Parameters("@ccode").Value = ccode

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@startdte", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@startdte").Value = startdte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyear", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyear").Value = pdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "NoOfpax")
        'Dim Dv As New DataView(DS.Tables("NoOfpax"))
        'Return DS

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function GetDeadLine(ByVal Prm As String, ByVal Ccode1 As String, ByVal CstartD As Date) As Date

        Dim cDLine As Date = "1/1/1900"
        Dim Ds0 As DataSet = New DataSet()
        Ds0 = CRelatedQueries(Prm, Ccode1, CstartD)
        Dim Dv0 As New DataView(Ds0.Tables("CRelatedQuery"))
        'Additional information: There is no row at position 0.
        If (Dv0.Table.Rows.Count <> 0) Then
            Dim cSdate As String = "" & IIf(IsDBNull(Dv0.Table.Rows(0)("coursesdte")), "1/1/1900", Dv0.Table.Rows(0)("coursesdte"))
            Dim RegDL As String = "" & Dv0.Table.Rows(0)("regdeadline")
            RegDL = RegDL.Trim
            If (Not Convert.IsDBNull(RegDL)) Then
                If (RegDL = "1/1/1900" Or RegDL = "1/1/1900 12:00:00 AM" Or RegDL = "") Then
                    cDLine = "1/1/1900"
                Else
                    Dim RegDL02 As Date = Convert.ToDateTime(RegDL)
                    Dim RegDL03 As String = RegDL02.ToString("dd MMM yyyy")
                    cDLine = RegDL03
                End If
            End If
        End If
        Dv0.Dispose()
        Ds0.Dispose()

        Return cDLine

    End Function

    Public Function GetTotalCapacity(ByVal Prm2 As String, ByVal Ccode2 As String, ByVal CStartD As Date) As Integer

        'Get Total Capacity
        Dim Ds1 As DataSet = New DataSet()
        Ds1 = CRelatedQueries(Prm2, Ccode2, CStartD)
        Dim Dv1 As New DataView(Ds1.Tables("CRelatedQuery"))
        Dim MaxStrength As Integer = 0
        MaxStrength = Dv1.Table.Rows(0)("tpax")
        Dv1.Dispose()
        Ds1.Dispose()
        If (MaxStrength <= 0) Then MaxStrength = 0

        Return MaxStrength

    End Function

    Public Function GetRegdTotParti(ByVal Prm1 As String, ByVal Ccode1 As String, ByVal PDyr1 As String, ByVal CstartD As Date) As Integer

        'Get Registered Participants
        Dim NullCheck As Boolean
        Dim Ds2 As DataSet = New DataSet()
        Ds2 = NumOfPax(Prm1, Ccode1, PDyr1, CstartD)
        Dim Dv2 As New DataView(Ds2.Tables("NoOfpax"))
        If Dv2.Table.Rows.Count = 0 Then Return 0
        Dim CurStrength As Integer = 0
        NullCheck = IsDBNull(Dv2.Table.Rows(0)("nop"))
        CurStrength = IIf((IsDBNull(Dv2.Table.Rows(0)("nop"))), 0, Dv2.Table.Rows(0)("nop"))
        Dv2.Dispose()
        Ds2.Dispose()
        If (CurStrength <= 0) Then CurStrength = 0

        Return CurStrength

    End Function

    Public Function SelectConsultantBkedDte(ByVal Tparam As String, ByVal Tcid As Integer, ByVal Ttid As String, ByVal Tbdates As Date, ByVal Tschname As String, ByVal Tpdyr As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CDateBooking", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Tparam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = Tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@tid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@tid").Value = Ttid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@bdates", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@bdates").Value = Tbdates

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schname", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schname").Value = Tschname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = Tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CBkedDteL1")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function ConsultantDateBooking(ByVal Tparam As String, ByVal Tcid As String, ByVal Ttid As String, ByVal Tbdates As Date, ByVal Tschname As String, ByVal Tpdyr As String) As Boolean
        ' This function for Insert / update and confirmations like yes or no
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CDateBooking", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Tparam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = Tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@tid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@tid").Value = Ttid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@bdates", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@bdates").Value = Tbdates

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schname", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schname").Value = Tschname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = Tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "ConsultantDB")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus

    End Function

    Public Function ConsultantTbl(ByVal tparam As String, ByVal tcid As Integer, ByVal tfname As String, ByVal tlname As String, ByVal tidno As String, ByVal tcountry As String, ByVal tcontactno As String, ByVal temail As String, ByVal tmaddress As String, ByVal tnotes As String) As Boolean
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("InsertConsultant", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = tparam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@fname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@fname").Value = tfname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@lname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@lname").Value = tlname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@idno", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@idno").Value = tidno

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@country", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@country").Value = tcountry

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@contactno", SqlDbType.VarChar, 20))
        MyDataAdapter.SelectCommand.Parameters("@contactno").Value = tcontactno

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 60))
        MyDataAdapter.SelectCommand.Parameters("@email").Value = temail

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@maddress", SqlDbType.VarChar, 200))
        MyDataAdapter.SelectCommand.Parameters("@maddress").Value = tmaddress

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@notes", SqlDbType.VarChar, 60))
        MyDataAdapter.SelectCommand.Parameters("@notes").Value = tnotes

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CrAddNew1")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus

    End Function

    Public Function SelectConsultantTbl(ByVal TParam As String, ByVal Tcid As Integer, ByVal Tfname As String, ByVal Tlname As String, ByVal Temail As String) As DataSet

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("getConsultant", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = TParam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = Tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@fname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@fname").Value = Tfname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@lname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@lname").Value = Tlname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 60))
        MyDataAdapter.SelectCommand.Parameters("@email").Value = Temail

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CnslRst1")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function ConsultantView(ByVal TParam As String, ByVal Tfname As String, ByVal Tlname As String, ByVal Temail As String, ByVal Tschname As String, ByVal Tpdyr As String) As DataSet
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("getConsultantView", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = TParam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@fname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@fname").Value = Tfname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@lname", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@lname").Value = Tlname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@email", SqlDbType.VarChar, 60))
        MyDataAdapter.SelectCommand.Parameters("@email").Value = Temail

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schname", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schname").Value = Tschname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = Tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CnslRstView")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function
    Public Function InsertConsultantTopics(ByVal tparam As String, ByVal tcid As Integer, ByVal tTopic As String, ByVal tStDte As Date, ByVal tTid As Integer, ByVal tFee As Integer, ByVal tschn As String, ByVal tpdyr As String) As Boolean

        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("InsertConsultantTopic", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = tparam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@topic", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@topic").Value = tTopic

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@stdate", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@stdate").Value = tStDte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@tid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@tid").Value = tTid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@fee", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@fee").Value = tFee

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schn", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schn").Value = tschn

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CTopicAN")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return SPExeStatus
    End Function

    Public Function SelectConstTopics(ByVal tparam As String, ByVal tcid As Integer, ByVal tTopic As String, ByVal tStDte As Date, ByVal tTid As Integer, ByVal tFee As Integer, ByVal tschn As String, ByVal tpdyr As String) As DataSet
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("InsertConsultantTopic", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = tparam

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = tcid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@topic", SqlDbType.VarChar, 50))
        MyDataAdapter.SelectCommand.Parameters("@topic").Value = tTopic

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@stdate", SqlDbType.Date))
        MyDataAdapter.SelectCommand.Parameters("@stdate").Value = tStDte

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@tid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@tid").Value = tTid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@fee", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@fee").Value = tFee

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schn", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schn").Value = tschn

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CTopicList")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function CbookedDateTopic(ByVal Param As String, ByVal tCid As String, ByVal ttid As String, tschname As String, ByVal tpdyr As String) As DataSet
        Dim DS As DataSet
        Dim MyConnection As SqlConnection
        Dim MyDataAdapter As SqlDataAdapter

        MyConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        MyDataAdapter = New SqlDataAdapter("CDateAndTopic", MyConnection)
        MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@param", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@param").Value = Param

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@cid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@cid").Value = tCid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@tid", SqlDbType.Int))
        MyDataAdapter.SelectCommand.Parameters("@tid").Value = ttid

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@schname", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@schname").Value = tschname

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@pdyr", SqlDbType.VarChar, 10))
        MyDataAdapter.SelectCommand.Parameters("@pdyr").Value = tpdyr

        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ExeStatus", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrNo", SqlDbType.Int)).Direction = ParameterDirection.Output
        MyDataAdapter.SelectCommand.Parameters.Add(New SqlParameter("@ErrMsg", SqlDbType.VarChar, 1024)).Direction = ParameterDirection.Output

        DS = New DataSet()
        MyDataAdapter.Fill(DS, "CTopicDate")

        Dim SPExeStatus As String = ""
        Dim SPErrNo As String = ""
        Dim SPErrMsg As String = ""

        SPExeStatus = MyDataAdapter.SelectCommand.Parameters("@ExeStatus").Value.ToString()
        SPErrNo = MyDataAdapter.SelectCommand.Parameters("@ErrNo").Value.ToString()
        SPErrMsg = MyDataAdapter.SelectCommand.Parameters("@ErrMsg").Value.ToString()

        MsgStus = "" & SPExeStatus
        ErrNo = "" & SPErrNo
        ErrDetails = "" & SPErrMsg

        MyDataAdapter.Dispose()
        MyConnection.Close()
        DS.Dispose()

        Return DS

    End Function

    Public Function checkROuser(ByVal username1 As String, ByVal Password1 As String) As String

        Dim sda As SqlDataAdapter = New SqlDataAdapter("checkROuser", System.Configuration.ConfigurationManager.ConnectionStrings("ConStr01").ToString())
        sda.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim txtusername As SqlParameter = New SqlParameter("@username", username1)
        sda.SelectCommand.Parameters.Add(txtusername)

        Dim txtPassword As SqlParameter = New SqlParameter("@Password", Password1)
        sda.SelectCommand.Parameters.Add(txtPassword)

        Dim ds As DataSet = New DataSet()
        sda.Fill(ds, "userRO")
        Dim dv As New DataView(ds.Tables("userRO"))
        If dv.Table.Rows.Count = 0 Then
            Return ""
            User = ""
            School = ""
            URole = ""
        Else
            User = dv.Table.Rows(0)("email")
            School = dv.Table.Rows(0)("organization")
            URole = "" & dv.Table.Rows(0)("Role")
            'Session("schoolname") = School
            Return School
        End If
        'Return ds
    End Function


End Class