namespace Excel
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
            this.OpenExcelBt = new System.Windows.Forms.Button();
            this.ReadExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenExcelBt
            // 
            this.OpenExcelBt.Location = new System.Drawing.Point(13, 61);
            this.OpenExcelBt.Name = "OpenExcelBt";
            this.OpenExcelBt.Size = new System.Drawing.Size(124, 99);
            this.OpenExcelBt.TabIndex = 0;
            this.OpenExcelBt.Text = "OpenExcel";
            this.OpenExcelBt.UseVisualStyleBackColor = true;
            this.OpenExcelBt.Click += new System.EventHandler(this.OpenExcelBt_Click);
            // 
            // ReadExcel
            // 
            this.ReadExcel.Location = new System.Drawing.Point(174, 61);
            this.ReadExcel.Name = "ReadExcel";
            this.ReadExcel.Size = new System.Drawing.Size(124, 99);
            this.ReadExcel.TabIndex = 1;
            this.ReadExcel.Text = "ReadExcel";
            this.ReadExcel.UseVisualStyleBackColor = true;
            this.ReadExcel.Click += new System.EventHandler(this.ReadExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Microsoft.Office.Interop.Excel を使用";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReadExcel);
            this.Controls.Add(this.OpenExcelBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenExcelBt;
        private System.Windows.Forms.Button ReadExcel;
        private System.Windows.Forms.Label label1;
    }
}

