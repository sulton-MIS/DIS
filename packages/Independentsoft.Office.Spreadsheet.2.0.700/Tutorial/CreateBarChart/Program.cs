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

            //set cell values
            sheet1["A2"] = new Cell("Category 1");
            sheet1["A3"] = new Cell("Category 2");
            sheet1["A4"] = new Cell("Category 3");
            sheet1["A5"] = new Cell("Category 4");

            sheet1["B1"] = new Cell("Series 1");
            sheet1["B2"] = new Cell(4.3);
            sheet1["B3"] = new Cell(2.5);
            sheet1["B4"] = new Cell(3.5);
            sheet1["B5"] = new Cell(4.5);

            sheet1["C1"] = new Cell("Series 2");
            sheet1["C2"] = new Cell(2.4);
            sheet1["C3"] = new Cell(4.4);
            sheet1["C4"] = new Cell(1.8);
            sheet1["C5"] = new Cell(2.8);

            sheet1["D1"] = new Cell("Series 3");
            sheet1["D2"] = new Cell(2);
            sheet1["D3"] = new Cell(2);
            sheet1["D4"] = new Cell(3);
            sheet1["D5"] = new Cell(5);

            //create Bar Chart
            BarChart barChart = new BarChart();
            barChart.Direction = BarDirection.Column;
            barChart.Grouping = BarGrouping.Clustered;

            BarChartSerie serie1 = new BarChartSerie();
            serie1.Index = 0;
            serie1.Order = 0;
            
            serie1.SeriesText = new SeriesText();
            serie1.SeriesText.StringReference = new StringReference();
            serie1.SeriesText.StringReference.Formula = "Sheet1!$B$1";
                        
            serie1.SeriesText.StringReference.StringCache = new StringCache();

            StringPoint seriesTextPoint11 = new StringPoint(0, "Series 1");
            serie1.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint11);

            serie1.CategoryAxis = new CategoryAxis();
            serie1.CategoryAxis.StringReference = new StringReference();
            serie1.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5";

            serie1.CategoryAxis.StringReference.StringCache = new StringCache();

            StringPoint categoryAxisPoint11 = new StringPoint(0, "Category 1");
            StringPoint categoryAxisPoint12 = new StringPoint(1, "Category 2");
            StringPoint categoryAxisPoint13 = new StringPoint(2, "Category 3");
            StringPoint categoryAxisPoint14 = new StringPoint(3, "Category 4");

            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint11);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint12);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint13);
            serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint14);
            
            serie1.Values = new Values();
            serie1.Values.NumberReference = new NumberReference();
            serie1.Values.NumberReference.Formula = "Sheet1!$B$2:$B$5";

            serie1.Values.NumberReference.NumberCache = new NumberCache();
            serie1.Values.NumberReference.NumberCache.Format = "General";

            NumericPoint valuesPoint11 = new NumericPoint(0, "4.3");
            NumericPoint valuesPoint12 = new NumericPoint(1, "2.5");
            NumericPoint valuesPoint13 = new NumericPoint(2, "3.5");
            NumericPoint valuesPoint14 = new NumericPoint(3, "4.5");

            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint11);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint12);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint13);
            serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint14);

            BarChartSerie serie2 = new BarChartSerie();
            serie2.Index = 1;
            serie2.Order = 1;

            serie2.SeriesText = new SeriesText();
            serie2.SeriesText.StringReference = new StringReference();
            serie2.SeriesText.StringReference.Formula = "Sheet1!$C$1";

            serie2.SeriesText.StringReference.StringCache = new StringCache();

            StringPoint seriesTextPoint21 = new StringPoint(0, "Series 2");
            serie2.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint21);

            serie2.CategoryAxis = new CategoryAxis();
            serie2.CategoryAxis.StringReference = new StringReference();
            serie2.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5";

            serie2.CategoryAxis.StringReference.StringCache = new StringCache();

            StringPoint categoryAxisPoint21 = new StringPoint(0, "Category 1");
            StringPoint categoryAxisPoint22 = new StringPoint(1, "Category 2");
            StringPoint categoryAxisPoint23 = new StringPoint(2, "Category 3");
            StringPoint categoryAxisPoint24 = new StringPoint(3, "Category 4");

            serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint21);
            serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint22);
            serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint23);
            serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint24);

            serie2.Values = new Values();
            serie2.Values.NumberReference = new NumberReference();
            serie2.Values.NumberReference.Formula = "Sheet1!$C$2:$C$5";

            serie2.Values.NumberReference.NumberCache = new NumberCache();
            serie2.Values.NumberReference.NumberCache.Format = "General";

            NumericPoint valuesPoint21 = new NumericPoint(0, "2.4");
            NumericPoint valuesPoint22 = new NumericPoint(1, "4.4");
            NumericPoint valuesPoint23 = new NumericPoint(2, "1.8");
            NumericPoint valuesPoint24 = new NumericPoint(3, "2.8");

            serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint21);
            serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint22);
            serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint23);
            serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint24);

            BarChartSerie serie3 = new BarChartSerie();
            serie3.Index = 2;
            serie3.Order = 2;

            serie3.SeriesText = new SeriesText();
            serie3.SeriesText.StringReference = new StringReference();
            serie3.SeriesText.StringReference.Formula = "Sheet1!$D$1";

            serie3.SeriesText.StringReference.StringCache = new StringCache();

            StringPoint seriesTextPoint31 = new StringPoint(0, "Series 3");
            serie3.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint31);

            serie3.CategoryAxis = new CategoryAxis();
            serie3.CategoryAxis.StringReference = new StringReference();
            serie3.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5";

            serie3.CategoryAxis.StringReference.StringCache = new StringCache();

            StringPoint categoryAxisPoint31 = new StringPoint(0, "Category 1");
            StringPoint categoryAxisPoint32 = new StringPoint(1, "Category 2");
            StringPoint categoryAxisPoint33 = new StringPoint(2, "Category 3");
            StringPoint categoryAxisPoint34 = new StringPoint(3, "Category 4");

            serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint31);
            serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint32);
            serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint33);
            serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint34);

            serie3.Values = new Values();
            serie3.Values.NumberReference = new NumberReference();
            serie3.Values.NumberReference.Formula = "Sheet1!$D$2:$D$5";

            serie3.Values.NumberReference.NumberCache = new NumberCache();
            serie3.Values.NumberReference.NumberCache.Format = "General";

            NumericPoint valuesPoint31 = new NumericPoint(0, "2");
            NumericPoint valuesPoint32 = new NumericPoint(1, "2");
            NumericPoint valuesPoint33 = new NumericPoint(2, "3");
            NumericPoint valuesPoint34 = new NumericPoint(3, "5");

            serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint31);
            serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint32);
            serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint33);
            serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint34);

            barChart.Series.Add(serie1);
            barChart.Series.Add(serie2);
            barChart.Series.Add(serie3);

            barChart.FirstAxisID = 1;
            barChart.SecondAxisID = 2;

            //create ChartSpace object and add barChart to the chartSpace
            ChartSpace chartSpace = new ChartSpace();
            chartSpace.PlotArea = new PlotArea();
            chartSpace.PlotArea.Layout = new Layout();
            chartSpace.PlotArea.Charts.Add(barChart);

            ChartCategoryAxis chartCategoryAxis = new ChartCategoryAxis();
            chartCategoryAxis.ID = 1;
            chartCategoryAxis.Scaling = new Scaling();
            chartCategoryAxis.Scaling.Orientation = Independentsoft.Office.Charts.Orientation.MinimumToMaximum;
            chartCategoryAxis.Position = AxisPosition.Bottom;
            chartCategoryAxis.TickLabelPosition = TickLabelPosition.NextTo;
            chartCategoryAxis.CrossingAxisID = 2;
            chartCategoryAxis.Crosses = Crosses.Zero;
            chartCategoryAxis.Auto = true;
            chartCategoryAxis.LabelAlignment = LabelAlignment.Center;
            chartCategoryAxis.LabelOffset = 100;

            ValueAxis valueAxis = new ValueAxis();
            valueAxis.ID = 2;
            valueAxis.Scaling = new Scaling();
            valueAxis.Scaling.Orientation = Independentsoft.Office.Charts.Orientation.MinimumToMaximum;
            valueAxis.Position = AxisPosition.Left;
            valueAxis.MajorGridlines = new MajorGridlines();
            valueAxis.NumberFormat = new NumberFormat();
            valueAxis.NumberFormat.Format = "General";
            valueAxis.NumberFormat.IsSourceLinked = true;
            valueAxis.TickLabelPosition = TickLabelPosition.NextTo;
            valueAxis.CrossingAxisID = 1;
            valueAxis.Crosses = Crosses.Zero;
            valueAxis.CrossBetween = CrossBetween.Between;
        
            chartSpace.PlotArea.Axes.Add(chartCategoryAxis);
            chartSpace.PlotArea.Axes.Add(valueAxis);

            Legend legend = new Legend();
            legend.Position = LegendPosition.Right;
            legend.Layout = new Layout();

            chartSpace.Legend = legend;
            chartSpace.PlotVisibleOnly = true;
           
            //create anchor and add chart to the anchor
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
