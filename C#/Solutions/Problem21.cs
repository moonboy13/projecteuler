namespace Solutions
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper 
    /// divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// 
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    public class Problem21
    {
        private static List<int> m_AmicableNumbers = new List<int>() { };

        private Problem21() { }

        public static int SumAmicableNumbersUnder(int max)
        {
            for(int i = 0; i < max; i++)
            {
                if(!m_AmicableNumbers.Contains(i))
                {
                    int x = SumDivisors(i);
                    if (i != x)
                    {
                        int y = SumDivisors(x);
                        if(y == i)
                        {
                            m_AmicableNumbers.Add(i);
                            m_AmicableNumbers.Add(x);
                        }

                    }
                }
            }

            return m_AmicableNumbers.Sum();
        }


        private static int SumDivisors(int n)
        {
            int result = 1;
            int step = 1;
            int max = (int)Math.Sqrt(n);

            // If the number is not even we can skip all even numbers
            if(n % 2 > 0)
            {
                step++;
            }
            else
            {
                result += 2;
                result += (n / 2);
            }

            for(int i = 3; i< max; i += step)
            {
                if(n % i == 0)
                {
                    result += i;
                    result += (n / i);
                }
            }

            return result;
        }
    }
}