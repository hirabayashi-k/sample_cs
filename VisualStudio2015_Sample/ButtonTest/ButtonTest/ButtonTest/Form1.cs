using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EventTest_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseDown\r\n");
        }

        private void EventTest_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseClick\r\n");

        }

        private void EventTest_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Click\r\n");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
