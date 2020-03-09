using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlserializerTest
{
    [Serializable]
    public class XmlClass1
    {
        public XmlClass1()
        {
            data1 = "data1";
            data2 = "data2";
            data3 = "data3";
            data4 = "data4";

            for (int i = 0; i < hairetu2.Length; i++)
            {
                hairetu2[i] = new int[3];
                for (int j = 0; j < hairetu2[i].Length; j++)
                {
                    hairetu2[i][j] = j;
                }
            }

            childData = new XmlClassChild();
        }

        public string data1;
        public string data2;
        public string data3;
        public string data4;

        public int index = 1;
        public int[] hairetu = new int[]{ 1, 2, 3 };
        public int[][] hairetu2 = new int[2][];// { { 1, 2, 3 }, { 4, 5, 6 } };

        private XmlClassChild childData = new XmlClassChild();

    }
    [Serializable]
    public class XmlClassChild
    {
        public XmlClassChild()
        {
            first = "first";
            second = "second";
            third = "third";
        }

        public string first;
        public string second;
        public string third;
    }
}
