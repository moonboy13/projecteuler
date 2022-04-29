using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extentions.Tests
{
    [TestClass()]
    public class IEnumerableExtensionsTests
    {
        [TestMethod()]
        public void SwapTest()
        {
            var expected = new List<int> { 1, 3, 2 };
            var start = new List<int> { 1, 2, 3 };
            start.Swap(1, 2);

            CollectionAssert.AreEqual(expected, start);
        }

        [TestMethod()]
        public void ToIntTest()
        {
            Assert.AreEqual(25, new List<int> { 2, 5 }.ToInt());
        }

        [TestMethod()]
        public void ToIntTest_Leading0()
        {
            Assert.AreEqual(2958, new List<int> { 0, 2, 9, 5, 8 }.ToInt());
        }
    }
}