
Public Class Replace
    ''' <summary>
    ''' Returns nothing if the input value is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked</param>
    Public Shared Function NullWithNothing(ByVal inputVal As DBNull) As Object
        Return Nothing
    End Function

    ''' <summary>
    ''' Returns nothing if the input value is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked</param>
    Public Shared Function NullWithNothing(ByVal inputVal As String) As String
        Return inputVal
    End Function

    ''' <summary>
    ''' Returns nothing if the input value is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked</param>
    Public Shared Function NullWithNothing(ByVal inputVal As Integer) As Integer
        Return inputVal
    End Function

    ''' <summary>
    ''' Returns nothing if the input value is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked</param>
    Public Shared Function NullWithNothing(ByVal inputVal As Date) As Date
        Return inputVal
    End Function


    ''' <summary>
    ''' Returns nothing if the input value equals the checked value. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked</param>
    ''' <param name="checkVal">Value to compare with the input.</param>
    Public Shared Function WithNothing(ByVal inputVal As Object, ByVal checkVal As Object) As Object
        If inputVal = checkVal Then
            Return Nothing
        End If

        Return inputVal
    End Function


    ''' <summary>
    ''' Returns a replacement value if the input is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nulls</param>
    ''' <param name="replaceVal">Value to be returned if input is null</param>
    Public Shared Function IfNull(ByVal inputVal As DBNull, ByVal replaceVal As Object) As Object
        Return replaceVal
    End Function

    ''' <summary>
    ''' Returns a replacement value if the input is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nulls</param>
    ''' <param name="replaceVal">Value to be returned if input is null</param>
    Public Shared Function IfNull(ByVal inputVal As String, ByVal replaceVal As Object) As String
        Return inputVal
    End Function

    ''' <summary>
    ''' Returns a replacement value if the input is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nulls</param>
    ''' <param name="replaceVal">Value to be returned if input is null</param>
    Public Shared Function IfNull(ByVal inputVal As Integer, ByVal replaceVal As Object) As Integer
        Return inputVal
    End Function

    ''' <summary>
    ''' Returns a replacement value if the input is null. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nulls</param>
    ''' <param name="replaceVal">Value to be returned if input is null</param>
    Public Shared Function IfNull(ByVal inputVal As Date, ByVal replaceVal As Object) As Date
        Return inputVal
    End Function


    ''' <summary>
    ''' Returns a replacement value if the input is nothing. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nothing</param>
    ''' <param name="replaceVal">Value to be returned if input is nothing</param>
    Public Shared Function IfNothing(ByVal inputVal As String, ByVal replaceVal As Object) As Object
        If inputVal Is Nothing Then
            Return replaceVal
        End If

        Return inputVal
    End Function

    ''' <summary>
    ''' Returns a replacement value if the input is nothing. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nothing</param>
    ''' <param name="replaceVal">Value to be returned if input is nothing</param>
    Public Shared Function IfNothing(ByVal inputVal As Integer?, ByVal replaceVal As Object) As Object
        If inputVal Is Nothing Then
            Return replaceVal
        End If

        Return inputVal
    End Function

    ''' <summary>
    ''' Returns a replacement value if the input is nothing. Otherwise the input value is returned
    ''' </summary>
    ''' <param name="inputVal">Value to be checked for nothing</param>
    ''' <param name="replaceVal">Value to be returned if input is nothing</param>
    Public Shared Function IfNothing(ByVal inputVal As Date?, ByVal replaceVal As Object) As Object
        If inputVal Is Nothing Then
            Return replaceVal
        End If

        Return inputVal
    End Function
End Class
