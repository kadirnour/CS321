namespace Spreadsheet_Kadir_Nour
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
            this.myGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // myGrid
            // 
            this.myGrid.AllowUserToAddRows = false;
            this.myGrid.AllowUserToDeleteRows = false;
            this.myGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myGrid.Location = new System.Drawing.Point(0, -1);
            this.myGrid.Name = "myGrid";
            this.myGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.myGrid.Size = new System.Drawing.Size(800, 422);
            this.myGrid.TabIndex = 0;
            this.myGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(800, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Perform Demo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DemoButton);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myGrid);
            this.Name = "Form1";
            this.Text = "My Spreadsheet";
            ((System.ComponentModel.ISupportInitialize)(this.myGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView myGrid;
        private System.Windows.Forms.Button button1;
    }
}

