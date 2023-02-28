Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim dataBarColor As DataBarColor = New DataBarColor()
        DataBarColor.Color = "0000FF"

        Dim font1 As Font = New Font()
        font1.Name = "Calibri"
        font1.Size = 11
        font1.Family = 2
        font1.Underline = New Underline(UnderlineType.Single)
        font1.Color = dataBarColor

        Dim link As Hyperlink = New Hyperlink()
        link.Display = "MyLink"
        link.Location = "MyName1"
        link.Reference = "A1"
        link.IsExternal = False

        Dim format1 As CellFormat = New CellFormat()
        format1.Font = font1

        Dim a1 As Cell = New Cell("MyLink")
        a1.Hyperlink = link
        a1.Format = format1

        Dim sheet1 As Worksheet = New Worksheet()
        sheet1.ID = 1
        sheet1.Name = "TestSheet1"

        sheet1("A1") = a1

        Dim sheet2 As Worksheet = New Worksheet()
        sheet2.ID = 1
        sheet2.Name = "TestSheet2"

        sheet2("A1") = New Cell("Destination")

        Dim name1 As DefinedName = New DefinedName("MyName1")
        name1.Body = "TestSheet2!$A$1:$A$1"

        Dim book As Workbook = New Workbook()

        book.Sheets.Add(sheet1)
        book.Sheets.Add(sheet2)

        book.DefinedNames.Add(name1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module