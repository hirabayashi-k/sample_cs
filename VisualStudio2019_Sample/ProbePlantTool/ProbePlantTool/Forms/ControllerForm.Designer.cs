namespace Takt.ProbePlantTool.Forms
{
    partial class ControllerForm
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
            this.SpinButton = new System.Windows.Forms.Button();
            this.ZDownButton = new System.Windows.Forms.Button();
            this.ZUpButton = new System.Windows.Forms.Button();
            this.YDownButton = new System.Windows.Forms.Button();
            this.YUpButton = new System.Windows.Forms.Button();
            this.XDownButton = new System.Windows.Forms.Button();
            this.XUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SpinButton
            // 
            this.SpinButton.Image = global::Takt.ProbePlantTool.Properties.Resources.矢印アイコン;
            this.SpinButton.Location = new System.Drawing.Point(210, 366);
            this.SpinButton.Name = "SpinButton";
            this.SpinButton.Size = new System.Drawing.Size(75, 75);
            this.SpinButton.TabIndex = 6;
            this.SpinButton.UseVisualStyleBackColor = true;
            // 
            // ZDownButton
            // 
            this.ZDownButton.Image = global::Takt.ProbePlantTool.Properties.Resources.DOWN;
            this.ZDownButton.Location = new System.Drawing.Point(129, 366);
            this.ZDownButton.Name = "ZDownButton";
            this.ZDownButton.Size = new System.Drawing.Size(75, 75);
            this.ZDownButton.TabIndex = 5;
            this.ZDownButton.UseVisualStyleBackColor = true;
            // 
            // ZUpButton
            // 
            this.ZUpButton.Image = global::Takt.ProbePlantTool.Properties.Resources.UP;
            this.ZUpButton.Location = new System.Drawing.Point(48, 366);
            this.ZUpButton.Name = "ZUpButton";
            this.ZUpButton.Size = new System.Drawing.Size(75, 75);
            this.ZUpButton.TabIndex = 4;
            this.ZUpButton.UseVisualStyleBackColor = true;
            // 
            // YDownButton
            // 
            this.YDownButton.Image = global::Takt.ProbePlantTool.Properties.Resources.矢印アイコン左;
            this.YDownButton.Location = new System.Drawing.Point(6, 138);
            this.YDownButton.Name = "YDownButton";
            this.YDownButton.Size = new System.Drawing.Size(123, 75);
            this.YDownButton.TabIndex = 3;
            this.YDownButton.UseVisualStyleBackColor = true;
            // 
            // YUpButton
            // 
            this.YUpButton.Image = global::Takt.ProbePlantTool.Properties.Resources.矢印アイコン右;
            this.YUpButton.Location = new System.Drawing.Point(200, 138);
            this.YUpButton.Name = "YUpButton";
            this.YUpButton.Size = new System.Drawing.Size(123, 75);
            this.YUpButton.TabIndex = 2;
            this.YUpButton.UseVisualStyleBackColor = true;
            // 
            // XDownButton
            // 
            this.XDownButton.Image = global::Takt.ProbePlantTool.Properties.Resources.矢印アイコン下;
            this.XDownButton.Location = new System.Drawing.Point(128, 219);
            this.XDownButton.Name = "XDownButton";
            this.XDownButton.Size = new System.Drawing.Size(75, 123);
            this.XDownButton.TabIndex = 1;
            this.XDownButton.UseVisualStyleBackColor = true;
            // 
            // XUpButton
            // 
            this.XUpButton.Image = global::Takt.ProbePlantTool.Properties.Resources.矢印アイコン上;
            this.XUpButton.Location = new System.Drawing.Point(128, 9);
            this.XUpButton.Name = "XUpButton";
            this.XUpButton.Size = new System.Drawing.Size(75, 123);
            this.XUpButton.TabIndex = 0;
            this.XUpButton.UseVisualStyleBackColor = true;
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 452);
            this.Controls.Add(this.SpinButton);
            this.Controls.Add(this.ZDownButton);
            this.Controls.Add(this.ZUpButton);
            this.Controls.Add(this.YDownButton);
            this.Controls.Add(this.YUpButton);
            this.Controls.Add(this.XDownButton);
            this.Controls.Add(this.XUpButton);
            this.Name = "ControllerForm";
            this.Text = "ControllerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button XUpButton;
        private System.Windows.Forms.Button XDownButton;
        private System.Windows.Forms.Button YUpButton;
        private System.Windows.Forms.Button YDownButton;
        private System.Windows.Forms.Button ZUpButton;
        private System.Windows.Forms.Button ZDownButton;
        private System.Windows.Forms.Button SpinButton;
    }
}