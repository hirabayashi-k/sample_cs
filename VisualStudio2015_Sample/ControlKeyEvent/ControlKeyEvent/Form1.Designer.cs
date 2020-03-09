namespace ControlKeyEvent
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
            this.StartBt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartBt
            // 
            this.StartBt.Location = new System.Drawing.Point(37, 49);
            this.StartBt.Name = "StartBt";
            this.StartBt.Size = new System.Drawing.Size(75, 23);
            this.StartBt.TabIndex = 0;
            this.StartBt.Text = "Enter";
            this.StartBt.UseVisualStyleBackColor = true;
            this.StartBt.Click += new System.EventHandler(this.StartBt_Click);
            this.StartBt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartBt_KeyDown);
            this.StartBt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartBt_KeyPress);
            this.StartBt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartBt_KeyUp);
            this.StartBt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.StartBt_PreviewKeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 179);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(250, 99);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter押下の順番確認";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StartBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

