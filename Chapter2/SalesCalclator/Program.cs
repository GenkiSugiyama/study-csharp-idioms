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
            SalesCounter sales = new SalesCounter(ReadSeals("sales.csv"));
            Dictionary<string, int> salesPerStore = sales.GetPerStoreSales();
            foreach(KeyValuePair<string, int> obj in salesPerStore)
            {
                Console.WriteLine($"店舗名：{obj.Key} 売上：{obj.Value}");
            }
        }

        static List<Sale> ReadSeals(string filePath)
        {
            // 返り値用のインスタンスを生成
            List<Sale> sales = new List<Sale>();

            // ファイルを読み込んだ結果を1行単位でlinesに格納
            string[] lines = File.ReadAllLines(filePath);

            // lines内の情報を１行ずつ処理する
            foreach(string line in lines)
            {
                // ファイルはCSVなのでカンマ区切りで情報を分ける
                string[] items = line.Split(",");
                // カンマ区切りで分けた情報でSaleオブジェクトを生成する
                Sale sale = new Sale(items[0], items[1], items[2]);
                // 返却用リストに追加する
                sales.Add(sale);
            }
            return sales;
        }
    }

    public class SalesCounter
    {
        private List<Sale> _sales;

        public SalesCounter(List<Sale> sales)
        {
            _sales = sales;
        }

        public Dictionary<string, int> GetPerStoreSales()
        {
            Dictionary<string, int> result = new Dictionary<string,int>();
            foreach (Sale sale in _sales)
            {
                // 店舗名が既存のキーと一致するかを確認
                if(result.ContainsKey(sale.ShopName))
                {
                    // 一致していたら既存キーの値に売上を加算
                    result[sale.ShopName] += sale.Amount;
                }
                else
                {
                    // 一致していなければ新しいキーの最初の売上として格納
                    result[sale.ShopName] = sale.Amount;
                }
            }
            return result;
        }
    }

    public class Sale
    {
        public string ShopName { get; set; }

        public string ProductCategory { get; set; }

        public int Amount { get; set; }

        public Sale(string shopName, string productCategory, string amount)
        {
            this.ShopName = shopName;
            this.ProductCategory = productCategory;
            this.Amount = int.Parse(amount);   
        }
    }
}