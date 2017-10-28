#include <iostream>
#include <stdio.h>

/**
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
Find the largest palindrome made from the product of two 3-digit numbers.
*/

// Figure out if the character array is a palindrome
bool isPalindrome (char * input, int nChars) {
  nChars--;
  for(int i = 0; i <= (nChars / 2); i++) {
    if (input[i] != input[(nChars - i)]) {
      return false;
    }
  }
  return true;
}

int main(int argc, char const *argv[]) {
  int i, j, n, product, max = 0;
  char buffer [50];

  // Starting from the maximum product. Idea being that this is a slight optimization as the
  // less-than comparision will execute faster than the isPalindrome() check.
  for (i = 999; i > 0; i--) {
    for (j = 999; j > 0; j--) {
      product = i * j;
      n = sprintf(buffer, "%d", product);
      if(max < product && isPalindrome(buffer, n)) {
        max = product;
      }
    }
  }

  std::cout << "The largest palindromic number is " << max << std::endl;
  return 0;
}