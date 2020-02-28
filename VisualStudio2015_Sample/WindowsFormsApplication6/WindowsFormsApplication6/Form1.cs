using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly string sample = "abcderg";
        readonly char[] sample_char = new char[] { 'い', 'ろ', 'は', 'd', 'e', 'f', 'g'};
        int i0 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string s0 = "";

            s0 = s0 + sample[i0];
            //textBox1.AppendText(s0.Length.ToString());
            textBox1.AppendText(sample.Remove(3));
            textBox1.AppendText(sample);
            i0 += 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i0;

            byte[] sample_byte = System.Text.Encoding.Default.GetBytes(sample_char);

            for (i0 = 0; i0 < sample_byte.Length; i0++)
            {
                textBox1.AppendText(sample_byte[i0].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] dst_mov_char = new char[] { 'い', 'ろ', 'は', 'd', 'e', 'f', 'g' };
            char[] src_mov_char = dst_mov_char;
            int idx = 0;
            string s0;

            s0 = new string(src_mov_char);
            textBox1.AppendText(s0);

            Array.Copy(src_mov_char, 3, dst_mov_char, 0, 3);

            s0 = new string(dst_mov_char);
            textBox1.AppendText(s0);

        }
    }
}
