using System;
using System.Diagnostics;

namespace Chapter3.Practice;

class Program
{
    static void Main(string[] args)
    {
        // 3-1
        var numbers = new List<int>{12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48};

        // 3-1-1
        var result1 = numbers.Exists(number => number % 8 ==0 || number % 9 == 0);
        Console.WriteLine($"3-1-1：{result1}");

        // 3-1-2
        numbers.ForEach(numbers => Console.WriteLine(numbers / 2.0));

        // 3-1-3
        var result3 = numbers.Where(num => num >= 50).ToList();
        result3.ForEach(val => Console.Write($"{val}, "));

        // 3-1-4
        var result4 = numbers.Select(numbers => numbers * 2).ToList();
        result4.ForEach(val => Console.Write($"{val}, "));

        // 3-2
        var names = new List<string>{"Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong"};

        // 3-2-1
        var input = Console.ReadLine();
        var index = names.FindIndex(name => name == input);
        Console.WriteLine($"3-2-1: {index}");

        // 3-2-2
        var count = names.Count(name => name.Contains('o'));
        Console.WriteLine($"3-2-2: {count}");

        // 3-2-3
        var array = names.Where(name => name.Contains('o')).ToList();
        array.ForEach(val => Console.WriteLine($"{val}, "));

        // 3-2-4
        var strCount = names.Where(name => name[0] == 'B').Select(name => name.Length).ToList();
        strCount.ForEach(val => Console.WriteLine($"{val}, "));

        Console.WriteLine("Hello, World!");
    }
}
