namespace SplatAIO
{
    partial class SinglePlayerForm
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
            this.heroShotBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inkTankBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splatBombBox = new System.Windows.Forms.ComboBox();
            this.upgradesGroup = new System.Windows.Forms.GroupBox();
            this.powerEggsBox = new System.Windows.Forms.NumericUpDown();
            this.seekerBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.burstBombBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.levelGroup = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.levelDataView = new System.Windows.Forms.ListView();
            this.levelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearStateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scrollColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearEnvironmentButton = new System.Windows.Forms.Button();
            this.setEnvironmentButton = new System.Windows.Forms.Button();
            this.resetAllButton = new System.Windows.Forms.Button();
            this.upgradesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerEggsBox)).BeginInit();
            this.levelGroup.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // heroShotBox
            // 
            this.heroShotBox.FormattingEnabled = true;
            this.heroShotBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.heroShotBox.Location = new System.Drawing.Point(73, 19);
            this.heroShotBox.Name = "heroShotBox";
            this.heroShotBox.Size = new System.Drawing.Size(85, 21);
            this.heroShotBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hero Shot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ink Tank";
            // 
            // inkTankBox
            // 
            this.inkTankBox.FormattingEnabled = true;
            this.inkTankBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.inkTankBox.Location = new System.Drawing.Point(73, 46);
            this.inkTankBox.Name = "inkTankBox";
            this.inkTankBox.Size = new System.Drawing.Size(85, 21);
            this.inkTankBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Splat Bomb";
            // 
            // splatBombBox
            // 
            this.splatBombBox.FormattingEnabled = true;
            this.splatBombBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.splatBombBox.Location = new System.Drawing.Point(73, 73);
            this.splatBombBox.Name = "splatBombBox";
            this.splatBombBox.Size = new System.Drawing.Size(85, 21);
            this.splatBombBox.TabIndex = 5;
            // 
            // upgradesGroup
            // 
            this.upgradesGroup.Controls.Add(this.powerEggsBox);
            this.upgradesGroup.Controls.Add(this.seekerBox);
            this.upgradesGroup.Controls.Add(this.label7);
            this.upgradesGroup.Controls.Add(this.label5);
            this.upgradesGroup.Controls.Add(this.burstBombBox);
            this.upgradesGroup.Controls.Add(this.label4);
            this.upgradesGroup.Controls.Add(this.splatBombBox);
            this.upgradesGroup.Controls.Add(this.label3);
            this.upgradesGroup.Controls.Add(this.heroShotBox);
            this.upgradesGroup.Controls.Add(this.label1);
            this.upgradesGroup.Controls.Add(this.label2);
            this.upgradesGroup.Controls.Add(this.inkTankBox);
            this.upgradesGroup.Location = new System.Drawing.Point(279, 12);
            this.upgradesGroup.Name = "upgradesGroup";
            this.upgradesGroup.Size = new System.Drawing.Size(169, 183);
            this.upgradesGroup.TabIndex = 7;
            this.upgradesGroup.TabStop = false;
            this.upgradesGroup.Text = "Upgrades";
            // 
            // powerEggsBox
            // 
            this.powerEggsBox.Location = new System.Drawing.Point(73, 154);
            this.powerEggsBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.powerEggsBox.Name = "powerEggsBox";
            this.powerEggsBox.Size = new System.Drawing.Size(85, 20);
            this.powerEggsBox.TabIndex = 18;
            // 
            // seekerBox
            // 
            this.seekerBox.FormattingEnabled = true;
            this.seekerBox.Items.AddRange(new object[] {
            "(Locked)",
            "1",
            "2",
            "3",
            "4"});
            this.seekerBox.Location = new System.Drawing.Point(73, 127);
            this.seekerBox.Name = "seekerBox";
            this.seekerBox.Size = new System.Drawing.Size(85, 21);
            this.seekerBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Power Eggs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Seeker";
            // 
            // burstBombBox
            // 
            this.burstBombBox.FormattingEnabled = true;
            this.burstBombBox.Items.AddRange(new object[] {
            "(Locked)",
            "1",
            "2",
            "3",
            "4"});
            this.burstBombBox.Location = new System.Drawing.Point(73, 100);
            this.burstBombBox.Name = "burstBombBox";
            this.burstBombBox.Size = new System.Drawing.Size(85, 21);
            this.burstBombBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Burst Bomb";
            // 
            // levelGroup
            // 
            this.levelGroup.Controls.Add(this.label6);
            this.levelGroup.Controls.Add(this.levelDataView);
            this.levelGroup.Controls.Add(this.addButton);
            this.levelGroup.Location = new System.Drawing.Point(12, 12);
            this.levelGroup.Name = "levelGroup";
            this.levelGroup.Size = new System.Drawing.Size(261, 321);
            this.levelGroup.TabIndex = 8;
            this.levelGroup.TabStop = false;
            this.levelGroup.Text = "Level Save Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "To edit, right click on the level number or name.";
            // 
            // levelDataView
            // 
            this.levelDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.levelColumn,
            this.clearStateColumn,
            this.scrollColumn});
            this.levelDataView.Location = new System.Drawing.Point(6, 39);
            this.levelDataView.Name = "levelDataView";
            this.levelDataView.Size = new System.Drawing.Size(248, 247);
            this.levelDataView.TabIndex = 0;
            this.levelDataView.UseCompatibleStateImageBehavior = false;
            this.levelDataView.View = System.Windows.Forms.View.Details;
            this.levelDataView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelDataView_MouseClick);
            // 
            // levelColumn
            // 
            this.levelColumn.Text = "Level";
            this.levelColumn.Width = 80;
            // 
            // clearStateColumn
            // 
            this.clearStateColumn.Text = "Clear State";
            this.clearStateColumn.Width = 80;
            // 
            // scrollColumn
            // 
            this.scrollColumn.Text = "Has Scroll";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(93, 291);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add Level";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.OKButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OKButton.Location = new System.Drawing.Point(279, 288);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(168, 45);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "Apply";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearEnvironmentButton
            // 
            this.clearEnvironmentButton.Location = new System.Drawing.Point(280, 201);
            this.clearEnvironmentButton.Name = "clearEnvironmentButton";
            this.clearEnvironmentButton.Size = new System.Drawing.Size(168, 23);
            this.clearEnvironmentButton.TabIndex = 15;
            this.clearEnvironmentButton.Text = "Clear Environment Flags";
            this.clearEnvironmentButton.UseVisualStyleBackColor = true;
            this.clearEnvironmentButton.Click += new System.EventHandler(this.clearEnvironmentButton_Click);
            // 
            // setEnvironmentButton
            // 
            this.setEnvironmentButton.Location = new System.Drawing.Point(280, 230);
            this.setEnvironmentButton.Name = "setEnvironmentButton";
            this.setEnvironmentButton.Size = new System.Drawing.Size(168, 23);
            this.setEnvironmentButton.TabIndex = 16;
            this.setEnvironmentButton.Text = "Set All Environment Flags";
            this.setEnvironmentButton.UseVisualStyleBackColor = true;
            this.setEnvironmentButton.Click += new System.EventHandler(this.setEnvironmentButton_Click);
            // 
            // resetAllButton
            // 
            this.resetAllButton.Location = new System.Drawing.Point(280, 259);
            this.resetAllButton.Name = "resetAllButton";
            this.resetAllButton.Size = new System.Drawing.Size(168, 23);
            this.resetAllButton.TabIndex = 17;
            this.resetAllButton.Text = "Reset Octo Valley";
            this.resetAllButton.UseVisualStyleBackColor = true;
            this.resetAllButton.Click += new System.EventHandler(this.resetAllButton_Click);
            // 
            // SinglePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 343);
            this.Controls.Add(this.resetAllButton);
            this.Controls.Add(this.setEnvironmentButton);
            this.Controls.Add(this.clearEnvironmentButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.levelGroup);
            this.Controls.Add(this.upgradesGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SinglePlayerForm";
            this.Text = "Single Player";
            this.Load += new System.EventHandler(this.SinglePlayerForm_Load);
            this.upgradesGroup.ResumeLayout(false);
            this.upgradesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerEggsBox)).EndInit();
            this.levelGroup.ResumeLayout(false);
            this.levelGroup.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox heroShotBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inkTankBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox splatBombBox;
        private System.Windows.Forms.GroupBox upgradesGroup;
        private System.Windows.Forms.ComboBox seekerBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox burstBombBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox levelGroup;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListView levelDataView;
        private System.Windows.Forms.ColumnHeader levelColumn;
        private System.Windows.Forms.ColumnHeader clearStateColumn;
        private System.Windows.Forms.ColumnHeader scrollColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button clearEnvironmentButton;
        private System.Windows.Forms.Button setEnvironmentButton;
        private System.Windows.Forms.Button resetAllButton;
        private System.Windows.Forms.NumericUpDown powerEggsBox;
        private System.Windows.Forms.Label label7;
    }
}