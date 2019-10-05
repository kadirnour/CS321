using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet_Kadir_Nour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int AsciiValue = 65;
            int RowCount = 1;
            while (AsciiValue != 91)
            {
                string AsciiToString = char.ConvertFromUtf32(AsciiValue++);
                myGrid.Columns.Add(AsciiToString, AsciiToString);
            }
            while (RowCount != 51)
            {
                string RowToString = RowCount.ToString();
                myGrid.Rows.Add();
                myGrid.Rows[RowCount - 1].HeaderCell.Value = RowToString;
                RowCount++;
            }
        }
    }
}
