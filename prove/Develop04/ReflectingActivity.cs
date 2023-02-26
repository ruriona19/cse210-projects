using System;
using System.Text.Json;
using System.Threading;

class ReflectingActivity: Activity
{    
    // Contains the list of prompts related to the current activity
    private List<string> _prompts;

    // Contains the list of QuestionToReflect objects
    private List<QuestionToReflect> _questionsToReflect;
    
    // Contains the start project message related to the current activity
    private string _startPromptMessage;

    public ReflectingActivity()
    {
        _activityName = "Reflecting";
        _activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _startPromptMessage = "Consider the following prompt:";
        _prompts = new List<string> 
                       {"Think of a time when you stood up for someone else.",
                        "Think of a time when you did something really difficult.",
                        "Think of a time when you helped someone in need.",
                        "Think of a time when you did something truly selfless."};
        _questionsToReflect = new List<QuestionToReflect>
                                  {new QuestionToReflect{Question = "Why was this experience meaningful to you?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "Have you ever done anything like this before?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "How did you get started?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "How did you feel when it was complete?", AlreadyDisplayed = false},                                   
                                   new QuestionToReflect{Question = "What made this time different than other times when you were not as successful?", AlreadyDisplayed = false},                                   
                                   new QuestionToReflect{Question = "What is your favorite thing about this experience?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "What could you learn from this experience that applies to other situations?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "What did you learn about yourself through this experience?", AlreadyDisplayed = false},
                                   new QuestionToReflect{Question = "How can you keep this experience in mind in the future?", AlreadyDisplayed = false}                                   
        };
    }
     
    /// <summary>
    /// Method to run the current activity
    /// </summary>          
    public void RunActivity()
    {                   
        DisplayingStartingMessage();                
        DisplayAnimation();
        DisplayPromptMessage(_prompts, _startPromptMessage);
        WhaitToHaveSomethingInMind();                
        YouMayBeginMessage();
        DisplayQuestions();     
        DisplayingEndingMessage();       
    }         
    
    /// <summary>
    /// Display the questions related to the random prompt shown in Reflecting Activity
    /// </summary>
    private void DisplayQuestions()
    {        
        Random r = new Random();
        int questionsToDisplay = _activityDurationTime/5;
        int questionsToReflectNumber = _questionsToReflect.Count;
        for (int i = 1; i <= questionsToDisplay; i++)
        {
            int index = r.Next(_questionsToReflect.Count);

            // Shows creativity and exceeds core requirements
            // Make sure no random prompts/questions are selected until they 
            // have all been used at least once in that session.
            if (_questionsToReflect[index].AlreadyDisplayed != true)
            {
                string randomQuestion = _questionsToReflect[index].Question;
                Console.Write($"\n> {randomQuestion}");
                DisplayAnimation();
                _questionsToReflect[index].AlreadyDisplayed = true;            
            }
            else
            {
                i--;
            }                                

            if (i == questionsToReflectNumber)
            {
                SetListOfQuestionsToReflectAvailable();
            }          
        }                        
    }   

    /// <summary>
    /// Set the list of questions flag to false
    /// </summary>
    private void SetListOfQuestionsToReflectAvailable()
    {        
        for (int i = 0; i < _questionsToReflect.Count; i++)
        {
            _questionsToReflect[i].AlreadyDisplayed = false;
        }
    }

    /// <summary>
    /// This method is on charge of show the message to wait until 
    /// the user have something on mind
    /// </summary>
    private void WhaitToHaveSomethingInMind()
    {
        ConsoleKeyInfo key;             
        Console.WriteLine("When you have something in mind, press enter to continue. \n");
        do
        {            
            key = Console.ReadKey(true);                
        }
        while (key.Key != ConsoleKey.Enter);         
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience:");
    }      
}