using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Factory for Operator Nodes
    /// </summary>
    public class OperatorFactory
    {
        /// <summary>
        /// Creates appropreate operator node
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public OperatorNode CreateOperatorNode(string op)
        {
            switch (op)
            {
                case "+":
                    return new PlusNode();
                case "-":
                    return new MinusNode();
                case "*":
                    return new MultiplyNode();
                case "/":
                    return new DivideNode();
                case "^":
                    return new ExponentNode();
                default:
                    throw new Exception("Unsupported Operator");
            }
        }
    }
}
