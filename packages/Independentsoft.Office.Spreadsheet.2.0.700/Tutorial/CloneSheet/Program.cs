using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook("c:\\test\\input.xlsx");

            Worksheet sheet1 = (Worksheet)book.Sheets[0];

            Worksheet sheet2 = sheet1;

            book.Sheets.Add(sheet2);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
