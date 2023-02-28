using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Fill grayFill = new Fill();
            grayFill.Pattern = new PatternFill();
            grayFill.Pattern.Type = PatternType.Solid;
            grayFill.Pattern.ForegroundColor = new ForegroundColor();
            grayFill.Pattern.ForegroundColor.Theme = 0;
            grayFill.Pattern.ForegroundColor.Tint = -0.34998626667073579;
            grayFill.Pattern.BackgroundColor = new BackgroundColor();
            grayFill.Pattern.BackgroundColor.Color = "FF000000"; //black color for cell text

            Fill lightGrayFill = new Fill();
            lightGrayFill.Pattern = new PatternFill();
            lightGrayFill.Pattern.Type = PatternType.Solid;
            lightGrayFill.Pattern.ForegroundColor = new ForegroundColor();
            lightGrayFill.Pattern.ForegroundColor.Theme = 0;
            lightGrayFill.Pattern.ForegroundColor.Tint = -0.049989318521683403;
            lightGrayFill.Pattern.BackgroundColor = new BackgroundColor();
            lightGrayFill.Pattern.BackgroundColor.Color = "FF000000"; //black color for cell text

            CellFormat format1 = new CellFormat();
            format1.Fill = grayFill;
            format1.ApplyFill = true; //important

            CellFormat format2 = new CellFormat();
            format2.Fill = lightGrayFill;
            format2.ApplyFill = true; //important

            Cell a1 = new Cell(100);
            a1.Format = format1;

            Cell b1 = new Cell(200);
            b1.Format = format2;

            Cell c1 = new Cell();
            c1.Formula = new Formula("SUM(A1,B1)");

            Worksheet sheet1 = new Worksheet();

            sheet1["A1"] = a1;
            sheet1["B1"] = b1;
            sheet1["C1"] = c1;

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
