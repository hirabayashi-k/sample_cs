using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialog
{
    public partial class Form2 : Form
    {
        // データを持たないイベントデリゲートの宣言
        //ここでは"Time"というイベントデリゲートを宣言する
        public event EventHandler Occurrence;

        public delegate void Occurrence2Handler(object sender, EventArgs1 e);

        public event Occurrence2Handler Occurrence2;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void Start()
        {
          //  System.Threading.Thread.Sleep(5000);
            if (Occurrence != null)
            {
                //"Time"イベントの発生
                Occurrence(this, EventArgs.Empty);
            }
        }

        public void Start2(EventArgs1 e)
        {
            //  System.Threading.Thread.Sleep(5000);
            if (Occurrence2 != null)
            {
                //"Time"イベントの発生
                Occurrence2(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventArgs1 ev = new EventArgs1();
            ev.Message = "終わったよ。";

            Start2(ev);
        }
    }
}
