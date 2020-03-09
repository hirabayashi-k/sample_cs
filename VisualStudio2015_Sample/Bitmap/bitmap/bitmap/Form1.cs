using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ペン描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBt_Click(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(panel1.Width, panel1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //Penオブジェクトの作成(幅1の黒色)
            //(この場合はPenを作成せずに、Pens.Blackを使っても良い)
            Pen p = new Pen(Color.Red, 1);
            //位置(10, 20)に100x80の長方形を描く
            g.DrawRectangle(p, 70, 80, 100, 80);

            //リソースを解放する
            p.Dispose();
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;

            Byte[] abc = new Byte[] { 0x0,0x0};

            test(abc);

            classtest tt = new classtest();

            tt.setBuffer(abc);

         
            tt.chngeBuffer();


            Byte[] efg;
            clsstest2.BlockCopyClip(abc, out efg,0,0);

            efg[0] = 7;
            efg[1] = 8;

            Byte[] hij;
            clsstest2.BlockCopyClip(abc, out hij, 0, 0);


            hij[0] = 0;
            hij[1] = 0;

            MessageBox.Show(abc[0].ToString() + " " + abc[1].ToString());
            MessageBox.Show(efg[0].ToString() + " " + efg[1].ToString());
            MessageBox.Show(hij[0].ToString() + " " + hij[1].ToString());

        }


        public void test(Byte[] abc)
        {
            abc[0] = 1;
            abc[1] = 2;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R = 1.0;

            textBox1.Text= string.Format("{0:F}", R);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double R = 1.0;

            textBox1.Text = string.Format("{0:F0}", R);
        }

        Bitmap bmp;
        private Graphics g = null;
        private void button3_Click(object sender, EventArgs e)
        {
            // ファイルを開くダイアログの作成 
            OpenFileDialog dlg = new OpenFileDialog();
            // ファイルフィルタ 
            dlg.Filter = "画像ﾌｧｲﾙ(*.bmp,*.jpg,*.png,*.tif,*.ico)|*.bmp;*.jpg;*.png;*.tif;*.ico";
            // ダイアログの表示 （Cancelボタンがクリックされた場合は何もしない）
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            // 取得したファイル名 
            String FileName = dlg.FileName;

            // Bitmapの確保
            if (bmp != null)
            {
                bmp.Dispose();
            }
            bmp = new Bitmap(FileName);

            if (bmp == null) return;

            pictureBox2.Image = bmp;

            g = Graphics.FromImage(pictureBox2.Image);


            // ピクチャボックスのクリア
            //g.Clear(pictureBox2.BackColor);
            // 描画
            g.DrawImage(bmp, 0, 0);
            // 再描画
            pictureBox2.Refresh();
        }

        private double zoomRatio = 2d;
        //倍率変更後の画像のサイズと位置
        private Rectangle drawRectangle;

        private void button4_Click(object sender, EventArgs e)
        {
            drawRectangle.Width = (int)Math.Round(bmp.Width * zoomRatio);
            drawRectangle.Height = (int)Math.Round(bmp.Height * zoomRatio);
            // 画面の真ん中拡大
            drawRectangle.X = (int)Math.Round(pictureBox2.Width / 2d - pictureBox2.Width / 2 * zoomRatio);
            drawRectangle.Y = (int)Math.Round(pictureBox2.Height / 2d - pictureBox2.Height /2 * zoomRatio);

            // クリック位置拡大
            //drawRectangle.X = (int)Math.Round(pb.Width / 2d - imgPoint.X * zoomRatio);
            //drawRectangle.Y = (int)Math.Round(pb.Height / 2d - imgPoint.Y * zoomRatio);

            //画像を指定された位置、サイズで描画する
            g.DrawImage(bmp, drawRectangle);

            pictureBox2.Refresh();
        }
        Bitmap bb;

        /// <summary>
        /// ピクチャーBOXにペン描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            bb = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = bb;
            Graphics gc = Graphics.FromImage(pictureBox1.Image);

            Pen pen = new Pen(Color.Black, 1);
            Point[] pts = {
                new Point(10, 10), new Point(110, 60), new Point(210, 10),
                new Point(210, 210), new Point(110, 160), new Point(10, 210)
            };
            gc.DrawPolygon(pen, pts);

            gc.Dispose();

            pictureBox1.Refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // ファイルを開くダイアログの作成 
            OpenFileDialog dlg = new OpenFileDialog();
            // ファイルフィルタ 
            dlg.Filter = "画像ﾌｧｲﾙ(*.bmp,*.jpg,*.png,*.tif,*.ico)|*.bmp;*.jpg;*.png;*.tif;*.ico";
            // ダイアログの表示 （Cancelボタンがクリックされた場合は何もしない）
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            // 取得したファイル名 
            String FileName = dlg.FileName;

            // Bitmapの確保
            if (bmp != null)
            {
                bmp.Dispose();
            }

            Stopwatch sw = new Stopwatch();

            sw.Start();

            bmp = new Bitmap(FileName);

            if (bmp == null) return;

            //Bitmapのイメージデータ部分のみをbyte配列に取り出したいのですが
            //うまくいきません。
            //BitmapをいったんMemoryStreamに保存しなおしたんですが
            //BitmapHeader部分のデータも保存されてしまいます

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);   //using System.Drawing.Imaging;

           byte[] data =  ms.ToArray();

            textBox2.AppendText(bmp.Width.ToString() + "*" + bmp.Height.ToString() + "="  + (bmp.Width*bmp.Height).ToString() + "\r\n");

            textBox2.AppendText(data.Length.ToString() + "\r\n");


            bmp.Save("C:\\test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            sw.Stop();

            textBox2.AppendText(string.Format("経過時間 = {0}", sw.ElapsedMilliseconds));

        }
    }


    public class classtest
    {

        public Byte[] FbBffer;

        public void setBuffer(Byte[] dst)
        {
            FbBffer = dst;
        }

        public void chngeBuffer()
        {
            FbBffer[0] = 4;
            FbBffer[1] = 5;

        }

        public Byte[] getByteData()
        {
            return FbBffer;
        }

    }

    public static class clsstest2
    {
        public static void BlockCopyClip(Byte[] src, out Byte[] dst, int OffX, int OffY)
        {
            dst = new Byte[src.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        }
    }
}
