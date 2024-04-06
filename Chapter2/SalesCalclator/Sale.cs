namespace Chapter2.SalesCalclator;

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
