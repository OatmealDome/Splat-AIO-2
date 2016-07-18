namespace SplatAIO
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ipBox = new System.Windows.Forms.TextBox();
            this.connectBox = new System.Windows.Forms.Button();
            this.disconnectBox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sazaeBox = new System.Windows.Forms.NumericUpDown();
            this.maeBox = new System.Windows.Forms.NumericUpDown();
            this.kaneBox = new System.Windows.Forms.NumericUpDown();
            this.rankBox = new System.Windows.Forms.NumericUpDown();
            this.showStatsBox = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.udeBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.skinBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.eyeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.takoBox = new System.Windows.Forms.Button();
            this.ikaBox = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.normalBox = new System.Windows.Forms.Button();
            this.swapBox = new System.Windows.Forms.Button();
            this.hotaruBox = new System.Windows.Forms.Button();
            this.aoriBox = new System.Windows.Forms.Button();
            this.amiiboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gameButton = new System.Windows.Forms.Button();
            this.bukiButton = new System.Windows.Forms.Button();
            this.gearButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sazaeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(71, 23);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(105, 20);
            this.ipBox.TabIndex = 0;
            // 
            // connectBox
            // 
            this.connectBox.Location = new System.Drawing.Point(182, 23);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(58, 21);
            this.connectBox.TabIndex = 1;
            this.connectBox.Text = "Connect";
            this.connectBox.UseVisualStyleBackColor = true;
            this.connectBox.Click += new System.EventHandler(this.connectBox_Click);
            // 
            // disconnectBox
            // 
            this.disconnectBox.Enabled = false;
            this.disconnectBox.Location = new System.Drawing.Point(246, 23);
            this.disconnectBox.Name = "disconnectBox";
            this.disconnectBox.Size = new System.Drawing.Size(91, 21);
            this.disconnectBox.TabIndex = 2;
            this.disconnectBox.Text = "Disconnect";
            this.disconnectBox.UseVisualStyleBackColor = true;
            this.disconnectBox.Click += new System.EventHandler(this.disconnectBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sazaeBox);
            this.groupBox1.Controls.Add(this.maeBox);
            this.groupBox1.Controls.Add(this.kaneBox);
            this.groupBox1.Controls.Add(this.rankBox);
            this.groupBox1.Controls.Add(this.showStatsBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udeBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 150);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats";
            // 
            // sazaeBox
            // 
            this.sazaeBox.Enabled = false;
            this.sazaeBox.Location = new System.Drawing.Point(88, 68);
            this.sazaeBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.sazaeBox.Name = "sazaeBox";
            this.sazaeBox.Size = new System.Drawing.Size(69, 20);
            this.sazaeBox.TabIndex = 6;
            this.sazaeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // maeBox
            // 
            this.maeBox.Enabled = false;
            this.maeBox.Location = new System.Drawing.Point(117, 94);
            this.maeBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maeBox.Name = "maeBox";
            this.maeBox.Size = new System.Drawing.Size(40, 20);
            this.maeBox.TabIndex = 8;
            this.maeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kaneBox
            // 
            this.kaneBox.Enabled = false;
            this.kaneBox.Location = new System.Drawing.Point(88, 43);
            this.kaneBox.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.kaneBox.Name = "kaneBox";
            this.kaneBox.Size = new System.Drawing.Size(69, 20);
            this.kaneBox.TabIndex = 5;
            this.kaneBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rankBox
            // 
            this.rankBox.Enabled = false;
            this.rankBox.Location = new System.Drawing.Point(117, 17);
            this.rankBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.rankBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rankBox.Name = "rankBox";
            this.rankBox.Size = new System.Drawing.Size(40, 20);
            this.rankBox.TabIndex = 4;
            this.rankBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rankBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // showStatsBox
            // 
            this.showStatsBox.Enabled = false;
            this.showStatsBox.Location = new System.Drawing.Point(6, 122);
            this.showStatsBox.Name = "showStatsBox";
            this.showStatsBox.Size = new System.Drawing.Size(151, 23);
            this.showStatsBox.TabIndex = 9;
            this.showStatsBox.Text = "Enable All";
            this.showStatsBox.UseVisualStyleBackColor = true;
            this.showStatsBox.Click += new System.EventHandler(this.showStatsBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sea Snails";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Money";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level";
            // 
            // udeBox
            // 
            this.udeBox.Enabled = false;
            this.udeBox.FormattingEnabled = true;
            this.udeBox.Items.AddRange(new object[] {
            "C-",
            "C",
            "C+",
            "B-",
            "B",
            "B+",
            "A-",
            "A",
            "A+",
            "S",
            "S+"});
            this.udeBox.Location = new System.Drawing.Point(76, 94);
            this.udeBox.Name = "udeBox";
            this.udeBox.Size = new System.Drawing.Size(35, 21);
            this.udeBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.skinBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.eyeBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.genderBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 107);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player";
            // 
            // skinBox
            // 
            this.skinBox.Enabled = false;
            this.skinBox.FormattingEnabled = true;
            this.skinBox.Items.AddRange(new object[] {
            "1 - Lightest",
            "2",
            "3",
            "4",
            "5",
            "6 - Darkest"});
            this.skinBox.Location = new System.Drawing.Point(72, 74);
            this.skinBox.Name = "skinBox";
            this.skinBox.Size = new System.Drawing.Size(85, 21);
            this.skinBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Skin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Eyes";
            // 
            // eyeBox
            // 
            this.eyeBox.Enabled = false;
            this.eyeBox.FormattingEnabled = true;
            this.eyeBox.Items.AddRange(new object[] {
            "Black",
            "Brown",
            "Pink",
            "Orange",
            "Yellow",
            "Green",
            "Blue"});
            this.eyeBox.Location = new System.Drawing.Point(72, 47);
            this.eyeBox.Name = "eyeBox";
            this.eyeBox.Size = new System.Drawing.Size(85, 21);
            this.eyeBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Gender";
            // 
            // genderBox
            // 
            this.genderBox.Enabled = false;
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "Girl",
            "Boy",
            "Octoling"});
            this.genderBox.Location = new System.Drawing.Point(72, 19);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(85, 21);
            this.genderBox.TabIndex = 10;
            this.genderBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.takoBox);
            this.groupBox3.Controls.Add(this.ikaBox);
            this.groupBox3.Location = new System.Drawing.Point(181, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 88);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Octohax";
            // 
            // takoBox
            // 
            this.takoBox.Enabled = false;
            this.takoBox.Location = new System.Drawing.Point(10, 49);
            this.takoBox.Name = "takoBox";
            this.takoBox.Size = new System.Drawing.Size(146, 23);
            this.takoBox.TabIndex = 15;
            this.takoBox.Text = "Octopus ZL";
            this.takoBox.UseVisualStyleBackColor = true;
            this.takoBox.Click += new System.EventHandler(this.takoBox_Click);
            // 
            // ikaBox
            // 
            this.ikaBox.Enabled = false;
            this.ikaBox.Location = new System.Drawing.Point(10, 19);
            this.ikaBox.Name = "ikaBox";
            this.ikaBox.Size = new System.Drawing.Size(146, 23);
            this.ikaBox.TabIndex = 14;
            this.ikaBox.Text = "Squid ZL";
            this.ikaBox.UseVisualStyleBackColor = true;
            this.ikaBox.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.normalBox);
            this.groupBox4.Controls.Add(this.swapBox);
            this.groupBox4.Controls.Add(this.hotaruBox);
            this.groupBox4.Controls.Add(this.aoriBox);
            this.groupBox4.Location = new System.Drawing.Point(182, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 149);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sisterhax";
            // 
            // normalBox
            // 
            this.normalBox.Enabled = false;
            this.normalBox.Location = new System.Drawing.Point(6, 108);
            this.normalBox.Name = "normalBox";
            this.normalBox.Size = new System.Drawing.Size(150, 23);
            this.normalBox.TabIndex = 19;
            this.normalBox.Text = "Normalize";
            this.normalBox.UseVisualStyleBackColor = true;
            this.normalBox.Click += new System.EventHandler(this.button9_Click);
            // 
            // swapBox
            // 
            this.swapBox.Enabled = false;
            this.swapBox.Location = new System.Drawing.Point(7, 79);
            this.swapBox.Name = "swapBox";
            this.swapBox.Size = new System.Drawing.Size(149, 23);
            this.swapBox.TabIndex = 18;
            this.swapBox.Text = "Sister Swap";
            this.swapBox.UseVisualStyleBackColor = true;
            this.swapBox.Click += new System.EventHandler(this.swapBox_Click);
            // 
            // hotaruBox
            // 
            this.hotaruBox.Enabled = false;
            this.hotaruBox.Location = new System.Drawing.Point(7, 50);
            this.hotaruBox.Name = "hotaruBox";
            this.hotaruBox.Size = new System.Drawing.Size(149, 23);
            this.hotaruBox.TabIndex = 17;
            this.hotaruBox.Text = "Copy Marie";
            this.hotaruBox.UseVisualStyleBackColor = true;
            this.hotaruBox.Click += new System.EventHandler(this.hotaruBox_Click);
            // 
            // aoriBox
            // 
            this.aoriBox.Enabled = false;
            this.aoriBox.Location = new System.Drawing.Point(7, 20);
            this.aoriBox.Name = "aoriBox";
            this.aoriBox.Size = new System.Drawing.Size(149, 23);
            this.aoriBox.TabIndex = 16;
            this.aoriBox.Text = "Copy Callie";
            this.aoriBox.UseVisualStyleBackColor = true;
            this.aoriBox.Click += new System.EventHandler(this.aoriBox_Click);
            // 
            // amiiboBox
            // 
            this.amiiboBox.Enabled = false;
            this.amiiboBox.FormattingEnabled = true;
            this.amiiboBox.Items.AddRange(new object[] {
            "(None)",
            "Girl",
            "Boy",
            "Squid",
            "Callie",
            "Marie"});
            this.amiiboBox.Location = new System.Drawing.Point(71, 63);
            this.amiiboBox.Name = "amiiboBox";
            this.amiiboBox.Size = new System.Drawing.Size(85, 21);
            this.amiiboBox.TabIndex = 3;
            this.amiiboBox.SelectedIndexChanged += new System.EventHandler(this.amiiboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Amiibo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "IP Address:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gameButton);
            this.groupBox5.Controls.Add(this.bukiButton);
            this.groupBox5.Controls.Add(this.gearButton);
            this.groupBox5.Location = new System.Drawing.Point(182, 312);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 111);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Unlock";
            // 
            // gameButton
            // 
            this.gameButton.Enabled = false;
            this.gameButton.Location = new System.Drawing.Point(6, 78);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(149, 22);
            this.gameButton.TabIndex = 22;
            this.gameButton.Text = "Minigames";
            this.gameButton.UseVisualStyleBackColor = true;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
            // 
            // bukiButton
            // 
            this.bukiButton.Enabled = false;
            this.bukiButton.Location = new System.Drawing.Point(6, 49);
            this.bukiButton.Name = "bukiButton";
            this.bukiButton.Size = new System.Drawing.Size(149, 23);
            this.bukiButton.TabIndex = 21;
            this.bukiButton.Text = "Weapons";
            this.bukiButton.UseVisualStyleBackColor = true;
            this.bukiButton.Click += new System.EventHandler(this.bukiButton_Click);
            // 
            // gearButton
            // 
            this.gearButton.Enabled = false;
            this.gearButton.Location = new System.Drawing.Point(6, 20);
            this.gearButton.Name = "gearButton";
            this.gearButton.Size = new System.Drawing.Size(149, 22);
            this.gearButton.TabIndex = 20;
            this.gearButton.Text = "Gear";
            this.gearButton.UseVisualStyleBackColor = true;
            this.gearButton.Click += new System.EventHandler(this.gearButton_Click_1);
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OKButton.Location = new System.Drawing.Point(19, 367);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(150, 45);
            this.OKButton.TabIndex = 13;
            this.OKButton.Text = "Apply";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 418);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "For Splatoon v2.10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 440);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.amiiboBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.disconnectBox);
            this.Controls.Add(this.connectBox);
            this.Controls.Add(this.ipBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Splat AIO 2: It\'s Him!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sazaeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Button connectBox;
        private System.Windows.Forms.Button disconnectBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox udeBox;
        private System.Windows.Forms.Button showStatsBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.ComboBox skinBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox eyeBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button takoBox;
        private System.Windows.Forms.Button ikaBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button normalBox;
        private System.Windows.Forms.Button swapBox;
        private System.Windows.Forms.Button hotaruBox;
        private System.Windows.Forms.Button aoriBox;
        private System.Windows.Forms.ComboBox amiiboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Button bukiButton;
        private System.Windows.Forms.Button gearButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.NumericUpDown rankBox;
        private System.Windows.Forms.NumericUpDown kaneBox;
        private System.Windows.Forms.NumericUpDown maeBox;
        private System.Windows.Forms.NumericUpDown sazaeBox;
        private System.Windows.Forms.Label label10;
    }
}

