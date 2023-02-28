Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        For i As Integer = 0 To book.Sheets.Count - 1

            If TypeOf book.Sheets(i) Is Worksheet Then
                Dim worksheet As Worksheet = DirectCast(book.Sheets(i), Worksheet)

                Console.WriteLine()
                Console.WriteLine("Worksheet = " + worksheet.Name)
                Console.WriteLine("___________________________________________________________________")

                For j As Integer = 0 To worksheet.Rows.Count - 1

                    If worksheet.Rows(j) IsNot Nothing Then

                        Console.WriteLine() 'write row in new line 

                        For k As Integer = 0 To worksheet.Rows(j).Cells.Count - 1

                            If worksheet.Rows(j).Cells(k) IsNot Nothing Then

                                Console.Write(worksheet.Rows(j).Cells(k).Value)
                                Console.Write("" & Chr(9) & "") ' tab

                            End If
                        Next

                    End If
                Next
            End If
        Next

        Console.Read()

    End Sub
End Module