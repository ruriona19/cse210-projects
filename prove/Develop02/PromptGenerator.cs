using System;

public class PromptGenerator 
{
    // public attribute that contains a list of prompts that will be provided to the user.
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    /// <summary>
    /// Get a random prompt from _prompts list
    /// </summary>
    /// <returns>A random prompt</returns>
    public string GetRamdomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0,5);
        return _prompts.ElementAt(index); 
    }

}