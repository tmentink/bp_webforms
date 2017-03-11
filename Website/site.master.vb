Imports ServerVariables

Partial Class site
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If GetFilePath() = "/login.aspx" OrElse
           GetFilePath() = "/passwordReset.aspx" Then

            header.Visible = False
            footer.Visible = False
        Else
            Admin.Login.VerifyLogin()
            InitHeader()
            InitFooter()
        End If
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.ClientScript.GetPostBackEventReference(Me, String.Empty)
    End Sub


    'Private Subs & Functions
    '-------------------------------------------
    Private Sub InitHeader()
        Dim pageName = GetPageName(withExtension:=False)
        headerTitle.InnerHtml = pageName.Substring(0, 1).ToUpper() + pageName.Substring(1)
    End Sub

    Private Sub InitFooter()
        copyright.InnerHtml = "&copy; " & Date.Now.Year.ToString() & " Boilerplate Website"
    End Sub
End Class

