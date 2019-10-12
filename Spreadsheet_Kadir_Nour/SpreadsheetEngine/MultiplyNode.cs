using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Multiply Operator Node
    /// </summary>
    public class MultiplyNode : OperatorNode
    {
        /// <summary>
        /// Constructor for multiply
        /// </summary>
        public MultiplyNode()
        {
            this.Type = "*";
            this.Left = null;
            this.Right = null;
        }
        /// <summary>
        /// Specific Eval for multiply
        /// </summary>
        /// <returns>double value</returns>
        public override double Eval()
        {
            return this.Left.Eval() * this.Right.Eval();
        }
    }

}


