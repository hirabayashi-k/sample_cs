using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// ビット反転
    /// </summary>
    public class AnBitInversion : AnalyzeBase
    {
        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public override bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            Cv2.BitwiseNot(inImg, outImg);

            if (view)
            {
                Cv2.ImShow("BitInversion", outImg);
                Cv2.WaitKey();
                Cv2.DestroyWindow("BitInversion");
            }

            return true;
        }
    }
}
