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
    /// ２値化
    /// </summary>
    public partial class BinarizationUserControl : UserControl, IDescriptionInterface
    {
        private AnBinarization _obj = new AnBinarization();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BinarizationUserControl()
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
            _obj = (AnBinarization)obj;

            TypeComboBox.SelectedIndex = (int)_obj.BinType;

            ThresholdNumericUpDown.Value = (decimal)_obj.Threshold;
        }

        /// <summary>
        /// 解析クラス取得
        /// </summary>
        /// <returns>解析クラス</returns>
        public AnalyzeBase GetData()
        {
            AnBinarization.Type enmVal = (AnBinarization.Type)TypeComboBox.SelectedIndex;

            _obj.BinType = enmVal;

            // アップキャスト
            _obj.Threshold = (double)ThresholdNumericUpDown.Value;

            return _obj;
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">Event</param>
        private void BinarizationUserControl_Load(object sender, EventArgs e)
        {
            foreach (var value in Enum.GetValues(typeof(AnBinarization.Type)))
            {
                TypeComboBox.Items.Add(value.ToString());
            }

            ThresholdNumericUpDown.Value = (decimal)_obj.Threshold;

            int index = 0;

            TypeComboBox.SelectedIndex = index;
            foreach (AnBinarization.Type value in Enum.GetValues(typeof(AnBinarization.Type)))
            {
                if (value == _obj.BinType)
                {
                    TypeComboBox.SelectedIndex = index;
                }

                index++;
            }

            SetTitle("２値化");
            string description = "画素値を2種類に0と255の２種類にする（実行する前にグレースケールにすること）\r\n" +
                                 "バイナリー\r\n" +
                                 "閾値に設定したバイナリー画素値を白か黒に振り分ける\r\n" +
                                 "オーツ\r\n" +
                                 "分離度という値が最大となるしきい値を求め、自動的に二値化を行う手法\r\n" +
                                 "アダプティブ 適応的閾値処理\r\n" +
                                 "画像全体の中で任意の大きさの局所領域を設定し、その領域の中で閾値の計算を行い、1つ1つの画素を二値化して行く画像の画素全体の二値化を「各領域に合わせた閾値で」行うことができる\r\n";

            SetDescription(description);
        }
    }
}
