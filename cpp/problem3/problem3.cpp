#include <iostream>
#include <math.h>

#include "../utility/Utility.h"

/**
* The prime factors of 13195 are 5, 7, 13 and 29.
* What is the largest prime factor of the number 600851475143?
*/

int main(int argc, char const *argv[])
{
  int long number;
  int squareRootInt, highFactor, maxFactor;
  double squareRoot;

  number = 600851475143;
  squareRoot = sqrt(number);
  squareRootInt = (int) squareRoot;
  maxFactor = 0;

  for(int lowFactor = 2; lowFactor <= squareRootInt; lowFactor++)
  {
    if (number % lowFactor == 0)
    {
      highFactor = number / lowFactor;
      if(Utility::isPrime(lowFactor) && lowFactor > maxFactor)
      {
        maxFactor = lowFactor;
      }
      if(Utility::isPrime(highFactor) && highFactor > maxFactor)
      {
        maxFactor = highFactor;
      }
    }
  }
  std::cout << "Maximum Factor: " << maxFactor << std::endl;
  return 0;
}