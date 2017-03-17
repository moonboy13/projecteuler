#include <iostream>
#include <math.h>

#include "../utility/Utility.h"

/*
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.

This round is to implement the sieve of Eratosthenes
*/

/*bool * sieveOfErat(bool nums[], int max) {
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
}*/

int main(int argc, char const *argv[]) {
  int long sum = 0;
  int max = 2000001;
  bool init[max];
  bool * primes;

  primes = Utility::sieveOfErat(init, max);

  for(int i = 0; i < max; i++) {
    if(primes[i]) {
      sum += i;
    }
  }
  std::cout << sum << std::endl;
  return 0;
}