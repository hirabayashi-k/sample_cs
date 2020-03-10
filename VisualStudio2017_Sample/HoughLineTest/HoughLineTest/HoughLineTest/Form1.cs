using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using OpenCvSharp;


namespace HoughLineTest
{
    public partial class Form1 : Form
    {
        private int req_xmlver = 100;       // 必要なXML Version

        string[] files;             // 処理ファイルリスト
        Param gparam = new Param();

        public Form1()
        {
            InitializeComponent();
            gparamguiset();
        }

        // ファイル指定
        private void buttonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "File Select";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = fd.FileName;
                textBoxFolderName.Text = "";
                files = new string[1];
                files[0] = fd.FileName;
                proc();
                Cv2.DestroyAllWindows();
            }
        }

        /// <summary>
        /// 汎用　縮小表示
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="message"></param>
        public void ShowImg(string message,Mat sourse)
        {
            Mat dstgimg = new Mat();
            Cv2.Resize(sourse, dstgimg, new OpenCvSharp.Size(sourse.Cols / 2, sourse.Rows / 2), 0, 0, InterpolationFlags.Cubic);
            Cv2.ImShow(message, dstgimg);
            //Cv2.ImShow(message, sourse);

        }


        // テキストボックスから画像処理パラメータクラスへセット
        private void gparamset()
        {
            gparam.filtersize = int.Parse(textBoxFilterSize.Text);
            gparam.threshold = int.Parse(textBoxThreshold.Text);
            gparam.cannyparam1 = int.Parse(textBoxCannyParam1.Text);
            gparam.cannyparam2 = int.Parse(textBoxCannyParam2.Text);
            gparam.houghthreshold = int.Parse(textBoxHoughThreshold.Text);
            gparam.houghparam1 = int.Parse(textBoxHoughParam1.Text);
            gparam.houghparam2 = int.Parse(textBoxHoughParam2.Text);
            gparam.maxtilt = int.Parse(textBoxMaxTilt.Text);
            gparam.invalidareaX1 = int.Parse(textBoxIAX1.Text);
            gparam.invalidareaX2 = int.Parse(textBoxIAX2.Text);
            gparam.invalidareaY1 = int.Parse(textBoxIAY1.Text);
            gparam.invalidareaY2 = int.Parse(textBoxIAY2.Text);
            gparam.offsetX1 = int.Parse(textBoxOffsetX1.Text);
            gparam.offsetX2 = int.Parse(textBoxOffsetX2.Text);
            gparam.offsetY1 = int.Parse(textBoxOffsetY1.Text);
            gparam.offsetY2 = int.Parse(textBoxOffsetY2.Text);
            gparam.R = int.Parse(textBoxR.Text);
            gparam.p1p2distance = int.Parse(textBoxp1p2distance.Text);
        }
        // 画像処理パラメータをGUIへセット
        private void gparamguiset()
        {
            textBoxFilterSize.Text = gparam.filtersize.ToString();
            textBoxThreshold.Text = gparam.threshold.ToString();
            textBoxCannyParam1.Text = gparam.cannyparam1.ToString();
            textBoxCannyParam2.Text = gparam.cannyparam2.ToString();
            textBoxHoughThreshold.Text = gparam.houghthreshold.ToString();
            textBoxHoughParam1.Text = gparam.houghparam1.ToString();
            textBoxHoughParam2.Text = gparam.houghparam2.ToString();
            textBoxMaxTilt.Text = gparam.maxtilt.ToString();
            textBoxIAX1.Text = gparam.invalidareaX1.ToString();
            textBoxIAX2.Text = gparam.invalidareaX2.ToString();
            textBoxIAY1.Text = gparam.invalidareaY1.ToString();
            textBoxIAY2.Text = gparam.invalidareaY2.ToString();
            textBoxOffsetX1.Text = gparam.offsetX1.ToString();
            textBoxOffsetX2.Text = gparam.offsetX2.ToString();
            textBoxOffsetY1.Text = gparam.offsetY1.ToString();
            textBoxOffsetY2.Text = gparam.offsetY2.ToString();
            textBoxR.Text = gparam.R.ToString();
            textBoxp1p2distance.Text = gparam.p1p2distance.ToString();
        }

        // 処理
        private void proc()
        {
            gparamset();

            for (int x = 0; x < files.Length; x++)
            {
                // オリジナル画像読み込み
                Mat orgimg = Cv2.ImRead(files[x], ImreadModes.AnyColor);
                // グレースケールで読み込み
                Mat srcimg = Cv2.ImRead(files[x], ImreadModes.Grayscale);
                if (srcimg == null)
                {
                    MessageBox.Show("Image file read error.", "Error");
                    return;
                }
                if (checkBoxSrcImg.CheckState == CheckState.Checked)
                {
                    // Source表示
                    ShowImg("Source Image(2値化)", srcimg);
                    int key1 = Cv2.WaitKey(0);
                    if (key1 == 'q' || key1 == 'Q')
                    {
                        return;
                    }
                }
                // 時間計測開始
                Stopwatch sw = new Stopwatch();
                sw.Start();
                // 正規化
                Mat normimg = new Mat();
                Cv2.Normalize(srcimg, normimg, 0, 255, NormTypes.MinMax);
                if (checkBoxNormalizeImage.CheckState == CheckState.Checked)
                {                // 正規化表示

                    ShowImg("Normalize Image(正規化 明るさの標準化)", normimg);
                    int key2 = Cv2.WaitKey(0);
                    if (key2 == 'q' || key2 == 'Q')
                    {
                        return;
                    }
                }
                // フィルター
                Mat fltimg = new Mat();
                if (gparam.filtersize > 0)
                {
                    if ((gparam.filtersize & 1) == 0)
                    {
                        // フィルターサイズは奇数
                        gparam.filtersize++;
                    }
                    OpenCvSharp.Size fltsz = new OpenCvSharp.Size(gparam.filtersize, gparam.filtersize);
                    Cv2.GaussianBlur(normimg, fltimg, fltsz, 0);
                    if (checkBoxFilterImage.CheckState == CheckState.Checked)
                    {
                        // フィルター表示
                        ShowImg("Filter Image(平滑化)", fltimg);
                        int key3 = Cv2.WaitKey(0);
                        if (key3 == 'q' || key3 == 'Q')
                        {
                            return;
                        }
                    }
                }
                else
                {
                    fltimg = normimg;
                }
                // Threshold
                Mat thrimg = new Mat();
                Cv2.Threshold(fltimg, thrimg, gparam.threshold, 255, ThresholdTypes.Binary);
                // Canny
                Mat cannyimg = new Mat();
                Cv2.Canny(thrimg, cannyimg, gparam.cannyparam1, gparam.cannyparam2);
                if (checkBoxCannyImage.CheckState == CheckState.Checked)
                {
                    // フィルター表示
                    ShowImg("Canny Image(エッジ検出)", cannyimg);
                    int key4 = Cv2.WaitKey(0);
                    if (key4 == 'q' || key4 == 'Q')
                    {
                        return;
                    }
                }
                // Hough変換
                LineSegmentPoint[] houghlines;
                houghlines = Cv2.HoughLinesP(cannyimg, 10, Cv2.PI / 180, gparam.houghthreshold, gparam.houghparam1, gparam.houghparam2);
                OpenCvSharp.Point p1 = new OpenCvSharp.Point();
                OpenCvSharp.Point p2 = new OpenCvSharp.Point();
                p1.X = srcimg.Width;
                p1.Y = srcimg.Height;
                p2.X = 0;
                p2.Y = 0;
                for (int i = 0; i < houghlines.Length; i++)
                {
                    LineSegmentPoint elem = houghlines.ElementAt(i);
                    int diff_x = Math.Abs(elem.P1.X - elem.P2.X);
                    int diff_y = Math.Abs(elem.P1.Y - elem.P2.Y);
                    if (diff_x > diff_y)
                    {
                        // 横線
                        if (diff_y < gparam.maxtilt)
                        {
                            if ((elem.P1.Y >= gparam.invalidareaY1) && (p1.Y > elem.P1.Y))
                            {
                                p1.Y = elem.P1.Y;
                            }
                            if ((elem.P2.Y >= gparam.invalidareaY1) && (p1.Y > elem.P2.Y))
                            {
                                p1.Y = elem.P2.Y;
                            }
                            if ((elem.P1.Y < (srcimg.Height - gparam.invalidareaY2)) && (p2.Y < elem.P1.Y))
                            {
                                p2.Y = elem.P1.Y;
                            }
                            if ((elem.P2.Y < (srcimg.Height - gparam.invalidareaY2)) && (p2.Y < elem.P2.Y))
                            {
                                p2.Y = elem.P2.Y;
                            }
                        }
                    } else
                    {
                        // 縦線
                        if (diff_x < gparam.maxtilt)
                        {
                            if ((elem.P1.X >= gparam.invalidareaX1) && (p1.X > elem.P1.X))
                            {
                                p1.X = elem.P1.X;
                            }
                            if ((elem.P2.X >= gparam.invalidareaX1) && (p1.X > elem.P2.X))
                            {
                                p1.X = elem.P2.X;
                            }
                            if ((elem.P1.X < (srcimg.Width - gparam.invalidareaX2)) && (p2.X < elem.P1.X))
                            {
                                p2.X = elem.P1.X;
                            }
                            if ((elem.P2.X < (srcimg.Width - gparam.invalidareaX2)) && (p2.X < elem.P2.X))
                            {
                                p2.X = elem.P2.X;
                            }
                        }
                    }
                }
                // 検出された直線から得られるp1とp2の位置関係をチェック
                if ((p1.X >= p2.X) || (p1.Y >= p2.Y) || 
                    (Math.Abs(p2.X - p1.X) < gparam.p1p2distance) || 
                    (Math.Abs(p2.Y - p1.Y) < gparam.p1p2distance))
                {
                    // p2.Xはp1.Xより大きくなければいけない、p2.Yはp1.Yより大きくなければいけない
                    // また、p1とp2の距離はgparam.p1p2distanceより大きくなければならない
                    if (!checkBatchSave.Checked)
                    {
                        MessageBox.Show("直線検出でp1/p2座標値取得に失敗しました。");
                    }
                    // 線を描く
                    for (int i = 0; i < houghlines.Length; i++)
                    {
                        LineSegmentPoint elem = houghlines.ElementAt(i);
                        int diff_x = Math.Abs(elem.P1.X - elem.P2.X);
                        int diff_y = Math.Abs(elem.P1.Y - elem.P2.Y);
                        if (diff_x > diff_y)
                        {
                            // 横線
                            if (diff_y < gparam.maxtilt)
                            {
                                orgimg.Line(elem.P1, elem.P2, Scalar.Red, 2);
                            }
                        }
                        else
                        {
                            // 縦線
                            if (diff_x < gparam.maxtilt)
                            {
                                orgimg.Line(elem.P1, elem.P2, Scalar.Red, 2);
                            }
                        }
                    }
                    // 結果表示

                    if(!checkBatchSave.Checked)
                    {
                        ShowImg("HoughLine (直線検出)", orgimg);
                    }

                    LogOut("直線検出NG:" + System.IO.Path.GetFileNameWithoutExtension(files[x]));

                    int key = Cv2.WaitKey(0);
                    if (key == 'q' || key == 'Q')
                    {
                        return;
                    }
                }
                else
                {
                    // オフセットをかける
                    p1.X += gparam.offsetX1;
                    p2.X += gparam.offsetX2;
                    p1.Y += gparam.offsetY1;
                    p2.Y += gparam.offsetY2;
                    if (p1.X < 0) p1.X = 0;
                    if (p2.X >= srcimg.Width) p2.X = srcimg.Width - 1;
                    if (p1.Y < 0) p1.Y = 0;
                    if (p2.Y >= srcimg.Height) p2.Y = srcimg.Height - 1;
                    OpenCvSharp.Point plu = new OpenCvSharp.Point((p1.X + gparam.R), (p1.Y + gparam.R));
                    OpenCvSharp.Point pru = new OpenCvSharp.Point((p2.X - gparam.R), (p1.Y + gparam.R));
                    OpenCvSharp.Point pll = new OpenCvSharp.Point((p1.X + gparam.R), (p2.Y - gparam.R));
                    OpenCvSharp.Point prl = new OpenCvSharp.Point((p2.X - gparam.R), (p2.Y - gparam.R));
                    if (plu.X < 0) plu.X = 0;
                    if (pru.X >= srcimg.Width) pru.X = srcimg.Width - 1;
                    if (pll.X < 0) pll.X = 0;
                    if (prl.X >= srcimg.Width) prl.X = srcimg.Width - 1;
                    if (plu.Y < 0) plu.Y = 0;
                    if (pru.Y < 0) pru.Y = 0;
                    if (pll.Y >= srcimg.Height) pll.Y = srcimg.Height - 1;
                    if (prl.Y >= srcimg.Height) prl.Y = srcimg.Height - 1;
                    OpenCvSharp.Size ax = new OpenCvSharp.Size(gparam.R, gparam.R);
                    // マスク作成
                    Mat mask = new Mat(orgimg.Height, orgimg.Width, MatType.CV_8U, new Scalar(255));
                    mask.Rectangle(p1, p2, new Scalar(0), 1);
                    mask.Ellipse(plu, ax, 0, 270, 180, new Scalar(0), 1);  // 左上コーナー
                    mask.Ellipse(pru, ax, 0, 0, -90, new Scalar(0), 1);  // 右上コーナー
                    mask.Ellipse(pll, ax, 0, 180, 90, new Scalar(0), 1);  // 左下コーナー
                    mask.Ellipse(prl, ax, 0, 0, 90, new Scalar(0), 1);  // 右下コーナー
                    mask.FloodFill(new OpenCvSharp.Point(0, 0), new Scalar(0));
                    OpenCvSharp.Point plu2 = new OpenCvSharp.Point((p1.X + 1), (p1.Y + 1));
                    OpenCvSharp.Point pru2 = new OpenCvSharp.Point((p2.X - 1), (p1.Y + 1));
                    OpenCvSharp.Point pll2 = new OpenCvSharp.Point((p1.X + 1), (p2.Y - 1));
                    OpenCvSharp.Point prl2 = new OpenCvSharp.Point((p2.X - 1), (p2.Y - 1));
                    mask.FloodFill(plu2, new Scalar(0));
                    mask.FloodFill(pru2, new Scalar(0));
                    mask.FloodFill(pll2, new Scalar(0));
                    mask.FloodFill(prl2, new Scalar(0));
                    Mat result = new Mat();
                    orgimg.CopyTo(result, mask);
                    // ここまでの処理時間
                    sw.Stop();
                    string stime = sw.ElapsedMilliseconds.ToString() + "msec";
                    //MessageBox msg = new MessageBox(stime, "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!checkBatchSave.Checked)
                    {
                        MessageBox.Show(stime);
                    }
                    // 線を描く
                    for (int i = 0; i < houghlines.Length; i++)
                    {
                        LineSegmentPoint elem = houghlines.ElementAt(i);
                        int diff_x = Math.Abs(elem.P1.X - elem.P2.X);
                        int diff_y = Math.Abs(elem.P1.Y - elem.P2.Y);
                        if (diff_x > diff_y)
                        {
                            // 横線
                            if (diff_y < gparam.maxtilt)
                            {
                                orgimg.Line(elem.P1, elem.P2, Scalar.Red, 2);
                            }
                        }
                        else
                        {
                            // 縦線
                            if (diff_x < gparam.maxtilt)
                            {
                                orgimg.Line(elem.P1, elem.P2, Scalar.Red, 2);
                            }
                        }
                    }
                    // 結果表示
                    if (!checkBatchSave.Checked)
                    {
                        ShowImg("HoughLine (直線検出)", orgimg);
                    }

                    int key = Cv2.WaitKey(0);
                    if (key == 'q' || key == 'Q')
                    {
                        return;
                    }
                    // 四角をコーナーを描く
                    orgimg.Rectangle(p1, p2, new Scalar(0, 255, 0), 2);
                    orgimg.Ellipse(plu, ax, 0, 270, 180, new Scalar(0, 255, 0), 2);  // 左上コーナー
                    orgimg.Ellipse(pru, ax, 0, 0, -90, new Scalar(0, 255, 0), 2);  // 右上コーナー
                    orgimg.Ellipse(pll, ax, 0, 180, 90, new Scalar(0, 255, 0), 2);  // 左下コーナー
                    orgimg.Ellipse(prl, ax, 0, 0, 90, new Scalar(0, 255, 0), 2);  // 右下コーナー

                    if (!checkBatchSave.Checked)
                    {
                        ShowImg("HoughLine - Rect", orgimg);
                    }


                    key = Cv2.WaitKey(0);
                    if (key == 'q' || key == 'Q')
                    {
                        return;
                    }

                    if (!checkBatchSave.Checked)
                    {
                        ShowImg("Masked", result);
                    }

                    key = Cv2.WaitKey(0);
                    if (key == 'q' || key == 'Q')
                    {
                        return;
                    }

                    if (!checkBatchSave.Checked)
                    {
                        DialogResult ret = MessageBox.Show("Save?", "", MessageBoxButtons.OKCancel);

                        if (ret == DialogResult.OK)
                        {
                            string dir = System.IO.Path.GetDirectoryName(files[x]);
                            string filename = System.IO.Path.GetFileNameWithoutExtension(files[x]);
                            Cv2.ImWrite(dir + @"\" + filename + "_Mask.bmp", result);
                        }
                    }
                    else
                    {
                        string dir = System.IO.Path.GetDirectoryName(files[x]) + @"\MASK";
                        string filename = System.IO.Path.GetFileNameWithoutExtension(files[x]);
                        System.IO.Directory.CreateDirectory(dir);
                                               
                        Cv2.ImWrite(dir + @"\" + filename + "_Mask.bmp", result);

                    }

                }
            }
        }
        
        // キー入力を数字とBSだけにする
        private bool num_bs(KeyPressEventArgs e)
        {
            bool rc = false;
            if ('0' <= e.KeyChar && e.KeyChar <= '9')
            {
            }
            else if (e.KeyChar == '\b')
            {
            }
            else
            {
                rc = true;
            }
            return rc;
        }

        // フィルターサイズは数字とBSのみ
        private void textBoxFilterSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Hough閾値は数字とBSのみ
        private void textBoxHoughThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Hough param1は数字とBSのみ
        private void textBoxHoughParam1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Hough param2は数字とBSのみ
        private void textBoxHoughParam2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Canny param1は数字とBSのみ
        private void textBoxCannyParam1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Canny param2は数字とBSのみ
        private void textBoxCannyParam2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Thresholdは数字とBSのみ
        private void textBoxThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }
        // MaxTiltは数字とBSのみ
        private void textBoxMaxTilt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Invalid Area X1は数字とBSのみ
        private void textBoxIAX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }
        // Invalid Area X2は数字とBSのみ
        private void textBoxIAX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }
        // Invalid Area Y1は数字とBSのみ
        private void textBoxIAY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }
        // Invalid Area Y2は数字とBSのみ
        private void textBoxIAY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }
        // p1-p2 distanceは数字とBSのみ
        private void textBoxp1p2distance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // キー入力を数字とBSと-だけにする
        private bool num_bsm(KeyPressEventArgs e)
        {
            bool rc = false;
            if ('0' <= e.KeyChar && e.KeyChar <= '9')
            {
            }
            else if (e.KeyChar == '\b')
            {
            }
            else if (e.KeyChar == '-')
            {
            }
            else
            {
                rc = true;
            }
            return rc;
        }

        // Offsetは数字とBSと-だけにする
        private void textBoxOffseetY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bsm(e);
        }

        // Offsetは数字とBSと-だけにする
        private void textBoxOffseetY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bsm(e);
        }

        // Offsetは数字とBSと-だけにする
        private void textBoxOffseetX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bsm(e);
        }

        // Offsetは数字とBSと-だけにする
        private void textBoxOffseetX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bsm(e);
        }

        // Rは数字とBSのみ
        private void textBoxR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = num_bs(e);
        }

        // Paramクラス（画処理パラメータ）をXMLで書き出す
        private void buttonPWrite_Click(object sender, EventArgs e)
        {
            gparam.xmlver = req_xmlver;
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = ".xml";
            fd.Title = "XML Write";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                // テキストボックスから画像処理パラメータクラスに反映する
                gparamset();

                //オブジェクトの型を指定する
                XmlSerializer xmlwrite = new XmlSerializer(typeof(Param));
                //書き込むファイルを開く（UTF-8 BOM無し）
                StreamWriter sw = new StreamWriter(fd.FileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                xmlwrite.Serialize(sw, gparam);
                //ファイルを閉じる
                sw.Close();
            }
        }

        private void buttonPRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "XML Read";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //オブジェクトの型を指定する
                XmlSerializer xmlread = new XmlSerializer(typeof(Param));
                //読み込むファイルを開く（UTF-8 BOM無し）
                StreamReader sr = new StreamReader(fd.FileName, new System.Text.UTF8Encoding(false));
                //XMLファイルを読み込む
                gparam = (Param)xmlread.Deserialize(sr);
                //ファイルを閉じる
                sr.Close();

                // 各テキストボックスに反映
                gparamguiset();

                // XML Version Check
                if (gparam.xmlver < req_xmlver)
                {
                    MessageBox.Show("XML Versionが違います");
                }
            }
        }

        private void textBoxFileName_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            files = new string[1];

            files[0] = fileName[0];
            proc();
            Cv2.DestroyAllWindows();
        }

        private void textBoxFileName_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされモノがファイル以外は何もしない
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void buttonPRead_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);


            //オブジェクトの型を指定する
            XmlSerializer xmlread = new XmlSerializer(typeof(Param));
            //読み込むファイルを開く（UTF-8 BOM無し）
            StreamReader sr = new StreamReader(fileName[0], new System.Text.UTF8Encoding(false));
            //XMLファイルを読み込む
            gparam = (Param)xmlread.Deserialize(sr);
            //ファイルを閉じる
            sr.Close();

            // 各テキストボックスに反映
            gparamguiset();

            // XML Version Check
            if (gparam.xmlver < req_xmlver)
            {
                MessageBox.Show("XML Versionが違います");
            }
        }

        private void buttonPRead_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされモノがファイル以外は何もしない
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void buttonFolderOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()
            {
                FileName = "Folder Selection",
                Filter = "Folder|.",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textBoxFolderName.Text = Path.GetDirectoryName(ofd.FileName);

                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(this.textBoxFolderName.Text);
                    System.IO.FileInfo[] filesInfo =
                        di.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly);


                    files = new string[filesInfo.Length];
                    for (int i = 0; i < filesInfo.Length; i++)
                    {
                        files[i] = filesInfo[i].FullName;
                    }
                    proc();
                    Cv2.DestroyAllWindows();
                }
            }
        }

        /// <summary>
        /// Log出力
        /// </summary>
        /// <param name="message"></param>
        private void LogOut(string message)
        {
            LogTb.AppendText(message + "\r\n");
        }

        private void ClearLogBt_Click(object sender, EventArgs e)
        {
            LogTb.Clear();
        }
    }

    // 画像処理パラメータクラス
    public class Param
    {
        public int xmlver = 0;              // XML Version (100=1.0.0)
        public int filtersize = 1;          // フィルターサイズ
        public int threshold = 200;         // threshold
        public int cannyparam1 = 50;        // Canny Param1
        public int cannyparam2 = 80;        // Canny Param2
        public int houghthreshold = 500;    // Hough変換閾値
        public int houghparam1 = 20;        // Hough変換param1
        public int houghparam2 = 200;       // Hough変換param2
        public int maxtilt = 30;            // 最大傾斜（斜め線排除用）
        public int invalidareaX1 = 1;       // 右端の無効領域のピクセル数
        public int invalidareaX2 = 1;       // 左端の無効領域のピクセル数
        public int invalidareaY1 = 1;       // 上の無効領域のピクセル数
        public int invalidareaY2 = 1;       // 下の無効領域のピクセル数
        public int offsetX1 = 0;            // Offset X1
        public int offsetX2 = 0;            // Offset X2
        public int offsetY1 = 0;            // Offset Y1
        public int offsetY2 = 0;            // Offset Y2
        public int R = 0;                   // コーナー半径
        public int p1p2distance = 500;      // p1とp2の最小距離
    }




}
