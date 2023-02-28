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
            
            MergedCell mergedCell = new MergedCell("A1:D1");
            sheet1.MergedCells.Add(mergedCell);

            sheet1["A1"] = new Cell("Merged cells from A1 to D1.");

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
