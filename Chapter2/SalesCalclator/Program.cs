using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Transactions;

namespace Chapter2.SalesCalclator{
    public class Program
    {
        static void Main(string[] args)
        {
            var sales = new SalesCounter("sales.csv");
            IDictionary<string, int> salesPerStore = sales.GetPerStoreSales();
            foreach(var obj in salesPerStore)
            {
                Console.WriteLine($"店舗名：{obj.Key} 売上：{obj.Value}");
            }
        }
    }
}