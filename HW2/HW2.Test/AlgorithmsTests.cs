// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace HW2.Test
{
    [TestFixture]
    public class AlgorithmsTests
    {
        private Algorithms TestObj = new Algorithms();

        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("Method name cannot be null or whitespace");

            var method = this.TestObj.GetType()
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0}	method	not	found", methodName));

            return method;
        }

        [Test]
        public void UsingHashSetTest()
        {
            MethodInfo methodInfo = this.GetMethod("UsingHashSet");

            this.TestObj.List = new List<int> { 1, 2, 3, 4, 3, 1, 2 };

            int count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(4, count);

            this.TestObj.List = new List<int> { 500, 3, 6, 430, 10000, 3, 430 };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(5, count);

            this.TestObj.List = new List<int> { };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Usingconstantspacetest()
        {
            MethodInfo methodInfo = this.GetMethod("UsingHashSet");

            this.TestObj.List = new List<int> { 1, 2, 3, 4, 3, 1, 2 };

            int count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(4, count);

            this.TestObj.List = new List<int> { 500, 3, 6, 430, 10000, 3, 430 };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(5, count);

            this.TestObj.List = new List<int> { };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Usingsortingtest()
        {
            MethodInfo methodInfo = this.GetMethod("UsingHashSet");

            this.TestObj.List = new List<int> { 1, 2, 3, 4, 3, 1, 2 };

            int count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(4, count);

            this.TestObj.List = new List<int> { 500, 3, 6, 430, 10000, 3, 430 };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(5, count);

            this.TestObj.List = new List<int> { };

            count = (int) methodInfo.Invoke(this.TestObj, null);
            Assert.AreEqual(0, count);
        }
    }
}
