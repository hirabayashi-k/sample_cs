using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpTest
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        void puts(string s)
        {
            logTextBox.AppendText(s + Environment.NewLine);
        }

        private void vbscriptButton_Click(object sender, EventArgs e)
        {

            // TEST


        }

        private void jscriptButton_Click(object sender, EventArgs e)
        {
            
            foreach (var s in exprTextBox.Lines)
            {
                try
                {
                    if (s.CompareTo("") != 0)
                    {
                        double r = JscriptEx.JscriptEx.Analysis(s);
                        puts(r.ToString());
                    }

                }
                catch (Exception ex)
                {
                    puts(ex.Message);
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            exprTextBox.Text = "";
            setText("(1 + 6) * 5 / (7 - 4)");
            setText("sin(2)");
            setText("SIN(1)");
            setText("COS(1)");
            setText("TAN(1)");
            setText("SUM(1)");
            setText("SUM(1, 2, 3)");
            setText("SUM(SIN(PI / 2), 1)");
            setText("AVERAGE(1, 2, 3, 4)");
            setText("STDEV(1, 2, 3, 4)");
            setText("ABS(-11)");
            setText("ASIN(1)");
            setText("ACOS(0.1)");
            setText("ATAN(1)");
            setText("ATAN2(SUM(1, 2, 3),2)");
            setText("EXP(6)");
            setText("MAX(1,2,3,4,5)");
            setText("MIN(1,2,3,4,5)");
            setText("SQRT(10)");
            setText("LOG(10)");
            setText("0.00119038499487799+0.0013*-0.410458678658745");

            setText(Math.Log10(2).ToString());
            setText("LOG10(2)");
            setText(Math.Sinh(1).ToString());
            setText("SINH(1)");
            setText(Math.Cosh(1).ToString());
            setText("COSH(1)");
            setText(Math.Tanh(1).ToString());
            setText("TANH(1)");

        }

        void setText(String s)
        {
            exprTextBox.AppendText(s + "\r\n");
        }

    }
}
