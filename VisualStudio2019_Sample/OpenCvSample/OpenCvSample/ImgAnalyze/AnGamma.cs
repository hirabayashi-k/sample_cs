using OpenCvSharp;
using System;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// ガンマ変換クラス
    /// 
    /// ガンマ補正（変換）は、画像のコントラストを調節し、視認しやすくするのによく使われています。
    /// </summary>
    public class AnGamma : AnalyzeBase
    {

        /// <summary>
        /// ガンマ閾値
        /// γ > 1 コントラストが全体的に明るくなる。（明部の差は小さく、暗部の差は大きくなる）　
        /// γ = 1 変化なし
        /// 1  > γ コントラストが全体的に暗くなる。（明部の差は大きく、暗部の差は小さくなる）
        /// </summary>
        public double Gamma { get; set; } = 1.0;

        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public override bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            byte[] lut = new byte[256];

            for (var i = 0; i < 256; i++)
            {
                lut[i] = (byte)(Math.Pow(i / 255.0, 1.0 / Gamma) * 255.0);
            }

            Cv2.LUT(inImg, lut, outImg);

            if (view)
            {
                Cv2.ImShow("Gamma", outImg);
                Cv2.WaitKey();
                Cv2.DestroyWindow("Gamma");
            }

            return true;
        }
    }
}
