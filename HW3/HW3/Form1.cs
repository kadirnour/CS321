using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the text in textBox to the contents of sr
        /// </summary>
        /// <param name="sr">TextReader</param>
        private void LoadText(TextReader sr)
        {
            textBox.Clear();
            textBox.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// Opens an Open Text Dialog to load a text file
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Button Click</param>
        private void LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            StreamReader sr;
            string path = null;

            if (open.ShowDialog() == DialogResult.OK)
            {
                path = open.FileName;
                if (path != null)
                {
                    sr = new StreamReader(path);
                    LoadText(sr);
                }
            }
        }

        /// <summary>
        /// Opens a Save Text Dialog to save the text in textBox to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text File|*.txt";
            save.Title = "Save Text File";


            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FileName != null)
                {
                    FileStream fs = (FileStream)save.OpenFile();

                    byte[] text = new UTF8Encoding(true).GetBytes(textBox.Text);
                    fs.Write(text, 0, text.Length);

                    fs.Close();
                }

            }
        }

        /// <summary>
        /// Loads 50 Fibinacci numbers to textbox
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Button Click</param>
        private void First50_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fib = new FibonacciTextReader(50);
            LoadText(fib);
        }

        /// <summary>
        /// Loads 100 Fibinacci numbers to textbox
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Button Click</param>
        private void First100_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fib = new FibonacciTextReader(100);
            LoadText(fib);
        }
    }
}

