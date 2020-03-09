using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nearest
{
    static class Program
    {
        static void Main(string[] args)
        {
            var list = new[] { 0.1, 0.2, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9,0.2,0.05};

            double anser = Nearest(list, 0.23);
            Console.WriteLine(string.Format("方法1 目的の値に最も近い値を返します 0.23: value:[{0}]", anser));
            anser = Nearest(list, 0.01);
            anser = Nearest(list, 2.0);
            anser = Nearest(list, 0.5);


            anser = Nearest2(list, 0.01);
            Console.WriteLine(string.Format("方法2 目的の値に最も近い値を返します 0.01: value:[{0}]", anser));


            anser = Nearest2(list, 2.0);
            anser = Nearest2(list, 0.5);

            int anserIndex = 0;

            List<double> ListData = new List<double>();
            ListData.AddRange(list);

            anserIndex = FindClosestIndex(ListData, 0.23);
            Console.WriteLine(string.Format("目的の値に最も近い値のIndexを返す 0.23: Index:[{0}]", anserIndex));

            anserIndex = FindClosestIndex(ListData, 0.01);
            anserIndex = FindClosestIndex(ListData, 2.0);
            anserIndex = FindClosestIndex(ListData, 0.5);

            Console.ReadLine();

        }
        /// <summary>
        /// 目的の値に最も近い値を返します
        /// </summary>
        public static double Nearest(
            this IEnumerable<double> self,
            double target
        )
        {
            var min = self.Min(c => Math.Abs(c - target));
            return self.First(c => Math.Abs(c - target) == min);

        }

        /// <summary>
        /// 目的の値に最も近い値を返します
        /// </summary>
        public static double Nearest2(
            this IEnumerable<double> self,
            double target
        )
        {
            var min = self.Min(c => Math.Abs(c - target));
            return self.Nearest(target);

        }

        /// <summary>
        /// 目的の値に最も近い値のIndexを返す
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int  FindClosestIndex(List<double> list, double value)
        {
            double closest = list.Aggregate((x, y) => Math.Abs(x - value) < Math.Abs(y - value) ? x : y);
            return list.IndexOf(closest);
        }
    }
}
