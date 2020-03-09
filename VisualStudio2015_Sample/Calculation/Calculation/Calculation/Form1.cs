using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Log.AppendText("Original:" + Sqrt(0.0).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(0.0).ToString("F20") + "\n");

            Log.AppendText("Original:" + Sqrt(1.0).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(1.0).ToString("F20") + "\n");

            Log.AppendText("Original:" + Sqrt(2.0).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(2.0).ToString("F20") + "\n");

            Log.AppendText("Original:" + Sqrt(1.234567).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(1.234567).ToString("F20") + "\n");

            Log.AppendText("Original:" + Sqrt(1.2345678910123456789).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(1.2345678910123456789).ToString("F20") + "\n");


            Log.AppendText("Original:" + Sqrt(0.00009876543210987654321).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(0.00009876543210987654321).ToString("F20") + "\n");

            Log.AppendText("Original:" + Sqrt(-0.00009876543210987654321).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Sqrt(-0.00009876543210987654321).ToString("F20") + "\n");


            double x = Math.Sqrt(-0.00009876543210987654321) + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log.AppendText("Original:" + Pow(0.0, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(0.0, 2).ToString("F20") + "\n");

            Log.AppendText("Original:" + Pow(1.0, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(1.0, 2).ToString("F20") + "\n");

            Log.AppendText("Original:" + Pow(2.0, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(2.0, 2).ToString("F20") + "\n");

            Log.AppendText("Original:" + Pow(1.234567, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(1.234567, 2).ToString("F20") + "\n");

            Log.AppendText("Original:" + Pow(1.2345678910123456789, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(1.2345678910123456789, 2).ToString("F20") + "\n");

            Log.AppendText("Original:" + Pow(-0.00000002345678910123456789, 2).ToString("F20") + "\n");
            Log.AppendText("Math    :" + Math.Pow(-0.00000002345678910123456789, 2).ToString("F20") + "\n");


            Log.AppendText("Math    :" + Math.Pow(4, 2.1).ToString("F20") + "\n");

        }

        double Sqrt(double _x)
        {
            decimal x = (decimal)_x;

            decimal s1 = 1, s2;
            if (x <= 0)
            {
                return 0;/*エラー処理*/
            }
            do
            {
                s2 = s1;
                s1 = (x / s1 + s1) / 2;
            }
            while (s1 != s2);
            return (double)s1;
        }




        double Pow(double A, int b)
        {
            decimal Result = 1.0M;

            for (int i = 0; i < b; i++)
            {
                Result *= (decimal)A;
            }

            return (double)Result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dd = new DateTime(2018,6,21,14,32,00,00);
            DateTime aa = new DateTime(2018, 6, 21, 16, 41, 00, 00);

            TimeSpan tm = aa - dd;

            int span = ((TimeSpan)(aa - dd)).Minutes;

        }
    }
}
