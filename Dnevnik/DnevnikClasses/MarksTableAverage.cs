using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    class MarksTableAverage : MarksTable
    {
        //public DataGridView marks { get; set; }
        //public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        public List<List<int>> mark { get; set; } = new List<List<int>>();

        public override void DrawGrid(int columns, List<string> _name)
        {
            ColumnClass column = new ColumnClass();

            marks.Columns.Add(column.lesson);

            for (int i = 0; i < columns; i++)
            {
                ColumnClass columnFor = new ColumnClass();

                columnFor.ball[0].DefaultCellStyle.BackColor = (marks.ColumnCount % 2 == 0 ? Color.FromArgb(179, 179, 179) : Color.FromArgb(221, 221, 221));

                marks.Columns.Add(columnFor.ball[0]);
            }

            marks.AllowUserToAddRows = false;

            /*=====================================*/

            marks.Columns.Add(column.ballSr[0]);

            /*=====================================*/

            for (int i = 0; i < _name.Count; ++i)
            {
                //Добавляем строку, указывая значения каждой ячейки по имени (можно использовать индекс 0, 1, 2 вместо имен)
                marks.Rows.Add();
                marks["name", marks.Rows.Count - 1].Value = _name[i];
            }
        }

        public override void ColumnGenBallWeight(int col = 1)
        {
            marks.AllowUserToAddRows = false;

            marks.Columns.RemoveAt(marks.Columns.Count - 1);

            for (int i = 0; i < col; i++)
            {
                ColumnClass columnFor = new ColumnClass();

                columnFor.ball[0].DefaultCellStyle.BackColor = (marks.ColumnCount % 2 == 0 ? Color.FromArgb(179, 179, 179) : Color.FromArgb(221, 221, 221));

                marks.Columns.Add(columnFor.ball[0]);
            }

            ColumnClass column = new ColumnClass();

            marks.Columns.Add(column.ballSr[0]);
        }

        internal override DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        public override void UpDownRow(bool direct) //direct == false down
        {
            if ((marks.CurrentCell.RowIndex != 0 && !direct) || (marks.CurrentCell.RowIndex != marks.Rows.Count && direct))
            {
                int inc = direct == false ? -1 : 1;

                int index = marks.CurrentCell.RowIndex;

                DataGridViewRow rowDown = CloneWithValues(marks.Rows[index + inc]);
                DataGridViewRow rowUp = CloneWithValues(marks.Rows[index]);

                marks.Rows.RemoveAt(index);
                marks.Rows.InsertRange(index, rowDown);

                marks.Rows.RemoveAt(index + inc);
                marks.Rows.InsertRange(index + inc, rowUp);

                marks.CurrentCell = marks[marks.CurrentCell.ColumnIndex, index + inc];
            }
        }

        public override void ResultBall(List<List<int>> _mark)
        {
            for (int i = 0; i < _mark.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;

                foreach (int oneMark in _mark[i])
                {
                    resultBall += oneMark;

                    resultWeight += 1;
                }

                float result = Convert.ToSingle(resultBall) / Convert.ToSingle(resultWeight);

                marks[marks.Columns.Count - 1, i].Value = (float.IsNaN(result) == false ? result.ToString("0.00") : "");
            }
        }

        public override void InputMark()
        {
            mark.Clear();

            for (int i = 0; i < marks.Rows.Count; i++)
            {
                mark.Add(new List<int>());

                for (int j = 1; j < marks.Columns.Count - 1; j++)
                {
                    if (marks[j, i].Value != null) mark[i].Add(Convert.ToInt32(marks[j, i].Value));
                }
            }
        }

        public override void CheckCell()
        {
            for (int i = 0; i < marks.Rows.Count; i++)
            {
                for (int j = 1; j < marks.Columns.Count - 1; j++)
                {
                    try
                    {
                        int ball = Convert.ToInt32(marks[j, i].Value);

                        if (!(ball >= 2 && ball <= 5))
                        {
                            marks[j, i].Value = null;
                        }
                    }
                    catch
                    {
                        marks[j, i].Value = null;
                    }
                }
            }
        }

        internal override int[] Str2intArr(string marksStr = "")
        {
            int[] poslBall;

            List<int> temp = new List<int>();

            for (int h = 0; h < marksStr.Length; h++)
            {
                temp.Add(Convert.ToInt16(marksStr[h].ToString()));
            }

            poslBall = temp.ToArray();


            return poslBall;
        }

        internal override void ListMarksRecurse(List<List<int[]>> _marks, List<int[]> itogMarks, int len, int[] _mark = null, int listNum = 0)
        {

        }

        internal override void GenMarksRecurse(int lenght, List<int[]> _test, int start = 2, string marks = "")
        {
            for (int i = start; i <= 5; i++)
            {
                if (marks.Length == lenght)
                {
                    _test.Add(Str2intArr(marks));
                    break;
                }
                else GenMarksRecurse(lenght, _test, i, marks + i.ToString());
            }
        }

        internal override int GetPosState(int[] _numBalls, int startPos = 0)
        {
            return 0;
        }

        internal override void SortCriteriaRecurse( SortMarkStructAverage sort, List<float> _averBall)
        {
            for (int i = 0; i < sort.marks.Count; i++)
            {
                for (int j = 0; j < sort.marks[i].Length; j++)
                {
                    if (!(sort.criteria[0] <= sort.marks[i][j] && sort.criteria[1] >= sort.marks[i][j]) || !(sort.averBall[0] <= _averBall[i] && sort.averBall[1] >= _averBall[i]))
                    {
                        sort.marks.RemoveAt(i);
                        _averBall.RemoveAt(i);
                        SortCriteriaRecurse(sort, _averBall);
                        return;
                    }
                }
            }
        }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        public override int GetCountBalls(int _numBalls, bool mode = true)
        {
            return 0;
        }

        internal override long FactFunc(long inFact)
        {

            if (inFact <= 1)
            {
                return 1;
            }
            else
            {
                long c = inFact * FactFunc(inFact - 1);
                return c;
            }
            
        }

        public override long CountMarksRow(int k)
        {
            long count = (FactFunc(4 + k - 1)) / (FactFunc(k) * FactFunc(4 - 1));
            return count;
        }

        internal override List<float> SortMarks(SortMarkStructAverage sort, int _numBalls, List<int> _marksWeights)
        {
            List<float> averBall = new List<float>();

            int preBall = 0, preWeight = 0;

            if (_marksWeights != null)
            {
                for (int i = 0; i < _marksWeights.Count; i++)
                {
                    preBall += _marksWeights[i];
                    preWeight += 1;
                }
            }

            for (int i = 0; i < sort.marks.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;

                foreach (int oneMark in sort.marks[i])
                {
                    resultBall += oneMark;

                    resultWeight += 1;
                }

                averBall.Add((float)Math.Round((Convert.ToSingle(resultBall + preBall) / Convert.ToSingle(resultWeight + preWeight)), 2));

            }

            SortCriteriaRecurse(sort, averBall);

            return averBall;
        }

        public override MarksDataAverage GenMarks(int numBalls, int[] _criteria, float[] _averBall, List<int> _marksWeights)
        {
            List<int[]> itogMarks = new List<int[]>();

            GenMarksRecurse(numBalls, itogMarks);

            SortMarkStructAverage sort = new SortMarkStructAverage
            {
                criteria = _criteria,
                marks = itogMarks,
                averBall = _averBall
            };

            List<float> averBall = SortMarks(sort, numBalls, _marksWeights);

            MarksDataAverage data = new MarksDataAverage
            {
                averBall = averBall,
                countBalls = numBalls,
                marks = itogMarks
            };

            return data;
        }   

        public override void EditTable(int type) //1-addRow 2-deleteRow 3-addColumn 4-deleteColumn
        {
            switch (type)
            {
                case 1:
                    marks.Rows.AddCopies(marks.CurrentCell.RowIndex, 1);
                    break;
                case 2:
                    marks.Rows.RemoveAt(marks.CurrentCell.RowIndex);
                    break;
                case 3:
                    ColumnGenBallWeight();
                    break;
                case 4:
                    if (marks.CurrentCell.ColumnIndex > 0 && marks.CurrentCell.ColumnIndex < marks.Columns.Count - 1)
                    {
                        marks.Columns.RemoveAt(marks.CurrentCell.ColumnIndex);
                    }
                    break;
            }
        }
    
        public override void ColorTableMarks()
        {
            for (int i = 0; i < marks.RowCount; i++)
                for (int j = 1; j < marks.ColumnCount-1; j++)
                {
                    marks[j, i].Style.BackColor = (Convert.ToInt32(marks[j, i].Value)) switch
                    {
                        2 => Color.OrangeRed,
                        3 => Color.Yellow,
                        int n when (n >= 4 && n <= 5) => Color.LightGreen,
                        _ => (j % 2 == 0 ? Color.FromArgb(179, 179, 179) : Color.FromArgb(221, 221, 221)),
                    };
                }

            for (int i = 0; i < marks.RowCount; i++)
            {
                try
                {
                    marks[marks.ColumnCount - 1, i].Style.BackColor = (Convert.ToSingle(marks[marks.ColumnCount - 1, i].Value)) switch
                    {
                        float n when (n < Properties.Settings.Default.averBall1) => Color.OrangeRed,
                        float n when (n >= Properties.Settings.Default.averBall1 && n < Properties.Settings.Default.averBall2) => Color.Yellow,
                        float n when (n >= Properties.Settings.Default.averBall2) => Color.LightGreen,
                        _ => Color.White,
                    };
                }
                catch
                {
                    marks[marks.ColumnCount - 1, i].Style.BackColor = Color.White;
                }
            }
        }

        public override void GenMarksForm()
        {
            if (marks.CurrentCell != null)
            {
                SortDataSr frm = new SortDataSr();
                MarksDataAverage data;
                List<int> marksWeights = (mark.Count != 0 ? mark[marks.CurrentCell.RowIndex] : null);

                frm.Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString();
                frm.ShowDialog();

                if (frm.aveBall != null)
                {
                    long countMarks = CountMarksRow(frm.numBalls);
                    DialogResult result = DialogResult.OK;

                    if (countMarks > 1000)
                        result = MessageBox.Show("Сгенерировать " + countMarks + " оценок? \r\rВы уверены?", "Большое количество вариантов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.OK || DialogResult.Yes == result)
                    {
                        data = GenMarks(frm.numBalls, frm.indMark, frm.aveBall, marksWeights);

                        try
                        {
                            data.oldBall = Convert.ToSingle(marks[marks.Columns.Count - 1, marks.CurrentCell.RowIndex].Value);
                        }
                        catch
                        {
                            data.oldBall = 0.00f;
                        }

                        data.type = true;

                        using MarksSelect selectForm = new MarksSelect(null, data)
                        {
                            Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString()
                        };

                        try
                        {
                            selectForm.ShowDialog();
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое кол-во оценок.\rПопробуйте изменить критерии поиска или изменить кол-во оценок.");
                        }

                        if (selectForm.selectedRow != null)
                        {
                            int countCol;

                            if (((marks.ColumnCount - 2) - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count <= 0))
                            {
                                countCol = Math.Abs((marks.ColumnCount - 2) - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count);

                                ColumnGenBallWeight(countCol);
                            }

                            int index = mark[marks.CurrentCell.RowIndex].Count + 1;

                            for (int i = 0; i < selectForm.selectedRow.Count; i++)
                            {
                                marks[index + i, marks.CurrentCell.RowIndex].Value = selectForm.selectedRow[i][0];
                            }
                        }
                    }
                }
            }
        }

        public override void CellFormating()
        {
            InputMark();
            ResultBall(mark);
            CheckCell();
            ColorTableMarks();
        }
    }
}
