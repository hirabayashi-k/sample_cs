using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            var ini = new IniFile(@"E:\日本語\IniFile\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Sample.ini");

            var s1 = ini.Read("", "RootKey"); // ""
            var s2 = ini.Read("Section Space Name", "fullscreen"); // false
            var s3 = ini.Read(" Section Space Name ", "fullscreen"); // false
            var s4 = ini.Read("IgnoreCase", "name"); // (文字化けで取得可)
            var s5 = ini.Read("ignorecase", "name"); // (文字化けで取得可)
            var s6 = ini.Read("日本語セクション", "files"); // ""

            // s1のケースでSectionをnullで指定すると・・・
            var s1_null = ini.Read(null, "RootKey"); // Section Space Name

      
        }
    }


    public class IniFile
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileString(
            string lpAppName, string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, uint nSize, string lpFileName);

        private readonly StringBuilder _builder = new StringBuilder(255);
        public string FullName { get; set; }

        public IniFile(string filePath)
        {
            FullName = Path.GetFullPath(filePath);
        }

        public string Read(string section, string key, string defaultValue = null)
        {
            _builder.Clear();
            GetPrivateProfileString(section, key, defaultValue, _builder, 255, FullName);
            return _builder.ToString();
        }
    }
}
