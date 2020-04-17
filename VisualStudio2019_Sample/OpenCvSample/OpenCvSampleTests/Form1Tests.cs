using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvSample.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void SampleTest()
        {

            Form1 from = new Form1();

            int act = from.Sample(1);
            int exp = 1;
            Assert.AreEqual(exp, act);
        }

        [TestMethod()]
        public void SampleTest2Test()
        {
            Form1 from = new Form1();

            int act = from.SampleTest2();
            int exp = 1;
            Assert.AreEqual(exp, act);
        }
    }
}