using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimePicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.AppendText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            if(!DateTime.TryParse(maskedTextBox1.Text,out data))
            {
                MessageBox.Show("NG");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox1.AppendText("0");
        }
    }
}
