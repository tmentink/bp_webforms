Imports System.Data
Imports System.Data.SqlClient

Namespace Logging

    Public Class Errors
        Public Shared Function AddLogEntry(ByVal ex As Exception) As Integer
            Return AddLogEntry("", ex, "")
        End Function

        Public Shared Function AddLogEntry(ByVal notes As String) As Integer
            Return AddLogEntry("", notes)
        End Function

        Public Shared Function AddLogEntry(ByVal errorPage As String, ByVal ex As Exception) As Integer
            Return AddLogEntry(errorPage, ex, "")
        End Function

        Public Shared Function AddLogEntry(ByVal ex As Exception, ByVal notes As String) As Integer
            Return AddLogEntry("", ex, notes)
        End Function

        Public Shared Function AddLogEntry(ByVal errorPage As String, ByVal notes As String) As Integer
            Return AddLogEntry("INFORMATION", errorPage, "", "", "", "", notes)
        End Function

        Public Shared Function AddLogEntry(ByVal errorPage As String, ByVal ex As Exception, ByVal notes As String) As Integer
            Return AddLogEntry("EXCEPTION", errorPage, ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace, notes)
        End Function

        Public Shared Function AddLogEntry(ByVal errorType As String, ByVal errorPage As String, ByVal errorSource As String, ByVal errorTarget As String, ByVal errorMessage As String, ByVal errorStackTrace As String, ByVal notes As String) As Integer
            Try
                Dim userID As Integer = 0
                If Admin.AppUser.Exists() Then
                    Dim currentUser As Admin.AppUser = HttpContext.Current.Session("AppUser")
                    userID = currentUser.UserID
                End If

                Dim procedureName As String = "admin.AddErrorLog"
                Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
                parms(0).Value = errorType
                parms(1).Value = errorPage
                parms(2).Value = userID
                parms(3).Value = errorSource
                parms(4).Value = errorTarget
                parms(5).Value = errorMessage
                parms(6).Value = errorStackTrace
                parms(7).Value = notes
                parms(8).Value = DBNull.Value

                SqlHelper.ExecuteNonQuery(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)
                Return parms(8).Value

            Catch ex As Exception
                Return 0
            End Try
        End Function
    End Class

End Namespace