﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    class marksTableClass : MarksTable
    {
        // DataGridView marks { get; set; }
        //public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        public List<List<int[]>> mark { get; set; } = new List<List<int[]>>();
        
        public override void drawGrid(int columns, List<string> _name)
        {
            ColumnClass column = new ColumnClass();

            marks.Columns.Add(column.lesson);

            for (int i = 0; i < columns; i++)
            {
                ColumnClass columnFor = new ColumnClass();

                marks.Columns.Add(columnFor.ball[0]);
                marks.Columns.Add(columnFor.weight[1]);
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

                marks.Columns.Add(columnFor.ball[0]);
                marks.Columns.Add(columnFor.weight[1]);
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

        public override void resultBall(List<List<int[]>> _mark)
        {
            for (int i = 0; i < _mark.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;

                foreach (int[] oneMark in _mark[i])
                {
                    resultBall += oneMark[0] * oneMark[1];

                    resultWeight += oneMark[1];
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
                mark.Add(new List<int[]>());

                for (int j = 1; j < marks.Columns.Count - 1; j = j + 2)
                {
                    if (marks[j, i].Value != null && marks[j + 1, i].Value != null) mark[i].Add(new int[] { Convert.ToInt32(marks[j, i].Value), Convert.ToInt32(marks[j + 1, i].Value) });
                }
            }
        }

        public override void checkCell()
        {
            for (int i = 0; i < marks.Rows.Count; i++)
            {
                for (int j = 1; j < marks.Columns.Count - 1; j += 2)
                {
                    try
                    {
                        int ball = Convert.ToInt32(marks[j, i].Value);

                        if (!(ball >= 1 && ball <= 10))
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
                        marks[j + 1, i].ErrorText = "Введите значение!";
                    }
                    else if (marks[j, i].Value == null && marks[j + 1, i].Value != null)
                    {
                        marks[j, i].ErrorText = "Введите значение!";
                    }
                    else
                    {
                        marks[j, i].ErrorText = "";
                        marks[j+1, i].ErrorText = "";
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

        internal override void listMarksRecurse(List<List<int[]>> _marks, List<int[]> itogMarks, int[] len, int[] _mark = null, int listNum = 0)
        {
            for (int i = 0; i < _marks[listNum].Count; i++)
            {
                if (listNum == _marks.Count - 1)
                {
                    if (_mark != null) itogMarks.Add(_mark.Concat(_marks[listNum][i]).ToArray());
                    else itogMarks.Add(_marks[listNum][i]);
                }
                else
                {
                    if (_mark != null) _mark = _mark.Concat(_marks[listNum][i]).ToArray();
                    else _mark = _marks[listNum][i];
                    listMarksRecurse(_marks, itogMarks, len, _mark, listNum + 1);
                    Array.Resize(ref _mark, _mark.Length - len[listNum]);
                }
            }
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
            for (int i = startPos; i < _numBalls.Length; i++)
            {
                if (_numBalls[i] != 0) return i;
            }

            return 1;
        }

        internal override void sortCriteriaRecurse(int[] _numBalls, sortMarkStruct sort, List<float> _averBall)
        {
            for (int i = 0; i < sort.marks.Count; i++)
            {
                int[] posWeight = new int[10];

                _numBalls.CopyTo(posWeight, 0);

                int pos = getPosState(_numBalls);

                for (int j = 0; j < sort.marks[i].Length; j++)
                {
                    if (!(sort.criteria[pos][0] <= sort.marks[i][j] && sort.criteria[pos][1] >= sort.marks[i][j]) || !(sort.averBall[0] <= _averBall[i] && sort.averBall[1] >= _averBall[i]))
                    {
                        sort.marks.RemoveAt(i);
                        _averBall.RemoveAt(i);
                        sortCriteriaRecurse(_numBalls, sort, _averBall);
                        return;
                    }

                    posWeight[pos] -= 1;
                    pos = (posWeight[pos] != 0 ? pos : getPosState(posWeight, pos));
                }
            }
        }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        public override int getCountBalls(int[] _numBalls, bool mode = true)
        {
            int count = 0;

            int[] numBalls = new int[10];
            _numBalls.CopyTo(numBalls, 0);

            if (mode)
            {
                for (int i = 0; i < _numBalls.Length; i++)
                {
                    count += (_numBalls[i] > 0 ? 1 : 0);
                }
            }
            else
            {
                for (int i = 0; i < numBalls.Length; i++)
                {
                    count += (numBalls[i] > 0 ? 1 : 0);
                    numBalls[i] -= 1;

                    i -= (numBalls[i] > 0 ? 1 : 0);
                }
            }

            return count;
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

        public override long countMarksRow(int k, int[] numBalls)
        {
            long count = (factFunc(4 + k - 1)) / (factFunc(k) * factFunc(4 - 1));
            return count * Convert.ToInt64(getCountBalls(numBalls));
        }

        internal override List<float> sortMarks(sortMarkStruct sort, int[] _numBalls, List<int[]> _marksWeights)
        {
            List<float> averBall = new List<float>();

            int preBall = 0, preWeight = 0;

            if (_marksWeights != null)
            {
                for (int i = 0; i < _marksWeights.Count; i++)
                {
                    preBall += _marksWeights[i][0] * _marksWeights[i][1];
                    preWeight += _marksWeights[i][1];
                }
            }

            for (int i = 0; i < sort.marks.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;
                int[] posWeight = new int[10];

                _numBalls.CopyTo(posWeight, 0);

                int pos = getPosState(_numBalls);

                foreach (int oneMark in sort.marks[i])
                {
                    resultBall += oneMark * (pos + 1);

                    resultWeight += (pos + 1);

                    posWeight[pos] -= 1;
                    pos = (posWeight[pos] != 0 ? pos : getPosState(posWeight, pos));
                }

                averBall.Add((float)Math.Round((Convert.ToSingle(resultBall + preBall) / Convert.ToSingle(resultWeight + preWeight)), 2));

            }

            sortCriteriaRecurse(_numBalls, sort, averBall);

            return averBall;
        }

        public override marksDataClass genMarks(int[] numBalls, List<int[]> _criteria, float[] _averBall, List<int[]> _marksWeights)
        {
            List<List<int[]>> ghostMarks = new List<List<int[]>>();
            List<int[]> itogMarks = new List<int[]>();

            for (int i = 0; i < 10; i++)
            {
                if (numBalls[i] != 0)
                {
                    ghostMarks.Add(new List<int[]>());
                    genMarksRecurse(numBalls[i], ghostMarks[ghostMarks.Count-1]);
                }
            }

            List<int> delPart = new List<int>();
            
            foreach (int weightsCount in numBalls)
            {
                if (weightsCount != 0) delPart.Add(weightsCount);
            }

            if (ghostMarks.Count != 1) listMarksRecurse(ghostMarks, itogMarks, delPart.ToArray());
            else itogMarks = ghostMarks[0];

            //columnGenBallWeight(20);

            //for (int i = 0; i < itogMarks.Count; i++)
            //{
            //    for (int j = 0; j < itogMarks[i].Length; j++)
            //        marks[j + 1, i].Value = itogMarks[i][j].ToString();

            //    marks.Rows.Add();
            //}
            //MessageBox.Show(itogMarks.Count.ToString());

            sortMarkStruct sort = new sortMarkStruct();

            sort.criteria = _criteria;
            sort.marks = itogMarks;
            sort.averBall = _averBall;

            List<float> averBall = sortMarks(sort, numBalls, _marksWeights);

            marksDataClass data = new marksDataClass();

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
                        var index = marks.CurrentCell.ColumnIndex;

                        if (marks.CurrentCell.ColumnIndex % 2 == 0)
                        {
                            marks.Columns.RemoveAt(index);
                            marks.Columns.RemoveAt(index-1);
                        }
                        else
                        {
                            marks.Columns.RemoveAt(index);
                            marks.Columns.RemoveAt(index);
                        }
                    }
                    break;
            }
        }
    
        public override void colorTableMarks()
        {
            for (int i = 0; i < marks.RowCount; i++)
                for (int j = 1; j < marks.ColumnCount-1; j+=2)
                {
                    //if (marks[j, i].Value != null)
                    //{
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
                                marks[j, i].Style.BackColor = Color.FromArgb(179, 179, 179);
                                break;
                        }
                    //}
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
                sortData frm = new sortData();
                marksDataClass data;
                List<int[]> marksWeights = (mark.Count != 0 ? mark[marks.CurrentCell.RowIndex] : null);

                frm.Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString();
                frm.ShowDialog();

                if (frm.averBall != null && getCountBalls(frm.countMarks,false) != 0)
                {
                    long countMarks = countMarksRow(getCountBalls(frm.countMarks, false), frm.countMarks);
                    DialogResult result = DialogResult.OK;

                    if (countMarks > 1000)
                        result = MessageBox.Show("Сгенерировать " + countMarks + " оценок? \r\rВы уверены?", "Большое количество вариантов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.OK || DialogResult.Yes == result)
                    {
                        data = genMarks(frm.countMarks, frm.indMarks, frm.averBall, marksWeights);

                        try
                        {
                            data.oldBall = Convert.ToSingle(marks[marks.Columns.Count - 1, marks.CurrentCell.RowIndex].Value);
                        }
                        catch
                        {
                            data.oldBall = 0.00f;
                        }

                        marksSelect selectForm = new marksSelect(data);

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

                            if (((marks.ColumnCount - 2)/2 - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count <= 0))
                            {
                                countCol = Math.Abs((marks.ColumnCount - 2) / 2 - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count);

                                columnGenBallWeight(countCol);
                            }

                            int index = mark[marks.CurrentCell.RowIndex].Count * 2 + 1, indexMark = 0;

                            for (int i = 0; i < selectForm.selectedRow.Count*2; i++)
                            {
                                if (i % 2 == 0)
                                    marks[index + i, marks.CurrentCell.RowIndex].Value = selectForm.selectedRow[indexMark][0];
                                else
                                {
                                    marks[index + i, marks.CurrentCell.RowIndex].Value = selectForm.selectedRow[indexMark][1];
                                    indexMark++;
                                }
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
    
        public void cellClearNotValid()
        {
            for (int i = 0; i < marks.Rows.Count; i++)
            {
                for (int j = 1; j < marks.Columns.Count - 1; j += 2)
                {
                    try
                    {
                        int ball = Convert.ToInt32(marks[j, i].Value);

                        if (!(ball >= 1 && ball <= 10))
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
                        marks[j , i].Value = null;
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