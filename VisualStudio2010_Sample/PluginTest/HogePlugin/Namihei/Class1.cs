using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HogePlugin;

namespace Namihei
{
    public class Namihei : IHogePlugin
    {
        public string Name
        {
            get { return "波平"; }
        }

        public string GetComment()
        {
            return "バッカモーーン！";
        }
    }
}
