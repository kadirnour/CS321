using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Base class for all Commands that follow the Command Patttern
    /// </summary>
    public class CommandCollection
    {
        protected string message;
        protected Stack<string> prevText = new Stack<string>();
        protected Stack<string> curText = new Stack<string>();
        protected Stack<uint> prevColor = new Stack<uint>();
        protected Stack<uint> curColor = new Stack<uint>();
        protected Stack<Cell> prevCell = new Stack<Cell>();
        protected Stack<Cell> curCell = new Stack<Cell>();

        /// <summary>
        /// Virtual Undo action for CommandCollection
        /// </summary>
        public virtual void Undo() { }

        /// <summary>
        /// Virtual Redo action for CommandCollection
        /// </summary>
        public virtual void Redo() { }

        public string GetMessage
        {
            get { return message; }
            set { message = value; }
        }
    }
}
