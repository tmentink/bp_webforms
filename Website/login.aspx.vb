
Partial Class login
    Inherits System.Web.UI.Page

    Private Sub login_Init(sender As Object, e As EventArgs) Handles Me.Init
        Localization.AddResxToJavaScript(Resources.login.ResourceManager)
    End Sub
End Class
