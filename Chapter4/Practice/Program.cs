using System.Linq;

namespace Chapter4.Practice;

class Program
{
    static void Main(string[] args)
    {
        // 4-2-1
        YearMonth[] yearMonthArr = {
            new YearMonth(2110, 3),
            new YearMonth(1993, 3),
            new YearMonth(2224, 12),
            new YearMonth(2105, 5),
            new YearMonth(2112, 12)
        };

        // 4-2-2
        foreach (var yearMonth in yearMonthArr)
        {
            Console.WriteLine(yearMonth);
        }

        // 4-2-4
        var ym = FindYearMonth(yearMonthArr);
        // Console.WriteLine(ym?.Year.ToString() ?? "21世紀のデータはありません");
        var s = ym == null ? "21世紀のデータはありません" : ym.ToString();

        // 4-2-5
        var after1MonthList = new List<YearMonth>();
        foreach(var yem in yearMonthArr)
        {
            var newYm = yem.AddOneMonth();
            after1MonthList.Add(newYm);
        }
        after1MonthList.ForEach(ym => Console.WriteLine(ym.ToString()));
    }

    // 4-2-3
    static YearMonth FindYearMonth(YearMonth[] yearMonthArr)
    {
        foreach(var ym in yearMonthArr)
        {
            if(ym.Is21Century)
            {
                return ym;
            }
        }
        return null;
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
            // if (2001 <= Year && Year <= 2100 )
            // {
            //     return true;
            // }
            // return false;
            return 2001 <= Year && Year <= 2100;
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
