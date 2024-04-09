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

            // ラムダ式理解のための助長なコード
            // Countメソッドに渡す判定式をもっとも助長な書き方でjudgeに渡している
            // Predicate<int> judge =
            //     (int n) => {
            //         if (n % 2 == 0)
            //         {
            //             return true;
            //         }
            //         else
            //         {
            //             return false;
            //         }
            //     };
            // Countメソッドに渡すためだけの変数は無駄なので直接ラムダ式をCountメソッドに渡す
            // 上記if文を１行でかける
            // &&ラムダ式の{}内の文が1行なら{}とreturnを省略できる
            // &&ラムダ式では引数の型を省略できる
            // &&ラムダ式の引数が1つの場合は()を省略できる
            // 以下が今回のラムダ式の最終系
            var result = Count(numbers, n => n % 2 == 0);
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
        // Predicateの登場によりdelegateに渡すメソッドを定義する必要がなくなった（※Predicateはboolを返す判定用のデリゲート）
        // ※処理が複雑な場合は可読性を考えて別で定義したものをdelegateに渡したい
        // public static bool IsEven(int n)
        // {
        //     return n % 2 == 0;
        // }
    }
}