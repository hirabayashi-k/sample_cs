using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public static class ExpressionAnalysis
    {

        const string E_UNDEFINED_IDENT = "Undefined Ident:"; // 未定義の変数
        const string E_INVALID_FUNCTION = "Invalid function:"; // 無効な関数呼び出し
        const string E_INVALID_PARAM = "Invalid parameter:"; // 関数パラメータが違う
        const string E_ZERO_DIVIDE = "Zero Divide:";     // ゼロによる除算
        const string E_VALUE_NOT_ENOUGH = "Value not enouth:"; // 値が不足
        const string E_CIRCULATION = "Circulation:";     // 循環参照


        public enum FncName
        {
            SUM, 
            AVERAGE, 
            STDEV, 
            ABS,

            ASIN,  // 検索の順番　同じ文字があるものより上げる
            ACOS,
            ATAN2,
            ATAN,
            SINH,
            COSH,
            TANH,
            SIN,
            COS, 
            TAN, 
            EXP, 
            MAX, 
            MIN, 
            SQRT,
            LOG10,
            LOG, 
        }

        public static double ExAnalysis(string exp, Dictionary<string, object> DCA)
        {
            exp = Microsoft.VisualBasic.Strings.StrConv(
                            exp, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411); //全角を半角に変換する
            exp = exp.ToUpper();    // 入力を大文字に統一
            exp = exp.Replace(" ","");    // 空白削除
            //exp = exp.Replace("　",""); // 全角空白削除

            string exExp = exp;

            // 数値変換
            exExp = AnalysisVar(exp, DCA);

            //関数検索
            foreach (FncName func in Enum.GetValues(typeof(FncName)))
            {
                exExp = searchFunc(exExp, func);
            }

            return  Analysis(exExp);

        }

        public static string AnalysisVar(string exp, Dictionary<string, object> DCA)
        {
            string Result = exp;

            if (DCA == null)
            {
                DCA = new Dictionary<string, object>();
            }

            DCA.Add("PI", "3.14159265358979323846");

            foreach (KeyValuePair<string, object> pair in DCA)
            {
                Result = Result.Replace((string)pair.Key, (string)pair.Value);
            }

            return Result;
        }

        public static void  testc()
        {
            // 正規表現

            string target = "せいきひょうげんで((かっこのなか)a)をとり(ます)。";
            Regex regex = new Regex(@"\((?<value>.*?)\)");
            Match match = regex.Match(target);
            // value = かっこのなか
            string value = match.Groups["Value"].Value;

            string target2 = "せいきひょうげんで（大文字カッコの中）をとります。";
            Regex regex2 = new Regex(@"（(?<value>.*?)）");
            Match match2 = regex2.Match(target2);
            // value2 = 大文字カッコの中
            string value2 = match2.Groups["Value"].Value;

        }

        // 再帰的に括弧を探す
        static int serchParentheses(string exp, int serchPos,bool right, int deep)
        {
            int index = serchPos;
            bool left = false;

            // 深度0
            if (deep == 0)
            {
                char data = exp[index];
                if (data != '(')
                {
                    throw new Exception("ExAnalysis:Search:(");
                }
            }
            for (; index < exp.Length; index++)
            {
                char data = exp[index];

                if (data == '(')
                {
                    right = true;

                    deep++;
                    index = serchParentheses(exp, index + 1, right, deep);
                    deep--;
                    if (deep == 0)
                    {
                        left = true;
                        break;
                    }
                } else if(data == ')')
                {
                    left = true;
                    break;
                }
            }

            if(right == false) throw new Exception("ExAnalysis:Search:(");
  
            if(left == false) throw new Exception("ExAnalysis:Search:)");

            return index;
        }

        public static string searchFunc(string exp, FncName serarchEnm)
        {


            var searchWord = Enum.GetName(typeof(FncName), serarchEnm);

            String Result = exp;


            //始めの位置を探す
            int foundIndex = exp.IndexOf(searchWord);
            while (0 <= foundIndex)
            {

                int foundLeftPareIndex = serchParentheses(exp, foundIndex + searchWord.Length,false,0);

                // 関数の取り出し
                string funcData = exp.Substring(foundIndex, foundLeftPareIndex - foundIndex + 1);
                // 関数の解析と結果の取得
                string analisysData = AnalysisFunc(funcData, serarchEnm);
                // 結果の反映
                Result = Result.Replace(funcData, analisysData);


                //次の検索開始位置
                int nextIndex = foundLeftPareIndex + 1;
                if (nextIndex < exp.Length)
                {
                    //次の位置を探す
                    foundIndex = exp.IndexOf(searchWord, nextIndex);
                }
                else
                {
                    //最後まで検索したときは終わる
                    break;
                }
            }
            return Result;
        }

        public static string AnalysisFunc(string funData, FncName serarchEnm)
        {
            string Result = "";
            double dResult = 0.0;

            var searchWord = Enum.GetName(typeof(FncName), serarchEnm);

            string Data = funData.Substring(searchWord.Length + 1 , funData.Length - searchWord.Length -2);

            // TODO カンマテキスト
            string[] Datas = Data.Split(',');

            double[] dDatas = new double[Datas.Count()];

            try
            {
                for (int i = 0; i < dDatas.Count(); i++)
                {
                    dDatas[i] = Analysis(Datas[i]);
                }

            } catch(Exception ex)
            {
                throw new Exception("ExAnalysis:" + ex.Message);
            }

            switch (serarchEnm)
            {
                case FncName.SUM:
                    dResult = OpSum(dDatas);
                    break;
                case FncName.AVERAGE:
                    dResult = OpAverage(dDatas);
                    break;
                case FncName.STDEV:
                    dResult = OpStdev(dDatas);
                    break;
                case FncName.ABS:
                    dResult = OpAbs(dDatas);
                    break;
                case FncName.SIN:
                    dResult = OpSin(dDatas);
                    break;
                case FncName.COS:
                    dResult = OpCos(dDatas);
                    break;
                case FncName.TAN:
                    dResult = OpTan(dDatas);
                    break;
                case FncName.ASIN:
                    dResult = OpASin(dDatas);
                    break;
                case FncName.ACOS:
                    dResult = OpACos(dDatas);
                    break;
                case FncName.ATAN:
                    dResult = OpATan(dDatas);
                    break;
                case FncName.ATAN2:
                    dResult = OpATan2(dDatas);
                    break;
                case FncName.EXP:
                    dResult = OpExp(dDatas);
                    break;
                case FncName.MAX:
                    dResult = OpMax(dDatas);
                    break;
                case FncName.MIN:
                    dResult = OpMin(dDatas);
                    break;
                case FncName.SQRT:
                    dResult = OpSqrt(dDatas);
                    break;
                case FncName.LOG:
                    dResult = OpLog(dDatas);
                    break;
                case FncName.LOG10:
                    dResult = OpLog10(dDatas);
                    break;
                case FncName.SINH:
                    dResult = OpSinh(dDatas);
                    break;
                case FncName.COSH:
                    dResult = OpCosh(dDatas);
                    break;
                case FncName.TANH:
                    dResult = OpTanh(dDatas);
                    break;
            }

            return dResult.ToString();
        }


        // vbscript使用 計算メソッド
        public static double Analysis(string exp)
        {

            //using System.Reflection;
            //using System.CodeDom.Compiler;
            //がソースファイルの一番上に書かれているものとする

            //計算式
            //string exp = "(1+6)*5/(7-4)";

            //計算するためのコード
            string source =
@"package Evaluator
{
    class Evaluator
    {
        public function Eval(expr : String) : String 
        { 
            return eval(expr); 
        }
    }
}";
            try
            {
                //コンパイルするための準備
                CodeDomProvider cp = new Microsoft.JScript.JScriptCodeProvider();
                ICodeCompiler icc = cp.CreateCompiler();
                CompilerParameters cps = new CompilerParameters();
                CompilerResults cres;
                //メモリ内で出力を生成する
                cps.GenerateInMemory = true;
                //コンパイルする
                cres = icc.CompileAssemblyFromSource(cps, source);

                //コンパイルしたアセンブリを取得
                Assembly asm = cres.CompiledAssembly;
                //クラスのTypeを取得
                Type t = asm.GetType("Evaluator.Evaluator");
                //インスタンスの作成
                object eval = Activator.CreateInstance(t);
                //Evalメソッドを実行し、結果を取得
                string result = (string)t.InvokeMember("Eval",
                    BindingFlags.InvokeMethod,
                    null,
                    eval,
                    new object[] { exp });

                return double.Parse(result);

            }
            catch (Exception ex)
            {
                throw new Exception("ExpressionAnalysis Error:" + ex.Message);
            }

        }

        //----------------
        //----------------
        //function OpSum(N: Integer; P: PDouble): Double;
        //var
        //  I: Integer;
        //begin
        //  Result := 0;
        //  for I := 0 to N - 1 do
        //  begin
        //    Result := Result + P^;
        //    Inc(P);
        //end;
        //end;
        static double OpSum(double[] P)
        {
            double Result = 0.0;
            int I;

            for (I = 0; I < P.Count(); I++)
            {
                Result += P[I];
            }
            return (Result);
        }

        //----------------
        //----------------
        //function OpAverage(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N > 0, E_VALUE_NOT_ENOUGH);
        //Result := OpSum(N, P) / N;
        //end;

        static double OpAverage(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N > 0, E_VALUE_NOT_ENOUGH);

            Result = OpSum(P) / N;

            return (Result);
        }


        //----------------
        //----------------
        //function OpStdev(N: Integer; P: PDouble): Double;
        //var
        //  S, S2: Double;
        //  I: Integer;
        //begin
        //  YYAssert(N > 1, E_VALUE_NOT_ENOUGH);
        //S := 0;
        //  S2 := 0;
        //  for I := 0 to N - 1 do
        //  begin
        //    S := S + P^;
        //    S2 := S2 + Sqr(P^);
        //    Inc(P);
        //end;
        //  Result := Sqrt(N* S2 - Sqr(S)) / (N* (N - 1));
        //end;

        static double OpStdev(double[] P)
        {
            // TODO 標準偏差　Delphiがあっている？

            double Result = 0.0;
            double S, S2;
            int I;

            int N = P.Count();

            YYAssert(N > 1, E_VALUE_NOT_ENOUGH);

            S = 0;
            S2 = 0;

            for (I = 0; I < N; I++)
            {
                S = S + P[I];
                S2 = S2 + Math.Pow(P[I], 2);
            }

            Result = Math.Sqrt(N * S2 - Math.Pow(S, 2)) / (N * (N - 1));

            return (Result);
        }


        //----------------
        //----------------
        //function OpAbs(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Abs(P^);
        //end;

        static double OpAbs(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Abs(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpSin(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Sin(P^);
        //end;

        static double OpSin(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Sin(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpCos(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Cos(P^);
        //end;

        static double OpCos(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Cos(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpTan(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Tan(P^);
        //end;

        static double OpTan(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Tan(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpASin(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //  YYAssert((-1 <= P^) and(P^ <= 1), E_INVALID_PARAM);
        //  Result := ArcSin(P^);
        //end;

        static double OpASin(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            YYAssert((-1 <= P[0]) && (P[0] <= 1), E_INVALID_PARAM);
            Result = Math.Asin(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpACos(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //  YYAssert((-1 <= P^) and(P^ <= 1), E_INVALID_PARAM);
        //  Result := ArcCos(P^);
        //end;

        static double OpACos(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            YYAssert((-1 <= P[0]) && (P[0] <= 1), E_INVALID_PARAM);
            Result = Math.Acos(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpATan(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := ArcTan(P^);
        //end;

        static double OpATan(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Atan(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpATan2(N: Integer; P: PDouble): Double;
        //var
        //  X, Y: Double;
        //begin
        //  YYAssert(N = 2, E_INVALID_PARAM);
        //Y := P^;
        //  Inc(P);
        //X := P^;
        //  Result := ArcTan2(Y, X);
        //end;

        static double OpATan2(double[] P)
        {
            double Result = 0.0;
            double X, Y;
            int N = P.Count();

            YYAssert(N == 2, E_INVALID_PARAM);
            Y = P[0];
            X = P[0 + 1];
            Result = Math.Atan2(Y, X);

            return (Result);
        }


        //----------------
        //----------------
        //function OpExp(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Exp(P^);
        //end;

        static double OpExp(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Exp(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpMax(N: Integer; P: PDouble): Double;
        //var
        //  I: Integer;
        //begin
        //  YYAssert(N > 0, E_VALUE_NOT_ENOUGH);
        //Result := P^;
        //  Inc(P);
        //  for I := 1 to N - 1 do
        //  begin
        //    Result := Max(Result, P^);
        //    Inc(P);
        //end;
        //end;

        static double OpMax(double[] P)
        {
            double Result = 0.0;
            int I;
            int N = P.Count();

            YYAssert(N > 0, E_VALUE_NOT_ENOUGH);

            Result = P[0];

            for (I = 1; I < N; I++)
            {
                Result = Math.Max(Result, P[0 + I]);
            }

            return (Result);
        }


        //----------------
        //----------------
        //function OpMin(N: Integer; P: PDouble): Double;
        //var
        //  I: Integer;
        //begin
        //  YYAssert(N > 0, E_VALUE_NOT_ENOUGH);
        //  Result := P^;
        //  Inc(P);
        //  for I := 1 to N - 1 do
        //  begin
        //    Result := Min(Result, P^);
        //    Inc(P);
        //end;
        //end;

        static double OpMin(double[] P)
        {
            double Result = 0.0;

            int I;

            int N = P.Count();

            YYAssert(N > 0, E_VALUE_NOT_ENOUGH);

            Result = P[0];

            for (I = 1; I < N; I++)
            {
                Result = Math.Min(Result, P[0 + I]);
            }

            return (Result);
        }


        //----------------
        //----------------
        //function OpSqrt(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //  YYAssert(P^ >= 0, E_INVALID_PARAM);
        //Result := Sqrt(P^);
        //end;

        static double OpSqrt(double[] P)
        {
            double Result = 0.0;

            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            YYAssert(P[0] >= 0, E_INVALID_PARAM);
            Result = Math.Sqrt(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpLog(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Ln(P^);
        //end;

        static double OpLog(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Log(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpLog10(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Log10(P^);
        //end;

        static double OpLog10(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Log10(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpSinh(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Sinh(P^);
        //end;

        static double OpSinh(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Sinh(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpCosh(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Cosh(P^);
        //end;

        static double OpCosh(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Cosh(P[0]);

            return (Result);
        }


        //----------------
        //----------------
        //function OpTanh(N: Integer; P: PDouble): Double;
        //begin
        //  YYAssert(N = 1, E_INVALID_PARAM);
        //Result := Tanh(P^);
        //end;
        static double OpTanh(double[] P)
        {
            double Result = 0.0;
            int N = P.Count();

            YYAssert(N == 1, E_INVALID_PARAM);
            Result = Math.Tanh(P[0]);

            return (Result);
        }

        //procedure YYAssert(Cond: Boolean; Msg: string);
        //begin
        //  if (Cond) then
        //    Exit;
        //raise Exception.Create(Msg);
        //end;

        static void YYAssert(bool Cond, string Msg)
        {
            if (Cond)
            {
                return;
            }

            throw new AccessViolationException(Msg);
        }

    }
}
