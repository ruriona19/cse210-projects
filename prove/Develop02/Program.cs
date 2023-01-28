using System;

class Program
{       
    static void Main(string[] args)
    {
        Journal _journal = new Journal();         
        PromptGenerator _currentPrompt = new PromptGenerator();        
        bool showMenu = true;

        // This loop is on charge to show the main menu until the user select option 5 (Quit)
        while (showMenu)
        {   
            showMenu = MainMenu(_journal, _currentPrompt);
        }            
    }

    /// <summary>
    /// This funnction is responsible of display the main menu and
    /// interact with options selected by the user.
    /// </summary>
    private static bool MainMenu(Journal _journal, PromptGenerator _currentPrompt)
    {                
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("\r\nWhat would like to do? ");
        Entry currentEntry;
        string currentOption = Console.ReadLine();
        string currentPrompt;
        string promptResponse;

        switch (currentOption)
        {
            case "1":
                currentPrompt = _currentPrompt.GetRamdomPrompt();
                Console.WriteLine($"{currentPrompt}");
                promptResponse = Console.ReadLine();
                currentEntry = _journal.WriteEntry(currentPrompt, promptResponse);
                _journal._entries.Add(currentEntry);
                return true;
            case "2":   
                _journal.DisplayEntries();             
                return true;
            case "3":                
                _journal.LoadEntries(); 
                return true;
            case "4":
                _journal.SaveEntries();           
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }
}