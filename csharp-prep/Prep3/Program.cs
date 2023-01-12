using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int magicNumber = rnd.Next(100);
        bool magicNumberFound = false;
        while (!magicNumberFound)
        {
            Console.Write("What is your guess? ");
            int guessNumber2 = Int16.Parse(Console.ReadLine());
            if (guessNumber2 > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNumber2 < magicNumber)
            {
                Console.WriteLine("Higher");
            }                    
            else
            {
                Console.WriteLine("You guessed it!");
                magicNumberFound = true;
            }    
        } ;
    }
}