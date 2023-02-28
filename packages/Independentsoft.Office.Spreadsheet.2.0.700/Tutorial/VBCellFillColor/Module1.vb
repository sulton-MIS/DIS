Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim grayFill As New Fill()
        grayFill.Pattern = New PatternFill()
        grayFill.Pattern.Type = PatternType.Solid
        grayFill.Pattern.ForegroundColor = New ForegroundColor()
        grayFill.Pattern.ForegroundColor.Theme = 0
        grayFill.Pattern.ForegroundColor.Tint = -0.349986266670736
        grayFill.Pattern.BackgroundColor = New BackgroundColor()
        grayFill.Pattern.BackgroundColor.Color = "FF000000" 'black color for cell text

        Dim lightGrayFill As New Fill()
        lightGrayFill.Pattern = New PatternFill()
        lightGrayFill.Pattern.Type = PatternType.Solid
        lightGrayFill.Pattern.ForegroundColor = New ForegroundColor()
        lightGrayFill.Pattern.ForegroundColor.Theme = 0
        lightGrayFill.Pattern.ForegroundColor.Tint = -0.0499893185216834
        lightGrayFill.Pattern.BackgroundColor = New BackgroundColor()
        lightGrayFill.Pattern.BackgroundColor.Color = "FF000000" 'black color for cell text

        Dim format1 As New CellFormat()
        format1.Fill = grayFill
        format1.ApplyFill = True 'important

        Dim format2 As New CellFormat()
        format2.Fill = lightGrayFill
        format2.ApplyFill = True 'important

        Dim a1 As New Cell(100)
        a1.Format = format1

        Dim b1 As New Cell(200)
        b1.Format = format2

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