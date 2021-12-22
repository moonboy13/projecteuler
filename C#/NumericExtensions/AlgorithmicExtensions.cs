using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Extentions
{
    public static class AlgorithmicExtensions
    {
        public static int NextFib(this int current, int previous)
        {
            if(previous == 0)
            {
                return 1;
            }
            else
            {
                return current + previous;
            }
        }

        public static long NextFib(this long current, long previous)
        {
            if (previous == 0)
            {
                return 1;
            }
            else
            {
                return current + previous;
            }
        }

        public static BigInteger NextFib(this BigInteger current, BigInteger previous)
        {
            if (previous == 0)
            {
                return 1;
            }
            else
            {
                return current + previous;
            }
        }
    }
}
