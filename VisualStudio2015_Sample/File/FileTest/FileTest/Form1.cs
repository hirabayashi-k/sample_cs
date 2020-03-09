using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTest
{
    public partial class Form1 : Form
    {

        // カレントディレクトリを取得する
        string stCurrentDir;

        public Form1()
        {
            InitializeComponent();

            // カレントディレクトリを取得する
            stCurrentDir = System.IO.Directory.GetCurrentDirectory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(stCurrentDir + @"\Test.txt", true, sjisEnc);
                writer.WriteLine("テスト書き込みです。");
                writer.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                System.IO.File.Delete(stCurrentDir + @"\Test.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // 保存フォルダがない場合は作成する

                //string dirName = Path.GetDirectoryName(FileName); // パス名のフォルダ部を取得 後ろから検索して最初に見つかった\以降を切る

                string dirName = stCurrentDir　+ @"\Test\Test2"; // パス名のフォルダ部を取得
                if (dirName != "" && Directory.Exists(dirName) == false)
                {
                    Directory.CreateDirectory(dirName); // 複数階層でも一気に作成可能
                }

                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(dirName + @"\Test.txt", true, sjisEnc);
                writer.WriteLine("テスト書き込みです。");
                writer.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string delFolder = stCurrentDir + @"\Test";

                // 第２引数を　falseにするとフォルダが空の場合、削除できない
                System.IO.Directory.Delete(delFolder,true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("BaseDirectory       :" + System.AppDomain.CurrentDomain.BaseDirectory + "\r\n");
            textBox1.AppendText("GetCurrentDirectory :" + Directory.GetCurrentDirectory() + "\r\n");
            textBox1.AppendText("GetExecutingAssembly:" + Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\r\n");
            textBox1.AppendText("CurrentDirectory    :" + Directory.GetParent(Environment.CurrentDirectory) + "\r\n");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(FileUtility.ExpandUNCFileName("Z:") + "\r\n");
            textBox1.AppendText(FileUtility.ExpandUNCFileName(@"Z:\平林\D\打鍵テスト.txt") + "\r\n" );

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string oldPath = @"Text.txt";

            // 拡張子を変更する
            string newPath =
              Path.ChangeExtension(oldPath, ".txt.bak");

            // 実際のファイル名を変更する
            textBox1.AppendText(newPath + Environment.NewLine);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string oldPath = @"Text";

            // 拡張子を変更する
            string newPath =
              Path.ChangeExtension(oldPath, ".txt.bak");

            // 実際のファイル名を変更する
            textBox1.AppendText(newPath + Environment.NewLine);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText (FileUtility.GetPathWithoutExtension(@"C\Text.txt") + Environment.NewLine);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(FileUtility.GetExtension(@"C\Text.txt") + Environment.NewLine);
        }
    }
}
