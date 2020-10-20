namespace AI_ChatApp2._0
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonToGUI = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonToGUI
            // 
            this.buttonToGUI.Location = new System.Drawing.Point(280, 265);
            this.buttonToGUI.Name = "buttonToGUI";
            this.buttonToGUI.Size = new System.Drawing.Size(216, 35);
            this.buttonToGUI.TabIndex = 0;
            this.buttonToGUI.Text = "Login";
            this.buttonToGUI.UseVisualStyleBackColor = true;
            this.buttonToGUI.Click += new System.EventHandler(this.buttonToGUI_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(297, 160);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(181, 27);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(297, 213);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(181, 27);
            this.textBoxIPAddress.TabIndex = 2;
            this.textBoxIPAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIPAddress_KeyDown);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(350, 137);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(78, 20);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "UserName";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(350, 190);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(73, 20);
            this.labelIPAddress.TabIndex = 4;
            this.labelIPAddress.Text = "IPAddress";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonToGUI);
            this.Name = "Login";
            this.Text = "Login Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToGUI;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelIPAddress;
    }
}

