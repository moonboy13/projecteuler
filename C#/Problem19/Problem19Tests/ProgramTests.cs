using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem19.Tests
{
	[TestClass()]
	public class ProgramTests
	{
		[TestMethod()]
		public void IsLeapYearTest()
		{
			Program p19 = new Program();
			Assert.IsFalse(p19.IsLeapYear(1900));
			Assert.IsFalse(p19.IsLeapYear(1901));
			Assert.IsTrue(p19.IsLeapYear(1904));
			Assert.IsTrue(p19.IsLeapYear(2000));
		}
	}
}