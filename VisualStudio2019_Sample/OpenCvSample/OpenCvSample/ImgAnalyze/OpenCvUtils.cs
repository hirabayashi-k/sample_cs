using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSample.Utils;

namespace OpenCvSample.ImgAnalyze
{
    /// <summary>
    /// OpenCvユーティリティ
    /// </summary>
    public static class OpenCvUtils
    {
        /// <summary>
        /// 変換種類
        /// </summary>
        public enum ConversionList
        {
            /// <summary>
            /// グレースケール
            /// </summary>
            [EnumDisplayName("グレースケール")] 
            Grayscale,

            /// <summary>
            /// Bit反転
            /// </summary>
            [EnumDisplayName("Bit反転")]
            BitInversion,

            /// <summary>
            /// ガンマ変換
            /// </summary>
            [EnumDisplayName("ガンマ変換")]
            Gamma,

            /// <summary>
            /// ヒストグラム
            /// </summary>
            [EnumDisplayName("ヒストグラム")]
            Histogram,

            /// <summary>
            /// ２値
            /// </summary>
            [EnumDisplayName("２値化")]
            Binarization,

            /// <summary>
            /// アフィン変換 平行移動
            /// </summary>
            [EnumDisplayName("アフィン変換 平行移動")]
            AffineTranslation,

            /// <summary>
            /// アフィン変換 回転
            /// </summary>
            [EnumDisplayName("アフィン変換 回転")]
            AffineRotation,

            /// <summary>
            /// 平滑化 Blur
            /// </summary>
            [EnumDisplayName("平滑化 Blur")]
            SmoothinBlur,

            /// <summary>
            /// 平滑化 ガウシアン
            /// </summary>
            [EnumDisplayName("平滑化 ガウシアン")]
            SmoothinGaussianBlur,

            /// <summary>
            /// 平滑化 メディアン
            /// </summary>
            [EnumDisplayName("平滑化 メディアン")]
            SmoothinMedianBlur,

            /// <summary>
            /// 平滑化 バイラテラル
            /// </summary>
            [EnumDisplayName("平滑化 バイラテラル")]
            SmoothinBilateral,
        }
    }
}
