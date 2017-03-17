#include "BigNum.h"

BigNum::BigNum(std::string number) {
  // Split the string up
  nDigits = number.size();

  // Read in each digit
  digits.reserve(nDigits);

  // i is an unsigned int, so it will never go below zero. Therefore, define
  // another counter to go up in the loopity-loop
  int unsigned c = 0;
  for(std::string::size_type i = (nDigits - 1); c < nDigits ; i--, c++) {
    if(!isspace(number[i]))
      digits.push_back((int)(number[i] - '0'));
  }
}

BigNum::~BigNum() {
  digits.clear();
}

std::vector<int> BigNum::getDigits() {
  return digits;
}

// Won't work if the two numbers are differing lengths.
void BigNum::add(BigNum *adder) {
  // Setup iterators to walk backwards
  std::vector<int> v = adder->getDigits(); // Need this intermediate step for iterator to work

  // Pad with 0's so that we're all working with the same number of digits
  pad(digits, v);

  std::vector<int>::iterator curNum = digits.begin(), addingNum = v.begin();
  int newDigit, remain = 0;

  // Add digit by digit, keeping remainder when above 10.
  while(curNum != digits.end() && addingNum != digits.end()) {
    newDigit = addNums(*curNum, *addingNum, remain);
    *curNum = newDigit;
    curNum++; addingNum++;
  }

  // Resizing instead of pushing back b/c that should be faster
  if(remain > 0) {
    digits.resize((nDigits + 1), remain);
  }
}

void BigNum::pad(std::vector<int> &a, std::vector<int> &b) {
  int aSize = a.size(), bSize = b.size();
  if(aSize > bSize) {
    b.resize(aSize, 0);
  } else if (bSize > aSize) {
    a.resize(bSize, 0);
  }
}

int BigNum::addNums(int a, int b, int &remaining) {
  int sum = a + b + remaining;

  remaining = 0;
  while(sum > 9) {
    sum -= 10;
    remaining += 1;
  }

  return sum;
}

void BigNum::print() {
  // Loop through in the opposite direction. This is because the digits vector is setup
  // so that the last digit corresponds to the hightest digit for ease of adding.
  for(std::vector<int>::iterator v = digits.begin(); v != digits.end(); v++) {
    std::cout << *v;
  }
}
