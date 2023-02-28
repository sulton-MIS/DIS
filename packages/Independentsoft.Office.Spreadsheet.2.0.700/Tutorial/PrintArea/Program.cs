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

            SheetView view1 = new SheetView();
            view1.IsWorksheetTabSelected = true;
            view1.Index = 0;

            sheet1.Views.Add(view1);

            DefinedName range1 = new DefinedName("_xlnm.Print_Area");
            range1.LocalSheetID = 0;
            range1.Body = "TestSheet1!$A$1:$B$20"; //print area

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);
            book.DefinedNames.Add(range1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
