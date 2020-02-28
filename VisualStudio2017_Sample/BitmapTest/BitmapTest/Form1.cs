using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //画像ファイルからImage(ここではBitmap)オブジェクトを作成する
            Bitmap img = new Bitmap(@"E:\VisualStudio2017_Sample\BitmapTest\191218_102905_No00003.bmp");

            Bitmap img2 = new Bitmap(@"E:\VisualStudio2017_Sample\BitmapTest\sample2.bmp");

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);

            //Graphicsオブジェクトに文字列を描画する
            g.DrawString("DOBON.NET", this.Font, Brushes.White, 1, 1);
            g.DrawString("DOBON.NET", this.Font, Brushes.Black, 0, 0);
            g.DrawImage(img2,0,0,img.Width,img.Height);
            //g.DrawImageUnscaled
            g.Dispose();

            //PictureBoxのImageプロパティに設定する
            pictureBox1.Image = img;




        }
    }
}
