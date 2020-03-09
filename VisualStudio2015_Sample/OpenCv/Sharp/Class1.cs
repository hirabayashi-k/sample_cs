using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    public static class Class1
    {
        public static void start()
        {
            /*
            using (var img = new IplImage(@"C:\Lenna.png"))
            {
                Cv.SetImageROI(img, new CvRect(200, 200, 180, 200));
                Cv.Not(img, img);
                Cv.ResetImageROI(img);
                using (new CvWindow(img))
                {
                    Cv.WaitKey();
                }
            }
            */


            IplImage img = Cv.CreateImage(new CvSize(128, 128), BitDepth.U8, 1);

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Cv.Set2D(img, y, x, x + y);
                }
            }

            Cv.NamedWindow("window");
            Cv.ShowImage("window", img);
            Cv.WaitKey();
            Cv.DestroyWindow("window");

            Cv.ReleaseImage(img);


        }


    }
}
