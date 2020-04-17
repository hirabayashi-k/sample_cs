namespace OpenCvSample.UserCon
{
    partial class GammaUserControl
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
            this.GammaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GammaLabel = new System.Windows.Forms.Label();
            this.ExplanationTextBox = new System.Windows.Forms.TextBox();
            this.TitlelLbel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GammaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GammaNumericUpDown
            // 
            this.GammaNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GammaNumericUpDown.DecimalPlaces = 1;
            this.GammaNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.GammaNumericUpDown.Location = new System.Drawing.Point(5, 265);
            this.GammaNumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GammaNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.GammaNumericUpDown.Name = "GammaNumericUpDown";
            this.GammaNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.GammaNumericUpDown.TabIndex = 13;
            this.GammaNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // GammaLabel
            // 
            this.GammaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GammaLabel.AutoSize = true;
            this.GammaLabel.Location = new System.Drawing.Point(3, 249);
            this.GammaLabel.Name = "GammaLabel";
            this.GammaLabel.Size = new System.Drawing.Size(65, 12);
            this.GammaLabel.TabIndex = 12;
            this.GammaLabel.Text = "ガンマ値(γ)";
            // 
            // ExplanationTextBox
            // 
            this.ExplanationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExplanationTextBox.Location = new System.Drawing.Point(3, 47);
            this.ExplanationTextBox.Multiline = true;
            this.ExplanationTextBox.Name = "ExplanationTextBox";
            this.ExplanationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExplanationTextBox.Size = new System.Drawing.Size(244, 129);
            this.ExplanationTextBox.TabIndex = 9;
            this.ExplanationTextBox.Text = "解析説明";
            // 
            // TitlelLbel
            // 
            this.TitlelLbel.AutoSize = true;
            this.TitlelLbel.Location = new System.Drawing.Point(3, 17);
            this.TitlelLbel.Name = "TitlelLbel";
            this.TitlelLbel.Size = new System.Drawing.Size(41, 12);
            this.TitlelLbel.TabIndex = 8;
            this.TitlelLbel.Text = "解析名";
            // 
            // GammaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GammaNumericUpDown);
            this.Controls.Add(this.GammaLabel);
            this.Controls.Add(this.ExplanationTextBox);
            this.Controls.Add(this.TitlelLbel);
            this.Name = "GammaUserControl";
            this.Size = new System.Drawing.Size(250, 300);
            this.Load += new System.EventHandler(this.GammaUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GammaNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown GammaNumericUpDown;
        private System.Windows.Forms.Label GammaLabel;
        private System.Windows.Forms.TextBox ExplanationTextBox;
        private System.Windows.Forms.Label TitlelLbel;
    }
}
