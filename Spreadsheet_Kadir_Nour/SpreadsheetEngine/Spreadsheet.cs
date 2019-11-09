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
        private ExpressionTree et;
        private Dictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();
        private UndoRedo UndoRedo = new UndoRedo();

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

        public string getCellName(int row, int column)
        {
            return ((char)(column + 65)).ToString() + (row + 1).ToString();
        }

        public void update(string myName, List<string> cellNames)
        {
            if (dependencies.ContainsKey(myName)) dependencies.Remove(myName);
            foreach (string name in cellNames)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(name, @"[A-Z][0-9]") && dependencies.ContainsKey(myName))
                    dependencies[myName].Add(name);
                else if (System.Text.RegularExpressions.Regex.IsMatch(name, @"[A-Z][0-9]"))
                    dependencies.Add(myName, new List<string>() { name });
            }
        }
        public void eval(object sender)
        {
            Cell otherCell;
            List<string> cellNames;
            Cell currentCell = sender as Cell;
            string myName = getCellName(currentCell.RowIndex, currentCell.ColumnIndex);

            et = new ExpressionTree(currentCell.Text.Substring(1));
            cellNames = et.GetVariables();

            foreach (string name in cellNames)
            {
                otherCell = GetCell(name);
                et.SetVariable(name, otherCell.Value);
            }
            currentCell.Value = et.Evaluate().ToString();

            update(myName, cellNames);

           
        }

        /// <summary>
        /// Evaluates and sets the value of current cell
        /// </summary>
        /// <param name="sender">Cell</param>
        /// <param name="e">PropertyChangedEventHandler</param>
        protected void OnCellPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            Cell currentCell = sender as Cell;
            string myName = getCellName(currentCell.RowIndex, currentCell.ColumnIndex);
            if (e.PropertyName == "Text")
            {
                if(currentCell.Text == "")
                {
                    dependencies.Remove(myName);
                    currentCell.Value = "";
                }
                else if (currentCell.Text[0] == '=')
                {
                    eval(sender);
                }
                else
                    currentCell.Value = (sender as Cell).Text;
            }
            else if(e.PropertyName == "Value")
            {
                List<string> keys = dependencies.Keys.ToList<string>();
                foreach(string cell in keys)
                {
                    if (dependencies[cell].Contains(myName))
                    {
                        eval(GetCell(cell));
                    }
                }
            }

            CellPropertyChanged?.Invoke(sender, e); //Lets the UI know that a cells value has changed
        }

        /// <summary>
        /// Adds a CommandCollection to the Undo stack
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public void AddUndo(CommandCollection cmd)
        {
            UndoRedo.AddUndo(cmd);
        }

        /// <summary>
        /// Executes Undo action for top CommandCollection in the undo stack
        /// </summary>
        public void Undo()
        {
            UndoRedo.DoUndo().Undo();
        }

        /// <summary>
        /// Executes Redo action for top CommandCollection in the redo stack
        /// </summary>
        public void Redo()
        {
            UndoRedo.DoRedo().Redo();
        }

        /// <summary>
        /// Checks if undo stack contains CommandCollections
        /// </summary>
        /// <returns></returns>
        public bool CanUndo()
        {
            if (UndoRedo.IsUndoEmpty())
                return false;

            return true;
        }

        /// <summary>
        /// Checks if redo stack contains CommandCollections
        /// </summary>
        /// <returns></returns>
        public bool CanRedo()
        {
            if (UndoRedo.IsRedoEmpty())
                return false;

            return true;
        }

        /// <summary>
        /// Gets message field from top of undo stack
        /// </summary>
        /// <returns>string message</returns>
        public string GetUndoMessage()
        {
            return UndoRedo.GetUndoMessage();
        }

        /// <summary>
        /// Gets message field from top of redo stack
        /// </summary>
        /// <returns>string message</returns>
        public string GetRedoMessage()
        {
            return UndoRedo.GetRedoMessage();
        }
    }
}
