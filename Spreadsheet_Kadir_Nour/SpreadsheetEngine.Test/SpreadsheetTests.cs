
using System.Collections;
using System.Collections.Generic;
using CptS321;
using NUnit.Framework;

namespace SpreadsheetEngine.Test
{
    /// <summary>
    /// Test class for the methods of Spreadsheet class
    /// </summary>
    [TestFixture]
    public class SpreadsheetTests
    {
        /// <summary>
        /// Test for overloaded GetCell method. Test by row and column
        /// </summary>
        [Test]
        public void GetCellByRowAndColTest()
        {
            int TestRow = 24, TestCol = 18;
            Cell TestCell = new ConcreteCell(0, 0);
            Spreadsheet TestSheet = new Spreadsheet(50, 26);

            TestCell = TestSheet.GetCell(TestRow, TestCol);

            Assert.AreEqual(24, TestCell.RowIndex);
            Assert.AreEqual(18, TestCell.ColumnIndex);
        }

        /// <summary>
        /// Test for overloaded GetCell method. Test by name
        /// </summary>
        [Test]
        public void GetCellByNameTest()
        {
            Cell TestCell = new ConcreteCell(0, 0);
            Spreadsheet TestSheet = new Spreadsheet(50, 26);

            TestCell = TestSheet.GetCell("E40");

            Assert.AreEqual(39, TestCell.RowIndex);
            //"E" corresponds to 4 since it is the 5th column
            Assert.AreEqual(4, TestCell.ColumnIndex);
        }

        /// <summary>
        /// Test for OnPropertyChanged method
        /// </summary>
        [Test]
        public void OnPropertyChangedTest()
        {
            Spreadsheet TestSpreadsheet = new Spreadsheet(1, 2);
            Cell TestCell1 = new ConcreteCell(0, 0);
            Cell TestCell2 = new ConcreteCell(0, 0);

            TestCell1 = TestSpreadsheet.GetCell(0, 0);
            TestCell1.Text = "12";

            TestCell2 = TestSpreadsheet.GetCell(0, 1);
            TestCell2.Text = "18";
            Assert.AreEqual("12", TestCell1.Value);

            //In the case the value was set to an expression
            TestCell1.Text = "=B1";
            Assert.AreEqual("18", TestCell1.Value);
        }
    }
}
