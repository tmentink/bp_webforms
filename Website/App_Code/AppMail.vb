Imports System.Net.Mail
Imports ServerVariables

Namespace AppMail

    Public Class Actions
        Public Shared Function SendEmail(ByVal email As MailMessage) As Boolean
            Dim client As New SmtpClient()
            Try
                client.Send(email)
                Return True

            Catch ex As Exception
                Logging.Errors.AddLogEntry(ex, "Email.Actions.SendEmail()")
                Return False
            End Try
        End Function
    End Class

    Public Class Templates
        Public Shared Function PasswordResetEmail(ByVal sendTo As String, ByVal firstName As String, ByVal requestToken As Guid) As MailMessage
            Dim email = New MailMessage
            email.To.Add(sendTo)
            email.Subject = "Reset your password"
            email.IsBodyHtml = True

            Dim body = New StringBuilder
            body.Append("Hi " & firstName & ", <br/><br/>")
            body.Append("A request was received to reset your password.<br/>")
            body.Append("You can use the following link within the next day to reset your password: <br/><br/>")
            body.Append("<a href='" & GetURL("/passwordReset.aspx?token=" & requestToken.ToString()) & "'>")
            body.Append(GetURL("/passwordReset.aspx?token=" & requestToken.ToString()) & "</a><br/><br/>")
            body.Append("If you don't use this link within 24 hours, it will expire and your password will remain unchanged.<br/>")

            email.Body = body.ToString()
            Return email
        End Function
    End Class

End Namespace
