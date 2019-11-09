using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Concrete Command for restoring cell text
    /// </summary>
    public class TextChange : CommandCollection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="curCell"></param>
        /// <param name="prevCell"></param>
        /// <param name="curText"></param>
        /// <param name="prevText"></param>
        public TextChange(Stack<Cell> curCell, Stack<Cell> prevCell, Stack<string> curText, Stack<string> prevText)
        {
            this.message = "Text Change";
            this.curCell = curCell;
            this.prevCell = prevCell;
            this.curText = curText;
            this.prevText = prevText;
        }

        /// <summary>
        /// Concrete Undo action
        /// </summary>
        public override void Undo()
        {
            Stack<Cell> cellCmdStack = new Stack<Cell>(prevCell);
            Stack<string> textCmdStack = new Stack<string>(prevText);

            while (prevCell.Count > 0)
                prevCell.Pop().Text = prevText.Pop();

            prevCell = cellCmdStack;
            prevText = textCmdStack;
        }

        /// <summary>
        /// Concreate Redo action
        /// </summary>
        public override void Redo()
        {
            Stack<Cell> cellCmdStack = new Stack<Cell>(curCell);
            Stack<string> textCmdStack = new Stack<string>(curText);

            while (curCell.Count > 0)
                curCell.Pop().Text = curText.Pop();

            curCell = cellCmdStack;
            prevText = textCmdStack;
        }
    }
}
