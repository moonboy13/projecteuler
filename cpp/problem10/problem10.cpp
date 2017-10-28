#include <iostream>

#include "../utility/Utility.h"

/*
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.
*/

int main(int argc, char const *argv[])
{
  int long sum = 0;

  for(int i = 2; i < 2000000; i++) {
    if(Utility::isPrime(i)) {
      sum += i;
    }
  }

  std::cout << sum << std::endl;
  return 0;
}