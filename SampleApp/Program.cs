using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Transactions;
using SampleApp.NameSpaceProduct;

namespace SampleApp{
    public class Program
    {
        static void Main(string[] args)
        {
            // new演算子を使ってクラスをインスタンス化する
            // 定義された変数karintoにインスタンスが直接格納されているわけではない
            // 変数karintoには生成されたインスタンスの参照（インスタンスが割り当てられたメモリのアドレス）が渡されている
            Product karinto = new Product(123, "かりんとう", 180);

            int price = karinto.Price;
            int taxIncludedPrice = karinto.GetPriceIncludingTax();
            // Console.WriteLine($"{karinto.Name}の税込み価格：{taxIncludedPrice}");

            // 演習問題
            // 1-1-1
            Product dorayaki = new Product(98, "どら焼き", 210);
            // 1-1-2
            Console.WriteLine($"{dorayaki.Name}の消費税額：{dorayaki.GetTax()}");
            // 1-1-3

            // 1-2-2
            MyClass myClass = new MyClass{X = 1, Y = 2};
            SampleStruct myStruct = new SampleStruct{X = 3, Y = 4};
            PrintObjects(myClass, myStruct);
            PrintObjects2(myClass, myStruct);
            Console.WriteLine("MyClass  : ({0},{1})", myClass.X, myClass.Y);
            Console.WriteLine("MyStruct : ({0},{1})", myStruct.X, myStruct.Y);
        }

        // 1-2-1
        static void PrintObjects(MyClass myClass, SampleStruct myStruct) {
            myClass.X *= 2;
            myClass.Y *= 2;
            myStruct.X *= 2;
            myStruct.Y *= 2;
            Console.WriteLine($"{myClass.X}, {myClass.Y}");
            Console.WriteLine($"{myStruct.X}, {myStruct.Y}");
        }

        static void PrintObjects2(MyClass myClass, SampleStruct myStruct) {
            myClass.X *= 2;
            myClass.Y *= 2;
            myStruct.X *= 2;
            myStruct.Y *= 2;
            Console.WriteLine($"{myClass.X}, {myClass.Y}");
            Console.WriteLine($"{myStruct.X}, {myStruct.Y}");
        }
    }

    // 1-2用
    class MyClass {
        public int X {get; set;}
        public int Y {get; set;}
    }

    // 構造体
    // クラスは変数にメモリのアドレスを渡すが、構造体はオブジェクトそのものを変数に渡す
    struct SampleStruct {
        public int X {get; set;}
        public int Y {get; set;}
    }
}


namespace SampleApp.NameSpaceProduct {
    class Product {
    // プロパティのセッターをprivateにすることで利用者はコンストラクタでしか値をセットできない
    public int Code {get; private set;}
    public string Name {get; private set;}
    public int Price {get; private set;}

    public Product(int code, string name, int price) {
        this.Code = code;
        this.Name = name;
        this.Price = price;
    }

    /// <summary>
    /// 消費税額を求める
    /// </summary>
    /// <returns>商品の消費税額</returns>
    public int GetTax() {
        return (int)(Price * 0.1);
    }

    /// <summary>
    /// 消費税込みの金額を求める
    /// </summary>
    /// <returns>税込み金額</returns>
    public int GetPriceIncludingTax() {
        return Price + GetTax();
    }
}
}