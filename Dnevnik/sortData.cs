using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Dnevnik
{
    public partial class SortData : Form
    {
        public float[] averBall;
        public List<int[]> indMarks;
        public int[] countMarks;

        public SortData()
        {
            InitializeComponent();

            averageBallTool.DropDownItems[0].Text = "2,0";
            averageBallTool.DropDownItems[1].Text = "5,0";
        }

        private void SortData_Shown(object sender, EventArgs e)
        {

            int rowIndex = 0;
            for (int i = 1; i < 11; i++)
            {
                if (Properties.Settings.Default["nameLess" + i].ToString().Length != 0)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, rowIndex].Value = i;
                    dataGridView1[1, rowIndex].Value = Properties.Settings.Default["nameLess" + i];
                    dataGridView1[2, rowIndex].Value = (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).Items[0];

                    dataGridView2.Rows.Add();
                    dataGridView2[0, rowIndex].Value = i;
                    dataGridView2[1, rowIndex].Value = Properties.Settings.Default["nameLess" + i];
                    dataGridView2[2, rowIndex].Value = (dataGridView2.Columns[2] as DataGridViewComboBoxColumn).Items[0];
                    dataGridView2[3, rowIndex].Value = (dataGridView2.Columns[2] as DataGridViewComboBoxColumn).Items[3];

                    rowIndex++;
                }

            }
        }

        private void ResetSort_Click(object sender, EventArgs e)
        {
            int countRows = dataGridView1.Rows.Count;

            for (int i = 0; i < countRows; i++)
            {
                dataGridView1.Rows.RemoveAt(0);
                dataGridView2.Rows.RemoveAt(0);
            }

            SortData_Shown(null, null);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            Validate();
            dataGridView1.Update();
            dataGridView1.EndEdit();

            dataGridView2.Update();
            dataGridView2.EndEdit();

            averBall = new float[] { Convert.ToSingle(averageBallTool.DropDownItems[0].Text), Convert.ToSingle(averageBallTool.DropDownItems[1].Text) };
            indMarks = new List<int[]>();
            countMarks = new int[10];

            int rowIndex = 0;
            for (int i = 1; i < 11; i++)
            {
                if (Properties.Settings.Default["nameLess" + i].ToString().Length != 0)
                {
                    indMarks.Add(new int[] { Convert.ToInt16(dataGridView2.Rows[rowIndex].Cells[2].Value), Convert.ToInt16(dataGridView2[3, rowIndex].Value) });
                    countMarks[i-1] = Convert.ToInt16(dataGridView1[2, rowIndex].Value);
                    rowIndex++;
                }
                else
                {
                    indMarks.Add(new int[] { 2, 5 });
                    countMarks[i-1] = 0;
                }
            }

            this.Close();
        }
    }
}
