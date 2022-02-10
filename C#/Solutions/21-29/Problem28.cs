using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    /// <summary>
    ///    Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
    /// 21 22 23 24 25
    /// 20  7  8  9 10
    /// 19  6  1  2 11
    /// 18  5  4  3 12
    /// 17 16 15 14 13
    /// It can be verified that the sum of the numbers on the diagonals is 101.
    /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    public class Problem28
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">Maximum numbers to a side. Since this is a square, (n-1) % 2 == 0</param>
        /// <returns></returns>
        public static int Solve(int n)
        {
            if((n-1) % 2 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            List<int> numList = new() { 1 };
            int currVal = 1;
            int currLayer = 0;
            int maxLayer = (n - 1) / 2;
            int nextVal = 0;

            while (currLayer < maxLayer)
            {
                currLayer++;
                for (int i = 1; i < 5; i++)
                {
                    nextVal = currVal + (2 * currLayer * i);
                    numList.Add(nextVal);
                }

                // This takes the top right of the current layer and saves it to
                // process the layers values
                currVal = nextVal;
            }

            return numList.Sum();
        }
    }
}
