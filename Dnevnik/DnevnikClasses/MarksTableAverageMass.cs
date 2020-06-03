using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dnevnik.DnevnikClasses;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс для работы с таблицей среднего взвешенного балла
    /// </summary>
    class MarksTableAverageMass : MarksTable
    {
        // DataGridView marks { get; set; }
        //public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };

        /// <summary>
        /// Оценки
        /// </summary>
        public List<List<int[]>> mark { get; set; } = new List<List<int[]>>();
        
        /// <summary>
        /// Создать в таблице начальные столбцы и строки
        /// </summary>
        /// <param name="columns">Кол-во столбцов</param>
        /// <param name="name">Список названий предметов</param>
        public override void DrawGrid(int columns, List<string> name)
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

            for (int i = 0; i < name.Count; ++i)
            {
                //Добавляем строку, указывая значения каждой ячейки по имени (можно использовать индекс 0, 1, 2 вместо имен)
                marks.Rows.Add();
                marks["name", marks.Rows.Count - 1].Value = name[i];
            }
        }

        /// <summary>
        /// Создать в таблице определённое кол-во столбцов
        /// </summary>
        /// <param name="col">Кол-во столбцов</param>
        public override void ColumnGenBallWeight(int col = 1)
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

        /// <summary>
        /// Копировать строку из таблицы
        /// </summary>
        /// <param name="row">строка</param>
        /// <returns></returns>
        internal override DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        /// <summary>
        /// Опускает или поднимает строку
        /// </summary>
        /// <param name="direct">
        /// <list type="bullet">
        /// <listheader>Направление строки:</listheader>
        /// <item>false - вниз</item>
        /// <item>true - вверх</item>
        /// </list>
        /// </param>
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

        /// <summary>
        /// Посчитать итоговый балл
        /// </summary>
        /// <param name="mark">Список оценок</param>
        public override void ResultBall(List<List<int[]>> mark)
        {
            for (int i = 0; i < mark.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;

                foreach (int[] oneMark in mark[i])
                {
                    resultBall += oneMark[0] * oneMark[1];

                    resultWeight += oneMark[1];
                }

                float result = Convert.ToSingle(resultBall) / Convert.ToSingle(resultWeight);

                marks[marks.Columns.Count - 1, i].Value = (float.IsNaN(result) == false ? result.ToString("0.00") : "");
            }
        }

        /// <summary>
        /// Внести оценки из таблицы в список
        /// </summary>
        public override void InputMark()
        {
            mark.Clear();

            for (int i = 0; i < marks.Rows.Count; i++)
            {
                mark.Add(new List<int[]>());

                for (int j = 1; j < marks.Columns.Count - 1; j += 2)
                {
                    if (marks[j, i].Value != null && marks[j + 1, i].Value != null) mark[i].Add(new int[] { Convert.ToInt32(marks[j, i].Value), Convert.ToInt32(marks[j + 1, i].Value) });
                }
            }
        }

        /// <summary>
        /// Проверка таблицы на ошибки
        /// </summary>
        public override void CheckCell()
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

        /// <summary>
        /// Перевод набора чисел в одномерный числовой массив
        /// </summary>
        /// <param name="marksStr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Собирает все возможные варианты перестановок оценок
        /// </summary>
        /// <param name="marks">Список оценок</param>
        /// <param name="itogMarks">Готовый список оценок</param>
        /// <param name="len">Длина последовательности</param>
        /// <param name="mark">Генерируемая последовательность</param>
        /// <param name="listNum">Длинна массива</param>
        internal override void ListMarksRecurse(List<List<int[]>> marks, List<int[]> itogMarks, int[] len, int[] mark = null, int listNum = 0)
        {
            for (int i = 0; i < marks[listNum].Count; i++)
            {
                if (listNum == marks.Count - 1)
                {
                    if (mark != null) itogMarks.Add(mark.Concat(marks[listNum][i]).ToArray());
                    else itogMarks.Add(marks[listNum][i]);
                }
                else
                {
                    if (mark != null) mark = mark.Concat(marks[listNum][i]).ToArray();
                    else mark = marks[listNum][i];
                    ListMarksRecurse(marks, itogMarks, len, mark, listNum + 1);
                    Array.Resize(ref mark, mark.Length - len[listNum]);
                }
            }
        }

        /// <summary>
        /// Генерация последовательности оценок без повторений
        /// </summary>
        /// <param name="lenght">Кол-во оценок</param>
        /// <param name="marksList">Список оценок</param>
        /// <param name="start">Стартовый индекс</param>
        /// <param name="marks">Генерируемая последовательность оценок</param>
        internal override void GenMarksRecurse(int lenght, List<int[]> marksList, int start = 2, string marks = "")
        {
            for (int i = start; i <= 5; i++)
            {
                if (marks.Length == lenght)
                {
                    marksList.Add(Str2intArr(marks));
                    break;
                }
                else GenMarksRecurse(lenght, marksList, i, marks + i.ToString());
            }
        }

        /// <summary>
        /// Получает индекс в массиве, который не равен 0
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="startPos">Начальная позиция поиска в массиве</param>
        /// <returns></returns>
        internal override int GetPosState(int[] numBalls, int startPos = 0)
        {
            for (int i = startPos; i < numBalls.Length; i++)
            {
                if (numBalls[i] != 0) return i;
            }

            return 1;
        }

        /// <summary>
        /// Сортировка списка сгенерированных оценок
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="sort">Структура в который находятся критерии для сортировки</param>
        /// <param name="averBall">Список со средними баллами</param>
        internal override void SortCriteriaRecurse(int[] numBalls, SortMarkStructAverageMass sort, List<float> averBall)
        {
            for (int i = 0; i < sort.marks.Count; i++)
            {
                int[] posWeight = new int[10];

                numBalls.CopyTo(posWeight, 0);

                int pos = GetPosState(numBalls);

                for (int j = 0; j < sort.marks[i].Length; j++)
                {
                    if (!(sort.criteria[pos][0] <= sort.marks[i][j] && sort.criteria[pos][1] >= sort.marks[i][j]) || !(sort.averBall[0] <= averBall[i] && sort.averBall[1] >= averBall[i]))
                    {
                        sort.marks.RemoveAt(i);
                        averBall.RemoveAt(i);
                        SortCriteriaRecurse(numBalls, sort, averBall);
                        return;
                    }

                    posWeight[pos] -= 1;
                    pos = (posWeight[pos] != 0 ? pos : GetPosState(posWeight, pos));
                }
            }
        }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        /// <summary>
        /// Считает сколько нужно сгенерировать оценок
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="mode">
        /// <list type="bullet">
        /// <listheader>Тип работы:</listheader>
        /// <item>true - считает сколько типов работ</item>
        /// <item>false - выдает кол-во оценок</item>
        /// </list>
        /// </param>
        /// <returns></returns>
        public override int GetCountBalls(int[] numBalls, bool mode = true)
        {
            int count = 0;

            int[] numBallsCopy = new int[10];
            numBalls.CopyTo(numBallsCopy, 0);

            if (mode)
            {
                for (int i = 0; i < numBallsCopy.Length; i++)
                {
                    count += (numBallsCopy[i] > 0 ? 1 : 0);
                }
            }
            else
            {
                for (int i = 0; i < numBallsCopy.Length; i++)
                {
                    count += (numBallsCopy[i] > 0 ? 1 : 0);
                    numBallsCopy[i] -= 1;

                    i -= (numBallsCopy[i] > 0 ? 1 : 0);
                }
            }

            return count;
        }

        /// <summary>
        /// Возведение в факториал
        /// </summary>
        /// <param name="inFact">Рекурсия</param>
        /// <returns></returns>
        internal override decimal FactFunc(decimal inFact)
        {
            if (inFact <= 1)
            {
                return 1;
            }
            else
            {
                decimal c = inFact * FactFunc(inFact - 1);
                return c;
            }
            
        }

        /// <summary>
        /// Считает кол-во генерируемых вариантов оценок
        /// </summary>
        /// <param name="countMarks">Кол-во оценок</param>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <returns></returns>
        public override decimal CountMarksRow(int countMarks, int[] numBalls)
        {
            decimal count = (FactFunc(4 + countMarks - 1)) / (FactFunc(countMarks) * FactFunc(4 - 1));
            return count * Convert.ToDecimal(GetCountBalls(numBalls));
        }

        /// <summary>
        /// Расчет среднего взвешенного балла и сортировка по критериям
        /// </summary>
        /// <param name="sort">Критерии сортировки</param>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        internal override List<float> SortMarks(SortMarkStructAverageMass sort, int[] numBalls, List<int[]> marksWeights)
        {
            List<float> averBall = new List<float>();

            int preBall = 0, preWeight = 0;

            if (marksWeights != null)
            {
                for (int i = 0; i < marksWeights.Count; i++)
                {
                    preBall += marksWeights[i][0] * marksWeights[i][1];
                    preWeight += marksWeights[i][1];
                }
            }

            for (int i = 0; i < sort.marks.Count; i++)
            {
                int resultBall = 0, resultWeight = 0;
                int[] posWeight = new int[10];

                numBalls.CopyTo(posWeight, 0);

                int pos = GetPosState(numBalls);

                foreach (int oneMark in sort.marks[i])
                {
                    resultBall += oneMark * (pos + 1);

                    resultWeight += (pos + 1);

                    posWeight[pos] -= 1;
                    pos = (posWeight[pos] != 0 ? pos : GetPosState(posWeight, pos));
                }

                averBall.Add((float)Math.Round((Convert.ToSingle(resultBall + preBall) / Convert.ToSingle(resultWeight + preWeight)), 2));

            }

            SortCriteriaRecurse(numBalls, sort, averBall);

            return averBall;
        }

        /// <summary>
        /// Генерирует последовательность оценок
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="criteria">Последовательность с параметрами индивидуальной сложности оценок</param>
        /// <param name="_averBall">Последовательность с параметрами сортировки по среднему баллу</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        public override MarksDataAverageMass GenMarks(int[] numBalls, List<int[]> criteria, float[] _averBall, List<int[]> marksWeights)
        {
            List<List<int[]>> ghostMarks = new List<List<int[]>>();
            List<int[]> itogMarks = new List<int[]>();

            for (int i = 0; i < 10; i++)
            {
                if (numBalls[i] != 0)
                {
                    ghostMarks.Add(new List<int[]>());
                    GenMarksRecurse(numBalls[i], ghostMarks[ghostMarks.Count-1]);
                }
            }

            List<int> delPart = new List<int>();
            
            foreach (int weightsCount in numBalls)
            {
                if (weightsCount != 0) delPart.Add(weightsCount);
            }

            if (ghostMarks.Count != 1) ListMarksRecurse(ghostMarks, itogMarks, delPart.ToArray());
            else itogMarks = ghostMarks[0];

            SortMarkStructAverageMass sort = new SortMarkStructAverageMass
            {
                criteria = criteria,
                marks = itogMarks,
                averBall = _averBall
            };

            List<float> averBall = SortMarks(sort, numBalls, marksWeights);

            MarksDataAverageMass data = new MarksDataAverageMass
            {
                averBall = averBall,
                countBalls = numBalls,
                marks = itogMarks
            };

            return data;
        }

        /// <summary>
        /// Разные действия с таблицей
        /// </summary>
        /// <param name="type">
        /// <list type="bullet">
        /// <listheader>Действие</listheader>
        /// <item>1-добавить строку</item>
        /// <item>2-удалить строку</item>
        /// <item>3-добавить столбец</item>
        /// <item>4-удалить столбец</item>
        /// </list>
        /// </param>
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

        /// <summary>
        /// Цветное выделение оценок
        /// </summary>
        public override void ColorTableMarks()
        {
            for (int i = 0; i < marks.RowCount; i++)
                for (int j = 1; j < marks.ColumnCount-1; j+=2)
                {
                    //if (marks[j, i].Value != null)
                    //{
                    marks[j, i].Style.BackColor = (Convert.ToInt32(marks[j, i].Value)) switch
                    {
                        2 => Color.OrangeRed,
                        3 => Color.Yellow,
                        int n when (n >= 4 && n <= 5) => Color.LightGreen,
                        _ => Color.FromArgb(179, 179, 179),
                    };
                    //}
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

        /// <summary>
        /// Вызов окна для выбора критериев с последующей генерацией оценок, выбора, и вставки в таблицу
        /// </summary>
        public override void GenMarksForm()
        {
            if (marks.CurrentCell != null)
            {
                using SortData frm = new SortData();
                MarksDataAverageMass data;
                List<int[]> marksWeights = (mark.Count != 0 ? mark[marks.CurrentCell.RowIndex] : null);

                frm.Text = marks[0, marks.CurrentCell.RowIndex].Value.ToString();
                frm.ShowDialog();

                if (frm.averBall != null && GetCountBalls(frm.countMarks,false) != 0)
                {
                    decimal countMarks = CountMarksRow(GetCountBalls(frm.countMarks, false), frm.countMarks);
                    DialogResult result = DialogResult.OK;

                    if (countMarks > 1000)
                        result = MessageBox.Show("Сгенерировать " + countMarks + " оценок? \r\rВы уверены?", "Большое количество вариантов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.OK || DialogResult.Yes == result)
                    {
                        data = GenMarks(frm.countMarks, frm.individualMarks, frm.averBall, marksWeights);

                        try
                        {
                            data.oldBall = Convert.ToSingle(marks[marks.Columns.Count - 1, marks.CurrentCell.RowIndex].Value);
                        }
                        catch
                        {
                            data.oldBall = 0.00f;
                        }

                        using MarksSelect selectForm = new MarksSelect(data)
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

                            if (((marks.ColumnCount - 2) / 2 - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count <= 0))
                            {
                                countCol = Math.Abs((marks.ColumnCount - 2) / 2 - mark[marks.CurrentCell.RowIndex].Count - selectForm.selectedRow.Count);

                                ColumnGenBallWeight(countCol);
                            }

                            int index = mark[marks.CurrentCell.RowIndex].Count * 2 + 1, indexMark = 0;

                            for (int i = 0; i < selectForm.selectedRow.Count * 2; i++)
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

        /// <summary>
        /// Форматирование таблицы
        /// </summary>
        public override void TableFormating()
        {
            CheckCell();
            InputMark();
            ResultBall(mark);
            ColorTableMarks();
        }

        /// <summary>
        /// Удалить неправильно заполненные ячейки
        /// </summary>
        public override void CellClearNotValid()
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
