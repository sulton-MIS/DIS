Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Namespace Sample
    Class Program
        Shared Sub Main(ByVal args As String())

            Dim book As New Workbook()

            Dim validation1 As New DataValidation()

            validation1.Type = DataValidationType.WholeNumber
            validation1.PromptTitle = "Validation title"
            validation1.Prompt = "You have to enter integer between 1 and 999."
            validation1.ErrorTitle = "Error"
            validation1.ErrorMessage = "Wrong value"
            validation1.ReferenceSequence = "A1:A1048576" 'A column 
            validation1.ShowErrorMessage = True
            validation1.ShowInputMessage = True
            validation1.Formula1 = "1" 'Min value 
            validation1.Formula2 = "999" 'Max value 

            Dim sheet1 As New Worksheet()
            sheet1.DataValidations = New DataValidations()
            sheet1.DataValidations.Items.Add(validation1)

            book.Sheets.Add(sheet1)

            book.Save("c:\test\output.xlsx", True)

        End Sub
    End Class
End Namespace