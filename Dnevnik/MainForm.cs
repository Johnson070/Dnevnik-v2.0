﻿using ApiDiaryLibrary;
using Dnevnik.DnevnikClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Dnevnik
{
    public partial class dnevnik : Form
    {
        List<MarksTable> table;
        readonly FileManager file = new FileManager();

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);

        public dnevnik()
        {
            InitializeComponent();

            this.addRowButton.Click += (sender, args) => { this.table[tabControl1.SelectedIndex].EditTable(1); CellFormating(null, null); };
            this.deleteRowButton.Click += (sender, args) => { this.table[tabControl1.SelectedIndex].EditTable(2); CellFormating(null, null); };
            this.addColumnButton.Click += (sender, args) => { this.table[tabControl1.SelectedIndex].EditTable(3); CellFormating(null, null); };
            this.deleteColumnButton.Click += (sender, args) => { this.table[tabControl1.SelectedIndex].EditTable(4); CellFormating(null, null); };
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
            table[tabControl1.SelectedIndex].GenMarksForm();

            CellFormating(null, null);

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        private void UpRow(object sender, EventArgs e)
        {
            table[tabControl1.SelectedIndex].UpDownRow(false);
        }

        private void DownRow(object sender, EventArgs e)
        {
            table[tabControl1.SelectedIndex].UpDownRow(true);
        }

        private void CellFormating(object sender, DataGridViewCellEventArgs e)
        {
            table[tabControl1.SelectedIndex].CellFormating();

            table[tabControl1.SelectedIndex].startEdit = true;

            tabControl1.TabPages[tabControl1.SelectedIndex].Text = tabControl1.TabPages[tabControl1.SelectedIndex].Text.Replace(" *", string.Empty) + " *";
        }

        private void Dnevnik_Shown(object sender, EventArgs e)
        {
            AddTab_Click(null, null);
        }

        private void ClearCell_Click(object sender, EventArgs e)
        {
            if (table[tabControl1.SelectedIndex].marks.CurrentCell.ColumnIndex > 0 && table[tabControl1.SelectedIndex].marks.CurrentCell.ColumnIndex < table[tabControl1.SelectedIndex].marks.ColumnCount - 1)
                table[tabControl1.SelectedIndex].marks[table[tabControl1.SelectedIndex].marks.CurrentCell.ColumnIndex, table[tabControl1.SelectedIndex].marks.CurrentCell.RowIndex].Value = null;

            CellFormating(null, null);
        }

        private void ClearTable_Click(object sender, EventArgs e)
        {
            DialogResult resultDial = MessageBox.Show("Вы уверены что хотите очистить таблицу?", "Очистить таблицу?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultDial == DialogResult.Yes)
            {
                ResetClass rst = new ResetClass(table[tabControl1.SelectedIndex], table[tabControl1.SelectedIndex].marks);

                table[tabControl1.SelectedIndex] = rst.Reset(table[tabControl1.SelectedIndex].type);
            }
        }

        private void SettingsButtonTool_Click(object sender, EventArgs e)
        {
            using SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (table[tabControl1.SelectedIndex] is MarksTableAverageMass) table[tabControl1.SelectedIndex].CellClearNotValid();
            //table[tabControl1.SelectedIndex].CellFormating();
            file.OpenFile(table[tabControl1.SelectedIndex].marks, table[tabControl1.SelectedIndex].startEdit, table[tabControl1.SelectedIndex].fileOpen, table[tabControl1.SelectedIndex].type);

            table[tabControl1.SelectedIndex].CellFormating();
            table[tabControl1.SelectedIndex].startEdit = false;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (table[tabControl1.SelectedIndex] is MarksTableAverageMass) table[tabControl1.SelectedIndex].CellClearNotValid();
            table[tabControl1.SelectedIndex].CellFormating();
            var state = file.SaveFile(table[tabControl1.SelectedIndex].marks, table[tabControl1.SelectedIndex].startEdit, table[tabControl1.SelectedIndex].type, tabControl1.SelectedTab.Text.Replace(" *", string.Empty));

            if (!state)
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = tabControl1.TabPages[tabControl1.SelectedIndex].Text.Replace(" *", string.Empty);

            table[tabControl1.SelectedIndex].startEdit = state;
        }

        private void Dnevnik_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
                if (table[i].startEdit == true)
                {
                    tabControl1.SelectedIndex = i;

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
            //try
            {
                DnevnikWork workDnevnik = new DnevnikWork((keyAccess == "" ? Properties.Settings.Default.keyAccess : keyAccess));

                if (table[tabControl1.SelectedIndex].startEdit == true)
                {
                    DialogResult rsl = MessageBox.Show("Сохранить таблицу в файл?\nТекущая таблица будет очищена перед вставкой оценок из ЭЖ.", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rsl == DialogResult.Yes)
                    {
                        saveFile.PerformClick();
                    }
                }

                ResetClass rst = new ResetClass(table[tabControl1.SelectedIndex], table[tabControl1.SelectedIndex].marks);
                ApiDiary api = new ApiDiary(keyAccess == "" ? Properties.Settings.Default.keyAccess : keyAccess);

                long personId = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>();
                var groups = workDnevnik.GetAllGroups(workDnevnik.GetMembers());

                using SelectDataChildren criteriaForm = new SelectDataChildren(workDnevnik.GetMembers(groups), workDnevnik.GetMembers(), groups);
                criteriaForm.ShowDialog();

                if (criteriaForm.closeWindow)
                {
                    Status.Visible = true;

                    loadBar.Value = 20;
                    loadBar.MarqueeAnimationSpeed = 45;
                    tabControl1.Enabled = false;
                    LabelLoad.Text = "Ожидайте пока программа вставит все оценки.";
                    Tools.Enabled = false;
                    table[tabControl1.SelectedIndex].marks.Enabled = false;

                    int indexTab = tabControl1.SelectedIndex;

                    var test = workDnevnik.GetAllGroups(workDnevnik.GetMembers());

                    SelectChildren children = new SelectChildren()
                    {
                        table = table[indexTab],
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
            //catch (Exception ex) { MessageBox.Show("Непредвиденная ошибка!\nПопробуйте повторить попытку, поменять параметры или перезапустить программу!"); Clipboard.SetText(ex.Message); }
        }

        private void WorkBack_RunWorkerCompleted(DnevnikWork diary)
        {
            diary.InsertMarksInTable();

            Tools.Enabled = true;
            Status.Visible = false;
            tabControl1.Enabled = true;
            table[tabControl1.SelectedIndex].marks.Enabled = true;
            loadBar.MarqueeAnimationSpeed = 0;

            CellFormating(null, null);
        }

        private void AddTab_Click(object sender, EventArgs e)
        {
            using TabSettings tab = (table == null ? null : new TabSettings("Создать вкладку", "Пример 1", false));

            if (table != null)
                tab.ShowDialog();

            table ??= new List<MarksTable>();

            tabControl1.TabPages.Add(tab == null ? "Вкладка 1" : tab.nameTab);
            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            table.Add(new MarksTable());

            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = false,
                ContextMenuStrip = contextMenuStrip2
            };

            grid.CellEndEdit += (obj, ev) => CellFormating(obj, ev);


            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(grid);

            ResetClass rst = new ResetClass(table[tabControl1.SelectedIndex], grid);

            table[tabControl1.SelectedIndex] = rst.Reset(tab == null ? true : tab.type);
        }

        private void EditTab_Click(object sender, EventArgs e)
        {
            using TabSettings tab = new TabSettings("Изменить вкладку", tabControl1.TabPages[tabControl1.SelectedIndex].Text, table[tabControl1.SelectedIndex].type);

            tab.ShowDialog();

            if (tab.nameTab != "")
            {
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = tab.nameTab;

                if (tab.type != table[tabControl1.SelectedIndex].type)
                {
                    DialogResult quest = DialogResult.No;

                    if (table[tabControl1.SelectedIndex].startEdit)
                        quest = MessageBox.Show("Вы сменили тип среднего балла, сохранить текущую таблицу?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (quest == DialogResult.Yes)
                    {
                        saveFile.PerformClick();
                    }

                    table[tabControl1.SelectedIndex].type = tab.type;

                    ResetClass rst = new ResetClass(table[tabControl1.SelectedIndex], table[tabControl1.SelectedIndex].marks);

                    table[tabControl1.SelectedIndex] = rst.Reset(tab.type);
                }
            }
        }

        private void DeleteTab_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult = DialogResult.Yes;

            if (tabControl1.TabCount > 1)
                result = MessageBox.Show("Вы уверены, что хотите закрыть вкладку?", "Закрыть?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (tabControl1.TabCount > 1)
                {
                    int indexTab = tabControl1.SelectedIndex;

                    tabControl1.TabPages.RemoveAt(indexTab);
                    table.RemoveAt(indexTab);
                }
            }
        }

        private void UpdateInfo_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                string version = "";

                using (WebClient Client = new WebClient())
                {
                    Client.Encoding = Encoding.UTF8;
                    version = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/change_log.txt");
                }

                MessageBox.Show(version);
            }
        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            using ErrorNotification mail = new ErrorNotification();
            mail.ShowDialog();
        }
    }
}
