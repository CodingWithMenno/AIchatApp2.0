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
            this.SuspendLayout();
            // 
            // buttonToGUI
            // 
            this.buttonToGUI.Location = new System.Drawing.Point(377, 196);
            this.buttonToGUI.Name = "buttonToGUI";
            this.buttonToGUI.Size = new System.Drawing.Size(94, 29);
            this.buttonToGUI.TabIndex = 0;
            this.buttonToGUI.Text = "Login";
            this.buttonToGUI.UseVisualStyleBackColor = true;
            this.buttonToGUI.Click += new System.EventHandler(this.buttonToGUI_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(246, 198);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(125, 27);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonToGUI);
            this.Name = "Login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToGUI;
        private System.Windows.Forms.TextBox textBoxUserName;
    }
}

