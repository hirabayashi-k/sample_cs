using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpTest
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        void puts(string s)
        {
            logTextBox.AppendText(s + Environment.NewLine);
        }

        void eval(dynamic sc)
        {
            logTextBox.Clear();
            foreach(var s in exprTextBox.Lines)
            {
                try
                {
                    if(s.CompareTo("") !=0)
                    {
                        object r = sc.Eval(s);
                        puts(r.ToString());
                    }

                }
                catch (Exception e)
                {
                    puts(e.Message);
                }
            }
        }

        private void vbscriptButton_Click(object sender, EventArgs e)
        {
            var t = Type.GetTypeFromProgID("MSScriptControl.ScriptControl");
            dynamic sc = Activator.CreateInstance(t);
            sc.Language = "vbscript";
            sc.AddCode(@"
Const PI = 3.14159265358979323846264338327950288

Function SUM(a, b)
    SUM = a + b
End Function

Function SUM(a, b, c)
    SUM = a + b + c
End Function
");
            eval(sc);
            puts("");
            puts("【結論】");
            puts("・大文字小文字を区別しない");
            puts("・SIN/COS などそのまま使える");
            puts("・同名関数は上書きされる");
            puts("・可変引数対応不可");
            puts("→可変引数のあるユーザー定義式は対応不可能");
        }

        private void jscriptButton_Click(object sender, EventArgs e)
        {
            var t = Type.GetTypeFromProgID("MSScriptControl.ScriptControl");
            dynamic sc = Activator.CreateInstance(t);
            sc.Language = "jscript";
            sc.AddCode(@"
var PI = 3.14159265358979323846264338327950288;

function SUM()
{
    var s = 0;
    for (var i = 0; i < arguments.length; i++)
    {
        s = s + eval(arguments[i]);
    }
    return s;
}

function AVERAGE()
{
    var s = 0;
    var count = arguments.length;


    for (var i = 0; i < arguments.length; i++)
    {
        s = s + eval(arguments[i]);
    }

    s = s / count;

    return s;
}

function STDEV()
{
    var Result = 0;
    var S, S2;
    var I;

    var N = arguments.length;

    S = 0;
    S2 = 0;

    for (I = 0; I < N; I++)
    {
        S = S + eval(arguments[I]);
        S2 = S2 + Math.pow(eval(arguments[I]), 2);
    }

    Result = Math.sqrt(N * S2 - Math.pow(S, 2)) / (N * (N - 1));

    return Result;
}

function ABS()
{
    var Result = 0.0;
    Result = Math.abs( eval(arguments[0]) );
    return Result;
}

function SIN(rad)
{
    return Math.sin(rad);
}

function COS(rad)
{
    return Math.cos(rad);
}

function TAN(rad)
{
    return Math.tan(rad);
}

function ASIN(rad)
{
    return Math.asin(rad);
}

function ACOS(rad)
{
    return Math.acos(rad);
}

function ATAN(rad)
{
    return Math.atan(rad);
}

function ATAN2()
{
    return Math.atan2(arguments[0], arguments[1]);
}

function SINH(rad)
{
    return ( Math.exp(rad) -  Math.exp(-rad))/2;

    //return Math.sinh(rad);
}

function COSH(rad)
{
    return ( Math.exp(rad) +  Math.exp(-rad))/2;
    //return Math.cosh(rad);
}

function TANH(rad)
{
    return SINH(rad)/COSH(rad);
    return Math.tanh(rad);
}


function EXP(data)
{
    var Result = 0.0;

    Result = Math.exp(data);

    return Result;
}

function MAX()
{
    var Result = 0.0;
    var I;


    Result = arguments[0];

    for (I = 1; I < arguments.length; I++)
    {
        Result = Math.max(Result, arguments[0 + I]);
    }

    return Result;
}


function MIN()
{
    var Result = 0.0;
    var I;


    Result = arguments[0];

    for (I = 1; I < arguments.length; I++)
    {
        Result = Math.min(Result, arguments[0 + I]);
    }

    return Result;
}

function SQRT(data)
{
    return Math.sqrt(data);
}

function LOG10(data)
{
    // log(a)b＝log(c)a/log(c)b
    return Math.log(data)/Math.log(10)
    //return Math.log10(data);
}
function LOG(data)
{
    return Math.log(data);
}

");
            eval(sc);
            puts("");
            puts("【結論】");
            puts("・大文字小文字を区別する→事前変換すれば良い");
            puts("・SIN/COS の名前で使うには準備必要");
            puts("・可変引数対応可能");
            puts("→可変引数のあるユーザー定義式も対応可能");
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            exprTextBox.Text = "";
            setText("(1 + 6) * 5 / (7 - 4)");
            setText("sin(2)");
            setText("SIN(1)");
            setText("COS(1)");
            setText("TAN(1)");
            setText("SUM(1)");
            setText("SUM(1, 2, 3)");
            setText("SUM(SIN(PI / 2), 1)");
            setText("AVERAGE(1, 2, 3, 4)");
            setText("STDEV(1, 2, 3, 4)");
            setText("ABS(-11)");
            setText("ASIN(1)");
            setText("ACOS(0.1)");
            setText("ATAN(1)");
            setText("ATAN2(SUM(1, 2, 3),2)");
            setText("EXP(6)");
            setText("MAX(1,2,3,4,5)");
            setText("MIN(1,2,3,4,5)");
            setText("SQRT(10)");
            setText("LOG(10)");
            setText("0.00119038499487799+0.0013*-0.410458678658745");

            setText(Math.Log10(2).ToString());
            setText("LOG10(2)");
            setText(Math.Sinh(1).ToString());
            setText("SINH(1)");
            setText(Math.Cosh(1).ToString());
            setText("COSH(1)");
            setText(Math.Tanh(1).ToString());
            setText("TANH(1)");

        }

        void setText(String s)
        {
            exprTextBox.AppendText(s + "\r\n");
        }

    }
}
