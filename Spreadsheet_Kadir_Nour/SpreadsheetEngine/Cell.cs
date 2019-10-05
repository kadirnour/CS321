using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CptS321
{
    /// <summary>
    /// Abstract base class that defines a backend cell to hold rowIndex, colIndex, text and value
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int rowIndex;
        protected int columnIndex;
        protected string text;
        protected string value;

        /// <summary>
        /// Propert to get rowIndex
        /// </summary>
        public int RowIndex
        {
            get { return rowIndex; }
        }

        /// <summary>
        /// property to get columnIndex
        /// </summary>
        public int ColumnIndex
        {
            get { return columnIndex; }
        }

        /// <summary>
        /// property to get/set text
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (value != text)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }

            }
        }

        /// <summary>
        /// Property to get/set value
        /// </summary>
        public string Value
        {
            get { return value; }

            //Allows only the inherited class and classes within the same assembly to set value
            protected internal set 
            {
                if (value != this.value)
                {
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Sets rowIndex, columnIndex and initial value of cell
        /// </summary>
        /// <param name="row">Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        public Cell(int row, int col)
        {
            rowIndex = row;
            columnIndex = col;
            text = value = "";
        }

        /// <summary>
        /// Creates a new PropertyChangedEvent
        /// </summary>
        /// <param name="name">Property name</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
