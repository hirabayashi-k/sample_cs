namespace OpenCvSample.UserCon
{
    partial class BinarizationUserControl
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
            this.ExplanationTextBox = new System.Windows.Forms.TextBox();
            this.TitlelLbel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ExplanationTextBox
            // 
            this.ExplanationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExplanationTextBox.Location = new System.Drawing.Point(3, 48);
            this.ExplanationTextBox.Multiline = true;
            this.ExplanationTextBox.Name = "ExplanationTextBox";
            this.ExplanationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExplanationTextBox.Size = new System.Drawing.Size(244, 129);
            this.ExplanationTextBox.TabIndex = 3;
            this.ExplanationTextBox.Text = "解析説明";
            // 
            // TitlelLbel
            // 
            this.TitlelLbel.AutoSize = true;
            this.TitlelLbel.Location = new System.Drawing.Point(3, 18);
            this.TitlelLbel.Name = "TitlelLbel";
            this.TitlelLbel.Size = new System.Drawing.Size(41, 12);
            this.TitlelLbel.TabIndex = 2;
            this.TitlelLbel.Text = "解析名";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(3, 212);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(162, 20);
            this.TypeComboBox.TabIndex = 4;
            // 
            // TypeLabel
            // 
            this.TypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(3, 197);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(55, 12);
            this.TypeLabel.TabIndex = 5;
            this.TypeLabel.Text = "解析タイプ";
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(3, 250);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(29, 12);
            this.ThresholdLabel.TabIndex = 6;
            this.ThresholdLabel.Text = "閾値";
            // 
            // ThresholdNumericUpDown
            // 
            this.ThresholdNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ThresholdNumericUpDown.Location = new System.Drawing.Point(5, 266);
            this.ThresholdNumericUpDown.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.ThresholdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThresholdNumericUpDown.Name = "ThresholdNumericUpDown";
            this.ThresholdNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.ThresholdNumericUpDown.TabIndex = 7;
            this.ThresholdNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // BinarizationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThresholdNumericUpDown);
            this.Controls.Add(this.ThresholdLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.ExplanationTextBox);
            this.Controls.Add(this.TitlelLbel);
            this.Name = "BinarizationUserControl";
            this.Size = new System.Drawing.Size(250, 300);
            this.Load += new System.EventHandler(this.BinarizationUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExplanationTextBox;
        private System.Windows.Forms.Label TitlelLbel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.NumericUpDown ThresholdNumericUpDown;
    }
}
