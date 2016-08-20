namespace SplatAIO
{
    partial class TimerHaxForm
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
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(TimerHaxForm));
            this.BattleDojoRadioButton = new System.Windows.Forms.RadioButton();
            this.ReconRadioButton = new System.Windows.Forms.RadioButton();
            this.AmiiboRadioButton = new System.Windows.Forms.RadioButton();
            this.TimerBox = new System.Windows.Forms.NumericUpDown();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.ControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.FreezeCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimerBox)).BeginInit();
            this.ControlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BattleDojoRadioButton
            // 
            this.BattleDojoRadioButton.AutoSize = true;
            this.BattleDojoRadioButton.Location = new System.Drawing.Point(12, 18);
            this.BattleDojoRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BattleDojoRadioButton.Name = "BattleDojoRadioButton";
            this.BattleDojoRadioButton.Size = new System.Drawing.Size(77, 17);
            this.BattleDojoRadioButton.TabIndex = 0;
            this.BattleDojoRadioButton.TabStop = true;
            this.BattleDojoRadioButton.Text = "Battle Dojo";
            this.BattleDojoRadioButton.UseVisualStyleBackColor = true;
            // 
            // ReconRadioButton
            // 
            this.ReconRadioButton.AutoSize = true;
            this.ReconRadioButton.Location = new System.Drawing.Point(12, 36);
            this.ReconRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReconRadioButton.Name = "ReconRadioButton";
            this.ReconRadioButton.Size = new System.Drawing.Size(57, 17);
            this.ReconRadioButton.TabIndex = 1;
            this.ReconRadioButton.TabStop = true;
            this.ReconRadioButton.Text = "Recon";
            this.ReconRadioButton.UseVisualStyleBackColor = true;
            // 
            // AmiiboRadioButton
            // 
            this.AmiiboRadioButton.AutoSize = true;
            this.AmiiboRadioButton.Location = new System.Drawing.Point(12, 55);
            this.AmiiboRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AmiiboRadioButton.Name = "AmiiboRadioButton";
            this.AmiiboRadioButton.Size = new System.Drawing.Size(140, 17);
            this.AmiiboRadioButton.TabIndex = 2;
            this.AmiiboRadioButton.TabStop = true;
            this.AmiiboRadioButton.Text = "amiibo Squid Challenges";
            this.AmiiboRadioButton.UseVisualStyleBackColor = true;
            // 
            // TimerBox
            // 
            this.TimerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerBox.Location = new System.Drawing.Point(156, 30);
            this.TimerBox.Maximum = new decimal(new int[] {
            6039,
            0,
            0,
            0});
            this.TimerBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimerBox.Name = "TimerBox";
            this.TimerBox.Size = new System.Drawing.Size(111, 19);
            this.TimerBox.TabIndex = 7;
            this.TimerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimerBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ApplyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ApplyButton.Location = new System.Drawing.Point(6, 90);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(276, 35);
            this.ApplyButton.TabIndex = 14;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(153, 14);
            this.TimerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(63, 13);
            this.TimerLabel.TabIndex = 15;
            this.TimerLabel.Text = "Set timer to:";
            // 
            // ControlsGroupBox
            // 
            this.ControlsGroupBox.Controls.Add(this.FreezeCheckBox);
            this.ControlsGroupBox.Controls.Add(this.ReconRadioButton);
            this.ControlsGroupBox.Controls.Add(this.TimerLabel);
            this.ControlsGroupBox.Controls.Add(this.BattleDojoRadioButton);
            this.ControlsGroupBox.Controls.Add(this.AmiiboRadioButton);
            this.ControlsGroupBox.Controls.Add(this.TimerBox);
            this.ControlsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ControlsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlsGroupBox.Name = "ControlsGroupBox";
            this.ControlsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlsGroupBox.Size = new System.Drawing.Size(278, 79);
            this.ControlsGroupBox.TabIndex = 16;
            this.ControlsGroupBox.TabStop = false;
            this.ControlsGroupBox.Text = "Controls";
            // 
            // FreezeCheckBox
            // 
            this.FreezeCheckBox.AutoSize = true;
            this.FreezeCheckBox.Location = new System.Drawing.Point(156, 55);
            this.FreezeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FreezeCheckBox.Name = "FreezeCheckBox";
            this.FreezeCheckBox.Size = new System.Drawing.Size(87, 17);
            this.FreezeCheckBox.TabIndex = 16;
            this.FreezeCheckBox.Text = "Freeze Timer";
            this.FreezeCheckBox.UseVisualStyleBackColor = true;
            this.FreezeCheckBox.CheckedChanged += new System.EventHandler(this.FreezeCheckBox_CheckedChanged);
            // 
            // TimerHaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(289, 135);
            this.Controls.Add(this.ControlsGroupBox);
            this.Controls.Add(this.ApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TimerHaxForm";
            this.Text = "TimerHax";
            ((System.ComponentModel.ISupportInitialize)(this.TimerBox)).EndInit();
            this.ControlsGroupBox.ResumeLayout(false);
            this.ControlsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton BattleDojoRadioButton;
        private System.Windows.Forms.RadioButton ReconRadioButton;
        private System.Windows.Forms.RadioButton AmiiboRadioButton;
        private System.Windows.Forms.NumericUpDown TimerBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.GroupBox ControlsGroupBox;
        private System.Windows.Forms.CheckBox FreezeCheckBox;
    }
}