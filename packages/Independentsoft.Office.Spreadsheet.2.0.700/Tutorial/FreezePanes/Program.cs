using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook();

            WorkbookView workbookView1 = new WorkbookView();
            workbookView1.UpperLeftCornerX = 240;
            workbookView1.UpperLeftCornerY = 105;

            book.Views.Add(workbookView1);
            int workbookViewIndex = book.Views.Count - 1;

            Worksheet sheet1 = new Worksheet();

            sheet1["A1"] = new Cell("Order ID");
            sheet1["B1"] = new Cell("Product");
            sheet1["C1"] = new Cell("Price");

            SheetViewPane pane1 = new SheetViewPane();
            pane1.State = PaneState.Frozen;
            pane1.VerticalSplitPosition = 1;
            pane1.ActivePane = PaneType.BottomLeft;
            pane1.TopLeftVisibleCellLocation = "A2";

            SheetView view1 = new SheetView();
            view1.Pane = pane1;
            view1.Index = workbookViewIndex;

            sheet1.Views.Add(view1);

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
