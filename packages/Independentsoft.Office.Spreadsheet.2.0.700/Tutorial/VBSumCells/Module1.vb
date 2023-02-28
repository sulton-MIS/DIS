Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim a1 As New Cell(100)
        Dim b1 As New Cell(200)

        Dim c1 As New Cell()
        c1.Formula = New Formula("SUM(A1,B1)")

        Dim sheet1 As New Worksheet()
        sheet1("A1") = a1
        sheet1("B1") = b1
        sheet1("C1") = c1

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module