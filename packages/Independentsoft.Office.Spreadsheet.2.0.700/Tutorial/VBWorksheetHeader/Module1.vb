Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1("A1") = New Cell(100)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        sheet1.HeaderFooterSettings.OddHeader = "test header"

        Dim view1 As New SheetView()
        view1.ZoomScale = 50
        view1.ZoomScaleNormalView = 50
        view1.Index = 0

        sheet1.Views.Add(view1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module