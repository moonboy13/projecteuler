using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Class to handle integer numbers larger than Int64.MAX
    /// </summary>
    public class BigInt
    {
        private List<int> _digits;

        /// <summary>
        /// Access individual digist based of an index. Mostly around
        /// to allow testing to validate the digit array.
        /// </summary>
        /// <param name="i">In base 10, which digit to return.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int this[int i]
        {
            get
            {
                if (i > _digits.Count - 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }
                return _digits[i];
            }
            private set
            {
                _digits.Insert(i, value);
            }
        }

        /// <summary>
        /// Private constructor to ensure that the factory methods are used.
        /// </summary>
        /// <param name="size"></param>
        private BigInt(int size = 1)
        {
            _digits = new List<int>(size) { };
        }

        /// <summary>
        /// Initialize the class from an integer value
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static BigInt FromInt(int start)
        {
            BigInt retVal = new();
            while (start > 0)
            {
                retVal.AppendDigit(start % 10);
                start /= 10;
            }

            return retVal;
        }

        /// <summary>
        /// Culture sensitive to-string representation of the number
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retString = new();
            StringBuilder initialString = new();
            string separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
            int groupSize = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSizes[0];
            int groupCounter = 0;

            foreach (int digit in _digits)
            {
                if (++groupCounter > groupSize)
                {
                    initialString.Append(separator);
                    groupCounter = 1;
                }
                initialString.Append(digit);
            }

            // Have to reverse the string so that it looks correct when printed
            for (int i = initialString.Length - 1; i >= 0; i--)
            {
                retString.Append(initialString[i]);
            }

            return retString.ToString();
        }

        /// <summary>
        /// This performs a value type comparison for equality instead of validating the
        /// references match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is BigInt right)
            {
                return this == right;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the hash code of the object. Pass through to the base implementation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region Operator Overloads
        public static BigInt operator +(BigInt left, BigInt right)
        {
            if (left is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            int remainder = 0;
            BigInt biggerNumber = left._digits.Count > right._digits.Count ? left : right;
            int length = Math.Min(left._digits.Count, right._digits.Count);
            int i = 0;
            BigInt result = new();
            for (; i < length; i++)
            {
                // Max value for sum is 27 (9 + 9 + 9)
                int sum = left[i] + right[i] + remainder;
                remainder = sum / 10;
                result.AppendDigit(sum % 10);
            }

            for (; i < biggerNumber._digits.Count; i++)
            {
                int sum = biggerNumber[i] + remainder;
                remainder = sum / 10;
                result.AppendDigit(sum % 10);
            }

            while (remainder > 0)
            {
                result.AppendDigit(remainder % 10);
                remainder /= 10;
            }

            return result;
        }

        public static bool operator ==(BigInt left, BigInt right)
        {
            if (left is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            // simple check
            if (left._digits.Count != right._digits.Count)
            {
                return false;
            }

            // now have to go digit by digit to ensure we match
            for (int i = 0; i < left._digits.Count; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            // Made it through all the checks, must be true
            return true;
        }

        public static bool operator !=(BigInt left, BigInt right) => !(left == right);

        public static BigInt operator *(BigInt left, BigInt right)
        {
            // Figure out which one has fewer digits and multiple that one into the other.
            // This allows me to create the fewest additional BigInt references so should save some time.
            BigInt finalValue = FromInt(0);
            bool leftIsBigger = left._digits.Count > right._digits.Count;
            BigInt multiplyee = leftIsBigger ? left : right;
            BigInt multiplyer = leftIsBigger ? right : left;
            List<BigInt> toAdd = new List<BigInt>(multiplyer._digits.Count);

            for(int i = 0; i < multiplyer._digits.Count; i++)
            {
                int x = 0;
                BigInt newVal = new();
                while(x++ < i)
                {
                    newVal.AppendDigit(0);
                }
                int currentMultiplyer = multiplyer._digits[i];

                // If we encounter a 0 there is no need to do any work
                if (currentMultiplyer != 0)
                {
                    int remainder = 0;
                    for (int j = 0; j < multiplyee._digits.Count; j++)
                    {
                        int curResult = multiplyee._digits[j] * currentMultiplyer + remainder;
                        newVal.AppendDigit(curResult % 10);
                        remainder = curResult / 10;
                    }
                    if (remainder != 0)
                    {
                        newVal.AppendDigit(remainder);
                    }

                    toAdd.Add(newVal);
                }
            }

            // Sum all our values
            foreach(var adder in toAdd)
            {
                finalValue += adder;
            }

            return finalValue;
        }

    #endregion

    private void AppendDigit(int x)
        {
            _digits.Add(x);
        }
    }
}
