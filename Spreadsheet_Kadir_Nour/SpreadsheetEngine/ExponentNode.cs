using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Exponent Operator Node
    /// </summary>
    public class ExponentNode : OperatorNode
    {
        /// <summary>
        /// Constructor for exponent
        /// </summary>
        public ExponentNode()
        {
            this.Type = "^";
            this.Left = null;
            this.Right = null;
        }
        /// <summary>
        /// Specific Eval for exponent
        /// </summary>
        /// <returns>double value</returns>
        public override double Eval()
        {
            return Math.Pow(this.Left.Eval(), this.Right.Eval());
        }
    }

}

