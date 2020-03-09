using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateTest
{
    class Base2
    {
        myDelegate myfun;
        string msg = "";

        public Base2(myDelegate _myfun,string _msg)
        {
            myfun = _myfun;
            msg = _msg;
        }

        public void doProc()
        {
            myfun(msg);
        }

    }
}
