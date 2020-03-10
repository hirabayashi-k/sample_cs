namespace Serial
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Conect = new System.Windows.Forms.Button();
            this.LogRich = new System.Windows.Forms.RichTextBox();
            this.Send = new System.Windows.Forms.Button();
            this.Command = new System.Windows.Forms.TextBox();
            this.DisConect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Conect
            // 
            this.Conect.Location = new System.Drawing.Point(21, 12);
            this.Conect.Name = "Conect";
            this.Conect.Size = new System.Drawing.Size(75, 23);
            this.Conect.TabIndex = 0;
            this.Conect.Text = "接続";
            this.Conect.UseVisualStyleBackColor = true;
            this.Conect.Click += new System.EventHandler(this.Conect_Click);
            // 
            // LogRich
            // 
            this.LogRich.Location = new System.Drawing.Point(12, 89);
            this.LogRich.Name = "LogRich";
            this.LogRich.Size = new System.Drawing.Size(268, 172);
            this.LogRich.TabIndex = 1;
            this.LogRich.Text = "";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(21, 50);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "送信";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Command
            // 
            this.Command.Location = new System.Drawing.Point(118, 53);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(162, 19);
            this.Command.TabIndex = 3;
            // 
            // DisConect
            // 
            this.DisConect.Location = new System.Drawing.Point(118, 12);
            this.DisConect.Name = "DisConect";
            this.DisConect.Size = new System.Drawing.Size(75, 23);
            this.DisConect.TabIndex = 4;
            this.DisConect.Text = "切断";
            this.DisConect.UseVisualStyleBackColor = true;
            this.DisConect.Click += new System.EventHandler(this.DisConect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.DisConect);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.LogRich);
            this.Controls.Add(this.Conect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Conect;
        private System.Windows.Forms.RichTextBox LogRich;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox Command;
        private System.Windows.Forms.Button DisConect;
    }
}

