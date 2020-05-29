namespace Dnevnik
{
    partial class SelectDataChildren
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
            this.ChilldrenSelect = new System.Windows.Forms.GroupBox();
            this.Childrens = new System.Windows.Forms.ComboBox();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.studyYear = new System.Windows.Forms.ComboBox();
            this.SelectPeriod = new System.Windows.Forms.ComboBox();
            this.TypeYearList = new System.Windows.Forms.ComboBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.schoolmates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChilldrenSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChilldrenSelect
            // 
            this.ChilldrenSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChilldrenSelect.Controls.Add(this.label2);
            this.ChilldrenSelect.Controls.Add(this.label1);
            this.ChilldrenSelect.Controls.Add(this.schoolmates);
            this.ChilldrenSelect.Controls.Add(this.Childrens);
            this.ChilldrenSelect.Location = new System.Drawing.Point(12, 12);
            this.ChilldrenSelect.Name = "ChilldrenSelect";
            this.ChilldrenSelect.Size = new System.Drawing.Size(202, 100);
            this.ChilldrenSelect.TabIndex = 0;
            this.ChilldrenSelect.TabStop = false;
            this.ChilldrenSelect.Text = "Учащийся(еся)";
            // 
            // Childrens
            // 
            this.Childrens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Childrens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Childrens.FormattingEnabled = true;
            this.Childrens.Location = new System.Drawing.Point(6, 31);
            this.Childrens.Name = "Childrens";
            this.Childrens.Size = new System.Drawing.Size(190, 21);
            this.Childrens.TabIndex = 0;
            this.Childrens.SelectedIndexChanged += new System.EventHandler(this.Childrens_SelectedIndexChanged);
            // 
            // StartDate
            // 
            this.StartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartDate.Location = new System.Drawing.Point(6, 73);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(190, 20);
            this.StartDate.TabIndex = 1;
            // 
            // EndDate
            // 
            this.EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EndDate.Location = new System.Drawing.Point(6, 99);
            this.EndDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(190, 20);
            this.EndDate.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.studyYear);
            this.groupBox1.Controls.Add(this.SelectPeriod);
            this.groupBox1.Controls.Add(this.TypeYearList);
            this.groupBox1.Controls.Add(this.StartDate);
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период";
            // 
            // studyYear
            // 
            this.studyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studyYear.FormattingEnabled = true;
            this.studyYear.Location = new System.Drawing.Point(6, 19);
            this.studyYear.Name = "studyYear";
            this.studyYear.Size = new System.Drawing.Size(190, 21);
            this.studyYear.TabIndex = 5;
            this.studyYear.SelectedIndexChanged += new System.EventHandler(this.StudyYear_SelectedIndexChanged);
            // 
            // SelectPeriod
            // 
            this.SelectPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectPeriod.FormattingEnabled = true;
            this.SelectPeriod.Items.AddRange(new object[] {
            "Четверть",
            "Триместр",
            "Семестр",
            "Другое"});
            this.SelectPeriod.Location = new System.Drawing.Point(107, 46);
            this.SelectPeriod.Name = "SelectPeriod";
            this.SelectPeriod.Size = new System.Drawing.Size(89, 21);
            this.SelectPeriod.TabIndex = 4;
            this.SelectPeriod.SelectedIndexChanged += new System.EventHandler(this.SelectPeriod_SelectedIndexChanged);
            // 
            // TypeYearList
            // 
            this.TypeYearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TypeYearList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeYearList.FormattingEnabled = true;
            this.TypeYearList.Items.AddRange(new object[] {
            "Четверть",
            "Триместр",
            "Семестр",
            "Другое"});
            this.TypeYearList.Location = new System.Drawing.Point(6, 46);
            this.TypeYearList.Name = "TypeYearList";
            this.TypeYearList.Size = new System.Drawing.Size(95, 21);
            this.TypeYearList.TabIndex = 3;
            this.TypeYearList.SelectedIndexChanged += new System.EventHandler(this.TimetableList_SelectedIndexChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(12, 249);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(202, 25);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Получить оценки";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // schoolmates
            // 
            this.schoolmates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.schoolmates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schoolmates.FormattingEnabled = true;
            this.schoolmates.Location = new System.Drawing.Point(6, 71);
            this.schoolmates.Name = "schoolmates";
            this.schoolmates.Size = new System.Drawing.Size(190, 21);
            this.schoolmates.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Учащийся:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Учебная группа ученика:";
            // 
            // SelectDataChildren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 286);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChilldrenSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectDataChildren";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор критериев";
            this.Shown += new System.EventHandler(this.SelectDataChildren_Shown);
            this.ChilldrenSelect.ResumeLayout(false);
            this.ChilldrenSelect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChilldrenSelect;
        private System.Windows.Forms.ComboBox Childrens;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox SelectPeriod;
        private System.Windows.Forms.ComboBox TypeYearList;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.DateTimePicker StartDate;
        public System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.ComboBox studyYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox schoolmates;
        private System.Windows.Forms.Label label2;
    }
}