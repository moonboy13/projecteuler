/*
 * n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
 */

using System;
using System.Numerics;
using DataStructures;

BigInt Factorial(BigInt value, int N)
{
    if(N > 0)
    {
        value *= N;
        return Factorial(value, --N);
    }
    else
    {
        return value;
    }
}

BigInt start = BigInt.FromInt(1);
start = Factorial(start, 100);
int sum = 0;
for(int i = 0; i < start.Count; i++)
{
    sum += start[i];
}

Console.WriteLine(sum);
