using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZoomImage
{
    public partial class Form1 : Form
    {
        // 表示するBitmap
        private Bitmap bmp = null;
        // 描画用Graphicsオブジェクト
        private Graphics g = null;
        // マウスダウンフラグ
        private bool MouseDownFlg = false;
        // マウスをクリックした位置の保持用
        private PointF OldPoint;
        // アフィン変換行列
        private System.Drawing.Drawing2D.Matrix mat;

        public Form1()
        {
            InitializeComponent();
            // ホイールイベントの追加
            this.pictureBox1.MouseWheel 
                += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // リサイズイベントを強制的に実行（Graphicsオブジェクトの作成のため）
            Form1_Resize(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (g != null)
            {
                mat = g.Transform;
                g.Dispose();
                g = null;
            }

            // PictureBoxと同じ大きさのBitmapクラスを作成する。
            Bitmap bmpPicBox = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // 空のBitmapをPictureBoxのImageに指定する。
            pictureBox1.Image = bmpPicBox;
            // Graphicsオブジェクトの作成(FromImageを使う)
            g = Graphics.FromImage(pictureBox1.Image);
            // アフィン変換行列の設定
            if (mat != null)
            {
                g.Transform = mat;
            }

            // 補間モードの設定（このサンプルではNearestNeighborに設定）
            g.InterpolationMode 
                = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            // 画像の描画
            DrawImage();
        }

        // ビットマップの描画
        private void DrawImage()
        {
            if (bmp == null) return;

            // アフィン変換行列の設定
            if ((mat != null))
            {
                g.Transform = mat;
            }
            // ピクチャボックスのクリア
            g.Clear(pictureBox1.BackColor);
            // 描画
            g.DrawImage(bmp, 0, 0);
            // 再描画
            pictureBox1.Refresh();
        }

        //ファイルを開く
        private void mnuFileOpen_Click(object sender, EventArgs e)
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

            // アフィン変換行列の初期化
            if (mat != null)
            {
                mat.Dispose();
            }
            mat = new System.Drawing.Drawing2D.Matrix();
            // 画像の描画
            DrawImage();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            // 終了
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 右ボタンがクリックされたとき
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // アフィン変換行列に単位行列を設定する
                mat.Reset();
                // 画像の描画
                DrawImage();

                return;
            }
            // フォーカスの設定
            //（クリックしただけではMouseWheelイベントが有効にならない）
            pictureBox1.Focus();
            // マウスをクリックした位置の記録
            OldPoint.X = e.X;
            OldPoint.Y = e.Y;
            // マウスダウンフラグ
            MouseDownFlg = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // マウスをクリックしながら移動中のとき
            if (MouseDownFlg == true)
            {
                // 画像の移動
                mat.Translate(e.X - OldPoint.X, e.Y - OldPoint.Y, 
                    System.Drawing.Drawing2D.MatrixOrder.Append);
                // 画像の描画
                DrawImage();

                // ポインタ位置の保持
                OldPoint.X = e.X;
                OldPoint.Y = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // マウスダウンフラグ
            MouseDownFlg = false;
        }

        // マウスホイールイベント
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            // ポインタの位置→原点へ移動
            mat.Translate(-e.X, -e.Y, 
                System.Drawing.Drawing2D.MatrixOrder.Append);
            if (e.Delta > 0)
            {
                // 拡大
                if (mat.Elements[0] < 100)  // X方向の倍率を代表してチェック
                {
                    mat.Scale(1.5f, 1.5f, 
                        System.Drawing.Drawing2D.MatrixOrder.Append);
                }
            }
            else
            {
                // 縮小
                if (mat.Elements[0] > 0.01)  // X方向の倍率を代表してチェック
                {
                    mat.Scale(1.0f / 1.5f, 1.0f / 1.5f, 
                        System.Drawing.Drawing2D.MatrixOrder.Append);
                }
            }
            // 原点→ポインタの位置へ移動(元の位置へ戻す)
            mat.Translate(e.X, e.Y, 
                System.Drawing.Drawing2D.MatrixOrder.Append);
            // 画像の描画
            DrawImage();
        }

    }
}
