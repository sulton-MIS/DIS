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
            Worksheet sheet1 = new Worksheet();

            sheet1["A1"] = new Cell(100);
            sheet1["A2"] = new Cell(1000);
            sheet1["A3"] = new Cell(2000);

            DataBar dataBar1 = new DataBar();
            dataBar1.Color = new DataBarColor("#FF0000"); //red

            dataBar1.FirstConditionalFormatValueObject = new ConditionalFormatValueObject();
            dataBar1.FirstConditionalFormatValueObject.Type = ConditionalFormatValueObjectType.Minimum;
            dataBar1.FirstConditionalFormatValueObject.Value = "0";

            dataBar1.SecondConditionalFormatValueObject = new ConditionalFormatValueObject();
            dataBar1.SecondConditionalFormatValueObject.Type = ConditionalFormatValueObjectType.Maximum;
            dataBar1.SecondConditionalFormatValueObject.Value = "0";

            ConditionalFormattingRule rule1 = new ConditionalFormattingRule();
            rule1.Type = ConditionalFormatType.DataBar;
            rule1.Priority = 1;
            rule1.DataBar = dataBar1;

            ConditionalFormatting formatting1 = new ConditionalFormatting();
            formatting1.Reference = "A1:A3";
            formatting1.Rules.Add(rule1);

            sheet1.ConditionalFormattings.Add(formatting1);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
