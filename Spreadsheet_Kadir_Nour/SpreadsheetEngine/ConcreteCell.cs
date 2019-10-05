using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CptS321
{
    /// <summary>
    /// Concrete Cell class that inherits from base Cell class.
    /// </summary>
    public class ConcreteCell : Cell
    {
        /// <summary>
        /// Calls base constructor to set row, col and initial values of the cell
        /// </summary>
        /// <param name="row"> Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        public ConcreteCell(int row, int col) : base(row, col) { }
    }
}

