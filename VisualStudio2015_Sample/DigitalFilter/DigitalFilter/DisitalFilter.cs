using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFilter
{
    /// <summary>
    /// デジタルフィルター
    /// http://vstcpp.wpblog.jp/?page_id=523
    /// </summary>
    public class DisitalFilter
    {

    	// フィルタの係数
	    private float a0, a1, a2, b0, b1, b2;
        // バッファ
        private float out1, out2;
        private float in1, in2;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisitalFilter()
        {
            // メンバー変数を初期化
            a0 = 1.0f; // 0以外にしておかないと除算でエラーになる
            a1 = 0.0f;
            a2 = 0.0f;
            b0 = 1.0f;
            b1 = 0.0f;
            b2 = 0.0f;

            in1 = 0.0f;
            in2 = 0.0f;

            out1 = 0.0f;
            out2 = 0.0f;
        }

        /// <summary>
        /// 入力信号にフィルタを適用する関数
        /// </summary>
        /// <param name="sin"></param>
        /// <returns></returns>
        public float Process(float sin)
        {
            // 入力信号にフィルタを適用し、出力信号変数に保存。
            float sout = b0 / a0 * sin +b1 / a0 * in1 + b2 / a0 * in2
                - a1 / a0 * out1 - a2 / a0 * out2;

            in2 = in1; // 2つ前の入力信号を更新
            in1 = sin;  // 1つ前の入力信号を更新

            out2 = out1; // 2つ前の出力信号を更新
            out1 = sout;  // 1つ前の出力信号を更新

            // 出力信号を返す
            return sout;
        }

        /// <summary>
        /// フィルタ係数を計算するメンバー関数
        /// </summary>
        /// <param name="freq"></param>
        /// <param name="q"></param>
        /// <param name="samplerate"></param>
        public void LowPass(float freq, float q, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);

            // フィルタ係数を求める。
            a0 = 1.0f + alpha;
            a1 = -2.0f *  (float)Math.Cos(omega);
            a2 = 1.0f - alpha;
            b0 = (1.0f - (float)Math.Cos(omega)) / 2.0f;
            b1 = 1.0f - (float)Math.Cos(omega);
            b2 = (1.0f - (float)Math.Cos(omega)) / 2.0f;
        }



        public void HighPass(float freq, float q, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);

            // フィルタ係数を求める。
            a0 = 1.0f + alpha;
            a1 = -2.0f * (float)Math.Cos(omega);
            a2 = 1.0f - alpha;
            b0 = (1.0f + (float)Math.Cos(omega)) / 2.0f;
            b1 = -(1.0f + (float)Math.Cos(omega));
            b2 = (1.0f + (float)Math.Cos(omega)) / 2.0f;
        }

        public void BandPass(float freq, float bw, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh(Math.Log(2.0f) / 2.0 * bw * omega / (float)Math.Sin(omega));

            // フィルタ係数を求める。
            a0 = 1.0f + alpha;
            a1 = -2.0f * (float)Math.Cos(omega);
            a2 = 1.0f - alpha;
            b0 = alpha;
            b1 = 0.0f;
            b2 = -alpha;
        }

        public void Notch(float freq, float bw, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh((float)Math.Log(2.0f) / 2.0 * bw * omega / (float)Math.Sin(omega));

            // フィルタ係数を求める。
            a0 = 1.0f + alpha;
            a1 = -2.0f * (float)Math.Cos(omega);
            a2 = 1.0f - alpha;
            b0 = 1.0f;
            b1 = -2.0f * (float)Math.Cos(omega);
            b2 = 1.0f;
        }

        public void LowShelf(float freq, float q, float gain, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));
            float beta = (float)Math.Sqrt(A) / q;

            // フィルタ係数を求める。
            a0 = (A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega);
            a1 = -2.0f * ((A - 1.0f) + (A + 1.0f) * (float)Math.Cos(omega));
            a2 = (A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega);
            b0 = A * ((A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega));
            b1 = 2.0f * A * ((A - 1.0f) - (A + 1.0f) * (float)Math.Cos(omega));
            b2 = A * ((A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega));
        }

        public void HighShelf(float freq, float q, float gain, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));
            float beta = (float)Math.Sqrt(A) / q;

            // フィルタ係数を求める。
            a0 = (A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega);
            a1 = 2.0f * ((A - 1.0f) - (A + 1.0f) * (float)Math.Cos(omega));
            a2 = (A + 1.0f) - (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega);
            b0 = A * ((A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) + beta * (float)Math.Sin(omega));
            b1 = -2.0f * A * ((A - 1.0f) + (A + 1.0f) * (float)Math.Cos(omega));
            b2 = A * ((A + 1.0f) + (A - 1.0f) * (float)Math.Cos(omega) - beta * (float)Math.Sin(omega));
        }


        public void Peaking(float freq, float bw, float gain, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) * (float)Math.Sinh((float)Math.Log(2.0f) / 2.0 * bw * omega / (float)Math.Sin(omega));
            float A = (float)Math.Pow(10.0f, (gain / 40.0f));

            // フィルタ係数を求める。
            a0 = 1.0f + alpha / A;
            a1 = -2.0f * (float)Math.Cos(omega);
            a2 = 1.0f - alpha / A;
            b0 = 1.0f + alpha * A;
            b1 = -2.0f * (float)Math.Cos(omega);
            b2 = 1.0f - alpha * A;
        }

        public void AllPass(float freq, float q, float samplerate)
        {
            // フィルタ係数計算で使用する中間値を求める。
            float omega = 2.0f * 3.14159265f * freq / samplerate;
            float alpha = (float)Math.Sin(omega) / (2.0f * q);

            // フィルタ係数を求める。
            a0 = 1.0f + alpha;
            a1 = -2.0f * (float)Math.Cos(omega);
            a2 = 1.0f - alpha;
            b0 = 1.0f - alpha;
            b1 = -2.0f * (float)Math.Cos(omega);
            b2 = 1.0f + alpha;
        }


    }
}
