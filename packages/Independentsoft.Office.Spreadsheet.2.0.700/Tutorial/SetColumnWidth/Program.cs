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
            Workbook book = new Workbook();
            Worksheet sheet1 = new Worksheet();

            Cell a1 = new Cell(9.99);
            Cell a2 = new Cell(99.99);
            Cell a3 = new Cell(999.99);
            Cell a4 = new Cell(9999.99);
            Cell a5 = new Cell(99999.99);
            Cell a6 = new Cell(999999.99);
            Cell a7 = new Cell(9999999.99);
            Cell a8 = new Cell(99999999.99);
            Cell a9 = new Cell(999999999.99);
            Cell a10 = new Cell(9999999999.99);
            Cell a11 = new Cell(99999999999.99);
            Cell a12 = new Cell(999999999999.99);
            Cell a13 = new Cell(9999999999999.99);

            CellFormat format1 = new CellFormat();
            format1.NumberFormatID = 2; //builtin number format 0.00

            a1.Format = format1;
            a2.Format = format1;
            a3.Format = format1;
            a4.Format = format1;
            a5.Format = format1;
            a6.Format = format1;
            a7.Format = format1;
            a8.Format = format1;
            a9.Format = format1;
            a10.Format = format1;
            a11.Format = format1;
            a12.Format = format1;
            a13.Format = format1;

            sheet1["A1"] = a1;
            sheet1["A2"] = a2;
            sheet1["A3"] = a3;
            sheet1["A4"] = a4;
            sheet1["A5"] = a5;
            sheet1["A6"] = a6;
            sheet1["A7"] = a7;
            sheet1["A8"] = a8;
            sheet1["A9"] = a9;
            sheet1["A10"] = a10;
            sheet1["A11"] = a11;
            sheet1["A12"] = a12;
            sheet1["A13"] = a13;

            sheet1["B1"] = a1;
            sheet1["B2"] = a2;
            sheet1["B3"] = a3;
            sheet1["B4"] = a4;
            sheet1["B5"] = a5;
            sheet1["B6"] = a6;
            sheet1["B7"] = a7;
            sheet1["B8"] = a8;
            sheet1["B9"] = a9;
            sheet1["B10"] = a10;
            sheet1["B11"] = a11;
            sheet1["B12"] = a12;
            sheet1["B13"] = a13;

            sheet1["C1"] = a1;
            sheet1["C2"] = a2;
            sheet1["C3"] = a3;
            sheet1["C4"] = a4;
            sheet1["C5"] = a5;
            sheet1["C6"] = a6;
            sheet1["C7"] = a7;
            sheet1["C8"] = a8;
            sheet1["C9"] = a9;
            sheet1["C10"] = a10;
            sheet1["C11"] = a11;
            sheet1["C12"] = a12;
            sheet1["C13"] = a13;

            Column columnInfo = new Column();
            columnInfo.FirstColumn = 1; //from column A
            columnInfo.LastColumn = 3; //to column C
            columnInfo.Width = 17;

            sheet1.Columns.Add(columnInfo);

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
