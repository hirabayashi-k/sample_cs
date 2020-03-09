using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static XmlserializerTest.XmlClass2;

namespace XmlserializerTest
{


    /// <summary>
    /// XmlSerializerについて
    /// 
    /// 保存すればするほどメモリリークを発生させる
    /// アプリのメモリを監視するとわかる
    /// 
    /// サバ太郎などでの電源断時、セーブを行っているとファイルを保持したままとなり、再起動後にファイルが壊れる
    /// 対応方法は　XmlSerializerに通すのは別名のファイルで行う
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        XmlClass1 cs = new XmlClass1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //保存
            FileUtil.SaveComXml(textBox1.Text, StaticClass1.test);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 読込み
            FileUtil.LoadComXml(textBox1.Text,ref StaticClass1.test);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 保存
            
            FileUtil.SaveComXml(textBox1.Text, cs);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 読込み
            FileUtil.LoadComXml(textBox1.Text, ref cs);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileUtil.SaveToFile(textBox1.Text,cs, typeof(XmlClass1));
        }

        private void button6_Click(object sender, EventArgs e)
        {
          cs =(XmlClass1)  FileUtil.LoadFromFile<XmlClass1>(textBox1.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileUtil.SaveToFile(textBox1.Text, StaticClass1.test, typeof(XmlClass1));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StaticClass1.test = (XmlClass1)FileUtil.LoadFromFile<XmlClass1>(textBox1.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Title =
                    "The Art of Readable Code: Simple and Practical Techniques for Writing Better Code (Theory in Practice)",
                Published = new DateTime(2011, 11, 3),
                Authors = new List<Author>
                {
                    new Author {AuthorName = "Dustin Boswell"},
                    new Author {AuthorName = "Trevor Foucher"}
                }
            };

            // シリアライズ
            var writer = new StringWriter(); // 出力先のWriterを定義
            var serializer = new XmlSerializer(typeof(Book)); // Bookクラスのシリアライザを定義
            serializer.Serialize(writer, book);

            var xml = writer.ToString();
            Console.WriteLine(xml);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";

            // ファイルへオブジェクトを書き込み（シリアライズ）
            using (var outwriter = XmlWriter.Create("./xmlClass2.xml", settings))
            {
                serializer.Serialize(outwriter, book);
            }


            // デシリアライズ
            var deserializedBook = (Book)serializer.Deserialize(new StringReader(xml));

            Console.WriteLine($"Title: {deserializedBook.Title}");
            Console.WriteLine($"Published: {deserializedBook.Published}");
            foreach (var author in deserializedBook.Authors)
            {
                Console.WriteLine($"AuthorName: {author.AuthorName}");
            }

        }
    }
}
