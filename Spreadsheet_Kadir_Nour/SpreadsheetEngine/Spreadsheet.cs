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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets cell by row and col
        /// </summary>
        /// <param name="row">Cell's row</param>
        /// <param name="col">Cell's column</param>
        /// <returns></returns>
        public Cell GetCell(int row, int col)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets cell by name
        /// </summary>
        /// <param name="CellName">Cell's name</param>
        /// <returns></returns>
        public Cell GetCell(string CellName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates and sets the value of current cell
        /// </summary>
        /// <param name="sender">Cell</param>
        /// <param name="e">PropertyChangedEventHandler</param>
        protected void OnCellPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
