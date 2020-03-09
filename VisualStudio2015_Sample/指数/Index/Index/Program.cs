using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    class Program
    {
        static void Main(string[] args)
        {
            test1();
            test2();
            test3();
            test4();
            Console.ReadLine();

        }

        static public void test1()
        {
            var ns = NumberStyles.Float;
            var fmt = CultureInfo.InvariantCulture;

            string s1 = "2.12345678975E9";
            decimal dm; double d1; float f1;
            decimal.TryParse(s1, ns, fmt, out dm); // true
            double.TryParse(s1, ns, fmt, out d1);  // true
            float.TryParse(s1, ns, fmt, out f1);  // true
            Console.WriteLine("{0:N4}", dm); // 2,123,456,789.7500
            Console.WriteLine("{0:N4}", d1); // 2,123,456,789.7500
            Console.WriteLine("{0:N4}", f1); // 2,123,457,000.0000
        }

        static public void test2()
        {
            var ns = NumberStyles.Float;
            var fmt = CultureInfo.InvariantCulture;

            string s1 = "2.12345678975E-9";
            decimal dm; double d1; float f1;
            decimal.TryParse(s1, ns, fmt, out dm); // true
            double.TryParse(s1, ns, fmt, out d1);  // true
            float.TryParse(s1, ns, fmt, out f1);  // true
            Console.WriteLine("{0:N20}", dm); //
            Console.WriteLine("{0:N20}", d1); //
            Console.WriteLine("{0:N20}", f1); // 
        }

        static public void test3()
        {
            var ns = NumberStyles.Float;
            var fmt = CultureInfo.InvariantCulture;

            string s1 = "2.12345678975E+9";
            decimal dm; double d1; float f1;
            decimal.TryParse(s1, ns, fmt, out dm); // true
            double.TryParse(s1, ns, fmt, out d1);  // true
            float.TryParse(s1, ns, fmt, out f1);  // true
            Console.WriteLine("{0:N4}", dm); // 2,123,456,789.7500
            Console.WriteLine("{0:N4}", d1); // 2,123,456,789.7500
            Console.WriteLine("{0:N4}", f1); // 2,123,457,000.0000
        }

        static public void test4()
        {
            var ns = NumberStyles.Float;
            var fmt = CultureInfo.InvariantCulture;

            string s1 = "2.12345678975 E-9";
            decimal dm; double d1; float f1;
            decimal.TryParse(s1, ns, fmt, out dm); // true
            double.TryParse(s1, ns, fmt, out d1);  // true
            float.TryParse(s1, ns, fmt, out f1);  // true
            Console.WriteLine("{0:N20}", dm); //
            Console.WriteLine("{0:N20}", d1); //
            Console.WriteLine("{0:N20}", f1); // 
        }
    }
}
