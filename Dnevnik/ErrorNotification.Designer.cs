namespace Dnevnik
{
    partial class ErrorNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorNotification));
            this.mailHeader = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.sendMail = new System.Windows.Forms.Button();
            this.attachments = new System.Windows.Forms.ComboBox();
            this.addDrop = new System.Windows.Forms.Button();
            this.removeDrop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fromEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mailHeader
            // 
            this.mailHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mailHeader.Location = new System.Drawing.Point(15, 69);
            this.mailHeader.Name = "mailHeader";
            this.mailHeader.Size = new System.Drawing.Size(492, 20);
            this.mailHeader.TabIndex = 0;
            this.mailHeader.Tag = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тема:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сообщение:";
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.ForeColor = System.Drawing.Color.Gray;
            this.message.Location = new System.Drawing.Point(15, 124);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(492, 218);
            this.message.TabIndex = 3;
            this.message.Text = "Постарайтесь здесь подробно описать ошибку или проблему которая возникла у Вас пр" +
    "и работе программы. Или напишите здесь ваши пожелания и комментарии...";
            this.message.Enter += new System.EventHandler(this.MessageTextEnter);
            this.message.Leave += new System.EventHandler(this.MessageTextLeave);
            // 
            // sendMail
            // 
            this.sendMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMail.Location = new System.Drawing.Point(15, 398);
            this.sendMail.Name = "sendMail";
            this.sendMail.Size = new System.Drawing.Size(492, 57);
            this.sendMail.TabIndex = 5;
            this.sendMail.Text = "Отправить";
            this.sendMail.UseVisualStyleBackColor = true;
            this.sendMail.Click += new System.EventHandler(this.SendMail);
            // 
            // attachments
            // 
            this.attachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachments.FormattingEnabled = true;
            this.attachments.Location = new System.Drawing.Point(15, 364);
            this.attachments.MaxDropDownItems = 10;
            this.attachments.Name = "attachments";
            this.attachments.Size = new System.Drawing.Size(293, 28);
            this.attachments.TabIndex = 6;
            // 
            // addDrop
            // 
            this.addDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDrop.Location = new System.Drawing.Point(314, 363);
            this.addDrop.Name = "addDrop";
            this.addDrop.Size = new System.Drawing.Size(96, 30);
            this.addDrop.TabIndex = 7;
            this.addDrop.Text = "Добавить";
            this.addDrop.UseVisualStyleBackColor = true;
            this.addDrop.Click += new System.EventHandler(this.AttackDocks);
            // 
            // removeDrop
            // 
            this.removeDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeDrop.Location = new System.Drawing.Point(416, 364);
            this.removeDrop.Name = "removeDrop";
            this.removeDrop.Size = new System.Drawing.Size(91, 29);
            this.removeDrop.TabIndex = 8;
            this.removeDrop.Text = "Удалить";
            this.removeDrop.UseVisualStyleBackColor = true;
            this.removeDrop.Click += new System.EventHandler(this.DeleteDocks);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Вложения:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email для ответа:";
            // 
            // fromEmail
            // 
            this.fromEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fromEmail.Location = new System.Drawing.Point(15, 27);
            this.fromEmail.Name = "fromEmail";
            this.fromEmail.Size = new System.Drawing.Size(492, 20);
            this.fromEmail.TabIndex = 10;
            this.fromEmail.Tag = "";
            // 
            // ErrorNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 467);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fromEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeDrop);
            this.Controls.Add(this.addDrop);
            this.Controls.Add(this.attachments);
            this.Controls.Add(this.sendMail);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(535, 506);
            this.Name = "ErrorNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправить письмо разработчику";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mailHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button sendMail;
        private System.Windows.Forms.ComboBox attachments;
        private System.Windows.Forms.Button addDrop;
        private System.Windows.Forms.Button removeDrop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fromEmail;
    }
}