using System;
using System.Collections.Generic;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook("c:\\test\\input.xlsx");

            foreach (Sheet sheet in book.Sheets)
            {
                if (sheet is Worksheet)
                {
                    Worksheet worksheet = (Worksheet)sheet;
                    IList<Cell> cells = worksheet.GetCells();

                    for (int i = 0; i < cells.Count; i++)
                    {
                        Console.WriteLine(cells[i].Reference + " = " + cells[i].Value);
                    }
                }
            }

            Console.Read();
        }
    }
}
