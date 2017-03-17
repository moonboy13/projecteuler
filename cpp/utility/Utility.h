#ifndef _UTILITY_H_
#define _UTILITY_H_

#include <math.h>

namespace Utility
{
  // Determine if an integer is prime
  bool isPrime(int number);
  bool isPrime(int long number);

  // Implement the sieve of Eratosthenes
  bool * sieveOfErat(bool nums[], int max);
};

#endif