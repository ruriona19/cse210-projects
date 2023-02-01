using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fn1 = new Fraction();
        Console.WriteLine($"{fn1.GetTop()}/{fn1.GetBottom()}");
        Fraction fn2 = new Fraction(5);
        Console.WriteLine($"{fn2.GetTop()}/{fn2.GetBottom()}");
        Fraction fn3 = new Fraction(3,4); 
        Console.WriteLine($"{fn3.GetTop()}/{fn3.GetBottom()}");
        Fraction fn4 = new Fraction(1,3); 
        Console.WriteLine($"{fn4.GetTop()}/{fn4.GetBottom()}");
        Console.WriteLine($"{fn4.GetDecimalValue()}");
    }
}