// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW3.Test
{
    /// <summary>
    /// Test class for all methods in FibonacciTextReader
    /// </summary>
    [TestFixture]
    public class FibonacciTextReaderTests
    {
        /// <summary>
        /// Test method for FibonacciTextReader.ReadLine()
        /// </summary>
        [Test]
        public void ReadLineTest()
        {
            FibonacciTextReader fib = new FibonacciTextReader(50);
            string str = null;
            for (int i = 0; i < 50; i++)
            {
                str = fib.ReadLine();
            }

            Assert.AreEqual("7778742049", str);

        }
        /// <summary>
        /// Test method for FibonacciTextReader.ReadToEnd()
        /// </summary>
        [Test]
        public void ReadToEndTest()
        {
            FibonacciTextReader fib = new FibonacciTextReader(3);
            string str = fib.ReadToEnd();

            Assert.AreEqual("1: 0\r\n2: 1\r\n3: 1\r\n", str);
        }
    }
}
