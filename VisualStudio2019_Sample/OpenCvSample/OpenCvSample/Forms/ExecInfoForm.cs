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

namespace OpenCvSample.Forms
{
    /// <summary>
    /// 変更画面
    /// </summary>
    public partial class ExecInfoForm : Form
    {
        /// <summary>
        /// 解析
        /// </summary>
        private AnalyzeBase _obj { get; set; } = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExecInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解析クラスの設定
        /// </summary>
        /// <param name="obj">解析クラス</param>
        public void SetData(AnalyzeBase obj)
        {
            _obj = obj;
        }

        /// <summary>
        /// 解析クラス取得
        /// </summary>
        /// <returns>解析クラス</returns>
        public AnalyzeBase GetData()
        {
            return _obj;
        }

        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecInfoForm_Load(object sender, EventArgs e)
        {
            if (_obj != null)
            {
                if (_obj is AnBitInversion)
                {

                }
                else if (_obj is AnGrayscale)
                {

                }
                else if (_obj is AnGamma)
                {

                }
                else if (_obj is AnBinarization)
                {

                }
                else if (_obj is AnHistogram)
                {

                }
            }
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
