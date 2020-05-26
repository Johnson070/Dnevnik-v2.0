using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    class ResetClass
    {
        DataGridView grid;
        MarksTable table;
        List<MarksTable> tableList;

        public ResetClass(MarksTable table, DataGridView grid)
        {
            this.grid = grid;
            this.table = table;
        }

        public ResetClass(List<MarksTable> table, DataGridView grid)
        {
            this.grid = grid;
            this.tableList = table;
        }

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

            table.CellFormating();

            table.startEdit = false;
            table.fileOpen = false;

            return table;
        }

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

            tableList[0].CellFormating();

            tableList[0].startEdit = false;
            tableList[0].fileOpen = false;

            return tableList;
        }
    }
}
