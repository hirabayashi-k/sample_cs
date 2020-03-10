using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Diagnostics.Process px = null;

        private void button1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process p = System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", @"E:\sample_cs\VisualStudio2017_Sample\外部アプリ呼び出し\CallApp\CallApp\bin\Debug\ibutama.wmv");


            /*
            p.WaitForExit();

            MessageBox.Show("終了しました。" +
                "\n終了コード:" + p.ExitCode.ToString() +
                "\n終了時間:" + p.ExitTime.ToString());
                */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Processオブジェクトを作成する
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //起動するファイルを指定する
            p.StartInfo.FileName = @".\ibutama.wmv";
            //イベントハンドラがフォームを作成したスレッドで実行されるようにする
            p.SynchronizingObject = this;
            //イベントハンドラの追加
            p.Exited += new EventHandler(p_Exited);
            //プロセスが終了したときに Exited イベントを発生させる
            p.EnableRaisingEvents = true;
            //起動する
            p.Start();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            //プロセスが終了したときに実行される
            MessageBox.Show("終了しました。");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            px = System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", @"E:\sample_cs\VisualStudio2017_Sample\外部アプリ呼び出し\CallApp\CallApp\bin\Debug\ibutama.wmv");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(px != null)
            {
                px.CloseMainWindow();

                px.WaitForExit();
            }
        }
    }
}
