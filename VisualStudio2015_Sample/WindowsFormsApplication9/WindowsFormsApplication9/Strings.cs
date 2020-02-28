using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication9
{
    public static class Strings
    {
        static readonly char quote = '"';
        static readonly string quote2 = "\"\"";
        static readonly char delimiter = ',';
        static readonly char space = ' ';

        public static unsafe char* inc(ref char* p)
        {
            p++;
            if (Char.IsSurrogate(*p))
                p++;
            return p;
        }

        // "...""...""..."
        public static unsafe string ExtractQuotedStr(ref char* p, char* endp)
        {
            string s = "";

            Debug.Assert(*p == quote);
            p++;
            while (p < endp)
            {
                if (*p == quote)
                {
                    // quote分
                    p++;
                    if (*p != quote)
                        break;
                }
                s += *p++;
                if (Char.IsSurrogate(*p))
                {
                    s += *p++;
                }
            }
            return s;
        }

        // abc"def -> "abc""def"
        static string QuotedStr(string s)
        {
            return quote + s.Replace(quote.ToString(), quote2) + quote;
        }

        // CommaText -> String List
        public static unsafe string[] ToStrings(string commaText)
        {
            if (commaText == "")
                return new string[] { "" };

            var result = new StringCollection();
            string s;

            var c = commaText.ToArray();
            fixed (char* startp = &c[0])
            {
                char* p = startp;
                char* endp = p + c.Length;
                while (p < endp)
                {
                    if (*p == quote)
                    {
                        s = ExtractQuotedStr(ref p, endp);
                    }
                    else
                    {
                        var p1 = p;
                        while (p != endp && *p > space && *p != delimiter)
                            inc(ref p);
                        s = commaText.Substring((int)(p1 - startp), (int)(p - p1));
                    }
                    result.Add(s);
                    while (p != endp && *p <= space)
                        inc(ref p);
                    if (p != endp && *p == delimiter)
                    {
                        if (p + 1 == endp)
                            result.Add("");
                        do
                        {
                            inc(ref p);
                        } while (p != endp && *p <= space);
                    }
                }
            }
            return result.Cast<string>().ToArray();
        }

        // String List -> CommaText
        public static unsafe string ToCommaText(string[] lines)
        {
            string result = "";

            // 1行の処理
            Func<string, string> f = (s) =>
            {
                var r = "";
                if (s == "")
                    return r;

                var c = s.ToArray();
                fixed (char* startp = &c[0])
                {
                    char* p = startp;
                    char* endp = p + c.Length;

                    while (p != endp && *p != space && *p != delimiter && *p != quote)
                        inc(ref p);
                    if (p != endp)
                        s = QuotedStr(s);
                    r += s;
                }
                return r;
            };

            for (int i = 0; i < lines.Length - 1; i++)
            {
                result += f(lines[i]) + delimiter;
            }
            return result += f(lines.Last());
        }
    }
}
