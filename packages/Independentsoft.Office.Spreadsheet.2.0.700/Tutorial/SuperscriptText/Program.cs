using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run run1 = new Run();
            run1.Text = new Text("normal ");

            Run run2 = new Run();
            run2.Text = new Text("superscript");
            run2.RunVerticalAlignment = RunVerticalAlignment.Superscript;

            RichTextInline richTextInline = new RichTextInline();
            richTextInline.Runs.Add(run1);
            richTextInline.Runs.Add(run2);

            Cell cell1 = new Cell();
            cell1.RichTextInline = richTextInline;

            Worksheet sheet1 = new Worksheet();
            sheet1["A1"] = cell1;

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
