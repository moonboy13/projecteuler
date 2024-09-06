
namespace Solutions;

static public class Problem34 {
    /***
    * 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145 
    * Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    * Note: As 1!=1 and 2!=2 are not sums they are not included.
    ***/

    private static Dictionary<char, int> Factorials = new Dictionary<char, int>() {
        {'0', 1},
        {'1', 1},
        {'2', 2},
        {'3', 6},
        {'4', 24},
        {'5', 120},
        {'6', 720},
        {'7', 5040},
        {'8', 40320},
        {'9', 362880}
    };

    public static int BruteForce() {
        int start = 33;
        int max = 10000000;
        int sum = 0;

        while(start < max) {
            char[] digits = start.ToString().ToCharArray();
            int innerSum = 0;
            for(int i = 0; i < digits.Length; i++) {
                innerSum += Factorials[digits[i]];
            }

            if(start == innerSum) {
                Console.WriteLine("found: " + start.ToString());
                sum += start;
            }

            start++;
        }

        return sum;
    }
}