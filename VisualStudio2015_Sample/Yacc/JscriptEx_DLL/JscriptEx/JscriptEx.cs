using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JscriptEx
{
    public class JscriptEx
    {


        // vbscript使用 計算メソッド
        public static double Analysis(string exp)
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
            return eval(sc, exp);

        }



        static double eval(dynamic sc, string data)
        {
            double result = 0.0;
            object r = sc.Eval(data);
            result = (double)r;
            return result;
        }

    }
}
