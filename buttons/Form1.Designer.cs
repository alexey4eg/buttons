namespace buttons
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.очиститьСтатистикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКнопкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBindImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBindMatrix = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowMatrix = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(2, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 458);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьСтатистикуToolStripMenuItem,
            this.создатьКнопкуToolStripMenuItem,
            this.создатьВкладкуToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // очиститьСтатистикуToolStripMenuItem
            // 
            this.очиститьСтатистикуToolStripMenuItem.Name = "очиститьСтатистикуToolStripMenuItem";
            this.очиститьСтатистикуToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.очиститьСтатистикуToolStripMenuItem.Text = "Очистить статистику";
            this.очиститьСтатистикуToolStripMenuItem.Click += new System.EventHandler(this.очиститьСтатистикуToolStripMenuItem_Click);
            // 
            // создатьКнопкуToolStripMenuItem
            // 
            this.создатьКнопкуToolStripMenuItem.Name = "создатьКнопкуToolStripMenuItem";
            this.создатьКнопкуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.создатьКнопкуToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.создатьКнопкуToolStripMenuItem.Text = "Создать кнопку...";
            this.создатьКнопкуToolStripMenuItem.Click += new System.EventHandler(this.создатьКнопкуToolStripMenuItem_Click);
            // 
            // создатьВкладкуToolStripMenuItem
            // 
            this.создатьВкладкуToolStripMenuItem.Name = "создатьВкладкуToolStripMenuItem";
            this.создатьВкладкуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.создатьВкладкуToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.создатьВкладкуToolStripMenuItem.Text = "Создать вкладку...";
            this.создатьВкладкуToolStripMenuItem.Click += new System.EventHandler(this.создатьВкладкуToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.menuBindImage,
            this.menuBindMatrix,
            this.menuItemShowMatrix});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(228, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать...";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // menuBindImage
            // 
            this.menuBindImage.Name = "menuBindImage";
            this.menuBindImage.Size = new System.Drawing.Size(227, 22);
            this.menuBindImage.Text = "Прикрепить изображение...";
            this.menuBindImage.Click += new System.EventHandler(this.menuBindImage_Click);
            // 
            // menuBindMatrix
            // 
            this.menuBindMatrix.Name = "menuBindMatrix";
            this.menuBindMatrix.Size = new System.Drawing.Size(227, 22);
            this.menuBindMatrix.Text = "Привязать матрицу...";
            this.menuBindMatrix.Click += new System.EventHandler(this.матрицаToolStripMenuItem_Click);
            // 
            // menuItemShowMatrix
            // 
            this.menuItemShowMatrix.Name = "menuItemShowMatrix";
            this.menuItemShowMatrix.Size = new System.Drawing.Size(227, 22);
            this.menuItemShowMatrix.Text = "Вывод матрицы";
            this.menuItemShowMatrix.Click += new System.EventHandler(this.menuItemShowMatrix_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Кнопки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem очиститьСтатистикуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьКнопкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьВкладкуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuBindImage;
        private System.Windows.Forms.ToolStripMenuItem menuBindMatrix;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowMatrix;
    }
}

