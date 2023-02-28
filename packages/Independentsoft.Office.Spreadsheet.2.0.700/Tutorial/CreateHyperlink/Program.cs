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
            Font font1 = new Font();
            font1.Name = "Calibri";
            font1.Size = 11;
            font1.Family = 2;
            font1.Underline = new Underline(UnderlineType.Single);
            font1.Color = new DataBarColor("#0000FF"); //blue

            CellFormat format1 = new CellFormat();
            format1.Font = font1;

            Cell a1 = new Cell("Independentsoft");
            a1.Hyperlink = new Hyperlink("http://www.independentsoft.com");
            a1.Format = format1;

            Worksheet sheet1 = new Worksheet();
            sheet1["A1"] = a1;

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
