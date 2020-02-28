using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // https://knowledge.rinpress.com/index.php/%E6%9C%80%E5%B0%8F%E4%BA%8C%E4%B9%97%E6%B3%95


        static void Main(string[] args)
        {

        }

        // 係数算出処理だよ
        public Double[] CoefficientCalc(List<InputElement> p_InputElementList, Int32 p_Dimension)
        {
            //求める係数の数は次数＋１だよね
            p_Dimension += 1;

            // ガウスの消去法で解く配列の作成をするよ
            Double[,] l_A = new Double[p_Dimension, p_Dimension + 1];
            for (Int32 i = 0; i < p_Dimension; i++)
            {
                for (Int32 j = 0; j < p_Dimension + 1; j++)
                {
                    l_A[i, j] = new Double();
                }
            }

            // 値の格納をするよ
            for (Int32 i = 0; i < p_Dimension; i++)
            {
                for (Int32 j = 0; j < p_Dimension; j++)
                {
                    for (Int32 k = 0; k < p_InputElementList.Count; k++)
                    {
                        l_A[i, j] += Math.Pow(p_InputElementList[k].XElement, i + j);
                    }
                }
            }
            for (Int32 i = 0; i < p_Dimension; i++)
            {
                for (Int32 k = 0; k < p_InputElementList.Count; k++)
                {
                    l_A[i, p_Dimension] += Math.Pow(p_InputElementList[k].XElement, i) * p_InputElementList[k].YElement;
                }
            }


            return this.Gauss(l_A, p_Dimension);
        }

        // ガウスの消去法処理だよ
        private Double[] Gauss(Double[,] p_A, Int32 p_Dimension)
        {
            //係数でソートするよ
            for (Int32 i = 0; i < p_Dimension; i++)
            {
                Double l_m = 0;
                Int32 l_pivot = i;

                //係数が一番大きい行を探すよ
                for (Int32 l = i; l < p_Dimension; l++)
                {
                    if (l_m < Math.Abs(p_A[l, i]))
                    {
                        l_m = Math.Abs(p_A[l, i]);
                        l_pivot = l;
                    }
                }

                //行の入れ替えするよ
                if (l_pivot != i)
                {
                    Double l_b = 0;
                    for (Int32 j = 0; j < p_Dimension + 1; j++)
                    {
                        l_b = p_A[i, j];
                        p_A[i, j] = p_A[l_pivot, j];
                        p_A[l_pivot, j] = l_b;
                    }
                }
            }

            // 前進消去処理だよ
            for (Int32 k = 0; k < p_Dimension; k++)
            {
                Double l_p = p_A[k, k];
                p_A[k, k] = 1;

                for (Int32 j = k + 1; j < p_Dimension + 1; j++)
                {
                    p_A[k, j] /= l_p;
                }

                for (Int32 i = k + 1; i < p_Dimension; i++)
                {
                    Double l_q = p_A[i, k];

                    for (Int32 j = k + 1; j < p_Dimension + 1; j++)
                    {
                        p_A[i, j] -= l_q * p_A[k, j];
                    }

                    p_A[i, k] = 0;
                }
            }

            // 後退代入処理だよ
            Double[] l_Result = new Double[p_Dimension];
            for (Int32 i = 0; i < p_Dimension; i++)
            {
                l_Result[i] = new Double();
            }

            for (Int32 i = p_Dimension - 1; 0 <= i; i--)
            {
                l_Result[i] = p_A[i, p_Dimension];
                for (Int32 j = p_Dimension - 1; i < j; j--)
                {
                    l_Result[i] -= p_A[i, j] * l_Result[j];
                }
            }

            return l_Result;
        }

        // データ投入用のクラスだよ
        public class InputElement
        {
            private Double m_XElement;
            private Double m_YElement;

            public InputElement()
            {
                this.m_XElement = 0;
                this.m_YElement = 0;
            }

            public InputElement(Double p_XElement, Double p_YElement)
            {
                this.m_XElement = p_XElement;
                this.m_YElement = p_YElement;
            }

            public Double XElement
            {
                get
                {
                    return this.m_XElement;
                }
                set
                {
                    this.m_XElement = value;
                }
            }

            public Double YElement
            {
                get
                {
                    return this.m_YElement;
                }
                set
                {
                    this.m_YElement = value;
                }
            }
        }
    }
}
