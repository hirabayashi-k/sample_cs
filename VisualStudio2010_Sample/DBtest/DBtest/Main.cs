using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBtest
{


    public partial class Main : Form
    {

        //接続文字列の生成
        string strSqlConnection = string.Empty;

        string databaseServer = "HIRABAYASHI\\SQLEXPRESS";

        string databaseName = "TestDB";

        string databaseConnTimeout = "3";


        public Main()
        {
            InitializeComponent();

            //Windows認証の場合
            strSqlConnection = String.Format(
                "Data Source={0};Integrated Security=SSPI;Initial Catalog={1};Connection Timeout={2};",
                databaseServer, databaseName, databaseConnTimeout);


            IniFile ini = new IniFile(@"D:\tmp\DBList.ini");

            List<string> dblist = null;

            try
            {
                dblist = ini.GetKeys("DB", "shift_jis");

            } catch (Exception) {
                MessageBox.Show("DBリストが正常ではありません。\r\nプログラムを終了します", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in dblist)
            {
                comboBox1.Items.Add(item);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                using (SqlConnection sn = new SqlConnection(strSqlConnection))
                {


                    //データベース接続を開く
                    sn.Open();
                    //SqlCommandのインスタンスを生成する
                    SqlCommand com = sn.CreateCommand();

                    string table = "Table_Syain";

                    test1 oj = new test1();

                    textBox1.AppendText(oj.SelectTest(com, table));

                    textBox1.AppendText(oj.SelectSample(com, table));


                    textBox1.AppendText(oj.getColumn(com, table));

                    textBox1.AppendText(oj.getColmnToDataType(com, table));


 

                    //データベース接続を閉じる
                    sn.Close();
                    sn.Dispose();
                }
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine("################エラー################");
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("######################################");
            }

        }

    }
}
