namespace WindowsBindingMultiRowCs
{
    partial class BindingMultiRow_Form
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingMultiRow_Form));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.List_DataGridView = new System.Windows.Forms.DataGridView();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.DebugToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(284, 26);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpenToolStripMenuItem,
            this.FileSaveToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.FileExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.FileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // FileOpenToolStripMenuItem
            // 
            this.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem";
            this.FileOpenToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.FileOpenToolStripMenuItem.Text = "開く(&O)";
            this.FileOpenToolStripMenuItem.Click += new System.EventHandler(this.FileOpenToolStripMenuItem_Click);
            // 
            // FileSaveToolStripMenuItem
            // 
            this.FileSaveToolStripMenuItem.Enabled = false;
            this.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem";
            this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.FileSaveToolStripMenuItem.Text = "保存(&S)";
            this.FileSaveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(116, 6);
            // 
            // FileExitToolStripMenuItem
            // 
            this.FileExitToolStripMenuItem.Name = "FileExitToolStripMenuItem";
            this.FileExitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.FileExitToolStripMenuItem.Text = "終了(&X)";
            this.FileExitToolStripMenuItem.Click += new System.EventHandler(this.FileExitToolStripMenuItem_Click);
            // 
            // DebugToolStripMenuItem
            // 
            this.DebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DebugViewToolStripMenuItem});
            this.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem";
            this.DebugToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.DebugToolStripMenuItem.Text = "デバッグ(&D)";
            // 
            // DebugViewToolStripMenuItem
            // 
            this.DebugViewToolStripMenuItem.Enabled = false;
            this.DebugViewToolStripMenuItem.Name = "DebugViewToolStripMenuItem";
            this.DebugViewToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DebugViewToolStripMenuItem.Text = "RowState表示(&V)";
            this.DebugViewToolStripMenuItem.Click += new System.EventHandler(this.DebugViewToolStripMenuItem_Click);
            // 
            // List_DataGridView
            // 
            this.List_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.List_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List_DataGridView.Location = new System.Drawing.Point(0, 26);
            this.List_DataGridView.Name = "List_DataGridView";
            this.List_DataGridView.RowTemplate.Height = 21;
            this.List_DataGridView.Size = new System.Drawing.Size(284, 236);
            this.List_DataGridView.TabIndex = 2;
            // 
            // BindingMultiRow_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.List_DataGridView);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BindingMultiRow_Form";
            this.Text = "WindowsBindingMultiRowCs";
            this.Load += new System.EventHandler(this.Me_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FileOpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem FileExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DebugToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DebugViewToolStripMenuItem;
        internal System.Windows.Forms.DataGridView List_DataGridView;
    }
}

