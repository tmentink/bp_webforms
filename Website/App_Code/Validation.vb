Imports System.Data
Imports System.Data.SqlClient

Namespace Validation

    Public Class Data
        Public Shared Function HasData(ByVal ds As DataSet, Optional ByVal tableIndex As Integer = 0) As Boolean
            Return ds IsNot Nothing AndAlso
                   ds.Tables.Count > 0 AndAlso
                   ds.Tables(tableIndex).Rows.Count > 0
        End Function

        Public Shared Function HasData(ByVal dt As DataTable) As Boolean
            Return dt IsNot Nothing AndAlso
                   dt.Rows.Count > 0
        End Function

        Public Shared Function HasNoData(ByVal ds As DataSet, Optional ByVal tableIndex As Integer = 0) As Boolean
            Return Not HasData(ds, tableIndex)
        End Function

        Public Shared Function HasNoData(ByVal dt As DataTable) As Boolean
            Return Not HasData(dt)
        End Function
    End Class

    Public Class Number
        Public Shared Function IsAPositiveInteger(ByVal input As Object) As Boolean
            If input Is Nothing Then
                Return False
            End If

            Return Regex.IsMatch(input, "^[1-9]\d*$")
        End Function

        Public Shared Function IsNotAPositiveInteger(ByVal input As Object) As Boolean
            Return Not IsAPositiveInteger(input)
        End Function
    End Class

End Namespace
