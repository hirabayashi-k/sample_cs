using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public class TVector
        {
            public double X, Y, Z;

            public TVector()
            {
                X = 0.0;
                Y = 0.0;
                Z = 0.0;
            }

            public TVector(double _X, double _Y, double _Z)
            {
                X = _X;
                Y = _Y;
                Z = _Z;
            }

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TVector vct = new TVector { X = 1, Y = 2, Z = 3 };

            textBox1.AppendText("X= " + vct.X.ToString() + "\r\n");
            textBox1.AppendText("Y= " + vct.Y.ToString() + "\r\n");
            textBox1.AppendText("Z= " + vct.Z.ToString() + "\r\n");


            TVector vct1 = new TVector(4, 5, 6);

            textBox1.AppendText("X1= " + vct1.X.ToString() + "\r\n");
            textBox1.AppendText("Y1= " + vct1.Y.ToString() + "\r\n");
            textBox1.AppendText("Z1= " + vct1.Z.ToString() + "\r\n");

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            ary ai0 = new ary(10, 10, 10);
            int i0, i1, i2;

            for (i0 = 0; i0 < 10; i0++)
            {
                for (i1 = 0; i1 < 10; i1++)
                {
                    for (i2 = 0; i2 < 10; i2++)
                    {
                        ai0[i0, i1, i2] = i0*100 +i1 * 10 + i2 + 1;
                    }
                }
            }

            for (i0 = 0; i0 < 10; i0++)
            {
                for (i1 = 0; i1 < 10; i1++)
                {
                    for (i2 = 0; i2 < 10; i2++)
                    {
                        textBox1.AppendText(ai0[i0, i1, i2].ToString() + "\r\n");
                    }
                }
            }

            smp1(ai0[(IntPtr)9]);


            IntPtr a = ai0.a(5);

            int[] b;

            //b = Marshal.PtrToStructure(a, typeof(int));

            ai0.Free();

        }

        void smp1(int[] a)
        {
            int i0;

            for(i0=0; i0<a.GetLength(0); i0++)
            {
                textBox1.AppendText("smp1: " +a[i0].ToString() + "\r\n");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            decimal d0;
            textBox1.AppendText("decimal max: " + decimal.MaxValue.ToString() +"\r\n");
            textBox1.AppendText("decimal min: " + decimal.MinValue.ToString() + "\r\n");

            d0 = 0.0000000000000000000000000000001M;
            textBox1.AppendText(d0.ToString() + "\r\n");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("aaaaaaaaaaaaaaaa");
            listBox1.Items.Add("bbbbbbbbbbbbbbbb");
            listBox1.Items.Add("cccccccccccccccc");
            listBox1.Items.Add("dddddddddddddddd");
            listBox1.Items.Add("eeeeeeeeeeeeeeee");
        }

        private void listBox1_Move(object sender, EventArgs e)
        {
            //label1.Text = listBox1.SelectedIndex.ToString();
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = listBox1.SelectedIndex.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach( int i0 in listBox1.SelectedIndices)
            {
                textBox1.AppendText(i0 +"," +listBox1.Items[i0]  +"\r\n");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(@"lcumpgraph.html");
        }
    }



    class ary
    {
        IntPtr memarea;
        int _a, _b, _c;
        int _aa, _bb, _cc;
        int siz;

        public int this[int a]
        {
            get { return Marshal.ReadInt32(memarea, siz * a*_aa); }
            set { Marshal.WriteInt32(memarea, siz * a*_aa, value); }
        }


        public int this[int a, int b]
        {
            get { return Marshal.ReadInt32(memarea, siz * ((a * _aa) + (b*_bb)) ); }
            set { Marshal.WriteInt32(memarea, siz * ((a * _aa) + (b * _bb)), value); }
        }

        public int this[int a, int b, int c]
        {
            get { return Marshal.ReadInt32(memarea, siz  * ((a*_aa) +(b*_bb) + c) ); }
            set { Marshal.WriteInt32(memarea, siz * ((a * _aa) + (b * _bb) + c), value); }
        }

        public int[] this[IntPtr a]
        {
            get {
                    int[] Result = new int[siz * _aa];
                    IntPtr idx = (IntPtr)((int)memarea + siz * (int)a * _aa);
                    Marshal.Copy(idx, Result, 0, Result.GetLength(0));
                    return Result;}
            //set { Marshal.WriteInt32(memarea, siz * a * _aa, value); }
        }


        public IntPtr a(int idx)
        {
            IntPtr pt = (IntPtr)((int)memarea + +siz * idx * _aa);
            return pt;
        }



        public ary( int a, int b, int c)
        {
            int i0;

            memarea = (IntPtr)0;
            siz = Marshal.SizeOf(typeof(int));

            _a = a;
            _b = b;
            _c = c;

            if (_a < 1)
            {
                return;
            }

            i0 = 0;
            _aa = 0;
            _bb = 0;
            _cc = _a;

            if (0 < _b)
            {
                _aa = _b;
                _cc = _a * _b; 
            }

            if (0 < _c)
            {
                _aa = _b * _c;
                _bb = _c;
                _cc = _a * _b * _c;
            }

            //memarea = Marshal.AllocCoTaskMem(d * (_a * _b * _c));
            memarea = Marshal.AllocHGlobal(siz * _cc);
        }

        ~ary()
        {
            this.Free();
        }

        public void Free()
        {
            if (memarea != (IntPtr)0)
            {
                //Marshal.FreeCoTaskMem(memarea);
                Marshal.FreeHGlobal(memarea);
                memarea = (IntPtr)0;
            }
        }



    }
}
