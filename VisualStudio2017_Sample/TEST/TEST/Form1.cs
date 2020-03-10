using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{

    public class TRDNCLASS
    {
        public double RCurvature;         // 曲率半径
        public double Thickness;          // 厚さ
        public double RefractRate;        // 屈折率
        public double Radius;             // 有効半径
        public double DX, DY, DZ;         // シフト(mm)
        public double DA, DB;             // チルト(rad)
    }

    public partial class Form1 : Form
    {
        public struct TRDN
        {
            public double RCurvature;         // 曲率半径
            public double Thickness;          // 厚さ
            public double RefractRate;        // 屈折率
            public double Radius;             // 有効半径
            public double DX, DY, DZ;         // シフト(mm)
            public double DA, DB;             // チルト(rad)
        }

        public Form1()
        {
            InitializeComponent();
        }

        #region ボタン
        private void button1_Click(object sender, EventArgs e)
        {

            TRDN a;
            a.RCurvature = 0;
            a.Thickness = 0;
            a.RefractRate = 0;
            a.Radius = 0;
            a.DX = 0;
            a.DY = 0;
            a.DZ = 0;
            a.DA = 0;
            a.DB = 0;
            TRDN b;
            b.RCurvature = 0;
            b.Thickness = 0;
            b.RefractRate = 0;
            b.Radius = 0;
            b.DX = 0;
            b.DY = 0;
            b.DZ = 0;
            b.DA = 0;
            b.DB = 0;

            TRDN c;
            c.RCurvature = 0;
            c.Thickness = 0;
            c.RefractRate = 0;
            c.Radius = 0;
            c.DX = 0;
            c.DY = 0;
            c.DZ = 0;
            c.DA = 0;
            c.DB = 0;


            TRDN f;
            f.RCurvature = 0;
            f.Thickness = 0;
            f.RefractRate = 0;
            f.Radius = 0;
            f.DX = 0;
            f.DY = 0;
            f.DZ = 0;
            f.DA = 0;
            f.DB = 0;


            TRDN[] RDN = { a,b,c,f };

       
            int aa = RDN.GetLength(0);

            MessageBox.Show(aa.ToString());



        }

        private void button2_Click(object sender, EventArgs e)
        {
            TRDN a;
            a.RCurvature = 0;
            a.Thickness = 0;
            a.RefractRate = 0;
            a.Radius = 0;
            a.DX = 0;
            a.DY = 0;
            a.DZ = 0;
            a.DA = 0;
            a.DB = 0;
            TRDN b;
            b.RCurvature = 0;
            b.Thickness = 0;
            b.RefractRate = 0;
            b.Radius = 0;
            b.DX = 0;
            b.DY = 0;
            b.DZ = 0;
            b.DA = 0;
            b.DB = 0;

            TRDN c;
            c.RCurvature = 0;
            c.Thickness = 0;
            c.RefractRate = 0;
            c.Radius = 0;
            c.DX = 0;
            c.DY = 0;
            c.DZ = 0;
            c.DA = 0;
            c.DB = 0;


            TRDN f;
            f.RCurvature = 0;
            f.Thickness = 0;
            f.RefractRate = 0;
            f.Radius = 0;
            f.DX = 0;
            f.DY = 0;
            f.DZ = 0;
            f.DA = 0;
            f.DB = 0;

            TRDN d;
            d.RCurvature = 0;
            d.Thickness = 0;
            d.RefractRate = 0;
            d.Radius = 0;
            d.DX = 0;
            d.DY = 0;
            d.DZ = 0;
            d.DA = 0;
            d.DB = 0;

            TRDN g;
            g.RCurvature = 0;
            g.Thickness = 0;
            g.RefractRate = 0;
            g.Radius = 0;
            g.DX = 0;
            g.DY = 0;
            g.DZ = 0;
            g.DA = 0;
            g.DB = 0;

            TRDN[,] RDN = { { a, b },
                            { c, f },
                            { d, g} };


            int aa = RDN.GetLength(1);

            //TRDN[] bb =  RDN[0];

            MessageBox.Show(aa.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TRDN a;
            a.RCurvature = 0;
            a.Thickness = 0;
            a.RefractRate = 0;
            a.Radius = 0;
            a.DX = 0;
            a.DY = 0;
            a.DZ = 0;
            a.DA = 0;
            a.DB = 0;
            TRDN b;
            b.RCurvature = 0;
            b.Thickness = 0;
            b.RefractRate = 0;
            b.Radius = 0;
            b.DX = 0;
            b.DY = 0;
            b.DZ = 0;
            b.DA = 0;
            b.DB = 0;

            TRDN c;
            c.RCurvature = 0;
            c.Thickness = 0;
            c.RefractRate = 0;
            c.Radius = 0;
            c.DX = 0;
            c.DY = 0;
            c.DZ = 0;
            c.DA = 0;
            c.DB = 0;


            TRDN f;
            f.RCurvature = 0;
            f.Thickness = 0;
            f.RefractRate = 0;
            f.Radius = 0;
            f.DX = 0;
            f.DY = 0;
            f.DZ = 0;
            f.DA = 0;
            f.DB = 0;

            TRDN d;
            d.RCurvature = 0;
            d.Thickness = 0;
            d.RefractRate = 0;
            d.Radius = 0;
            d.DX = 0;
            d.DY = 0;
            d.DZ = 0;
            d.DA = 0;
            d.DB = 0;

            TRDN g;
            g.RCurvature = 0;
            g.Thickness = 0;
            g.RefractRate = 0;
            g.Radius = 0;
            g.DX = 0;
            g.DY = 0;
            g.DZ = 0;
            g.DA = 0;
            g.DB = 0;

            TRDN[][] RDN = new TRDN[3][];

            RDN[0] = new TRDN[2];
            RDN[1] = new TRDN[2];
            RDN[2] = new TRDN[2];

            RDN[0][0] = a;
            RDN[0][1] = b;

            RDN[1][0] = c;
            RDN[1][1] = d;

            RDN[2][0] = g;
            RDN[2][1] = f;


            TRDN[] xx = RDN[0];

            int aa = RDN.GetLength(0);

            MessageBox.Show(aa.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<List<TRDNCLASS>> RDNList =new List<List<TRDNCLASS>>
            {
                new List<TRDNCLASS>(){ new TRDNCLASS(),new TRDNCLASS(),new TRDNCLASS() },
                new List<TRDNCLASS>(){ new TRDNCLASS(),new TRDNCLASS(),new TRDNCLASS() },

            };

            List<TRDNCLASS[]> RDNList2 = new List<TRDNCLASS[]>
            {
                new TRDNCLASS[] { new TRDNCLASS(), new TRDNCLASS(), new TRDNCLASS() } ,
                new TRDNCLASS[] { new TRDNCLASS(), new TRDNCLASS(), new TRDNCLASS() } ,
            };


            //  trdnList1(ref RDNList[1]);


            TRDNCLASS a = testStatic.test1(100);

            TRDNCLASS b = testStatic.test1(200);


            MessageBox.Show("");

        }
        #endregion

        #region テストコード

        public void  trdnList1(ref TRDNCLASS[] aa)
        {

            aa[1].DA = 100;
        }

        public void trdnList1(ref List<TRDNCLASS> aa)
        {

            aa[1].DA = 100;
        }
        #endregion

    }

    public static class testStatic
    {

        public static TRDNCLASS test1(int abc)
        {
            TRDNCLASS a = new TRDNCLASS();

            a.DA = abc;

            return a;


        }

    }

}
