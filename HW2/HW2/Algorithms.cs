using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    /// <summary>
    /// Defines the algorithms UsingHashSet, UsingConstantSpace and UsingSorting
    /// </summary>
    public class Algorithms
    {
        public List<int> List { get; set; }

        /// <summary>
        /// Creates a list of 10,000 integers
        /// </summary>
        public Algorithms()
        {
            List = new List<int>(10000);
            Random rand = new Random();

            for (int i = 0; i < List.Capacity; i++)
                List.Add(rand.Next(20000));
        }

        /// <summary>
        /// Sets list to internal list
        /// </summary>
        /// <param name="list"> list of integers</param>
        public Algorithms(List<int> list)
        {
            this.List = list;
        }

        /// <summary>
        /// Runs UsingHashSet, UsingConstantSpace and UsingSorting
        /// </summary>
        public void Run()
        {
            UsingHashSet();
            UsingConstantSpace();
            UsingSorting();
        }

        /// <summary>
        /// Finds distinct number of integers in list using a HashSet
        /// </summary>
        private int UsingHashSet()
        {
            return -1;
        }

        /// <summary>
        /// Finds distinct number of integers in list using constant space
        /// </summary>
        private int UsingConstantSpace()
        {
            return -1;
        }

        /// <summary>
        /// Finds distinct number of integers in list by sorting and 
        /// </summary>
        private int UsingSorting()
        {
            return -1;
        }
    }
}
