using System;
using System.Diagnostics;

namespace Chapter3.Lambda
{
    internal class Program
    {
        // デリゲート（委託する、派遣する）の定義
        // このデリゲートには「int型の値を引数にとり、bool値の値を返すメソッド」を渡せる
        // このデリゲートに「int型の値を引数にとり、bool値の値を返すメソッド」を「移譲する」ってイメージ？
        // public delegate bool Judgement(int value);

        static void Main(string[] args)
        {
            var numbers = new[] {1, 4, 4, 2, 5, 7, 6};

            // IsEvenメソッドをJudgementデリゲートに渡す
            // Judgement judge = IsEven;

            // デリゲート用変数だけじゃなくIsEvenメソッドを直接渡すこともできる
            // var result = Count(numbers, IsEven);
            // Predicateを使ってCountメソッド呼び出し時にメソッドに渡したい処理を直接記述している
            var result = Count(numbers, delegate(int n){ return n % 2 == 0; });
            Console.WriteLine(result);
        }

        // 渡された配列の中からJudgementデリゲートに渡された判定条件を満たす値の個数をカウントする
        // Predicateデリゲートを引数に使用してメソッドを定義することで、メソッド呼び出し箇所でdelegateキーワードを使って渡すメソッドを直接宣言している
        public static int Count(int[] numbers, Predicate<int> judge)
        {
            int count = 0;
            foreach(var num in numbers)
            {
                if(judge(num))
                {
                    count ++;
                }
            }

            return count;
        }

        // 渡された数値が2の倍数かを判定するメソッド
        // このメソッドをJudgementデリゲートに渡す
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}