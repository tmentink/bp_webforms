
Public Class ServerVariables
    Public Shared Function GetClientIPAddress() As String
        Dim sIPAddress As String = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function

    Public Shared Function GetFilePath() As String
        Return HttpContext.Current.Request.ServerVariables("URL")
    End Function

    Public Shared Function GetHost() As String
        Return HttpContext.Current.Request.ServerVariables("HTTP_HOST")
    End Function

    Public Shared Function GetPageName(Optional ByVal withExtension As Boolean = True) As String
        Dim url = HttpContext.Current.Request.ServerVariables("URL")
        If withExtension Then
            Return IO.Path.GetFileName(url)
        Else
            Return IO.Path.GetFileNameWithoutExtension(url)
        End If
    End Function

    Public Shared Function GetPhysicalPath() As String
        Return HttpContext.Current.Request.ServerVariables("APPL_PHYSICAL_PATH")
    End Function

    Public Shared Function GetProtocol() As String
        Dim protocol As String = "https://"
        If HttpContext.Current.Request.ServerVariables("HTTPS") <> "on" Then
            protocol = "http://"
        End If
        Return protocol
    End Function

    Public Shared Function GetServerName() As String
        Return HttpContext.Current.Request.Item("SERVER_NAME")
    End Function

    Public Shared Function GetServerVariable(ByVal name As String) As String
        Return HttpContext.Current.Request.ServerVariables(name)
    End Function

    Public Shared Function GetScriptName() As String
        Return HttpContext.Current.Request.ServerVariables("SCRIPT_NAME")
    End Function

    Public Shared Function GetURL() As String
        Return GetProtocol() & GetHost() & HttpContext.Current.Request.ServerVariables("URL")
    End Function

    Public Shared Function GetURL(ByVal filePath As String) As String
        Return GetProtocol() & GetHost() & filePath
    End Function
End Class
