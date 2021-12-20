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
            HashSet<int> expectedDivisors = new HashSet<int>()
            {
                1, 2, 4, 7, 14
            };
            int number = 28;

            HashSet<int> actualDivisors = number.FindDivisors();

            //CollectionAssert.AreEquivalent(expectedDivisors, actualDivisors);
        }
    }
}