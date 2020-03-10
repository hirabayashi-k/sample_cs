using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sqlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.IO.StreamWriter RS;
            RS = System.IO.File.AppendText(@"C:\log.txt");

            RS.WriteLine("aaa");

            RS.Close();

            string sql = "insert into Reuse (qrcode,optime,indate	)values('12345678AMMV',	65535,'2015/4/10')";

            System.Data.OleDb.OleDbCommand com;
            System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection();
            cn.ConnectionString
            = @"Provider=SQLOLEDB.1;Password=daikoku;Persist Security Info=True;User ID=sa;Initial Catalog=ReuseDB;Data Source=200.168.1.11";

            // トランザクションを開始します。
            cn.Open();
            try
            {
                com = new System.Data.OleDb.OleDbCommand(sql,cn);
                com.ExecuteNonQuery();
                cn.Close();
            }
            catch (System.Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "通知");
            }
            finally
            {
            }


        }
    }
}
