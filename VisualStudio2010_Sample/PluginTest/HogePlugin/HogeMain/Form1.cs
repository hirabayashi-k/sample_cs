using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HogePlugin;
using System.IO;
using System.Reflection;

namespace HogeMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ディレクトリ内のプラグインを取得して配列で返す
        private IHogePlugin[] GetPlugins(string path)
        {
            List<IHogePlugin> plugins = new List<IHogePlugin>();
            // ディレクトリ内のDLLファイルパスを取得
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                // ファイルパスからアセンブリを読み込む
                Assembly asm = Assembly.LoadFrom(dll);
                // アセンブリで定義されている型を取得（例 Namiheiクラス）
                foreach (Type type in asm.GetTypes())
                {
                    // 非クラス型、非パブリック型、抽象クラスはスキップ
                    if (!type.IsClass || !type.IsPublic || type.IsAbstract) continue;
                    // 型に実装されているインターフェイスから IHogePlugin を取得
                    Type t = type.GetInterfaces().FirstOrDefault((_t) => _t == typeof(IHogePlugin));
                    // default(IHogePlugin) と等しい場合は未実装なのでスキップ
                    if (t == default(IHogePlugin)) continue;
                    // 取得した型のインスタンスを作成（例 Namiheiクラス）
                    object obj = Activator.CreateInstance(type);
                    plugins.Add((IHogePlugin)obj);
                }
            }
            return plugins.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 実行ファイルのディレクトリを取得
            //string path = Path.GetDirectoryName(Application.ExecutablePath);
            string path = @"E:\sample_cs\VisualStudio2010_Sample\PluginTest\HogePlugin\Plugin";
            // ディレクトリ内のプラグインを取得
            foreach (IHogePlugin plugin in this.GetPlugins(path))
            {
                // 名前とコメントを表示
                MessageBox.Show(string.Format("{0}:{1}", plugin.Name, plugin.GetComment()));
            }
        }



    }
}
