#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <cerrno>
#include <cstring>
#include <stdlib.h>

#include "../utility/BigNum.h"

#include <boost/algorithm/string.hpp>

/**
Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
see file
*/

int main(int argc, char const *argv[])
{
    std::string line, init = "0";
    
    BigNum *sum = new BigNum(init);
    
    // Read file in line by line
    std::ifstream fileHandle;
    fileHandle.open("problem13/numbers.txt");

    if(fileHandle.is_open()) {
        while(std::getline(fileHandle, line)) {
            std::cout << "Incoming number: " << line;
            boost::trim_right(line);
            BigNum *adder = new BigNum(line);
            std::cout << "Sum: ";
            sum->add(adder);
            sum->print();
            std::cout << std::endl;
            delete adder;
        }
    } else {
        std::cerr << std::strerror(errno) << std::endl;
    }

    sum->print();
    std::cout << std::endl;

    return 0;
}
