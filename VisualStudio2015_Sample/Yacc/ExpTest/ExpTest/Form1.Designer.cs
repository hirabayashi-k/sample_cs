﻿namespace ExpTest
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.exprTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.javaScriptButton = new System.Windows.Forms.Button();
            this.jscriptButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.vbscriptButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exprTextBox
            // 
            this.exprTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.exprTextBox.Location = new System.Drawing.Point(0, 40);
            this.exprTextBox.Multiline = true;
            this.exprTextBox.Name = "exprTextBox";
            this.exprTextBox.Size = new System.Drawing.Size(240, 492);
            this.exprTextBox.TabIndex = 1;
            this.exprTextBox.Text = resources.GetString("exprTextBox.Text");
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(243, 40);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(401, 492);
            this.logTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.javaScriptButton);
            this.panel1.Controls.Add(this.jscriptButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.vbscriptButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 40);
            this.panel1.TabIndex = 0;
            // 
            // javaScriptButton
            // 
            this.javaScriptButton.Location = new System.Drawing.Point(168, 8);
            this.javaScriptButton.Name = "javaScriptButton";
            this.javaScriptButton.Size = new System.Drawing.Size(75, 23);
            this.javaScriptButton.TabIndex = 0;
            this.javaScriptButton.Text = "JavaScript";
            this.javaScriptButton.UseVisualStyleBackColor = true;
            this.javaScriptButton.Click += new System.EventHandler(this.javaScriptButton_Click);
            // 
            // jscriptButton
            // 
            this.jscriptButton.Location = new System.Drawing.Point(88, 8);
            this.jscriptButton.Name = "jscriptButton";
            this.jscriptButton.Size = new System.Drawing.Size(75, 23);
            this.jscriptButton.TabIndex = 2;
            this.jscriptButton.Text = "JScript";
            this.jscriptButton.UseVisualStyleBackColor = true;
            this.jscriptButton.Click += new System.EventHandler(this.jscriptButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(560, 8);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // vbscriptButton
            // 
            this.vbscriptButton.Location = new System.Drawing.Point(8, 8);
            this.vbscriptButton.Name = "vbscriptButton";
            this.vbscriptButton.Size = new System.Drawing.Size(75, 23);
            this.vbscriptButton.TabIndex = 1;
            this.vbscriptButton.Text = "VBScript";
            this.vbscriptButton.UseVisualStyleBackColor = true;
            this.vbscriptButton.Click += new System.EventHandler(this.vbscriptButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(240, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 492);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 532);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.exprTextBox);
            this.Controls.Add(this.panel1);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox exprTextBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button jscriptButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button vbscriptButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button javaScriptButton;
    }
}

