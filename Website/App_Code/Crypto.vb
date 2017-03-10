Imports System.Security.Cryptography

Namespace Crypto

    Public Class Hashing
        Public Shared Function ComputeHash(ByVal plainText As String) As Byte()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
            Dim hash As HashAlgorithm = New SHA256Managed()
            Return hash.ComputeHash(bytes)
        End Function

        Public Shared Function CompareHash(ByVal hash1 As Byte(), hash2 As Byte()) As Boolean
            If hash1.Length <> hash2.Length Then
                Return False
            End If

            For i As Integer = 0 To hash1.Length - 1
                If hash1(i) <> hash2(i) Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Class

End Namespace
