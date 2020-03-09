namespace delegateTest
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
            this.buttonDelegate = new System.Windows.Forms.Button();
            this.textBoxDelegate = new System.Windows.Forms.TextBox();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDelegate
            // 
            this.buttonDelegate.Location = new System.Drawing.Point(44, 117);
            this.buttonDelegate.Name = "buttonDelegate";
            this.buttonDelegate.Size = new System.Drawing.Size(152, 23);
            this.buttonDelegate.TabIndex = 0;
            this.buttonDelegate.Text = "Delegate実行";
            this.buttonDelegate.UseVisualStyleBackColor = true;
            this.buttonDelegate.Click += new System.EventHandler(this.buttonDelegate_Click);
            // 
            // textBoxDelegate
            // 
            this.textBoxDelegate.Location = new System.Drawing.Point(44, 167);
            this.textBoxDelegate.Name = "textBoxDelegate";
            this.textBoxDelegate.Size = new System.Drawing.Size(201, 19);
            this.textBoxDelegate.TabIndex = 1;
            this.textBoxDelegate.Text = "ここがBase2から呼び出される";
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(44, 61);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(201, 19);
            this.textBoxIn.TabIndex = 2;
            this.textBoxIn.Text = "ここがBase2に渡される";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.textBoxIn);
            this.Controls.Add(this.textBoxDelegate);
            this.Controls.Add(this.buttonDelegate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelegate;
        private System.Windows.Forms.TextBox textBoxDelegate;
        private System.Windows.Forms.TextBox textBoxIn;
    }
}

