Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        For Each sheet As Worksheet In book.Sheets
            If sheet.VisibilityState = SheetVisibilityType.Hidden Then
                Console.WriteLine("Hidden sheet: " + sheet.Name)
            End If
        Next

        Console.Read()

    End Sub
End Module