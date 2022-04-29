using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extentions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Swap to elements in-place within the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Swap<T>(this IList<T> list, int from, int to)
        {
            //-- Nothing to swap, get out now
            if(from == to)
            {
                return;
            }

            void CheckPositionIsValue(int count, int pos, string name)
            {
                if(pos < 0 || pos >= count)
                    throw new ArgumentOutOfRangeException(nameof(pos), pos, $"Value {pos} for parameter {name} is outside the bounds of the array.");
            }

            CheckPositionIsValue(list.Count, from, nameof(from));
            CheckPositionIsValue(list.Count, to, nameof(to));

            T temp = list[to];
            list[to] = list[from];
            list[from] = temp;
        }

        /// <summary>
        /// Convert an IEnumerable of ints to an integer. If the length of the IEnumerable is known ahead of time
        /// the set the count parameter to improve performance
        /// </summary>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int ToInt(this IEnumerable<int> list, int count = 0)
        {
            if(count == 0)
            {
                count = list.Count();
            }

            int multiplier = (int)Math.Pow(10, count-1);
            int val = 0;

            foreach(var digit in list)
            {
                val += (digit * multiplier);
                multiplier /= 10;
            }

            return val;
        }

    }
}
