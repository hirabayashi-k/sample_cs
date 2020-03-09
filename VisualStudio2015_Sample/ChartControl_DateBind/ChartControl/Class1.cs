using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartControl
{
    public class Class1
    {
        public Series AccScope;
        public ChartArea area1;

        public Task task;

        public Action<Delegate>  invo;

        public Action<Series, double, double> acSetPointXY;

        public Class1()
        {
            AccScope = new Series();
            AccScope.ChartType = SeriesChartType.Line;
            AccScope.ChartArea = "Acc"; // ChartAreaとの紐付名
            AccScope.Color = Color.Red;

            area1 = new ChartArea("Acc");

            area1.AxisX.Title = "[DataPoint]";
            area1.AxisY.Title = "[m/s2]";

            //chartAcc1.Series.Clear();
            //chartAcc1.ChartAreas.Add(area1);
            //chartAcc1.Series.Add(AccScope);
        }

        public async Task Start()
        {
            for (int i = 0; i < 20; i++)
            {

                AccScope.Points.AddXY(i, i);

                await Task.Delay(500);

                //System.Threading.Thread.Sleep(500);
            }
        }

        public void Start2()
        {

            Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    AccScope.Points.AddXY(i, i );
                    Task.Delay(500);
                }
            });
        }

        public void Start3()
        {
                for (int i = 0; i < 20; i++)
                {
                    AccScope.Points.AddXY(i, i);
                    Task.Delay(500);
                }
        }

        public void Start4()
        {
            task = Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    AccScope.Points.AddXY(i, i);
                    Task.Delay(500);
                }
            });
        }

        public void Start5()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    invo(new Action(() =>
                    {
                        AccScope.Points.AddXY(i, i);
                        Task.Delay(500);
                    }));

                }
            });
        }


        public void Start6()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    SetPointXY(AccScope,i,i);

                    // Task.Delayが利かない
                    //Task.Delay(500);
                    System.Threading.Thread.Sleep(500);
                }
            });
        }


        public void SetPointXY(Series se, double x, double y)
        {
            if (acSetPointXY != null) acSetPointXY(se, x, y);
        }

    }
}
