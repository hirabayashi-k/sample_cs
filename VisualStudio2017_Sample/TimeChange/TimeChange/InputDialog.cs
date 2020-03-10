using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeChange
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
            } else
            {
                DataTimeMtb.Visible = false;
                InputTb.Visible = true;

            }
            timer1.Start();

            DateTime time = new DateTime(2019,07,15,9,0,0);


        }

        private void InputDataMethod(String data)
        {
            if (InputMode == Mode.Times)
            {
                DataTimeMtb.AppendText(data);
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

        private void ClearBt_Click(object sender, EventArgs e)
        {
            InputTb.Text = "";
            DataTimeMtb.Text = "";
        }

        private void EnterBt_Click(object sender, EventArgs e)
        {
            if(InputMode == Mode.Times)
            {
                DateTime data = new DateTime();
                if (!DateTime.TryParse(DataTimeMtb.Text, out data))
                {
                    MessageBox.Show("日付を入力してください");
                    DataTimeMtb.Clear();
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

            // 変更
            Microsoft.VisualBasic.DateAndTime.Today = InputTime;
            Microsoft.VisualBasic.DateAndTime.TimeOfDay = InputTime;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void CancelBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InputDotBt_Click(object sender, EventArgs e)
        {
            InputTb.AppendText(".");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                NowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            }));
        }
    }
}
