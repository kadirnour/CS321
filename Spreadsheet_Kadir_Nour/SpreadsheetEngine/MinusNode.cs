using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Minus Operator Node
    /// </summary>
    public class MinusNode : OperatorNode
    {
        /// <summary>
        /// Constructor for minus
        /// </summary>
        public MinusNode()
        {
            this.Type = "-";
            this.Left = null;
            this.Right = null;
        }
        /// <summary>
        /// Specific Eval for minus
        /// </summary>
        /// <returns>double value</returns>
        public override double Eval()
        {
            return this.Left.Eval() - this.Right.Eval();
        }
    }

}

