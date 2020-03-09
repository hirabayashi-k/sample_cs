using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessKill
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Process p = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ProcessStartInfoオブジェクトを作成する
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo();
            //起動する実行ファイルのパスを設定する
            psi.FileName = "notepad";
            //起動する
            p = System.Diagnostics.Process.Start(psi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("notepad");

            
            foreach (System.Diagnostics.Process p in ps)
            {
                //プロセスを強制的に終了させる
                p.Kill();
            }
            */
            
            if (p != null)
            {
                p.Kill();
                p = null;
            }
            
        }
    }
}
