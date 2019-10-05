using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CptS321
{
    /// <summary>
    /// Manages two dimensional array of Cells
    /// </summary>
    public class Spreadsheet
    {
        public event PropertyChangedEventHandler CellPropertyChanged;

        private int rows;
        private int cols;
        private Cell[,] cells;

        /// <summary>
        /// Property to get rows
        /// </summary>
        public int RowCount
        {
            get { return rows; }
        }

        /// <summary>
        /// Property to get columns
        /// </summary>
        public int ColumnCount
        {
            get { return cols; }
        }

        /// <summary>
        /// Initializes the two dimensional array of Cells and subscribes to each cell's PropertyChangedEventHandler
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="cols">Number of columns</param>
        public Spreadsheet(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cells[i, j] = new ConcreteCell(i, j);
                    cells[i, j].PropertyChanged += OnCellPropertyChange;

                }
            }
        }

        /// <summary>
        /// Gets cell by row and col
        /// </summary>
        /// <param name="row">Cell's row</param>
        /// <param name="col">Cell's column</param>
        /// <returns></returns>
        public Cell GetCell(int row, int col)
        {
            return cells[row, col] == null ? null : cells[row, col];
        }

        /// <summary>
        /// Gets cell by name
        /// </summary>
        /// <param name="CellName">Cell's name</param>
        /// <returns></returns>
        public Cell GetCell(string CellName)
        {
            string col = CellName.Substring(1);
            int rowNum = -1;

            rowNum = Int32.Parse(col);

            if (!Char.IsLetter(CellName[0]) || rowNum > rows || rowNum < 0)
                return null;

            return GetCell(rowNum - 1, CellName[0] - 65);
        }

        /// <summary>
        /// Evaluates and sets the value of current cell
        /// </summary>
        /// <param name="sender">Cell</param>
        /// <param name="e">PropertyChangedEventHandler</param>
        protected void OnCellPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                if ((sender as Cell).Text[0] == '=')
                {
                    string otherCell = (sender as Cell).Text.Substring(1);

                    //Evaluate Formula (supports '=' only)
                    (sender as Cell).Value = GetCell(otherCell).Value;
                }
                else
                    (sender as Cell).Value = (sender as Cell).Text;
            }
            CellPropertyChanged?.Invoke(sender, e); //Lets the UI know that a cells value has changed

        }
    }
}
