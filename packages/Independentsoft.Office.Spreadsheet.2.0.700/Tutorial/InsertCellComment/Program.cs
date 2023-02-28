using System;
using Independentsoft.Office;
using Independentsoft.Office.Vml;
using Independentsoft.Office.Spreadsheet;
using Independentsoft.Office.Spreadsheet.Comments;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Worksheet sheet1 = new Worksheet();
            sheet1["A1"] = new Cell(100);

            Author john = new Author();
            john.Name = "John";

            sheet1.CommentSet = new CommentSet();

            sheet1.CommentSet.Authors.Add(john);
            int johnID = sheet1.CommentSet.Authors.Count - 1;

            Comment comment1 = new Comment();
            comment1.AuthorID = johnID;
            comment1.CellReference = "A1";

            Run run1 = new Run();
            run1.Text = new Text("Author: John\r\n");
            run1.Bold = true;

            Run run2 = new Run();
            run2.Text = new Text("This is a comment");

            comment1.Runs.Add(run1);
            comment1.Runs.Add(run2);

            //Create comment text box
            ShapeLayout layout1 = new ShapeLayout();
            layout1.ExtensionHandlingBehavior = ExtensionHandlingBehavior.Editable;

            ShapeTemplate template1 = new ShapeTemplate();
            template1.ID = "template1";
            template1.CoordinateSpaceSize = "21600,21600";
            template1.EdgePath = "m,l,21600r21600,l21600,xe";
            template1.OptionalNumberID = 202;

            Stroke stroke1 = new Stroke();
            stroke1.JoinStyle = StrokeJoinStyle.Miter;

            ShapePath path1 = new ShapePath();
            path1.EnableGradient = true;
            path1.ConnectionPointType = ConnectType.Four;

            template1.Content.Add(stroke1);
            template1.Content.Add(path1);

            Shape shape1 = new Shape();
            shape1.ID = "1";
            shape1.TypeReference = "template1";
            shape1.FillColor = "#FFFFE1";
            shape1.TextInsetMode = InsetMode.Auto;

            ShapeStyle style1 = new ShapeStyle();
            style1.Position = Position.Absolute;
            style1.LeftMargin = "59.25pt";
            style1.TopMargin = "1.5pt";
            style1.Width = "96pt";
            style1.Height = "55.5pt";
            style1.ZIndex = "1";

            Fill fill1 = new Fill();
            fill1.SecondaryColor = "#FFFFE1";

            Shadow shadow1 = new Shadow();
            shadow1.Display = true;
            shadow1.PrimaryColor = "black";
            shadow1.IsTransparent = true;

            TextBox textBox1 = new TextBox();

            ClientData clientData1 = new ClientData();
            clientData1.ObjectType = ObjectType.Note;
            clientData1.MoveWithCells = true;
            clientData1.SizeWithCells = true;
            clientData1.Anchor = new Anchor(1,15,0,2,3,15,3,16);
            clientData1.CommentRow = 0;
            clientData1.CommentColumn = 0;
            clientData1.CommentVisibility = true;

            shape1.Content.Add(fill1);
            shape1.Content.Add(shadow1);
            shape1.Content.Add(textBox1);
            shape1.Content.Add(clientData1);


            sheet1.CommentSet.Comments.Add(comment1);
            sheet1.VmlObjects.Add(layout1);
            sheet1.VmlObjects.Add(template1);
            sheet1.VmlObjects.Add(shape1);

            Workbook book = new Workbook();
            book.Sheets.Add(sheet1);

            book.Save("c:\\test\\output.xlsx", true);
        }
    }
}
