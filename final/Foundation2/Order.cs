
public class Order 
{    
    private List<Product> _products;
    private Customer _customer;
        
    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double CalculateTotalProductsCost()
    {
        double totalProductCost = 0.00;
        foreach (var product in _products)
        {
            totalProductCost += product.GetTotalProductPrice();
        }

        totalProductCost = System.Math.Round(totalProductCost,2);
        return totalProductCost;
    }

    public void DisplayPackingLabel()
    {
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine("     Products:");
        foreach (var product in _products)
        {
            Console.WriteLine("     ================================");
            Console.WriteLine($"     Name:{product.GetName()}");
            Console.WriteLine($"     Id:{product.GetId()}");
            Console.WriteLine($"     Unit Price:{product.GetUnitPrice()}");
            Console.WriteLine($"     Quantity:{product.GetQuantity()}");
            Console.WriteLine("     ================================\n");
        }
    }

    public void DisplayShippingLabel()
    {
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine("     Customer:");        
        Console.WriteLine("     ================================");
        Console.WriteLine($"     Name:{_customer.GetName()}");
        Console.WriteLine($"     Adress:{_customer.GetAddress().GetFullAddress()}");
        Console.WriteLine("     ================================\n");        
    }

    public double GetShippingCost()
    {
        double shippingCost = 0.00;
        if (_customer.LiveInTheUSA())
        {   
            shippingCost = 5.00;
            return shippingCost;
        }
        else
        {
            shippingCost = 35.00;
            return shippingCost;
        }
    }

}