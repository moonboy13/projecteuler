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
    public class NumericExtensionsTests
    {
        [TestMethod()]
        public void FindDivisorsTest()
        {
            List<int> expectedDivisors = new List<int>()
            {
                1, 2, 4, 7, 14
            };
            int number = 28;

            List<int> actualDivisors = number.FindDivisors();

            CollectionAssert.AreEquivalent(expectedDivisors, actualDivisors);
        }
    }
}