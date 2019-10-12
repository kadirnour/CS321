using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Concrete Node for ExpressionTree that holds a constant value and type
    /// </summary>
    public class ConstantNode : Node
    {
        /// <summary>
        /// Property for node value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Constructor that sets node value
        /// </summary>
        /// <param name="value"></param>
        public ConstantNode(double value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Node value
        /// </summary>
        /// <returns>Node value</returns>
        public override double Eval()
        {
            throw new NotImplementedException();
        }
    }
}
