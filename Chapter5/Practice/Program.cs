namespace Chapter5.Practice;   
internal class Program
{
    static void Main(string[] args)
    {
        var str1 = Console.ReadLine();
        var str2 = Console.ReadLine();

        // 5-1
        if(String.Compare(str1, str2, ignoreCase: true) == 0)
        {
            Console.WriteLine($"5-1: str1:{str1}とstr2:{str2}は一致しています");
        }
        else
        {
            Console.WriteLine($"5-1: str1:{str1}とstr2:{str2}は不一致です");
        }
    }
}
