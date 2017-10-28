using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
*/

namespace Problem18
{
	class Program
	{
		static void Main(string[] args)
		{
			//-- Read in the file
			List<List<int>> lineData = ReadFile("Data/ProblemData.txt");

			//-- Roll through the lines, merging them up.
			int nLines = lineData.Count;
			for (int i = (nLines - 2); i > -1; i--)
			{
				lineData[i] = MergeUpList(lineData[i], lineData[i + 1]);
			}
			Console.WriteLine(lineData[0][0]);
		}

		static List<int> MergeUpList(List<int> topList, List<int> bottomList)
		{
			for(int i = 0; i < topList.Count; i++)
			{
				//-- Max function here would've tidied up the solution
				int leftSum = topList[i] + bottomList[i];
				int rightSum = topList[i] + bottomList[i + 1];
				topList[i] = (leftSum > rightSum) ? leftSum : rightSum;
			}

			return topList;
		}

		static List<List<int>> ReadFile(string pcFileLocation)
		{
			List<List<int>> fileLines = new List<List<int>>();

			try
			{
				using (StreamReader fileStream = new StreamReader(pcFileLocation))
				{
					string textLine;
					while((textLine = fileStream.ReadLine()) != null)
					{
						List<int> line = (
							from stringNumber in textLine.Split(' ')
							select
								Convert.ToInt32(stringNumber)
							).ToList();
						fileLines.Add(line);
					}
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ForegroundColor = ConsoleColor.White;
			}

			return fileLines;
		}
	}
}
