Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim border As New Border()
        border.Style = BorderStyle.Thin

        Dim format1 As New CellFormat()

        format1.Border = New CellBorder()
        format1.Border.Top = border
        format1.Border.Bottom = border
        format1.Border.Left = border
        format1.Border.Right = border

        Dim a1 As New Cell(999.99)
        a1.Format = format1

        Dim sheet1 As New Worksheet()
        sheet1("A1") = a1

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module