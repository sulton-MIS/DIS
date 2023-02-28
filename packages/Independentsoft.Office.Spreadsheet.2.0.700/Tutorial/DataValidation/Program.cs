using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook();

            DataValidation validation1 = new DataValidation();

            validation1.Type = DataValidationType.WholeNumber;
            validation1.PromptTitle = "Validation title";
            validation1.Prompt = "You have to enter integer between 1 and 999.";
            validation1.ErrorTitle = "Error";
            validation1.ErrorMessage = "Wrong value";
            validation1.ReferenceSequence = "A1:A1048576"; //A column
            validation1.ShowErrorMessage = true;
            validation1.ShowInputMessage = true;
            validation1.Formula1 = "1"; //Min value
            validation1.Formula2 = "999"; //Max value

            Worksheet sheet1 = new Worksheet();
            sheet1.DataValidations = new DataValidations();
            sheet1.DataValidations.Items.Add(validation1);

            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}

