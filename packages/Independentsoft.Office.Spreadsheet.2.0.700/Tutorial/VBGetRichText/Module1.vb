Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook("c:\test\input.xlsx")

        Dim sheet1 As Worksheet = DirectCast(book.Sheets(0), Worksheet)

        Dim b1 As Cell = sheet1("B1")
        Dim text As [String] = ""

        If b1.RichTextInline IsNot Nothing Then

            Dim inlineText As RichTextInline = b1.RichTextInline

            For Each run As Run In inlineText.Runs
                If run.Text IsNot Nothing AndAlso run.Text.Value IsNot Nothing Then
                    text += run.Text.Value
                End If
            Next

            Console.WriteLine(text)

        End If

        Console.Read()

    End Sub
End Module