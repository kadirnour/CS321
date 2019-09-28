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
            maxLines = max;
        }

        /// <summary>
        /// Overrides TextReader ReadLine to return a number in the Fibonacci sequence as a string
        /// </summary>
        /// <returns>Fibonacci number as string</returns>
        public override string ReadLine()
        {
            if (count == maxLines)
                return null;
            if (count == 0)
            {
                count++;
                return 0.ToString();
            }
            if (count == 1)
            {
                count++;
                return 1.ToString();
            }

            result = f1 + f2;
            f1 = f2;
            f2 = result;

            count++;

            return result.ToString();
        }

        /// <summary>
        /// Overrides Textreader ReadToEnd a Fibonacci sequence of maxLines length
        /// </summary>
        /// <returns>Fibonacci sequence with a length of maxLines</returns>
        public override string ReadToEnd()
        {
            string fib = ReadLine();
            StringBuilder sb = new StringBuilder();
            int fibCount = 1;
            while (fib != null)
            {
                sb.Append(fibCount.ToString() + ": " + fib + Environment.NewLine);
                fibCount++;
                fib = ReadLine();
            }

            return sb.ToString();
        }
    }
    
}

