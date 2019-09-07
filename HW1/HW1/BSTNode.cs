using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    internal class BSTNode
    {
        internal int data;                  //Data held in BSTNode
        internal BSTNode left;              //Left child of BSTNode
        internal BSTNode right;             //Right child of BSTNode


        /// <summary>
        /// Default constructor
        /// </summary>
        public BSTNode()
        {
            data = -1;
            left = null;
            right = null;
        }

        /// <summary>
        /// Constructor that takes in a single int, data 
        /// </summary>
        /// <param name="data"></param>
        public BSTNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

    }
}
