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

        public static int Solve(int maxDenominator)
        {
            if (maxDenominator <= 0)
            {
                throw new ArgumentException("Cannot work with a negative denominator", nameof(maxDenominator));
            }

            int maxCycleLength = 0;
            int index = 0;
            Problem26 reference = new();

            for (int i = 2; i <= maxDenominator; i++)
            {
                int checkVal = reference.FindCycleLength(1, i);
                if(checkVal > maxCycleLength)
                {
                    index = i;
                    maxCycleLength = checkVal;
                }
            }

            return index;
        }

        private int FindCycleLength(int numerator, int denominator)
        {
            decimal answer = 0m, multiplier = 1m;
            int remainder = numerator;
            int breaker = 0;

            // Track a list of remainder values, if the same remainder appears we have a cycle
            List<int> seenRemainders = new();

            while(remainder > 0 && !seenRemainders.Contains(remainder) && breaker++ < 2000)
            {
                seenRemainders.Add(remainder);
                answer += (remainder / denominator) * multiplier;
                remainder %= denominator;



                remainder *= 10;
                multiplier /= 10m;
            }

            int cycleLength = remainder > 0 ? seenRemainders.Count - seenRemainders.IndexOf(remainder) : 0;

            //Console.WriteLine($"Fraction: {numerator}/{denominator}\tDecimal: {answer}\tCycleLength:{cycleLength}");

            return cycleLength;
        }
    }
}
