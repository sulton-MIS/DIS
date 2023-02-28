Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim font1 As New Font()
        font1.Name = "Calibri"
        font1.Size = 11
        font1.Family = 2
        font1.Underline = New Underline(UnderlineType.Single)
        font1.Color = New DataBarColor("#0000FF") ''blue

        Dim format1 As New CellFormat()
        format1.Font = font1

        Dim a1 As New Cell("Independentsoft")
        a1.Hyperlink = New Hyperlink("http://www.independentsoft.com")
        a1.Format = format1

        Dim sheet1 As New Worksheet()
        sheet1("A1") = a1

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module