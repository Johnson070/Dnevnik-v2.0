namespace Dnevnik
{
    partial class TabSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTab = new System.Windows.Forms.TextBox();
            this.TypeAverage = new System.Windows.Forms.RadioButton();
            this.TypeAverageMass = new System.Windows.Forms.RadioButton();
            this.CreateTab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя вкладки:";
            // 
            // NameTab
            // 
            this.NameTab.Location = new System.Drawing.Point(112, 8);
            this.NameTab.MaxLength = 20;
            this.NameTab.Name = "NameTab";
            this.NameTab.Size = new System.Drawing.Size(101, 20);
            this.NameTab.TabIndex = 1;
            this.NameTab.Text = "Вкладка";
            // 
            // TypeAverage
            // 
            this.TypeAverage.AutoSize = true;
            this.TypeAverage.Checked = true;
            this.TypeAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeAverage.Location = new System.Drawing.Point(12, 34);
            this.TypeAverage.Name = "TypeAverage";
            this.TypeAverage.Size = new System.Drawing.Size(118, 20);
            this.TypeAverage.TabIndex = 2;
            this.TypeAverage.TabStop = true;
            this.TypeAverage.Text = "Средний балл";
            this.TypeAverage.UseVisualStyleBackColor = true;
            // 
            // TypeAverageMass
            // 
            this.TypeAverageMass.AutoSize = true;
            this.TypeAverageMass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeAverageMass.Location = new System.Drawing.Point(12, 60);
            this.TypeAverageMass.Name = "TypeAverageMass";
            this.TypeAverageMass.Size = new System.Drawing.Size(203, 20);
            this.TypeAverageMass.TabIndex = 3;
            this.TypeAverageMass.Text = "Средний взвешенный балл";
            this.TypeAverageMass.UseVisualStyleBackColor = true;
            // 
            // CreateTab
            // 
            this.CreateTab.Location = new System.Drawing.Point(12, 86);
            this.CreateTab.Name = "CreateTab";
            this.CreateTab.Size = new System.Drawing.Size(201, 23);
            this.CreateTab.TabIndex = 5;
            this.CreateTab.Text = "Создать";
            this.CreateTab.UseVisualStyleBackColor = true;
            this.CreateTab.Click += new System.EventHandler(this.CreateTab_Click);
            // 
            // TabSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 119);
            this.Controls.Add(this.CreateTab);
            this.Controls.Add(this.TypeAverageMass);
            this.Controls.Add(this.TypeAverage);
            this.Controls.Add(this.NameTab);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TabSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка вкладки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTab;
        private System.Windows.Forms.RadioButton TypeAverage;
        private System.Windows.Forms.RadioButton TypeAverageMass;
        private System.Windows.Forms.Button CreateTab;
    }
}