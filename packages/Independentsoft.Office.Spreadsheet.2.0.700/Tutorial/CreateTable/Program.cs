using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Worksheet sheet1 = new Worksheet();

            sheet1["A1"] = new Cell("Column1");
            sheet1["A2"] = new Cell(100);
            sheet1["A3"] = new Cell(200);
            sheet1["A4"] = new Cell(300);

            sheet1["B1"] = new Cell("Column2");
            sheet1["B2"] = new Cell(110);
            sheet1["B3"] = new Cell(210);
            sheet1["B4"] = new Cell(310);

            sheet1["C1"] = new Cell("Column3");
            sheet1["C2"] = new Cell(120);
            sheet1["C3"] = new Cell(220);
            sheet1["C4"] = new Cell(320);

            sheet1["D1"] = new Cell("Column4");
            sheet1["D2"] = new Cell(130);
            sheet1["D3"] = new Cell(230);
            sheet1["D4"] = new Cell(330);

            Table table1 = new Table();
            table1.ID = 1;
            table1.Name = "Table1";
            table1.DisplayName = "Table1";
            table1.Reference = "A1:D4";
            table1.AutoFilter = new AutoFilter("A1:D4");
            
            TableColumn tableColumn1 = new TableColumn(1, "Column1");
            TableColumn tableColumn2 = new TableColumn(2, "Column2");
            TableColumn tableColumn3 = new TableColumn(3, "Column3");
            TableColumn tableColumn4 = new TableColumn(4, "Column4");

            table1.Columns.Add(tableColumn1);
            table1.Columns.Add(tableColumn2);
            table1.Columns.Add(tableColumn3);
            table1.Columns.Add(tableColumn4);

            sheet1.Tables.Add(table1);
            
            //set columns width
            Column columnInfo = new Column();
            columnInfo.FirstColumn = 1; //from column A
            columnInfo.LastColumn = 4; //to column D
            columnInfo.Width = 15;

            sheet1.Columns.Add(columnInfo);
            
            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
