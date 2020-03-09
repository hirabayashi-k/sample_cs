using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegateTest
{

    public delegate void myDelegate(string msg);

    public partial class Form1 : Form
    {

        Base1 delg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myDelegate md1 = new myDelegate(textBoxPut);

            delg = new Base1(md1, textBoxIn.Text);
        }

        private void buttonDelegate_Click(object sender, EventArgs e)
        {
            delg.doProc();
        }


        public void textBoxPut(string msg)
        {

            textBoxDelegate.Text = msg;

        }


    }
}
