using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "メリー・クリスマス";

            Type t = this.GetType();

            // Type stringType = typeof(string); // これでもOK

            // 以下はmsg.Remove(0, 4)と同じ
            //
            MethodInfo mi1 = t.GetMethod("OriginRemove");
            string removed
                = (string)mi1.Invoke(this, new object[] {msg, 0, 4 });

            textBox1.Text = removed; // 出力：クリスマス

        }


        public string OriginRemove(string st,int a,int b)
        {
            return st.Remove(a,b);
        }

    }
}
