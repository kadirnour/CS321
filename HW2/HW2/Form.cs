using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Appends resluts of UsingHashSet, UsingConstantSpace and UsingSorting to Statistics TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(Object sender, EventArgs e)
        {
            Algorithms obj = new Algorithms();
            List<int> outList = obj.Run();

            Statistics.AppendText(Environment.NewLine + "1. Duplicates removed using HashSet: " + outList[0].ToString());
            Statistics.AppendText(Environment.NewLine + "   This method uses a Hashset to remove duplicates. " + Environment.NewLine
                + "   This is possible because it is based on a mathematical set and by definition a set cannot contain duplicates. " + Environment.NewLine
                + "   A HashSet determines on insertion if the object's HashCode is the same as an already existing entry. "
             );

            Statistics.AppendText(Environment.NewLine + "2. Duplicates removed O(1) Space complexity: " + outList[1]);

            Statistics.AppendText(Environment.NewLine + "3. Duplicates removed after sorting: " + outList[2]);

        }
    }
}
