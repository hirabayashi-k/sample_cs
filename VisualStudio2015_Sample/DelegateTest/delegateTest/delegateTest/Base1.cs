using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateTest
{
    class Base1
    {

        Base2 obj;

        public Base1(myDelegate myfun , string msg)
        {

            obj = new delegateTest.Base2(myfun,msg);
            
        }

        public void doProc()
        {
            obj.doProc();
        }

    }
}
