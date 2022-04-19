using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DLLdiscounts;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Calctulate calctulate = new Calctulate();
        [TestMethod]
        public void MakeDiscount_BigValues()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(15, 9999));
            Assert.AreEqual(34, result);
        }
        [TestMethod]
        public void MakeDiscount_BigValues3()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(8, 1200));
            Assert.AreEqual(12, result);
        }
        [TestMethod]
        public void MakeDiscount_BigValues2()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(9, 1659));
            Assert.AreEqual(13, result);
        }
        [TestMethod]
        public void MakeDiscount_BigValues1()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(15, 2010));
            Assert.AreEqual(19, result);
        }
        [TestMethod]
        public void MakeDiscount_CountBiggerThan9()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(10, 502));
            Assert.AreEqual(16, result);
        }
        [TestMethod]
        public void MakeDiscount_CountBiggerThan4()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(5, 300));
            Assert.AreEqual(10, result);
        }
        [TestMethod]
        public void MakeDiscount_CountBiggerThan2()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(3, 400));
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void MakeDiscount_ZeroValues()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(0, 0));
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void MakeDiscount_BigFloatValues()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(15, 9999.3f));
            Assert.AreEqual(34, result);
        }
        [TestMethod]
        public void MakeDiscount_SmallValues()
        {
            int result = Convert.ToInt32(100 * calctulate.MakeDiscount(2, 400));
            Assert.AreEqual(0, result);
        }
    }
}
