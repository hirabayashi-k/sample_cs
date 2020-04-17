using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// 平滑化フィルタ
    /// </summary>
    public class AnalyzeSmooth : AnalyzeBase
    {
        /// <summary>
        /// 近傍
        /// </summary>
        public int Neighborhood { get; set; } = 3;

        /// <summary>
        /// タイプ ENUM
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// ブーリーフィルタ
            /// 
            /// </summary>
            Blur,

            /// <summary>
            /// ガウシアンフィルタ
            /// 
            /// </summary>
            Gaussian,

            /// <summary>
            /// メディアンフィルタ
            /// 
            /// 
            /// </summary>
            Median,

            /// <summary>
            /// バイラテラルフィルタ
            /// </summary>
            Bilateral,
        }

        /// <summary>
        /// フィルタータイプ
        /// </summary>
        public Type FilterType { get; set; } = Type.Blur;

        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ(グレースケール画像)</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public override bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            if (FilterType == Type.Blur)
            {
                Cv2.Blur(inImg, outImg, new OpenCvSharp.Size(Neighborhood, Neighborhood));
            }
            else if (FilterType == Type.Gaussian)
            {
                Cv2.GaussianBlur(inImg, outImg, new OpenCvSharp.Size(Neighborhood, Neighborhood), 2);
            }
            else if (FilterType == Type.Median)
            {
                Cv2.MedianBlur(inImg, outImg, Neighborhood);
            }
            else
            {
                Cv2.BilateralFilter(inImg, outImg, 20, 30, 30);
            }

            if (view)
            {
                Cv2.ImShow("Smooth", outImg);
                Cv2.WaitKey();
                Cv2.DestroyWindow("Smooth");
            }

            return true;
        }
    }
}
