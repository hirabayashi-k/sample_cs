namespace Takt.ProbePlantTool.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingTextBox = new System.Windows.Forms.TextBox();
            this.SettingLabel = new System.Windows.Forms.Label();
            this.SettingDataGridView = new System.Windows.Forms.DataGridView();
            this.SettingDataLabel1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PinBordPanel = new System.Windows.Forms.Panel();
            this.PinBordPictureBox = new System.Windows.Forms.PictureBox();
            this.PinBordLabel = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PinBordHigthTextBox = new System.Windows.Forms.TextBox();
            this.PinBordWidthTextBox = new System.Windows.Forms.TextBox();
            this.HigthLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.OkNgTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SettingDataGridView)).BeginInit();
            this.PinBordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PinBordPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingTextBox
            // 
            this.SettingTextBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingTextBox.Location = new System.Drawing.Point(35, 38);
            this.SettingTextBox.Name = "SettingTextBox";
            this.SettingTextBox.Size = new System.Drawing.Size(362, 34);
            this.SettingTextBox.TabIndex = 0;
            this.SettingTextBox.Text = "設定ファイル名";
            // 
            // SettingLabel
            // 
            this.SettingLabel.AutoSize = true;
            this.SettingLabel.Location = new System.Drawing.Point(33, 23);
            this.SettingLabel.Name = "SettingLabel";
            this.SettingLabel.Size = new System.Drawing.Size(63, 12);
            this.SettingLabel.TabIndex = 1;
            this.SettingLabel.Text = "設定ファイル";
            // 
            // SettingDataGridView
            // 
            this.SettingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SettingDataGridView.Location = new System.Drawing.Point(35, 136);
            this.SettingDataGridView.Name = "SettingDataGridView";
            this.SettingDataGridView.RowTemplate.Height = 21;
            this.SettingDataGridView.Size = new System.Drawing.Size(362, 586);
            this.SettingDataGridView.TabIndex = 2;
            this.SettingDataGridView.CurrentCellChanged += new System.EventHandler(this.SettingDataGridView_CurrentCellChanged);
            this.SettingDataGridView.SelectionChanged += new System.EventHandler(this.SettingDataGridView_SelectionChanged);
            // 
            // SettingDataLabel1
            // 
            this.SettingDataLabel1.AutoSize = true;
            this.SettingDataLabel1.Location = new System.Drawing.Point(33, 121);
            this.SettingDataLabel1.Name = "SettingDataLabel1";
            this.SettingDataLabel1.Size = new System.Drawing.Size(63, 12);
            this.SettingDataLabel1.TabIndex = 3;
            this.SettingDataLabel1.Text = "設定ファイル";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartButton.Location = new System.Drawing.Point(413, 23);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(138, 60);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StopButton.Location = new System.Drawing.Point(557, 23);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(138, 60);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PinBordPanel
            // 
            this.PinBordPanel.BackColor = System.Drawing.Color.White;
            this.PinBordPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PinBordPanel.Controls.Add(this.PinBordPictureBox);
            this.PinBordPanel.Location = new System.Drawing.Point(403, 136);
            this.PinBordPanel.Name = "PinBordPanel";
            this.PinBordPanel.Size = new System.Drawing.Size(879, 586);
            this.PinBordPanel.TabIndex = 6;
            // 
            // PinBordPictureBox
            // 
            this.PinBordPictureBox.Location = new System.Drawing.Point(8, 4);
            this.PinBordPictureBox.Name = "PinBordPictureBox";
            this.PinBordPictureBox.Size = new System.Drawing.Size(100, 50);
            this.PinBordPictureBox.TabIndex = 0;
            this.PinBordPictureBox.TabStop = false;
            // 
            // PinBordLabel
            // 
            this.PinBordLabel.AutoSize = true;
            this.PinBordLabel.Location = new System.Drawing.Point(411, 101);
            this.PinBordLabel.Name = "PinBordLabel";
            this.PinBordLabel.Size = new System.Drawing.Size(52, 12);
            this.PinBordLabel.TabIndex = 7;
            this.PinBordLabel.Text = "ピンボード";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(35, 90);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 8;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PinBordHigthTextBox
            // 
            this.PinBordHigthTextBox.Location = new System.Drawing.Point(572, 101);
            this.PinBordHigthTextBox.Name = "PinBordHigthTextBox";
            this.PinBordHigthTextBox.Size = new System.Drawing.Size(100, 19);
            this.PinBordHigthTextBox.TabIndex = 9;
            this.PinBordHigthTextBox.Text = "1000";
            // 
            // PinBordWidthTextBox
            // 
            this.PinBordWidthTextBox.Location = new System.Drawing.Point(744, 104);
            this.PinBordWidthTextBox.Name = "PinBordWidthTextBox";
            this.PinBordWidthTextBox.Size = new System.Drawing.Size(100, 19);
            this.PinBordWidthTextBox.TabIndex = 10;
            this.PinBordWidthTextBox.Text = "1500";
            // 
            // HigthLabel
            // 
            this.HigthLabel.AutoSize = true;
            this.HigthLabel.Location = new System.Drawing.Point(514, 104);
            this.HigthLabel.Name = "HigthLabel";
            this.HigthLabel.Size = new System.Drawing.Size(32, 12);
            this.HigthLabel.TabIndex = 11;
            this.HigthLabel.Text = "Higth";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(706, 107);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(33, 12);
            this.WidthLabel.TabIndex = 12;
            this.WidthLabel.Text = "Width";
            // 
            // OkNgTextBox
            // 
            this.OkNgTextBox.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OkNgTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.OkNgTextBox.Location = new System.Drawing.Point(1178, 23);
            this.OkNgTextBox.Name = "OkNgTextBox";
            this.OkNgTextBox.Size = new System.Drawing.Size(104, 71);
            this.OkNgTextBox.TabIndex = 13;
            this.OkNgTextBox.Text = "OK";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 734);
            this.Controls.Add(this.OkNgTextBox);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HigthLabel);
            this.Controls.Add(this.PinBordWidthTextBox);
            this.Controls.Add(this.PinBordHigthTextBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.PinBordLabel);
            this.Controls.Add(this.PinBordPanel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SettingDataLabel1);
            this.Controls.Add(this.SettingDataGridView);
            this.Controls.Add(this.SettingLabel);
            this.Controls.Add(this.SettingTextBox);
            this.Name = "MainForm";
            this.Text = "ProbePlantTool";
            ((System.ComponentModel.ISupportInitialize)(this.SettingDataGridView)).EndInit();
            this.PinBordPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PinBordPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SettingTextBox;
        private System.Windows.Forms.Label SettingLabel;
        private System.Windows.Forms.DataGridView SettingDataGridView;
        private System.Windows.Forms.Label SettingDataLabel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Panel PinBordPanel;
        private System.Windows.Forms.Label PinBordLabel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox PinBordHigthTextBox;
        private System.Windows.Forms.TextBox PinBordWidthTextBox;
        private System.Windows.Forms.Label HigthLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.PictureBox PinBordPictureBox;
        private System.Windows.Forms.TextBox OkNgTextBox;
    }
}