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
            sheet1.ID = 1;
            sheet1.Name = "TestSheet1";

            DefinedName range1 = new DefinedName("myrange1");
            range1.Body = "TestSheet1!$A$1:$A$10";

            DefinedName range2 = new DefinedName("myrange2");
            range2.Body = "TestSheet1!$B$1:$D$1";

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);
            book.DefinedNames.Add(range1);
            book.DefinedNames.Add(range2);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
