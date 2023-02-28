Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1.ID = 1
        sheet1.Name = "TestSheet1"

        Dim range1 As New DefinedName("myrange1")
        range1.Body = "TestSheet1!$A$1:$A$10"

        Dim range2 As New DefinedName("myrange2")
        range2.Body = "TestSheet1!$B$1:$D$1"

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)
        book.DefinedNames.Add(range1)
        book.DefinedNames.Add(range2)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module