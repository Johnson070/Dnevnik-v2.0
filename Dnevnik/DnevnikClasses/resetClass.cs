using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс для сброса markstable и таблицы
    /// </summary>
    class ResetClass
    {
        /// <summary>
        /// Таблица
        /// </summary>
        readonly DataGridView grid;

        /// <summary>
        /// Класс с таблицей
        /// </summary>
        MarksTable table;

        /// <summary>
        /// Список с таблицами
        /// </summary>
        List<MarksTable> tableList;

        /// <summary>
        /// Инициализация класса
        /// </summary>
        /// <param name="table">Класс с таблицей</param>
        /// <param name="grid">Таблица datagridview</param>
        public ResetClass(MarksTable table, DataGridView grid)
        {
            this.grid = grid;
            this.table = table;
        }

        /// <summary>
        /// Инициализация класса
        /// </summary>
        /// <param name="table">Список классов с таблицами</param>
        /// <param name="grid">Таблица datagridview</param>
        public ResetClass(List<MarksTable> table, DataGridView grid)
        {
            this.grid = grid;
            this.tableList = table;
        }

        /// <summary>
        /// Сброс класса в начальные настроки
        /// </summary>
        /// <param name="type">Тип таблицы(true - средний балл, false - средний взвешенный балл)</param>
        /// <returns></returns>
        public MarksTable Reset(bool type)
        {
            table = null;

            if (!type)
                table = new MarksTableAverageMass();
            else
                table = new MarksTableAverage();

            grid.Rows.Clear();
            grid.Columns.Clear();

            table.type = type;
            table.marks = grid;
            table.DrawGrid(2, table.nameLess);

            table.TableFormating();

            table.startEdit = false;
            table.fileOpen = false;

            return table;
        }

        /// <summary>
        /// Сброс списка таблиц в начальные настройки
        /// </summary>
        /// <param name="type">Тип таблицы(true - средний балл, false - средний взвешенный балл)</param>
        /// <returns></returns>
        public List<MarksTable> ResetList(bool type)
        {
            tableList = new List<MarksTable>();

            if (!type)
                tableList.Add(new MarksTableAverageMass());
            else
                tableList.Add(new MarksTableAverage());

            grid.Rows.Clear();
            grid.Columns.Clear();

            tableList[0].type = !type;
            tableList[0].marks = grid;
            tableList[0].DrawGrid(2, tableList[0].nameLess);

            tableList[0].TableFormating();

            tableList[0].startEdit = false;
            tableList[0].fileOpen = false;

            return tableList;
        }
    }
}
