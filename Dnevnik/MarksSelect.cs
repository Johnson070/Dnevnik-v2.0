using Dnevnik.DnevnikClasses;
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
    public partial class MarksSelect : Form
    {
        List<int[]> marks;
        List<float> averBall;
        float oldBall;
        int[] countBalls;
        int countBallsSr;
        public List<int[]> selectedRow;

        bool type = false;

        public MarksSelect(MarksDataAverageMass _data, MarksDataAverage _dataSr = null)
        {
            InitializeComponent();

            if (_dataSr == null)
            {
                marks = _data.marks;
                averBall = _data.averBall;
                countBalls = _data.countBalls;
                oldBall = _data.oldBall;
            }
            else
            {
                marks = _dataSr.marks;
                averBall = _dataSr.averBall;
                countBallsSr = _dataSr.countBalls;
                oldBall = _dataSr.oldBall;
                type = _dataSr.type;
            }
        }

        private void columnsGen(int colNewBalls)
        {
            selectMarksTable.Rows.Clear();
            selectMarksTable.Columns.Clear();

            selectMarksTable.AllowUserToAddRows = false;

            for (int i = 0; i < colNewBalls; i++)
            {
                ColumnClass columnFor = new ColumnClass();

                columnFor.ball[1].DefaultCellStyle.BackColor = (i % 2 == 0 && type == true ? Color.FromArgb(0, 159, 7) : Color.LimeGreen);

                if (!type)
                {
                    selectMarksTable.Columns.Add(columnFor.ball[1]);
                    selectMarksTable.Columns.Add(columnFor.weight[0]);
                }
                else selectMarksTable.Columns.Add(columnFor.ball[1]);
            }

            ColumnClass column = new ColumnClass();

            selectMarksTable.Columns.Add(column.ballSr[1]);
            selectMarksTable.Columns.Add(column.ballSr[2]);
            selectMarksTable.Columns.Add(column.ballSr[3]);
        }

        private int getPosState(int[] _numBalls, int startPos = 0)
        {
            for (int i = startPos; i < _numBalls.Length; i++)
            {
                if (_numBalls[i] != 0) return i;
            }

            return 1;
        }

        private Color getColorBall(float ball, bool type = true)
        {
            if (type)
            {
                if (ball < Properties.Settings.Default.averBall1) return Color.OrangeRed;
                else if (ball >= Properties.Settings.Default.averBall1 && ball < Properties.Settings.Default.averBall2) return Color.Yellow;
                else return Color.LightGreen;
            }
            else
            {
                if (ball < 0) return Color.OrangeRed;
                else if (ball == 0) return Color.Yellow;
                else return Color.LightGreen;
            }
        }

        private void marksSelect_Shown(object sender, EventArgs e)
        {
            columnsGen(marks[0].Length);

            for (int i = 0; i < marks.Count; i++)
            {
                int[] posWeight = new int[10];

                int pos = 0;

                if (!type)
                {
                    countBalls.CopyTo(posWeight, 0);

                    pos = getPosState(countBalls);
                }

                selectMarksTable.Rows.Add();

                int indexMark = 0;

                selectMarksTable[selectMarksTable.ColumnCount - 1, selectMarksTable.RowCount - 1].Value = Math.Round(averBall[i] - oldBall, 2);
                selectMarksTable[selectMarksTable.ColumnCount - 1, selectMarksTable.RowCount - 1].Style.BackColor = getColorBall(averBall[i] - oldBall, false);

                selectMarksTable[selectMarksTable.ColumnCount - 2, selectMarksTable.RowCount - 1].Value = oldBall;

                selectMarksTable[selectMarksTable.ColumnCount - 3, selectMarksTable.RowCount - 1].Value = averBall[i];
                selectMarksTable[selectMarksTable.ColumnCount - 3, selectMarksTable.RowCount - 1].Style.BackColor = getColorBall(averBall[i]);

                if (!type)
                {
                    for (int j = 0; j < marks[i].Length * 2; j++)
                    {
                        selectMarksTable[j, selectMarksTable.RowCount - 1].Value = (j % 2 == 0 ? marks[i][indexMark] : pos + 1);


                        indexMark += (j % 2 == 0 ? 1 : 0);

                        if (j % 2 != 0)
                        {
                            posWeight[pos] -= 1;
                            pos = (posWeight[pos] != 0 ? pos : getPosState(posWeight, pos));
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < marks[i].Length; j++)
                    {
                        selectMarksTable[j, selectMarksTable.RowCount - 1].Value = marks[i][indexMark];
                        indexMark++;
                    }
                }
            }
        }

        private void upSort_Click(object sender, EventArgs e)
        {
            selectMarksTable.Sort(selectMarksTable.Columns[selectMarksTable.ColumnCount - 3], ListSortDirection.Ascending);
        }

        private void downSort_Click(object sender, EventArgs e)
        {
            selectMarksTable.Sort(selectMarksTable.Columns[selectMarksTable.ColumnCount - 3], ListSortDirection.Descending);
        }

        private void selectMarksButton_Click(object sender, EventArgs e)
        {
            selectedRow = new List<int[]>();

            if (!type)
            {
                for (int i = 0; i < selectMarksTable.ColumnCount - 3; i += 2)
                {
                    selectedRow.Add(new int[] { Convert.ToInt16(selectMarksTable[i, selectMarksTable.CurrentCell.RowIndex].Value), Convert.ToInt16(selectMarksTable[i + 1, selectMarksTable.CurrentCell.RowIndex].Value) });
                }
            }
            else
            {
                for (int i = 0; i < selectMarksTable.ColumnCount - 3; i++)
                {
                    selectedRow.Add(new int[] { Convert.ToInt16(selectMarksTable[i, selectMarksTable.CurrentCell.RowIndex].Value) });
                }
            }


            this.Close();
        }
    }
}
