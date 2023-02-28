Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()

        Dim commaFormat As New MasterCellFormat()
        commaFormat.NumberFormat = New NumberFormat(1, "#,##0.00")

        Dim currencyFormat As New MasterCellFormat()
        currencyFormat.NumberFormat = New NumberFormat(2, "$#,##0.00")

        book.Styles.MasterCellFormats.Add(commaFormat)
        book.Styles.MasterCellFormats.Add(currencyFormat)

        Dim format1 As New CellFormat()
        format1.NumberFormatID = 1

        Dim format2 As New CellFormat()
        format2.NumberFormatID = 2

        Dim a1 As New Cell(9999.99)
        a1.Format = format1

        Dim a2 As New Cell(9999.99)
        a2.Format = format2

        Dim sheet1 As New Worksheet()
        sheet1("A1") = a1
        sheet1("A2") = a2

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module
