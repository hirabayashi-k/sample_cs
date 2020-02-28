using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Dynamic;
using System.CodeDom.Compiler;
using System.Reflection;

// 構文解析　条件 .NET4.6.1以降
// Nuget  PM>Install-Package Microsoft.CodeAnalysis.CSharp.Scripting -Version 2.6.1 
// 参考文献
// http://ufcpp.net/study/csharp/cheatsheet/apscripting/
// https://qiita.com/hukatama024e/items/741dd950096c3b4c688c
// http://wiki.clockahead.com/index.php?Coding/.NET/Roslyn/Scripting

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static async Task MainAsync()
        {
            var result = await CSharpScript.EvaluateAsync<int>(@"
var x = 1;
var y = 2;
x + y
");
            Console.WriteLine(result);
        }

        public void sample1()
        {
            // 非同期
            string code = "var x = 10; System.Console.WriteLine(x);"   /* C#スクリプトのコード */;
            var script = CSharpScript.Create(code);                     /* スクリプトの生成。Scriptクラスのインスタンスが生成される */
            script.RunAsync();                                          /* スクリプトの実行(非同期) */
        }

        public void sample2()
        {
            // 同期実行
            string code = "var x = 11; System.Console.WriteLine(x);"   /* C#スクリプトのコード */;
            var script = CSharpScript.Create(code);                     /* スクリプトの生成。Scriptクラスのインスタンスが生成される */
            var scriptState = script.RunAsync();                                          /* スクリプトの実行(非同期) */
            scriptState.Wait();
        }

        public async Task sample3()
        {
            try
            {
                Console.WriteLine(await CSharpScript.EvaluateAsync(Console.ReadLine()));
            }
            catch (CompilationErrorException e)
            {
                Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics));
            }
        }

        public async Task sample4()
        {
            string code = "var x = 10; var y = 10; var result = x + y;";
            var script = CSharpScript.Create(code);
            var state = await script.RunAsync();     /* ScriptStateクラスのインスタンスが生成される。実行中の状態を取得可能。（この場合(awaitしている場合)、実行後の状態） */


            var var = state.Variables;             /* Variablesプロパティに各変数の状態(Microsoft.CodeAnalysis.Scripting.ScriptVariableクラス)が入っている*/
            var name = state.Variables[0].Name;     /* 変数名 */
            var value = state.Variables[0].Value;    /* 値 */
            var type = state.Variables[0].Type;     /* 型情報（System.Typeクラス） */

            var result = state.GetVariable("result"); /* 変数名で取得可能 */

            //return (int)resutl;
        }

        int smp5;

        public async Task sample5()
        {
            string code = "var x = 10; var y = 11; var result = x + y;return result;";
            var script = CSharpScript.Create(code);
            var state = await script.RunAsync();     /* ScriptStateクラスのインスタンスが生成される。実行中の状態を取得可能。（この場合(awaitしている場合)、実行後の状態） */

            // int型
            smp5 = (int)state.ReturnValue;

        }

        public async Task sample6()
        {

            //var hostObject = new HostObject { Value = 123 };

            var script1 = CSharpScript.Create(
            @"Console.WriteLine(""Id={0}, Name={1}"", Target.Id, Target.Name);",
            ScriptOptions.Default.
            WithImports(
                "System",
                "System.Diagnostics").
            WithReferences(
                typeof(object).Assembly,
                typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly),
                typeof(HostObject));    // ホストオブジェクトの型を指定
                                        // ホストオブジェクト
            var hostObject = new HostObject();

            await script1.RunAsync(hostObject);

            //var func = new CallFunction { Value = 123 };

            //string code = "var x = 10; var result = CreateValues(x);return result;";
            //var script = CSharpScript.Create(code);

            //var state = await script.RunAsync(func);     /* ScriptStateクラスのインスタンスが生成される。実行中の状態を取得可能。（この場合(awaitしている場合)、実行後の状態） */

            //smp6 = (string)state.ReturnValue;

        }

        string smp7;
        public async Task sample7()
        {

            var func = new CallFunction { Value = 123 };

            string code = "var x = 10; var result = CreateValues(x);return result;";
            var script = CSharpScript.Create(code,
            ScriptOptions.Default.
            WithImports(
                "System",
                "System.Diagnostics").
            WithReferences(
                typeof(object).Assembly,
                typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly),
                typeof(CallFunction));    // ホストオブジェクトの型を指定

            var state = await script.RunAsync(func);     /* ScriptStateクラスのインスタンスが生成される。実行中の状態を取得可能。（この場合(awaitしている場合)、実行後の状態） */

            smp7 = (string)state.ReturnValue;

        }

        double sum = 0.0;
        public async Task sumSapmle()
        {

            var func = new CallFunction { Value = 123 };

            // FX 入力文字
            // dx1 + 0.0013 * ex1 + SUM(1,2,3)
            string inputFX = "dx1 + 0.0013 * ex1 + SUM(1,2,3) + sum(1,2,3)";

            inputFX = inputFX.ToUpper();    // 入力を大文字に統一

            inputFX= inputFX.Replace("SUM", "OpSum");// 関数名に変更

            string code = "var DX1 = 10.0; var EX1 = 20.0;  var result =" + inputFX +";return result;";


            var script = CSharpScript.Create(code,
            ScriptOptions.Default.
            WithImports(
                "System",
                "System.Diagnostics").
            WithReferences(
                typeof(object).Assembly,
                typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly),
                typeof(CallFunction));    // ホストオブジェクトの型を指定

            var state = await script.RunAsync(func);     /* ScriptStateクラスのインスタンスが生成される。実行中の状態を取得可能。（この場合(awaitしている場合)、実行後の状態） */

            sum = (double)state.ReturnValue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 初期が大分　遅い
            var result = CSharpScript.EvaluateAsync<int>(@"
var x = 1;
var y = 2;
x + y
");
            textBox1.Text = result.Result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainAsync().Wait();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            sample1();
            sample2();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();

            textBox1.Text = "";

            sample5().Wait();

            textBox1.Text = smp5.ToString();


            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox2.Text = sw.Elapsed.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();

            textBox1.Text = "";

            sample6().Wait();

            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox2.Text = sw.Elapsed.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();

            textBox1.Text = "";

            sample7().Wait();

            textBox1.Text = smp7;

            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox2.Text = sw.Elapsed.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();

            textBox1.Text = "";

            sumSapmle().Wait();

            textBox1.Text = sum.ToString();

            //ストップウォッチを止める
            sw.Stop();

            //結果を表示する
            textBox2.Text = sw.Elapsed.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //using System.Reflection;
            //using System.CodeDom.Compiler;
            //がソースファイルの一番上に書かれているものとする

            //計算式
            string exp = "(1+6)*5/(7-4)";

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

            //結果を表示
            textBox2.Text = result.ToString();

        }
    }

    public sealed class CallFunction
    {
        public int Value;

        public string CreateValues(int count)
        {
            var r = new Random();
            return string.Join(",", Enumerable.Range(0, count).Select(index => r.Next()));
        }

        //function OpSum(N: Integer; P: PDouble): Double;
        //var
        //  I: Integer;
        //begin
        //  Result := 0;
        //  for I := 0 to N - 1 do
        //  begin
        //    Result := Result + P^;
        //    Inc(P);
        //  end;
        //end;
        public double OpSum(params double[] p)
        {
            double Result = 0.0;
            try
            {

                foreach (double pp in p)
                {
                    Result += pp;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("SUM解析エラー");
            }
            return Result;
        }


    }

    // ホストオブジェクトクラス
    public sealed class HostObject
    {
        public HostObject()
        {
            this.Target = new ExpandoObject();
            this.Target.Id = 123;
            this.Target.Name = "ABC";
        }

        // ExpandoObjectを使ってダイナミックアクセスを指定するホスト環境のプロパティ
        public dynamic Target
        {
            get;
            private set;
        }
    }

}
