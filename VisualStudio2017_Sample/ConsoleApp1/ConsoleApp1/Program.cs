using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseKeyName =

            @"HARDWARE\DEVICEMAP\SERIALCOMM\";

            // すべてのサブ・キー名を取得する
            RegistryKey rParentKey =
              Registry.LocalMachine.OpenSubKey(baseKeyName);

            string[] arySubKeyNames = rParentKey.GetSubKeyNames();

            string[] valueNames = rParentKey.GetValueNames();
           

            foreach (string subKeyName in arySubKeyNames)
            {
                Console.WriteLine(subKeyName);
                // 出力例：
                // AcroRd32.exe
                // atltracetool.exe
                // ……以下略
            }

            foreach (string valueName in valueNames)
            {
                Console.WriteLine(valueName);

                Console.WriteLine(rParentKey.GetValue(valueName));
                // 出力例：
                // AcroRd32.exe
                // atltracetool.exe
                // ……以下略


            }
            

            rParentKey.Close();

            Console.ReadKey();
        }
    }
}
