namespace Dnevnik
{
    partial class MarksSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarksSelect));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectMarksTable = new System.Windows.Forms.DataGridView();
            this.selectMarksButton = new System.Windows.Forms.ToolStripButton();
            this.sortTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.upSort = new System.Windows.Forms.ToolStripMenuItem();
            this.downSort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectMarksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMarksButton,
            this.sortTool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectMarksTable
            // 
            this.selectMarksTable.AllowUserToAddRows = false;
            this.selectMarksTable.AllowUserToDeleteRows = false;
            this.selectMarksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectMarksTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectMarksTable.Location = new System.Drawing.Point(0, 25);
            this.selectMarksTable.Name = "selectMarksTable";
            this.selectMarksTable.Size = new System.Drawing.Size(800, 425);
            this.selectMarksTable.TabIndex = 1;
            // 
            // selectMarksButton
            // 
            this.selectMarksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectMarksButton.Image = ((System.Drawing.Image)(resources.GetObject("selectMarksButton.Image")));
            this.selectMarksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectMarksButton.Name = "selectMarksButton";
            this.selectMarksButton.Size = new System.Drawing.Size(58, 22);
            this.selectMarksButton.Text = "Выбрать";
            this.selectMarksButton.Click += new System.EventHandler(this.selectMarksButton_Click);
            // 
            // sortTool
            // 
            this.sortTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sortTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upSort,
            this.downSort});
            this.sortTool.Image = ((System.Drawing.Image)(resources.GetObject("sortTool.Image")));
            this.sortTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortTool.Name = "sortTool";
            this.sortTool.Size = new System.Drawing.Size(86, 22);
            this.sortTool.Text = "Сортировка";
            this.sortTool.ToolTipText = "Выбор типа сортировки";
            // 
            // upSort
            // 
            this.upSort.Name = "upSort";
            this.upSort.Size = new System.Drawing.Size(180, 22);
            this.upSort.Text = "По возрастанию";
            this.upSort.Click += new System.EventHandler(this.upSort_Click);
            // 
            // downSort
            // 
            this.downSort.Name = "downSort";
            this.downSort.Size = new System.Drawing.Size(180, 22);
            this.downSort.Text = "По убыванию";
            this.downSort.Click += new System.EventHandler(this.downSort_Click);
            // 
            // marksSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectMarksTable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "marksSelect";
            this.Text = "marksSelect";
            this.Shown += new System.EventHandler(this.marksSelect_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectMarksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton selectMarksButton;
        private System.Windows.Forms.DataGridView selectMarksTable;
        private System.Windows.Forms.ToolStripDropDownButton sortTool;
        private System.Windows.Forms.ToolStripMenuItem upSort;
        private System.Windows.Forms.ToolStripMenuItem downSort;
    }
}