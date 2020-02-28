﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SyntaxHighlighter
{
    /// <summary>
    /// HTML → ufcpp.net で使ってる XML に変換。
    /// Productivity Power Tool が出力する HTML を読み込む。
    /// 改行文字は &lt;br/&gt; タグになってる前提。
    /// </summary>
    class HtmlParser : IParser
    {
        public static IDictionary<string, string> ColorToTagNameCsharp = new Dictionary<string, string>
        {
            { "blue", "reserved" },
            { "green", "comment" },
            { "#2b91af", "type" },
            { "#a31515", "string" },
            { "gray", "inactive" },
            { "maroon", "string" }
        };

        public static IDictionary<string, string> ColorToTagNameXml = new Dictionary<string, string>
        {
            { "blue", "attvalue" },
            { "red", "attribute" },
            { "gray", "inactive" },
            { "green", "comment" },
            { "#2b91af", "xsl" },
            { "#a31515", "element" },
        };

        private IDictionary<string, string> ColorToTagNameMap;

        public HtmlParser(Mode mode)
        {
            switch (mode)
            {
                case Mode.Csharp:
                    ColorToTagNameMap = ColorToTagNameCsharp;
                    break;
                case Mode.Xml:
                    ColorToTagNameMap = ColorToTagNameXml;
                    break;
                default:
                    break;
            }
        }

        static readonly Regex regPre = new Regex(@"\<pre(.|\s)*?\>(?<body>(.|\s)*)\</pre", RegexOptions.Compiled | RegexOptions.Multiline);
        static readonly Regex regSpan = new Regex(@"\<span style=""color:(?<color>(.|\s)*?);"">(?<body>(.|\s)*?)\</span\>", RegexOptions.Compiled | RegexOptions.Multiline);

        public string Parse(string text)
        {
            var mBody = regPre.Match(text);
            if (!mBody.Success)
            {
                return string.Empty;
            }

            string converted = mBody.Groups["body"].Value;

            converted = regSpan.Replace(converted, m =>
            {
                var c = m.Groups["color"].Value;
                var tag = ColorToTagNameMap[c];
                var body = m.Groups["body"].Value;

                return "<" + tag + ">" + body + "</" + tag + ">";
            });

            converted = converted
                .Replace(" <br/>", Environment.NewLine)
                .Replace("&nbsp;", " ")
                .Replace("\t", "    ")
                .Replace("<br/>", Environment.NewLine)
                ;

            return converted;
        }
    }
}
