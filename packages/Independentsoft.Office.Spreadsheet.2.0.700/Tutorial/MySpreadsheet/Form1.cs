using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Independentsoft.Office.Spreadsheet;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {             
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";

            if (DialogResult.OK == dialog.ShowDialog())
            {
                OpenWorkbook(dialog.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";

            if (DialogResult.OK == dialog.ShowDialog())
            {
                SaveWorkbook(dialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenWorkbook(string filePath)
        {
            tabControl1.Controls.Clear();

            Workbook book = new Workbook(filePath);
            int tabIndex = -1;

            for (int s = 0; s < book.Sheets.Count; s++)
            {
                if (book.Sheets[s] is Worksheet)
                {
                    tabIndex++;

                    Worksheet sheet = (Worksheet)book.Sheets[s];

                    DataGridView dataGridView = new DataGridView();
                    dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
                    dataGridView.Location = new System.Drawing.Point(3, 3);
                    dataGridView.Name = "dataGridView" + tabIndex;
                    dataGridView.Size = new System.Drawing.Size(1234, 688);
                    dataGridView.TabIndex = tabIndex;
                    dataGridView.ScrollBars = ScrollBars.Both;

                    TabPage tabPage = new TabPage();
                    tabPage.Tag = dataGridView;
                    tabPage.Controls.Add(dataGridView);
                    tabPage.Location = new System.Drawing.Point(4, 22);
                    tabPage.Name = sheet.Name;
                    tabPage.Padding = new System.Windows.Forms.Padding(3);
                    tabPage.Size = new System.Drawing.Size(1240, 694);
                    tabPage.TabIndex = tabIndex;
                    tabPage.Text = sheet.Name;
                    tabPage.UseVisualStyleBackColor = true;

                    this.tabControl1.Controls.Add(tabPage);

                    DataTable dataTable = new DataTable();

                    for (int i = 0; i < sheet.Rows.Count; i++)
                    {
                        Row row = sheet.Rows[i];
                        DataRow dataRow = dataTable.NewRow();

                        if (row != null)
                        {
                            string[] cellValues = new string[row.Cells.Count];

                            if (dataTable.Columns.Count < row.Cells.Count)
                            {
                                for (int k = dataTable.Columns.Count; k < row.Cells.Count; k++)
                                {
                                    dataTable.Columns.Add(new DataColumn());
                                }
                            }

                            for (int j = 0; j < row.Cells.Count; j++)
                            {
                                Cell cell = row.Cells[j];

                                if (cell != null)
                                {
                                    cellValues[j] = cell.Value;
                                }
                                else
                                {
                                    cellValues[j] = "";
                                }
                            }

                            dataRow.ItemArray = cellValues;
                        }

                        dataTable.Rows.Add(dataRow);
                    }

                    dataGridView.DataSource = dataTable;

                    for (int r = 0; r < dataGridView.Rows.Count; r++)
                    {
                        string rowIndex = (r + 1).ToString();

                        dataGridView.Rows[r].HeaderCell.Value = rowIndex;
                        dataGridView.Rows[r].HeaderCell.ToolTipText = rowIndex;
                    }

                    dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                }
            }
        }

        private void SaveWorkbook(string filePath)
        {
            Workbook book = new Workbook();

            for (int t = 0; t < tabControl1.TabPages.Count; t++)
            {
                TabPage tabPage = tabControl1.TabPages[t];
                DataGridView dataGridView = (DataGridView)tabPage.Tag;
                DataTable dataTable = (DataTable)dataGridView.DataSource;

                Worksheet sheet = new Worksheet();
                sheet.Name = tabPage.Name;

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    Row row = new Row();

                    object[] values = dataRow.ItemArray;

                    for (int c = 0; c < values.Length; c++)
                    {
                        if (values[c] != null)
                        {
                            Cell cell = new Cell(values[c].ToString());
                            row.Cells.Add(cell);
                        }
                    }

                    sheet.Rows.Add(row);
                }

                book.Sheets.Add(sheet);
            }

            book.Save(filePath, true);
        }
    }
}