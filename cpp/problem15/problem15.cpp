#include <iostream>

/**
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
How many such routes are there through a 20×20 grid?
**/

unsigned int long getNextPascalNumber(double prev_number, int k, int row_num) {
    double factor = ((double)row_num + 1 - (double)k) / (double)k;
    std::cout << "Factor <" << factor << ">\n";
    return (unsigned int long)(prev_number * factor);
}

int main() {
    unsigned int long num = 1;
    int row;

    std::cout << "Enter row number: ";
    std::cin >> row;
    
    for (int i = 1; i <= (row+1); i++) {
        std::cout << num << ", ";
        num = getNextPascalNumber(num, i, row);
    }

    std::cout << std::endl;

    return 0;
}
