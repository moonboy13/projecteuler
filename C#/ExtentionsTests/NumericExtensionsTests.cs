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
        /// <summary>
        /// TODO: Add a data source that can be read in for this. Kinda
        /// waiting for NUnit to get extended as I prefer working with that.
        /// </summary>
        [TestMethod()]
        public void FindDivisorsTest()
        {
            HashSet<int> expectedDivisors = new HashSet<int>()
            {
                1, 2, 4, 7, 14
            };
            int number = 28;

            HashSet<int> actualDivisors = number.FindDivisors();

            Assert.AreEqual(expectedDivisors.Sum(), actualDivisors.Sum());
        }

        [TestMethod()]
        public void FindDivisors_SmallNumberTestA()
        {
            HashSet<int> expectedDivisors = new HashSet<int>()
            {
                1, 2
            };
            int number = 4;

            HashSet<int> actualDivisors = number.FindDivisors();

            Assert.AreEqual(expectedDivisors.Sum(), actualDivisors.Sum());
        }

        [TestMethod()]
        public void FindDivisors_SmallNumberTestB()
        {
            HashSet<int> expectedDivisors = new HashSet<int>()
            {
                1
            };
            int number = 2;

            HashSet<int> actualDivisors = number.FindDivisors();

            Assert.AreEqual(expectedDivisors.Sum(), actualDivisors.Sum());
        }
    }
}