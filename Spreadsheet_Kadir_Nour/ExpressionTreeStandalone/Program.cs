using System;

namespace CptS321
{
    /// <summary>
    /// Driver for ExpressionTreeStandalone
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ExpressionTree tree = new ExpressionTree("");

            Menu(ref tree);

        }
        /// <summary>
        /// Displays console menu
        /// </summary>
        /// <param name="tree"></param>
        public static void Menu(ref ExpressionTree tree)
        {
            string option;
            do
            {
                Console.WriteLine("Current expression: " + tree.Expression);
                Console.WriteLine("1. Enter New Expression");
                Console.WriteLine("2. Set Variable");
                Console.WriteLine("3. Evaluate Expression");
                Console.WriteLine("4. Quit");

                option = Console.ReadLine();
                Console.Clear();
            } while (Convert.ToInt32(option) < 1 || Convert.ToInt32(option) > 4);

            switch (Convert.ToInt32(option))
            {
                case 1:
                    NewExpression(ref tree);
                    break;
                case 2:
                    SetVariable(ref tree);
                    break;
                case 3:
                    Evaluate(ref tree);
                    break;
                case 4:
                    Quit();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set new Expression for ExpressionTree
        /// </summary>
        /// <param name="tree"></param>
        static void NewExpression(ref ExpressionTree tree)
        {
            string newExp = null;

            Console.WriteLine("Current Expression: " + tree.Expression);
            Console.Write("Enter New Expression: ");
            newExp = Console.ReadLine();

            tree = new ExpressionTree(newExp);
            Menu(ref tree);
        }

        /// <summary>
        /// Set value to variable node
        /// </summary>
        /// <param name="tree"></param>
        static void SetVariable(ref ExpressionTree tree)
        {
            string newVar = null;
            string newVarVal = null;

            Console.WriteLine("Current Expression: " + tree.Expression);
            Console.Write("Enter Variable Name: ");
            newVar = Console.ReadLine();

            Console.Write("Enter Variable Value: ");
            newVarVal = (Console.ReadLine());

            try
            {
                tree.SetVariable(newVar, newVarVal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Menu(ref tree);
        }

        /// <summary>
        /// Evaluates current ExpressionTree
        /// </summary>
        /// <param name="tree"></param>
        static void Evaluate(ref ExpressionTree tree)
        {
            try
            {
                Console.WriteLine("Evaluated Expression: " + tree.Evaluate());
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Cannot Divide By Zero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Menu(ref tree);
        }

        /// <summary>
        /// Exits program
        /// </summary>
        /// <returns></returns>
        static int Quit()
        {
            return 0;
        }

    }
}
