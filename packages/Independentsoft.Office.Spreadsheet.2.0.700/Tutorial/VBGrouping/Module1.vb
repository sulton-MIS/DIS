Imports System
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()

        sheet1.DefaultRowHeight = 15
        sheet1.OutlineLevelRow = 1 'grouping
        Dim row1 As New Row()
        Dim row2 As New Row()
        Dim row3 As New Row()

        row1.OutlineLevel = 1 'grouping
        row2.OutlineLevel = 1 'grouping
        row3.OutlineLevel = 1 'grouping

        Dim cell1 As New Cell(100)
        cell1.Type = CellType.Number

        Dim cell2 As New Cell(200)
        cell2.Type = CellType.Number

        Dim cell3 As New Cell(300)
        cell3.Type = CellType.Number

        row1.Cells.Add(cell1)
        row1.Cells.Add(cell2)
        row1.Cells.Add(cell3)

        row2.Cells.Add(cell1)
        row2.Cells.Add(cell2)
        row2.Cells.Add(cell3)

        row3.Cells.Add(cell1)
        row3.Cells.Add(cell2)
        row3.Cells.Add(cell3)

        sheet1.Rows.Add(row1)
        sheet1.Rows.Add(row2)
        sheet1.Rows.Add(row3)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module