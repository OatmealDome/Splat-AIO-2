namespace SplatAIO.Core
{
    partial class EditLevelDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(EditLevelDataForm));
            this.levelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clearStateBox = new System.Windows.Forms.ComboBox();
            this.scrollBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // levelBox
            // 
            resources.ApplyResources(this.levelBox, "levelBox");
            this.levelBox.FormattingEnabled = true;
            this.levelBox.Items.AddRange(new object[] {
            resources.GetString("levelBox.Items"),
            resources.GetString("levelBox.Items1"),
            resources.GetString("levelBox.Items2"),
            resources.GetString("levelBox.Items3"),
            resources.GetString("levelBox.Items4"),
            resources.GetString("levelBox.Items5"),
            resources.GetString("levelBox.Items6"),
            resources.GetString("levelBox.Items7"),
            resources.GetString("levelBox.Items8"),
            resources.GetString("levelBox.Items9"),
            resources.GetString("levelBox.Items10"),
            resources.GetString("levelBox.Items11"),
            resources.GetString("levelBox.Items12"),
            resources.GetString("levelBox.Items13"),
            resources.GetString("levelBox.Items14"),
            resources.GetString("levelBox.Items15"),
            resources.GetString("levelBox.Items16"),
            resources.GetString("levelBox.Items17"),
            resources.GetString("levelBox.Items18"),
            resources.GetString("levelBox.Items19"),
            resources.GetString("levelBox.Items20"),
            resources.GetString("levelBox.Items21"),
            resources.GetString("levelBox.Items22"),
            resources.GetString("levelBox.Items23"),
            resources.GetString("levelBox.Items24"),
            resources.GetString("levelBox.Items25"),
            resources.GetString("levelBox.Items26"),
            resources.GetString("levelBox.Items27"),
            resources.GetString("levelBox.Items28"),
            resources.GetString("levelBox.Items29"),
            resources.GetString("levelBox.Items30"),
            resources.GetString("levelBox.Items31")});
            this.levelBox.Name = "levelBox";
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
            // clearStateBox
            // 
            resources.ApplyResources(this.clearStateBox, "clearStateBox");
            this.clearStateBox.FormattingEnabled = true;
            this.clearStateBox.Items.AddRange(new object[] {
            resources.GetString("clearStateBox.Items"),
            resources.GetString("clearStateBox.Items1"),
            resources.GetString("clearStateBox.Items2")});
            this.clearStateBox.Name = "clearStateBox";
            // 
            // scrollBox
            // 
            resources.ApplyResources(this.scrollBox, "scrollBox");
            this.scrollBox.Name = "scrollBox";
            this.scrollBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EditLevelDataForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scrollBox);
            this.Controls.Add(this.clearStateBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.levelBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditLevelDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox levelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox clearStateBox;
        private System.Windows.Forms.CheckBox scrollBox;
        private System.Windows.Forms.Button saveButton;
    }
}