using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Abstract Node for ExpressionTree
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Property for node type. Every node will have a type
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// Abstract method to be overridden. Every node will have an Eval()
        /// </summary>
        /// <returns></returns>
        public abstract double Eval();
    }
}
