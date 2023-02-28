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
            sheet1.BackgroundImage = new BackgroundImage("c:\\test\\draft.png");

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
