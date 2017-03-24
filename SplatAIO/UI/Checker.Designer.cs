namespace SplatAIO.UI
{
    partial class Checker
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
            this.updateBox = new System.Windows.Forms.TextBox();
            this.githubButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "A new update has been detected!";
            // 
            // updateBox
            // 
            this.updateBox.Location = new System.Drawing.Point(13, 30);
            this.updateBox.Multiline = true;
            this.updateBox.Name = "updateBox";
            this.updateBox.ReadOnly = true;
            this.updateBox.Size = new System.Drawing.Size(296, 299);
            this.updateBox.TabIndex = 1;
            this.updateBox.Text = "Loading...";
            // 
            // githubButton
            // 
            this.githubButton.Location = new System.Drawing.Point(12, 336);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(138, 23);
            this.githubButton.TabIndex = 0;
            this.githubButton.Text = "Take Me to GitHub";
            this.githubButton.UseVisualStyleBackColor = true;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(171, 336);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(138, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Checker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 366);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.githubButton);
            this.Controls.Add(this.updateBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Checker";
            this.Text = "Super Special Update Window";
            this.Load += new System.EventHandler(this.Update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox updateBox;
        private System.Windows.Forms.Button githubButton;
        private System.Windows.Forms.Button closeButton;
    }
}