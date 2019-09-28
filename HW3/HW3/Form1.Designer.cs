namespace HW3
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.first50NumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.first100NumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 24);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(337, 425);
            this.textBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(337, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadFibonacciToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load File";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // loadFibonacciToolStripMenuItem
            // 
            this.loadFibonacciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.first50NumbersToolStripMenuItem,
            this.first100NumbersToolStripMenuItem});
            this.loadFibonacciToolStripMenuItem.Name = "loadFibonacciToolStripMenuItem";
            this.loadFibonacciToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFibonacciToolStripMenuItem.Text = "Load Fibonacci";
            // 
            // first50NumbersToolStripMenuItem
            // 
            this.first50NumbersToolStripMenuItem.Name = "first50NumbersToolStripMenuItem";
            this.first50NumbersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.first50NumbersToolStripMenuItem.Text = "First 50 Numbers";
            this.first50NumbersToolStripMenuItem.Click += new System.EventHandler(this.First50_Click);
            // 
            // first100NumbersToolStripMenuItem
            // 
            this.first100NumbersToolStripMenuItem.Name = "first100NumbersToolStripMenuItem";
            this.first100NumbersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.first100NumbersToolStripMenuItem.Text = "First 100 Numbers";
            this.first100NumbersToolStripMenuItem.Click += new System.EventHandler(this.First100_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 449);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Notepad";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFibonacciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem first50NumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem first100NumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

