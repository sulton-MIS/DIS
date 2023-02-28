Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim pageMargins As New PageMargins()
        pageMargins.Left = 1
        pageMargins.Right = 1
        pageMargins.Top = 0.75
        pageMargins.Bottom = 0.75
        pageMargins.Header = 0.3
        pageMargins.Footer = 0.3

        Dim sheet1 As New Worksheet()

        sheet1.PageMargins = pageMargins
        sheet1.PageSetupSettings.PaperSize = PaperSize.A4Paper
        sheet1.PageSetupSettings.Orientation = Orientation.Portrait

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module