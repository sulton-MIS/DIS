Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1("A1") = New Cell(100)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module