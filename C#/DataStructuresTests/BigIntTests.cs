using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DataStructures.Tests
{
    [TestClass()]
    public class BigIntTests
    {
        [TestMethod()]
        public void FromIntTest()
        {
            var test = BigInt.FromInt(54321);
            int[] digits = new int[] { 1, 2, 3, 4, 5 };

            for(int i = 0; i < 5; i++)
            {
                Assert.AreEqual(digits[i], test[i]);
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            int max = (int.MaxValue / 2) - 1;
            int A = Random.Shared.Next(max);
            int B = Random.Shared.Next(max);
            var bigA = BigInt.FromInt(A);
            var bigB = BigInt.FromInt(B);

            Assert.AreEqual(BigInt.FromInt(A + B), (bigA + bigB));
        }

        [TestMethod()]
        public void ToStringTest_ENCulture()
        {
            int number = Random.Shared.Next();
            var test = BigInt.FromInt(number); 

            Assert.AreEqual(string.Format("{0:n0}", number), test.ToString());
        }

        [TestMethod()]
        public void ToStringTest_DECulture()
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;

            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");

                int number = Random.Shared.Next();
                var test = BigInt.FromInt(number);

                Assert.AreEqual(string.Format("{0:n0}", number), test.ToString());
            }
            finally
            {
                // make sure we reset that culture
                Thread.CurrentThread.CurrentCulture = cultureInfo;
            }
        }

        [TestMethod()]
        public void EqualsTest_ValsAreEqual()
        {
            var A = BigInt.FromInt(55);
            var B = BigInt.FromInt(55);

            Assert.IsTrue(A.Equals(B));
            Assert.IsTrue(A == B);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            int max = 1000;
            int A = Random.Shared.Next(max);
            int B = Random.Shared.Next(max);
            var bigA = BigInt.FromInt(A);
            var bigB = BigInt.FromInt(B);

            Assert.AreEqual(BigInt.FromInt(A * B), (bigA * bigB));
        }
    }
}