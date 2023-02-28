Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Charts
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()
        Dim sheet1 As New Worksheet()

        sheet1("A2") = New Cell("1st Qtr")
        sheet1("A3") = New Cell("2nd Qtr")
        sheet1("A4") = New Cell("3rd Qtr")
        sheet1("A5") = New Cell("4th Qtr")

        sheet1("B1") = New Cell("Sales")
        sheet1("B2") = New Cell(365.68)
        sheet1("B3") = New Cell(259.98)
        sheet1("B4") = New Cell(199.8)
        sheet1("B5") = New Cell(411.9)

        Dim pieChart As New Pie3DChart()
        pieChart.VaryColors = True

        Dim serie1 As New PieChartSerie()
        serie1.Index = 0
        serie1.Order = 0

        serie1.SeriesText = New SeriesText()
        serie1.SeriesText.StringReference = New StringReference()
        serie1.SeriesText.StringReference.Formula = "Sheet1!$B$1"

        serie1.SeriesText.StringReference.StringCache = New StringCache()

        Dim seriesTextPoint1 As New StringPoint(0, "Sales")
        serie1.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint1)

        serie1.CategoryAxis = New CategoryAxis()
        serie1.CategoryAxis.StringReference = New StringReference()
        serie1.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5"

        serie1.CategoryAxis.StringReference.StringCache = New StringCache()

        Dim categoryAxisPoint1 As New StringPoint(0, "1st Qtr")
        Dim categoryAxisPoint2 As New StringPoint(1, "2nd Qtr")
        Dim categoryAxisPoint3 As New StringPoint(2, "3rd Qtr")
        Dim categoryAxisPoint4 As New StringPoint(3, "4th Qtr")

        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint1)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint2)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint3)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint4)

        serie1.Values = New Values()
        serie1.Values.NumberReference = New NumberReference()
        serie1.Values.NumberReference.Formula = "Sheet1!$B$2:$B$5"

        serie1.Values.NumberReference.NumberCache = New NumberCache()
        serie1.Values.NumberReference.NumberCache.Format = "General"

        Dim valuesPoint1 As New NumericPoint(0, "365.68")
        Dim valuesPoint2 As New NumericPoint(1, "259.98")
        Dim valuesPoint3 As New NumericPoint(2, "199.80")
        Dim valuesPoint4 As New NumericPoint(3, "411.90")

        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint1)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint2)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint3)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint4)

        pieChart.Series.Add(serie1)

        Dim chartSpace As New ChartSpace()
        chartSpace.PlotArea = New PlotArea()
        chartSpace.PlotArea.Layout = New Layout()
        chartSpace.PlotArea.Charts.Add(pieChart)

        Dim legend As New Legend()
        legend.Position = LegendPosition.Right
        legend.Layout = New Layout()

        chartSpace.Legend = legend
        chartSpace.PlotVisibleOnly = True

        Dim anchor As New TwoCellAnchor()

        anchor.Start = New StartAnchorPoint()
        anchor.Start.Column = 5
        anchor.Start.ColumnOffset = New Unit(1, UnitType.Pixel)
        anchor.Start.Row = 5
        anchor.Start.RowOffset = New Unit(1, UnitType.Pixel)

        anchor.[End] = New EndAnchorPoint()
        anchor.[End].Column = 12
        anchor.[End].ColumnOffset = New Unit(33, UnitType.Pixel)
        anchor.[End].Row = 19
        anchor.[End].RowOffset = New Unit(9, UnitType.Pixel)

        Dim graphicFrame As New Independentsoft.Office.Spreadsheet.Drawing.GraphicFrame()
        graphicFrame.ID = "1"
        graphicFrame.Name = "Chart 1"
        graphicFrame.GraphicObject = chartSpace

        graphicFrame.Transform2D = New Independentsoft.Office.Spreadsheet.Drawing.Transform2D()
        graphicFrame.Transform2D.Extents = New Extents(0, 0)
        graphicFrame.Transform2D.Offset = New Offset(0, 0)

        anchor.Element = graphicFrame
        anchor.ClientData = New ClientData()

        Dim drawingObjects As New DrawingObjects()
        drawingObjects.Anchors.Add(anchor)

        sheet1.DrawingObjects = drawingObjects

        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module