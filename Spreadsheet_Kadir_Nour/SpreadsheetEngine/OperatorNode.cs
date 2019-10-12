using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Abstract OperatorNode for ExpressionTree. Extends Node
    /// </summary>
    public abstract class OperatorNode : Node
    {
        /// <summary>
        /// Property for pointer to Left ExpressionTree
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// Property for pointer to Left ExpressionTree
        /// </summary>
        public Node Right { get; set; }
    }

}
