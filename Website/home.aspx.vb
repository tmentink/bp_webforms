
Partial Class home
    Inherits System.Web.UI.Page

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim currentUser As Admin.AppUser = Session("AppUser")
        Label1.Text = currentUser.Email
    End Sub
End Class
