using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // DLL Import
//using Mc8000pWrap;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        [DllImport("MC8000P.dll")]
        public static extern void Nmc_Open(int hwnd, bool text);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MC8000P.Nmc_Open(0, false);
            Form1.Nmc_Open(0, false);


        }
    }
}
