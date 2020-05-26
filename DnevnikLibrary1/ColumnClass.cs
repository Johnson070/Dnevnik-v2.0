using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    class ColumnClass
    {
        public List<DataGridViewColumn> ball = new List<DataGridViewColumn>();
        public List<DataGridViewColumn> weight = new List<DataGridViewColumn>();
        public List<DataGridViewColumn> ballSr = new List<DataGridViewColumn>();
        public DataGridViewColumn lesson = new DataGridViewColumn();

        public ColumnClass()
        {
            for (int i = 0; i < 2; i++)
                ball.Add(new DataGridViewColumn());

            for (int i = 0; i < 2; i++)
                weight.Add(new DataGridViewColumn());

            for (int i = 0; i < 4; i++)
                ballSr.Add(new DataGridViewColumn());

            ball[0].HeaderText = "Оценка"; //текст в шапке
            ball[0].Width = 50; //ширина колонки
            ball[0].DefaultCellStyle.BackColor = Color.FromArgb(179, 179, 179);
            //ball.DefaultCellStyle.BackColor = (marks.ColumnCount % 2 == 0 ? Color.FromArgb(179, 179, 179) : Color.FromArgb(221, 221, 221));
            ball[0].ReadOnly = false; //значение в этой колонке нельзя править
            ball[0].Name = "val"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
                               //ball.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ball[0].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            /*=================================*/

            ball[1].HeaderText = "Оценка"; //текст в шапке
            ball[1].Width = 50; //ширина колонки
            //ball.DefaultCellStyle.BackColor = (i % 2 == 0 && type == true ? Color.LightGreen : Color.LimeGreen);
            ball[1].ReadOnly = true; //значение в этой колонке нельзя править
                                  //ball.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ball[1].Name = "val"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            ball[1].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            /*=================================*/

            weight[0].HeaderText = "Вес";
            weight[0].Width = 30;
            weight[0].ReadOnly = true;
            //weight.DefaultCellStyle.Font = Properties.Settings.Default.fontWeight;
            weight[0].DefaultCellStyle.BackColor = Color.FromArgb(0, 159, 7);
            weight[0].Name = "costs";
            weight[0].CellTemplate = new DataGridViewTextBoxCell();

            /*=================================*/

            weight[1].HeaderText = "Вес";
            weight[1].Width = 35;
            weight[1].DefaultCellStyle.BackColor = Color.FromArgb(221, 221, 221);
            //weight.DefaultCellStyle.Font = Properties.Settings.Default.fontWeight;
            weight[1].Name = "costs";
            weight[1].CellTemplate = new DataGridViewTextBoxCell();

            /*=================================*/

            ballSr[0].HeaderText = "Балл"; //текст в шапке
            ballSr[0].Width = 100; //ширина колонки
            ballSr[0].ReadOnly = false; //значение в этой колонке нельзя править
            ballSr[0].Name = "ball"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            //srBall.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ballSr[0].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            ballSr[0].ReadOnly = true;
            ballSr[0].DisplayIndex = 9999;

            /*=================================*/

            ballSr[1].HeaderText = "Балл"; //текст в шапке
            ballSr[1].Width = 75; //ширина колонки
            ballSr[1].ReadOnly = true; //значение в этой колонке нельзя править
            ballSr[1].Name = "ball"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            //srBallColumn.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ballSr[1].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            ballSr[1].SortMode = DataGridViewColumnSortMode.Programmatic;
            ballSr[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            ballSr[1].DisplayIndex = 999;

            /*=================================*/

            ballSr[2].HeaderText = "Старый балл"; //текст в шапке
            ballSr[2].Width = 75; //ширина колонки
            ballSr[2].ReadOnly = true; //значение в этой колонке нельзя править
            ballSr[2].Name = "ballBefore"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            //srBallColumnDo.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ballSr[2].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            ballSr[2].SortMode = DataGridViewColumnSortMode.Programmatic;
            ballSr[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            ballSr[2].DisplayIndex = 9999;

            /*=================================*/

            ballSr[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            ballSr[3].HeaderText = "Разность баллов"; //текст в шапке
            ballSr[3].Width = 75; //ширина колонки
            ballSr[3].ReadOnly = true; //значение в этой колонке нельзя править
            //srBallColumnRasn.DefaultCellStyle.Font = Properties.Settings.Default.fontBall;
            ballSr[3].Name = "ballRasn"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            ballSr[3].CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            ballSr[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            ballSr[3].SortMode = DataGridViewColumnSortMode.Programmatic;
            ballSr[3].DisplayIndex = 9999;

            /*=================================*/

            lesson.HeaderText = "Предмет"; //текст в шапке
            lesson.Width = 150; //ширина колонки
            lesson.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            lesson.Frozen = true;
            lesson.ReadOnly = false;
            //less.DefaultCellStyle.Font = Properties.Settings.Default.font;
            lesson.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
        }
    }
}
