using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Worksheet sheet1 = new Worksheet();
            sheet1.PageSetupSettings.PaperSize = PaperSize.A4Paper;
            sheet1.PageSetupSettings.Orientation = Orientation.Portrait;

            sheet1["A1"] = new Cell(100);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
