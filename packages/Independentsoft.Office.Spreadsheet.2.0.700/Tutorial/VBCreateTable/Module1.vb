Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Tables

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()

        sheet1("A1") = New Cell("Column1")
        sheet1("A2") = New Cell(100)
        sheet1("A3") = New Cell(200)
        sheet1("A4") = New Cell(300)

        sheet1("B1") = New Cell("Column2")
        sheet1("B2") = New Cell(110)
        sheet1("B3") = New Cell(210)
        sheet1("B4") = New Cell(310)

        sheet1("C1") = New Cell("Column3")
        sheet1("C2") = New Cell(120)
        sheet1("C3") = New Cell(220)
        sheet1("C4") = New Cell(320)

        sheet1("D1") = New Cell("Column4")
        sheet1("D2") = New Cell(130)
        sheet1("D3") = New Cell(230)
        sheet1("D4") = New Cell(330)

        Dim table1 As New Table()
        table1.ID = 1
        table1.Name = "Table1"
        table1.DisplayName = "Table1"
        table1.Reference = "A1:D4"
        table1.AutoFilter = New AutoFilter("A1:D4")

        Dim tableColumn1 As New TableColumn(1, "Column1")
        Dim tableColumn2 As New TableColumn(2, "Column2")
        Dim tableColumn3 As New TableColumn(3, "Column3")
        Dim tableColumn4 As New TableColumn(4, "Column4")

        table1.Columns.Add(tableColumn1)
        table1.Columns.Add(tableColumn2)
        table1.Columns.Add(tableColumn3)
        table1.Columns.Add(tableColumn4)

        sheet1.Tables.Add(table1)

        'set columns width 
        Dim columnInfo As New Column()
        columnInfo.FirstColumn = 1 'from column A 
        columnInfo.LastColumn = 4 'to column D 
        columnInfo.Width = 15

        sheet1.Columns.Add(columnInfo)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module