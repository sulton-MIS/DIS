Imports Independentsoft.Office.Spreadsheet

Public Class Form1

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim dialog As New OpenFileDialog()
        dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"

        If DialogResult.OK = dialog.ShowDialog() Then
            OpenWorkbook(dialog.FileName)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim dialog As New SaveFileDialog()
        dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx"

        If DialogResult.OK = dialog.ShowDialog() Then
            SaveWorkbook(dialog.FileName)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.[Exit]()
    End Sub


    Private Sub OpenWorkbook(ByVal filePath As String)
        Me.TabControl1.Controls.Clear()

        Dim book As New Workbook(filePath)
        Dim tabIndex As Integer = -1

        For s As Integer = 0 To book.Sheets.Count - 1
            If TypeOf book.Sheets(s) Is Worksheet Then
                tabIndex += 1

                Dim sheet As Worksheet = DirectCast(book.Sheets(s), Worksheet)

                Dim dataGridView As New DataGridView()
                dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dataGridView.Dock = System.Windows.Forms.DockStyle.Fill
                dataGridView.Location = New System.Drawing.Point(3, 3)
                dataGridView.Name = "dataGridView" & tabIndex
                dataGridView.Size = New System.Drawing.Size(1234, 688)
                dataGridView.TabIndex = tabIndex
                dataGridView.ScrollBars = ScrollBars.Both

                Dim tabPage As New TabPage()
                tabPage.Tag = dataGridView
                tabPage.Controls.Add(dataGridView)
                tabPage.Location = New System.Drawing.Point(4, 22)
                tabPage.Name = sheet.Name
                tabPage.Padding = New System.Windows.Forms.Padding(3)
                tabPage.Size = New System.Drawing.Size(1240, 694)
                tabPage.TabIndex = tabIndex
                tabPage.Text = sheet.Name
                tabPage.UseVisualStyleBackColor = True

                Me.TabControl1.Controls.Add(tabPage)

                Dim dataTable As New DataTable()

                For i As Integer = 0 To sheet.Rows.Count - 1
                    Dim row As Row = sheet.Rows(i)
                    Dim dataRow As DataRow = dataTable.NewRow()

                    If row IsNot Nothing Then
                        Dim cellValues As String() = New String(row.Cells.Count - 1) {}

                        If dataTable.Columns.Count < row.Cells.Count Then
                            For k As Integer = dataTable.Columns.Count To row.Cells.Count - 1
                                dataTable.Columns.Add(New DataColumn())
                            Next
                        End If

                        For j As Integer = 0 To row.Cells.Count - 1
                            Dim cell As Cell = row.Cells(j)

                            If cell IsNot Nothing Then
                                cellValues(j) = cell.Value
                            Else
                                cellValues(j) = ""
                            End If
                        Next

                        dataRow.ItemArray = cellValues
                    End If

                    dataTable.Rows.Add(dataRow)
                Next

                dataGridView.DataSource = dataTable

                For r As Integer = 0 To dataGridView.Rows.Count - 1
                    Dim rowIndex As String = (r + 1).ToString()

                    dataGridView.Rows(r).HeaderCell.Value = rowIndex
                    dataGridView.Rows(r).HeaderCell.ToolTipText = rowIndex
                Next

                dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
            End If
        Next
    End Sub

    Private Sub SaveWorkbook(ByVal filePath As String)
        Dim book As New Workbook()

        For t As Integer = 0 To TabControl1.TabPages.Count - 1
            Dim tabPage As TabPage = TabControl1.TabPages(t)
            Dim dataGridView As DataGridView = DirectCast(tabPage.Tag, DataGridView)
            Dim dataTable As DataTable = DirectCast(dataGridView.DataSource, DataTable)

            Dim sheet As New Worksheet()
            sheet.Name = tabPage.Name

            For i As Integer = 0 To dataTable.Rows.Count - 1
                Dim dataRow As DataRow = dataTable.Rows(i)
                Dim row As New Row()

                Dim values As Object() = dataRow.ItemArray

                For c As Integer = 0 To values.Length - 1
                    If values(c) IsNot Nothing Then
                        Dim cell As New Cell(values(c).ToString())
                        row.Cells.Add(cell)
                    End If
                Next

                sheet.Rows.Add(row)
            Next

            book.Sheets.Add(sheet)
        Next

        book.Save(filePath, True)
    End Sub

End Class
