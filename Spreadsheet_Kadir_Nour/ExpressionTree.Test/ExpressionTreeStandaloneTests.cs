// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CptS321;
using System.Reflection;
using System.Text;

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
            Assert.AreEqual(et.tokens, null);
            VariableReference.Instance.ClearDictionary();

            //Simple variable node test case
            et = new ExpressionTree("A*B*C");
            Assert.AreEqual(et.tokens, new string[] { "A", "B", "C", "*", "*" });
            VariableReference.Instance.ClearDictionary();

            //Simple constant node test case
            et = new ExpressionTree("1 + 2");
            Assert.AreEqual(et.tokens, new string[] { "1", "2", "+" });
            VariableReference.Instance.ClearDictionary();

            //Simple variable and constant node test case with minus
            et = new ExpressionTree("A - 2");
            Assert.AreEqual(et.tokens, new string[] { "A", "2", "-" });
            VariableReference.Instance.ClearDictionary();

            //Complex variable and constant node test case with random whitespace
            et = new ExpressionTree(" A  /2 / B/ C /3 / 5/D  ");
            Assert.AreEqual(et.tokens, new string[] { "A", "2", "B", "C", "3", "5", "D", "/", "/", "/", "/", "/", "/" });
            VariableReference.Instance.ClearDictionary();

        }

        [Test]
        public void SetVariableTest()
        {
            ExpressionTree et = new ExpressionTree("2 * x * 3");
            et.SetVariable("x", "2");
            Assert.AreEqual(2, VariableReference.Instance.VariableDictionary["x"]);
            VariableReference.Instance.ClearDictionary();

            et = new ExpressionTree("x * y * 4");
            et.SetVariable("x", "2");
            et.SetVariable("y", "5");
            Assert.AreEqual(2, VariableReference.Instance.VariableDictionary["x"]);
            Assert.AreEqual(5, VariableReference.Instance.VariableDictionary["y"]);
            VariableReference.Instance.ClearDictionary();

            et = new ExpressionTree("");
            et.SetVariable("x", "2");
            //Im not sure how to test this but I know SetVariable will throw an exception
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

            et = new ExpressionTree("1-2-3");
            Assert.AreEqual(.5, et.Evaluate());
        }

    }
}
