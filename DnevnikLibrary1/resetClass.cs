using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    class resetClass
    {
        DataGridView grid;
        fileManager file;
        MarksTable table;

        public resetClass(MarksTable _table, fileManager _file, DataGridView _grid)
        {
            grid = _grid;
            file = _file;
            table = _table;
        }

        public MarksTable Reset()
        {
            table = null;

            if (!Properties.Settings.Default.typeBall)
                table = new marksTableClass();
            else
                table = new marksTableClassSr();

            grid.Rows.Clear();
            grid.Columns.Clear();

            table.marks = grid;
            table.drawGrid(2, table.nameLess);

            table.cellFormating();

            file.startEdit = false;
            file.fileOpen = false;

            return table;
        }
    }
}
