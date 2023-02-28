using System;
using Independentsoft.Office;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.PivotTables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string product1 = "Product1";
            string product2 = "Product2";
            string product3 = "Product3";
            string product4 = "Product4";
            string product5 = "Product5";

            string quarter1 = "Qtr.1";
            string quarter2 = "Qtr.2";
            string quarter3 = "Qtr.3";
            string quarter4 = "Qtr.4";

            int salesP1Q1 = 5000;
            int salesP1Q3 = 4500;
            int salesP1Q4 = 3900;
            int salesP2Q1 = 2300;
            int salesP2Q2 = 3100;
            int salesP2Q3 = 5000;
            int salesP2Q4 = 9000;
            int salesP3Q1 = 8500;
            int salesP3Q3 = 7800;
            int salesP3Q4 = 6600;
            int salesP4Q3 = 2230;
            int salesP4Q4 = 1190;
            int salesP5Q1 = 5200;
            int salesP5Q2 = 4200;
            int salesP5Q3 = 3680;
            int salesP5Q4 = 5230;

            Worksheet sheet1 = new Worksheet("TestSheet");

            sheet1["A1"] = new Cell("Product");
            sheet1["A2"] = new Cell(product1);
            sheet1["A3"] = new Cell(product1);
            sheet1["A4"] = new Cell(product1);
            sheet1["A5"] = new Cell(product2);
            sheet1["A6"] = new Cell(product2);
            sheet1["A7"] = new Cell(product2);
            sheet1["A8"] = new Cell(product2);
            sheet1["A9"] = new Cell(product3);
            sheet1["A10"] = new Cell(product3);
            sheet1["A11"] = new Cell(product3);
            sheet1["A12"] = new Cell(product4);
            sheet1["A13"] = new Cell(product4);
            sheet1["A14"] = new Cell(product5);
            sheet1["A15"] = new Cell(product5);
            sheet1["A16"] = new Cell(product5);
            sheet1["A17"] = new Cell(product5);

            sheet1["B1"] = new Cell("Quarter");
            sheet1["B2"] = new Cell(quarter1);
            sheet1["B3"] = new Cell(quarter3);
            sheet1["B4"] = new Cell(quarter4);
            sheet1["B5"] = new Cell(quarter1);
            sheet1["B6"] = new Cell(quarter2);
            sheet1["B7"] = new Cell(quarter3);
            sheet1["B8"] = new Cell(quarter4);
            sheet1["B9"] = new Cell(quarter1);
            sheet1["B10"] = new Cell(quarter3);
            sheet1["B11"] = new Cell(quarter4);
            sheet1["B12"] = new Cell(quarter3);
            sheet1["B13"] = new Cell(quarter4);
            sheet1["B14"] = new Cell(quarter1);
            sheet1["B15"] = new Cell(quarter2);
            sheet1["B16"] = new Cell(quarter3);
            sheet1["B17"] = new Cell(quarter4);

            sheet1["C1"] = new Cell("Sales");
            sheet1["C2"] = new Cell(salesP1Q1);
            sheet1["C3"] = new Cell(salesP1Q3);
            sheet1["C4"] = new Cell(salesP1Q4);
            sheet1["C5"] = new Cell(salesP2Q1);
            sheet1["C6"] = new Cell(salesP2Q2);
            sheet1["C7"] = new Cell(salesP2Q3);
            sheet1["C8"] = new Cell(salesP2Q4);
            sheet1["C9"] = new Cell(salesP3Q1);
            sheet1["C10"] = new Cell(salesP3Q3);
            sheet1["C11"] = new Cell(salesP3Q4);
            sheet1["C12"] = new Cell(salesP4Q3);
            sheet1["C13"] = new Cell(salesP4Q4);
            sheet1["C14"] = new Cell(salesP5Q1);
            sheet1["C15"] = new Cell(salesP5Q2);
            sheet1["C16"] = new Cell(salesP5Q3);
            sheet1["C17"] = new Cell(salesP5Q4);

            PivotTable pivotTable1 = new PivotTable(1, "PivotTable1", "Sum of Sales");
            pivotTable1.Location = new Location("G1:L8", 1, 2, 1);

            PivotField productPivotField = new PivotField();
            productPivotField.Axis = PivotTableAxis.Row;

            PivotFieldItem productPivotFieldItem1 = new PivotFieldItem(0);
            PivotFieldItem productPivotFieldItem2 = new PivotFieldItem(1);
            PivotFieldItem productPivotFieldItem3 = new PivotFieldItem(2);
            PivotFieldItem productPivotFieldItem4 = new PivotFieldItem(3);
            PivotFieldItem productPivotFieldItem5 = new PivotFieldItem(4);
            PivotFieldItem productPivotFieldItem6 = new PivotFieldItem(PivotItemType.Default);

            productPivotField.Items.Add(productPivotFieldItem1);
            productPivotField.Items.Add(productPivotFieldItem2);
            productPivotField.Items.Add(productPivotFieldItem3);
            productPivotField.Items.Add(productPivotFieldItem4);
            productPivotField.Items.Add(productPivotFieldItem5);
            productPivotField.Items.Add(productPivotFieldItem6);

            PivotField quarterPivotField = new PivotField();
            quarterPivotField.Axis = PivotTableAxis.Column;

            PivotFieldItem quarterPivotFieldItem1 = new PivotFieldItem(0);
            PivotFieldItem quarterPivotFieldItem2 = new PivotFieldItem(1);
            PivotFieldItem quarterPivotFieldItem3 = new PivotFieldItem(2);
            PivotFieldItem quarterPivotFieldItem4 = new PivotFieldItem(3);
            PivotFieldItem quarterPivotFieldItem5 = new PivotFieldItem(PivotItemType.Default);

            quarterPivotField.Items.Add(quarterPivotFieldItem1);
            quarterPivotField.Items.Add(quarterPivotFieldItem2);
            quarterPivotField.Items.Add(quarterPivotFieldItem3);
            quarterPivotField.Items.Add(quarterPivotFieldItem4);
            quarterPivotField.Items.Add(quarterPivotFieldItem5);

            PivotField salesPivotField = new PivotField();
            salesPivotField.IsDataField = true;

            pivotTable1.PivotFields.Add(productPivotField);
            pivotTable1.PivotFields.Add(quarterPivotField);
            pivotTable1.PivotFields.Add(salesPivotField);

            Field productField = new Field(0);
            pivotTable1.RowFields.Add(productField);

            Field quarterField = new Field(1);
            pivotTable1.ColumnFields.Add(quarterField);

            DataField salesField = new DataField(2);
            pivotTable1.DataFields.Add(salesField);
            
            PivotCache pivotCache1 = new PivotCache();
            pivotCache1.RefreshOnLoad = true;

            PivotCacheSource cacheSource = new PivotCacheSource();
            cacheSource.WorksheetSource = new WorksheetSource("TestSheet", "A1:C17");
            cacheSource.Type = SourceType.Worksheet;

            pivotCache1.Source = cacheSource;

            PivotCacheField productCacheField = new PivotCacheField("Product");

            productCacheField.SharedItems = new SharedItems();
            productCacheField.SharedItems.Values.Add(new StringValue(product1));
            productCacheField.SharedItems.Values.Add(new StringValue(product2));
            productCacheField.SharedItems.Values.Add(new StringValue(product3));
            productCacheField.SharedItems.Values.Add(new StringValue(product4));
            productCacheField.SharedItems.Values.Add(new StringValue(product5));

            PivotCacheField quarterCacheField = new PivotCacheField("Quarter");

            quarterCacheField.SharedItems = new SharedItems();
            quarterCacheField.SharedItems.Values.Add(new StringValue(quarter1));
            quarterCacheField.SharedItems.Values.Add(new StringValue(quarter2));
            quarterCacheField.SharedItems.Values.Add(new StringValue(quarter3));
            quarterCacheField.SharedItems.Values.Add(new StringValue(quarter4));

            PivotCacheField salesCacheField = new PivotCacheField("Sales");

            pivotCache1.Fields.Add(productCacheField);
            pivotCache1.Fields.Add(quarterCacheField);
            pivotCache1.Fields.Add(salesCacheField);

            PivotCacheRecord record1 = new PivotCacheRecord();
            record1.Values.Add(new StringValue(product1));
            record1.Values.Add(new StringValue(quarter1));
            record1.Values.Add(new NumericValue(salesP1Q1));

            PivotCacheRecord record2 = new PivotCacheRecord();
            record2.Values.Add(new StringValue(product1));
            record2.Values.Add(new StringValue(quarter3));
            record2.Values.Add(new NumericValue(salesP1Q3));

            PivotCacheRecord record3 = new PivotCacheRecord();
            record3.Values.Add(new StringValue(product1));
            record3.Values.Add(new StringValue(quarter4));
            record3.Values.Add(new NumericValue(salesP1Q4));

            PivotCacheRecord record4 = new PivotCacheRecord();
            record4.Values.Add(new StringValue(product2));
            record4.Values.Add(new StringValue(quarter1));
            record4.Values.Add(new NumericValue(salesP2Q1));

            PivotCacheRecord record5 = new PivotCacheRecord();
            record5.Values.Add(new StringValue(product2));
            record5.Values.Add(new StringValue(quarter2));
            record5.Values.Add(new NumericValue(salesP2Q2));

            PivotCacheRecord record6 = new PivotCacheRecord();
            record6.Values.Add(new StringValue(product2));
            record6.Values.Add(new StringValue(quarter3));
            record6.Values.Add(new NumericValue(salesP2Q3));

            PivotCacheRecord record7 = new PivotCacheRecord();
            record7.Values.Add(new StringValue(product2));
            record7.Values.Add(new StringValue(quarter4));
            record7.Values.Add(new NumericValue(salesP2Q4));

            PivotCacheRecord record8 = new PivotCacheRecord();
            record8.Values.Add(new StringValue(product3));
            record8.Values.Add(new StringValue(quarter1));
            record8.Values.Add(new NumericValue(salesP3Q1));

            PivotCacheRecord record9 = new PivotCacheRecord();
            record9.Values.Add(new StringValue(product3));
            record9.Values.Add(new StringValue(quarter3));
            record9.Values.Add(new NumericValue(salesP3Q3));

            PivotCacheRecord record10 = new PivotCacheRecord();
            record10.Values.Add(new StringValue(product3));
            record10.Values.Add(new StringValue(quarter4));
            record10.Values.Add(new NumericValue(salesP3Q4));

            PivotCacheRecord record11 = new PivotCacheRecord();
            record11.Values.Add(new StringValue(product4));
            record11.Values.Add(new StringValue(quarter3));
            record11.Values.Add(new NumericValue(salesP4Q3));

            PivotCacheRecord record12 = new PivotCacheRecord();
            record12.Values.Add(new StringValue(product4));
            record12.Values.Add(new StringValue(quarter4));
            record12.Values.Add(new NumericValue(salesP4Q4));

            PivotCacheRecord record13 = new PivotCacheRecord();
            record13.Values.Add(new StringValue(product5));
            record13.Values.Add(new StringValue(quarter1));
            record13.Values.Add(new NumericValue(salesP5Q1));

            PivotCacheRecord record14 = new PivotCacheRecord();
            record14.Values.Add(new StringValue(product5));
            record14.Values.Add(new StringValue(quarter2));
            record14.Values.Add(new NumericValue(salesP5Q2));

            PivotCacheRecord record15 = new PivotCacheRecord();
            record15.Values.Add(new StringValue(product5));
            record15.Values.Add(new StringValue(quarter3));
            record15.Values.Add(new NumericValue(salesP5Q3));

            PivotCacheRecord record16 = new PivotCacheRecord();
            record16.Values.Add(new StringValue(product5));
            record16.Values.Add(new StringValue(quarter4));
            record16.Values.Add(new NumericValue(salesP5Q4));

            pivotCache1.Records.Add(record1);
            pivotCache1.Records.Add(record2);
            pivotCache1.Records.Add(record3);
            pivotCache1.Records.Add(record4);
            pivotCache1.Records.Add(record5);
            pivotCache1.Records.Add(record6);
            pivotCache1.Records.Add(record7);
            pivotCache1.Records.Add(record8);
            pivotCache1.Records.Add(record9);
            pivotCache1.Records.Add(record10);
            pivotCache1.Records.Add(record11);
            pivotCache1.Records.Add(record12);
            pivotCache1.Records.Add(record13);
            pivotCache1.Records.Add(record14);
            pivotCache1.Records.Add(record15);
            pivotCache1.Records.Add(record16);

            pivotTable1.PivotCache = pivotCache1;

            sheet1.PivotTables.Add(pivotTable1);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);
            
            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
