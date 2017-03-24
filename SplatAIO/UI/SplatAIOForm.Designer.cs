namespace SplatAIO.UI
{
    partial class SplatAIOForm
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
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(SplatAIOForm));
            this.ipBox = new System.Windows.Forms.TextBox();
            this.connectBox = new System.Windows.Forms.Button();
            this.disconnectBox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.skinBox = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.sazaeBox = new System.Windows.Forms.NumericUpDown();
            this.progressFlagsBox = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.maeBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.kaneBox = new System.Windows.Forms.NumericUpDown();
            this.eyeBox = new System.Windows.Forms.ComboBox();
            this.rankBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.udeBox = new System.Windows.Forms.ComboBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.editorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerHaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sazaeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaneBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipBox
            // 
            resources.ApplyResources(this.ipBox, "ipBox");
            this.ipBox.Name = "ipBox";
            // 
            // connectBox
            // 
            resources.ApplyResources(this.connectBox, "connectBox");
            this.connectBox.Name = "connectBox";
            this.connectBox.UseVisualStyleBackColor = true;
            this.connectBox.Click += new System.EventHandler(this.connectBox_Click);
            // 
            // disconnectBox
            // 
            resources.ApplyResources(this.disconnectBox, "disconnectBox");
            this.disconnectBox.Name = "disconnectBox";
            this.disconnectBox.UseVisualStyleBackColor = true;
            this.disconnectBox.Click += new System.EventHandler(this.disconnectBox_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.skinBox);
            this.groupBox1.Controls.Add(this.OKButton);
            this.groupBox1.Controls.Add(this.sazaeBox);
            this.groupBox1.Controls.Add(this.progressFlagsBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.maeBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.kaneBox);
            this.groupBox1.Controls.Add(this.eyeBox);
            this.groupBox1.Controls.Add(this.rankBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.genderBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udeBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // refreshButton
            // 
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // skinBox
            // 
            resources.ApplyResources(this.skinBox, "skinBox");
            this.skinBox.FormattingEnabled = true;
            this.skinBox.Items.AddRange(new object[] {
            resources.GetString("skinBox.Items"),
            resources.GetString("skinBox.Items1"),
            resources.GetString("skinBox.Items2"),
            resources.GetString("skinBox.Items3"),
            resources.GetString("skinBox.Items4"),
            resources.GetString("skinBox.Items5"),
            resources.GetString("skinBox.Items6")});
            this.skinBox.Name = "skinBox";
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // sazaeBox
            // 
            resources.ApplyResources(this.sazaeBox, "sazaeBox");
            this.sazaeBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.sazaeBox.Name = "sazaeBox";
            // 
            // progressFlagsBox
            // 
            resources.ApplyResources(this.progressFlagsBox, "progressFlagsBox");
            this.progressFlagsBox.Name = "progressFlagsBox";
            this.progressFlagsBox.UseVisualStyleBackColor = true;
            this.progressFlagsBox.Click += new System.EventHandler(this.progressFlagsBox_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // maeBox
            // 
            resources.ApplyResources(this.maeBox, "maeBox");
            this.maeBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maeBox.Name = "maeBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // kaneBox
            // 
            resources.ApplyResources(this.kaneBox, "kaneBox");
            this.kaneBox.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.kaneBox.Name = "kaneBox";
            // 
            // eyeBox
            // 
            resources.ApplyResources(this.eyeBox, "eyeBox");
            this.eyeBox.FormattingEnabled = true;
            this.eyeBox.Items.AddRange(new object[] {
            resources.GetString("eyeBox.Items"),
            resources.GetString("eyeBox.Items1"),
            resources.GetString("eyeBox.Items2"),
            resources.GetString("eyeBox.Items3"),
            resources.GetString("eyeBox.Items4"),
            resources.GetString("eyeBox.Items5"),
            resources.GetString("eyeBox.Items6")});
            this.eyeBox.Name = "eyeBox";
            // 
            // rankBox
            // 
            resources.ApplyResources(this.rankBox, "rankBox");
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
            this.rankBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // genderBox
            // 
            resources.ApplyResources(this.genderBox, "genderBox");
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            resources.GetString("genderBox.Items"),
            resources.GetString("genderBox.Items1")});
            this.genderBox.Name = "genderBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // udeBox
            // 
            resources.ApplyResources(this.udeBox, "udeBox");
            this.udeBox.FormattingEnabled = true;
            this.udeBox.Items.AddRange(new object[] {
            resources.GetString("udeBox.Items"),
            resources.GetString("udeBox.Items1"),
            resources.GetString("udeBox.Items2"),
            resources.GetString("udeBox.Items3"),
            resources.GetString("udeBox.Items4"),
            resources.GetString("udeBox.Items5"),
            resources.GetString("udeBox.Items6"),
            resources.GetString("udeBox.Items7"),
            resources.GetString("udeBox.Items8"),
            resources.GetString("udeBox.Items9"),
            resources.GetString("udeBox.Items10")});
            this.udeBox.Name = "udeBox";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.takoBox);
            this.groupBox3.Controls.Add(this.ikaBox);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // takoBox
            // 
            resources.ApplyResources(this.takoBox, "takoBox");
            this.takoBox.Name = "takoBox";
            this.takoBox.UseVisualStyleBackColor = true;
            this.takoBox.Click += new System.EventHandler(this.takoBox_Click);
            // 
            // ikaBox
            // 
            resources.ApplyResources(this.ikaBox, "ikaBox");
            this.ikaBox.Name = "ikaBox";
            this.ikaBox.UseVisualStyleBackColor = true;
            this.ikaBox.Click += new System.EventHandler(this.ikaBox_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.normalBox);
            this.groupBox4.Controls.Add(this.swapBox);
            this.groupBox4.Controls.Add(this.hotaruBox);
            this.groupBox4.Controls.Add(this.aoriBox);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // normalBox
            // 
            resources.ApplyResources(this.normalBox, "normalBox");
            this.normalBox.Name = "normalBox";
            this.normalBox.UseVisualStyleBackColor = true;
            this.normalBox.Click += new System.EventHandler(this.normalBox_Click);
            // 
            // swapBox
            // 
            resources.ApplyResources(this.swapBox, "swapBox");
            this.swapBox.Name = "swapBox";
            this.swapBox.UseVisualStyleBackColor = true;
            this.swapBox.Click += new System.EventHandler(this.swapBox_Click);
            // 
            // hotaruBox
            // 
            resources.ApplyResources(this.hotaruBox, "hotaruBox");
            this.hotaruBox.Name = "hotaruBox";
            this.hotaruBox.UseVisualStyleBackColor = true;
            this.hotaruBox.Click += new System.EventHandler(this.hotaruBox_Click);
            // 
            // aoriBox
            // 
            resources.ApplyResources(this.aoriBox, "aoriBox");
            this.aoriBox.Name = "aoriBox";
            this.aoriBox.UseVisualStyleBackColor = true;
            this.aoriBox.Click += new System.EventHandler(this.aoriBox_Click);
            // 
            // amiiboBox
            // 
            resources.ApplyResources(this.amiiboBox, "amiiboBox");
            this.amiiboBox.FormattingEnabled = true;
            this.amiiboBox.Items.AddRange(new object[] {
            resources.GetString("amiiboBox.Items"),
            resources.GetString("amiiboBox.Items1"),
            resources.GetString("amiiboBox.Items2"),
            resources.GetString("amiiboBox.Items3"),
            resources.GetString("amiiboBox.Items4"),
            resources.GetString("amiiboBox.Items5")});
            this.amiiboBox.Name = "amiiboBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.gameButton);
            this.groupBox5.Controls.Add(this.bukiButton);
            this.groupBox5.Controls.Add(this.gearButton);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // gameButton
            // 
            resources.ApplyResources(this.gameButton, "gameButton");
            this.gameButton.Name = "gameButton";
            this.gameButton.UseVisualStyleBackColor = true;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
            // 
            // bukiButton
            // 
            resources.ApplyResources(this.bukiButton, "bukiButton");
            this.bukiButton.Name = "bukiButton";
            this.bukiButton.UseVisualStyleBackColor = true;
            this.bukiButton.Click += new System.EventHandler(this.bukiButton_Click);
            // 
            // gearButton
            // 
            resources.ApplyResources(this.gearButton, "gearButton");
            this.gearButton.Name = "gearButton";
            this.gearButton.UseVisualStyleBackColor = true;
            this.gearButton.Click += new System.EventHandler(this.gearButton_Click_1);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Name = "label10";
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorsToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // editorsToolStripMenuItem
            // 
            resources.ApplyResources(this.editorsToolStripMenuItem, "editorsToolStripMenuItem");
            this.editorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponsToolStripMenuItem});
            this.editorsToolStripMenuItem.Name = "editorsToolStripMenuItem";
            // 
            // weaponsToolStripMenuItem
            // 
            resources.ApplyResources(this.weaponsToolStripMenuItem, "weaponsToolStripMenuItem");
            this.weaponsToolStripMenuItem.Name = "weaponsToolStripMenuItem";
            this.weaponsToolStripMenuItem.Click += new System.EventHandler(this.weaponsToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            resources.ApplyResources(this.otherToolStripMenuItem, "otherToolStripMenuItem");
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePlayerToolStripMenuItem,
            this.timerHaxToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            // 
            // singlePlayerToolStripMenuItem
            // 
            resources.ApplyResources(this.singlePlayerToolStripMenuItem, "singlePlayerToolStripMenuItem");
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.singlePlayerToolStripMenuItem_Click);
            // 
            // timerHaxToolStripMenuItem
            // 
            resources.ApplyResources(this.timerHaxToolStripMenuItem, "timerHaxToolStripMenuItem");
            this.timerHaxToolStripMenuItem.Name = "timerHaxToolStripMenuItem";
            this.timerHaxToolStripMenuItem.Click += new System.EventHandler(this.timerHaxToolStripMenuItem_Click);
            // 
            // autoRefreshTimer
            // 
            this.autoRefreshTimer.Enabled = true;
            this.autoRefreshTimer.Interval = 5000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.amiiboBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.disconnectBox);
            this.Controls.Add(this.connectBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sazaeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaneBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.Button progressFlagsBox;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerHaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponsToolStripMenuItem;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer autoRefreshTimer;
    }
}

