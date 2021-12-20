namespace Extentions
{
    public static class NumericExtensions
    {
        public static HashSet<int> FindDivisors(this int n)
        {
            int step = 1;
            int max = (int)Math.Sqrt(n);
            HashSet<int> divisors = new HashSet<int>() { 1 };

            if(n <= 2)
            {
                return divisors;
            }

            // If not even then we can skip all even numbers
            if (n % 2 > 0)
            {
                step++;
            }
            else
            {
                divisors.Add(2);
                divisors.Add(n / 2);
            }

            for(int i = 3; i <= max; i++)
            {
                if(n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }

            return divisors;
        }
    }
}