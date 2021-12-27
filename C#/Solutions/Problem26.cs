using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace Solutions
{
    /// <summary>
    /// A unit fraction contains 1 in the numerator.The decimal representation of the unit fractions with denominators 2 to 10 are given:
    /// 1/2	= 	0.5
    /// 1/3	= 	0.(3)
    /// 1/4	= 	0.25
    /// 1/5	= 	0.2
    /// 1/6	= 	0.1(6)
    /// 1/7	= 	0.(142857)
    /// 1/8	= 	0.125
    /// 1/9	= 	0.(1)
    /// 1/10	= 	0.1
    /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.It can be seen that 1/7 has a 6-digit recurring cycle.
    /// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
    /// </summary>
    public class Problem26
    {
        // General algo is to divide by digit to get current position then multilpy remainder by 10 and move one place lower
        // in the decimal. Need to figure out a way to detect a cycle.

        public static List<decimal> GetDecimals(int maxDenominator)
        {
            if(maxDenominator <= 0)
            {
                throw new ArgumentException("Cannot work with a negative denominator", nameof(maxDenominator));
            }

            List<decimal> result = new(maxDenominator);
            Problem26 reference = new();

            for(int i = 2; i <= maxDenominator; i++)
            {
                result.Add(reference.FractionToDecimal(1, i));
            }

            return result;
        }

        private decimal FractionToDecimal(int numerator, int denominator)
        {
            decimal answer = 0m, multiplier = 1m;
            int remainder = numerator;
            int breaker = 0;

            do
            {
                answer += (remainder / denominator) * multiplier;
                remainder %= denominator;
                remainder *= 10;
                multiplier /= 10m;
            }
            while (remainder > 0 && breaker++ < 20);

            return answer;
        }
    }
}
