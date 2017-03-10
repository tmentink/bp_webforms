Imports System.Web.Services

<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="Boilerplate")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class AdminWebService
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    Public Function Login(ByVal loginMethod As String, ByVal password As String) As String
        Try
            Return Admin.Login.Login(loginMethod, password)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminWebService.Login()")
            Return ""
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function RequestPasswordReset(ByVal loginMethod As String) As String
        Try
            Return Admin.Password.RequestPasswordReset(loginMethod)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminWebService.RequestPasswordReset()")
            Return ""
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function ResetPassword(ByVal token As String, ByVal password As String) As String
        Try
            Return Admin.Password.ResetPassword(token, password)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminWebService.ResetPassword()")
            Return ""
        End Try
    End Function
End Class