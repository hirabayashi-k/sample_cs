using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartControl
{
    public partial class Form1 : Form
    {
        Class1 obj;

        Series scope;

        Series test;
        Series test2;
        Series test3;
        ChartArea area;
        ChartArea area2;

        public Form1()
        {
            InitializeComponent();

            obj = new Class1();


            chart1.Series.Clear();
            chart1.ChartAreas.Add(obj.area1);
            chart1.Series.Add(obj.AccScope);

            // プロパティで設定されたチャートクリアする
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            // Test グラフ設定
            {
                //Seriesの作成
                test = new Series();
                test.ChartArea = "Test";
                test.Name = "Test";
                // ChartAreaの作成
                area = new ChartArea("Test");

                // チャートを追加
                chart2.ChartAreas.Add(area);
                // Seriesをchartコントロールに追加する
                chart2.Series.Add(test);

                //グラフのタイプを指定(今回は線)
                test.ChartType = SeriesChartType.Line;

                //グラフのデータを追加(試しにsin関数)
                for (int i = 1; i < 360; i++)
                {
                    test.Points.AddXY(i, Math.Sin(i * Math.PI / 180.0));
                }

                test3 = new Series();
                test3.ChartArea = "Test";
                test3.Name = "Test3";
                chart2.Series.Add(test3);
                test3.ChartType = SeriesChartType.Point;

                for (int i = 1; i < 360;  i+=10)
                {
                    test3.Points.AddXY(i, Math.Sin(i * Math.PI / 180.0));
                }

                test3.Points[3].Label = "aa";

                TextAnnotation ana = new TextAnnotation();

                ana.Name = "step";

                ana.X = 3;
                ana.Y = 4;

                chart2.Annotations.Add(ana);

               // chart2.Annotations[0].AnchorDataPoint = chart2.Series[1].Points[1];

            }


            // Test2グラフ設定
            {
                //Seriesの作成
                test2 = new Series();
                test2.ChartArea = "Test2";
                test2.Name = "Test2";
                // ChartAreaの作成
                area2 = new ChartArea("Test2");


                // チャートを追加
                chart2.ChartAreas.Add(area2);
                // Seriesをchartコントロールに追加する
                chart2.Series.Add(test2);

                //グラフのタイプを指定(今回は線)
                test2.ChartType = SeriesChartType.Line;

                //グラフのデータを追加(試しにsin関数)
                for (int i = 1; i < 360; i++)
                {
                    test2.Points.AddXY(i, Math.Sinh(i * Math.PI / 180.0));
                }
            }
            // 対数グラフ設定
            chart2.ChartAreas.First().AxisX.IsLogarithmic = true;

            // 積み上げ棒グラフ
            {
                string[] legends = new string[] { "グラフ１", "グラフ２", "グラフ３" }; //凡例

                chart3.Series.Clear();  //グラフ初期化

                // 罫線の削除
                chart3.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
                chart3.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;

                //chart3.ChartAreas[0].Position.Y = 10;
                chart3.ChartAreas[0].Position.Auto = false;
                chart3.ChartAreas[0].Position.Width = 100F;
                chart3.ChartAreas[0].Position.Height = 20.0F;
                //chart3.ChartAreas[0].Position.X = 10.0F;
                chart3.ChartAreas[0].Position.Y = 13.0F;

                // シリーズの作成
                foreach (var item in legends)
                {
                    chart3.Series.Add(item);    //グラフ追加
                                                //グラフの種類を指定（Columnは積み上げ縦棒グラフ）
                    //chart3.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    chart3.Series[item].LegendText = item;  //凡例に表示するテキストを指定

                    // 横棒　積み上げ設定
                    chart3.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                }

                //string[] xValues = new string[] { "A", "B", "C", "D", "E" };    //X軸のデータ
                string[] xValues = new string[] { "step"};    //X軸のデータ
                int[,] yValues = new int[,] { { 10, 20, 30, 40, 50 }, { 20, 40, 60, 80, 100 }, { 20, 40, 60, 80, 100 } };    //Y軸のデータ

                for (int i = 0; i < xValues.Length; i++)
                {
                    for (int j = 0; j < yValues.GetLength(0); j++)
                    {
                        //グラフに追加するデータクラスを生成
                        System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                        dp.SetValueXY(xValues[i], yValues[j, i]);  //XとYの値を設定
                        dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                        chart3.Series[legends[j]].Points.Add(dp);   //グラフにデータ追加

                        // 凡例名の非表示
                        chart3.Series[legends[j]].IsVisibleInLegend = false;
                    }
                }
            }

        }

        /// <summary>
        /// invokeの中でasync awaite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_TEST_Click(object sender, EventArgs e)
        {
            try
            {
                obj.AccScope.Points.Clear();


                this.Invoke(new Action(async () =>
                {
                        await obj.Start();
                }));
        

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// Task.Runの中でincoke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            Task.Run(() =>  {
                int total = 0;
                for (int i = 1; i <= 10; ++i)
                {
                    total += i;
                    Thread.Sleep(500); // 何か重い処理をしている...
                    this.Invoke(new Action(() =>
                    {
                        textBox1.Text = total.ToString();
                    }));
                }

                Thread.Sleep(4000); // 何か重い処理をしている...

                this.Invoke(new Action(() =>
                {
                    textBox1.Text = "End";
                }));

               // return total;
            });

            //MessageBox.Show(task.ToString());
        }

        /// <summary>
        /// invokeの中でTask.Run 　例外発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTEST3_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                obj.Start2();
            }));
        }

        /// <summary>
        /// invokeの中でTask.Run 2 例外発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest4_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Task.Run(() =>
                {
                    obj.Start3();
                });
            }));
        }
        /// <summary>
        /// Invoke Task.Run await
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Invoke(new Action(async () =>
                {

                    obj.Start4();

                    Thread.Sleep(100);

                    await obj.task;
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonTest6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            Task<int> task = Task.Run<int>(() =>
            {
                int total = 0;
                for (int i = 1; i <= 100; ++i)
                    total += i;
                Thread.Sleep(4560); // 何か重い処理をしている...
                return total;
                });
            int result = await task;
            textBox2.Text = $"{result}"; // 雑なstring変換


         
        }

        /// <summary>
        /// SetPointXYをStart6で呼び出すﾊﾟﾀｰﾝ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            obj.AccScope.Points.Clear();
            obj.acSetPointXY = this.SetPointXY;
            obj.Start6();
        }


        public void SetPointXY(Series se, double x, double y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    se.Points.AddXY(x,y);
                }));

                return;
            }

            se.Points.AddXY(x, y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
             chart1.Series.Clear();
             chart1.ChartAreas.Clear();

        }
        /// <summary>
        /// データ取得関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            DataPoint[] data = chart2.Series["Test"].Points.ToArray();

            foreach(DataPoint point in data)
            {
                textBox3.AppendText(point.ToString() + "\r\n");
            }
        }
        /// <summary>
        /// シリアル化セーブ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            chart2.Serializer.Save("SavedData.xml");
            //Chart1.Serializer.Load("SavedData.xml");
            textBox3.AppendText("SavedData.xml に保存\r\n");
        }
        /// <summary>
        /// ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
//            chart2.Series.Clear();
            chart2.Serializer.Load("SavedDataCos.xml");
            textBox3.AppendText("SavedDataCos.xml ロード\r\n");

        }
        /// <summary>
        /// チャート出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            chart2.SaveImage("chart.jpg", ChartImageFormat.Jpeg);
            textBox3.AppendText("chart.jpg 出力\r\n");
        }
        /// <summary>
        /// 画面出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            //using System.Drawing;

            //コントロールの外観を描画するBitmapの作成
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            //キャプチャする
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            //ファイルに保存する
            bmp.Save("画面.png");
            //後始末
            bmp.Dispose();

            textBox3.AppendText("画面.png 出力\r\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("./", "Chart*.xml");


            //ファイル消す
            foreach (string file in files)
            {

                File.Delete(file);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            chart3.Series.Add("グラフ４");    //グラフ追加
                                          //グラフの種類を指定（Columnは積み上げ縦棒グラフ）
                                          //chart3.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart3.Series["グラフ４"].LegendText = "グラフ４";  //凡例に表示するテキストを指定

            // 横棒　積み上げ設定
            chart3.Series["グラフ４"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;

            //グラフに追加するデータクラスを生成
            System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
            dp.SetValueXY("step", 100);  //XとYの値を設定
            dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
            chart3.Series["グラフ４"].Points.Add(dp);   //グラフにデータ追加

            // 凡例名の非表示
            chart3.Series["グラフ４"].IsVisibleInLegend = false;


        }

        private void button11_Click(object sender, EventArgs e)
        {

            //グラフに追加するデータクラスを生成
            System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
            dp.SetValueXY("step", 100);  //XとYの値を設定

            chart3.Series["グラフ１"].Points.Clear();

            chart3.Series["グラフ１"].Points.Add(dp);   //グラフにデータ追加

            dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
            // 凡例名の非表示
            //chart3.Series["グラフ１"].IsVisibleInLegend = false;
        }
    }
}
