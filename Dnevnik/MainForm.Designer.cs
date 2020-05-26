namespace Dnevnik
{
    partial class dnevnik
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dnevnik));
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.operateFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsDownList = new System.Windows.Forms.ToolStripDropDownButton();
            this.genMarksCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьОценкиИзБуфераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMarksInDnevnik = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.upRowButton = new System.Windows.Forms.ToolStripMenuItem();
            this.downRowButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.addRowButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addColumnButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCell = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mainList = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsButtonTool = new System.Windows.Forms.ToolStripMenuItem();
            this.обновлениеПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.loadBar = new System.Windows.Forms.ToolStripProgressBar();
            this.LabelLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabControlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTab = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.EditTab = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkBack = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОбОбновленииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools.SuspendLayout();
            this.Status.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TabControlMenu.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tools
            // 
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operateFile,
            this.actionsDownList,
            this.mainList});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(637, 25);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "toolStrip1";
            // 
            // operateFile
            // 
            this.operateFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.operateFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile});
            this.operateFile.Image = ((System.Drawing.Image)(resources.GetObject("operateFile.Image")));
            this.operateFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.operateFile.Name = "operateFile";
            this.operateFile.Size = new System.Drawing.Size(49, 22);
            this.operateFile.Text = "Файл";
            this.operateFile.ToolTipText = "Работа с файлом";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(132, 22);
            this.openFile.Text = "Открыть";
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(132, 22);
            this.saveFile.Text = "Сохранить";
            this.saveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // actionsDownList
            // 
            this.actionsDownList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.actionsDownList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genMarksCriteria,
            this.toolStripSeparator1,
            this.добавитьОценкиИзБуфераToolStripMenuItem,
            this.AddMarksInDnevnik,
            this.toolStripSeparator2,
            this.upRowButton,
            this.downRowButton,
            this.toolStripSeparator3,
            this.addRowButton,
            this.deleteRowButton,
            this.toolStripSeparator4,
            this.addColumnButton,
            this.deleteColumnButton,
            this.toolStripSeparator5,
            this.clearCell,
            this.toolStripSeparator6,
            this.clearTable});
            this.actionsDownList.Image = ((System.Drawing.Image)(resources.GetObject("actionsDownList.Image")));
            this.actionsDownList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.actionsDownList.Name = "actionsDownList";
            this.actionsDownList.Size = new System.Drawing.Size(71, 22);
            this.actionsDownList.Text = "Действия";
            this.actionsDownList.ToolTipText = "Действия с таблицей";
            // 
            // genMarksCriteria
            // 
            this.genMarksCriteria.Name = "genMarksCriteria";
            this.genMarksCriteria.Size = new System.Drawing.Size(228, 22);
            this.genMarksCriteria.Text = "Генерировать";
            this.genMarksCriteria.Click += new System.EventHandler(this.GenerateMarks);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // добавитьОценкиИзБуфераToolStripMenuItem
            // 
            this.добавитьОценкиИзБуфераToolStripMenuItem.Name = "добавитьОценкиИзБуфераToolStripMenuItem";
            this.добавитьОценкиИзБуфераToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.добавитьОценкиИзБуфераToolStripMenuItem.Text = "Добавить оценки из буфера";
            // 
            // AddMarksInDnevnik
            // 
            this.AddMarksInDnevnik.Name = "AddMarksInDnevnik";
            this.AddMarksInDnevnik.Size = new System.Drawing.Size(228, 22);
            this.AddMarksInDnevnik.Text = "Добавить оценки из ЭЖ";
            this.AddMarksInDnevnik.Click += new System.EventHandler(this.AddMarksInDnevnik_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // upRowButton
            // 
            this.upRowButton.Name = "upRowButton";
            this.upRowButton.Size = new System.Drawing.Size(228, 22);
            this.upRowButton.Text = "Поднять строку";
            this.upRowButton.Click += new System.EventHandler(this.UpRow);
            // 
            // downRowButton
            // 
            this.downRowButton.Name = "downRowButton";
            this.downRowButton.Size = new System.Drawing.Size(228, 22);
            this.downRowButton.Text = "Опустить строку";
            this.downRowButton.Click += new System.EventHandler(this.DownRow);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // addRowButton
            // 
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(228, 22);
            this.addRowButton.Text = "Добавить строку";
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(228, 22);
            this.deleteRowButton.Text = "Удалить строку";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // addColumnButton
            // 
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(228, 22);
            this.addColumnButton.Text = "Добавить столбец";
            // 
            // deleteColumnButton
            // 
            this.deleteColumnButton.Name = "deleteColumnButton";
            this.deleteColumnButton.Size = new System.Drawing.Size(228, 22);
            this.deleteColumnButton.Text = "Удалить столбец";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
            // 
            // clearCell
            // 
            this.clearCell.Name = "clearCell";
            this.clearCell.Size = new System.Drawing.Size(228, 22);
            this.clearCell.Text = "Очистить ячейку";
            this.clearCell.Click += new System.EventHandler(this.ClearCell_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(225, 6);
            // 
            // clearTable
            // 
            this.clearTable.Name = "clearTable";
            this.clearTable.Size = new System.Drawing.Size(228, 22);
            this.clearTable.Text = "Очистить таблицу";
            this.clearTable.Click += new System.EventHandler(this.ClearTable_Click);
            // 
            // mainList
            // 
            this.mainList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mainList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsButtonTool,
            this.обновлениеПрограммыToolStripMenuItem,
            this.информацияОбОбновленииToolStripMenuItem,
            this.toolStripSeparator7,
            this.оПрограммеToolStripMenuItem});
            this.mainList.Image = ((System.Drawing.Image)(resources.GetObject("mainList.Image")));
            this.mainList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainList.Name = "mainList";
            this.mainList.Size = new System.Drawing.Size(77, 22);
            this.mainList.Text = "Основные";
            this.mainList.ToolTipText = "Основные";
            // 
            // settingsButtonTool
            // 
            this.settingsButtonTool.Name = "settingsButtonTool";
            this.settingsButtonTool.Size = new System.Drawing.Size(236, 22);
            this.settingsButtonTool.Text = "Настройки";
            this.settingsButtonTool.Click += new System.EventHandler(this.SettingsButtonTool_Click);
            // 
            // обновлениеПрограммыToolStripMenuItem
            // 
            this.обновлениеПрограммыToolStripMenuItem.Name = "обновлениеПрограммыToolStripMenuItem";
            this.обновлениеПрограммыToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.обновлениеПрограммыToolStripMenuItem.Text = "Обновление программы";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(233, 6);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBar,
            this.LabelLoad});
            this.Status.Location = new System.Drawing.Point(0, 458);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(637, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            this.Status.Visible = false;
            // 
            // loadBar
            // 
            this.loadBar.Name = "loadBar";
            this.loadBar.Size = new System.Drawing.Size(100, 16);
            this.loadBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // LabelLoad
            // 
            this.LabelLoad.Name = "LabelLoad";
            this.LabelLoad.Size = new System.Drawing.Size(118, 17);
            this.LabelLoad.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 455);
            this.panel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.TabControlMenu;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // TabControlMenu
            // 
            this.TabControlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTab,
            this.DeleteTab,
            this.toolStripSeparator8,
            this.EditTab});
            this.TabControlMenu.Name = "contextMenuStrip1";
            this.TabControlMenu.Size = new System.Drawing.Size(175, 76);
            // 
            // AddTab
            // 
            this.AddTab.Name = "AddTab";
            this.AddTab.Size = new System.Drawing.Size(174, 22);
            this.AddTab.Text = "Добавить вкладку";
            this.AddTab.Click += new System.EventHandler(this.AddTab_Click);
            // 
            // DeleteTab
            // 
            this.DeleteTab.Name = "DeleteTab";
            this.DeleteTab.Size = new System.Drawing.Size(174, 22);
            this.DeleteTab.Text = "Удалить вкладку";
            this.DeleteTab.Click += new System.EventHandler(this.DeleteTab_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(171, 6);
            // 
            // EditTab
            // 
            this.EditTab.Name = "EditTab";
            this.EditTab.Size = new System.Drawing.Size(174, 22);
            this.EditTab.Text = "Изменить вкладку";
            this.EditTab.Click += new System.EventHandler(this.EditTab_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.wefToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(173, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "Добавить вкладку";
            // 
            // wefToolStripMenuItem
            // 
            this.wefToolStripMenuItem.Name = "wefToolStripMenuItem";
            this.wefToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.wefToolStripMenuItem.Text = "wef";
            // 
            // информацияОбОбновленииToolStripMenuItem
            // 
            this.информацияОбОбновленииToolStripMenuItem.Name = "информацияОбОбновленииToolStripMenuItem";
            this.информацияОбОбновленииToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.информацияОбОбновленииToolStripMenuItem.Text = "Информация об обновлении";
            // 
            // dnevnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.Status);
            this.Name = "dnevnik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дневник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dnevnik_FormClosing);
            this.Shown += new System.EventHandler(this.Dnevnik_Shown);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.TabControlMenu.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton operateFile;
        private System.Windows.Forms.ToolStripDropDownButton actionsDownList;
        private System.Windows.Forms.ToolStripMenuItem genMarksCriteria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem добавитьОценкиИзБуфераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMarksInDnevnik;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem upRowButton;
        private System.Windows.Forms.ToolStripMenuItem downRowButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem addRowButton;
        private System.Windows.Forms.ToolStripMenuItem deleteRowButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem addColumnButton;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem clearCell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem clearTable;
        private System.Windows.Forms.ToolStripDropDownButton mainList;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem settingsButtonTool;
        private System.Windows.Forms.ToolStripMenuItem обновлениеПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar loadBar;
        private System.Windows.Forms.ToolStripStatusLabel LabelLoad;
        private System.ComponentModel.BackgroundWorker WorkBack;
        private System.Windows.Forms.ContextMenuStrip TabControlMenu;
        private System.Windows.Forms.ToolStripMenuItem AddTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wefToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem EditTab;
        private System.Windows.Forms.ToolStripMenuItem информацияОбОбновленииToolStripMenuItem;
    }
}

