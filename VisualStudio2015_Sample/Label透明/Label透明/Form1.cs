using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Label透明
{
    public partial class Form1 : Form
    {
        int No = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;

            //pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\コアラ.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //画像の大きさをPictureBoxに合わせる
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //画像を表示する
            pictureBox1.Image = System.Drawing.Image.FromFile(@".\ダウンロード2.jpg");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = "書き換え:" + No.ToString();
            No ++;
        }
    }
}
