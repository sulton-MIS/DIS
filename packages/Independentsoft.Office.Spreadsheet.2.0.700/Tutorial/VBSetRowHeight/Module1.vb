Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1.DefaultRowHeight = 15

        Dim row1 As New Row()

        row1.Height = 45
        row1.HasCustomHeight = True

        sheet1.Rows.Add(row1)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module