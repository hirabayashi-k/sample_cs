using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialog
{
    public partial class Form1 : Form
    {
        bool chflg = false;

        public Form1()
        {
            InitializeComponent();

            //ホイールイベントの追加  
            this.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(pbSub_MouseWheel);

        }

        /// <summary>
        /// モーダレス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Occurrence += new EventHandler(this.EventOccurrence);
            dlg.Occurrence2 += new Form2.Occurrence2Handler(this.EventOccurrence2);
            dlg.Show();
        }
        /// <summary>
        /// モーダル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            Form2 dlg = new Form2();
            dlg.Occurrence += new EventHandler(this.EventOccurrence);
            dlg.Occurrence2 += new Form2.Occurrence2Handler(this.EventOccurrence2);

            dlg.ShowDialog();
        }
        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("tthh時mm分ss秒fffミリ秒");
        }
        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Timerスタート
            timer1.Start();
        }
        /// <summary>
        /// イベント受信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventOccurrence(object sender, System.EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("tthh時mm分ss秒fffミリ秒");

        }

        /// <summary>
        /// イベント受信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventOccurrence2(object sender, EventArgs1 e)
        {
            textBox2.Text = e.Message;

        }


        private void pbSub_MouseWheel(object sender, MouseEventArgs e)
        {
            int wheel = (e.Delta * SystemInformation.MouseWheelScrollLines / 120);

            //フォーム上の座標でマウスポインタの位置を取得する
            //画面座標でマウスポインタの位置を取得する
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;

            //画面座標をクライアント座標に変換する
            System.Drawing.Point cp = this.PointToClient(sp);

            Debug.WriteLine("X:" + cp.X.ToString() + "Y:" + cp.Y.ToString());

            //MessageBox.Show(wheel.ToString());

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            //MessageBox.Show("comboBox1_SelectedIndexChanged");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("comboBox1_SelectedValueChanged");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           //MessageBox.Show("comboBox1_SelectionChangeCommitted");
        }

    }
}
