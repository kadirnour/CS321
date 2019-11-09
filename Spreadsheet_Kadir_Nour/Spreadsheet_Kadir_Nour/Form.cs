using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;

namespace Spreadsheet_Kadir_Nour
{
    public partial class Form : System.Windows.Forms.Form
    {

        public Spreadsheet spreadsheet;

        public Form()
        {
            InitializeComponent();

            int AsciiValue = 65;
            int RowCount = 1;
            while (AsciiValue != 91)
            {
                string AsciiToString = char.ConvertFromUtf32(AsciiValue++);
                myGrid.Columns.Add(AsciiToString, AsciiToString);
            }
            while (RowCount != 51)
            {
                string RowToString = RowCount.ToString();
                myGrid.Rows.Add();
                myGrid.Rows[RowCount - 1].HeaderCell.Value = RowToString;
                RowCount++;
            }

            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.CellPropertyChanged += OnCellChanged;
        }

        /// <summary>
        /// Sets value of UI grid cell to the value of the backend Cell
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e"></param>
        private void OnCellChanged(object sender, PropertyChangedEventArgs e)
        {
            myGrid.Rows[(sender as Cell).RowIndex].Cells[(sender as Cell).ColumnIndex].Value = (sender as Cell).Value;
            myGrid.Rows[(sender as Cell).RowIndex].Cells[(sender as Cell).ColumnIndex].Style.BackColor = Color.FromArgb((int)(sender as Cell).BGColor);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellColorChanged(object sender, EventArgs e)
        {
            Stack<Cell> curCells = new Stack<Cell>();
            Stack<Cell> prevCells = new Stack<Cell>();

            Stack<uint> curColor = new Stack<uint>();
            Stack<uint> prevColor = new Stack<uint>();

            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();

            foreach(DataGridViewCell cell in myGrid.SelectedCells)
            {
                Cell logicCell = spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex);
                curCells.Push(logicCell);
                prevCells.Push(logicCell);

                prevColor.Push(logicCell.BGColor);
                logicCell.BGColor = (uint) cd.Color.ToArgb();
                curColor.Push(logicCell.BGColor);
            }

            BGColorChange cmd = new BGColorChange(curCells, prevCells, curColor, prevColor);
            spreadsheet.AddUndo(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string text = spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Text;

            if(text != "")
               myGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = text;

        }

        /// <summary>
        /// Sets the UI grid cell's value to the backend cell's text. Sends current change to undo stack
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">CellEndEdit</param>
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Stack<Cell> curCells = new Stack<Cell>();
            Stack<Cell> prevCells = new Stack<Cell>();

            Stack<string> curText = new Stack<string>();
            Stack<string> prevText = new Stack<string>();

            if (spreadsheet == null) { return; }
            object text = myGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if(text == null) { text = ""; }
            Cell cell = spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);
            string beforeText = cell.Text;
            cell.Text = text.ToString();

            curCells.Push(cell);
            prevCells.Push(cell);

            curText.Push(cell.Text);
            prevText.Push(beforeText);

            TextChange cmd = new TextChange(curCells, prevCells, curText, prevText);
            spreadsheet.AddUndo(cmd);

            myGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Value;
        }

        /// <summary>
        /// Changes Undo and Redo buttons text to match context. Supported: Text Change and BGColor Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditClick(object sender, EventArgs e)
        {
            if (!spreadsheet.CanUndo())
                undo_button.Enabled = false;
            else
            {
                undo_button.Enabled = true;
                undo_button.Text = "Undo";
                undo_button.Text += " " + spreadsheet.GetUndoMessage();
            }

            if (!spreadsheet.CanRedo())
                redo_button.Enabled = false;
            else
            {
                redo_button.Enabled = true;
                redo_button.Text = "Redo";
                redo_button.Text += " " + spreadsheet.GetRedoMessage();
            }
        }

        /// <summary>
        /// Executes Undo action to logic layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoClick(object sender, EventArgs e)
        {
            if (spreadsheet.CanUndo())
                spreadsheet.Undo();
        }

        /// <summary>
        /// Executes Redo action to logic layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedoClick(object sender, EventArgs e)
        {
            if (spreadsheet.CanRedo())
                spreadsheet.Redo();
        }

        /// <summary>
        /// Demo 
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Button Click</param>
        private void DemoButton(object sender, EventArgs e)
        {
            Random rand = new Random();
            string str = "Hello World!";
            for (int i = 0; i < 50; i++)
            {
                spreadsheet.GetCell(rand.Next(50), rand.Next(2, 26)).Text = str;
                spreadsheet.GetCell(i, 1).Text = "This is cell B" + (i + 1);
                spreadsheet.GetCell(i, 0).Text = "=B" + (i + 1);
            }
        }
    }
}
