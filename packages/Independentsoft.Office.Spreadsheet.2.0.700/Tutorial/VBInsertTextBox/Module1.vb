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
        shape.ID = "1"
        shape.Name = "TextBox1"
        shape.IsTextBox = True
        shape.ShapeProperties.PresetGeometry = New PresetGeometry(ShapeType.Rectangle)

        shape.ShapeProperties.SolidFill = New SolidFill()
        shape.ShapeProperties.SolidFill.ColorChoice = New SchemeColor(SchemeColorValue.Accent6)

        Dim run1 As New TextRun("TextBox body text.")

        Dim paragraph1 As New TextParagraph()
        paragraph1.Content.Add(run1)

        shape.TextBody = New Independentsoft.Office.Spreadsheet.Drawing.ShapeTextBody()
        shape.TextBody.Paragraphs.Add(paragraph1)

        anchor.Element = shape
        anchor.ClientData = New ClientData()

        Dim drawingObjects As New DrawingObjects()
        drawingObjects.Anchors.Add(anchor)

        sheet1.DrawingObjects = drawingObjects

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module