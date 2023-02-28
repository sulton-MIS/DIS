Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()
        Dim sheet1 As New Worksheet()

        Dim anchor As New TwoCellAnchor()

        anchor.Start = New StartAnchorPoint()
        anchor.Start.Column = 1
        anchor.Start.ColumnOffset = New Unit(0, UnitType.EnglishMetricUnit)
        anchor.Start.Row = 2
        anchor.Start.RowOffset = New Unit(0, UnitType.EnglishMetricUnit)

        anchor.[End] = New EndAnchorPoint()
        anchor.[End].Column = 5
        anchor.[End].ColumnOffset = New Unit(0, UnitType.EnglishMetricUnit)
        anchor.[End].Row = 7
        anchor.[End].RowOffset = New Unit(0, UnitType.EnglishMetricUnit)

        Dim shape As New Independentsoft.Office.Spreadsheet.Drawing.Shape()
        shape.ID = "10"
        shape.Name = "Line 1"

        Dim solidFill As New SolidFill()
        solidFill.ColorChoice = New SchemeColor(SchemeColorValue.Accent6)

        Dim borderLine As New Outline()
        borderLine.LineWidth = New Unit(2, UnitType.Point)
        borderLine.SolidFill = solidFill

        Dim presetGeometry As New PresetGeometry(ShapeType.Line)
        shape.ShapeProperties.PresetGeometry = presetGeometry
        shape.ShapeProperties.Outline = borderLine

        anchor.Element = shape
        anchor.ClientData = New ClientData()

        Dim drawingObjects As New DrawingObjects()
        drawingObjects.Anchors.Add(anchor)

        sheet1.DrawingObjects = drawingObjects

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module