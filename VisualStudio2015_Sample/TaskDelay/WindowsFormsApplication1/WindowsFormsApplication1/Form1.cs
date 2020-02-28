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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stop = "";

            var delay = Task.Run(async () => {
                Stopwatch sw = Stopwatch.StartNew();
                await Task.Delay(2500);
                sw.Stop();
                return sw.ElapsedMilliseconds;
            });
            Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task.Delay(2500);
            sw.Stop();

            Console.WriteLine("Elapsed milliseconds: {0}", sw.ElapsedMilliseconds);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();            
            await Task.Delay(2500);           
            sw.Stop();
            Console.WriteLine("Elapsed milliseconds: {0}", sw.ElapsedMilliseconds);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task.Run(async () => {
                await Task.Delay(200);
                Console.WriteLine("遅延させたい処理。");
            });

            Console.WriteLine("遅延させたい処理。2");
        }
    }
}
