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
            shape.ID = "1";
            shape.Name = "TextBox1";
            shape.IsTextBox = true;
            shape.ShapeProperties.PresetGeometry = new PresetGeometry(ShapeType.Rectangle);

            shape.ShapeProperties.SolidFill = new SolidFill();
            shape.ShapeProperties.SolidFill.ColorChoice = new SchemeColor(SchemeColorValue.Accent6);

            TextRun run1 = new TextRun("TextBox body text.");

            TextParagraph paragraph1 = new TextParagraph();
            paragraph1.Content.Add(run1);

            shape.TextBody = new Independentsoft.Office.Spreadsheet.Drawing.ShapeTextBody();
            shape.TextBody.Paragraphs.Add(paragraph1);

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
