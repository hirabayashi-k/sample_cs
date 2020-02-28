using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Class1 smp;

        public Form1()
        {
            InitializeComponent();

            smp = new Class1();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smp.prc(ref textBox1);
        }
    }
}
