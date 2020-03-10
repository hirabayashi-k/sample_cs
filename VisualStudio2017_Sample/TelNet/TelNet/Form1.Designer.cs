namespace TelNet
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
            this.ConectBt = new System.Windows.Forms.Button();
            this.Console_ListBox = new System.Windows.Forms.ListBox();
            this.SendData = new System.Windows.Forms.TextBox();
            this.SendBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConectBt
            // 
            this.ConectBt.Location = new System.Drawing.Point(83, 57);
            this.ConectBt.Name = "ConectBt";
            this.ConectBt.Size = new System.Drawing.Size(75, 23);
            this.ConectBt.TabIndex = 0;
            this.ConectBt.Text = "Conect";
            this.ConectBt.UseVisualStyleBackColor = true;
            this.ConectBt.Click += new System.EventHandler(this.ConectBt_Click);
            // 
            // Console_ListBox
            // 
            this.Console_ListBox.FormattingEnabled = true;
            this.Console_ListBox.ItemHeight = 12;
            this.Console_ListBox.Location = new System.Drawing.Point(83, 148);
            this.Console_ListBox.Name = "Console_ListBox";
            this.Console_ListBox.Size = new System.Drawing.Size(679, 88);
            this.Console_ListBox.TabIndex = 1;
            // 
            // SendData
            // 
            this.SendData.Location = new System.Drawing.Point(284, 61);
            this.SendData.Name = "SendData";
            this.SendData.Size = new System.Drawing.Size(185, 19);
            this.SendData.TabIndex = 2;
            // 
            // SendBt
            // 
            this.SendBt.Location = new System.Drawing.Point(475, 59);
            this.SendBt.Name = "SendBt";
            this.SendBt.Size = new System.Drawing.Size(75, 23);
            this.SendBt.TabIndex = 3;
            this.SendBt.Text = "Send";
            this.SendBt.UseVisualStyleBackColor = true;
            this.SendBt.Click += new System.EventHandler(this.SendBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendBt);
            this.Controls.Add(this.SendData);
            this.Controls.Add(this.Console_ListBox);
            this.Controls.Add(this.ConectBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConectBt;
        private System.Windows.Forms.ListBox Console_ListBox;
        private System.Windows.Forms.TextBox SendData;
        private System.Windows.Forms.Button SendBt;
    }
}

