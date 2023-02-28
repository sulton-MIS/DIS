Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.PivotTables

Module Module1
    Sub Main(ByVal args As String())

        Dim product1 As String = "Product1"
        Dim product2 As String = "Product2"
        Dim product3 As String = "Product3"
        Dim product4 As String = "Product4"
        Dim product5 As String = "Product5"

        Dim quarter1 As String = "Qtr.1"
        Dim quarter2 As String = "Qtr.2"
        Dim quarter3 As String = "Qtr.3"
        Dim quarter4 As String = "Qtr.4"

        Dim salesP1Q1 As Integer = 5000
        Dim salesP1Q3 As Integer = 4500
        Dim salesP1Q4 As Integer = 3900
        Dim salesP2Q1 As Integer = 2300
        Dim salesP2Q2 As Integer = 3100
        Dim salesP2Q3 As Integer = 5000
        Dim salesP2Q4 As Integer = 9000
        Dim salesP3Q1 As Integer = 8500
        Dim salesP3Q3 As Integer = 7800
        Dim salesP3Q4 As Integer = 6600
        Dim salesP4Q3 As Integer = 2230
        Dim salesP4Q4 As Integer = 1190
        Dim salesP5Q1 As Integer = 5200
        Dim salesP5Q2 As Integer = 4200
        Dim salesP5Q3 As Integer = 3680
        Dim salesP5Q4 As Integer = 5230

        Dim sheet1 As New Worksheet("TestSheet")

        sheet1("A1") = New Cell("Product")
        sheet1("A2") = New Cell(product1)
        sheet1("A3") = New Cell(product1)
        sheet1("A4") = New Cell(product1)
        sheet1("A5") = New Cell(product2)
        sheet1("A6") = New Cell(product2)
        sheet1("A7") = New Cell(product2)
        sheet1("A8") = New Cell(product2)
        sheet1("A9") = New Cell(product3)
        sheet1("A10") = New Cell(product3)
        sheet1("A11") = New Cell(product3)
        sheet1("A12") = New Cell(product4)
        sheet1("A13") = New Cell(product4)
        sheet1("A14") = New Cell(product5)
        sheet1("A15") = New Cell(product5)
        sheet1("A16") = New Cell(product5)
        sheet1("A17") = New Cell(product5)

        sheet1("B1") = New Cell("Quarter")
        sheet1("B2") = New Cell(quarter1)
        sheet1("B3") = New Cell(quarter3)
        sheet1("B4") = New Cell(quarter4)
        sheet1("B5") = New Cell(quarter1)
        sheet1("B6") = New Cell(quarter2)
        sheet1("B7") = New Cell(quarter3)
        sheet1("B8") = New Cell(quarter4)
        sheet1("B9") = New Cell(quarter1)
        sheet1("B10") = New Cell(quarter3)
        sheet1("B11") = New Cell(quarter4)
        sheet1("B12") = New Cell(quarter3)
        sheet1("B13") = New Cell(quarter4)
        sheet1("B14") = New Cell(quarter1)
        sheet1("B15") = New Cell(quarter2)
        sheet1("B16") = New Cell(quarter3)
        sheet1("B17") = New Cell(quarter4)

        sheet1("C1") = New Cell("Sales")
        sheet1("C2") = New Cell(salesP1Q1)
        sheet1("C3") = New Cell(salesP1Q3)
        sheet1("C4") = New Cell(salesP1Q4)
        sheet1("C5") = New Cell(salesP2Q1)
        sheet1("C6") = New Cell(salesP2Q2)
        sheet1("C7") = New Cell(salesP2Q3)
        sheet1("C8") = New Cell(salesP2Q4)
        sheet1("C9") = New Cell(salesP3Q1)
        sheet1("C10") = New Cell(salesP3Q3)
        sheet1("C11") = New Cell(salesP3Q4)
        sheet1("C12") = New Cell(salesP4Q3)
        sheet1("C13") = New Cell(salesP4Q4)
        sheet1("C14") = New Cell(salesP5Q1)
        sheet1("C15") = New Cell(salesP5Q2)
        sheet1("C16") = New Cell(salesP5Q3)
        sheet1("C17") = New Cell(salesP5Q4)

        Dim pivotTable1 As New PivotTable(1, "PivotTable1", "Sum of Sales")
        pivotTable1.Location = New Location("G1:L8", 1, 2, 1)

        Dim productPivotField As New PivotField()
        productPivotField.Axis = PivotTableAxis.Row

        Dim productPivotFieldItem1 As New PivotFieldItem(0)
        Dim productPivotFieldItem2 As New PivotFieldItem(1)
        Dim productPivotFieldItem3 As New PivotFieldItem(2)
        Dim productPivotFieldItem4 As New PivotFieldItem(3)
        Dim productPivotFieldItem5 As New PivotFieldItem(4)
        Dim productPivotFieldItem6 As New PivotFieldItem(PivotItemType.[Default])

        productPivotField.Items.Add(productPivotFieldItem1)
        productPivotField.Items.Add(productPivotFieldItem2)
        productPivotField.Items.Add(productPivotFieldItem3)
        productPivotField.Items.Add(productPivotFieldItem4)
        productPivotField.Items.Add(productPivotFieldItem5)
        productPivotField.Items.Add(productPivotFieldItem6)

        Dim quarterPivotField As New PivotField()
        quarterPivotField.Axis = PivotTableAxis.Column

        Dim quarterPivotFieldItem1 As New PivotFieldItem(0)
        Dim quarterPivotFieldItem2 As New PivotFieldItem(1)
        Dim quarterPivotFieldItem3 As New PivotFieldItem(2)
        Dim quarterPivotFieldItem4 As New PivotFieldItem(3)
        Dim quarterPivotFieldItem5 As New PivotFieldItem(PivotItemType.[Default])

        quarterPivotField.Items.Add(quarterPivotFieldItem1)
        quarterPivotField.Items.Add(quarterPivotFieldItem2)
        quarterPivotField.Items.Add(quarterPivotFieldItem3)
        quarterPivotField.Items.Add(quarterPivotFieldItem4)
        quarterPivotField.Items.Add(quarterPivotFieldItem5)

        Dim salesPivotField As New PivotField()
        salesPivotField.IsDataField = True

        pivotTable1.PivotFields.Add(productPivotField)
        pivotTable1.PivotFields.Add(quarterPivotField)
        pivotTable1.PivotFields.Add(salesPivotField)

        Dim productField As New Field(0)
        pivotTable1.RowFields.Add(productField)

        Dim quarterField As New Field(1)
        pivotTable1.ColumnFields.Add(quarterField)

        Dim salesField As New DataField(2)
        pivotTable1.DataFields.Add(salesField)

        Dim pivotCache1 As New PivotCache()
        pivotCache1.RefreshOnLoad = True

        Dim cacheSource As New PivotCacheSource()
        cacheSource.WorksheetSource = New WorksheetSource("TestSheet", "A1:C17")
        cacheSource.Type = SourceType.Worksheet

        pivotCache1.Source = cacheSource

        Dim productCacheField As New PivotCacheField("Product")

        productCacheField.SharedItems = New SharedItems()
        productCacheField.SharedItems.Values.Add(New StringValue(product1))
        productCacheField.SharedItems.Values.Add(New StringValue(product2))
        productCacheField.SharedItems.Values.Add(New StringValue(product3))
        productCacheField.SharedItems.Values.Add(New StringValue(product4))
        productCacheField.SharedItems.Values.Add(New StringValue(product5))

        Dim quarterCacheField As New PivotCacheField("Quarter")

        quarterCacheField.SharedItems = New SharedItems()
        quarterCacheField.SharedItems.Values.Add(New StringValue(quarter1))
        quarterCacheField.SharedItems.Values.Add(New StringValue(quarter2))
        quarterCacheField.SharedItems.Values.Add(New StringValue(quarter3))
        quarterCacheField.SharedItems.Values.Add(New StringValue(quarter4))

        Dim salesCacheField As New PivotCacheField("Sales")

        pivotCache1.Fields.Add(productCacheField)
        pivotCache1.Fields.Add(quarterCacheField)
        pivotCache1.Fields.Add(salesCacheField)

        Dim record1 As New PivotCacheRecord()
        record1.Values.Add(New StringValue(product1))
        record1.Values.Add(New StringValue(quarter1))
        record1.Values.Add(New NumericValue(salesP1Q1))

        Dim record2 As New PivotCacheRecord()
        record2.Values.Add(New StringValue(product1))
        record2.Values.Add(New StringValue(quarter3))
        record2.Values.Add(New NumericValue(salesP1Q3))

        Dim record3 As New PivotCacheRecord()
        record3.Values.Add(New StringValue(product1))
        record3.Values.Add(New StringValue(quarter4))
        record3.Values.Add(New NumericValue(salesP1Q4))

        Dim record4 As New PivotCacheRecord()
        record4.Values.Add(New StringValue(product2))
        record4.Values.Add(New StringValue(quarter1))
        record4.Values.Add(New NumericValue(salesP2Q1))

        Dim record5 As New PivotCacheRecord()
        record5.Values.Add(New StringValue(product2))
        record5.Values.Add(New StringValue(quarter2))
        record5.Values.Add(New NumericValue(salesP2Q2))

        Dim record6 As New PivotCacheRecord()
        record6.Values.Add(New StringValue(product2))
        record6.Values.Add(New StringValue(quarter3))
        record6.Values.Add(New NumericValue(salesP2Q3))

        Dim record7 As New PivotCacheRecord()
        record7.Values.Add(New StringValue(product2))
        record7.Values.Add(New StringValue(quarter4))
        record7.Values.Add(New NumericValue(salesP2Q4))

        Dim record8 As New PivotCacheRecord()
        record8.Values.Add(New StringValue(product3))
        record8.Values.Add(New StringValue(quarter1))
        record8.Values.Add(New NumericValue(salesP3Q1))

        Dim record9 As New PivotCacheRecord()
        record9.Values.Add(New StringValue(product3))
        record9.Values.Add(New StringValue(quarter3))
        record9.Values.Add(New NumericValue(salesP3Q3))

        Dim record10 As New PivotCacheRecord()
        record10.Values.Add(New StringValue(product3))
        record10.Values.Add(New StringValue(quarter4))
        record10.Values.Add(New NumericValue(salesP3Q4))

        Dim record11 As New PivotCacheRecord()
        record11.Values.Add(New StringValue(product4))
        record11.Values.Add(New StringValue(quarter3))
        record11.Values.Add(New NumericValue(salesP4Q3))

        Dim record12 As New PivotCacheRecord()
        record12.Values.Add(New StringValue(product4))
        record12.Values.Add(New StringValue(quarter4))
        record12.Values.Add(New NumericValue(salesP4Q4))

        Dim record13 As New PivotCacheRecord()
        record13.Values.Add(New StringValue(product5))
        record13.Values.Add(New StringValue(quarter1))
        record13.Values.Add(New NumericValue(salesP5Q1))

        Dim record14 As New PivotCacheRecord()
        record14.Values.Add(New StringValue(product5))
        record14.Values.Add(New StringValue(quarter2))
        record14.Values.Add(New NumericValue(salesP5Q2))

        Dim record15 As New PivotCacheRecord()
        record15.Values.Add(New StringValue(product5))
        record15.Values.Add(New StringValue(quarter3))
        record15.Values.Add(New NumericValue(salesP5Q3))

        Dim record16 As New PivotCacheRecord()
        record16.Values.Add(New StringValue(product5))
        record16.Values.Add(New StringValue(quarter4))
        record16.Values.Add(New NumericValue(salesP5Q4))

        pivotCache1.Records.Add(record1)
        pivotCache1.Records.Add(record2)
        pivotCache1.Records.Add(record3)
        pivotCache1.Records.Add(record4)
        pivotCache1.Records.Add(record5)
        pivotCache1.Records.Add(record6)
        pivotCache1.Records.Add(record7)
        pivotCache1.Records.Add(record8)
        pivotCache1.Records.Add(record9)
        pivotCache1.Records.Add(record10)
        pivotCache1.Records.Add(record11)
        pivotCache1.Records.Add(record12)
        pivotCache1.Records.Add(record13)
        pivotCache1.Records.Add(record14)
        pivotCache1.Records.Add(record15)
        pivotCache1.Records.Add(record16)

        pivotTable1.PivotCache = pivotCache1

        sheet1.PivotTables.Add(pivotTable1)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module