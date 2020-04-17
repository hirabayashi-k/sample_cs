using System;
using OpenCvSharp;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// ヒストグラム
    /// 画素値の分布を平坦化することで画像のコントラストを改善する
    /// </summary>
    public class AnHistogram : AnalyzeBase
    {
        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ(グレースケール)</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public override bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            //Cv2.CvtColor(inImg, outImg, MatType.CV_8U);

            Cv2.EqualizeHist(outImg, outImg);

            if (view)
            {
                Cv2.ImShow("Histogram", outImg);
                Cv2.WaitKey();
                Cv2.DestroyWindow("Histogram");
            }

            return true;
        }
    }
}
