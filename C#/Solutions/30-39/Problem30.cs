using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    /// <summary>
    /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    /// 
    /// 1634 = 1^4 + 6^4 + 3^4 + 4^4
    /// 8208 = 8^4 + 2^4 + 0^4 + 8^4
    /// 9474 = 9^4 + 4^4 + 7^4 + 4^4
    /// As 1 = 1^4 is not a sum it is not included.
    /// 
    /// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    ///
    /// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    /// </summary>
    static public class Problem30
    {
        // 999,999 is the break even where summing the digits matches the number of digits in the number. This should provide a reasonable upper limit.
        static double power = 5;
        static int _nineFifth = (int)Math.Pow(9, power);
        static int _eightFifth = (int)Math.Pow(8, power);
        static int _sevenFifth = (int)Math.Pow(7, power);
        static int _sixFifth = (int)Math.Pow(6, power);
        static int _fiveFifth = (int)Math.Pow(5, power);
        static int _fourFifth = (int)Math.Pow(4, power);
        static int _threeFifth = (int)Math.Pow(3, power);
        static int _twoFifth = (int)Math.Pow(2, power);
        static int _oneFifth = 1;
        static int _maxValue = 999999;


        /// <summary>
        /// This increments the digit in a position by bumping the 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        static private int GetPower(int n) =>
           n switch
           {
               9 => _nineFifth,
               8 => _eightFifth,
               7 => _sevenFifth,
               6 => _sixFifth,
               5 => _fiveFifth,
               4 => _fourFifth,
               3 => _threeFifth,
               2 => _twoFifth,
               1 => _oneFifth,
               _ => 0
           };

        static public int Solve()
        {
            // 2^5 is 32, so this is the min.
            int answerSum = 0;
            for(int i = 32; i < _maxValue; i++)
            {
                int divisor = 100000;
                int num = i;
                int sum = 0;
                do
                {
                    sum += GetPower(num / divisor);
                    num %= divisor;
                    divisor /= 10;
                    
                }
                while (num > 0);

                if (sum == i)
                    answerSum += i;
            }

            return answerSum;
        }
    }
}
