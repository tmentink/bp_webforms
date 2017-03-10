Imports System.Data
Imports System.IO
Imports System.Web.Script.Serialization

Public Class ConvertTo
    ''' <summary>
    ''' Converts DataTable into a CSV string
    ''' </summary>
    ''' <param name="dt">DataTable to be converted</param>
    Public Shared Function CSVFile(ByVal dt As DataTable) As String
        Dim csv As New StringBuilder

        Dim headerIndex = 0
        For Each col As DataColumn In dt.Columns
            If headerIndex > 0 Then
                csv.Append(",")
            End If

            csv.Append(col.ColumnName)
            headerIndex += 1
        Next

        'add line break after header
        csv.Append(vbCr & vbLf)

        For Each dr As DataRow In dt.Rows
            Dim rowIndex As Integer = 0

            For Each col As DataColumn In dt.Columns
                Dim value As String = dr(col.ColumnName).ToString()

                If rowIndex > 0 Then
                    csv.Append(",")
                End If

                'if value has a comma it must be wrapped in quotes
                If value.Contains(",") Then
                    csv.Append("""" & dr(col.ColumnName) & """")
                Else
                    csv.Append(dr(col.ColumnName))
                End If

                rowIndex += 1
            Next

            'add line break at end of row
            csv.Append(vbCr & vbLf)
        Next

        Return csv.ToString()
    End Function


    ''' <summary>
    ''' Converts DataTable into a string formatted as a javascript array
    ''' </summary>
    ''' <param name="dt">DataTable to be converted</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSArray(ByVal dt As DataTable) As String
        Dim array As New List(Of Object)

        For Each dr As DataRow In dt.Rows

            For Each col As DataColumn In dt.Columns
                Select Case col.DataType
                    Case GetType(Date)
                        array.Add(dr(col).ToString())

                    Case Else
                        array.Add(dr(col))
                End Select
            Next

        Next

        Return Serialize(array)
    End Function

    ''' <summary>
    ''' Converts DataTable into a string formatted as a javascript array
    ''' </summary>
    ''' <param name="dt">DataTable to be converted</param>
    ''' <param name="column">Name of specific column to be inserted into array</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSArray(ByVal dt As DataTable, ByVal column As String) As String
        Dim array As New List(Of Object)

        For Each dr As DataRow In dt.Rows
            If TypeOf dr(column) Is Date Then
                array.Add(dr(column).ToString())
            Else
                array.Add(dr(column))
            End If
        Next

        Return Serialize(array)
    End Function


    ''' <summary>
    ''' Converts DataSet into JSON
    ''' </summary>
    ''' <param name="ds">The DataSet to be converted</param>
    ''' <param name="tableNames">Names of the tables in the DataSet</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSON(ByVal ds As DataSet, ByVal tableNames As String()) As String
        Dim dict As New Dictionary(Of String, Object)
        Dim i As Integer = 0
        For Each dt As DataTable In ds.Tables
            dict.Add(tableNames(i), FormatForJSON(dt))
            i += 1
        Next

        Return Serialize(dict)
    End Function

    ''' <summary>
    ''' Converts DataSets into JSON
    ''' </summary>
    ''' <param name="dataSets">The DataSets to be converted</param>
    ''' <param name="tableNames">Names of the tables in the DataSets</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSON(ByVal dataSets As DataSet(), ByVal tableNames As String()) As String
        Dim dict As New Dictionary(Of String, Object)
        Dim i As Integer = 0
        For Each ds As DataSet In dataSets
            For Each dt As DataTable In ds.Tables
                dict.Add(tableNames(i), FormatForJSON(dt))
                i += 1
            Next
        Next

        Return Serialize(dict)
    End Function

    ''' <summary>
    ''' Converts DataTable into JSON
    ''' </summary>
    ''' <param name="dt">The DataTable to be converted</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSON(ByVal dt As DataTable) As String
        Return Serialize(FormatForJSON(dt))
    End Function

    ''' <summary>
    ''' Converts DataView into JSON
    ''' </summary>
    ''' <param name="dv">The DataView to be converted</param>
    ''' <remarks>Dates are converted into strings</remarks>
    Public Shared Function JSON(ByVal dv As DataView) As String
        Return Serialize(FormatForJSON(dv.ToTable()))
    End Function

    ''' <summary>
    ''' Converts Dictionary into JSON
    ''' </summary>
    ''' <param name="dict">The Dictionary to be converted</param>
    Public Shared Function JSON(ByVal dict As Dictionary(Of String, Object)) As String
        Return Serialize(dict)
    End Function


    ''' <summary>
    ''' Converts DataTable into an XML string
    ''' </summary>
    ''' <param name="dt">DataTable to be converted</param>
    ''' <param name="tableName">Name of the table</param>
    ''' <remarks></remarks>
    Public Shared Function XMLString(ByVal dt As DataTable, ByVal tableName As String) As String
        Using sw As New StringWriter()
            'wrap table in new dataset to make xml nodes consistent
            Dim ds As DataSet
            If dt.DataSet Is Nothing Then
                ds = New DataSet()
                ds.Tables.Add(dt)
            Else
                ds = dt.DataSet
            End If

            FormatForXML(dt)
            dt.TableName = tableName
            ds.DataSetName = "NewDataSet"
            ds.WriteXml(sw)

            Return sw.ToString()
        End Using
    End Function

    ''' <summary>
    ''' Converts DataSet into an XML string
    ''' </summary>
    ''' <param name="ds">DataSet to be converted</param>
    ''' <param name="tableNames">Names of the tables in the DataSets</param>
    ''' <remarks></remarks>
    Public Shared Function XMLString(ByVal ds As DataSet, ByVal tableNames As String()) As String
        Using sw As New StringWriter()
            Dim i As Integer = 0
            For Each dt As DataTable In ds.Tables
                FormatForXML(dt)
                dt.TableName = tableNames(i)
                i += 1
            Next

            ds.DataSetName = "NewDataSet"
            ds.WriteXml(sw)

            Return sw.ToString()
        End Using
    End Function


    ' Private Subs & Functions
    '-------------------------------------------
    Private Shared Function FormatForJSON(ByVal dt As DataTable) As List(Of Dictionary(Of String, Object))
        Dim table As New List(Of Dictionary(Of String, Object))

        For Each dr As DataRow In dt.Rows
            Dim row As New Dictionary(Of String, Object)

            For Each col As DataColumn In dt.Columns
                Select Case col.DataType
                    Case GetType(Date)
                        row.Add(col.ColumnName, dr(col).ToString())

                    Case Else
                        row.Add(col.ColumnName, dr(col))
                End Select
            Next

            table.Add(row)
        Next

        Return table
    End Function

    Private Shared Sub FormatForXML(ByVal dt As DataTable)
        For Each dc As DataColumn In dt.Columns
            If dc.DataType Is GetType(Date) Then
                dc.DateTimeMode = DataSetDateTime.Unspecified
            End If
        Next
    End Sub

    Private Shared Function Serialize(ByVal obj As Object) As String
        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(obj)
    End Function
End Class
