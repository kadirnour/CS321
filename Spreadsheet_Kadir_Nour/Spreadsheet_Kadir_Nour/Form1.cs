using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;

namespace Spreadsheet_Kadir_Nour
{
    public partial class Form1 : Form
    {

        public Spreadsheet spreadsheet;


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

            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.CellPropertyChanged += OnCellChanged;

        }

        /// <summary>
        /// Sets value of UI grid cell to the value of the backend Cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCellChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the UI grid cell's value to the backend cell's text
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">CellEndEdit</param>
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
