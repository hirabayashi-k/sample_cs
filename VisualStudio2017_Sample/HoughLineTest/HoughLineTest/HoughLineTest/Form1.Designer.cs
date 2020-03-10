namespace HoughLineTest
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
            this.components = new System.ComponentModel.Container();
            this.buttonFileOpen = new System.Windows.Forms.Button();
            this.buttonFolderOpen = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.textBoxFolderName = new System.Windows.Forms.TextBox();
            this.textBoxFilterSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHoughThreshold = new System.Windows.Forms.TextBox();
            this.textBoxHoughParam1 = new System.Windows.Forms.TextBox();
            this.textBoxHoughParam2 = new System.Windows.Forms.TextBox();
            this.checkBoxSrcImg = new System.Windows.Forms.CheckBox();
            this.checkBoxNormalizeImage = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterImage = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCannyParam1 = new System.Windows.Forms.TextBox();
            this.textBoxCannyParam2 = new System.Windows.Forms.TextBox();
            this.checkBoxCannyImage = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.buttonPWrite = new System.Windows.Forms.Button();
            this.buttonPRead = new System.Windows.Forms.Button();
            this.textBoxMaxTilt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxIAX1 = new System.Windows.Forms.TextBox();
            this.textBoxIAX2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxIAY1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxIAY2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxOffsetY2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOffsetY1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxOffsetX2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxOffsetX1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxp1p2distance = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.CloseBt = new System.Windows.Forms.Button();
            this.LogTb = new System.Windows.Forms.TextBox();
            this.checkBatchSave = new System.Windows.Forms.CheckBox();
            this.ClearLogBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFileOpen
            // 
            this.buttonFileOpen.Location = new System.Drawing.Point(12, 12);
            this.buttonFileOpen.Name = "buttonFileOpen";
            this.buttonFileOpen.Size = new System.Drawing.Size(116, 36);
            this.buttonFileOpen.TabIndex = 8;
            this.buttonFileOpen.Text = "File Open...";
            this.buttonFileOpen.UseVisualStyleBackColor = true;
            this.buttonFileOpen.Click += new System.EventHandler(this.buttonFileOpen_Click);
            // 
            // buttonFolderOpen
            // 
            this.buttonFolderOpen.Location = new System.Drawing.Point(12, 54);
            this.buttonFolderOpen.Name = "buttonFolderOpen";
            this.buttonFolderOpen.Size = new System.Drawing.Size(116, 36);
            this.buttonFolderOpen.TabIndex = 9;
            this.buttonFolderOpen.Text = "Folder Open...";
            this.buttonFolderOpen.UseVisualStyleBackColor = true;
            this.buttonFolderOpen.Click += new System.EventHandler(this.buttonFolderOpen_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.AllowDrop = true;
            this.textBoxFileName.Location = new System.Drawing.Point(134, 29);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(411, 19);
            this.textBoxFileName.TabIndex = 2;
            this.textBoxFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragDrop);
            this.textBoxFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileName_DragEnter);
            // 
            // textBoxFolderName
            // 
            this.textBoxFolderName.Location = new System.Drawing.Point(134, 71);
            this.textBoxFolderName.Name = "textBoxFolderName";
            this.textBoxFolderName.Size = new System.Drawing.Size(411, 19);
            this.textBoxFolderName.TabIndex = 3;
            // 
            // textBoxFilterSize
            // 
            this.textBoxFilterSize.Location = new System.Drawing.Point(150, 115);
            this.textBoxFilterSize.Name = "textBoxFilterSize";
            this.textBoxFilterSize.Size = new System.Drawing.Size(81, 19);
            this.textBoxFilterSize.TabIndex = 1;
            this.textBoxFilterSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilterSize_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "平滑サイズ(画像のぼかし )";
            this.toolTip1.SetToolTip(this.label1, "ガウシアンフィルタのフィルターサイズ。通常、1〜50程度の範囲で指定します。ゼロを指定するとガウシアンフィルターは実行されません。マイナス値は指定できません。");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hough 閾値";
            this.toolTip1.SetToolTip(this.label2, "ハフ変換の閾値です。マイナス値は指定できません。");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hough Param1";
            this.toolTip1.SetToolTip(this.label3, "ハフ変換のパラメータ１（線長最小値）です。");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hough Param2";
            this.toolTip1.SetToolTip(this.label4, "ハフ変換のパラメータ２（同一線長と判断する最長距離）です。");
            // 
            // textBoxHoughThreshold
            // 
            this.textBoxHoughThreshold.Location = new System.Drawing.Point(150, 235);
            this.textBoxHoughThreshold.Name = "textBoxHoughThreshold";
            this.textBoxHoughThreshold.Size = new System.Drawing.Size(81, 19);
            this.textBoxHoughThreshold.TabIndex = 5;
            this.textBoxHoughThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoughThreshold_KeyPress);
            // 
            // textBoxHoughParam1
            // 
            this.textBoxHoughParam1.Location = new System.Drawing.Point(150, 262);
            this.textBoxHoughParam1.Name = "textBoxHoughParam1";
            this.textBoxHoughParam1.Size = new System.Drawing.Size(81, 19);
            this.textBoxHoughParam1.TabIndex = 6;
            this.textBoxHoughParam1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoughParam1_KeyPress);
            // 
            // textBoxHoughParam2
            // 
            this.textBoxHoughParam2.Location = new System.Drawing.Point(150, 286);
            this.textBoxHoughParam2.Name = "textBoxHoughParam2";
            this.textBoxHoughParam2.Size = new System.Drawing.Size(81, 19);
            this.textBoxHoughParam2.TabIndex = 7;
            this.textBoxHoughParam2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoughParam2_KeyPress);
            // 
            // checkBoxSrcImg
            // 
            this.checkBoxSrcImg.AutoSize = true;
            this.checkBoxSrcImg.Location = new System.Drawing.Point(256, 117);
            this.checkBoxSrcImg.Name = "checkBoxSrcImg";
            this.checkBoxSrcImg.Size = new System.Drawing.Size(93, 16);
            this.checkBoxSrcImg.TabIndex = 10;
            this.checkBoxSrcImg.Text = "Source Image";
            this.checkBoxSrcImg.UseVisualStyleBackColor = true;
            // 
            // checkBoxNormalizeImage
            // 
            this.checkBoxNormalizeImage.AutoSize = true;
            this.checkBoxNormalizeImage.Location = new System.Drawing.Point(256, 143);
            this.checkBoxNormalizeImage.Name = "checkBoxNormalizeImage";
            this.checkBoxNormalizeImage.Size = new System.Drawing.Size(108, 16);
            this.checkBoxNormalizeImage.TabIndex = 11;
            this.checkBoxNormalizeImage.Text = "Normalize Image";
            this.checkBoxNormalizeImage.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterImage
            // 
            this.checkBoxFilterImage.AutoSize = true;
            this.checkBoxFilterImage.Location = new System.Drawing.Point(256, 169);
            this.checkBoxFilterImage.Name = "checkBoxFilterImage";
            this.checkBoxFilterImage.Size = new System.Drawing.Size(85, 16);
            this.checkBoxFilterImage.TabIndex = 12;
            this.checkBoxFilterImage.Text = "Filter Image";
            this.checkBoxFilterImage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Canny Param1";
            this.toolTip1.SetToolTip(this.label5, "エッジ検出のCannyアルゴリズムの閾値1です。マイナス値は指定できません。");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Canny Param2";
            this.toolTip1.SetToolTip(this.label6, "エッジ検出のCannyアルゴリズムの閾値２です。マイナス値は指定できません。");
            // 
            // textBoxCannyParam1
            // 
            this.textBoxCannyParam1.Location = new System.Drawing.Point(150, 171);
            this.textBoxCannyParam1.Name = "textBoxCannyParam1";
            this.textBoxCannyParam1.Size = new System.Drawing.Size(81, 19);
            this.textBoxCannyParam1.TabIndex = 3;
            this.textBoxCannyParam1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCannyParam1_KeyPress);
            // 
            // textBoxCannyParam2
            // 
            this.textBoxCannyParam2.Location = new System.Drawing.Point(150, 199);
            this.textBoxCannyParam2.Name = "textBoxCannyParam2";
            this.textBoxCannyParam2.Size = new System.Drawing.Size(81, 19);
            this.textBoxCannyParam2.TabIndex = 4;
            this.textBoxCannyParam2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCannyParam2_KeyPress);
            // 
            // checkBoxCannyImage
            // 
            this.checkBoxCannyImage.AutoSize = true;
            this.checkBoxCannyImage.Location = new System.Drawing.Point(256, 195);
            this.checkBoxCannyImage.Name = "checkBoxCannyImage";
            this.checkBoxCannyImage.Size = new System.Drawing.Size(90, 16);
            this.checkBoxCannyImage.TabIndex = 13;
            this.checkBoxCannyImage.Text = "Canny Image";
            this.checkBoxCannyImage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "2値化 Threshold";
            this.toolTip1.SetToolTip(this.label7, "2値化の閾値を指定します。0〜255の範囲で指定します。マイナス値は指定できません。");
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(150, 143);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(81, 19);
            this.textBoxThreshold.TabIndex = 2;
            this.textBoxThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxThreshold_KeyPress);
            // 
            // buttonPWrite
            // 
            this.buttonPWrite.Location = new System.Drawing.Point(371, 115);
            this.buttonPWrite.Name = "buttonPWrite";
            this.buttonPWrite.Size = new System.Drawing.Size(117, 28);
            this.buttonPWrite.TabIndex = 21;
            this.buttonPWrite.Text = "Parameter Write";
            this.buttonPWrite.UseVisualStyleBackColor = true;
            this.buttonPWrite.Click += new System.EventHandler(this.buttonPWrite_Click);
            // 
            // buttonPRead
            // 
            this.buttonPRead.AllowDrop = true;
            this.buttonPRead.Location = new System.Drawing.Point(371, 158);
            this.buttonPRead.Name = "buttonPRead";
            this.buttonPRead.Size = new System.Drawing.Size(117, 28);
            this.buttonPRead.TabIndex = 22;
            this.buttonPRead.Text = "Parameter Read";
            this.buttonPRead.UseVisualStyleBackColor = true;
            this.buttonPRead.Click += new System.EventHandler(this.buttonPRead_Click);
            this.buttonPRead.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonPRead_DragDrop);
            this.buttonPRead.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonPRead_DragEnter);
            // 
            // textBoxMaxTilt
            // 
            this.textBoxMaxTilt.Location = new System.Drawing.Point(150, 320);
            this.textBoxMaxTilt.Name = "textBoxMaxTilt";
            this.textBoxMaxTilt.Size = new System.Drawing.Size(81, 19);
            this.textBoxMaxTilt.TabIndex = 23;
            this.textBoxMaxTilt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxTilt_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Max Tilt";
            this.toolTip1.SetToolTip(this.label8, "斜め線を排除するための最大角度です。（degree表記）");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "Invalid Area";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(81, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "X1";
            this.toolTip1.SetToolTip(this.label10, "直線検出させたくない左端の領域（pixcel）");
            // 
            // textBoxIAX1
            // 
            this.textBoxIAX1.Location = new System.Drawing.Point(105, 355);
            this.textBoxIAX1.Name = "textBoxIAX1";
            this.textBoxIAX1.Size = new System.Drawing.Size(46, 19);
            this.textBoxIAX1.TabIndex = 27;
            this.textBoxIAX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIAX1_KeyPress);
            // 
            // textBoxIAX2
            // 
            this.textBoxIAX2.Location = new System.Drawing.Point(181, 355);
            this.textBoxIAX2.Name = "textBoxIAX2";
            this.textBoxIAX2.Size = new System.Drawing.Size(46, 19);
            this.textBoxIAX2.TabIndex = 29;
            this.textBoxIAX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIAX2_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "X2";
            this.toolTip1.SetToolTip(this.label11, "直線検出させたくない右端の領域（pixcel）");
            // 
            // textBoxIAY1
            // 
            this.textBoxIAY1.Location = new System.Drawing.Point(257, 355);
            this.textBoxIAY1.Name = "textBoxIAY1";
            this.textBoxIAY1.Size = new System.Drawing.Size(46, 19);
            this.textBoxIAY1.TabIndex = 31;
            this.textBoxIAY1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIAY1_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "Y1";
            this.toolTip1.SetToolTip(this.label12, "直線検出させたくない上端の領域（pixcel）");
            // 
            // textBoxIAY2
            // 
            this.textBoxIAY2.Location = new System.Drawing.Point(333, 355);
            this.textBoxIAY2.Name = "textBoxIAY2";
            this.textBoxIAY2.Size = new System.Drawing.Size(46, 19);
            this.textBoxIAY2.TabIndex = 33;
            this.textBoxIAY2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIAY2_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(309, 358);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "Y2";
            this.toolTip1.SetToolTip(this.label13, "直線検出させたくない下端の領域（pixcel）");
            // 
            // textBoxOffsetY2
            // 
            this.textBoxOffsetY2.Location = new System.Drawing.Point(333, 391);
            this.textBoxOffsetY2.Name = "textBoxOffsetY2";
            this.textBoxOffsetY2.Size = new System.Drawing.Size(46, 19);
            this.textBoxOffsetY2.TabIndex = 42;
            this.textBoxOffsetY2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOffseetY2_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(309, 394);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 12);
            this.label14.TabIndex = 41;
            this.label14.Text = "Y2";
            this.toolTip1.SetToolTip(this.label14, "検出した直線座標の下端Y座標にオフセットを付ける（pixcel）");
            // 
            // textBoxOffsetY1
            // 
            this.textBoxOffsetY1.Location = new System.Drawing.Point(257, 391);
            this.textBoxOffsetY1.Name = "textBoxOffsetY1";
            this.textBoxOffsetY1.Size = new System.Drawing.Size(46, 19);
            this.textBoxOffsetY1.TabIndex = 40;
            this.textBoxOffsetY1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOffseetY1_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(233, 394);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 12);
            this.label15.TabIndex = 39;
            this.label15.Text = "Y1";
            this.toolTip1.SetToolTip(this.label15, "検出した直線座標の上端Y座標にオフセットを付ける（pixcel）");
            // 
            // textBoxOffsetX2
            // 
            this.textBoxOffsetX2.Location = new System.Drawing.Point(181, 391);
            this.textBoxOffsetX2.Name = "textBoxOffsetX2";
            this.textBoxOffsetX2.Size = new System.Drawing.Size(46, 19);
            this.textBoxOffsetX2.TabIndex = 38;
            this.textBoxOffsetX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOffseetX2_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(157, 394);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "X2";
            this.toolTip1.SetToolTip(this.label16, "検出した直線座標の左端X座標にオフセットを付ける（pixcel）");
            // 
            // textBoxOffsetX1
            // 
            this.textBoxOffsetX1.Location = new System.Drawing.Point(105, 391);
            this.textBoxOffsetX1.Name = "textBoxOffsetX1";
            this.textBoxOffsetX1.Size = new System.Drawing.Size(46, 19);
            this.textBoxOffsetX1.TabIndex = 36;
            this.textBoxOffsetX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOffseetX1_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(81, 394);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 12);
            this.label17.TabIndex = 35;
            this.label17.Text = "X1";
            this.toolTip1.SetToolTip(this.label17, "検出した直線座標の右端X座標にオフセットを付ける（pixcel）");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 394);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 12);
            this.label18.TabIndex = 34;
            this.label18.Text = "Offset";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 424);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 12);
            this.label19.TabIndex = 43;
            this.label19.Text = "R";
            this.toolTip1.SetToolTip(this.label19, "容器のコーナー（Ｒ）の半径");
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(38, 421);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(51, 19);
            this.textBoxR.TabIndex = 44;
            this.textBoxR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxR_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(160, 424);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 12);
            this.label20.TabIndex = 45;
            this.label20.Text = "p1-p2 Distance";
            this.toolTip1.SetToolTip(this.label20, "マスク領域の最小範囲（ピクセル数で正方形の領域を表現します）");
            // 
            // textBoxp1p2distance
            // 
            this.textBoxp1p2distance.Location = new System.Drawing.Point(250, 421);
            this.textBoxp1p2distance.Name = "textBoxp1p2distance";
            this.textBoxp1p2distance.Size = new System.Drawing.Size(53, 19);
            this.textBoxp1p2distance.TabIndex = 46;
            this.textBoxp1p2distance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxp1p2distance_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(395, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 49;
            this.label21.Text = "Log";
            this.toolTip1.SetToolTip(this.label21, "エッジ検出のCannyアルゴリズムの閾値２です。マイナス値は指定できません。");
            // 
            // CloseBt
            // 
            this.CloseBt.AllowDrop = true;
            this.CloseBt.Location = new System.Drawing.Point(456, 412);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(117, 28);
            this.CloseBt.TabIndex = 47;
            this.CloseBt.Text = "Close";
            this.CloseBt.UseVisualStyleBackColor = true;
            this.CloseBt.Click += new System.EventHandler(this.CloseBt_Click);
            // 
            // LogTb
            // 
            this.LogTb.Location = new System.Drawing.Point(397, 231);
            this.LogTb.Multiline = true;
            this.LogTb.Name = "LogTb";
            this.LogTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTb.Size = new System.Drawing.Size(176, 175);
            this.LogTb.TabIndex = 48;
            this.LogTb.WordWrap = false;
            // 
            // checkBatchSave
            // 
            this.checkBatchSave.AutoSize = true;
            this.checkBatchSave.Location = new System.Drawing.Point(256, 251);
            this.checkBatchSave.Name = "checkBatchSave";
            this.checkBatchSave.Size = new System.Drawing.Size(83, 16);
            this.checkBatchSave.TabIndex = 50;
            this.checkBatchSave.Text = "Batch Save";
            this.checkBatchSave.UseVisualStyleBackColor = true;
            // 
            // ClearLogBt
            // 
            this.ClearLogBt.Location = new System.Drawing.Point(495, 202);
            this.ClearLogBt.Name = "ClearLogBt";
            this.ClearLogBt.Size = new System.Drawing.Size(59, 23);
            this.ClearLogBt.TabIndex = 51;
            this.ClearLogBt.Text = "Clear";
            this.ClearLogBt.UseVisualStyleBackColor = true;
            this.ClearLogBt.Click += new System.EventHandler(this.ClearLogBt_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 447);
            this.Controls.Add(this.ClearLogBt);
            this.Controls.Add(this.checkBatchSave);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.LogTb);
            this.Controls.Add(this.CloseBt);
            this.Controls.Add(this.textBoxp1p2distance);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxR);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxOffsetY2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxOffsetY1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxOffsetX2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxOffsetX1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBoxIAY2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxIAY1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxIAX2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxIAX1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxMaxTilt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonPRead);
            this.Controls.Add(this.buttonPWrite);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBoxCannyImage);
            this.Controls.Add(this.textBoxCannyParam2);
            this.Controls.Add(this.textBoxCannyParam1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxFilterImage);
            this.Controls.Add(this.checkBoxNormalizeImage);
            this.Controls.Add(this.checkBoxSrcImg);
            this.Controls.Add(this.textBoxHoughParam2);
            this.Controls.Add(this.textBoxHoughParam1);
            this.Controls.Add(this.textBoxHoughThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterSize);
            this.Controls.Add(this.textBoxFolderName);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonFolderOpen);
            this.Controls.Add(this.buttonFileOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileOpen;
        private System.Windows.Forms.Button buttonFolderOpen;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox textBoxFolderName;
        private System.Windows.Forms.TextBox textBoxFilterSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHoughThreshold;
        private System.Windows.Forms.TextBox textBoxHoughParam1;
        private System.Windows.Forms.TextBox textBoxHoughParam2;
        private System.Windows.Forms.CheckBox checkBoxSrcImg;
        private System.Windows.Forms.CheckBox checkBoxNormalizeImage;
        private System.Windows.Forms.CheckBox checkBoxFilterImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCannyParam1;
        private System.Windows.Forms.TextBox textBoxCannyParam2;
        private System.Windows.Forms.CheckBox checkBoxCannyImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.Button buttonPWrite;
        private System.Windows.Forms.Button buttonPRead;
        private System.Windows.Forms.TextBox textBoxMaxTilt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxIAX1;
        private System.Windows.Forms.TextBox textBoxIAX2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxIAY1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxIAY2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxOffsetY2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxOffsetY1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxOffsetX2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxOffsetX1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxp1p2distance;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.TextBox LogTb;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBatchSave;
        private System.Windows.Forms.Button ClearLogBt;
    }
}

