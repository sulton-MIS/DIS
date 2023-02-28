Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()

        sheet1("A1") = New Cell(100)
        sheet1("A2") = New Cell(1000)
        sheet1("A3") = New Cell(2000)

        Dim dataBar1 As New DataBar()
        dataBar1.Color = New DataBarColor("#FF0000") ''red

        dataBar1.FirstConditionalFormatValueObject = New ConditionalFormatValueObject()
        dataBar1.FirstConditionalFormatValueObject.Type = ConditionalFormatValueObjectType.Minimum
        dataBar1.FirstConditionalFormatValueObject.Value = "0"

        dataBar1.SecondConditionalFormatValueObject = New ConditionalFormatValueObject()
        dataBar1.SecondConditionalFormatValueObject.Type = ConditionalFormatValueObjectType.Maximum
        dataBar1.SecondConditionalFormatValueObject.Value = "0"

        Dim rule1 As New ConditionalFormattingRule()
        rule1.Type = ConditionalFormatType.DataBar
        rule1.Priority = 1
        rule1.DataBar = dataBar1

        Dim formatting1 As New ConditionalFormatting()
        formatting1.Reference = "A1:A3"
        formatting1.Rules.Add(rule1)

        sheet1.ConditionalFormattings.Add(formatting1)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module