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
            sheet1.OutlineLevelRow = 1; //grouping

            Row row1 = new Row();
            Row row2 = new Row();
            Row row3 = new Row();

            row1.OutlineLevel = 1; //grouping
            row2.OutlineLevel = 1; //grouping
            row3.OutlineLevel = 1; //grouping

            Cell cell1 = new Cell(100);
            cell1.Type = CellType.Number;

            Cell cell2 = new Cell(200);
            cell2.Type = CellType.Number;

            Cell cell3 = new Cell(300);
            cell3.Type = CellType.Number;

            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);
            row1.Cells.Add(cell3);

            row2.Cells.Add(cell1);
            row2.Cells.Add(cell2);
            row2.Cells.Add(cell3);

            row3.Cells.Add(cell1);
            row3.Cells.Add(cell2);
            row3.Cells.Add(cell3);

            sheet1.Rows.Add(row1);
            sheet1.Rows.Add(row2);
            sheet1.Rows.Add(row3);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
