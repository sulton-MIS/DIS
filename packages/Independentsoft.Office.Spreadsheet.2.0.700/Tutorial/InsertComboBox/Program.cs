using System;
using Independentsoft.Office.Vml;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book1 = new Workbook();
            Worksheet sheet1 = new Worksheet();

            sheet1["A1"] = new Cell("Value1");
            sheet1["A2"] = new Cell("Value2");
            sheet1["A3"] = new Cell("Value3");
            sheet1["A4"] = new Cell("Value4");
            sheet1["A5"] = new Cell("Value5");

            ShapeStyle shapeStyle = new ShapeStyle();
            shapeStyle.Position = Position.Absolute;
            shapeStyle.LeftMargin = "96pt";
            shapeStyle.TopMargin = "30pt";
            shapeStyle.Width = "96pt";
            shapeStyle.Height = "15pt";

            ClientData comboBox = new ClientData();
            comboBox.ObjectType = ObjectType.DropdownBox;
            comboBox.SizeWithCells = true;
            comboBox.Anchor = new Anchor();
            comboBox.Anchor.LeftColumn = 2;
            comboBox.Anchor.LeftOffset = 1;
            comboBox.Anchor.TopRow = 0;
            comboBox.Anchor.TopOffset = 1;
            comboBox.Anchor.RightColumn = 3;
            comboBox.Anchor.RightOffset = 63;
            comboBox.Anchor.BottomRow = 1;
            comboBox.Anchor.BottomOffset = 1;
            comboBox.ListItemsSourceRange = "$A$1:$A$5";
            comboBox.SelectedEntry = 0;
            comboBox.SelectionType = SelectionType.Single;
            comboBox.DropdownStyle = DropdownStyle.Combo;
            comboBox.DropdownMaximumLines = 8;

            Shape shape = new Shape(shapeStyle);
            shape.Content.Add(comboBox);

            sheet1.VmlObjects.Add(shape);

            book1.Sheets.Add(sheet1);

            book1.Save("c:\\test\\output.xlsx", true);
        }
    }
}
