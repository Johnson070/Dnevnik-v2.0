namespace Dnevnik
{
    partial class LoginDnevnik
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
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.LabelLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.memberCred = new System.Windows.Forms.CheckBox();
            this.login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(63, 12);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(111, 20);
            this.UserName.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(63, 38);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(111, 20);
            this.Password.TabIndex = 1;
            this.Password.UseSystemPasswordChar = true;
            // 
            // LabelLogin
            // 
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Location = new System.Drawing.Point(12, 15);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(38, 13);
            this.LabelLogin.TabIndex = 2;
            this.LabelLogin.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Пароль";
            // 
            // memberCred
            // 
            this.memberCred.AutoSize = true;
            this.memberCred.Location = new System.Drawing.Point(12, 64);
            this.memberCred.Name = "memberCred";
            this.memberCred.Size = new System.Drawing.Size(108, 17);
            this.memberCred.TabIndex = 4;
            this.memberCred.Text = "Запомнить вход";
            this.memberCred.UseVisualStyleBackColor = true;
            this.memberCred.CheckedChanged += new System.EventHandler(this.memberCred_CheckedChanged);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(12, 87);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(162, 23);
            this.login.TabIndex = 5;
            this.login.Text = "Войти";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // LoginDnevnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 120);
            this.Controls.Add(this.login);
            this.Controls.Add(this.memberCred);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelLogin);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginDnevnik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox memberCred;
        private System.Windows.Forms.Button login;
    }
}