using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    /*
     *
     *Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?
     */
    public class Problem22
    {
        private readonly string _FileContents = Properties.Resources.p022_names;

        public static ulong Solve()
        {
            return new Problem22().InnerSolve();
        }

        private Problem22() { }

        private ulong InnerSolve()
        {
            ulong sum = 0;
            List<string> names = _FileContents.Replace("\"", "").Split(',').ToList();
            names.Sort();

            for(int i = 0; i < names.Count; i++)
            {
                sum += (ulong)(WordScore(names[i]) * (i + 1));
            }

            return sum;
        }

        private int WordScore(string word)
        {
            int score = 0;
            foreach (char c in word)
            {
                score += c % 32;
            }

            return score;
        }

    }
}
