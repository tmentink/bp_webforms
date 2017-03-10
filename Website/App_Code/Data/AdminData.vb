Imports System.Data
Imports System.Data.SqlClient
Imports Crypto.Hashing

Public Class AdminData
    Public Shared Function AddUser(ByVal userName As String, ByVal firstName As String, ByVal lastName As String, ByVal email As String, ByVal password As String, ByVal lastChangedBy As Integer) As Integer
        Try
            Dim passwordSalt = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 25)
            Dim passwordHash = ComputeHash(password & passwordSalt)

            Dim procedureName As String = "admin.AddUser"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = userName
            parms(1).Value = firstName
            parms(2).Value = lastName
            parms(3).Value = email
            parms(4).Value = passwordHash
            parms(5).Value = passwordSalt
            parms(6).Value = lastChangedBy
            parms(7).Value = DBNull.Value

            SqlHelper.ExecuteNonQuery(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)
            Return parms(7).Value

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.AddUser()")
            Return 0
        End Try
    End Function

    Public Shared Function CheckPasswordResetToken(ByVal token As String) As Boolean
        Try
            Dim procedureName As String = "admin.CheckPasswordResetToken"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = token
            parms(1).Value = DBNull.Value

            SqlHelper.ExecuteNonQuery(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)
            Return parms(1).Value

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.CheckPasswordResetToken()")
            Return False
        End Try
    End Function

    Public Shared Function GetPasswordResetTokenByLoginMethod(ByVal loginMethod As String) As DataSet
        If InStr(loginMethod, "@") > 0 Then
            Return GetPasswordResetTokenByEmail(loginMethod)
        Else
            Return GetPasswordResetTokenByUserName(loginMethod)
        End If
    End Function

    Public Shared Function GetPasswordResetTokenByEmail(ByVal email As String) As DataSet
        Try
            Dim procedureName As String = "admin.GetPasswordResetToken"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = email

            Return SqlHelper.ExecuteDataset(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.GetPasswordResetTokenByEmail()")
            Return New DataSet()
        End Try
    End Function

    Public Shared Function GetPasswordResetTokenByUserName(ByVal userName As String) As DataSet
        Try
            Dim procedureName As String = "admin.GetPasswordResetToken"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = DBNull.Value
            parms(1).Value = userName

            Return SqlHelper.ExecuteDataset(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.GetPasswordResetTokenByUserName()")
            Return New DataSet()
        End Try
    End Function

    Public Shared Function GetUserByLoginMethod(ByVal loginMethod As String) As DataSet
        If InStr(loginMethod, "@") > 0 Then
            Return GetUserByEmail(loginMethod)
        Else
            Return GetUserByUserName(loginMethod)
        End If
    End Function

    Public Shared Function GetUserByEmail(ByVal email As String) As DataSet
        Try
            Dim procedureName As String = "admin.GetUserByEmail"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = email

            Return SqlHelper.ExecuteDataset(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.GetUserByEmail()")
            Return New DataSet()
        End Try
    End Function

    Public Shared Function GetUserByUserName(ByVal userName As String) As DataSet
        Try
            Dim procedureName As String = "admin.GetUserByUserName"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = userName

            Return SqlHelper.ExecuteDataset(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.GetUserByUserName()")
            Return New DataSet()
        End Try
    End Function

    Public Shared Function ResetUserPassword(ByVal token As String, ByVal password As String) As Boolean
        Try
            Dim passwordSalt = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 25)
            Dim passwordHash = ComputeHash(password & passwordSalt)

            Dim procedureName As String = "admin.ResetUserPassword"
            Dim parms As SqlParameter() = SqlHelperParameterCache.GetSpParameterSet(Config.DBConnection, procedureName)
            parms(0).Value = token
            parms(1).Value = passwordHash
            parms(2).Value = passwordSalt

            SqlHelper.ExecuteNonQuery(Config.DBConnection, CommandType.StoredProcedure, procedureName, parms)
            Return True

        Catch ex As Exception
            Logging.Errors.AddLogEntry(ex, "AdminData.ResetUserPassword()")
            Return False
        End Try
    End Function
End Class

