#ifndef _BIGNUM_H_
#define _BIGNUM_H_

#include <iostream>
#include <string>
#include <vector>

/**
Handle numbers that are larger than a standard long int
*/

class BigNum
{
public:
  BigNum(std::string number);
  ~BigNum();

  // Add will have to handle the case where it needs a new digit
  // BigNum add(int adder);
  // BigNum add(int long adder);
  void add(BigNum *adder);

  void pad(std::vector<int> &a, std::vector<int> &b);

  std::vector<int> getDigits();

  void print();

private:
  std::vector<int> digits;
  int unsigned nDigits;

  int addNums(int a, int b, int &remaining);
};

#endif