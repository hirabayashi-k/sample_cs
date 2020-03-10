namespace VisaCom
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
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.OpenBt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LogTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenBt
            // 
            this.OpenBt.Location = new System.Drawing.Point(52, 48);
            this.OpenBt.Name = "OpenBt";
            this.OpenBt.Size = new System.Drawing.Size(75, 23);
            this.OpenBt.TabIndex = 0;
            this.OpenBt.Text = "Open";
            this.OpenBt.UseVisualStyleBackColor = true;
            this.OpenBt.Click += new System.EventHandler(this.OpenBt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 19);
            this.textBox1.TabIndex = 1;
            // 
            // LogTb
            // 
            this.LogTb.Location = new System.Drawing.Point(52, 287);
            this.LogTb.Multiline = true;
            this.LogTb.Name = "LogTb";
            this.LogTb.Size = new System.Drawing.Size(693, 133);
            this.LogTb.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogTb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OpenBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenBt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox LogTb;
    }
}

