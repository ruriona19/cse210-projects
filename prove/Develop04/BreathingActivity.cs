using System;
using System.Text.Json;
using System.Threading;

class BreathingActivity: Activity
{    
    // Contains the number of seconds to breathe in and breathe out. 
    private int _breatheInBreatheOutTime;


    public BreathingActivity()
    {
        _activityName = "Breathing";
        _activityDescription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _breatheInBreatheOutTime = 5;
    }

    /// <summary>
    /// Method to run the current activity
    /// </summary>         
    public void RunActivity()
    {        
        DisplayingStartingMessage();
        DisplayAnimation();
        BreatheInBreatheOutMessage();
        DisplayingEndingMessage();        
    }

   
    /// <summary>
    /// This method is on charge of display the Breathe In and Breathe Out message
    /// </summary>
    private void BreatheInBreatheOutMessage()
    {
        int breathingMessages = (_activityDurationTime/_breatheInBreatheOutTime)/2;
        for (int i = 0; i < breathingMessages; i++)
        {
            Console.Write("\n");
            for (int j = 5; j > 0; j--)
            {                                
                Console.Write($"Breathe in...{j}");    
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            }
            Console.Write($"Breathe in...\n");
            for (int k = 5; k > 0; k--)
            {
                Console.Write($"Now breathe out...{k}");    
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            }
            Console.Write($"Now breathe out...\n\n");
        }                
    }     
}