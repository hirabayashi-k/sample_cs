using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HogePlugin;

namespace Fune
{
    public class Fune : IHogePlugin
    {
        public string Name
        {
            get { return "フネ"; }
        }

        public string GetComment()
        {
            return "あらあら。";
        }
    }
}
