#include <iostream>
#include <math.h>

/**
The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?
*/

int main(int argc, char const *argv[])
{

  int long sum = 0;
  int squareRootInt, factorCount, max = 3000000;
  double squareRoot;

  for(int i = 1; i < max; i++) {
    sum += i;

    squareRoot = sqrt(sum);
    squareRootInt = (int) squareRoot;
    factorCount = 0;
    for(int lowFactor = 1; lowFactor <= squareRootInt; lowFactor++) {
      if(sum % lowFactor == 0) {
        factorCount++;
      }
    }
    if(factorCount > 250) {
      std::cout << sum << std::endl;
      break;
    }
  }
  std::cout << "done\n";
  return 0;
}