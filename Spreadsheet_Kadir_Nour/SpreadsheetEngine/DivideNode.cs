using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Divide Operator Node
    /// </summary>
    public class DivideNode : OperatorNode
    {
        /// <summary>
        /// Constructor for divide
        /// </summary>
        public DivideNode()
        {
            this.Type = "/";
            this.Left = null;
            this.Right = null;
        }
        /// <summary>
        /// Specific Eval for divide
        /// </summary>
        /// <returns>double value</returns>
        public override double Eval()
        {
            try
            {
                return this.Left.Eval() / this.Right.Eval();
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
        }
    }

}

