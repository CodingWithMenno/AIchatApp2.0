namespace AI_ChatApp2._0
{
    partial class GUI
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
            this.buttonSendChat = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.textBoxSendChat = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxUsersBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSendChat
            // 
            this.buttonSendChat.Location = new System.Drawing.Point(428, 303);
            this.buttonSendChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendChat.Name = "buttonSendChat";
            this.buttonSendChat.Size = new System.Drawing.Size(82, 24);
            this.buttonSendChat.TabIndex = 0;
            this.buttonSendChat.Text = "Send";
            this.buttonSendChat.UseVisualStyleBackColor = true;
            this.buttonSendChat.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 8);
            this.textBoxMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.Size = new System.Drawing.Size(498, 291);
            this.textBoxMessages.TabIndex = 1;
            // 
            // textBoxSendChat
            // 
            this.textBoxSendChat.Location = new System.Drawing.Point(12, 304);
            this.textBoxSendChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSendChat.Name = "textBoxSendChat";
            this.textBoxSendChat.Size = new System.Drawing.Size(411, 23);
            this.textBoxSendChat.TabIndex = 2;
            this.textBoxSendChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSendChat_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(529, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(161, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Connected Users";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUsersBox
            // 
            this.textBoxUsersBox.Location = new System.Drawing.Point(529, 37);
            this.textBoxUsersBox.Multiline = true;
            this.textBoxUsersBox.Name = "textBoxUsersBox";
            this.textBoxUsersBox.ReadOnly = true;
            this.textBoxUsersBox.Size = new System.Drawing.Size(161, 263);
            this.textBoxUsersBox.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(575, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 4;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 328);
            this.Controls.Add(this.textBoxUsersBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxSendChat);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.buttonSendChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GUI";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSendChat;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox textBoxSendChat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxUsersBox;
        private System.Windows.Forms.TextBox textBox2;
    }
}