namespace OpenCvSample.UserCon
{
    partial class GeneralBaseUserControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitlelLbel = new System.Windows.Forms.Label();
            this.ExplanationTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // TitlelLbel
            // 
            this.TitlelLbel.AutoSize = true;
            this.TitlelLbel.Location = new System.Drawing.Point(3, 18);
            this.TitlelLbel.Name = "TitlelLbel";
            this.TitlelLbel.Size = new System.Drawing.Size(41, 12);
            this.TitlelLbel.TabIndex = 0;
            this.TitlelLbel.Text = "解析名";
            // 
            // ExplanationTextBox
            // 
            this.ExplanationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExplanationTextBox.Location = new System.Drawing.Point(3, 48);
            this.ExplanationTextBox.Multiline = true;
            this.ExplanationTextBox.Name = "ExplanationTextBox";
            this.ExplanationTextBox.Size = new System.Drawing.Size(244, 129);
            this.ExplanationTextBox.TabIndex = 1;
            this.ExplanationTextBox.Text = "解析説明";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GeneralBaseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExplanationTextBox);
            this.Controls.Add(this.TitlelLbel);
            this.Name = "GeneralBaseUserControl";
            this.Size = new System.Drawing.Size(250, 300);
            this.Load += new System.EventHandler(this.GeneralBaseUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitlelLbel;
        private System.Windows.Forms.TextBox ExplanationTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
