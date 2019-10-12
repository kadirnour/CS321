using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Concrete Node for ExpressionTree that holds the name, type and value
    /// </summary>
    public class VariableNode : Node
    {
        public string Name { get; set; }

        /// <summary>
        /// Constructor that sets variable name
        /// </summary>
        /// <param name="name">variable name</param>
        public VariableNode(string name)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Evaluates value of variable node. Gets value from VariableReference dictionary
        /// </summary>
        /// <returns>Node value</returns>
        public override double Eval()
        {
            throw new NotImplementedException();
        }
    }
}
