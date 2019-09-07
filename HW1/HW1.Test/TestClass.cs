// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW1.Test
{
    [TestFixture]
    public class BSTTest
    {
        [Test]
        public void InsertBSTNodeTest()
        {
            BST tree = new BST();

            tree.Insert(10);

            Assert.That(1, Is.EqualTo(tree.Count));
        }

        [Test]
        public void InOrderTraversalTest()
        {
            BST tree = new BST();

            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(4);

            Assert.That("1 3 4 5 ", Is.EqualTo(tree.InOrderTraversal()));
        }

        [Test]
        public void GetMaxLevelTest()
        {
            BST tree = new BST();

            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(4);

            Assert.That(3, Is.EqualTo(tree.GetMaxLevel()));
        }
    }
}
