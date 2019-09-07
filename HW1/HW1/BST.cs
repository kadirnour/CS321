using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class BST
    {
        private BSTNode root;                   //beginning of BST
        private int count;                      //number of nodes in BST
        private int levels;                     //number of levels in BST

        /// <summary>
        /// Property to get Count
        /// </summary>
        public int Count { get { return count; } }
        /// <summary>
        /// Property to get Levels
        /// </summary>
        public int Levels { get { return levels; } }
        /// <summary>
        /// Creates and returns a new BSTNode with the value of data 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>new BSTNode with data</returns>
        private BSTNode CreateNode(int data)
        {
            return new BSTNode(data);
        }
        /// <summary>
        /// Private helper insert method for inserting a node into a BST with the data passed in starting from root
        /// </summary>
        /// <param name="data"></param>
        /// <param name="node"></param>
        private void Insert(int data, ref BSTNode node)
        {
            if (node == null) { node = CreateNode(data); count++; }
            else if (data > node.data) Insert(data, ref node.right);
            else if (data < node.data) Insert(data, ref node.left);
        }
        /// <summary>
        /// Private helper InOrderTraversal method prints the data from every node in the BST in order from smallest to largest
        /// </summary>
        /// <param name="root"></param>
        private void InOrderTraversal(BSTNode root, StringBuilder ret)
        {
            if (root != null)
            {
                InOrderTraversal(root.left, ret);
                ret.Append(root.data + " ");
                InOrderTraversal(root.right, ret);
            }
        }
        /// <summary>
        /// Returns max level of the BST
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Max level</returns>
        private int GetMaxLevel(BSTNode root)
        {
            if (root != null)
            {
                int left = GetMaxLevel(root.left);
                int right = GetMaxLevel(root.right);

                if (right > left) return right + 1;
                else return left + 1;
            }
            return 0;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public BST()
        {
            root = null;
            count = 0;
            levels = 0;
        }
        /// <summary>
        /// Constructor that takes in an input array to build the BST
        /// </summary>
        /// <param name="consoleInput"></param>
        public BST(string[] consoleInput)
        {
            foreach (string i in consoleInput)
            {
                Insert(int.Parse(i));
            }
        }
        /// <summary>
        /// Public insert method for inserting a node into a BST with the data passed in
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            Insert(data, ref root);
        }
        /// <summary>
        /// Public InOrderTraversal method prints the data from every node in the BST in order from smallest to largest
        /// </summary>
        public String InOrderTraversal()
        {
            StringBuilder ret = new StringBuilder(); //plan on appending to string
            InOrderTraversal(root, ret);

            return ret.ToString();
        }
        public int GetMaxLevel()
        {
            return GetMaxLevel(root);
        }
        /// <summary>
        /// Prints Number of nodes, current level and theoretical level based on count for BST
        /// </summary>
        public void Statistics()
        {
            levels = GetMaxLevel(root);
            Console.WriteLine("\nTree Statistics:");
            Console.WriteLine("     Number of Nodes: {0}", count);
            Console.WriteLine("     Number of Levels: {0}", levels);
            //Formula for minimum number of levels in a tree
            Console.WriteLine("     Minimum level of a tree with {0} nodes cound have = {1}", count, Math.Ceiling(Math.Log(count + 1, 2)));
            Console.WriteLine("Done");
        }
    }
}
