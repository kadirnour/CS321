
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CptS321;

namespace SpreadsheetEngine.Test
{
    /// <summary>
    /// Test class for the methods of ConcreteCell
    /// </summary>
    [TestFixture]
    public class ConcreteCellTests
    {
        /// <summary>
        /// Test method for ConcreteCell.OnPropertyChanged
        /// </summary>
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
