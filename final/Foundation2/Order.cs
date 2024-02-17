using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.TotalCost();
        }
        return totalPrice + GetShippingCost();
        }

    private decimal GetShippingCost()
    {
        return customer.Address.IsInUSA() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer: {customer.Name}\nAddress: {customer.Address.GetFullAddress()}";
    }
}
