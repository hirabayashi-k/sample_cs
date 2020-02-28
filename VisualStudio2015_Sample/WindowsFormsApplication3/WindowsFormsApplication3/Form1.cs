using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{

    class test1
    {
        public int a;
        public int[] b;

        public test1()
        {
            a = 0;
            b = new int[4];
        }
    }


    public partial class Form1 : Form
    {

        byte[] sample;
        byte[] sample_b;

        List<byte> sample_l;

        List<byte[]> sample_bb;

        test1[] aa;
        test1[] bb;

        public Form1()
        {
            int i0, i1;

            InitializeComponent();

            sample = new byte[6] { 10, 20, 30, 40, 50, 60 };

            sample_l = new List<byte> { 10, 20, 30, 40, 50, 60 };

            aa = new test1[3];
            bb = new test1[3];

            for (i0 = 0; i0 < 3; i0++)
            {
                aa[i0] = new test1();
                aa[i0].a = i0;
                for (i1 = 0; i1 < aa[i0].b.Length; i1++)
                {
                    aa[i0].b[i1] = i0 *i1 *10;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte b0;
            const char A = ' ';

            b0 = (byte)Convert.ToUInt16( ' ' );
            textBox1.AppendText(b0.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i0;

            for (i0 = 0; i0 < sample.Length; i0++)
            {
                textBox1.AppendText(sample[i0].ToString());
            }

            textBox1.AppendText("\r\n");

            sample_b = sample;

            for (i0 = 0; i0 < sample.Length; i0++)
            {
                textBox1.AppendText(sample_b[i0].ToString());
            }

            textBox1.AppendText("\r\n");
            sample[5] = 100;

            for (i0 = 0; i0 < sample.Length; i0++)
            {
                textBox1.AppendText(sample[i0].ToString());
            }

            textBox1.AppendText("\r\n");

            for (i0 = 0; i0 < sample.Length; i0++)
            {
                textBox1.AppendText(sample_b[i0].ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i0, i1;

            //for(i0=0; i0<sample.Length; i0++)
            //{
//
  //              sample[i0] += 1;
    //        }

            textBox1.AppendText("\r\n");

            for (i0 = 0; i0 < aa.Length; i0++)
            {
                textBox1.AppendText( "aa" +aa[i0].a.ToString() +", " );

                for(i1=0; i1<aa[i0].b.Length; i1++)
                {
                    textBox1.AppendText(aa[i0].b[i1].ToString() + ", ");
                }

                textBox1.AppendText("\r\n");

                bb[i0] = aa[i0];
            }


            /*
                        for (i0 = 0; i0 < sample.Length; i0++)
                        {
                            textBox1.AppendText( );
                        }
                        */

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i0, i1;

            for (i0 = 0; i0 < bb.Length; i0++)
            {
                textBox1.AppendText("bb" + bb[i0].a.ToString() + ", ");

                for (i1 = 0; i1 < bb[i0].b.Length; i1++)
                {
                    textBox1.AppendText(bb[i0].b[i1].ToString() + ", ");
                }

                textBox1.AppendText("\r\n");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            aa[0].a = 10;
        }
    }
}
