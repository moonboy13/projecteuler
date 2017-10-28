#include <iostream>

/*
The sum of the squares of the first ten natural numbers is,

12 + 22 + ... + 102 = 385
The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)2 = 552 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
*/

int main(int argc, char const *argv[])
{
  int sum = 0, square = 0;
  for(int i = 1; i < 101; i++)
  {
    sum += i;
    square += (i * i);
  }

  sum *= sum;

  std::cout << (square - sum) << std::endl;
  return 0;
}