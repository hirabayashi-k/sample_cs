using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 3;
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            ////ヘッダー以外のセル
            //if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            //{
            //    DataGridView dgv = (DataGridView)sender;
            //    //セルスタイルを変更する
            //    dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
            //    dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Red;
            //}
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            ////ヘッダー以外のセル
            //if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            //{
            //    DataGridView dgv = (DataGridView)sender;
            //    //セルスタイルを元に戻す
            //    //セルスタイルを削除するなら、nullを設定してもよい
            //   dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Empty;
            //    dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Empty;
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            e.CellStyle.BackColor = Color.Yellow;

            ////セルの列を確認
            //if ( e.Value is int)
            //{
            //    int val = (int)e.Value;
            //    //セルの値により、背景色を変更する
            //    if (val < 0)
            //    {
            //        e.CellStyle.BackColor = Color.Yellow;
            //    }
            //    else if (val == 0)
            //    {
            //        e.CellStyle.BackColor = Color.Red;
            //    }
            //}
        }
    }
}
