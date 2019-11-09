using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Concrete Command for restoring cell back ground color
    /// </summary>
    public class BGColorChange : CommandCollection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="curCell"></param>
        /// <param name="prevCell"></param>
        /// <param name="curColor"></param>
        /// <param name="prevColor"></param>
        public BGColorChange(Stack<Cell> curCell, Stack<Cell> prevCell, Stack<uint> curColor, Stack<uint> prevColor)
        {
            this.message = "BGColor Change";
            this.curCell = curCell;
            this.prevCell = prevCell;
            this.curColor = curColor;
            this.prevColor = prevColor;
        }

        /// <summary>
        /// Concrete Undo action
        /// </summary>
        public override void Undo()
        {
            Stack<Cell> cellCmdStack = new Stack<Cell>(prevCell);
            Stack<uint> colorCmdStack = new Stack<uint>(prevColor);

            while (prevCell.Count > 0)
                prevCell.Pop().BGColor = prevColor.Pop();

            prevCell = cellCmdStack;
            prevColor = colorCmdStack;
        }

        /// <summary>
        /// Concrete Redo action
        /// </summary>
        public override void Redo()
        {
            Stack<Cell> cellCmdStack = new Stack<Cell>(curCell);
            Stack<uint> colorCmdStack = new Stack<uint>(curColor);

            while (curCell.Count > 0)
                curCell.Pop().BGColor = curColor.Pop();

            curCell = cellCmdStack;
            prevColor = colorCmdStack;
        }
    }
}
