Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()
        Dim sheet1 As New Worksheet()

        sheet1("A1") = New Cell("Value1")
        sheet1("A2") = New Cell("Value2")
        sheet1("A3") = New Cell("Value3")
        sheet1("A4") = New Cell("Value4")
        sheet1("A5") = New Cell("Value5")

        Dim anchor As New TwoCellAnchor()
        anchor.EditAs = EditAs.OneCell

        anchor.Start = New StartAnchorPoint()
        anchor.Start.Column = 2
        anchor.Start.ColumnOffset = New Unit(0, UnitType.EnglishMetricUnit)
        anchor.Start.Row = 2
        anchor.Start.RowOffset = New Unit(0, UnitType.EnglishMetricUnit)

        anchor.[End] = New EndAnchorPoint()
        anchor.[End].Column = 12
        anchor.[End].ColumnOffset = New Unit(0, UnitType.EnglishMetricUnit)
        anchor.[End].Row = 26
        anchor.[End].RowOffset = New Unit(0, UnitType.EnglishMetricUnit)

        Dim picture As New Independentsoft.Office.Spreadsheet.Drawing.Picture("c:\\test\\image.gif")
        picture.ID = "1"
        picture.Name = "Picture 1"
        picture.Description = "image.gif"

        picture.Locking = New PictureLocking()
        picture.Locking.DisallowAspectRatioChange = True

        picture.Stretch = New Stretch()
        picture.Stretch.FillRectangle = New FillRectangle()

        picture.ShapeProperties.Transform2D = New Independentsoft.Office.Drawing.Transform2D()
        picture.ShapeProperties.Transform2D.Offset = New Offset(1219200, 381000)
        picture.ShapeProperties.Transform2D.Extents = New Extents(6096000, 4572000)

        picture.ShapeProperties.PresetGeometry = New PresetGeometry(ShapeType.Rectangle)

        anchor.Element = picture
        anchor.ClientData = New ClientData()

        Dim drawingObjects As New DrawingObjects()
        drawingObjects.Anchors.Add(anchor)

        sheet1.DrawingObjects = drawingObjects

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module