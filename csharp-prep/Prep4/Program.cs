using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;        

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while(number != 0)
        {
            Console.WriteLine("Enter number:");
            number = Int16.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);   
            }            
        }                
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
    }
}