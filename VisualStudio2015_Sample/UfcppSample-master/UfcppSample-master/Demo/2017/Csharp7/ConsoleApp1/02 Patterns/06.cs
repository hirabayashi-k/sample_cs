using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1._02_Patterns
{
    class _06
    {
        public static void Run()
        {
            var d = new Dictionary<int, object>
            {
                [1] = 1,
                [3] = new[] { 1, 2, 3 },
                [5] = null,
            };

            {
                var (key, value) = d.First();
                Console.WriteLine(key);
            }

            var sum = 0;
            foreach (var (key, value) in d)
            {
                if (value is int n) sum += n;
                if (value is int[] a) sum += a.Sum();
            }

            if (d.TryGetValue(1, out var v))
            {
                Console.WriteLine(v);
            }

            // while の条件式の中とかでも
            // is の後ろでも var 利用可能
            while (Console.ReadLine() is var line && !string.IsNullOrEmpty(line))
            {
                Console.WriteLine(line);
            }
            // line のスコープは漏れない(元のコードだと漏れてる)
        }
    }
}
