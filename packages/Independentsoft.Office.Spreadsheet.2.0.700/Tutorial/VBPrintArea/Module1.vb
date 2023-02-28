Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1.ID = 1
        sheet1.Name = "TestSheet1"

        Dim view1 As New SheetView()
        view1.IsWorksheetTabSelected = True
        view1.Index = 0

        sheet1.Views.Add(view1)

        Dim range1 As New DefinedName("_xlnm.Print_Area")
        range1.LocalSheetID = 0
        range1.Body = "TestSheet1!$A$1:$B$20" 'print area

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)
        book.DefinedNames.Add(range1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module