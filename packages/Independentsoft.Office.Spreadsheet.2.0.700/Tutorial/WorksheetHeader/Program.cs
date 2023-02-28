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
            sheet1["A1"] = new Cell(100);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            sheet1.HeaderFooterSettings.OddHeader = "test header";

            SheetView view1 = new SheetView();
            view1.ZoomScale = 50;
            view1.ZoomScaleNormalView = 50;
            view1.Index = 0;

            sheet1.Views.Add(view1);
            
            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
