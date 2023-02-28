using System;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook("c:\\test\\input.xlsx");

            Worksheet sheet1 = (Worksheet)book.Sheets[0];
            
            Cell b1 = sheet1["B1"];
            String text = "";
            
            if(b1.RichTextInline != null)
            {
              RichTextInline inlineText = b1.RichTextInline;
              
              foreach(Run run in inlineText.Runs)
              {
                 if(run.Text != null && run.Text.Value != null)
                 {
                	 text += run.Text.Value;
                 }
              }
              
              Console.WriteLine(text);
            }

            Console.Read();
        }
    }
}
