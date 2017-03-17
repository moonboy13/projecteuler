#include <iostream>

#include "../utility/Utility.h"

/*
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?
*/

int main(int argc, char const *argv[]) {
  int count = 0, i = 2;

  while(count < 10001) {
    if(Utility::isPrime(i)) {
      count++;
    }
    i++;
  }

  // i ends up iterating one value beyond the one I want
  std::cout << (i-1) << std::endl;

  return 0;
}