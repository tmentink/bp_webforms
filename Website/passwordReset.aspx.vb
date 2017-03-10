
Partial Class passwordReset
    Inherits System.Web.UI.Page

    Private Sub passwordReset_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim token = Replace.IfNothing(Request.QueryString("token"), "")
        If AdminData.CheckPasswordResetToken(token) Then
            Localization.AddResxToJavaScript({Resources.passwordReset.ResourceManager, Resources.passwordValidation.ResourceManager})
        Else
            Response.Redirect("~/login.aspx")
        End If
    End Sub

End Class
