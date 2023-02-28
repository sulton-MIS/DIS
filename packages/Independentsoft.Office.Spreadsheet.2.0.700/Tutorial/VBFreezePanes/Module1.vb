Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()

        Dim workbookView1 As New WorkbookView()
        workbookView1.UpperLeftCornerX = 240
        workbookView1.UpperLeftCornerY = 105

        book.Views.Add(workbookView1)
        Dim workbookViewIndex As Integer = book.Views.Count - 1

        Dim sheet1 As New Worksheet()

        sheet1("A1") = New Cell("Order ID")
        sheet1("B1") = New Cell("Product")
        sheet1("C1") = New Cell("Price")

        Dim pane1 As New SheetViewPane()
        pane1.State = PaneState.Frozen
        pane1.VerticalSplitPosition = 1
        pane1.ActivePane = PaneType.BottomLeft
        pane1.TopLeftVisibleCellLocation = "A2"

        Dim view1 As New SheetView()
        view1.Pane = pane1
        view1.Index = workbookViewIndex

        sheet1.Views.Add(view1)

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module