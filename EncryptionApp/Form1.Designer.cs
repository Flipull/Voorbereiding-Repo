namespace EncryptionApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadTextfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadEncryptedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEncryptedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadTextfileToolStripMenuItem,
            this.loadEncryptedTextToolStripMenuItem,
            this.saveEncryptedTextToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.loadToolStripMenuItem.Text = "Files";
            // 
            // LoadTextfileToolStripMenuItem
            // 
            this.LoadTextfileToolStripMenuItem.Name = "LoadTextfileToolStripMenuItem";
            this.LoadTextfileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LoadTextfileToolStripMenuItem.Text = "Load Textfile";
            this.LoadTextfileToolStripMenuItem.Click += new System.EventHandler(this.LoadTextfileToolStripMenuItem_Click);
            // 
            // loadEncryptedTextToolStripMenuItem
            // 
            this.loadEncryptedTextToolStripMenuItem.Name = "loadEncryptedTextToolStripMenuItem";
            this.loadEncryptedTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadEncryptedTextToolStripMenuItem.Text = "Load Encrypted Text";
            this.loadEncryptedTextToolStripMenuItem.Click += new System.EventHandler(this.LoadEncryptedTextToolStripMenuItem_Click);
            // 
            // saveEncryptedTextToolStripMenuItem
            // 
            this.saveEncryptedTextToolStripMenuItem.Name = "saveEncryptedTextToolStripMenuItem";
            this.saveEncryptedTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveEncryptedTextToolStripMenuItem.Text = "Save Encrypted Text";
            this.saveEncryptedTextToolStripMenuItem.Click += new System.EventHandler(this.SaveEncryptedTextToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Load Textfile";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 277);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(306, 27);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 277);
            this.textBox2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 353);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadTextfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadEncryptedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEncryptedTextToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

