using System;
using Exceptions;

public class Test
{
    private static void Main()
    {
        int testNum = 105;
        int startNum = 1;
        int endNum = 100;

        try
        {
            if (testNum < startNum || testNum > endNum)
            {
                throw new InvalidRangeException<int>(startNum, endNum);
            }
        }
        catch (InvalidRangeException<int> intEx)
        {
            Console.WriteLine(intEx.Message);
        }

        DateTime testDate = DateTime.Now;
        DateTime startDate = new DateTime(2013, 12, 31);
        DateTime endDate = new DateTime(1980, 1, 1);

        try
        {
            if (testDate < startDate || testDate > endDate)
            {
                throw new InvalidRangeException<DateTime>(startDate, endDate);
            }
        }
        catch (InvalidRangeException<DateTime> dateEx)
        {
            Console.WriteLine(dateEx.Message);
        }
    }
}
