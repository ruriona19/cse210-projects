using System;

class Program
{
    static void Main(string[] args)
    {                
        // Boolean attribute that is used to keep showing the main menu
        bool showMenu = true;

        
        while (showMenu)
        {   
            showMenu = MainMenu();
        }                  
    }

    // This method is on charge of displaying the main menu
    private static bool MainMenu()
    {                
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");        
        Console.WriteLine("2. Start reflecting activity");        
        Console.WriteLine("3. Start listining activity");
        Console.WriteLine("4. Quit");
        Console.Write("\r\nSelect a choice from the menu: ");        
        string currentOption = Console.ReadLine();
        
        switch (currentOption)
        {
            case "1":
                BreathingActivity _breathe = new BreathingActivity();
                _breathe.RunActivity();
                return true;
            case "2":
                ReflectingActivity _reflect = new ReflectingActivity();
                _reflect.RunActivity();
                return true;
            case "3":
                ListingActivity _listing = new ListingActivity();
                _listing.RunActivity();
                return true; 
            case "4":                
                return false; 
            default:
                return true;
        }
    }
}