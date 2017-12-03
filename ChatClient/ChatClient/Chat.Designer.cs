namespace ChatClient
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.messageHistory = new System.Windows.Forms.ListBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.userList = new System.Windows.Forms.ListBox();
            this.usersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.приватToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВИгнорToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelRegister = new System.Windows.Forms.Label();
            this.loginField = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.chatUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.labelPassword = new System.Windows.Forms.Label();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.userUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.usersContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageHistory
            // 
            this.messageHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageHistory.FormattingEnabled = true;
            this.messageHistory.Location = new System.Drawing.Point(13, 13);
            this.messageHistory.Name = "messageHistory";
            this.messageHistory.Size = new System.Drawing.Size(923, 706);
            this.messageHistory.TabIndex = 0;
            // 
            // textMessage
            // 
            this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessage.Location = new System.Drawing.Point(12, 732);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(736, 20);
            this.textMessage.TabIndex = 1;
            this.textMessage.Visible = false;
            this.textMessage.TextChanged += new System.EventHandler(this.textMessage_TextChanged);
            this.textMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMessage_KeyDown);
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.ContextMenuStrip = this.usersContextMenu;
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(942, 13);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(182, 706);
            this.userList.TabIndex = 2;
            this.userList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userList_MouseDown);
            // 
            // usersContextMenu
            // 
            this.usersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приватToolStripMenuItem1,
            this.добавитьВИгнорToolStripMenuItem1});
            this.usersContextMenu.Name = "usersContextMenu";
            this.usersContextMenu.Size = new System.Drawing.Size(172, 48);
            // 
            // приватToolStripMenuItem1
            // 
            this.приватToolStripMenuItem1.Enabled = false;
            this.приватToolStripMenuItem1.Name = "приватToolStripMenuItem1";
            this.приватToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.приватToolStripMenuItem1.Text = "Приват";
            this.приватToolStripMenuItem1.Click += new System.EventHandler(this.приватToolStripMenuItem1_Click);
            // 
            // добавитьВИгнорToolStripMenuItem1
            // 
            this.добавитьВИгнорToolStripMenuItem1.Enabled = false;
            this.добавитьВИгнорToolStripMenuItem1.Name = "добавитьВИгнорToolStripMenuItem1";
            this.добавитьВИгнорToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.добавитьВИгнорToolStripMenuItem1.Text = "Добавить в игнор";
            this.добавитьВИгнорToolStripMenuItem1.Click += new System.EventHandler(this.добавитьВИгнорToolStripMenuItem1_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(754, 730);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(182, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Visible = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelRegister
            // 
            this.labelRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRegister.AutoSize = true;
            this.labelRegister.Location = new System.Drawing.Point(12, 735);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(75, 13);
            this.labelRegister.TabIndex = 4;
            this.labelRegister.Text = "Введите имя:";
            // 
            // loginField
            // 
            this.loginField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loginField.Location = new System.Drawing.Point(93, 732);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(276, 20);
            this.loginField.TabIndex = 5;
            this.loginField.TextChanged += new System.EventHandler(this.loginField_TextChanged);
            this.loginField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginField_KeyDown);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(754, 730);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(182, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Войти";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Location = new System.Drawing.Point(942, 730);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(182, 23);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Выйти";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Visible = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // chatUpdateTimer
            // 
            this.chatUpdateTimer.Enabled = true;
            this.chatUpdateTimer.Interval = 1000;
            this.chatUpdateTimer.Tick += new System.EventHandler(this.chatUpdateTimer_Tick);
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(375, 735);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(91, 13);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Введите пароль:";
            // 
            // passwordField
            // 
            this.passwordField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordField.Location = new System.Drawing.Point(472, 732);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(276, 20);
            this.passwordField.TabIndex = 9;
            this.passwordField.TextChanged += new System.EventHandler(this.passwordField_TextChanged);
            this.passwordField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordField_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(942, 730);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(182, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Закрыть";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // userUpdateTimer
            // 
            this.userUpdateTimer.Enabled = true;
            this.userUpdateTimer.Interval = 5000;
            this.userUpdateTimer.Tick += new System.EventHandler(this.userUpdateTimer_Tick);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 764);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.loginField);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.messageHistory);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.Text = "Онлайн-чат";
            this.usersContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox messageHistory;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Timer chatUpdateTimer;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip usersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem приватToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВИгнорToolStripMenuItem1;
        private System.Windows.Forms.Timer userUpdateTimer;
    }
}

