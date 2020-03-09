using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSizeGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetBt_Click(object sender, EventArgs e)
        {
            //ディスプレイの高さ
            int h = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //ディスプレイの幅
            int w = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            // 
            LogTb.AppendText( string.Format("ディスプレイの高さ:{0}ピクセル\r\n", h));
            LogTb.AppendText(string.Format("ディスプレイの幅:{0}ピクセル\r\n", w));
            LogTb.AppendText(string.Format("フォームX座標 = {0}\r\n", this.Left));
            LogTb.AppendText(string.Format("フォームY座標 = {0}\r\n", this.Top));
            LogTb.AppendText(string.Format("フォームの横幅 = {0}\r\n", this.Width));
            LogTb.AppendText(string.Format("フォームの高さ = {0}\r\n", this.Height));


        }
    }
}
