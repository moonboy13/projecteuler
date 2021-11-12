/*
 * n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!

Shifting everything down by a factor of 10. The digits will be the same
but we avoid the rollover of the integer value.

Using decimals to avoid issues with floating point values.
 */

using System;

Console.WriteLine("foo");