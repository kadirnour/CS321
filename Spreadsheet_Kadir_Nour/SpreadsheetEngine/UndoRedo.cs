using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Invoker for CommandCollection following Command Pattern
    /// </summary>
    public class UndoRedo
    {
        private Stack<CommandCollection> undoStack = new Stack<CommandCollection>();
        private Stack<CommandCollection> redoStack = new Stack<CommandCollection>();

        /// <summary>
        /// Adds a command to the undo stack
        /// </summary>
        /// <param name="command">command from supported commands</param>
        public void AddUndo(CommandCollection cmd)
        {
            undoStack.Push(cmd);
            redoStack.Clear();
        }

        /// <summary>
        /// Hidden method for Undo
        /// </summary>
        /// <returns>Top CommandCollection</returns>
        public CommandCollection DoUndo()
        {
            CommandCollection cmd = undoStack.Pop();
            redoStack.Push(cmd);
            return cmd;
        }

        /// <summary>
        /// HIdden method for Redo
        /// </summary>
        /// <returns>Top CommandCollection</returns>
        public CommandCollection DoRedo()
        {
            CommandCollection cmd = redoStack.Pop();
            undoStack.Push(cmd);
            return cmd;
        }

        /// <summary>
        /// Checks if undo stack is empty
        /// </summary>
        /// <returns>bool </returns>
        public bool IsUndoEmpty() // true if undo stack is empty
        {
            if (undoStack.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if redo stack is empty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsRedoEmpty()
        {
            if (redoStack.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Hidden method for Spreadsheet.GetUndoMessage()
        /// </summary>
        /// <returns>Top CommandCollection messsage</returns>
        public string GetUndoMessage()
        {
            CommandCollection cmd = undoStack.Peek();
            return cmd.GetMessage;
        }

        /// <summary>
        /// Hidden method for Spreadsheet.GetRedoMessage()
        /// </summary>
        /// <returns>Top CommandCollection messsage</returns>
        public string GetRedoMessage()
        {
            CommandCollection cmd = redoStack.Peek();
            return cmd.GetMessage;
        }
    }
}
