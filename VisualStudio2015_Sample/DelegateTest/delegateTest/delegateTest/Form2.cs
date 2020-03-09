using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegateTest
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;


            backgroundWorker1.RunWorkerAsync(10);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int bgWorkerArg = (int)e.Argument;

            // senderの値はbgWorkerの値と同じ
            BackgroundWorker worker = (BackgroundWorker)sender;

            int i = 0;

            delTextUpdate update = new delTextUpdate(TextUpdate);

            while (true)
            {

                // キャンセルされてないか定期的にチェック
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                System.Threading.Thread.Sleep(bgWorkerArg);


                i++;

                if(10 < i)
                {
                    i = 0;
                }


                // スレッドセーフな呼び出し
                worker.ReportProgress(i);
                // ProgressChangedイベント発生


                // アンスレッドセーフ 例外発生
                // this.textBox1.Text = String.Format("{0}", i);


                // ガーベージコレクション発生
               // Invoke(new delTextUpdate(TextUpdate), i);

                // ガーベージコレクション対策
                //Invoke(new delTextUpdate(update), i);



            }

            // このメソッドからの戻り値
            e.Result = "すべて完了";
            // この後、RunWorkerCompletedイベントが発生
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            TextUpdate(e.ProgressPercentage);

            //this.textBox1.Text = String.Format( "{0}", e.ProgressPercentage);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("キャンセルされました");
                // この場合にはe.Resultにはアクセスできない
            }
            else
            {
                // 処理結果の表示
               // this.Text = e.Result.ToString();
                //MessageBox.Show("正常に完了");
            }

            button1.Enabled = true;
            button2.Enabled = false;

        }

        delegate void delTextUpdate(int x);

        private void TextUpdate(int x)
        {
//            this.textBox1.Text = String.Format("{0}", x);


            this.textBox1.Text = $" GC:{GCCount.ToString()} Mem:{GC.GetTotalMemory(false)}";



            //参照にMicrosoft.VisualBasic.dllを追加する必要がある

            textBox2.Clear();
            Microsoft.VisualBasic.Devices.ComputerInfo info =
                new Microsoft.VisualBasic.Devices.ComputerInfo();

            //合計物理メモリ
            textBox2.AppendText( String.Format("合計物理メモリ:{0}バイト\n", info.TotalPhysicalMemory));
            //利用可能な物理メモリ
            textBox2.AppendText( String.Format("利用可能物理メモリ:{0}バイト\n", info.AvailablePhysicalMemory));
            //合計仮想メモリ
            textBox2.AppendText(String.Format("合計仮想メモリ:{0}バイト\n", info.TotalVirtualMemory));
            //利用可能な仮想メモリ
            textBox2.AppendText(String.Format("利用可能仮想メモリ:{0}バイト\n", info.AvailableVirtualMemory));


        }


        static int GCCount => GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);

        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
