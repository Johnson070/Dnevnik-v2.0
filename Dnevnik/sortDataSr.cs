using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    public partial class SortDataSr : Form
    {
        public int numBalls;
        public int[] indMark;
        public float[] aveBall;

        public SortDataSr()
        {
            InitializeComponent();
        }

        private void GenButton_Click(object sender, EventArgs e)
        {
            numBalls = Convert.ToInt32(numericUpDown1.Value);

            indMark = new int[] { Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value)};
            aveBall = new float[] { Convert.ToSingle(numericUpDown5.Value), Convert.ToSingle(numericUpDown4.Value) };

            this.Close();
        }
    }
}
