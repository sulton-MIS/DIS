Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        For Each sheet As Sheet In book.Sheets
            If TypeOf sheet Is Worksheet Then

                Dim worksheet As Worksheet = DirectCast(sheet, Worksheet)
                Dim cells As IList(Of Cell) = worksheet.GetCells()

                For i As Integer = 0 To cells.Count - 1
                    Console.WriteLine(cells(i).Reference + " = " + cells(i).Value)
                Next

            End If
        Next

        Console.Read()

    End Sub
End Module