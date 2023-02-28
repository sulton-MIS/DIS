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

            IList<DefinedName> ranges = book.DefinedNames;

            foreach (DefinedName range in ranges)
            {
                Console.WriteLine("Range name = " + range.Name);
                Console.WriteLine("Reference  = " + range.Body);

                IList<Cell> cells = book.GetCells(range.Body);

                foreach (Cell cell in cells)
                {
                    Console.WriteLine(cell.Reference + " = " + cell.Value);
                }
            }

            Console.Read();
        }
    }
}
