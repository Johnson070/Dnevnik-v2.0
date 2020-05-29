using ApiDiaryLibrary;
using Dnevnik.DnevnikClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Dnevnik
{
    partial class dnevnik : Form
    {
        List<MarksTable> tables;
        readonly FileManager file = new FileManager();
        string[] args;

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public dnevnik(string[] args)
        {
            InitializeComponent();

            this.args = args;

            this.addRowButton.Click += (sender, args) => { this.tables[TabMarks.SelectedIndex].EditTable(1); CellFormating(null, null); };
            this.deleteRowButton.Click += (sender, args) => { this.tables[TabMarks.SelectedIndex].EditTable(2); CellFormating(null, null); };
            this.addColumnButton.Click += (sender, args) => { this.tables[TabMarks.SelectedIndex].EditTable(3); CellFormating(null, null); };
            this.deleteColumnButton.Click += (sender, args) => { this.tables[TabMarks.SelectedIndex].EditTable(4); CellFormating(null, null); };
        }

        public static bool IsInternetAvailable()
        {
            bool state = InternetGetConnectedState(out _, 0);

            if (!state)
                MessageBox.Show($"Проверьте соединение с интернетом.", "Нет доступа к интернету", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return state;
        }

        private void GenerateMarks(object sender, EventArgs e)
        {
            tables[TabMarks.SelectedIndex].GenMarksForm();

            CellFormating(null, null);

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        private void UpRow(object sender, EventArgs e)
        {
            tables[TabMarks.SelectedIndex].UpDownRow(false);
        }

        private void DownRow(object sender, EventArgs e)
        {
            tables[TabMarks.SelectedIndex].UpDownRow(true);
        }

        private void CellFormating(object sender, DataGridViewCellEventArgs e)
        {
            tables[TabMarks.SelectedIndex].CellFormating();

            tables[TabMarks.SelectedIndex].startEdit = true;

            TabMarks.TabPages[TabMarks.SelectedIndex].Text = TabMarks.TabPages[TabMarks.SelectedIndex].Text.Replace(" *", string.Empty) + " *";
        }

        private void Dnevnik_Shown(object sender, EventArgs e)
        {
            if (args.Length > 1)
            {
                try
                {
                    bool type = file.GetFileType(args[1]);

                    AddTabFunc(type);
                }
                catch
                {
                    AddTabFunc();
                    args = null;
                }
            }
            else
                AddTabFunc();

            Welcome();
            ChangeLog();

            try
            {
                if (args.Length > 1) file.OpenFile(tables[TabMarks.SelectedIndex].marks, args[1], tables[TabMarks.SelectedIndex].type);

                tables[TabMarks.SelectedIndex].CellFormating();
                tables[TabMarks.SelectedIndex].startEdit = false;
            }
            catch { }

            ProgramUpdate.PerformClick();
        }

        private void ChangeLog()
        {
            if (Properties.Settings.Default.change_log)
            {
                if (IsInternetAvailable())
                {
                    CheckUpdate update = new CheckUpdate();

                    MessageBox.Show(update.GetChangeLog(), "О обновлении", MessageBoxButtons.OK);
                }

                Properties.Settings.Default.change_log = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Welcome()
        {
            if (Properties.Settings.Default.welcome)
            {
                MessageBox.Show("Здравствуйте, спасибо за установку данной программы.\r\r\r\n\nЕсли вы нашли ошибку перейдите в\nОсновные => Репорт об ошибках и предложений\r\r\r\n\nЕсли у вас есть идеи и предложения перейдите в Основные => Репорт об ошибках и предложений\r\r\r\n\nПриятного пользования!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Properties.Settings.Default.welcome = false;
                Properties.Settings.Default.Save();
            }
        }

        private void ClearCell_Click(object sender, EventArgs e)
        {
            if (tables[TabMarks.SelectedIndex].marks.CurrentCell.ColumnIndex > 0 && tables[TabMarks.SelectedIndex].marks.CurrentCell.ColumnIndex < tables[TabMarks.SelectedIndex].marks.ColumnCount - 1)
                tables[TabMarks.SelectedIndex].marks[tables[TabMarks.SelectedIndex].marks.CurrentCell.ColumnIndex, tables[TabMarks.SelectedIndex].marks.CurrentCell.RowIndex].Value = null;

            CellFormating(null, null);
        }

        private void ClearTable_Click(object sender, EventArgs e)
        {
            DialogResult resultDial = MessageBox.Show("Вы уверены что хотите очистить таблицу?", "Очистить таблицу?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultDial == DialogResult.Yes)
            {
                ResetClass rst = new ResetClass(tables[TabMarks.SelectedIndex], tables[TabMarks.SelectedIndex].marks);

                tables[TabMarks.SelectedIndex] = rst.Reset(tables[TabMarks.SelectedIndex].type);
            }
        }

        private void SettingsButtonTool_Click(object sender, EventArgs e)
        {
            using SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (tables[TabMarks.SelectedIndex] is MarksTableAverageMass) tables[TabMarks.SelectedIndex].CellClearNotValid();
            //table[tabControl1.SelectedIndex].CellFormating();
            file.OpenFile(tables[TabMarks.SelectedIndex].marks, tables[TabMarks.SelectedIndex].startEdit, tables[TabMarks.SelectedIndex].fileOpen, tables[TabMarks.SelectedIndex].type);

            tables[TabMarks.SelectedIndex].CellFormating();
            tables[TabMarks.SelectedIndex].startEdit = false;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (tables[TabMarks.SelectedIndex] is MarksTableAverageMass) tables[TabMarks.SelectedIndex].CellClearNotValid();
            tables[TabMarks.SelectedIndex].CellFormating();
            var state = file.SaveFile(tables[TabMarks.SelectedIndex].marks, tables[TabMarks.SelectedIndex].startEdit, tables[TabMarks.SelectedIndex].type, TabMarks.SelectedTab.Text.Replace(" *", string.Empty));

            if (!state)
                TabMarks.TabPages[TabMarks.SelectedIndex].Text = TabMarks.TabPages[TabMarks.SelectedIndex].Text.Replace(" *", string.Empty);

            tables[TabMarks.SelectedIndex].startEdit = state;
        }

        private void Dnevnik_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < TabMarks.TabCount; i++)
                if (tables[i].startEdit == true)
                {
                    TabMarks.SelectedIndex = i;

                    DialogResult rsl = MessageBox.Show("Сохранить файл перед закрытием?", "Сохранить файл?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rsl == DialogResult.Yes)
                    {
                        saveFile.PerformClick();
                    }
                }
        }

        private void AddMarksInDnevnik_Click(object sender, EventArgs e)
        {
            string keyAccess = "";
            bool closedSuccess = false;

            if (Properties.Settings.Default.keyAccess != "")
            {

                try
                {
                    ApiDiary api = new ApiDiary(Properties.Settings.Default.keyAccess);

                    closedSuccess = true;
                }
                catch
                {
                    using LoginDnevnik loginForm = new LoginDnevnik();
                    loginForm.ShowDialog();

                    keyAccess = loginForm.keyAccess;

                    closedSuccess = loginForm.closedSuccess;
                }
            }
            else
            {
                using LoginDnevnik loginForm = new LoginDnevnik();
                loginForm.ShowDialog();

                keyAccess = loginForm.keyAccess;

                closedSuccess = loginForm.closedSuccess;
            }

            if (closedSuccess)
                try
                {
                    DnevnikWork workDnevnik = new DnevnikWork((keyAccess == "" ? Properties.Settings.Default.keyAccess : keyAccess));

                    if (tables[TabMarks.SelectedIndex].startEdit == true)
                    {
                        DialogResult rsl = MessageBox.Show("Сохранить таблицу в файл?\nТекущая таблица будет очищена перед вставкой оценок из ЭЖ.", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rsl == DialogResult.Yes)
                        {
                            saveFile.PerformClick();
                        }
                    }

                    ResetClass rst = new ResetClass(tables[TabMarks.SelectedIndex], tables[TabMarks.SelectedIndex].marks);
                    ApiDiary api = new ApiDiary(keyAccess == "" ? Properties.Settings.Default.keyAccess : keyAccess);

                    long personId = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>();
                    var groups = workDnevnik.GetAllGroups(workDnevnik.GetMembers());

                    using SelectDataChildren criteriaForm = new SelectDataChildren(workDnevnik.GetMembers(groups), workDnevnik.GetMembers(), groups);
                    criteriaForm.ShowDialog();

                    if (criteriaForm.closeWindow)
                    {
                        Status.Visible = true;

                        loadBar.Value = 20;
                        loadBar.Style = ProgressBarStyle.Marquee;
                        loadBar.MarqueeAnimationSpeed = 45;
                        TabMarks.Enabled = false;
                        LabelLoad.Text = "Ожидайте пока программа вставит все оценки.";
                        Tools.Enabled = false;
                        tables[TabMarks.SelectedIndex].marks.Enabled = false;

                        int indexTab = TabMarks.SelectedIndex;

                        var test = workDnevnik.GetAllGroups(workDnevnik.GetMembers());

                        SelectChildren children = new SelectChildren()
                        {
                            table = tables[indexTab],
                            Reset = rst,
                            EndDate = criteriaForm.EndDate.Value,
                            StartDate = criteriaForm.StartDate.Value,
                            Member = workDnevnik.GetMembers(workDnevnik.GetAllGroups(workDnevnik.GetMembers()))[criteriaForm.indexGroup][criteriaForm.indexChild],
                            group = workDnevnik.GetAllGroups(workDnevnik.GetMembers())[criteriaForm.indexChildGroup][criteriaForm.indexGroup]
                        };

                        WorkBack = new BackgroundWorker(); //WorkBack.DoWork += (obj, ea) => 
                        WorkBack.DoWork += (obj, ea) => workDnevnik.GetMarksDiary(children);
                        WorkBack.RunWorkerCompleted += (obj, ea) => WorkBack_RunWorkerCompleted(workDnevnik);
                        WorkBack.RunWorkerAsync();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Непредвиденная ошибка!\nПопробуйте повторить попытку, поменять параметры или перезапустить программу!"); Clipboard.SetText(ex.Message); }
        }

        private void WorkBack_RunWorkerCompleted(DnevnikWork diary)
        {
            diary.InsertMarksInTable();

            Tools.Enabled = true;
            Status.Visible = false;
            TabMarks.Enabled = true;
            tables[TabMarks.SelectedIndex].marks.Enabled = true;
            loadBar.MarqueeAnimationSpeed = 0;

            CellFormating(null, null);
        }

        private void AddTab_Click(object sender, EventArgs e)
        {
            AddTabFunc();
        }

        private void AddTabFunc(bool type = false, bool newTab = false)
        {
            if (!newTab)
            {
                using TabSettings tab = (tables == null ? null : new TabSettings("Создать вкладку", "Пример 1", type));

                if (tables != null)
                    tab.ShowDialog();

                tables ??= new List<MarksTable>();

                TabMarks.TabPages.Add(tab == null ? "Вкладка 1" : tab.nameTab);
                TabMarks.SelectedIndex = TabMarks.TabCount - 1;
                tables.Add(new MarksTable());

                DataGridView grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = false,
                    ContextMenuStrip = contextMenuStrip2,
                    AllowDrop = true
                };

                grid.DragDrop += DropFile;
                grid.DragEnter += DragEnter;
                grid.CellEndEdit += (obj, ev) => CellFormating(obj, ev);


                TabMarks.TabPages[TabMarks.SelectedIndex].Controls.Add(grid);

                ResetClass rst = new ResetClass(tables[TabMarks.SelectedIndex], grid);

                tables[TabMarks.SelectedIndex] = rst.Reset(tab == null ? type : tab.type);
            }
            else
            {
                using TabSettings tab = new TabSettings("Создать вкладку", "Пример 1", type);

                TabMarks.TabPages.Add("Пример 1");
                TabMarks.SelectedIndex = TabMarks.TabCount - 1;
                tables.Add(new MarksTable());

                DataGridView grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = false,
                    ContextMenuStrip = contextMenuStrip2,
                    AllowDrop = true
                };

                grid.DragDrop += DropFile;
                grid.DragEnter += DragEnter;
                grid.CellEndEdit += (obj, ev) => CellFormating(obj, ev);


                TabMarks.TabPages[TabMarks.SelectedIndex].Controls.Add(grid);

                ResetClass rst = new ResetClass(tables[TabMarks.SelectedIndex], grid);

                tables[TabMarks.SelectedIndex] = rst.Reset(type);
            }
        }

        private void EditTab_Click(object sender, EventArgs e)
        {
            using TabSettings tab = new TabSettings("Изменить вкладку", TabMarks.TabPages[TabMarks.SelectedIndex].Text, tables[TabMarks.SelectedIndex].type);

            tab.ShowDialog();

            if (tab.nameTab != "")
            {
                TabMarks.TabPages[TabMarks.SelectedIndex].Text = tab.nameTab;

                if (tab.type != tables[TabMarks.SelectedIndex].type)
                {
                    DialogResult quest = DialogResult.No;

                    if (tables[TabMarks.SelectedIndex].startEdit)
                        quest = MessageBox.Show("Вы сменили тип среднего балла, сохранить текущую таблицу?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (quest == DialogResult.Yes)
                    {
                        saveFile.PerformClick();
                    }

                    tables[TabMarks.SelectedIndex].type = tab.type;

                    ResetClass rst = new ResetClass(tables[TabMarks.SelectedIndex], tables[TabMarks.SelectedIndex].marks);

                    tables[TabMarks.SelectedIndex] = rst.Reset(tab.type);
                }
            }
        }

        private void DeleteTab_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult = DialogResult.Yes;

            if (TabMarks.TabCount > 1)
                result = MessageBox.Show("Вы уверены, что хотите закрыть вкладку?", "Закрыть?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (TabMarks.TabCount > 1)
                {
                    int indexTab = TabMarks.SelectedIndex;

                    TabMarks.TabPages.RemoveAt(indexTab);
                    tables.RemoveAt(indexTab);
                }
            }
        }

        private void UpdateInfo_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                CheckUpdate update = new CheckUpdate();

                MessageBox.Show(update.GetChangeLog(), "О обновлении", MessageBoxButtons.OK);
            }
        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            using ErrorNotification mail = new ErrorNotification();
            mail.ShowDialog();
        }

        private void AboutProgram_Click(object sender, EventArgs e)
        {
            AboutDnevnik about = new AboutDnevnik();

            about.ShowDialog();
        }

        private void ProgramUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate update = new CheckUpdate();

            var text = update.CheckProgramUpdate();
            var version = update.GetVersion();


            DialogResult updateResult;

            if (!String.Equals(version, Application.ProductVersion))
                MessageBox.Show(text + "\n\r\n\rОбновление не требуется.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                updateResult = MessageBox.Show(text + "\n\r\n\rТребуется обновление. Обновить ПО?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (updateResult == DialogResult.Yes)
                {
                    bool notSaveTables = false;

                    foreach (MarksTable table in tables)
                        if (table.startEdit) notSaveTables = true;

                    DialogResult saveTables = DialogResult.No;

                    if (notSaveTables)
                        saveTables = MessageBox.Show("У вас есть не сохранённые таблицы, сохранить?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (saveTables == DialogResult.Yes)
                        Dnevnik_FormClosing(null, null);

                    Properties.Settings.Default.change_log = false;
                    Properties.Settings.Default.Save();

                    update.UpdateProgram(Status, loadBar, LabelLoad);
                }
            }
        }

        private void DropFile(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    try
                    {
                        bool type = file.GetFileType(filePath);

                        AddTabFunc(type, true);

                        file.OpenFile(tables[TabMarks.SelectedIndex].marks, filePath, tables[TabMarks.SelectedIndex].type);

                        tables[TabMarks.SelectedIndex].CellFormating();
                        tables[TabMarks.SelectedIndex].startEdit = false;
                    }
                    catch { }
                }
            }
        }

        new void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
