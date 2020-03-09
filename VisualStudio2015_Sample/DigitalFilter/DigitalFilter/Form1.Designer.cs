namespace DigitalFilter
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonlowpass = new System.Windows.Forms.Button();
            this.buttonHigthpass = new System.Windows.Forms.Button();
            this.numericUpDownHz = new System.Windows.Forms.NumericUpDown();
            this.buttonMoveAve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMoveArv = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveArv)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(787, 364);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // buttonlowpass
            // 
            this.buttonlowpass.Location = new System.Drawing.Point(12, 499);
            this.buttonlowpass.Name = "buttonlowpass";
            this.buttonlowpass.Size = new System.Drawing.Size(138, 23);
            this.buttonlowpass.TabIndex = 1;
            this.buttonlowpass.Text = "ローパスﾌｨﾙﾀ";
            this.buttonlowpass.UseVisualStyleBackColor = true;
            this.buttonlowpass.Click += new System.EventHandler(this.buttonlowpass_Click);
            // 
            // buttonHigthpass
            // 
            this.buttonHigthpass.Location = new System.Drawing.Point(156, 499);
            this.buttonHigthpass.Name = "buttonHigthpass";
            this.buttonHigthpass.Size = new System.Drawing.Size(138, 23);
            this.buttonHigthpass.TabIndex = 2;
            this.buttonHigthpass.Text = "ハイパスﾌｨﾙﾀ";
            this.buttonHigthpass.UseVisualStyleBackColor = true;
            this.buttonHigthpass.Click += new System.EventHandler(this.buttonHigthpass_Click);
            // 
            // numericUpDownHz
            // 
            this.numericUpDownHz.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownHz.Location = new System.Drawing.Point(12, 528);
            this.numericUpDownHz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownHz.Name = "numericUpDownHz";
            this.numericUpDownHz.Size = new System.Drawing.Size(120, 19);
            this.numericUpDownHz.TabIndex = 3;
            this.numericUpDownHz.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // buttonMoveAve
            // 
            this.buttonMoveAve.Location = new System.Drawing.Point(300, 499);
            this.buttonMoveAve.Name = "buttonMoveAve";
            this.buttonMoveAve.Size = new System.Drawing.Size(138, 23);
            this.buttonMoveAve.TabIndex = 4;
            this.buttonMoveAve.Text = "移動平均";
            this.buttonMoveAve.UseVisualStyleBackColor = true;
            this.buttonMoveAve.Click += new System.EventHandler(this.buttonMoveAve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hz";
            // 
            // numericUpDownMoveArv
            // 
            this.numericUpDownMoveArv.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMoveArv.Location = new System.Drawing.Point(300, 535);
            this.numericUpDownMoveArv.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownMoveArv.Name = "numericUpDownMoveArv";
            this.numericUpDownMoveArv.Size = new System.Drawing.Size(62, 19);
            this.numericUpDownMoveArv.TabIndex = 6;
            this.numericUpDownMoveArv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Items.AddRange(new object[] {
            "500Hz",
            "600Hz",
            "700Hz",
            "800Hz",
            "900Hz",
            "1000Hz"});
            this.comboBoxFile.Location = new System.Drawing.Point(12, 413);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFile.TabIndex = 7;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(140, 413);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 23);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "ロード";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(268, 413);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(94, 23);
            this.buttonWrite.TabIndex = 9;
            this.buttonWrite.Text = "保存";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 559);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.comboBoxFile);
            this.Controls.Add(this.numericUpDownMoveArv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMoveAve);
            this.Controls.Add(this.numericUpDownHz);
            this.Controls.Add(this.buttonHigthpass);
            this.Controls.Add(this.buttonlowpass);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoveArv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonlowpass;
        private System.Windows.Forms.Button buttonHigthpass;
        private System.Windows.Forms.NumericUpDown numericUpDownHz;
        private System.Windows.Forms.Button buttonMoveAve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMoveArv;
        private System.Windows.Forms.ComboBox comboBoxFile;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonWrite;
    }
}

