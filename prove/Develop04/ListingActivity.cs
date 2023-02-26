using System;
using System.Text.Json;
using System.Threading;

class ListingActivity: Activity
{    
    // Contains the list of prompts related to the current activity
    private List<string> _prompts;
    
    // Contains the start project message related to the current activity
    private string _startPromptMessage;

    public ListingActivity()
    {
        _activityName = "Listing";
        _activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _startPromptMessage = "List as many reponses you can to the following prompt:";
        _prompts = new List<string> 
                       {"Who are people that you appreciate?",
                        "What are personal strengths of yours?",
                        "Who are people that you have helped this week?",
                        "When have you felt the Holy Ghost this month?",
                        "Who are some of your personal heroes?"};        
    }

    /// <summary>
    /// Method to run the current activity
    /// </summary>           
    public void RunActivity()
    {        
        DisplayingStartingMessage();        
        DisplayAnimation();    
        DisplayPromptMessage(_prompts, _startPromptMessage);
        YouMayBeginMessage();        
        MakeList();                        
        DisplayingEndingMessage();    
    }

    /// <summary>
    /// This method is on charge of let the user enter the list of items and 
    /// show the number of items entered by the user
    /// </summary>   
    private void MakeList()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_activityDurationTime);       
        int count = 0;
        do
        {
            Console.Write("> ");
            Console.ReadLine();    
            count++;
        } while (DateTime.Now < futureTime);
        Console.Write($"\nYou listed {count} items!\n");
    }
}