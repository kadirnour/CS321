using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CptS321

{
    /// <summary>
    /// ExpressionTree generator
    /// </summary>
    public class ExpressionTree
    {
        private Node root;

        public string opPattern = @"(\+)|(\-)|(\*)|(\/)|(\^)";
        public string Expression;
        public string[] tokens;

        /// <summary>
        /// property for pattern. Returns pattern or appends new operator to pattern string
        /// </summary>
        public string Pattern
        {
            get { return opPattern; }
            set { opPattern += value; }
        }

        /// <summary>
        /// Constructs tree from given expression
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionTree(string expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets specified variable value to a variable by name. Updates the Variable dictionary in VariableReference
        /// </summary>
        /// <param name="variableName">name</param>
        /// <param name="variableValue">value</param>
        public void SetVariable(string variableName, string variableValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recursive Evaluate helper
        /// </summary>
        /// <param name="node">root node</param>
        /// <returns>double value</returns>
        private double? Evaluate(Node node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates ExpressionTree from root
        /// </summary>
        /// <returns>evaluated double or null</returns>
        public double? Evaluate()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reorders ExpressionTree.tokens to Postfix
        /// </summary>
        private void ToPostFix()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds ExpressionTree with tokens
        /// </summary>
        private void BuildTree()
        {
            throw new NotImplementedException();
        }

    }
}
