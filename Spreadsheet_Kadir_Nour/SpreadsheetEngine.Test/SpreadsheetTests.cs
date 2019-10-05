
using System.Collections;
using System.Collections.Generic;
using CptS321;
using NUnit.Framework;

namespace SpreadsheetEngine.Test
{
    [TestFixture]
    public class SpreadsheetTests
    {

        [Test]
        public void OnPropertyChangedTest()
        {
            Cell TestCell = new ConcreteCell(0, 0);
            string ReturnedName = null;

            TestCell.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                ReturnedName = e.PropertyName;
            };

            TestCell.Text = "Test Text";
            Assert.AreEqual("Text", ReturnedName);
        }
    }

}
