using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet
{
    public static class Class1
    {

        public static void start()
        {

          
            // ファイルから画像読み込み
            var img = OpenCV.Net.CV.LoadImage(@".\ダウンロード5.jpg", OpenCV.Net.LoadImageFlags.AnyColor);
            // エッジ画像格納用の変数作成
            var dst = img.Clone();

            // sobelフィルタ適用
            OpenCV.Net.CV.Sobel(img, dst, 1, 1);

            // 原画用のウインドウ生成
            var windowOrg = new OpenCV.Net.NamedWindow("原画");
            // 原画表示
            windowOrg.ShowImage(img);
            // エッジ用のウィンドウ生成
            var windowEdge = new OpenCV.Net.NamedWindow("エッジ");
            // エッジ表示
            windowEdge.ShowImage(dst);

            // キー入力待ち
            OpenCV.Net.CV.WaitKey(0);

        }
    }
}
