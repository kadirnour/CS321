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

        //pattern to check if token is supported operator
        public string opPattern = @"(\+)|(\-)|(\*)|(\/)|(\^)|(\()|(\))";
        /*pattern for splitting mathematical expression. Credit: Wiktor Stribiżew on 
        https://stackoverflow.com/questions/34778288/using-regex-to-split-equations-with-variables-c-sharp
        */
        public string splitPattern = @"[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?|[-^+*/()]|\w+";
        public string Expression;
        public string[] tokens;
        private int tokenCount = 0;

        /// <summary>
        /// Constructs tree from given expression
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionTree(string expression)
        {
            if (expression == "") { Console.WriteLine("Empty Expression"); return; }
            this.Expression = expression.Replace(" ", ""); //remove whitespace
            var matches = Regex.Matches(this.Expression, splitPattern);

            tokens = new string[matches.Count];

            foreach (Match m in matches)
            {
                tokens[tokenCount++] = m.Value;
            }

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
        private double Evaluate(Node node)
        {
            return node.Eval();
        }

        /// <summary>
        /// Evaluates ExpressionTree from root
        /// </summary>
        /// <returns>evaluated double or null</returns>
        public double Evaluate()
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
        /// Returns if op1 has a higher precenence than op2
        /// </summary>
        /// <param name="op1">first string</param>
        /// <param name="op2">Second string</param>
        /// <returns>true if op1 has a higher precedence</returns>
        private bool IsHigherPrecedence(string op1, string op2)
        {
            //supported types are: +, -, *, / and ()
            int a = -1, b = -1;
            switch (op1)
            {
                case "+":
                    a = 1;
                    break;
                case "-":
                    a = 1;
                    break;
                case "*":
                    a = 2;
                    break;
                case "/":
                    a = 2;
                    break;
                case "^":
                    a = 3;
                    break;
                case "(":
                    a = 0;
                    break;
                case ")":
                    a = 4;
                    break;
                default:
                    break;
            }

            switch (op2)
            {
                case "+":
                    b = 1;
                    break;
                case "-":
                    b = 1;
                    break;
                case "*":
                    b = 2;
                    break;
                case "/":
                    b = 2;
                    break;
                case "(":
                    b = 0;
                    break;
                case "^":
                    b = 3;
                    break;
                case ")":
                    b = 4;
                    break;
                default:
                    break;
            }

            if (op1 == op2 && (op1 == "(" || op1 == ")"))
                a = 10;

            return a > b ? true : false;

        }

        /// <summary>
        /// Reorders ExpressionTree.tokens to Postfix
        /// </summary>
        private void ToPostFix()
        {
            Stack<string> opStack = new Stack<string>();
            List<string> postfixTokens = new List<string>();

            int j = 0;
            foreach (string s in tokens)
            {
                if (!Regex.IsMatch(s, opPattern))
                {
                    postfixTokens.Add(s);
                }
                else
                {
                    if (opStack.Count == 0 || s == "(")
                    {
                        opStack.Push(s);
                    }

                    else if (s == ")")
                    {
                        while (opStack.Count != 0 && opStack.Peek() != "(") postfixTokens.Add(opStack.Pop());
                        if (opStack.Count != 0) opStack.Pop();
                    }
                    else if (IsHigherPrecedence(s, opStack.Peek()))
                    {
                        opStack.Push(s);
                    }
                    else if (!IsHigherPrecedence(s, opStack.Peek()))
                    {
                        while (opStack.Count != 0 && s != "(") postfixTokens.Add(opStack.Pop());

                        opStack.Push(s);
                    }
                }
            }

            while (opStack.Any())
            {
                postfixTokens.Add(opStack.Pop());

            }

            tokens = postfixTokens.ToArray();
        }

        /// <summary>
        /// Builds ExpressionTree with tokens
        /// </summary>
        private void BuildTree()
        {
            ToPostFix();
            VariableReference.Instance.ClearDictionary();
            Stack<Node> nodeStack = new Stack<Node>();
            OperatorFactory opFac = new OperatorFactory();


            foreach (string s in tokens)
            {
                if (Regex.IsMatch(s, @"^[0-9]*\.?[0-9]"))
                {
                    nodeStack.Push(new ConstantNode(float.Parse(s)));
                }
                else if (Regex.IsMatch(s, @"\w+"))
                {
                    nodeStack.Push(new VariableNode(s));
                    VariableReference.Instance.VariableDictionary.Add(s, 0);
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
