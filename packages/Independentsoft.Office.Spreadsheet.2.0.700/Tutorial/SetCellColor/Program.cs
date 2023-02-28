using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Styles;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Workbook book1 = new Workbook();
            Worksheet sheet1 = new Worksheet();

            CellFormat format1 = new CellFormat();

            format1.Font = new Font();
            format1.Font.Name = "Calibri";
            format1.Font.Size = 11;
            format1.Font.Family = 2;
            format1.Font.Bold = true;
            format1.Font.Underline = new Underline(UnderlineType.Single);
            format1.Font.Color = new DataBarColor();
            format1.Font.Color.Color = "FFFF00"; //yellow

            format1.Border = new CellBorder();
            format1.Border.Bottom = new Border();
            format1.Border.Bottom.Style = BorderStyle.Thin;

            format1.Fill = new Fill();
            format1.Fill.Pattern = new PatternFill();
            format1.Fill.Pattern.Type = PatternType.Solid;
            format1.Fill.Pattern.ForegroundColor = new ForegroundColor();
            format1.Fill.Pattern.ForegroundColor.Color = "FF0000"; //red

            Cell a1 = new Cell(100);
            a1.Format = format1;

            sheet1["A1"] = a1;

            book1.Sheets.Add(sheet1);

            book1.Save("c:\\test\\output.xlsx", true);
        }
    }
}
