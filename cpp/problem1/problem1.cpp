#include <iostream>

/**
* If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
* Find the sum of all the multiples of 3 or 5 below 1000.
*/

int main(int argc, char const *argv[])
{
  int sum = 0;
  int candidate = 1;

  while (candidate < 1000)
  {
    if( (candidate % 3 == 0) || (candidate % 5 == 0) )
    {
      sum += candidate;
    }
    candidate++;
  }
  std::cout << "The sum is:\t" << sum << std::endl;
  return 0;
}
