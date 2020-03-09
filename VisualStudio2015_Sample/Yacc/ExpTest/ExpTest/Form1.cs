using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

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
            foreach (var s in exprTextBox.Lines)
            {
                try
                {
                    var r = sc.Eval(s.ToUpper());
                    puts(r.ToString());
                }
                catch (Exception e)
                {
                    puts(e.Message);
                }
            }
        }

        private void vbscriptButton_Click(object sender, EventArgs e)
        {
            dynamic sc = Activator.CreateInstance(Type.GetTypeFromProgID("ScriptControl"));
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

        #region code
        string code = @"
var PI = 3.14159265358979323846264338327950288;

function SUM()
{
    var s = 0;
    for (var i = 0; i < arguments.length; i++)
    {
        s = s + arguments[i];
    }
    return s;
}

function AVERAGE()
{
    return SUM.apply(this, arguments) / arguments.length;
}

function STDEV()
{
    var ave = AVERAGE.apply(this, arguments);
    var s = 0;  
    for (var i = 0; i < arguments.length; i++)
    {
        s = s + Math.pow(arguments[i] - ave, 2);
    }
    return Math.sqrt(s / (arguments.length - 1));
}

function ABS(value)
{
    return Math.abs(value);
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

function ASIN(value)
{
    return Math.asin(value);
}

function ACOS(value)
{
    return Math.acos(value);
}

function ATAN(value)
{
    return Math.atan(value);
}

function ATAN2(y, x)
{
    return Math.atan2(y, x);
}

function EXP(value)
{
    return Math.exp(value);
}

function MAX()
{
    var v = arguments[0];
    for (var i = 1; i < arguments.length; i++)
    {
        v = Math.max(v, arguments[i]);
    }
    return v;
}

function MIN()
{
    var v = arguments[0];
    for (var i = 1; i < arguments.length; i++)
    {
        v = Math.min(v, arguments[i]);
    }
    return v;
}

function SQRT(value)
{
    return Math.sqrt(value);
}

function LOG(value)
{
    return Math.log(value);
}

function LOG10(value)
{
    return Math.LOG10E * Math.log(value);
}

function SINH(value)
{
    var p = Math.exp(value);
    var m = Math.exp(-value);
    return (p - m) / 2;
}

function COSH(value)
{
    var p = Math.exp(value);
    var m = Math.exp(-value);
    return (p + m) / 2;
}

function TANH(value)
{
    var p = Math.exp(value);
    var m = Math.exp(-value);
    return (p - m) / (p + m);
}
";
        #endregion

        private void jscriptButton_Click(object sender, EventArgs e)
        {
            dynamic sc = Activator.CreateInstance(Type.GetTypeFromProgID("ScriptControl"));
            sc.Language = "jscript";
            sc.AddCode(code);
            eval(sc);
            puts("");
            puts("【結論】");
            puts("・大文字小文字を区別する→事前変換すれば良い");
            puts("・SIN/COS の名前で使うには準備必要");
            puts("・可変引数対応可能");
            puts("→可変引数のあるユーザー定義式も対応可能");
        }

        private void javaScriptButton_Click(object sender, EventArgs e)
        {
            var jsc = new Olympus.Common.JavaScriptControl();
            jsc.AddCode(code);
            eval(jsc);

            var cpu = (Environment.Is64BitProcess) ? "64bit" : "32bit";
            puts("");
            puts("実行環境 : " + cpu);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
        }
    }
}
