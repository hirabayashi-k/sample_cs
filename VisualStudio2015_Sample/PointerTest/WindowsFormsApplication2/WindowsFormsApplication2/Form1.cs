using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Class1 myClass = new Class1();

            GCHandle handle = GCHandle.Alloc(myClass);
            unsafe
            {
                myClass.Init();

                myClass.ss();
                GC.Collect();
                myClass.ss();
                GC.Collect();
                myClass.ss();
                GC.Collect();
                myClass.ss();


                // 1行にまとめると、
                // void* p = (void*)(IntPtr)GCHandle.Alloc(myClass);
            }
            handle.Free();

            textBox1.Text = myClass.dd[0].ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            // 違いがわからない　GCが入るとメモリが最適化されてしまう確認
            Class1 myClass = new Class1();

            myClass.Init();
            myClass.ss();
            GC.Collect();
            myClass.ss();
            GC.Collect();
            myClass.ss();
            GC.Collect();
            myClass.ss();

            textBox1.Text = myClass.dd[0].ToString();

            



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 myClass = new Class1();

            GCHandle handle = GCHandle.Alloc(myClass);
            unsafe
            {
                myClass.Init();
                myClass.ss();
                GC.Collect();
                myClass.ss();
                GC.Collect();
                myClass.ss();
                GC.Collect();
                myClass.ss();

                textBox1.Text = myClass.copy();

                textBox1.Text = "a";

                textBox1.Text = myClass.copy();

                int c = myClass.copy().Length;

                char[] src = myClass.copy().ToArray();


                // 1行にまとめると、
                // void* p = (void*)(IntPtr)GCHandle.Alloc(myClass);
            }
            handle.Free();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool Result = false;
            string sptr;

            Class1 myClass = new Class1();

            GCHandle handle = GCHandle.Alloc(myClass);
            unsafe
            {
                myClass.Init();

                Result = myClass.resize(out sptr);
            }
            handle.Free();


            textBox1.Text = Result.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool Result = false;

            Class1 myClass = new Class1();

            GCHandle handle = GCHandle.Alloc(myClass);
            unsafe
            {
                myClass.Init();

                Result = myClass.resizeMovePointer();
            }
            handle.Free();


            textBox1.Text = Result.ToString();
        }
    }
}
