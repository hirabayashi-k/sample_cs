using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSample.ImgAnalyze;

namespace OpenCvSample.UserCon
{
    /// <summary>
    /// 説明ユーザーコントールのインターフェース
    /// </summary>
    internal interface IDescriptionInterface
    {
        /// <summary>
        /// 説明
        /// </summary>
        /// <param name="text">タイトル</param>
        void SetDescription(string text);

        /// <summary>
        /// タイトル設定
        /// </summary>
        /// <param name="text">タイトル</param>
        void SetTitle(string text);

        /// <summary>
        /// 値のチェック
        /// </summary>
        /// <param name="errormessage">エラーメッセージ</param>
        /// <returns>チェック結果</returns>
        bool CheckValue(ref string errormessage);

        /// <summary>
        /// 解析クラスの設定
        /// </summary>
        /// <param name="obj">解析クラス</param>
        void SetData(AnalyzeBase obj);

        /// <summary>
        /// 解析クラス取得
        /// </summary>
        /// <returns>解析クラス</returns>
        AnalyzeBase GetData();      
    }
}
