using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Michael Asamoah", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P055", 1.49, 10));

        Address address2 = new Address("45 King Street", "London", "England", "UK");
        Customer customer2 = new Customer("Deborah Asamoah", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N777", 5.99, 3));
        order2.AddProduct(new Product("Pencil", "P888", 0.99, 6));
        order2.AddProduct(new Product("Eraser", "E099", 0.49, 4));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}\n");

    }
}