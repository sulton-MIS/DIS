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
            DataBarColor dataBarColor = new DataBarColor();
            dataBarColor.Color = "0000FF";

            Font font1 = new Font();
            font1.Name = "Calibri";
            font1.Size = 11;
            font1.Family = 2;
            font1.Underline = new Underline(UnderlineType.Single);
            font1.Color = dataBarColor;

            Hyperlink link = new Hyperlink();
            link.Display = "MyLink";
            link.Location = "MyName1";
            link.Reference = "A1";
            link.IsExternal = false;

            CellFormat format1 = new CellFormat();
            format1.Font = font1;

            Cell a1 = new Cell("MyLink");
            a1.Hyperlink = link;
            a1.Format = format1;

            Worksheet sheet1 = new Worksheet();
            sheet1.ID = 1;
            sheet1.Name = "TestSheet1";

            sheet1["A1"] = a1;

            Worksheet sheet2 = new Worksheet();
            sheet2.ID = 1;
            sheet2.Name = "TestSheet2";

            sheet2["A1"] = new Cell("Destination");

            DefinedName name1 = new DefinedName("MyName1");
            name1.Body = "TestSheet2!$A$1:$A$1";

            Workbook book = new Workbook();

            book.Sheets.Add(sheet1);
            book.Sheets.Add(sheet2);

            book.DefinedNames.Add(name1); 

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
