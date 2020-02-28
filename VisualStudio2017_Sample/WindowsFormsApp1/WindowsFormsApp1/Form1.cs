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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                // 5秒
                if (5 < sw.Elapsed.TotalSeconds)
                {
                    this.Invoke(new Action(() =>
                    {
                        textBox1.Text = sw.Elapsed.TotalSeconds.ToString();
                    }));

                    break;
                }
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
