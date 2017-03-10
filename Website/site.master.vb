Imports ServerVariables

Partial Class site
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If GetFilePath() = "/login.aspx" OrElse
           GetFilePath() = "/passwordReset.aspx" Then

        Else
            Admin.Login.VerifyLogin()
        End If
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.ClientScript.GetPostBackEventReference(Me, String.Empty)
    End Sub
End Class

