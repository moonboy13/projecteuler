#include <iostream>


/*
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
*/

int main(int argc, char const *argv[]) {
  for(int i = (20*19); i < 2521000000000 ; i+=10) {
    for(int j = 11; j < 21; j++) {
      if(i%j == 0) {
        if(j == 20) {
          std::cout << i << std::endl;
          return 0;
        }
      } else {
        break;
      }
    }
  }
}