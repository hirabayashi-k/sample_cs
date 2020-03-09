namespace DataGridViewXml
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReadBt = new System.Windows.Forms.Button();
            this.WriteBt = new System.Windows.Forms.Button();
            this.SlipsDataSet = new System.Data.DataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.setbt = new System.Windows.Forms.Button();
            this.set2bt = new System.Windows.Forms.Button();
            this.tabbt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.CommaHedder = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(264, 229);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // ReadBt
            // 
            this.ReadBt.Location = new System.Drawing.Point(13, 318);
            this.ReadBt.Name = "ReadBt";
            this.ReadBt.Size = new System.Drawing.Size(75, 23);
            this.ReadBt.TabIndex = 1;
            this.ReadBt.Text = "ReadXml";
            this.ReadBt.UseVisualStyleBackColor = true;
            this.ReadBt.Click += new System.EventHandler(this.ReadBt_Click);
            // 
            // WriteBt
            // 
            this.WriteBt.Location = new System.Drawing.Point(113, 318);
            this.WriteBt.Name = "WriteBt";
            this.WriteBt.Size = new System.Drawing.Size(75, 23);
            this.WriteBt.TabIndex = 2;
            this.WriteBt.Text = "WriteXml";
            this.WriteBt.UseVisualStyleBackColor = true;
            this.WriteBt.Click += new System.EventHandler(this.WriteBt_Click);
            // 
            // SlipsDataSet
            // 
            this.SlipsDataSet.DataSetName = "SlipsDataSet";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Make";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setbt
            // 
            this.setbt.Location = new System.Drawing.Point(298, 69);
            this.setbt.Name = "setbt";
            this.setbt.Size = new System.Drawing.Size(75, 23);
            this.setbt.TabIndex = 4;
            this.setbt.Text = "設定";
            this.setbt.UseVisualStyleBackColor = true;
            this.setbt.Click += new System.EventHandler(this.setbt_Click);
            // 
            // set2bt
            // 
            this.set2bt.Location = new System.Drawing.Point(298, 108);
            this.set2bt.Name = "set2bt";
            this.set2bt.Size = new System.Drawing.Size(75, 23);
            this.set2bt.TabIndex = 5;
            this.set2bt.Text = "設定2";
            this.set2bt.UseVisualStyleBackColor = true;
            this.set2bt.Click += new System.EventHandler(this.set2bt_Click);
            // 
            // tabbt
            // 
            this.tabbt.Location = new System.Drawing.Point(298, 153);
            this.tabbt.Name = "tabbt";
            this.tabbt.Size = new System.Drawing.Size(75, 23);
            this.tabbt.TabIndex = 6;
            this.tabbt.Text = "Tag";
            this.tabbt.UseVisualStyleBackColor = true;
            this.tabbt.Click += new System.EventHandler(this.tabbt_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(298, 182);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 19);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // CommaHedder
            // 
            this.CommaHedder.Location = new System.Drawing.Point(298, 231);
            this.CommaHedder.Name = "CommaHedder";
            this.CommaHedder.Size = new System.Drawing.Size(110, 23);
            this.CommaHedder.TabIndex = 8;
            this.CommaHedder.Text = "CommaHedder";
            this.CommaHedder.UseVisualStyleBackColor = true;
            this.CommaHedder.Click += new System.EventHandler(this.CommaHedder_Click);
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(282, 290);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(222, 82);
            this.Log.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(77, 26);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.aToolStripMenuItem.Text = "a";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "設定3";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "TEST";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data1,
            this.Data2,
            this.Data3});
            this.dataGridView2.Location = new System.Drawing.Point(564, 69);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(264, 229);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            this.dataGridView2.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView2_RowPrePaint);
            // 
            // Data1
            // 
            this.Data1.HeaderText = "データ1";
            this.Data1.Name = "Data1";
            // 
            // Data2
            // 
            this.Data2.HeaderText = "データ2";
            this.Data2.Name = "Data2";
            // 
            // Data3
            // 
            this.Data3.HeaderText = "データ3";
            this.Data3.Name = "Data3";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(510, 349);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "ADD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(641, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(161, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 454);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.CommaHedder);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tabbt);
            this.Controls.Add(this.set2bt);
            this.Controls.Add(this.setbt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WriteBt);
            this.Controls.Add(this.ReadBt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ReadBt;
        private System.Windows.Forms.Button WriteBt;
        private System.Data.DataSet SlipsDataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button setbt;
        private System.Windows.Forms.Button set2bt;
        private System.Windows.Forms.Button tabbt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button CommaHedder;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}

