namespace OpenCvSample
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.ExecListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.ExecButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ViewExecCheckBox = new System.Windows.Forms.CheckBox();
            this.ConversionListView = new System.Windows.Forms.ListView();
            this.AddButton = new System.Windows.Forms.Button();
            this.ConversionLabel = new System.Windows.Forms.Label();
            this.InputDataGeneralPanel = new System.Windows.Forms.Panel();
            this.ConversKindTabControl = new System.Windows.Forms.TabControl();
            this.InputDataGeneralPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "トリミング";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "グレースケール";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "bit反転";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 295);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "輪郭検出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(23, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "ガンマ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(23, 110);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "ヒストグラム";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(23, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "2値化";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(23, 168);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "2値化(トラックバー)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(23, 197);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "アファイン変換1";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(23, 226);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(94, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "アファイン変換2";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(23, 255);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(94, 23);
            this.button11.TabIndex = 10;
            this.button11.Text = "平滑化";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.AllowDrop = true;
            this.FileNameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileNameTextBox.Location = new System.Drawing.Point(104, 450);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(487, 26);
            this.FileNameTextBox.TabIndex = 11;
            this.FileNameTextBox.Text = "Sample1.jpg";
            this.FileNameTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileNameTextBox_DragDrop);
            this.FileNameTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileNameTextBox_DragEnter);
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileNameLabel.Location = new System.Drawing.Point(29, 456);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(69, 15);
            this.FileNameLabel.TabIndex = 12;
            this.FileNameLabel.Text = "ファイル名";
            // 
            // ExecListView
            // 
            this.ExecListView.HideSelection = false;
            this.ExecListView.Location = new System.Drawing.Point(680, 52);
            this.ExecListView.Name = "ExecListView";
            this.ExecListView.Size = new System.Drawing.Size(163, 373);
            this.ExecListView.TabIndex = 13;
            this.ExecListView.UseCompatibleStateImageBehavior = false;
            this.ExecListView.DoubleClick += new System.EventHandler(this.ExecListView_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(677, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "実行リスト";
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(859, 81);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 15;
            this.UpButton.Text = "↑";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(859, 168);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 23);
            this.DownButton.TabIndex = 16;
            this.DownButton.Text = "↓";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(859, 121);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(75, 23);
            this.DelButton.TabIndex = 17;
            this.DelButton.Text = "Del";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // ExecButton
            // 
            this.ExecButton.Location = new System.Drawing.Point(859, 335);
            this.ExecButton.Name = "ExecButton";
            this.ExecButton.Size = new System.Drawing.Size(75, 23);
            this.ExecButton.TabIndex = 18;
            this.ExecButton.Text = "実行";
            this.ExecButton.UseVisualStyleBackColor = true;
            this.ExecButton.Click += new System.EventHandler(this.ExecButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(32, 483);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.LogTextBox.Size = new System.Drawing.Size(559, 72);
            this.LogTextBox.TabIndex = 19;
            // 
            // ViewExecCheckBox
            // 
            this.ViewExecCheckBox.AutoSize = true;
            this.ViewExecCheckBox.Location = new System.Drawing.Point(849, 299);
            this.ViewExecCheckBox.Name = "ViewExecCheckBox";
            this.ViewExecCheckBox.Size = new System.Drawing.Size(94, 16);
            this.ViewExecCheckBox.TabIndex = 20;
            this.ViewExecCheckBox.Text = "ProgressView";
            this.ViewExecCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConversionListView
            // 
            this.ConversionListView.HideSelection = false;
            this.ConversionListView.Location = new System.Drawing.Point(428, 52);
            this.ConversionListView.Name = "ConversionListView";
            this.ConversionListView.Size = new System.Drawing.Size(163, 373);
            this.ConversionListView.TabIndex = 21;
            this.ConversionListView.UseCompatibleStateImageBehavior = false;
            this.ConversionListView.SelectedIndexChanged += new System.EventHandler(this.ConversionListView_SelectedIndexChanged);
            this.ConversionListView.TabIndexChanged += new System.EventHandler(this.ConversionListView_TabIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(599, 226);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "→";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ConversionLabel
            // 
            this.ConversionLabel.AutoSize = true;
            this.ConversionLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConversionLabel.Location = new System.Drawing.Point(425, 23);
            this.ConversionLabel.Name = "ConversionLabel";
            this.ConversionLabel.Size = new System.Drawing.Size(73, 15);
            this.ConversionLabel.TabIndex = 23;
            this.ConversionLabel.Text = "変換リスト";
            // 
            // InputDataGeneralPanel
            // 
            this.InputDataGeneralPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputDataGeneralPanel.Controls.Add(this.ConversKindTabControl);
            this.InputDataGeneralPanel.Location = new System.Drawing.Point(123, 52);
            this.InputDataGeneralPanel.Name = "InputDataGeneralPanel";
            this.InputDataGeneralPanel.Size = new System.Drawing.Size(299, 377);
            this.InputDataGeneralPanel.TabIndex = 24;
            // 
            // ConversKindTabControl
            // 
            this.ConversKindTabControl.Location = new System.Drawing.Point(3, 9);
            this.ConversKindTabControl.Name = "ConversKindTabControl";
            this.ConversKindTabControl.SelectedIndex = 0;
            this.ConversKindTabControl.Size = new System.Drawing.Size(291, 363);
            this.ConversKindTabControl.TabIndex = 0;
            this.ConversKindTabControl.SelectedIndexChanged += new System.EventHandler(this.ConversKindTabControl_SelectedIndexChanged);
            this.ConversKindTabControl.TabIndexChanged += new System.EventHandler(this.ConversKindTabControl_TabIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 567);
            this.Controls.Add(this.InputDataGeneralPanel);
            this.Controls.Add(this.ConversionLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ConversionListView);
            this.Controls.Add(this.ViewExecCheckBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.ExecButton);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExecListView);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.InputDataGeneralPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.ListView ExecListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button ExecButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.CheckBox ViewExecCheckBox;
        private System.Windows.Forms.ListView ConversionListView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label ConversionLabel;
        private System.Windows.Forms.Panel InputDataGeneralPanel;
        private System.Windows.Forms.TabControl ConversKindTabControl;
    }
}

