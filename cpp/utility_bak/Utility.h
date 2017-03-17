#ifndef _UTILITY_H_
#define _UTILITY_H_

#include <math.h>

class Utility
{
public:
  // Constructor and descructor. Will be blank initially
  Utility();
  ~Utility();

  // Determine if an integer is prime
  bool isPrime(int number);
  bool isPrime(int long number);
};

#endif