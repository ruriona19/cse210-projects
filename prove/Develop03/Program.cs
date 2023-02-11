using System;

class Program
{
    static void Main(string[] args)
    {
        // Declaring scripture object
        Scripture _scripture;
        // Boolean attribute that is used to keep showing the main menu
        bool showMenu = true;

        
        while (showMenu)
        {   _scripture = new Scripture();
            showMenu = MainMenu(_scripture);
        }                  
    }

    // This method is on charge of displaying the main menu
    private static bool MainMenu(Scripture _scripture)
    {                
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Save Scripture");        
        Console.WriteLine("2. Memorize Scripture");        
        Console.WriteLine("3. Quit");
        Console.Write("\r\nWhat would like to do? ");        
        string currentOption = Console.ReadLine();
        
        switch (currentOption)
        {
            case "1":
                _scripture.SaveScripture();
                return true;
            case "2":
                _scripture.LoadScriptureToMemorize();
                return true;
            case "3":                
                return false; 
            default:
                return true;
        }
    }
}