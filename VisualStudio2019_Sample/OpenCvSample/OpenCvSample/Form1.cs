using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCvSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //画像ファイル読み込み
            Mat img = new Mat(@"カメラ1_181212_211033_No00003.bmp");
            Mat img2 = img.Clone();
            Mat img3 = img.Clone();

            //トリミング（ROI）
            img3 = img3[new OpenCvSharp.Rect(200, 200, 180, 200)];

            //表示
            Cv2.ImShow("img", img);
            Cv2.ImShow("img3", img3);

        }


        /// <summary>
        /// グレースケース
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            var src = Cv2.ImRead(@"カメラ1_181212_211033_No00003.bmp");
            var dst = new Mat();

            Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2GRAY);

            Cv2.ImShow("img2", dst);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mat img = new Mat(@"カメラ1_181212_211033_No00003.bmp");
            Mat img2 = img.Clone();

            //反転
            Cv2.BitwiseNot(img2, img2);
            Cv2.ImShow("img2", img2);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Mat gray = new Mat(@"カメラ1_181212_211033_No00003.bmp");
            gray = gray.CvtColor(ColorConversionCodes.BGRA2GRAY);

            Mat bin = gray.Clone();

            Cv2.Threshold(gray, bin, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            // 輪郭の検出
            Mat[] contours;
            OutputArray hierarchy = OutputArray.Create(bin);

            Cv2.ImShow("bin", bin);

            //FindContours(InputOutputArray image, out Mat[] contours, OutputArray hierarchy, RetrievalModes mode, ContourApproximationModes method, Point ? offset = null);
            Cv2.FindContours(bin,out contours, hierarchy, RetrievalModes.CComp, ContourApproximationModes.ApproxNone);
            //輪郭の描画
            //public static void DrawContours(InputOutputArray image, IEnumerable<Mat> contours, int contourIdx, Scalar color, int thickness = 1, LineTypes lineType = LineTypes.Link8, Mat hierarchy = null, int maxLevel = int.MaxValue, Point? offset = null);
            Cv2.DrawContours(gray, contours, -1, 0, 255, 0);

            Cv2.ImShow("gray", gray);
            //storage.Dispose();
            //pictureBox1.Invalidate();

        }
    }
}
