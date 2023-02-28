Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim book1 As New Workbook()
        Dim sheet1 As New Worksheet()

        sheet1("A1") = New Cell("Value1")
        sheet1("A2") = New Cell("Value2")
        sheet1("A3") = New Cell("Value3")
        sheet1("A4") = New Cell("Value4")
        sheet1("A5") = New Cell("Value5")

        Dim shapeTemplate As New ShapeTemplate()

        Dim shapeStyle As New ShapeStyle()
        shapeStyle.Position = Position.Absolute
        shapeStyle.LeftMargin = "96pt"
        shapeStyle.TopMargin = "30pt"
        shapeStyle.Width = "96pt"
        shapeStyle.Height = "15pt"

        Dim comboBox As New ClientData()
        comboBox.ObjectType = ObjectType.DropdownBox
        comboBox.SizeWithCells = True
        comboBox.Anchor = New Anchor()
        comboBox.Anchor.LeftColumn = 2
        comboBox.Anchor.LeftOffset = 1
        comboBox.Anchor.TopRow = 0
        comboBox.Anchor.TopOffset = 1
        comboBox.Anchor.RightColumn = 3
        comboBox.Anchor.RightOffset = 63
        comboBox.Anchor.BottomRow = 1
        comboBox.Anchor.BottomOffset = 1
        comboBox.ListItemsSourceRange = "$A$1:$A$5"
        comboBox.SelectedEntry = 0
        comboBox.SelectionType = SelectionType.[Single]
        comboBox.DropdownStyle = DropdownStyle.Combo
        comboBox.DropdownMaximumLines = 8

        Dim shape As New Shape(shapeStyle)
        shape.Content.Add(comboBox)

        sheet1.VmlObjects.Add(shape)

        book1.Sheets.Add(sheet1)

        book1.Save("c:\test\output.xlsx", True)

    End Sub
End Module