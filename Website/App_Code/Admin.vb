Imports System.Data
Imports AppMail.Actions
Imports Crypto.Hashing
Imports ServerVariables
Imports Validation.Data

Namespace Admin

    Public Class AppUser
        Public Property UserID As Integer
        Public Property Username As String
        Public Property Fullname As String
        Public Property Firstname As String
        Public Property Lastname As String
        Public Property Email As String

        Sub New(ByVal dr As DataRow)
            UserID = dr("UserID")
            Username = dr("UserName")
            Fullname = dr("FirstName") & " " & dr("LastName")
            Firstname = dr("FirstName")
            Lastname = dr("LastName")
            Email = dr("Email")
        End Sub

        Public Shared Function Exists() As Boolean
            Return HttpContext.Current.Session IsNot Nothing AndAlso
                   HttpContext.Current.Session("AppUser") IsNot Nothing
        End Function
    End Class

    Public Class Login
        Public Shared Function Login(ByVal loginMethod As String, ByVal password As String) As Boolean
            Dim ds As DataSet = AdminData.GetUserByLoginMethod(loginMethod)
            If HasData(ds) Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)

                If UserIsLocked(dr) OrElse
                   PasswordIsValid(password, dr) = False Then
                    Return False
                End If

                SaveUserToSession(dr)
                Return True
            End If

            Return False
        End Function

        Public Shared Sub VerifyLogin()
            If AppUser.Exists() Then

            ElseIf GetServerName() = "localhost" Then
                SetDeveloperSession()
            Else
                HttpContext.Current.Response.Redirect("~/login.aspx")
            End If
        End Sub


        'Private Subs and Functions
        '-------------------------------------------
        Private Shared Sub SetDeveloperSession()
            Dim localPath As String = GetPhysicalPath().ToLower()

            If InStr(localPath, "tmentink") > 0 Then
                Dim ds As DataSet = AdminData.GetUserByLoginMethod("tmentink")
                SaveUserToSession(ds.Tables(0).Rows(0))
            Else
                HttpContext.Current.Response.Redirect("~/login.aspx")
            End If
        End Sub

        Private Shared Sub SaveUserToSession(ByVal dr As DataRow)
            HttpContext.Current.Session("AppUser") = New AppUser(dr)
        End Sub

        Private Shared Function UserIsLocked(dr As DataRow) As Boolean
            Return Convert.ToBoolean(dr("IsLocked"))
        End Function

        Private Shared Function PasswordIsValid(password As String, dr As DataRow) As Boolean
            Dim userHash = ComputeHash(password & dr("PasswordSalt"))
            Return CompareHash(dr("PasswordHash"), userHash)
        End Function
    End Class

    Public Class Password
        Public Shared Function RequestPasswordReset(ByVal loginMethod As String) As Boolean
            Dim ds As DataSet = AdminData.GetPasswordResetTokenByLoginMethod(loginMethod)
            If HasData(ds) Then
                Dim dr = ds.Tables(0).Rows(0)
                Dim email = AppMail.Templates.PasswordResetEmail(dr("Email"), dr("FirstName"), dr("RequestToken"))

                Return SendEmail(email)
            End If

            Return True
        End Function

        Public Shared Function ResetPassword(ByVal token As String, ByVal password As String) As Boolean
            Return AdminData.CheckPasswordResetToken(token) AndAlso
                   AdminData.ResetUserPassword(token, password)
        End Function
    End Class

End Namespace
