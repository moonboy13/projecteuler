#include <iostream>

long int getNSequence(long int number, long int cur_sum) {
    if(number == 1) {
        return cur_sum;
    } else if (number%2 == 0) {
        number /= 2;
    } else {
        number = 3*number + 1;
    }

    cur_sum++;
    return getNSequence(number, cur_sum);
}

int main() {
    long int max_sequence = 0, temp_sequence, starter;

    for (long int i = 100; i < 1000000; i++) {
        temp_sequence = getNSequence(i, 1l);
        if(temp_sequence > max_sequence) {
            max_sequence = temp_sequence;
            starter = i;
        }
    }

    std::cout << starter << std::endl;

    return 0;
}
