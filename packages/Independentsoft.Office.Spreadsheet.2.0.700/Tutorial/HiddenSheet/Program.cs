using System;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook("c:\\test\\input.xlsx");

            foreach(Worksheet sheet in book.Sheets)
            {
                if(sheet.VisibilityState == SheetVisibilityType.Hidden)
                {
                    Console.WriteLine("Hidden sheet: " + sheet.Name);
                }
            }

            Console.Read();
        }
    }
}
