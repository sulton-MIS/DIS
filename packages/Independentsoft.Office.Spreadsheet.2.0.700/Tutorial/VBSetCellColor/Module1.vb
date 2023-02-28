Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim format1 As New CellFormat()

        format1.Font = New Font()
        format1.Font.Name = "Calibri"
        format1.Font.Size = 11
        format1.Font.Family = 2
        format1.Font.Bold = True
        format1.Font.Underline = New Underline(UnderlineType.Single)
        format1.Font.Color = New DataBarColor()
        format1.Font.Color.Color = "FFFF00" ''yellow

        format1.Border = New CellBorder()
        format1.Border.Bottom = New Border()
        format1.Border.Bottom.Style = BorderStyle.Thin

        format1.Fill = New Fill()
        format1.Fill.Pattern = New PatternFill()
        format1.Fill.Pattern.Type = PatternType.Solid
        format1.Fill.Pattern.ForegroundColor = New ForegroundColor()
        format1.Fill.Pattern.ForegroundColor.Color = "FF0000" ''red

        Dim a1 As New Cell(100)
        a1.Format = format1

        Dim sheet1 As New Worksheet()
        sheet1("A1") = a1

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module
