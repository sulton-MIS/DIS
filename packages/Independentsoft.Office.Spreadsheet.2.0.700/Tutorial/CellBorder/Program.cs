using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Border border = new Border();
            border.Style = BorderStyle.Thin;

            CellFormat format1 = new CellFormat();

            format1.Border = new CellBorder();
            format1.Border.Top = border;
            format1.Border.Bottom = border;
            format1.Border.Left = border;
            format1.Border.Right = border;

            Cell a1 = new Cell(999.99);
            a1.Format = format1;

            Worksheet sheet1 = new Worksheet();
            sheet1["A1"] = a1;

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
