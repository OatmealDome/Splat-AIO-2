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
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(SinglePlayerForm));
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
            resources.ApplyResources(this.heroShotBox, "heroShotBox");
            this.heroShotBox.FormattingEnabled = true;
            this.heroShotBox.Items.AddRange(new object[] {
            resources.GetString("heroShotBox.Items"),
            resources.GetString("heroShotBox.Items1"),
            resources.GetString("heroShotBox.Items2"),
            resources.GetString("heroShotBox.Items3")});
            this.heroShotBox.Name = "heroShotBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // inkTankBox
            // 
            resources.ApplyResources(this.inkTankBox, "inkTankBox");
            this.inkTankBox.FormattingEnabled = true;
            this.inkTankBox.Items.AddRange(new object[] {
            resources.GetString("inkTankBox.Items"),
            resources.GetString("inkTankBox.Items1"),
            resources.GetString("inkTankBox.Items2"),
            resources.GetString("inkTankBox.Items3")});
            this.inkTankBox.Name = "inkTankBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // splatBombBox
            // 
            resources.ApplyResources(this.splatBombBox, "splatBombBox");
            this.splatBombBox.FormattingEnabled = true;
            this.splatBombBox.Items.AddRange(new object[] {
            resources.GetString("splatBombBox.Items"),
            resources.GetString("splatBombBox.Items1"),
            resources.GetString("splatBombBox.Items2"),
            resources.GetString("splatBombBox.Items3")});
            this.splatBombBox.Name = "splatBombBox";
            // 
            // upgradesGroup
            // 
            resources.ApplyResources(this.upgradesGroup, "upgradesGroup");
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
            this.upgradesGroup.Name = "upgradesGroup";
            this.upgradesGroup.TabStop = false;
            // 
            // powerEggsBox
            // 
            resources.ApplyResources(this.powerEggsBox, "powerEggsBox");
            this.powerEggsBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.powerEggsBox.Name = "powerEggsBox";
            // 
            // seekerBox
            // 
            resources.ApplyResources(this.seekerBox, "seekerBox");
            this.seekerBox.FormattingEnabled = true;
            this.seekerBox.Items.AddRange(new object[] {
            resources.GetString("seekerBox.Items"),
            resources.GetString("seekerBox.Items1"),
            resources.GetString("seekerBox.Items2"),
            resources.GetString("seekerBox.Items3"),
            resources.GetString("seekerBox.Items4")});
            this.seekerBox.Name = "seekerBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // burstBombBox
            // 
            resources.ApplyResources(this.burstBombBox, "burstBombBox");
            this.burstBombBox.FormattingEnabled = true;
            this.burstBombBox.Items.AddRange(new object[] {
            resources.GetString("burstBombBox.Items"),
            resources.GetString("burstBombBox.Items1"),
            resources.GetString("burstBombBox.Items2"),
            resources.GetString("burstBombBox.Items3"),
            resources.GetString("burstBombBox.Items4")});
            this.burstBombBox.Name = "burstBombBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // levelGroup
            // 
            resources.ApplyResources(this.levelGroup, "levelGroup");
            this.levelGroup.Controls.Add(this.label6);
            this.levelGroup.Controls.Add(this.levelDataView);
            this.levelGroup.Controls.Add(this.addButton);
            this.levelGroup.Name = "levelGroup";
            this.levelGroup.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // levelDataView
            // 
            resources.ApplyResources(this.levelDataView, "levelDataView");
            this.levelDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.levelColumn,
            this.clearStateColumn,
            this.scrollColumn});
            this.levelDataView.Name = "levelDataView";
            this.levelDataView.UseCompatibleStateImageBehavior = false;
            this.levelDataView.View = System.Windows.Forms.View.Details;
            this.levelDataView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelDataView_MouseClick);
            // 
            // levelColumn
            // 
            resources.ApplyResources(this.levelColumn, "levelColumn");
            // 
            // clearStateColumn
            // 
            resources.ApplyResources(this.clearStateColumn, "clearStateColumn");
            // 
            // scrollColumn
            // 
            resources.ApplyResources(this.scrollColumn, "scrollColumn");
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // contextMenu
            // 
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearEnvironmentButton
            // 
            resources.ApplyResources(this.clearEnvironmentButton, "clearEnvironmentButton");
            this.clearEnvironmentButton.Name = "clearEnvironmentButton";
            this.clearEnvironmentButton.UseVisualStyleBackColor = true;
            this.clearEnvironmentButton.Click += new System.EventHandler(this.clearEnvironmentButton_Click);
            // 
            // setEnvironmentButton
            // 
            resources.ApplyResources(this.setEnvironmentButton, "setEnvironmentButton");
            this.setEnvironmentButton.Name = "setEnvironmentButton";
            this.setEnvironmentButton.UseVisualStyleBackColor = true;
            this.setEnvironmentButton.Click += new System.EventHandler(this.setEnvironmentButton_Click);
            // 
            // resetAllButton
            // 
            resources.ApplyResources(this.resetAllButton, "resetAllButton");
            this.resetAllButton.Name = "resetAllButton";
            this.resetAllButton.UseVisualStyleBackColor = true;
            this.resetAllButton.Click += new System.EventHandler(this.resetAllButton_Click);
            // 
            // SinglePlayerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resetAllButton);
            this.Controls.Add(this.setEnvironmentButton);
            this.Controls.Add(this.clearEnvironmentButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.levelGroup);
            this.Controls.Add(this.upgradesGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SinglePlayerForm";
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