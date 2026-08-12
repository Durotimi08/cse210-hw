using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "A100", 25.99, 2));
        order1.AddProduct(new Product("Keyboard", "A101", 45.50, 1));
        order1.AddProduct(new Product("USB Cable", "A102", 8.75, 3));

        Address address2 = new Address("45 King Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("David Chen", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "B200", 189.99, 1));
        order2.AddProduct(new Product("HDMI Cable", "B201", 12.25, 2));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
    }
}
