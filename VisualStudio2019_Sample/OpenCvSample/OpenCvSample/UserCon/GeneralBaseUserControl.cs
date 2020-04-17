using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSample.ImgAnalyze;

namespace OpenCvSample.UserCon
{
    /// <summary>
    /// ベースユーザーコントロール
    /// </summary>
    public partial class GeneralBaseUserControl : UserControl, IDescriptionInterface
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GeneralBaseUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 説明
        /// </summary>
        /// <param name="text">text</param>
        public void SetDescription(string text)
        {
            ExplanationTextBox.Text = text;
        }

        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <param name="errormessage">エラーメッセージ</param>
        /// <returns>チェック結果</returns>
        public bool CheckValue(ref string errormessage)
        {
            return true;
        }

        /// <summary>
        /// タイトル
        /// </summary>
        /// <param name="text">text</param>
        public void SetTitle(string text)
        {
            TitlelLbel.Text = text;
        }

        /// <summary>
        /// 解析クラスの設定
        /// </summary>
        /// <param name="obj">解析クラス</param>
        public void SetData(AnalyzeBase obj)
        {
            // 無処理
        }

        /// <summary>
        /// 解析クラス取得
        /// </summary>
        /// <returns>解析クラス</returns>
        public AnalyzeBase GetData()
        {
            return null;
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender">senderObj</param>
        /// <param name="e">Event</param>
        private void GeneralBaseUserControl_Load(object sender, EventArgs e)
        {
            // 無処理
        }
    }
}
