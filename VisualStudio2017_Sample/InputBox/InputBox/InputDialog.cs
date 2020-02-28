using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputBox
{
    public partial class InputDialog : Form
    {
        public double InputData { get; set; }
        public DateTime InputTime{ get; set; }

        public enum Mode
        {
            Number,
            Times
        }

        public Mode InputMode;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="label"></param>
        /// <param name="mInputMode"></param>
        public InputDialog(string label, Mode mInputMode)
        {
            InitializeComponent();

            LabelName.Text = label;

            InputData = 0;

            InputMode = mInputMode;

            if(InputMode == Mode.Times)
            {
                InputDotBt.Enabled = false;
                DataTimeMtb.Visible = true;
                InputTb.Visible = false;

                DataTimeMtb.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");



            } else
            {
                DataTimeMtb.Visible = false;
                InputTb.Visible = true;

            }

            timer1.Start();

        }
        /// <summary>
        /// Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputDialog_Shown(object sender, EventArgs e)
        {
            DataTimeMtb.Select(0, 1);
            DataTimeMtb.Focus();
        }
        /// <summary>
        /// 入力表示
        /// </summary>
        /// <param name="data"></param>
        private void InputDataMethod(String data)
        {
            if (InputMode == Mode.Times)
            {

                int postion = DataTimeMtb.SelectionStart;

                string timeTb = DataTimeMtb.Text;

                DataTimeMtb.Text = timeTb.Remove(postion, 1).Insert(postion, data);

                DataTimeMtb.Focus();

                if (postion < DataTimeMtb.TextLength - 1)
                {
                    postion++;
                    if (!TimePostionGet(postion))
                    {
                        postion++;
                    }
                }

                DataTimeMtb.Select(postion, 1);

            }
            else
            {
                InputTb.AppendText(data);
            }
        }
        
        private void Input0Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("0");
        }

        private void Input1Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("1");
        }

        private void Input2Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("2");
        }

        private void Input3Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("3");
        }

        private void Input4Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("4");
        }

        private void Input5Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("5");
        }

        private void Input6Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("6");
        }

        private void Input7Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("7");
        }

        private void Input8Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("8");
        }

        private void Input9Bt_Click(object sender, EventArgs e)
        {
            InputDataMethod("9");
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBt_Click(object sender, EventArgs e)
        {
            InputTb.Text = "";
            DataTimeMtb.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            if (InputMode == Mode.Times)
            {
                DataTimeMtb.Focus();
                DataTimeMtb.Select(0, 1);
            }
        }
        /// <summary>
        /// Enterボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterBt_Click(object sender, EventArgs e)
        {
            if(InputMode == Mode.Times)
            {
                DateTime data = new DateTime();
                if (!DateTime.TryParse(DataTimeMtb.Text, out data))
                {
                    MessageBox.Show("日付を入力してください");
                    ClearBt_Click(null,null);
                    return;
                }

                InputTime = DateTime.Parse(DataTimeMtb.Text);

            } else
            {
                double dummy;
                bool result = double.TryParse(InputTb.Text, out dummy);

                if (!result)
                {
                    InputTb.Clear();
                    MessageBox.Show("数値を入力してください");
                    return;
                }

                InputData = dummy;
            }

            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// ドットボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputDotBt_Click(object sender, EventArgs e)
        {
            InputTb.AppendText(".");
        }
        /// <summary>
        /// ←クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftBt_Click(object sender, EventArgs e)
        {
            DataTimeMtb.Focus();

            int postion = DataTimeMtb.SelectionStart;

            if(postion != 0)
            {
                postion--;
                if (!TimePostionGet(postion))
                {
                    postion--;
                }
            }

            DataTimeMtb.Select(postion, 1);
        }
        /// <summary>
        /// →クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightBt_Click(object sender, EventArgs e)
        {
            DataTimeMtb.Focus();

            int postion = DataTimeMtb.SelectionStart;

            if (postion < DataTimeMtb.TextLength-1)
            {
                postion++;
                if (!TimePostionGet(postion))
                {
                    postion++;
                }
            }

            DataTimeMtb.Select(postion, 1);

        }
        /// <summary>
        /// 位置チェック
        /// </summary>
        /// <param name="nowpos"></param>
        /// <returns></returns>
        private bool TimePostionGet(int nowpos)
        {
            // フォーマット　"yyyy/MM/dd HH:mm"

            int[] nextpos = { 4, 7, 10,13 };

            int result = nowpos;

            foreach (int i in nextpos)
            {
                if (i == nowpos)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 時間表示タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                TimeLb.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }));
        }
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
