using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 管理者で実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p =
            System.Diagnostics.Process.Start(@"E:\sample_cs\VisualStudio2017_Sample\TimeChange\TimeChange\bin\Debug\TimeChange.exe");
            p.WaitForExit();
        }
    }
}
