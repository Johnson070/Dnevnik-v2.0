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
            this.SelectPeriod = new System.Windows.Forms.ComboBox();
            this.TypeYearList = new System.Windows.Forms.ComboBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.studyYear = new System.Windows.Forms.ComboBox();
            this.ChilldrenSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChilldrenSelect
            // 
            this.ChilldrenSelect.Controls.Add(this.Childrens);
            this.ChilldrenSelect.Location = new System.Drawing.Point(12, 12);
            this.ChilldrenSelect.Name = "ChilldrenSelect";
            this.ChilldrenSelect.Size = new System.Drawing.Size(202, 55);
            this.ChilldrenSelect.TabIndex = 0;
            this.ChilldrenSelect.TabStop = false;
            this.ChilldrenSelect.Text = "Учащийся(еся)";
            // 
            // Childrens
            // 
            this.Childrens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Childrens.FormattingEnabled = true;
            this.Childrens.Location = new System.Drawing.Point(6, 19);
            this.Childrens.Name = "Childrens";
            this.Childrens.Size = new System.Drawing.Size(190, 21);
            this.Childrens.TabIndex = 0;
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.studyYear);
            this.groupBox1.Controls.Add(this.SelectPeriod);
            this.groupBox1.Controls.Add(this.TypeYearList);
            this.groupBox1.Controls.Add(this.StartDate);
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период";
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
            this.CloseButton.Location = new System.Drawing.Point(12, 204);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(202, 25);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Получить оценки";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
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
            // SelectDataChildren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 241);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChilldrenSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectDataChildren";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор критериев";
            this.Shown += new System.EventHandler(this.SelectDataChildren_Shown);
            this.ChilldrenSelect.ResumeLayout(false);
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
    }
}