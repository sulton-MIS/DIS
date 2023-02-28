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

            sheet1["A1"] = new Cell("Value1");
            sheet1["A2"] = new Cell("Value2");
            sheet1["A3"] = new Cell("Value3");
            sheet1["A4"] = new Cell("Value4");
            sheet1["A5"] = new Cell("Value5");

            TwoCellAnchor anchor = new TwoCellAnchor();
            anchor.EditAs = EditAs.OneCell;

            anchor.Start = new StartAnchorPoint();
            anchor.Start.Column = 2;
            anchor.Start.ColumnOffset = new Unit(0, UnitType.EnglishMetricUnit);
            anchor.Start.Row = 2;
            anchor.Start.RowOffset = new Unit(0, UnitType.EnglishMetricUnit);

            anchor.End = new EndAnchorPoint();
            anchor.End.Column = 12;
            anchor.End.ColumnOffset = new Unit(0, UnitType.EnglishMetricUnit);
            anchor.End.Row = 26;
            anchor.End.RowOffset = new Unit(0, UnitType.EnglishMetricUnit);

            Independentsoft.Office.Spreadsheet.Drawing.Picture picture = new Independentsoft.Office.Spreadsheet.Drawing.Picture("c:\\test\\image.gif");
            picture.ID = "1";
            picture.Name = "Picture 1";
            picture.Description = "image.gif";

            picture.Locking = new PictureLocking();
            picture.Locking.DisallowAspectRatioChange = true;

            picture.Stretch = new Stretch();
            picture.Stretch.FillRectangle = new FillRectangle();

            picture.ShapeProperties.Transform2D = new Independentsoft.Office.Drawing.Transform2D();
            picture.ShapeProperties.Transform2D.Offset = new Offset(1219200, 381000);
            picture.ShapeProperties.Transform2D.Extents = new Extents(6096000, 4572000);

            picture.ShapeProperties.PresetGeometry = new PresetGeometry(ShapeType.Rectangle);

            anchor.Element = picture;
            anchor.ClientData = new ClientData();

            DrawingObjects drawingObjects = new DrawingObjects();
            drawingObjects.Anchors.Add(anchor);

            sheet1.DrawingObjects = drawingObjects;

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
