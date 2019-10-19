// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CptS321;
using System.Reflection;
using System.Text;
using System;

namespace ExpressionTreeStandalone.Test
{
    [TestFixture]
    public class ExpressionTreeStandaloneTests
    {
        /// <summary>
        /// Test case that asserts ExpressionTree.tokens is the correct tokenization of Expression
        /// </summary>
        [Test]
        public void PostfixExpressionTest()
        {
            //Empty Expression test case
            ExpressionTree et = new ExpressionTree("");
            Assert.AreEqual(et.tokens == null ? "" : String.Join("", et.tokens), "");

            //Simple variable node test case
            et = new ExpressionTree("A*B*C");
            Assert.AreEqual(String.Join("", et.tokens), "AB*C*");

            //Simple constant node test case
            et = new ExpressionTree("1 + 2");
            Assert.AreEqual(String.Join("", et.tokens), "12+");

            //Simple variable and constant node test case with minus
            et = new ExpressionTree("A - 2");
            Assert.AreEqual(String.Join("", et.tokens), "A2-");

            //Complex variable and constant node test case with random whitespace
            et = new ExpressionTree(" A  /2 / B/ C /3 / 5/D  ");
            Assert.AreEqual(String.Join("", et.tokens), "A2/B/C/3/5/D/");

            //Mixed operator tests below
            et = new ExpressionTree("(2*3)^1/2");
            Assert.AreEqual(String.Join("", et.tokens), "23*1^2/");

            et = new ExpressionTree("A2 + B3 - F6 * 2");
            Assert.AreEqual(String.Join("", et.tokens), "A2B3+F62*-");

            et = new ExpressionTree("A2 + B3 - F6 * 2");
            Assert.AreEqual(String.Join("", et.tokens), "A2B3+F62*-");

            et = new ExpressionTree("2^(4+1) * A6");
            Assert.AreEqual(String.Join("", et.tokens), "241+^A6*");


        }

        [Test]
        public void SetVariableTest()
        {
            ExpressionTree et = new ExpressionTree("2 * x * 3");
            et.SetVariable("x", "2");
            Assert.AreEqual(2, VariableReference.Instance.VariableDictionary["x"]);

            et = new ExpressionTree("x * y * 4");
            et.SetVariable("x", "2");
            et.SetVariable("y", "5");
            Assert.AreEqual(2, VariableReference.Instance.VariableDictionary["x"]);
            Assert.AreEqual(5, VariableReference.Instance.VariableDictionary["y"]);

            //Null expression throws an exception with the message 'No Expression'
            et = new ExpressionTree("");
            try
            {
                et.SetVariable("x", "2");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "No Expression");
            }
        }

        [Test]
        public void Evaluate()
        {
            ExpressionTree et = new ExpressionTree("2 * x * 3");
            et.SetVariable("x", "2");
            Assert.AreEqual(12, et.Evaluate());
            VariableReference.Instance.ClearDictionary();

            et = new ExpressionTree("2 + x + 3");
            et.SetVariable("x", "2");
            Assert.AreEqual(7, et.Evaluate());
            VariableReference.Instance.ClearDictionary();

            et = new ExpressionTree("1/2/1");
            Assert.AreEqual(.5, et.Evaluate());

            et = new ExpressionTree("(2*3)^1/2");
            Assert.AreEqual(3, et.Evaluate());

            et = new ExpressionTree("3*(2+4)/2");
            Assert.AreEqual(9, et.Evaluate());

            et = new ExpressionTree("1.5 *4");
            Assert.AreEqual(6, et.Evaluate());

            et = new ExpressionTree("1-2-3");
            Assert.AreEqual(-4, et.Evaluate());
        }
    }
}
