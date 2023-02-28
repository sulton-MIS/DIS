using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            PageMargins pageMargins = new PageMargins();
            pageMargins.Left = 1;
            pageMargins.Right = 1;
            pageMargins.Top = 0.75;
            pageMargins.Bottom = 0.75;
            pageMargins.Header = 0.3;
            pageMargins.Footer = 0.3;

            Worksheet sheet1 = new Worksheet();

            sheet1.PageMargins = pageMargins;
            sheet1.PageSetupSettings.PaperSize = PaperSize.A4Paper;
            sheet1.PageSetupSettings.Orientation = Orientation.Portrait;

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
