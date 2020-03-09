using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    unsafe class Class1
    {
        public char[] dd;
        public char* point;

        public Class1()
        {

        }

        public void Init()
        {
            dd = new char[10];
            for (int i = 0; i < 9; i++)
            {
                dd[i] = (char)(0x61 + i);
            }

            fixed (char* ptr = &dd[0])
            {
                point = ptr;
            }
        }


        public void ss(char data)
        {
            *point = data;
            point++;
        }

        public string copy()
        {
            return Marshal.PtrToStringAuto((IntPtr)point); 
        }

        public bool resize(out string sptr)
        {

            bool result = false;
            Array.Resize(ref dd, dd.Count() * 2);

            // 配列のポインタ確認
            fixed(char* ptrR = &dd[0])
            {
                if (point == ptrR) result = true;

                *ptrR = 'X';
            }

            sptr = Marshal.PtrToStringAuto((IntPtr)point);



            return result;
        }


        public bool resizeMovePointer()
        {
            bool result = false;

            // わかりやすいようにポインタ一つ進める
            point += 2;

            int nowPos = 0;

            // 配列のポインタ確認
            fixed (char* ptr = &dd[0])
            {
                // ポインタの進み位置を取得
                nowPos = (int)point - (int)ptr;
            }
            
            // リサイズすることでポインタが変更される
            Array.Resize(ref dd, dd.Count() * 2);

            // 配列のポインタ確認
            fixed (char* ptrR = &dd[0])
            {
                point =(char*)((int)ptrR + nowPos);

                *point = 'X';
            }
            if (dd[2] == *point)
            {
                result = true;
            }
            

            return result;
        }


    }
}
