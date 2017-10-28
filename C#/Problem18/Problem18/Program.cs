using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
