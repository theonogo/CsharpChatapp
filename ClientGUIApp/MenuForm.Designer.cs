using System.ComponentModel;

namespace ClientGUIApp
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ListTopics = new System.Windows.Forms.ListBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NewTopicBox = new System.Windows.Forms.TextBox();
            this.AddTopicButton = new System.Windows.Forms.Button();
            this.TopicsLabel = new System.Windows.Forms.Label();
            this.MessagesLabel = new System.Windows.Forms.Label();
            this.NewTopicLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.DMBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DMLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(381, 262);
            this.textBox1.TabIndex = 0;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(228, 342);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(315, 20);
            this.MessageBox.TabIndex = 1;
            // 
            // ListTopics
            // 
            this.ListTopics.FormattingEnabled = true;
            this.ListTopics.Location = new System.Drawing.Point(17, 46);
            this.ListTopics.Name = "ListTopics";
            this.ListTopics.Size = new System.Drawing.Size(182, 264);
            this.ListTopics.TabIndex = 2;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(549, 342);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(61, 20);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendMessage);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(114, 21);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(85, 22);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshClick);
            // 
            // NewTopicBox
            // 
            this.NewTopicBox.Location = new System.Drawing.Point(17, 342);
            this.NewTopicBox.Name = "NewTopicBox";
            this.NewTopicBox.Size = new System.Drawing.Size(119, 20);
            this.NewTopicBox.TabIndex = 5;
            // 
            // AddTopicButton
            // 
            this.AddTopicButton.Location = new System.Drawing.Point(142, 342);
            this.AddTopicButton.Name = "AddTopicButton";
            this.AddTopicButton.Size = new System.Drawing.Size(57, 20);
            this.AddTopicButton.TabIndex = 6;
            this.AddTopicButton.Text = "Add";
            this.AddTopicButton.UseVisualStyleBackColor = true;
            this.AddTopicButton.Click += new System.EventHandler(this.AddTopic);
            // 
            // TopicsLabel
            // 
            this.TopicsLabel.Location = new System.Drawing.Point(17, 24);
            this.TopicsLabel.Name = "TopicsLabel";
            this.TopicsLabel.Size = new System.Drawing.Size(89, 19);
            this.TopicsLabel.TabIndex = 9;
            this.TopicsLabel.Text = "Topics:";
            // 
            // MessagesLabel
            // 
            this.MessagesLabel.Location = new System.Drawing.Point(228, 24);
            this.MessagesLabel.Name = "MessagesLabel";
            this.MessagesLabel.Size = new System.Drawing.Size(93, 19);
            this.MessagesLabel.TabIndex = 10;
            this.MessagesLabel.Text = "Topic Messages:";
            // 
            // NewTopicLabel
            // 
            this.NewTopicLabel.Location = new System.Drawing.Point(17, 322);
            this.NewTopicLabel.Name = "NewTopicLabel";
            this.NewTopicLabel.Size = new System.Drawing.Size(120, 17);
            this.NewTopicLabel.TabIndex = 11;
            this.NewTopicLabel.Text = "New Topic:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(756, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "To:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(787, 370);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(166, 20);
            this.textBox4.TabIndex = 13;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(229, 322);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(113, 16);
            this.MessageLabel.TabIndex = 14;
            this.MessageLabel.Text = "New Topic Message:";
            // 
            // DMBox
            // 
            this.DMBox.Location = new System.Drawing.Point(667, 48);
            this.DMBox.Multiline = true;
            this.DMBox.Name = "DMBox";
            this.DMBox.ReadOnly = true;
            this.DMBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DMBox.Size = new System.Drawing.Size(352, 262);
            this.DMBox.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(666, 344);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(287, 20);
            this.textBox3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(966, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendDirectMessage);
            // 
            // DMLabel
            // 
            this.DMLabel.Location = new System.Drawing.Point(667, 26);
            this.DMLabel.Name = "DMLabel";
            this.DMLabel.Size = new System.Drawing.Size(118, 19);
            this.DMLabel.TabIndex = 10;
            this.DMLabel.Text = "Direct Messages:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(667, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "New Direct Message:";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 445);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NewTopicLabel);
            this.Controls.Add(this.DMLabel);
            this.Controls.Add(this.MessagesLabel);
            this.Controls.Add(this.TopicsLabel);
            this.Controls.Add(this.AddTopicButton);
            this.Controls.Add(this.NewTopicBox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ListTopics);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.DMBox);
            this.Controls.Add(this.textBox1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DMBox;
        private System.Windows.Forms.Label DMLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button SendButton;

        private System.Windows.Forms.Button AddTopicButton;
        private System.Windows.Forms.Label MessagesLabel;
        private System.Windows.Forms.TextBox NewTopicBox;
        private System.Windows.Forms.Label NewTopicLabel;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ListTopics;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label TopicsLabel;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}