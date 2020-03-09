namespace ScreenSizeGet
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
            this.GetBt = new System.Windows.Forms.Button();
            this.LogTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GetBt
            // 
            this.GetBt.Location = new System.Drawing.Point(104, 106);
            this.GetBt.Name = "GetBt";
            this.GetBt.Size = new System.Drawing.Size(75, 23);
            this.GetBt.TabIndex = 0;
            this.GetBt.Text = "Get";
            this.GetBt.UseVisualStyleBackColor = true;
            this.GetBt.Click += new System.EventHandler(this.GetBt_Click);
            // 
            // LogTb
            // 
            this.LogTb.Location = new System.Drawing.Point(13, 135);
            this.LogTb.Multiline = true;
            this.LogTb.Name = "LogTb";
            this.LogTb.Size = new System.Drawing.Size(267, 126);
            this.LogTb.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.LogTb);
            this.Controls.Add(this.GetBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetBt;
        private System.Windows.Forms.TextBox LogTb;
    }
}

