Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim run1 As New Run()
        run1.Text = New Text("normal ")

        Dim run2 As New Run()
        run2.Text = New Text("superscript")
        run2.RunVerticalAlignment = RunVerticalAlignment.Superscript

        Dim richTextInline As New RichTextInline()
        richTextInline.Runs.Add(run1)
        richTextInline.Runs.Add(run2)

        Dim cell1 As New Cell()
        cell1.RichTextInline = richTextInline

        Dim sheet1 As New Worksheet()
        sheet1("A1") = cell1

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module