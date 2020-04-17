using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSample.Forms;
using OpenCvSample.ImgAnalyze;
using OpenCvSample.UserCon;
using OpenCvSharp;

namespace OpenCvSample
{
    /// <summary>
    /// OpenCvサンプル
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 画像表示タブ
        /// </summary>
        private List<TabPage> _tabPages;

        /// <summary>
        /// 変換詳細表示ユーザーコントロール
        /// </summary>
        private List<UserControl> _conversPanel;

        /// <summary>
        /// 解析クラスリスト
        /// </summary>
        private List<AnalyzeBase> _analyzeList = new List<AnalyzeBase>();

        /// <summary>
        /// tab動作中フラグ
        /// </summary>
        private bool _tabactionflg = false;

        /// <summary>
        /// list動作中フラグ
        /// </summary>
        private bool _listactionflg = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 変換リストの初期化
            // Set the view to show details.
            ConversionListView.View = View.Details;

            // Allow the user to edit item text.
            ConversionListView.LabelEdit = false;

            // Allow the user to rearrange columns.
            ConversionListView.AllowColumnReorder = false;

            // Display check boxes.
            ConversionListView.CheckBoxes = false;

            // Select the item and subitems when selection is made.
            ConversionListView.FullRowSelect = true;

            // Display grid lines.
            ConversionListView.GridLines = false;

            // Sort the items in the list in ascending order.
            ConversionListView.Sorting = SortOrder.None;

            List<ListViewItem> llViewItem = new List<ListViewItem>();
            int index = 0;

            foreach (var value in Enum.GetValues(typeof(ImgAnalyze.OpenCvUtils.ConversionList)))
            {
                // OpenCvUtils.ConversionList.AffineRotation.GetEnumDisplayName();
                string name = Enum.GetName(typeof(ImgAnalyze.OpenCvUtils.ConversionList), value);

                llViewItem.Add(new ListViewItem(name, index));
                index++;
            }

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            ConversionListView.Columns.Add("ConVersion", -2, HorizontalAlignment.Center);

            ConversionListView.HeaderStyle = ColumnHeaderStyle.None;

            // Add the items to the ListView.
            ConversionListView.Items.AddRange(llViewItem.ToArray());

            // 実行リストの初期化
            // Set the view to show details.
            ExecListView.View = View.Details;

            // Allow the user to edit item text.
            ExecListView.LabelEdit = false;

            // Allow the user to rearrange columns.
            ExecListView.AllowColumnReorder = false;

            // Display check boxes.
            ExecListView.CheckBoxes = false;

            // Select the item and subitems when selection is made.
            ExecListView.FullRowSelect = true;

            // Display grid lines.
            ExecListView.GridLines = false;

            // Sort the items in the list in ascending order.
            ExecListView.Sorting = SortOrder.None;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            ExecListView.Columns.Add("ConVersion", -2, HorizontalAlignment.Center);

            ExecListView.HeaderStyle = ColumnHeaderStyle.None;

            // タブ作成
            TabMake();
        }

        /// <summary>
        /// ドラッグアンドドロップ
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void FileNameTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length != 0)
            {
                string fileName = files[0];
                FileNameTextBox.Text = fileName;
            }
        }

        /// <summary>
        /// ドラッグエンター
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void FileNameTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ConversionListView.SelectedItems.Count != 0)
            {
                int index = ConversionListView.SelectedItems[0].Index;

                string name = Enum.GetName(typeof(ImgAnalyze.OpenCvUtils.ConversionList), index);

                ListViewItem listview = new ListViewItem(name, ExecListView.Items.Count);

                ExecListView.Items.Add(listview);

                Type stringType = name.GetType();

                if (typeof(AnBitInversion).Name.CompareTo("An" + name) == 0)
                {
                    AnBitInversion obj = new AnBitInversion();
                    _analyzeList.Add(obj);
                }
                else if (typeof(AnGrayscale).Name.CompareTo("An" + name) == 0)
                {
                    AnGrayscale obj = new AnGrayscale();
                    _analyzeList.Add(obj);
                }
                else if (typeof(AnGamma).Name.CompareTo("An" + name) == 0)
                {
                    AnGamma obj = new AnGamma();

                    GammaUserControl ucon = (GammaUserControl)_conversPanel[index];

                    // ダウンキャスト
                    obj = (AnGamma)ucon.GetData();

                    _analyzeList.Add(obj);
                }
                else if (typeof(AnBinarization).Name.CompareTo("An" + name) == 0)
                {
                    AnBinarization obj = new AnBinarization();

                    BinarizationUserControl ucon = (BinarizationUserControl)_conversPanel[index];

                    // ダウンキャスト
                    obj = (AnBinarization)ucon.GetData();
                    _analyzeList.Add(obj);
                }
                else if (typeof(AnHistogram).Name.CompareTo("An" + name) == 0)
                {
                    AnHistogram obj = new AnHistogram();

                    _analyzeList.Add(obj);
                }
            }
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void DelButton_Click(object sender, EventArgs e)
        {
            int index;

            if (ExecListView.SelectedItems.Count != 0)
            {
                index = ExecListView.SelectedItems[0].Index;

                ExecListView.Items.RemoveAt(index);

                _analyzeList.RemoveAt(index);

                if (ExecListView.Items.Count != 0)
                {
                    int count = ExecListView.Items.Count;

                    if (count == index)
                    {
                        ExecListView.Items[count - 1].Selected = true;
                    }
                    else
                    {
                        ExecListView.Items[index].Selected = true;
                    }

                    ExecListView.Focus();
                }
            }
        }

        /// <summary>
        /// Upボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void UpButton_Click(object sender, EventArgs e)
        {
            int index;

            if (ExecListView.Items.Count > 1)
            {
                if (ExecListView.SelectedItems.Count == 0)
                {
                    return;
                }

                index = ExecListView.SelectedItems[0].Index;

                if (index == 0)
                {
                    return;
                }

                ListViewItem backup = ExecListView.Items[index];

                ExecListView.Items.RemoveAt(index);

                ExecListView.Items.Insert(index - 1, backup);

                ExecListView.Items[index - 1].Selected = true;
            }
        }

        /// <summary>
        /// Downボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void DownButton_Click(object sender, EventArgs e)
        {
            int index;

            if (ExecListView.Items.Count > 1)
            {
                int count = ExecListView.Items.Count;

                if (ExecListView.SelectedItems.Count == 0)
                {
                    return;
                }

                index = ExecListView.SelectedItems[0].Index;

                if (index + 1 == count)
                {
                    return;
                }

                ListViewItem backup = ExecListView.Items[index];

                ExecListView.Items.RemoveAt(index);

                ExecListView.Items.Insert(index + 1, backup);

                ExecListView.Items[index + 1].Selected = true;
            }
        }

        /// <summary>
        /// 実行ボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void ExecButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 処理確認
                Mat img = new Mat(FileNameTextBox.Text);
                Mat imgresult = img.Clone();

                // MakeAnalyzeList();
                Cv2.ImShow("img", img);

                for (int i = 0; i < _analyzeList.Count; i++)
                {
                    _analyzeList[i].Analyze(imgresult, ref imgresult, ViewExecCheckBox.Checked);
                }

                Cv2.WaitKey();
                Cv2.DestroyWindow("img");

            }
            catch (Exception ex)
            {
                LogAdd("解析エラー:" + ex.Message);
            }
        }

        /// <summary>
        /// 解析クラスリストの作成
        /// </summary>
        private void MakeAnalyzeList()
        {
            _analyzeList.Clear();

            foreach (ListViewItem item in ExecListView.Items)
            {
                foreach (var value in Enum.GetValues(typeof(ImgAnalyze.OpenCvUtils.ConversionList)))
                {
                    // OpenCvUtils.ConversionList.AffineRotation.GetEnumDisplayName();
                    string name = Enum.GetName(typeof(ImgAnalyze.OpenCvUtils.ConversionList), value);

                    if (item.Text.CompareTo(name) == 0)
                    {
                        Type stringType = name.GetType();

                        if (typeof(AnBitInversion).Name.CompareTo("An" + name) == 0)
                        {
                            AnBitInversion obj = new AnBitInversion();
                            _analyzeList.Add(obj);
                            break;
                        }
                        else if (typeof(AnGrayscale).Name.CompareTo("An" + name) == 0)
                        {
                            AnGrayscale obj = new AnGrayscale();
                            _analyzeList.Add(obj);
                            break;
                        }
                        else if (typeof(AnGamma).Name.CompareTo("An" + name) == 0)
                        {
                            AnGamma obj = new AnGamma();
                            _analyzeList.Add(obj);
                            break;
                        }
                        else if (typeof(AnBinarization).Name.CompareTo("An" + name) == 0)
                        {
                            AnBinarization obj = new AnBinarization();
                            _analyzeList.Add(obj);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// タブ作成
        /// </summary>
        private void TabMake()
        {
            ConversKindTabControl.TabPages.Clear();

            if (_tabPages != null)
            {
                _tabPages.Clear();
            }

            _tabPages = new List<TabPage>();

            if (_conversPanel != null)
            {
                _conversPanel.Clear();
            }

            _conversPanel = new List<UserControl>();

            int index = 0;

            foreach (ImgAnalyze.OpenCvUtils.ConversionList value in Enum.GetValues(typeof(ImgAnalyze.OpenCvUtils.ConversionList)))
            {
                _tabPages.Add(new TabPage());

                // 種類によって変更
                if (value == ImgAnalyze.OpenCvUtils.ConversionList.BitInversion)
                {
                    GeneralBaseUserControl obj = new GeneralBaseUserControl();

                    obj.SetTitle("ビット反転");

                    string description = "画素値を反転する";

                    obj.SetDescription(description);

                    _conversPanel.Add(obj);
                }
                else if (value == ImgAnalyze.OpenCvUtils.ConversionList.Grayscale)
                {
                    GeneralBaseUserControl obj = new GeneralBaseUserControl();

                    obj.SetTitle("グレースケール");

                    string description = "グレースケール化は白黒とその間の灰色だけの彩度0の画像にすること";

                    obj.SetDescription(description);

                    _conversPanel.Add(obj);
                }
                else if (value == ImgAnalyze.OpenCvUtils.ConversionList.Binarization)
                {
                    BinarizationUserControl obj = new BinarizationUserControl();

                    _conversPanel.Add(obj);
                }
                else if (value == ImgAnalyze.OpenCvUtils.ConversionList.Gamma)
                {
                    GammaUserControl obj = new GammaUserControl();

                    _conversPanel.Add(obj);
                }
                else if (value == ImgAnalyze.OpenCvUtils.ConversionList.Histogram)
                {
                    GeneralBaseUserControl obj = new GeneralBaseUserControl();

                    obj.SetTitle("ヒストグラム");

                    string description = "画素値の分布を平坦化することで画像のコントラストを改善する(グレースケール画像)";

                    obj.SetDescription(description);

                    _conversPanel.Add(obj);
                }
                else
                {
                    _conversPanel.Add(new GeneralBaseUserControl());
                }

                _tabPages[index].Name = value.ToString();
                _tabPages[index].Text = value.ToString();

                _tabPages[index].TabIndex = 0;

                _conversPanel[index].Location = new System.Drawing.Point(2, 2);

                // _conversPanel[index].Index = index;
                _tabPages[index].Controls.Add(_conversPanel[index]);

                // タブページの追加
                ConversKindTabControl.TabPages.Add(_tabPages[index]);

                index++;
            }
        }

        /// <summary>
        /// MSTestサンプル
        /// </summary>
        /// <param name="a">数値</param>
        /// <returns>結果</returns>
        public int Sample(int a)
        {
            List<AnalyzeBase> anaclass = new List<AnalyzeBase>();

            anaclass.Add(new AnGrayscale());
            anaclass.Add(new AnBitInversion());

            if (a == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// MSTestサンプル2
        /// </summary>
        /// <returns>結果</returns>
        public int SampleTest2()
        {
            return 1;
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="text"></param>
        private void LogAdd(string text)
        {
            LogTextBox.AppendText(text + "\r\n");
        }

        /// <summary>
        /// トリミング
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            // 画像ファイル読み込み
            Mat img = new Mat(FileNameTextBox.Text);
            Mat img2 = img.Clone();
            Mat img3 = img.Clone();

            // トリミング（ROI）
            img3 = img3[new OpenCvSharp.Rect(50, 50, 100, 100)];

            // 表示
            Cv2.ImShow("img", img);
            Cv2.ImShow("img3", img3);
        }

        /// <summary>
        /// グレースケース
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            var src = Cv2.ImRead(FileNameTextBox.Text);
            var dst = new Mat();

            Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2GRAY);

            Cv2.ImShow("img2", dst);
        }

        /// <summary>
        /// bit反転
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button3_Click(object sender, EventArgs e)
        {
            Mat img = new Mat(FileNameTextBox.Text);
            Mat img2 = img.Clone();

            // 反転
            Cv2.BitwiseNot(img2, img2);
            Cv2.ImShow("img2", img2);
        }

        /// <summary>
        /// 輪郭抽出
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button4_Click(object sender, EventArgs e)
        {
            Mat gray = new Mat(this.FileNameTextBox.Text);

            gray = gray.CvtColor(ColorConversionCodes.BGRA2GRAY);

            Mat bin = gray.Clone();

            Cv2.Threshold(gray, bin, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);

            // 輪郭の検出
            Mat[] contours;
            OutputArray hierarchy = OutputArray.Create(bin);

            Cv2.ImShow("bin", bin);

            // FindContours(InputOutputArray image, out Mat[] contours, OutputArray hierarchy, RetrievalModes mode, ContourApproximationModes method, Point ? offset = null);
            Cv2.FindContours(bin, out contours, hierarchy, RetrievalModes.CComp, ContourApproximationModes.ApproxNone);

            // 輪郭の描画
            // public static void DrawContours(InputOutputArray image, IEnumerable<Mat> contours, int contourIdx, Scalar color, int thickness = 1, LineTypes lineType = LineTypes.Link8, Mat hierarchy = null, int maxLevel = int.MaxValue, Point? offset = null);
            Cv2.DrawContours(gray, contours, -1, 0, 255, 0);

            Cv2.ImShow("gray", gray);

            // storage.Dispose();
            // pictureBox1.Invalidate();
        }

        /// <summary>
        /// ガンマ変換
        /// gammaが高い場合、色が薄くなり　gammaが低い場合、色が薄くなる
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button5_Click(object sender, EventArgs e)
        {
            // この値を低くしたり高くする
            var gamma = 1.5;

            var img = new Mat(FileNameTextBox.Text);
            Mat gammaimg = img.Clone();

            byte[] lut = new byte[256];

            for (var i = 0; i < 256; i++)
            {
                lut[i] = (byte)(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0);
            }

            Cv2.LUT(img, lut, gammaimg);

            Cv2.ImShow("img", img);
            Cv2.ImShow("gammaimg", gammaimg);
        }

        /// <summary>
        /// ヒストグラム　平坦化
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button6_Click(object sender, EventArgs e)
        {
            var img = new Mat(FileNameTextBox.Text, MatType.CV_8U);
            Mat img_eq = img.Clone();

            Cv2.EqualizeHist(img, img_eq);

            Cv2.ImShow("img", img);
            Cv2.ImShow("img_eq", img_eq);
        }

        /// <summary>
        /// 2値化
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button7_Click(object sender, EventArgs e)
        {
            var img = new Mat(FileNameTextBox.Text, MatType.CV_8U);
            Mat img_2 = img.Clone();
            Mat img_otsu = img.Clone();
            Mat imgadap = img.Clone();

            double threshold = 100;
            double ret = Cv2.Threshold(img, img_2, threshold, 255, ThresholdTypes.Binary);

            double ret2 = Cv2.Threshold(img, img_otsu, threshold, 255, ThresholdTypes.Otsu);

            Cv2.AdaptiveThreshold(img, imgadap, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 3, 1);

            Cv2.ImShow("img", img);
            Cv2.ImShow("img_2", img_2);
            Cv2.ImShow("img_Otsu", img_otsu);
            Cv2.ImShow("img_Adap", imgadap);
        }

        /// <summary>
        /// 2値トラックバー付き
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button8_Click(object sender, EventArgs e)
        {
            int th = 0;

            using (var src = new Mat(FileNameTextBox.Text))
            using (var gray = new Mat())
            using (var dst = new Mat())
            {
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

                Cv2.Threshold(gray, dst, 100, 255, ThresholdTypes.Binary);
                var win = new Window("dst image", gray);
                win.ShowImage(dst); // win.Image = dst; // ShowImageのかわりにこう書いてもOK

                using (win)
                {
                    _ = win.CreateTrackbar2(
                        "Threshold",
                        100,
                        255,
                        (pos, userdata) =>
                        {
                            Cv2.Threshold(gray, dst, pos, 255, ThresholdTypes.Binary);
                            win.ShowImage(dst); // win.Image = dst; // ShowImageのかわりにこう書いてもOK
                            th = pos;
                        },
                        null);

                    Cv2.WaitKey();
                }
            }

            MessageBox.Show(th.ToString());
        }

        /// <summary>
        /// アファイン変換 1
        /// 平行移動
        /// 
        /// https://imagingsolution.net/program/globaltransformations/
        /// https://qiita.com/qinojp/items/d2d9a68a962b34b62888
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button9_Click(object sender, EventArgs e)
        {
            var img = new Mat(FileNameTextBox.Text);
            Mat img_2 = img.Clone();

            // 30ピクセルの平行移動
            int dx = 30, dy = 30;

            double[] data = new double[6] { 1.0, 0.0, dx, 0.0, 1.0, dy };

            Mat mat = new Mat(2, 3, MatType.CV_64FC1, data);  // << 1.0, 0.0, dx, 0.0, 1.0, dy);

            Cv2.WarpAffine(img, img_2, mat, new OpenCvSharp.Size(img.Rows, img.Cols));

            Cv2.ImShow("img", img);
            Cv2.ImShow("img_2", img_2);
        }

        /// <summary>
        /// アファイン変換
        /// 回転
        /// https://imagingsolution.net/program/globaltransformations/
        /// https://qiita.com/qinojp/items/d2d9a68a962b34b62888
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button10_Click(object sender, EventArgs e)
        {
            var img = new Mat(FileNameTextBox.Text);
            Mat img_2 = img.Clone();

            // 回転角度
            int angle = 40;

            var rot_mat = Cv2.GetRotationMatrix2D(new Point2f(img.Cols / 2, img.Rows / 2), angle, 1);

            Cv2.WarpAffine(img, img_2, rot_mat, new OpenCvSharp.Size(img.Rows, img.Cols));

            Cv2.ImShow("img", img);
            Cv2.ImShow("img_2", img_2);
        }

        /// <summary>
        /// 平滑化 
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void Button11_Click(object sender, EventArgs e)
        {
            var img = new Mat(FileNameTextBox.Text);
            Mat img_2 = img.Clone();

            // blur
            Cv2.Blur(img, img_2, new OpenCvSharp.Size(3, 3));

            Cv2.ImShow("img", img);
            Cv2.ImShow("img_blur", img_2);
            Cv2.WaitKey();
            Cv2.DestroyWindow("img_blur");

            // ガウシアンフィルタ
            Cv2.GaussianBlur(img, img_2, new OpenCvSharp.Size(9, 9), 2);
            Cv2.ImShow("img", img);
            Cv2.ImShow("img_ga", img_2);
            Cv2.WaitKey();
            Cv2.DestroyWindow("img_ga");

            // メディアンフィルタ
            Cv2.MedianBlur(img, img_2, 5);
            Cv2.ImShow("img", img);
            Cv2.ImShow("img_me", img_2);
            Cv2.WaitKey();
            Cv2.DestroyWindow("img_me");

            // バイラテラルフィルタ
            Cv2.BilateralFilter(img, img_2, 20, 30, 30);
            Cv2.ImShow("img", img);
            Cv2.ImShow("img_bi", img_2);
            Cv2.WaitKey();
            Cv2.DestroyWindow("img_bi");
        }

        private void ConversionListView_TabIndexChanged(object sender, EventArgs e)
        {
            // 無処理
        }

        private void ConversKindTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            // 無処理
        }

        /// <summary>
        /// セレクトイベント
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void ConversKindTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listactionflg)
            {
                return;
            }

            _tabactionflg = true;

            int index = ConversKindTabControl.SelectedIndex;
            ConversionListView.SelectedItems.Clear();
            ConversionListView.Items[index].Selected = true;

            _tabactionflg = false;
        }

        /// <summary>
        /// セレクトイベント
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void ConversionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tabactionflg)
            {
                return;
            }

            _listactionflg = true;

            for (int i = 0; i < ConversionListView.Items.Count; i++)
            {
                if (ConversionListView.Items[i].Selected == true)
                {
                    ConversKindTabControl.SelectedIndex = i;
                    break;
                }
            }

            _listactionflg = false;
        }

        /// <summary>
        /// 実行リストダブルクリック
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">event</param>
        private void ExecListView_DoubleClick(object sender, EventArgs e)
        {
            if (ExecListView.SelectedItems.Count != 0)
            {
                int index = ExecListView.SelectedItems[0].Index;

                string name = Enum.GetName(typeof(ImgAnalyze.OpenCvUtils.ConversionList), index);

                ExecInfoForm dlg = new ExecInfoForm();

                dlg.SetData(_analyzeList[index]);

                dlg.ShowDialog();
            }
        }
    }
}
