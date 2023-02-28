Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        Dim ranges As IList(Of DefinedName) = book.DefinedNames

        For Each range As DefinedName In ranges

            Console.WriteLine("Range name = " + range.Name)
            Console.WriteLine("Reference = " + range.Body)

            Dim cells As IList(Of Cell) = book.GetCells(range.Body)

            For Each cell As Cell In cells
                Console.WriteLine(cell.Reference + " = " + cell.Value)
            Next
        Next

        Console.Read()

    End Sub
End Module