using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell a1 = new Cell(100);
            Cell b1 = new Cell(200);

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
