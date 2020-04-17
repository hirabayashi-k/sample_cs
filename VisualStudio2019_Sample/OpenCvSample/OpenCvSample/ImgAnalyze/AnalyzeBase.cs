using OpenCvSharp;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// 解析クラスベース
    /// </summary>
    public abstract class AnalyzeBase
    {
        /// <summary>
        /// 解析ベースメソッド
        /// </summary>
        /// <param name="inImg">入力イメージ</param>
        /// <param name="outImg">出力イメージ</param>
        /// <param name="view">結果表示</param>
        /// <returns>解析結果</returns>
        public virtual bool Analyze(Mat inImg, ref Mat outImg, bool view)
        {
            return true;
        }
    }
}
