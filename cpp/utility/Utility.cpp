#include "Utility.h"

// Overloading of the isPrime function for a different int type
bool Utility::isPrime(int number)
{
  return isPrime((long) number);
}

// Determine if a numbe is prime by checking each factor starting at two
// up to the sqrt of the number. If any of them divide into the number then
// it is not prime.
bool Utility::isPrime(int long number)
{
  int squareRootInt;
  double squareRoot;

  squareRoot = sqrt(number);
  squareRootInt = (int) squareRoot;

  for(int i = 2; i <= squareRootInt; i++)
  {
    if(number % i == 0)
    {
      return false;
    }
  }
  return true;
}

bool * Utility::sieveOfErat(bool nums[], int max) {
  for(int j = 0; j < max; j++) {
    nums[j] = true;
  }

  int squareRootInt;
  double squareRoot;

  squareRoot = sqrt(max);
  squareRootInt = (int) squareRoot;

  nums[0] = false;
  nums[1] = false;

  // Fill out the sieve
  for(int i = 2; i < squareRootInt; i++) {
    if(nums[i]) {
      for(int m = (i * 2); m < max; m += i) {
        nums[m] = false;
      }
    }
  }

  return nums;
}