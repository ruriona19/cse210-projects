using System;

class Program
{    
    static void Main(string[] args)
    {                
        List<Product> products1 = new List<Product>
        {
            new Product("The Book of Mormon Hardcover","00001",3.50,3),
            new Product("Simulated Leather Bible","00002",30.00,2),
            new Product("Thumb-indexed Genuine Leather Quad Combination","00003",63.00,1)
        };

        List<Product> products2 = new List<Product>
        {
            new Product("Preach My Gospel","00004",9.25,2),
            new Product("Oil Vial Keychain","00005",3.05,3),
            new Product("Plastic Oil Vial","00006",7.60,2)
        };

        Address address1 = new Address("San Martin #415", "Tiquipaya", "Cochabamba", "Bolivia");
        Address address2 = new Address("Washington Av #713", "Salt Lake", "Utah", "USA");

        Customer customer1 = new Customer("Roberto Uriona", address1);
        Customer customer2 = new Customer("Chris Wells", address2);

        Order order1 = new Order(customer1, products1);
        Order order2 = new Order(customer2, products2);                    

        DisplayOrder(order1);
        DisplayOrder(order2);
    }
    
    private static void DisplayOrder(Order order)
    {    
        double totalCostOfProducts = order.CalculateTotalProductsCost();
        double shippingCost = order.GetShippingCost();
        double totalCostOfOrder = totalCostOfProducts + shippingCost;
        Console.WriteLine("\n\nOrder**********************************************************");            
        order.DisplayPackingLabel();
        order.DisplayShippingLabel();
        Console.WriteLine($"Total Products Cost: {totalCostOfProducts}");
        Console.WriteLine($"Shipping Cost: {shippingCost}");
        Console.WriteLine($"Total Order Cost: {totalCostOfOrder}");
        Console.WriteLine("***************************************************************");
    }    
}