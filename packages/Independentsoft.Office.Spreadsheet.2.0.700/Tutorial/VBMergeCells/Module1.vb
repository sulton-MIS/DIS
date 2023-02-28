Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()

        Dim mergedCell As New MergedCell("A1:D1")
        sheet1.MergedCells.Add(mergedCell)

        sheet1("A1") = New Cell("Merged cells from A1 to D1.")

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module