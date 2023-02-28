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
            
            MasterCellFormat commaFormat = new MasterCellFormat();
            commaFormat.NumberFormat = new NumberFormat(1, "#,##0.00");

            MasterCellFormat currencyFormat = new MasterCellFormat();
            currencyFormat.NumberFormat = new NumberFormat(2, "$#,##0.00");

            book.Styles.MasterCellFormats.Add(commaFormat);
            book.Styles.MasterCellFormats.Add(currencyFormat);

            CellFormat format1 = new CellFormat();
            format1.NumberFormatID = 1;

            CellFormat format2 = new CellFormat();
            format2.NumberFormatID = 2;

            Cell a1 = new Cell(9999.99);
            a1.Format = format1;

            Cell a2 = new Cell(9999.99);
            a2.Format = format2;

            Worksheet sheet1 = new Worksheet();
            sheet1["A1"] = a1;
            sheet1["A2"] = a2;
 
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
