using System;
using Independentsoft.Office;
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

            TwoCellAnchor anchor = new TwoCellAnchor();

            anchor.Start = new StartAnchorPoint();
            anchor.Start.Column = 1;
            anchor.Start.ColumnOffset = new Unit(0, UnitType.EnglishMetricUnit);
            anchor.Start.Row = 2;
            anchor.Start.RowOffset = new Unit(0, UnitType.EnglishMetricUnit);

            anchor.End = new EndAnchorPoint();
            anchor.End.Column = 5;
            anchor.End.ColumnOffset = new Unit(0, UnitType.EnglishMetricUnit);
            anchor.End.Row = 7;
            anchor.End.RowOffset = new Unit(0, UnitType.EnglishMetricUnit);

            Independentsoft.Office.Spreadsheet.Drawing.Shape shape = new Independentsoft.Office.Spreadsheet.Drawing.Shape();
            shape.ID = "10";
            shape.Name = "Line 1";

            SolidFill solidFill = new SolidFill();
            solidFill.ColorChoice = new SchemeColor(SchemeColorValue.Accent6);

            Outline borderLine = new Outline();
            borderLine.LineWidth = new Unit(2, UnitType.Point);
            borderLine.SolidFill = solidFill;

            PresetGeometry presetGeometry = new PresetGeometry(ShapeType.Line);
            shape.ShapeProperties.PresetGeometry = presetGeometry;
            shape.ShapeProperties.Outline = borderLine;

            anchor.Element = shape;
            anchor.ClientData = new ClientData();

            DrawingObjects drawingObjects = new DrawingObjects();
            drawingObjects.Anchors.Add(anchor);

            sheet1.DrawingObjects = drawingObjects;

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
