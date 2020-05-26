namespace Dnevnik
{
    partial class SortData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortData));
            this.sortTool = new System.Windows.Forms.ToolStrip();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.resetSort = new System.Windows.Forms.ToolStripButton();
            this.averageBallTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.ballOtTool = new System.Windows.Forms.ToolStripComboBox();
            this.ballDoTool = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.weightBall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameLess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ballOt = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ballDo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sortTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // sortTool
            // 
            this.sortTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectButton,
            this.resetSort,
            this.averageBallTool});
            this.sortTool.Location = new System.Drawing.Point(0, 0);
            this.sortTool.Name = "sortTool";
            this.sortTool.Size = new System.Drawing.Size(849, 25);
            this.sortTool.TabIndex = 0;
            this.sortTool.Text = "toolStrip1";
            // 
            // selectButton
            // 
            this.selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(87, 22);
            this.selectButton.Text = "Генерировать";
            this.selectButton.ToolTipText = "Закончить выбор критериев";
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // resetSort
            // 
            this.resetSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetSort.Image = ((System.Drawing.Image)(resources.GetObject("resetSort.Image")));
            this.resetSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetSort.Name = "resetSort";
            this.resetSort.Size = new System.Drawing.Size(46, 22);
            this.resetSort.Text = "Сброс";
            this.resetSort.ToolTipText = "Сброс критериев";
            this.resetSort.Click += new System.EventHandler(this.resetSort_Click);
            // 
            // averageBallTool
            // 
            this.averageBallTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.averageBallTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ballOtTool,
            this.ballDoTool});
            this.averageBallTool.Image = ((System.Drawing.Image)(resources.GetObject("averageBallTool.Image")));
            this.averageBallTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.averageBallTool.Name = "averageBallTool";
            this.averageBallTool.Size = new System.Drawing.Size(98, 22);
            this.averageBallTool.Text = "Средний балл";
            // 
            // ballOtTool
            // 
            this.ballOtTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ballOtTool.Items.AddRange(new object[] {
            "2,0",
            "2,1",
            "2,2",
            "2,3",
            "2,4",
            "2,5",
            "2,6",
            "2,7",
            "2,8",
            "2,9",
            "3,0",
            "3,1",
            "3,2",
            "3,3",
            "3,4",
            "3,5",
            "3,6",
            "3,7",
            "3,8",
            "3,9",
            "4,0",
            "4,1",
            "4,2",
            "4,3",
            "4,4",
            "4,5",
            "4,6",
            "4,7",
            "4,8",
            "4,9",
            "5,0"});
            this.ballOtTool.Name = "ballOtTool";
            this.ballOtTool.Size = new System.Drawing.Size(121, 23);
            // 
            // ballDoTool
            // 
            this.ballDoTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ballDoTool.Items.AddRange(new object[] {
            "5,0",
            "4,9",
            "4,8",
            "4,7",
            "4,6",
            "4,5",
            "4,4",
            "4,3",
            "4,2",
            "4,1",
            "4,0",
            "3,9",
            "3,8",
            "3,7",
            "3,6",
            "3,5",
            "3,4",
            "3,2",
            "3,1",
            "3,0",
            "2,9",
            "2,8",
            "2,7",
            "2,6",
            "2,5",
            "2,4",
            "2,3",
            "2,2",
            "2,1"});
            this.ballDoTool.Name = "ballDoTool";
            this.ballDoTool.Size = new System.Drawing.Size(121, 23);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(849, 562);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество работ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weightBall,
            this.nameLess,
            this.count});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // weightBall
            // 
            this.weightBall.HeaderText = "Вес";
            this.weightBall.Name = "weightBall";
            this.weightBall.ReadOnly = true;
            this.weightBall.Width = 50;
            // 
            // nameLess
            // 
            this.nameLess.HeaderText = "Имя";
            this.nameLess.Name = "nameLess";
            this.nameLess.ReadOnly = true;
            this.nameLess.Width = 650;
            // 
            // count
            // 
            this.count.HeaderText = "Количество";
            this.count.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.count.Name = "count";
            this.count.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 306);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Индивидуальная сложность";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weight,
            this.name,
            this.ballOt,
            this.ballDo});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(843, 287);
            this.dataGridView2.TabIndex = 0;
            // 
            // weight
            // 
            this.weight.HeaderText = "Вес";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 550;
            // 
            // ballOt
            // 
            this.ballOt.HeaderText = "Балл от";
            this.ballOt.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.ballOt.Name = "ballOt";
            this.ballOt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ballOt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ballDo
            // 
            this.ballDo.HeaderText = "Балл до";
            this.ballDo.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.ballDo.Name = "ballDo";
            this.ballDo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ballDo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sortData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 587);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sortTool);
            this.Name = "sortData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sortData";
            this.Shown += new System.EventHandler(this.sortData_Shown);
            this.sortTool.ResumeLayout(false);
            this.sortTool.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip sortTool;
        private System.Windows.Forms.ToolStripButton resetSort;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton selectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightBall;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameLess;
        private System.Windows.Forms.DataGridViewComboBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn ballOt;
        private System.Windows.Forms.DataGridViewComboBoxColumn ballDo;
        private System.Windows.Forms.ToolStripDropDownButton averageBallTool;
        private System.Windows.Forms.ToolStripComboBox ballOtTool;
        private System.Windows.Forms.ToolStripComboBox ballDoTool;
    }
}