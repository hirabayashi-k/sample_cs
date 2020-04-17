using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// ２値化
    /// グレースケールにしてから使用
    /// </summary>
    public class AnBinarization : AnalyzeBase
    {
        /// <summary>
        /// タイプ ENUM
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// バイナリー
            /// 閾値に設定したバイナリー画素値を白か黒に振り分ける
            /// </summary>
            Binary,

            /// <summary>
            /// オーツ
            /// 分離度という値が最大となるしきい値を求め、自動的に二値化を行う手法
            /// </summary>
            Otsu,

            /// <summary>
            /// アダプティブ 適応的閾値処理
            /// 画像全体の中で任意の大きさの局所領域を設定し、その領域の中で閾値の計算を行い、1つ1つの画素を二値化して行く
            /// 画像の画素全体の二値化を「各領域に合わせた閾値で」行うことができる
            /// </summary>
            Adaptive,
        }

        /// <summary>
        /// 閾値
        /// </summary>
        public double Threshold { get; set; } = 100;

        /// <summary>
        /// タイプGetSet
        /// </summary>
        public Type BinType { get; set; } = Type.Binary;

        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ(グレースケール画像)</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public override bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            // グレースケール化
            // Cv2.CvtColor(inImg, outImg, MatType.CV_8U);
            if (BinType == Type.Binary)
            {
                // バイナリー
                double ret = Cv2.Threshold(inImg, outImg, Threshold, 255, ThresholdTypes.Binary);
            }
            else if (BinType == Type.Otsu)
            {
                // オーツ
                double ret2 = Cv2.Threshold(inImg, outImg, Threshold, 255, ThresholdTypes.Otsu);
            }
            else
            {
                //// アダプティブ
                Cv2.AdaptiveThreshold(inImg, outImg, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 3, 1);
            }

            if (view)
            {
                Cv2.ImShow("Binarization", outImg);
                Cv2.WaitKey();
                Cv2.DestroyWindow("Binarization");
            }

            return true;
        }
    }
}
