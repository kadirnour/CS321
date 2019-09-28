using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HW3
{
    /// <summary>
    /// Creates a fibonacci sequence
    /// Inherits from TextReader
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private int maxLines = -1; //maximum number of Fibonacci numbers
        private int count = 0;
        private BigInteger f1 = 0, f2 = 1; //first and second Fibonacci number
        private BigInteger result = 0;

        /// <summary>
        /// Sets maximum Fibonacci numbers
        /// </summary>
        /// <param name="max">Max Fibonacci numbers</param>
        public FibonacciTextReader(int max)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overrides TextReader ReadLine to return a number in the Fibonacci sequence as a string
        /// </summary>
        /// <returns>Fibonacci number as string</returns>
        public override string ReadLine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overrides Textreader ReadToEnd a Fibonacci sequence of maxLines length
        /// </summary>
        /// <returns>Fibonacci sequence with a length of maxLines</returns>
        public override string ReadToEnd()
        {
            throw new NotImplementedException();
        }
    }
}

