using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Row 10行
            dataGridView2.RowCount = 10;

            // ヘッダテキスト
            for (int i = 0; i < 10; i++)
            {
                dataGridView2.Rows[i].HeaderCell.Value = i.ToString();
            }

            // Coulmn を追加
            dataGridView2.ColumnCount = 4;

            dataGridView2.Columns[3].HeaderText = "追加行4";


            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


        }

        private void ReadBt_Click(object sender, EventArgs e)
        {


            //dataGridView1.CurrentCell.RowIndex;

            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.xml";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "xmlファイル(*.xml)|*.xml;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //1番目の「xmlファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
               // Console.WriteLine(ofd.FileName);


                SlipsDataSet.ReadXml(ofd.FileName);

                dataGridView1.DataSource = SlipsDataSet;
                dataGridView1.DataMember = "slips";

                // 左上隅
                dataGridView1.TopLeftHeaderCell.Value = "/";

                //dataGridView1.DataMember = "slips2";
                //dataGridView1.DataMember = "slips3";

            }

        }

        private void WriteBt_Click(object sender, EventArgs e)
        {

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "新しいファイル.html";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = System.Environment.CurrentDirectory;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            sfd.Filter = "xmlファイル(*.xml)|*.xml;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                SlipsDataSet.WriteXml(sfd.FileName);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(
                System.IO.Path.GetDirectoryName(
                    @"C:\My Documents\My Pictures\"));
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void setbt_Click(object sender, EventArgs e)
        {
            try {
                // Column , Row 
                dataGridView1[0, 1].Value = setbt.Text;
            } catch (Exception)
            {
                MessageBox.Show("XMLを読み込んでください");

            }
        }

        private void set2bt_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows[0].Cells[1].Value = set2bt.Text;
            } catch (Exception)
            {
                MessageBox.Show("XMLを読み込んでください");

            }
        }

        private void tabbt_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows[0].Tag = 1;
                dataGridView1.Rows[1].Tag = 2;
                dataGridView1.Rows[2].Tag = 3;

                MessageBox.Show(string.Format("Tag0:{0} Tag1:{1} Tag2:{2}",
                    (int)dataGridView1.Rows[0].Tag,
                    (int)dataGridView1.Rows[1].Tag,
                    (int)dataGridView1.Rows[2].Tag
                    ));

            } catch(Exception)
            {
                MessageBox.Show("XMLを読み込んでください");
            }




        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ValueChanged:" + numericUpDown1.Value);
        }

        private void CommaHedder_Click(object sender, EventArgs e)
        {
            try
            {
                string Result = "";

                Result = (string)dataGridView1.TopLeftHeaderCell.Value;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    // カンマ区切り
                    Result = Result + ",";

                    Result = Result + dataGridView1.Columns[i].HeaderText;
                }

                Log.AppendText(Result + "\n");
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Cells[0].Value = "0";
            dataGridView1.Rows[1].Cells[0].Value = "1";
            dataGridView1.Rows[2].Cells[0].Value = "2";

            dataGridView1.Rows[0].HeaderCell.Value = "0";
            dataGridView1.Rows[1].HeaderCell.Value = "1";
            dataGridView1.Rows[2].HeaderCell.Value = "2";



        }

        private void button3_Click(object sender, EventArgs e)
        {
            // int a = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.RowCount = 51;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 17;

            dataGridView1.RowCount = 17;
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 全てイベントが発生した後に行レベルのペイントを実行する

        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //背景を描画するか
            if ((e.PaintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
            {

                int i = e.RowIndex;

 

                //選択されているか調べ、色を決定する
                //bColor1が開始色、bColor2が終了色
                Color bColor1, bColor2;
                if ((e.PaintParts & DataGridViewPaintParts.SelectionBackground) ==
                        DataGridViewPaintParts.SelectionBackground &&
                    (e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
                {
                    bColor1 = e.InheritedRowStyle.SelectionBackColor;
                    bColor2 = Color.Black;
                }
                else
                {
                    bColor1 = e.InheritedRowStyle.BackColor;
                    bColor2 = Color.YellowGreen;
                }

                //グラデーションの範囲を計算する
                //ヘッダーを除くセルの部分だけ描画する
                DataGridView dgv = (DataGridView)sender;
                int rectLeft2 = dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0;
                int rectLeft = rectLeft2 - dgv.HorizontalScrollingOffset;
                int rectWidth = dgv.Columns.GetColumnsWidth(
                    DataGridViewElementStates.Visible);
                Rectangle rect = new Rectangle(rectLeft, e.RowBounds.Top,
                    rectWidth, e.RowBounds.Height - 1);

                //グラデーションブラシを作成
                using (System.Drawing.Drawing2D.LinearGradientBrush b =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect, bColor1, bColor2,
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    //描画する範囲を計算する
                    rect.X = rectLeft2;
                    rect.Width -= dgv.HorizontalScrollingOffset;
                    //セルを塗りつぶす
                    e.Graphics.FillRectangle(b, rect);
                }

                //ヘッダーを描画する
                e.PaintHeader(true);

                //背景を描画しないようにする
                e.PaintParts &= ~DataGridViewPaintParts.Background;





            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Log.Text = Log.Text +  "ADD\r\n";

            //カレット位置を末尾に移動
            Log.SelectionStart = Log.Text.Length;
            //テキストボックスにフォーカスを移動
            Log.Focus();
            //カレット位置までスクロール
            Log.ScrollToCaret();



            //コントロールを初期化する
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            progressBar1.Value = 0;
            label1.Text = "0";
            //Label1を再描画する
            label1.Update();

            //時間のかかる処理を開始する
            for (int i = 1; i <= 10; i++)
            {
                //1秒間待機する（時間のかかる処理があるものとする）
                System.Threading.Thread.Sleep(1000);

                //ProgressBar1の値を変更する
                progressBar1.Value = i;
                //Label1のテキストを変更する
                label1.Text = i.ToString();

                //Label1を再描画する
                label1.Update();
                //（フォーム全体を再描画するには、次のようにする）
                //this.Update();
            }

        }
    }
}
