#include <iostream>

/*
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
*/

int main(int argc, char const *argv[])
{
  int a, b, c;
  // Setting a reasonable termination incase I mess something up.
  for(int n = 2; n < 100 ; n++) {
    for(int m = (n + 1); m < 100; m++) {
      a = (m * m) - (n * n);
      b = 2 * m * n;
      c = (m * m) + (n * n);
      if( (a + b + c) == 1000 ) {
        std::cout << (a * b * c) << std::endl;
      }
    }
  }
  return 0;
}