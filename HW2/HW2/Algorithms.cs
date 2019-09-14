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
        /// Runs UsingHashSet, UsingConstantSpace and UsingSorting and saves results to a list
        /// </summary>
        /// <returns>Results of UsingHashSet, UsingConstantSpace and UsingSorting in a List</returns>
        public List<int> Run()
        {
            return new List<int>
            {
                UsingHashSet(),
                UsingConstantSpace(),
                UsingSorting()
            };
        }

        /// <summary>
        /// Finds distinct number of integers in list using a HashSet
        /// </summary>
        private int UsingHashSet()
        {
            HashSet<int> ht = new HashSet<int>(List);
            return ht.Count;

        }

        /// <summary>
        /// Finds distinct number of integers in list using constant space
        /// </summary>
        private int UsingConstantSpace()
        {
            int count = 0;

            for (int i = 0; i < List.Count; i++)
            {
                bool seen = false;
                for (int j = i + 1; j < List.Count; j++)
                {
                    if (List[i] == List[j] && !seen)
                    {
                        seen = true;
                        count++;
                    }
                }
            }

            return List.Count - count;
        }

        /// <summary>
        /// Finds distinct number of integers in list by sorting and counting
        /// </summary>
        private int UsingSorting()
        {
            int count = List.Count;
            int prev = -1;

            List.Sort();
            foreach (int x in List)
            {
                if (x == prev)
                    count--;
                prev = x;
            }

            return count;
        }
    }
}
