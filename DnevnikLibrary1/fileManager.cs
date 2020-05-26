using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    public class fileManager
    {
        public bool startEdit = false;
        public bool fileOpen = false;
        private string directory = "";

        public void openFile(DataGridView grid)
        {
            if (startEdit)
            {
                DialogResult result = MessageBox.Show("Сохранить таблицу перед открытием файла?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    saveFile(grid);
            }

            OpenFileDialog loadFileDialog = new OpenFileDialog();

            loadFileDialog.Filter = "json Файл (*.json)|*.json|txt Файл (*.txt)|*.txt";
            loadFileDialog.RestoreDirectory = true;

            string json;
            structFile table = null;

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fname = loadFileDialog.FileName;
                directory = loadFileDialog.FileName;

                json = File.ReadAllText(fname);

                try
                {
                    table = JsonConvert.DeserializeObject<structFile>(json);
                    fileOpen = true;
                }
                catch
                {
                    MessageBox.Show("Таблица не была загружена.\nПроверьте целостность файла.", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (table != null)
            {
                if (table.typeGrid != Properties.Settings.Default.typeBall)
                {
                    MessageBox.Show("Не совпадают настройки типа вычисления баллов!\rПоменяйте в настройках тип на средний балл/средний взвешенный бал.", "Ошибка несовместимости", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MarksTable drawTable;

                    if (!Properties.Settings.Default.typeBall)
                    {
                        drawTable = new marksTableClass();

                        drawTable.marks = grid;

                        drawTable.marks.Rows.Clear();
                        drawTable.marks.Columns.Clear();

                        drawTable.drawGrid((table.columnCount - 2) / 2, table.nameLess);
                    }
                    else
                    {
                        drawTable = new marksTableClassSr();

                        drawTable.marks = grid;

                        drawTable.marks.Rows.Clear();
                        drawTable.marks.Columns.Clear();

                        drawTable.drawGrid(table.columnCount - 2, table.nameLess);
                    }

                    int posRow = 0, posColumn = 1;

                    for (int i = 0; i < table.marks.Count; i++)
                    {
                        for (int j = 0; j < table.marks[i].Count; j++)
                        {
                            drawTable.marks[posColumn, posRow].Value = table.marks[i][j];
                            posColumn++;
                        }

                        posRow++;
                        posColumn = 1;
                    }
                }
            }
        }

        public void saveFile(DataGridView grid)
        {
            structFile table = new structFile();

            table.typeGrid = Properties.Settings.Default.typeBall;
            table.columnCount = grid.ColumnCount;

            for (int i = 0; i < grid.RowCount; i++)
                if (grid[0, i].Value != null)
                    table.nameLess.Add(grid[0, i].Value.ToString());
                else
                    table.nameLess.Add("");

            for (int i = 0; i < grid.RowCount; i++) {
                table.marks.Add(new List<string>());
                
                for (int j = 1; j < grid.ColumnCount - 1; j++)
                    if (grid[j, i].Value != null)
                        table.marks[i].Add(grid[j, i].Value.ToString());
            }

            Stream saveStream;

            SaveFileDialog saveLevelDialog = new SaveFileDialog();

            saveLevelDialog.Filter = "json Файл (*.json)|*.json|txt Файл (*.txt)|*.txt";
            saveLevelDialog.RestoreDirectory = true;

            if (saveLevelDialog.ShowDialog() == DialogResult.OK)
            {
                if ((saveStream = saveLevelDialog.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(saveStream);
                    try
                    {
                        myWriter.Write(JsonConvert.SerializeObject(table, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
                        MessageBox.Show("Таблица сохранена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        startEdit = false;

                    }
                    catch 
                    {
                        MessageBox.Show("Таблица не сохранена!\rПопробуйте поменять имя файла или проверить не занят ли файл другим процессом.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                    saveStream.Close();

                    
                }
            }
            else
            {

            }
        }

        private class structFile
        {
            public List<List<string>> marks = new List<List<string>>();
            public List<string> nameLess = new List<string>();
            public bool typeGrid;
            public int columnCount;
        }
    }
}
