using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // 通常テスト
            string exp = "(1 + 6) * 5 / (7 - 4)";
            double result = ExpressionAnalysis.Analysis(exp);
            ResultPrint(exp, result.ToString());


            // 大文字小文字　全角
            exp = "sum(1,(1)) *　 ５ / (sUM（1,1) - 4)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // NG 括弧の対応が取れない
            //exp = "sum(1, (1))) * ５ / (sUM（1,1) -4)";
            //result = ExpressionAnalysis.ExAnalysis("sum(1,(1))) *　 ５ / (sUM（1,1) - 4)");
            //ResultPrint(exp, result.ToString());

            // NG 括弧の前に数値
            //exp = "sum1(1,(1)) *　 ５ / (sUM（1,1) - 4)";
            //result = ExpressionAnalysis.ExAnalysis(exp,null);
            //ResultPrint(exp, result.ToString());


            // 括弧の中に式
            exp = "sum(1,(1),(1),(123 + 2)) *　 ５ / (sUM（1,1) - 4)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // AVERAGE 2.5
            exp = "AVERAGE(1,2,3,4)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());


            // STDEV 16.955
            exp = "STDEV(35,55,70,80)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());


            // ABS 10
            exp = "ABS(-10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // SIN
            exp = "SIN(10 * (3.141519 /180))";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // COS
            exp = "COS(10 * (3.141519 /180))";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // TAN
            exp = "TAN(10 * (3.141519 /180))";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());


            //double deg = 30;
            //double rad = 3.141519 * deg / 180.0;
            //double y = System.Math.Asin(rad);

            // ASIN
            exp = "ASIN(3.141519*30/180)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // ACOS
            exp = "ACOS(3.141519*30/180)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // ATAN
            exp = "ATAN(3.141519*30/180)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // ATAN2
            exp = "ATAN2(1,2)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // EXP
            exp = "EXP(2)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // MAX
            exp = "MAX(1,2.1,2,3,4.5)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // MAX
            exp = "MIN(1,2.1,2,3,4.5)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // LOG
            exp = "LOG(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // LOG10
            exp = "LOG10(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // SINH
            exp = "SINH(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // COSH
            exp = "COSH(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // TANH
            exp = "TANH(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());

            // SIN
            exp = "SIN(10)";
            result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());



            // SIN

            Dictionary<string, object> DCA = new Dictionary<string, object>();

            DCA.Add("DY1","0.1235");
            DCA.Add("EY1","0.1234");
            DCA.Add("EX1","0.1235");

            exp = "dy1+0.0013*ey1+sum(12)+PI";
            result = ExpressionAnalysis.ExAnalysis(exp, DCA);
            ResultPrint(exp, result.ToString());



            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox3.Text = sw.Elapsed.ToString();
        }

        public void ResultPrint(string exp, string result)
        {

            textBox2.AppendText("式:" + exp　+ "\r\n");
            textBox2.AppendText("結果:" + result + "\r\n");

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // 通常テスト
            string exp = textBox1.Text;

            if (exp.CompareTo("") == 0) return;

            double result = ExpressionAnalysis.ExAnalysis(exp,null);
            ResultPrint(exp, result.ToString());


            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox3.Text = sw.Elapsed.ToString();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
