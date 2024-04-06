using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Transactions;

namespace Chapter2.DistanceConverter{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom")
            {
                PrintFeetToMeterList(1, 10);
            }
            else
            {
                PrintMeterToFeetList(1, 10);
            }
        }

        private static void PrintFeetToMeterList(int start, int stop)
        {
            for (int feet = start; feet <= stop; feet++)
            {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine($"{feet} ft = {meter} m");
            }
        }

        private static void PrintMeterToFeetList(int start, int stop)
        {
            for (int meter = 1; meter <= 10; meter++)
            {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter} m = {feet} ft");
            }
        }


    }

    /// <summary>
    /// 換算ロジックだけを抜き出した静的クラス
    /// </summary>
    public static class FeetConverter
    {
        // マジックナンバーの使用を控えるために定数を定義する
        // 他のクラスから参照させないものや今後変わらないものにはconst、参照されたり今後変わる可能性があるものはstatic readonlyをつける
        private const double Raito = 0.3048;

        public static double ToMeter(int feet)
        {
            return feet * Raito;
        }

        public static double FromMeter(int meter)
        {
            return meter / Raito;
        }
    }
}