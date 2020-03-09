namespace ChartControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_TEST = new System.Windows.Forms.Button();
            this.buttonTest2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTEST3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonTest4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonTest6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button_TEST
            // 
            this.button_TEST.Location = new System.Drawing.Point(351, 24);
            this.button_TEST.Name = "button_TEST";
            this.button_TEST.Size = new System.Drawing.Size(75, 23);
            this.button_TEST.TabIndex = 1;
            this.button_TEST.Text = "TEST";
            this.button_TEST.UseVisualStyleBackColor = true;
            this.button_TEST.Click += new System.EventHandler(this.button_TEST_Click);
            // 
            // buttonTest2
            // 
            this.buttonTest2.Location = new System.Drawing.Point(351, 53);
            this.buttonTest2.Name = "buttonTest2";
            this.buttonTest2.Size = new System.Drawing.Size(75, 23);
            this.buttonTest2.TabIndex = 2;
            this.buttonTest2.Text = "TEST2";
            this.buttonTest2.UseVisualStyleBackColor = true;
            this.buttonTest2.Click += new System.EventHandler(this.buttonTest2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 254);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 3;
            // 
            // buttonTEST3
            // 
            this.buttonTEST3.Location = new System.Drawing.Point(351, 82);
            this.buttonTEST3.Name = "buttonTEST3";
            this.buttonTEST3.Size = new System.Drawing.Size(100, 23);
            this.buttonTEST3.TabIndex = 4;
            this.buttonTEST3.Text = "TEST3(例外)";
            this.buttonTEST3.UseVisualStyleBackColor = true;
            this.buttonTEST3.Click += new System.EventHandler(this.buttonTEST3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(351, 302);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 5;
            // 
            // buttonTest4
            // 
            this.buttonTest4.Location = new System.Drawing.Point(351, 111);
            this.buttonTest4.Name = "buttonTest4";
            this.buttonTest4.Size = new System.Drawing.Size(100, 23);
            this.buttonTest4.TabIndex = 6;
            this.buttonTest4.Text = "TEST4(例外)";
            this.buttonTest4.UseVisualStyleBackColor = true;
            this.buttonTest4.Click += new System.EventHandler(this.buttonTest4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "TEST5(例外)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonTest6
            // 
            this.buttonTest6.Location = new System.Drawing.Point(351, 169);
            this.buttonTest6.Name = "buttonTest6";
            this.buttonTest6.Size = new System.Drawing.Size(100, 23);
            this.buttonTest6.TabIndex = 8;
            this.buttonTest6.Text = "TEST6";
            this.buttonTest6.UseVisualStyleBackColor = true;
            this.buttonTest6.Click += new System.EventHandler(this.buttonTest6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "TEST7";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "ChartTEST";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(511, 12);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(373, 342);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(511, 360);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "データ取得";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(511, 442);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(300, 101);
            this.textBox3.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(589, 360);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "シリアル化セーブ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(695, 360);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "シリアル化ロード";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(511, 399);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "チャートセーブ";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(627, 399);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "画面セーブ";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(122, 318);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // chart3
            // 
            chartArea9.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chart3.Legends.Add(legend9);
            this.chart3.Location = new System.Drawing.Point(12, 374);
            this.chart3.Name = "chart3";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chart3.Series.Add(series9);
            this.chart3.Size = new System.Drawing.Size(439, 185);
            this.chart3.TabIndex = 19;
            this.chart3.Text = "chart3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "横棒　積み上げグラフ";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(15, 572);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(105, 23);
            this.button10.TabIndex = 21;
            this.button10.Text = "積み上げ追加";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(163, 572);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(105, 23);
            this.button11.TabIndex = 22;
            this.button11.Text = "データ追加";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 607);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonTest6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTest4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonTEST3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonTest2);
            this.Controls.Add(this.button_TEST);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_TEST;
        private System.Windows.Forms.Button buttonTest2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonTEST3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonTest4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTest6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

