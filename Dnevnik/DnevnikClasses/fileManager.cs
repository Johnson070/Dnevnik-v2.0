using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    public class FileManager
    {
        //bool startEdit = false;
        //bool fileOpen = false;

        //private string directory = "";

        public void OpenFile(DataGridView grid, bool startEdit, bool fileOpen, bool type)
        {
            if (startEdit)
            {
                DialogResult result = MessageBox.Show("Сохранить таблицу перед открытием файла?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    SaveFile(grid, startEdit, type, "");
            }

            using OpenFileDialog loadFileDialog = new OpenFileDialog
            {
                Filter = "json Файл (*.dnv)|*.dnv|txt Файл (*.txt)|*.txt",
                RestoreDirectory = true
            };

            string json;
            StructFile table = null;

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fname = loadFileDialog.FileName;
                //directory = loadFileDialog.FileName;

                json = File.ReadAllText(fname);

                try
                {
                    table = JsonConvert.DeserializeObject<StructFile>(json);
                    fileOpen = true;
                }
                catch
                {
                    MessageBox.Show("Таблица не была загружена.\nПроверьте целостность файла.", "Ошибка чтения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (table != null)
            {
                if (table.typeGrid != type)
                {
                    MessageBox.Show("Не совпадают настройки типа вычисления баллов!\rПоменяйте в вкладке тип на средний балл/средний взвешенный бал.", "Ошибка несовместимости", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MarksTable drawTable;

                    if (!type)
                    {
                        drawTable = new MarksTableAverageMass
                        {
                            marks = grid
                        };

                        drawTable.marks.Rows.Clear();
                        drawTable.marks.Columns.Clear();

                        drawTable.DrawGrid((table.columnCount - 2) / 2, table.nameLess);
                    }
                    else
                    {
                        drawTable = new MarksTableAverage
                        {
                            marks = grid
                        };

                        drawTable.marks.Rows.Clear();
                        drawTable.marks.Columns.Clear();

                        drawTable.DrawGrid(table.columnCount - 2, table.nameLess);
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

        public bool SaveFile(DataGridView grid, bool startEdit, bool type, string fileName)
        {
            bool returnBool = true;

            StructFile table = new StructFile
            {
                typeGrid = type,
                columnCount = grid.ColumnCount
            };

            for (int i = 0; i < grid.RowCount; i++)
                if (grid[0, i].Value != null)
                    table.nameLess.Add(grid[0, i].Value.ToString());
                else
                    table.nameLess.Add("");

            for (int i = 0; i < grid.RowCount; i++)
            {
                table.marks.Add(new List<string>());

                for (int j = 1; j < grid.ColumnCount - 1; j++)
                    if (grid[j, i].Value != null)
                        table.marks[i].Add(grid[j, i].Value.ToString());
            }

            Stream saveStream;

            using SaveFileDialog saveLevelDialog = new SaveFileDialog
            {
                Filter = "json Файл (*.dnv)|*.dnv|txt Файл (*.txt)|*.txt",
                RestoreDirectory = true,
                FileName = fileName
            };

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
                        returnBool = false;
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

            return returnBool;
        }

        private class StructFile
        {
            public List<List<string>> marks = new List<List<string>>();
            public List<string> nameLess = new List<string>();
            public bool typeGrid;
            public int columnCount;
        }
    }
}
