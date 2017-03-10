
Public Class Config
    Public Shared Property DBConnection As String = ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString
End Class
