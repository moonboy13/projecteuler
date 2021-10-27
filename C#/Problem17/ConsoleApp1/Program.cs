// See https://aka.ms/new-console-template for more information
using System.Text;

int total = 0;
foreach(var num in Enumerable.Range(1, 1000))
{
    total += GetNumberStringLetterCount(num);
}

Console.WriteLine(total);


static string GetOnesString(int number) => number switch
{

    0 => string.Empty,
    1 => "one",
    2 => "two",
    3 => "three",
    4 => "four",
    5 => "five",
    6 => "six",
    7 => "seven",
    8 => "eight",
    9 => "nine",
    _ => throw new ArgumentException("This method only accepts [0,9]", nameof(number))
};

static string GetTensString(int number)
{
    string retVal = string.Empty;
    if(number < 20)
    {
        retVal = number switch
        {
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            13 => "thirteen",
            14 => "fourteen",
            15 => "fifteen",
            16 => "sixteen",
            17 => "seventeen",
            18 => "eighteen",
            19 => "nineteen",
            _ => throw new NotImplementedException() // Should be unreachable, unless the compiler and CLR fails me
        };
    }
    else
    {
        int remainder = number % 10;
        retVal = (number / 10) switch
        {
            2 => string.Join("", "twenty", GetOnesString(remainder)),
            3 => string.Join("", "thirty", GetOnesString(remainder)),
            4 => string.Join("", "forty", GetOnesString(remainder)),
            5 => string.Join("", "fifty", GetOnesString(remainder)),
            6 => string.Join("", "sixty", GetOnesString(remainder)),
            7 => string.Join("", "seventy", GetOnesString(remainder)),
            8 => string.Join("", "eighty", GetOnesString(remainder)),
            9 => string.Join("", "ninety", GetOnesString(remainder)),
            _ => throw new ArgumentException("This method only accepts [10, 99]", nameof(number))
        };
        if(remainder == 0)
        {
            retVal = retVal.TrimEnd('-');
        }
    }

    return retVal;
}

static int GetNumberStringLetterCount(int number)
{
    StringBuilder ret = new();

    int thousands = (number / 1000);
    int hundreds = (number % 1000) / 100;
    int tens = (number % 100);

    if(thousands > 0 )
    {
        ret.Append(GetOnesString(thousands) + "thousand");
    }

    if( hundreds > 0 )
    {
        ret.Append(GetOnesString(hundreds) + "hundred");
        if(tens > 0)
        {
            ret.Append("and");
        }
    }

    if( tens > 9 )
    {
        ret.Append(GetTensString(tens));
    }
    else
    {
        ret.Append(GetOnesString(tens));
    }

    Console.WriteLine(ret.ToString() + "   " + ret.Length.ToString());

    return ret.Length;
}