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
            sheet1.DefaultRowHeight = 15;

            Row row1 = new Row();

            row1.Height = 45;
            row1.HasCustomHeight = true;

            sheet1.Rows.Add(row1);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
