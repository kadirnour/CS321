using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Plus Operator Node
    /// </summary>
    public class PlusNode : OperatorNode
    {
        /// <summary>
        /// Constructor for plus
        /// </summary>
        public PlusNode()
        {
            this.Type = "+";
            this.Left = null;
            this.Right = null;
        }
        /// <summary>
        /// Specific Eval for plus
        /// </summary>
        /// <returns></returns>
        public override double Eval()
        {
            return this.Left.Eval() + this.Right.Eval();
        }
    }

}

