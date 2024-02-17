public class Customer
{
    private string name;
    public Address Address { get; }

    public Customer(string name, Address address)
    {
        this.name = name;
        Address = address;
    }

    public string Name => name;
}
