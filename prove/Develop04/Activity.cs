using System;
using System.Text.Json;

class Activity
{    
    protected string _activityName;
    protected string _activityDescription;
    protected string _activityEndMessage;
    protected int _activityDurationTime;

    /// <summary>
    /// Displays the start message related to the current activity
    /// </summary>    
    protected void DisplayingStartingMessage()
    {
        Console.Clear(); 
        Console.WriteLine($"Welcome to the {_activityName} Activity  \n");
        Console.WriteLine($"{_activityDescription}\n"); 
        Console.WriteLine($"How long, in seconds, would you like for your session?");
        _activityDurationTime = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.Write("Get ready...");
    }

    /// <summary>
    /// Displays the ending message related to the current activity
    /// </summary>        
    protected void DisplayingEndingMessage()
    {   
        _activityEndMessage = $"You have completed another {_activityDurationTime} seconds of the {_activityName} Activity";
        Console.Write("\nWell done!!");
        DisplayAnimation();
        Console.Write($"\n{_activityEndMessage}");
        DisplayAnimation();
        Console.Clear();        
    }        

    /// <summary>
    /// Displays the Pusing/Animation functionality
    /// </summary>
    protected void DisplayAnimation()
    {        
        for (int i = 0; i < 5; i++)
        {
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the + character

             Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the + character

            Console.Write("-"); // Replace it with the - character
            Thread.Sleep(250);
            Console.Write("\b \b");

            Console.Write("/"); // Replace it with the - character
            Thread.Sleep(250);
            Console.Write("\b \b");
        }               
    }

    /// <summary>
    /// Displays the "You may begin" message
    /// </summary>    
    protected void YouMayBeginMessage()
    {
        for (int j = 5; j > 0; j--)
        {
            Console.Write($"You may begin in: {j}");    
            Thread.Sleep(1000);
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
        }
        Console.Write($"You may begin in:\n");
        Console.Clear();
    }

    /// <summary>
    /// Displays the prompt message related to the current activity
    /// </summary>    
    protected void DisplayPromptMessage(List<string> prompts, string promptMessage)
    {
        Random r = new Random();
        int index = r.Next(prompts.Count);
        string randomPrompt = prompts[index];

        Console.WriteLine($"\n{promptMessage}\n");
        Console.WriteLine($"---{randomPrompt}---\n");        
    }
}