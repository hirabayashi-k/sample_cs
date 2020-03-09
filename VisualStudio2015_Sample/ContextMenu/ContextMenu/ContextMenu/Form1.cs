using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.ContextMenuStrip = contextMenuStrip1;

        }

        private void abcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("abc");
        }

        private void werToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wer");
        }

        private void cdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cde");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // ToolStripItemを追加
                ToolStripItem[] stripItem = new ToolStripMenuItem[]
                {
                    new ToolStripMenuItem("選択1"),
                    new ToolStripMenuItem("選択2"),
                    new ToolStripMenuItem("選択3",null,new ToolStripMenuItem[] {
                    new ToolStripMenuItem("子要素1"),
                    new ToolStripMenuItem("子要素2"),
                     })
                };

                contextMenuStrip2.Items.AddRange(stripItem);

                contextMenuStrip2.Show(this.pictureBox1, e.X,e.Y);

                //contextMenuStrip2.


                //contextMenuStrip2.Items.Clear();
            }
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aa");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
