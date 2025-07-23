using System.Net.Sockets;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA() => _address.IsInUSA();

    public string GetName() => _name;
    public string GetShippingAddress() => _address.GetFullAddress();
}