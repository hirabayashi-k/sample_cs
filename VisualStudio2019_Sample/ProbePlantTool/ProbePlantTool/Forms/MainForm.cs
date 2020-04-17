using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takt.ProbePlantTool.Datas;

namespace Takt.ProbePlantTool.Forms
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PinBordnの描画
        /// </summary>
        /// <param name="tpcount">TPの個数</param>
        public void DrawPinBord(int tpcount)
        {
            int rate = 0;
            int bordWidth = int.Parse(PinBordWidthTextBox.Text);
            int bordHigth = int.Parse(PinBordHigthTextBox.Text);

            // 倍率の指定　未使用
            if (bordWidth > bordHigth)
            {
                rate = PinBordPanel.Width / bordWidth;
            }
            else
            {
                rate = PinBordHigthTextBox.Width / bordHigth;
            }

            if (rate < 1)
            {
                rate = 1;
            }

            Bitmap canvas = new Bitmap(bordWidth, bordHigth);

            PinBordPictureBox.Width = PinBordPanel.Width - 5;
            PinBordPictureBox.Height = PinBordPanel.Height - 5;
            PinBordPictureBox.BackColor = Color.DarkCyan;
            PinBordPictureBox.Image = canvas;
            PinBordPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Graphics g = Graphics.FromImage(canvas);
            SolidBrush bRed = new SolidBrush(Color.Red);
            SolidBrush bBlack = new SolidBrush(Color.Black);

            Font fnt = new Font("MS UI Gothic", 20);

            DataGridViewCell cell = SettingDataGridView.CurrentCell;

            int selectNo;
            try
            {
                // 描画が終わっていないタイミングで実行される場合がある為trycatchで囲む
                selectNo = cell.RowIndex;
            }
            catch
            {
                selectNo = -1;
            }

            for (int i = 0; i < tpcount; i++)
            {
                int x = GBdata.PinMapDatas[i].XAdress;
                int y = GBdata.PinMapDatas[i].YAdress;

                g.DrawString(GBdata.PinMapDatas[i].PinPloatAdress, fnt, Brushes.Black, x - 30, y - 30);

                if (i == selectNo)
                {
                    g.FillEllipse(bBlack, x - 10, y - 10, 20, 20);
                }
                else
                {
                    g.FillEllipse(bRed, x - 10, y - 10, 20, 20);
                }
            }

            // リソースを解放する
            g.Dispose();
        }

        /// <summary>
        /// スタートボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">ButtonEvent</param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            // 無処理
        }

        /// <summary>
        /// ストップボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">ButtonEvent</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            // 無処理
        }

        /// <summary>
        /// ロードボタン
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">ButtonEvent</param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            int tpcount = 50;

            GBdata.PinMapDatas.Clear();

            SettingDataGridView.Rows.Clear();

            Random r2 = new System.Random();

            // 疑似データの作成
            for (int i = 0; i < tpcount; i++)
            {
                PinMapData pinMapData = new PinMapData();

                int xData = r2.Next(10, 1490);
                int yData = r2.Next(10, 990);

                pinMapData.XAdress = xData;
                pinMapData.YAdress = yData;

                pinMapData.PinPloatAdress = "TP" + i.ToString();

                pinMapData.Name = "24V DET";

                pinMapData.Side = "A-SIDE";

                GBdata.PinMapDatas.Add(pinMapData);
            }

            // カラム数を指定
            SettingDataGridView.ColumnCount = 4;

            // カラム名を指定
            SettingDataGridView.Columns[0].HeaderText = "Adress";
            SettingDataGridView.Columns[1].HeaderText = "Name";
            SettingDataGridView.Columns[2].HeaderText = "X";
            SettingDataGridView.Columns[3].HeaderText = "Y";

            for (int i = 0; i < tpcount; i++)
            {
                SettingDataGridView.Rows.Add(GBdata.PinMapDatas[i].PinPloatAdress, GBdata.PinMapDatas[i].Name, GBdata.PinMapDatas[i].XAdress, GBdata.PinMapDatas[i].YAdress);
            }
        }

        /// <summary>
        /// データグリッド選択変更前イベント
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">Event</param>
        private void SettingDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // 未処理
        }

        /// <summary>
        /// データグリッド選択変更イベント
        /// </summary>
        /// <param name="sender">senderObject</param>
        /// <param name="e">Event</param>
        private void SettingDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DrawPinBord(GBdata.PinMapDatas.Count);
        }
    }
}
