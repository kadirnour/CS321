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
            if(expression == "") { Console.WriteLine("Empty Expression"); return; }
            this.Expression = expression.Replace(" ", ""); //remove whitespace
            this.tokens = Regex.Split(this.Expression, opPattern);

            BuildTree();
        }

        /// <summary>
        /// Sets specified variable value to a variable by name. Updates the Variable dictionary in VariableReference
        /// </summary>
        /// <param name="variableName">name</param>
        /// <param name="variableValue">value</param>
        public void SetVariable(string variableName, string variableValue)
        {
            if (tokens == null) { throw new Exception("No Expression"); }
            foreach (string x in tokens)
            {
                if (x == variableName)
                {
                    VariableReference.Instance.VariableDictionary[variableName] = float.Parse(variableValue);
                    return;
                }
            }
            throw new Exception("Variable Not In Expression");
        }

        /// <summary>
        /// Recursive Evaluate helper
        /// </summary>
        /// <param name="node">root node</param>
        /// <returns>double value</returns>
        private double? Evaluate(Node node)
        {
            return node.Eval();
        }

        /// <summary>
        /// Evaluates ExpressionTree from root
        /// </summary>
        /// <returns>evaluated double or null</returns>
        public double? Evaluate()
        {
            try
            {
                return Evaluate(root);
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Reorders ExpressionTree.tokens to Postfix
        /// </summary>
        private void ToPostFix()
        {
            Stack<string> opStack = new Stack<string>();
            string[] postfixTokens = new string[tokens.Length];

            int j = 0;
            foreach (string s in tokens)
            {
                if(!Regex.IsMatch(s, opPattern))
                {
                    postfixTokens[j] = s;
                    j++;
                }
                else
                {
                    opStack.Push(s);
                }
            }

            while (opStack.Any())
            {
                postfixTokens[j] = opStack.Pop();
                j++;
            }

            tokens = postfixTokens;
        }

        /// <summary>
        /// Builds ExpressionTree with tokens
        /// </summary>
        private void BuildTree()
        {
            ToPostFix();
            Stack<Node> nodeStack = new Stack<Node>();
            OperatorFactory opFac = new OperatorFactory();

            foreach(string s in tokens)
            {
                if(Regex.IsMatch(s, @"[0-9]"))
                {
                    nodeStack.Push(new ConstantNode(float.Parse(s)));
                }
                else if(Regex.IsMatch(s, @"^[a-zA-z]"))
                {
                    nodeStack.Push(new VariableNode(s));
                    VariableReference.Instance.VariableDictionary.Add(s, null);
                }
                else
                {
                    OperatorNode op = opFac.CreateOperatorNode(s);
                    op.Right = nodeStack.Pop();
                    op.Left = nodeStack.Pop();

                    nodeStack.Push(op);
                }
            }

            root = nodeStack.Pop();
        }

    }
}
