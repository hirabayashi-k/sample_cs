using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;   // VS_FIXEDFILEINFO


namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s0 = string.Format("{0:d}.{1:d}.{2:d}.{3:d}", 1, 2, 3, 4);
            textBox1.AppendText(s0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string s0 = Environment.SystemDirectory + "\\Notepad.exe";
            string s0 = "e:\\WUTEMP\\lcump.exe";
            FileVersionInfo vinf = FileVersionInfo.GetVersionInfo(s0);

            textBox1.AppendText(vinf.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i0;
            string s0;
            byte[] b0;

            TVerInfoRes a = new TVerInfoRes("e:\\WUTEMP\\lcump.exe");
            /*
                        b0 = a.getinfo();

                        for(i0=0; i0<b0.GetLength(0); i0+=4)
                        {
                            s0 = string.Format("{0,2:x2}{1,2:x2}{2,2:x2}{3,2:x2}\r\n", b0[i0 + 0], b0[i0 + 1], b0[i0 + 2], b0[i0 + 3]);
                            textBox1.AppendText(s0);
                        }


                        for (i0 = 0; i0 < 10; i0++)
                        {
                            b0 = a.GetPreDefKeyString((TVerInfoRes.TVerInfoType)i0);

                            if (b0 != null)
                            {
                                textBox1.AppendText(b0.ToString());
                            }
                        }
                        */

            FileVersionInfo vinf = FileVersionInfo.GetVersionInfo("e:\\WUTEMP\\lcump.exe");

            textBox1.AppendText(vinf.LegalTrademarks);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.OriginalFilename);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.LegalCopyright);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.Comments);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.CompanyName);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FileDescription);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FileName);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FileVersion);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.InternalName);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.Language);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.PrivateBuild);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductName);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductVersion);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.SpecialBuild);
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductBuildPart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FileMajorPart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FileMinorPart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.FilePrivatePart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductMajorPart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductMinorPart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText(vinf.ProductPrivatePart.ToString());
            textBox1.AppendText("\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("\r\n");

        }
    }
}
