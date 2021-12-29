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

    internal class Problem27
    {
        // Start w/ n = 0. Given the constraints, b must be a postive prime number less than 1k.
        // Then, b +/- a must still be prime.
        // Using these two constriants, it should be possible to create a short list of possible a & b values to try plugging into the formula.
        // Be sure to build a list of primes along the way to check against.
    }
}
