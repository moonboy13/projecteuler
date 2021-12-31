using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Solutions
{
    /// <summary>
    ///   Euler discovered the remarkable quadratic formula:
    /// n**2 + n + 41
    /// It turns out that the formula will produce 40 primes for the consecutive integer values 0 <= n <= 39 .However, when n=40, 40**2 + 40 + 41  is divisible by 41, and certainly when n = 41  is clearly divisible by 41.
    /// The incredible formula n**2 - 79n + 1601 was discovered, which produces 80 primes for the consecutive values 0 <= n <= 79 .The product of the coefficients, −79 and 1601, is −126479.
    /// Considering quadratics of the form:
    /// n**2 + an + b, where abs(a) < 1000 and abs(b) <= 1000
    /// where abs(n) is the modulus/absolute value of n
    ///
    /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0.
    /// </summary>

    public class Problem27
    {
        // Start w/ n = 0. Given the constraints, b must be a postive prime number less than 1k.
        // Then, b +/- a must still be prime.
        // Using these two constriants, it should be possible to create a short list of possible a & b values to try plugging into the formula.
        // Be sure to build a list of primes along the way to check against.
        private int _minA, _maxA, _minB = 0, _maxB;
        private List<int> _primes = new();
        
        private Problem27(int minA, int maxA, int maxB)
        {
            _minA = minA + 1;
            _maxA = maxA - 1;
            _maxB = maxB;
        }

        public static int Solve(int A, int B)
        {
            return Solve(-A, A, B);
        }

        public static int Solve(int minA, int maxA, int maxB)
        {
            Problem27 obj = new(minA, maxA, maxB);
            Dictionary<int, List<int>> valuesForAGivenB = obj.GetAValues(obj.GetBValues());

            Func<int, int, int, bool> ComboIsPrime = (a, b, n) => obj.IsPrime(n * n + a * n + b);
            int maxN = 0, a=0, b=0;

            foreach(var pairing in valuesForAGivenB)
            {
                foreach(var aVal in pairing.Value)
                {
                    int n = 0;
                    
                    // Quick check, if the current pairing cannot best the existing max N val by
                    // one then there is no need to check any intermediate vals. Should save a
                    // bit of processing in the typical case and does not add too much in the worst
                    // case scenario as we only do one extra prime check.
                    if(!ComboIsPrime(aVal, pairing.Key, maxN+1))
                    {
                        continue;
                    }

                    while(ComboIsPrime(aVal, pairing.Key, n))
                    {
                        n++;
                    }

                    if(n > maxN)
                    {
                        a = aVal;
                        b = pairing.Key;
                        maxN = n;
                    }
                }
            }

            return a*b;
        }

        private bool IsPrime(int n)
        {
            if(n < 2)
            {
                return false;
            }

            if(_primes.Contains(n))
            {
                return true;
            }

            if(n.IsPrime())
            {
                _primes.Add(n);
                return true;
            }

            return false;
        }

        private List<int> GetBValues()
        {
            List<int> values = new();
            for(int i = _minB; i <= _maxB; i++)
            {
                if(i.IsPrime() && !values.Contains(i))
                {
                    values.Add(i);
                }
            }

            return values;
        }

        private Dictionary<int, List<int>> GetAValues(List<int> bValues)
        {
            Dictionary<int, List<int>> finalValues = new();

            foreach(var b in bValues)
            {
                finalValues.Add(b, new List<int>());
                for(int i = _minA; i <= _maxA; i++)
                {
                    if(IsPrime(b + i + 1))
                    {
                        finalValues[b].Add(i);
                    }
                }
            }

            return finalValues;
        }
    }
}
