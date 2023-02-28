Imports System
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        Dim sheet1 As Worksheet = DirectCast(book.Sheets(0), Worksheet)

        Dim sheet2 As Worksheet = sheet1

        book.Sheets.Add(sheet2)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module