public class Product
{
    // Properties
    public string Name { get; }
    public int ProductId { get; }
    private decimal Price { get; }
    private int Quantity { get; }

    // Constructor
    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    // Method to calculate total cost of the product
    public decimal TotalCost()
    {
        return Price * Quantity;
    }
}
