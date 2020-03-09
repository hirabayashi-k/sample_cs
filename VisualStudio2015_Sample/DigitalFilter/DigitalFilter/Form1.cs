using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalFilter
{
    public partial class Form1 : Form
    {

        public Series RawScope;          // 生データ
        public ChartArea area1;

        public Series FilterScope;          // 生データ
        public ChartArea area2;

        List<double> InData;
        List<double> OutData;

        public Form1()
        {
            InitializeComponent();

            comboBoxFile.SelectedIndex = 0;

            RawScope = new Series();
            RawScope.ChartType = SeriesChartType.Line;
            RawScope.ChartArea = "Raw"; // ChartAreaとの紐付名
            RawScope.Color = Color.Red;

            RawScope.Name = "Raw";


            area1 = new ChartArea("Raw");

            area1.AxisX.Title = "[DataPoint]";
            area1.AxisY.Title = "[mm]";


            FilterScope = new Series();
            FilterScope.ChartType = SeriesChartType.Line;
            FilterScope.ChartArea = "Filter"; // ChartAreaとの紐付名
            FilterScope.Color = Color.Blue;

            FilterScope.Name = "Raw2";

            area2 = new ChartArea("Filter");

            area2.AxisX.Title = "[DataPoint]";
            area2.AxisY.Title = "[mm]";


            area1.AxisX.Minimum = 0;
            area2.AxisX.Minimum = 0;


            InData = ReadData();

            int i = 0;

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();


            foreach (var data in InData)
            {
                RawScope.Points.AddXY(i,data);
                FilterScope.Points.AddXY(i, data);

                i++;
            }

            chart1.ChartAreas.Add(area1);
            chart1.Series.Add(RawScope);

            chart1.ChartAreas.Add(area2);
            chart1.Series.Add(FilterScope);

            OutData = new List<double>();

            area2.AxisY.Minimum = area1.AxisY.Minimum;
            area2.AxisY.Maximum = area1.AxisY.Maximum;



        }

        private void buttonlowpass_Click(object sender, EventArgs e)
        {
            FilterScope.Name = "ローパス";

            DisitalFilter filter = new DisitalFilter();

            FilterScope.Points.Clear();
            OutData.Clear();

            // カットオフ周波数 1000Hz、Q値 1/√2のローパスフィルタに設定

            filter.LowPass((float)numericUpDownHz.Value, 1.0f / (float)Math.Sqrt(2.0f),800000.0f);

            //filter.LowPass((float)numericUpDownHz.Value, 0.1f,800000.0f);


            // 入力信号にフィルタを適用していく。
            for (int i = 0; i < InData.Count; i++)
            {
                // 入力信号にフィルタを適用し、出力信号として書き出す。
                OutData.Add(filter.Process((float)InData[i]));
            }

            int point = 0;
            foreach (var data in OutData)
            {
                //if( !(point <= 0 || point <= 500))
                //{
                    FilterScope.Points.AddXY(point, data);

                //}

                point++;
            }

            area2.AxisY.Minimum = area1.AxisY.Minimum;
            area2.AxisY.Maximum = area1.AxisY.Maximum;

        }
        private void buttonHigthpass_Click(object sender, EventArgs e)
        {
            FilterScope.Name = "ハイパス";

            DisitalFilter filter = new DisitalFilter();

            FilterScope.Points.Clear();
            OutData.Clear();

            // カットオフ周波数 1000Hz、Q値 1/√2のローパスフィルタに設定
            filter.HighPass((float)numericUpDownHz.Value, 1.0f / (float)Math.Sqrt(2.0f), 800000.0f);

            // 入力信号にフィルタを適用していく。
            for (int i = 0; i < InData.Count; i++)
            {
                // 入力信号にフィルタを適用し、出力信号として書き出す。
                OutData.Add(filter.Process((float)InData[i]));
            }

            int point = 0;
            foreach (var data in OutData)
            {
                FilterScope.Points.AddXY(point, data);
                point++;
            }

            area2.AxisY.Minimum = area1.AxisY.Minimum;
            area2.AxisY.Maximum = area1.AxisY.Maximum;
        }

        private void buttonMoveAve_Click(object sender, EventArgs e)
        {
            FilterScope.Name = "移動平均";

            FilterScope.Points.Clear();
            OutData.Clear();

            MoveAve(InData.ToArray());

            int point = 0;
            foreach (var data in OutData)
            {
                FilterScope.Points.AddXY(point, data);
                point++;
            }

            area2.AxisY.Minimum = area1.AxisY.Minimum;
            area2.AxisY.Maximum = area1.AxisY.Maximum;

        }

        void MoveAve(double[] data)
        {
            int i, N;
            double sout= 0.0;

            N = (int)numericUpDownMoveArv.Value;

            for (i = 0; i < data.Count() - N; i++)
            {
                sout = 0.0;

                for (int pos = i; pos < (N + i); pos++)
                {
                    sout += data[pos];
                }

                OutData.Add(sout/N);
            }

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            InData = ReadData();

            int i = 0;


            FilterScope.Name = "Raw2";

            RawScope.Points.Clear();
            FilterScope.Points.Clear();


            foreach (var data in InData)
            {
                RawScope.Points.AddXY(i, data);
                FilterScope.Points.AddXY(i, data);

                i++;
            }


            //System.Threading.Thread.Sleep(200);
            //area2.AxisY.Minimum = area1.AxisY.Minimum;
            //area2.AxisY.Maximum = area1.AxisY.Maximum;
        }

        public List<double> ReadData()
        {
            List<double> ret = new List<double>();

            try
            {
                string filename = comboBoxFile.SelectedItem.ToString();

                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(filename + @".csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する

                        ret.Add(double.Parse(line));

                        //var values = line.Split(',');
                        //// 出力する
                        //foreach (var value in values)
                        //{
                        //    System.Console.Write("{0} ", value);
                        //}
                        //System.Console.WriteLine();
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }

            return ret;
        }

        private void WriteCsv()
        {
            try
            {
                string filename = comboBoxFile.SelectedItem.ToString();

                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = false;
                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(filename + @"_New.csv", append))
                {
                    for (int i = 0; i < OutData.Count; ++i)
                    {
                        // 
                        sw.WriteLine("{0}", OutData[i]);
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したときエラーメッセージを表示
                System.Console.WriteLine(e.Message);
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            WriteCsv();
        }
    }
}
