using System;

class Program
{
    static void Main(string[] args)
    {
        // Create customer
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        // Create products
        Product product1 = new Product("Widget", 1001, 10.99m, 2);
        Product product2 = new Product("Gadget", 1002, 19.99m, 1);

        // Create order
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Display order details
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalPrice());
    }
}
