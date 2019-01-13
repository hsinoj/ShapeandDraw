namespace ShapeInterface
{
    partial class inputOutput
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.run = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.help = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Teal;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.Color.Teal;
            this.run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.run.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.run.FlatAppearance.BorderSize = 0;
            this.run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.run.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.run.Location = new System.Drawing.Point(95, 0);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(44, 23);
            this.run.TabIndex = 3;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = false;
            this.run.Click += new System.EventHandler(this.button1_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Teal;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exit.Location = new System.Drawing.Point(133, 1);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(54, 23);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Teal;
            this.edit.Location = new System.Drawing.Point(0, 27);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(331, 424);
            this.edit.TabIndex = 5;
            this.edit.Text = "";
            this.edit.TextChanged += new System.EventHandler(this.edit_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(337, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 424);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Teal;
            this.help.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.help.FlatAppearance.BorderSize = 0;
            this.help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help.Location = new System.Drawing.Point(41, 0);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(48, 23);
            this.help.TabIndex = 7;
            this.help.Text = "Help";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(184, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // inputOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.help);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.run);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "inputOutput";
            this.Text = "inputOutput";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.RichTextBox edit;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button button1;
    }
}