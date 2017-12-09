using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
*/

namespace Problem19
{
	class Program
	{
		//-- I realize everything being static is bad.
		private static List<int> thirtyOneDays = new List<int>()
		{
			0, 2, 4, 6, 7, 9, 11
		};

		private static List<int> thirtyDays = new List<int>()
		{
			3, 5, 8, 10
		};

		private static bool IsLeapYear(int year) => ((year % 4 == 0) && (year % 100 != 0 || year % 400 == 0));

		private static void AdvanceStartDay(int month, int year, ref DayOfWeek day)
		{
			if(thirtyOneDays.Contains(month))
			{
				day += 3;
			}
			else if(thirtyDays.Contains(month))
			{
				day += 2;
			}
			else
			{
				if(IsLeapYear(year))
				{
					day++;
				}
			}

			if(day > DayOfWeek.Saturday)
			{
				day -= 7;
			}
		}

		static void Main(string[] args)
		{
			//-- Determine inital positions
			int count = 0, year = 1900;
			DayOfWeek start = DayOfWeek.Monday;

			while(year < 2001)
			{
				int month = 0;
				while (month < 12)
				{
					Console.WriteLine("Year: " + year.ToString() + " Month: " + month.ToString() + " Mine: " + start.ToString() + " NET: " + new DateTime(year, (month + 1), 1).DayOfWeek.ToString());
					if (start == DayOfWeek.Sunday)
					{
						count++;
					}

					AdvanceStartDay(month, year, ref start);
					month++;
				}
				year++;
			}

			Console.WriteLine(count);
		}
	}
}
