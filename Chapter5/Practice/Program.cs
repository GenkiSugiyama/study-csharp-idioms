namespace Chapter5.Practice;   
internal class Program
{
    static void Main(string[] args)
    {
        // var str1 = Console.ReadLine();
        // var str2 = Console.ReadLine();

        // // 5-1
        // if(String.Compare(str1, str2, ignoreCase: true) == 0)
        // {
        //     Console.WriteLine($"5-1: str1:{str1}とstr2:{str2}は一致しています");
        // }
        // else
        // {
        //     Console.WriteLine($"5-1: str1:{str1}とstr2:{str2}は不一致です");
        // }

        // 5-2
        var str3 = Console.ReadLine();
        int.TryParse(str3, out int valueInt);
        var valueWithCanma = valueInt.ToString("#,0");
        Console.WriteLine(valueWithCanma);

        // 5-3
        var str4 = "Jackdaws love my big sphinx of quartz";

        // 5-3-1
        var spaceCount = str4.Count(car => car == ' ');
        Console.WriteLine($"空白文字の数: {spaceCount}");
    }
}
