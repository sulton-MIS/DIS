using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook("c:\\test\\input.xlsx");

            for(int i=0; i < book.Sheets.Count; i++)
            {
                if (book.Sheets[i] is Worksheet)
                {
                    Worksheet worksheet = (Worksheet)book.Sheets[i];

                    Console.WriteLine();
                    Console.WriteLine("Worksheet = " + worksheet.Name);
                    Console.WriteLine("___________________________________________________________________");
                    
                    for (int j = 0; j < worksheet.Rows.Count; j++)
                    {
                        if (worksheet.Rows[j] != null)
                        {
                            Console.WriteLine(); //write row in new line
   
                            for (int k = 0; k < worksheet.Rows[j].Cells.Count; k++)
                            {
                                if (worksheet.Rows[j].Cells[k] != null)
                                {
                                    Console.Write(worksheet.Rows[j].Cells[k].Value);
                                    Console.Write("\t");
                                }
                            }
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}
