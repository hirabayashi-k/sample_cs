using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlKeyEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBt_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "Click\r\n";
        }

        private void StartBt_KeyDown(object sender, KeyEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = textBox1.Text + "KeyDown\r\n";
                }));
            }
            else
            {
                textBox1.Text = textBox1.Text + "KeyDown\r\n";
            }
        }

        private void StartBt_KeyUp(object sender, KeyEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = textBox1.Text + "KeyUp\r\n";
                }));
            }
            else
            {
                textBox1.Text = textBox1.Text + "KeyUp\r\n";

            }
        }

        private void StartBt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = textBox1.Text + "KeyPress\r\n";
                }));
            }
            else
            {
                textBox1.Text = textBox1.Text + "KeyPress\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartBt.Focus();
        }

        private void StartBt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = textBox1.Text + "PreviewKeyDown\r\n";
                }));
            }
            else
            {
                textBox1.Text = textBox1.Text + "PreviewKeyDown\r\n";
            }
        }
    }
}
