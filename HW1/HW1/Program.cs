using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input from console and split on 'space' delimeter and save to arr.
            string rawInput;
            string[] arrInput;
            Console.WriteLine("Enter a collection of numbers in the range [0,100], seperated by spaces:");
            rawInput = Console.ReadLine();
            arrInput = rawInput.Split(' ');

            //Create a BST with arrInput's value. Print out content of tree and statistics.
            BST tree = new BST(arrInput);
            Console.WriteLine(tree.InOrderTraversal());
            tree.Statistics();
        }
    }
}
