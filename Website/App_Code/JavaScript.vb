
Public Class JavaScript
    ''' <summary>
    ''' Adds JavaScript at the bottom of the head.
    ''' </summary>
    Public Shared Sub AddToHead(ByVal script As String)
        Dim currPage As Page = TryCast(HttpContext.Current.Handler, Page)
        Dim scriptTag = New LiteralControl("<script type='text/javascript'>" & script & "</script>")
        currPage.Header.Controls.Add(scriptTag)
    End Sub

    ''' <summary>
    ''' Adds JavaScript at the top of the form. This will be above the DOM and master page scripts.
    ''' </summary>
    Public Shared Sub AddToTopOfForm(ByVal script As String)
        Dim currPage As Page = TryCast(HttpContext.Current.Handler, Page)
        Dim scriptTag = New LiteralControl("<script type='text/javascript'>" & script & "</script>")
        currPage.Form.Controls.AddAt(0, scriptTag)
    End Sub

    ''' <summary>
    ''' Adds JavaScript at the bottom of the form. This will be below the DOM and master page scripts.
    ''' </summary>
    Public Shared Sub AddToBottomOfForm(ByVal script As String)
        Dim currPage As Page = TryCast(HttpContext.Current.Handler, Page)
        Dim scriptTag = New LiteralControl("<script type='text/javascript'>" & script & "</script>")
        currPage.Form.Controls.Add(scriptTag)
    End Sub
End Class
