using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome("Welcome to the Program!");
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squareFavoriteNumber = SquareNumber(favoriteNumber);
        DisplayResult(userName, squareFavoriteNumber);
    }

    static void DisplayWelcome(string welcomeMessage)
    {
        Console.WriteLine(welcomeMessage);
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        int favoriteNumber = Int16.Parse(Console.ReadLine());
        return favoriteNumber;
    }

    static int SquareNumber(int favoriteNumber)
    {
        int squareNumber = favoriteNumber*favoriteNumber;        
        return squareNumber;
    }

    static void DisplayResult(string userName, int number)
    {
        Console.WriteLine($"{userName}, the square of your number is {number}")
    }    
}