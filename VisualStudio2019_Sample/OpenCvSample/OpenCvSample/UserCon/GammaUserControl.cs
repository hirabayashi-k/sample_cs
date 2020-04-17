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
    /// ガンマ変換
    /// </summary>
    public partial class GammaUserControl : UserControl, IDescriptionInterface
    {
        /// <summary>
        /// ガンマクラス
        /// </summary>
        private AnGamma _obj = new AnGamma();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GammaUserControl()
        {
            InitializeComponent();
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
        /// 説明
        /// </summary>
        /// <param name="text">text</param>
        public void SetDescription(string text)
        {
            ExplanationTextBox.Text = text;
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
            _obj = (AnGamma)obj;

            GammaNumericUpDown.Value = (decimal)_obj.Gamma;
        }

        /// <summary>
        /// 解析クラス取得
        /// </summary>
        /// <returns>解析クラス</returns>
        public AnalyzeBase GetData()
        {
            // アップキャスト
            _obj.Gamma = (double)GammaNumericUpDown.Value;

            return _obj;
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">Event</param>
        private void GammaUserControl_Load(object sender, EventArgs e)
        {
            GammaNumericUpDown.Value = (decimal)_obj.Gamma;

            SetTitle("ガンマ変換");
            string description = "ガンマ補正（変換）は、画像のコントラストを調節し、視認しやすくするのによく使われています。\r\n" +
                                 "γ > 1 コントラストが全体的に明るくなる。（明部の差は小さく、暗部の差は大きくなる）\r\n" +
                                 "γ = 1 変化なし\r\n" +
                                 "1  > γ コントラストが全体的に暗くなる。（明部の差は大きく、暗部の差は小さくなる）\r\n";

            SetDescription(description);
        }
    }
}
