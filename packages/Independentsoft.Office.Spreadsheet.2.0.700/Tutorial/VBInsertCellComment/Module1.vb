Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Spreadsheet.Comments

Module Module1
    Sub Main(ByVal args As String())

        Dim sheet1 As New Worksheet()
        sheet1("A1") = New Cell(100)

        Dim john As New Author()
        john.Name = "John"

        sheet1.CommentSet = New CommentSet()

        sheet1.CommentSet.Authors.Add(john)
        Dim johnID As Integer = sheet1.CommentSet.Authors.Count - 1

        Dim comment1 As New Comment()
        comment1.AuthorID = johnID
        comment1.CellReference = "A1"

        Dim run1 As New Run()
        run1.Text = New Text("Author: John" & Environment.NewLine)
        run1.Bold = True

        Dim run2 As New Run()
        run2.Text = New Text("This is a comment")

        comment1.Runs.Add(run1)
        comment1.Runs.Add(run2)

        'Create comment text box 
        Dim layout1 As New ShapeLayout()
        layout1.ExtensionHandlingBehavior = ExtensionHandlingBehavior.Editable

        Dim template1 As New ShapeTemplate()
        template1.ID = "template1"
        template1.CoordinateSpaceSize = "21600,21600"
        template1.EdgePath = "m,l,21600r21600,l21600,xe"
        template1.OptionalNumberID = 202

        Dim stroke1 As New Stroke()
        stroke1.JoinStyle = StrokeJoinStyle.Miter

        Dim path1 As New ShapePath()
        path1.EnableGradient = True
        path1.ConnectionPointType = ConnectType.Four

        template1.Content.Add(stroke1)
        template1.Content.Add(path1)

        Dim shape1 As New Shape()
        shape1.ID = "1"
        shape1.TypeReference = "template1"
        shape1.FillColor = "#FFFFE1"
        shape1.TextInsetMode = InsetMode.Auto

        Dim style1 As New ShapeStyle()
        style1.Position = Position.Absolute
        style1.LeftMargin = "59.25pt"
        style1.TopMargin = "1.5pt"
        style1.Width = "96pt"
        style1.Height = "55.5pt"
        style1.ZIndex = "1"

        Dim fill1 As New Fill()
        fill1.SecondaryColor = "#FFFFE1"

        Dim shadow1 As New Shadow()
        shadow1.Display = True
        shadow1.PrimaryColor = "black"
        shadow1.IsTransparent = True

        Dim textBox1 As New TextBox()

        Dim clientData1 As New ClientData()
        clientData1.ObjectType = ObjectType.Note
        clientData1.MoveWithCells = True
        clientData1.SizeWithCells = True
        clientData1.Anchor = New Anchor(1, 15, 0, 2, 3, 15, 3, 16)
        clientData1.CommentRow = 0
        clientData1.CommentColumn = 0
        clientData1.CommentVisibility = True

        shape1.Content.Add(fill1)
        shape1.Content.Add(shadow1)
        shape1.Content.Add(textBox1)
        shape1.Content.Add(clientData1)


        sheet1.CommentSet.Comments.Add(comment1)
        sheet1.VmlObjects.Add(layout1)
        sheet1.VmlObjects.Add(template1)
        sheet1.VmlObjects.Add(shape1)

        Dim book As New Workbook()
        book.Sheets.Add(sheet1)

        book.Save("c:\test\output.xlsx", True)

    End Sub
End Module