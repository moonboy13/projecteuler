using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    ///
    /// 012   021   102   120   201   210
    ///
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    /// <plan>
    /// X = combinations to try, starting at 1 million.
    /// Y = left position in list, starting at 0.
    /// Z = counter for the number of times N goes into X, starting at 1
    /// N = total number of possible combinations for the # of total digits - Y.
    /// WHILE X > 0
    ///     IF(N < X)
    ///         X -= N
    ///         Swap digit Y with Y + Z
    ///         Z++
    ///     ELSE
    ///         Z = 1
    ///         Y++
    /// 
    /// </plan>
    public class Problem24
    {
        private uint _combosToTry;
        private int _digitPosition = 0;
        private List<int> _digits = new()
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        };
        private uint _totalDigits;

        private Problem24(uint combos)
        {
            _combosToTry = combos;
            _totalDigits = (uint)_digits.Count;
        }

        public static List<int> Solve(uint totalCombos)
        {
            Problem24 foo = new(--totalCombos);
            return foo.InnerSolve();
        }

        private List<int> InnerSolve()
        {
            int counter = 1;
            uint totalCombos = GetCombos();
            while(_combosToTry > 0)
            {
                if(totalCombos <= _combosToTry)
                {
                    _combosToTry -= totalCombos;
                    int swapPosition = (_digitPosition + counter);
                    int temp = _digits[_digitPosition];
                    _digits[_digitPosition] = _digits[swapPosition];
                    _digits[swapPosition] = temp;
                    counter++;
                }
                else
                {
                    counter = 1;
                    _digitPosition++;
                    totalCombos = GetCombos();
                }
            }

            return _digits;
        }

        private uint GetCombos()
        {
            return (_totalDigits - (uint)(_digitPosition + 1)).Factorial();
        }

    }
}
