using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            p.Refresh();

            textBox1.Text = string.Format("{0}", p.WorkingSet64);
            textBox2.Text = string.Format("{0}", p.VirtualMemorySize64);

            long currentSet = Environment.WorkingSet;
            textBox3.Text = string.Format("{0}", currentSet);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            string data;
            string path = "C:\\Works";
            if (Directory.Exists(path))
            {

            } else
            {
                Directory.CreateDirectory(path);
            }

            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            p.Refresh();

            data = string.Format("{0}  物理メモリ使用量: {1}", DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss"),p.WorkingSet64);
            File.AppendAllText("C:\\Work\\test.txt", data + Environment.NewLine);

            data = string.Format("{0}  仮想メモリ使用量: {1}", DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss"),p.VirtualMemorySize64);
            File.AppendAllText("C:\\Work\\test.txt", data + Environment.NewLine);

            long currentSet = Environment.WorkingSet;
            data = string.Format("{0}  Environment     : {1}", DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss"), currentSet);
            File.AppendAllText("C:\\Work\\test.txt", data + Environment.NewLine);



        }
    }
}
