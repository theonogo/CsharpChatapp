namespace ClientGUIApp
{
    partial class AuthForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.LogButton = new System.Windows.Forms.Button();
            this.SignButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserBox
            // 
            this.UserBox.Location = new System.Drawing.Point(100, 31);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(143, 20);
            this.UserBox.TabIndex = 0;
            // 
            // UserLabel
            // 
            this.UserLabel.Location = new System.Drawing.Point(25, 31);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(69, 18);
            this.UserLabel.TabIndex = 1;
            this.UserLabel.Text = "Username:";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PassLabel
            // 
            this.PassLabel.Location = new System.Drawing.Point(31, 58);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(63, 19);
            this.PassLabel.TabIndex = 2;
            this.PassLabel.Text = "Password:";
            this.PassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(100, 58);
            this.PassBox.Name = "PassBox";
            this.PassBox.PasswordChar = '*';
            this.PassBox.Size = new System.Drawing.Size(143, 20);
            this.PassBox.TabIndex = 0;
            // 
            // LogButton
            // 
            this.LogButton.Location = new System.Drawing.Point(60, 116);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(74, 24);
            this.LogButton.TabIndex = 3;
            this.LogButton.Text = "Log In";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogClick);
            // 
            // SignButton
            // 
            this.SignButton.Location = new System.Drawing.Point(140, 116);
            this.SignButton.Name = "SignButton";
            this.SignButton.Size = new System.Drawing.Size(74, 24);
            this.SignButton.TabIndex = 3;
            this.SignButton.Text = "Sign Up";
            this.SignButton.UseVisualStyleBackColor = true;
            this.SignButton.Click += new System.EventHandler(this.SignClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Location = new System.Drawing.Point(31, 87);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(212, 26);
            this.InfoLabel.TabIndex = 4;
            this.InfoLabel.Text = "Enter user info";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 161);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.SignButton);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.UserBox);
            this.Name = "AuthForm";
            this.Text = "Authentication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label InfoLabel;

        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Button SignButton;
        private System.Windows.Forms.TextBox UserBox;

        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label UserLabel;

        #endregion
    }
}