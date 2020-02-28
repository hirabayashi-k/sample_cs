using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            this.Paint += new PaintEventHandler(this._Update);
        }

        Bitmap smp;

        private void button1_Click(object sender, EventArgs e)
        {
            smp = new Bitmap(pictureBox1.Width / 2, pictureBox1.Height / 2);

            Graphics Canvas = Graphics.FromImage(smp);
            Canvas.FillRectangle(Brushes.Black, 10, 10, 40, 40);

            pictureBox1.Image = smp;
        }

        private void _Update(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }


    }
}
