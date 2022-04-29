using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extentions;

namespace Solutions
{
    public class Problem32
    {
        /*
         * We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
         * The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
         * Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
         * HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
         * 
         * Plan:
         * Create array of digits [1,9]
         * slide the multiplier and equals sign through the array to test combos
         *  Can be smart here by counting digits to skip some combos if needed for time.
         *  Sum of digits for multiplicand and multiplier is greater than digist in product
         *  Equals sign is at index 4.5, multilpier operator slides from 0.5 to 3.5
         * iterate combination of digits in array
         * profit
         */

        private List<int> _digits = Enumerable.Range(1, 9).ToList();
        private HashSet<int> _products = new HashSet<int>();
        private const int DIGITS_IN_PRODUCT = 4;
        private const int DIGITS_IN_MULTIPLIER_MULTIPLICAND = 5;

        public static int Solve()
        {
            Problem32 reference = new Problem32();
            return reference.InnerSolve();
        }

        private int InnerSolve()
        {
            foreach(var perm in Permutate(_digits, _digits.Count))
            {
                int product = _digits
                    .TakeLast(DIGITS_IN_PRODUCT)
                    .ToInt();

                for (int multiplierPosition = 1; multiplierPosition < DIGITS_IN_MULTIPLIER_MULTIPLICAND; multiplierPosition++)
                {
                    
                    int multiplicand = _digits
                        .Take(multiplierPosition)
                        .ToInt();
                    int multiplier = _digits
                        .Skip(multiplierPosition)
                        .Take((DIGITS_IN_MULTIPLIER_MULTIPLICAND - multiplierPosition))
                        .ToInt();

                    if(multiplier * multiplicand == product)
                    {
                        _products.Add(product);
                    }
                }
            }

            return _products.Sum();
        }

        // Below functions taken from https://www.codeproject.com/Articles/43767/A-C-List-Permutation-Iterator
        private void RotateRight<T>(IList<T> sequence, int count)
        {
            T tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        private IEnumerable<IList<T>> Permutate<T>(IList<T> sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;

                    RotateRight(sequence, count);
                }
            }
        }
    }
}
