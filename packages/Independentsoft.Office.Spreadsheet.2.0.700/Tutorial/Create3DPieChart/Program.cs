using System;
using Independentsoft.Office;
using Independentsoft.Office.Charts;
using Independentsoft.Office.Drawing;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook();
            Worksheet sheet1 = new Worksheet();

            sheet1["A2"] = new Cell("1st Qtr");
            sheet1["A3"] = new Cell("2nd Qtr");
            sheet1["A4"] = new Cell("3rd Qtr");
            sheet1["A5"] = new Cell("4th Qtr");

            sheet1["B1"] = new Cell("Sales");
            sheet1["B2"] = new Cell(365.68);
            sheet1["B3"] = new Cell(259.98);
            sheet1["B4"] = new Cell(199.80);
            sheet1["B5"] = new Cell(411.90);

            Pie3DChart pieChart = new Pie3DChart();
            pieChart.VaryColors = true;

            PieChartSerie serie1 = new PieChartSerie();
            serie1.Index = 0;
            serie1.Order = 0;

            serie1.SeriesText = new SeriesText();
            serie1.SeriesText.StringReference = new StringReference();
            serie1.SeriesText.StringReference.Formula = "Sheet1!$B$1";

            serie1.SeriesText.StringReference.StringCache = new StringCache();

            StringPoint seriesTextPoint1 = new StringPoint(0, "Sales");
            serie1.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint1);

            serie1.CategoryAxis = new CategoryAxis();
            serie1.CategoryAxis.StringReference = new StringReference();
            serie1.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5";

            serie1.CategoryAxis.StringReference.StringCache = new StringCache();

            StringPoint categoryAxisPoint1 = new StringPoint(0, "1st Qtr");
            StringPoint categoryAxisPoint2 = new StringPoint(1, "2nd Qtr");
            StringPoint categoryAxisPoint3 = new StringPoint(2, "3rd Qtr");
            StringPoint categoryAxisPoint4 = new StringPoint(3, "4th Qtr");

            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint1);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint2);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint3);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint4);

            serie1.Values = new Values();
            serie1.Values.NumberReference = new NumberReference();
            serie1.Values.NumberReference.Formula = "Sheet1!$B$2:$B$5";

            serie1.Values.NumberReference.NumberCache = new NumberCache();
            serie1.Values.NumberReference.NumberCache.Format = "General";

            NumericPoint valuesPoint1 = new NumericPoint(0, "365.68");
            NumericPoint valuesPoint2 = new NumericPoint(1, "259.98");
            NumericPoint valuesPoint3 = new NumericPoint(2, "199.80");
            NumericPoint valuesPoint4 = new NumericPoint(3, "411.90");

            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint1);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint2);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint3);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint4);
                       
            pieChart.Series.Add(serie1);

            ChartSpace chartSpace = new ChartSpace();
            chartSpace.PlotArea = new PlotArea();
            chartSpace.PlotArea.Layout = new Layout();
            chartSpace.PlotArea.Charts.Add(pieChart);

            Legend legend = new Legend();
            legend.Position = LegendPosition.Right;
            legend.Layout = new Layout();

            chartSpace.Legend = legend;
            chartSpace.PlotVisibleOnly = true;

            TwoCellAnchor anchor = new TwoCellAnchor();

            anchor.Start = new StartAnchorPoint();
            anchor.Start.Column = 5;
            anchor.Start.ColumnOffset = new Unit(1, UnitType.Pixel);
            anchor.Start.Row = 5;
            anchor.Start.RowOffset = new Unit(1, UnitType.Pixel);

            anchor.End = new EndAnchorPoint();
            anchor.End.Column = 12;
            anchor.End.ColumnOffset = new Unit(33, UnitType.Pixel);
            anchor.End.Row = 19;
            anchor.End.RowOffset = new Unit(9, UnitType.Pixel);

            Independentsoft.Office.Spreadsheet.Drawing.GraphicFrame graphicFrame = new Independentsoft.Office.Spreadsheet.Drawing.GraphicFrame();
            graphicFrame.ID = "1";
            graphicFrame.Name = "Chart 1";
            graphicFrame.GraphicObject = chartSpace;

            graphicFrame.Transform2D = new Independentsoft.Office.Spreadsheet.Drawing.Transform2D();
            graphicFrame.Transform2D.Extents = new Extents(0, 0);
            graphicFrame.Transform2D.Offset = new Offset(0, 0);

            anchor.Element = graphicFrame;
            anchor.ClientData = new ClientData();

            DrawingObjects drawingObjects = new DrawingObjects();
            drawingObjects.Anchors.Add(anchor);

            sheet1.DrawingObjects = drawingObjects;

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
