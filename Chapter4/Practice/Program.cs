using System.Linq;

namespace Chapter4.Practice;

class Program
{
    static void Main(string[] args)
    {
        // 4-2-1
        var YearMonthArr = new YearMonth[] {
            new YearMonth(2001, 3),
            new YearMonth(1993, 3),
            new YearMonth(2024, 12),
            new YearMonth(2005, 5),
            new YearMonth(2012, 12)
        };

        // 4-2-2
        foreach (var yearMonth in YearMonthArr)
        {
            Console.WriteLine(yearMonth.ToString());
        }

        // 4-3-3

    }

    static YearMonth FindYearMonth(Array yearMonthArr)
    {
        
    }
}

// 4-1
class YearMonth
{
    public int Year {get; private set;}
    public int Month {get; private set;}

    public bool Is21Century
    {
        get {
            if (2001 <= Year && Year <= 2100 )
            {
                return true;
            }
            return false;
        }
    }

    public override string ToString()
    {
        return $"{Year}年{Month}月";
    }

    public YearMonth AddOneMonth()
    {
        if (Month == 12)
        {
            return new YearMonth(++Year, 1);
        }

        return new YearMonth(Year, ++Month);
    }

    public YearMonth(int year, int month)
    {
        Year = year;
        Month = month;
    }
}
