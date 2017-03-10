Imports System.Globalization
Imports System.Resources
Imports System.Web.Script.Serialization

Public Class Localization
    Public Shared Sub AddResxToJavaScript(ByVal resxMngr As ResourceManager)
        JavaScript.AddToHead("var Resources={};" & FormatScript(resxMngr))
    End Sub

    Public Shared Sub AddResxToJavaScript(ByVal resxMngrs As ResourceManager())
        Dim script As String = "var Resources={};"
        For Each resxMngr As ResourceManager In resxMngrs
            script += FormatScript(resxMngr)
        Next
        JavaScript.AddToHead(script)
    End Sub


    'Private Subs & Functions
    '-------------------------------------------
    Private Shared Function FormatScript(ByVal resxMngr As ResourceManager) As String
        Return resxMngr.BaseName & "=" & ResxToJSON(resxMngr) & ";"
    End Function

    Private Shared Function ResxToJSON(ByVal resxMngr As ResourceManager) As String
        Dim dict As New Dictionary(Of String, String)
        Dim curr_resxSet = resxMngr.GetResourceSet(CultureInfo.CurrentUICulture, True, True)
        AddResxToDictionary(dict, curr_resxSet)

        If CultureInfo.CurrentUICulture.IetfLanguageTag <> "en" Then
            Dim en_resxSet = resxMngr.GetResourceSet(New CultureInfo("en"), True, True)
            AddResxToDictionary(dict, en_resxSet)
        End If

        Return New JavaScriptSerializer().Serialize(dict)
    End Function

    Private Shared Sub AddResxToDictionary(ByVal dict As Dictionary(Of String, String), ByVal resxSet As ResourceSet)
        For Each entry As DictionaryEntry In resxSet
            Dim key = entry.Key.ToString
            Dim val = entry.Value.ToString

            If Not dict.ContainsKey(key) Then
                dict.Add(key, val)
            End If
        Next
    End Sub
End Class
