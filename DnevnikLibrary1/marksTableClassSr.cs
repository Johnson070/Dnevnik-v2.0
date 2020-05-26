using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    class marksTableClassSr : MarksTable
    {
        //public DataGridView marks { get; set; }
        //public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        public List<List<int>> mark { get; set; } = new List<List<int>>();

        public override void drawGrid(int columns, List<string> _name)
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

        public override void columnGenBallWeight(int col = 1)
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

        public override void upDownRow(bool direct) //direct == false down
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

        public override void resultBall(List<List<int>> _mark)
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

        public override void inputMark()
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

        public override void checkCell()
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

        internal override int[] str2intArr(string marksStr = "")
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

        internal override void listMarksRecurse(List<List<int[]>> _marks, List<int[]> itogMarks, int len, int[] _mark = null, int listNum = 0)
        {

        }

        internal override void genMarksRecurse(int lenght, List<int[]> _test, int start = 2, string marks = "")
        {
            for (int i = start; i <= 5; i++)
            {
                if (marks.Length == lenght)
                {
                    _test.Add(str2intArr(marks));
                    break;
                }
                else genMarksRecurse(lenght, _test, i, marks + i.ToString());
            }
        }

        internal override int getPosState(int[] _numBalls, int startPos = 0)
        {
            return 0;
        }

        internal override void sortCriteriaRecurse( sortMarkStructSr sort, List<float> _averBall)
        {
            for (int i = 0; i < sort.marks.Count; i++)
            {
                for (int j = 0; j < sort.marks[i].Length; j++)
                {
                    if (!(sort.criteria[0] <= sort.marks[i][j] && sort.criteria[1] >= sort.marks[i][j]) || !(sort.averBall[0] <= _averBall[i] && sort.averBall[1] >= _averBall[i]))
                    {
                        sort.marks.RemoveAt(i);
                        _averBall.RemoveAt(i);
                        sortCriteriaRecurse(sort, _averBall);
                        return;
                    }
                }
            }
        }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        public override int getCountBalls(int _numBalls, bool mode = true)
        {
            return 0;
        }

        internal override long factFunc(long inFact)
        {

            if (inFact <= 1)
            {
                return 1;
            }
            else
            {
                long c = inFact * factFunc(inFact - 1);
                return c;
            }
            
        }

        public override long countMarksRow(int k)
        {
            long count = (factFunc(4 + k - 1)) / (factFunc(k) * factFunc(4 - 1));
            return count;
        }

        internal override List<float> sortMarks(sortMarkStructSr sort, int _numBalls, List<int> _marksWeights)
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

            sortCriteriaRecurse(sort, averBall);

            return averBall;
        }

        public override marksDataClassSr genMarks(int numBalls, int[] _criteria, float[] _averBall, List<int> _marksWeights)
        {
            List<int[]> itogMarks = new List<int[]>();

            genMarksRecurse(numBalls, itogMarks);

            List<int> delPart = new List<int>();

            delPart.Add(numBalls);

            sortMarkStructSr sort = new sortMarkStructSr();

            sort.criteria = _criteria;
            sort.marks = itogMarks;
            sort.averBall = _averBall;

            List<float> averBall = sortMarks(sort, numBalls, _marksWeights);

            marksDataClassSr data = new marksDataClassSr();

            data.averBall = averBall;
            data.countBalls = numBalls;
            data.marks = itogMarks;

            return data;
        }   

        public override void editTable(int type) //1-addRow 2-deleteRow 3-addColumn 4-deleteColumn
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
                    columnGenBallWeight();
                    break;
                case 4:
                    if (marks.CurrentCell.ColumnIndex > 0 && marks.CurrentCell.ColumnIndex < marks.Columns.Count - 1)
                    {
                        marks.Columns.RemoveAt(marks.CurrentCell.ColumnIndex);
                    }
                    break;
            }
        }
    
        public override void colorTableMarks()
        {
            for (int i = 0; i < marks.RowCount; i++)
                for (int j = 1; j < marks.ColumnCount-1; j++)
                {
                    switch (Convert.ToInt32(marks[j, i].Value))
                    {
                        case 2:
                            marks[j, i].Style.BackColor = Color.OrangeRed;
                            break;
                        case 3:
                            marks[j, i].Style.BackColor = Color.Yellow;
                            break;
                        case int n when (n >= 4 && n <= 5):
                            marks[j, i].Style.BackColor = Color.LightGreen;
                            break;
                        default:
                            marks[j, i].Style.BackColor = (j % 2 == 0 ? Color.FromArgb(179, 179, 179) : Color.FromArgb(221, 221, 221));
                            break;
                    }
                    
                }

            for (int i = 0; i < marks.RowCount; i++)
            {
                try
                {
                    switch (Convert.ToSingle(marks[marks.ColumnCount - 1, i].Value))
                    {
                        case float n when (n < Properties.Settings.Default.averBall1):
                            marks[marks.ColumnCount - 1, i].Style.BackColor = Color.OrangeRed;
                            break;
                        case float n when (n >= Properties.Settings.Default.averBall1 && n < Properties.Settings.Default.averBall2):
                            marks[marks.ColumnCount - 1, i].Style.BackColor = Color.Yellow;
                            break;
                        case float n when (n >= Properties.Settings.Default.averBall2):
                            marks[marks.ColumnCount - 1, i].Style.BackColor = Color.LightGreen;
                            break;
                        default:
                            marks[marks.ColumnCount - 1, i].Style.BackColor = Color.White;
                            break;
                    }
                }
                catch
                {
                    marks[marks.ColumnCount - 1, i].Style.BackColor = Color.White;
                }
            }
        }

        public override void genMarksForm()
        {
            if (marks.CurrentCell != null)
            {
                sortDataSr frm = new sortDataSr();
                marksDataClassSr data;
                List<int> marksWeights = (mark.Count != 0 ? mark[marks.CurrentCell.RowIndex] : null);

                frm.Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString();
                frm.ShowDialog();

                if (frm.aveBall != null)
                {
                    long countMarks = countMarksRow(frm.numBalls);
                    DialogResult result = DialogResult.OK;

                    if (countMarks > 1000)
                        result = MessageBox.Show("Сгенерировать " + countMarks + " оценок? \r\rВы уверены?", "Большое количество вариантов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.OK || DialogResult.Yes == result)
                    {
                        data = genMarks(frm.numBalls, frm.indMark, frm.aveBall, marksWeights);

                        try
                        {
                            data.oldBall = Convert.ToSingle(marks[marks.Columns.Count - 1, marks.CurrentCell.RowIndex].Value);
                        }
                        catch
                        {
                            data.oldBall = 0.00f;
                        }

                        data.type = true;

                        marksSelect selectForm = new marksSelect(null, data);

                        selectForm.Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString();

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

                                columnGenBallWeight(countCol);
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

        public override void cellFormating()
        {
            inputMark();
            resultBall(mark);
            checkCell();
            colorTableMarks();
        }

        public override void cellClearNotValid()
        {
            for (int i = 0; i < marks.Rows.Count; i++)
            {
                for (int j = 1; j < marks.Columns.Count - 1; j += 2)
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

                    if (marks[j, i].Value != null && marks[j + 1, i].Value == null)
                    {
                        marks[j, i].Value = null;
                    }
                    else if (marks[j, i].Value == null && marks[j + 1, i].Value != null)
                    {
                        marks[j + 1, i].Value = null;
                    }
                }
            }
        }
    }
}
