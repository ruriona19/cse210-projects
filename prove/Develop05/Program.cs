using System;
using System.Runtime.InteropServices;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int gamePoints = 0;

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
        Console.WriteLine($"\r\nYou have {gamePoints} points.\r\n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");        
        Console.WriteLine("2. List Goals");        
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("\r\nSelect a choice from the menu: ");        
        string currentOption = Console.ReadLine();                

        switch (currentOption)
        {            
            case "1":
                TypesOfGoal();
                return true;
            case "2":
                int itemNumber = 1;
                Console.WriteLine("Goals to meet:\n");
                foreach (Goal goal in goals)
                {
                    if (!goal.IsComplete())
                    {
                        goal.DisplayGoal(itemNumber);
                        itemNumber++;   
                    }
                }
                itemNumber = 1;
                Console.WriteLine("\nCompleted Goals:\n");
                foreach (Goal goal in goals)
                {
                    if (goal.IsComplete())
                    {
                        goal.DisplayGoal(itemNumber);
                        itemNumber++;
                    }                    
                }
                return true;
            case "3":
                SaveGoalList saveGoalList = new SaveGoalList(goals, gamePoints);   
                saveGoalList.WriteToTxtFile("goals.txt");
                return true;
            case "4":                 
                LoadGoalList loadGoalList = new LoadGoalList();
                loadGoalList.ReadFromTxtFile("goals.txt");
                gamePoints = loadGoalList.GetGamePoints();
                goals = loadGoalList.GetGoalList();
                return true;
            case "5": 
                itemNumber = 1;
                Console.WriteLine("Goals to meet:");
                foreach (Goal goal in goals)
                {
                    if (!goal.IsComplete())
                    {
                        Console.WriteLine($"{itemNumber}. {goal.GetName()}");
                        itemNumber ++;
                    }
                }
                Console.Write("\r\nWhich goal did you acomplish? ");
                int goalAccomplishedItem = int.Parse(Console.ReadLine());
                RecordEvent(goals[goalAccomplishedItem - 1].GetType().ToString(), goals[goalAccomplishedItem - 1].GetName());
                Console.Write($"\r\nCongratulations! You have earned {goals[goalAccomplishedItem - 1].GetAmountOfPoints()}!");
                Console.Write($"\r\nYou now have {gamePoints} points.\n");
                SaveGoalList saveGoalList2 = new SaveGoalList(goals, gamePoints);
                saveGoalList2.WriteToTxtFile("goals.txt");
                LoadGoalList loadGoalList2 = new LoadGoalList();
                loadGoalList2.ReadFromTxtFile("goals.txt");
                gamePoints = loadGoalList2.GetGamePoints();
                goals = loadGoalList2.GetGoalList();
                return true;
            case "6":
                return false;
            default:
                return true;
        }
    }

    public static bool TypesOfGoal()
    {                
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\r\nWhich type of goal would you like to create? ");
        string typeOfGoal = Console.ReadLine();
        string goalName;
        string goalDescription;
        int goalAmountOfPoints;
        int goalNumberOfTimes;            
        int goalBonusPoints;
                
        switch (typeOfGoal)
        {
            case "1":                         
                Console.Write("\r\nWhat is the name of your goal? ");
                goalName = Console.ReadLine();
                Console.Write("\r\nWhat is a short description of it? ");
                goalDescription = Console.ReadLine();
                Console.Write("\r\nWhat is the amount of points associated with this goal? ");
                goalAmountOfPoints = int.Parse(Console.ReadLine());
                Goal simpleGoal = new SimpleGoal(goalName, goalDescription, goalAmountOfPoints);
                goals.Add(simpleGoal);
                return true;
            case "2":
                Console.Write("\r\nWhat is the name of your goal? ");
                goalName = Console.ReadLine();
                Console.Write("\r\nWhat is a short description of it? ");
                goalDescription = Console.ReadLine();
                Console.Write("\r\nWhat is the amount of points associated with this goal? ");
                goalAmountOfPoints = int.Parse(Console.ReadLine());
                Goal eternalGoal = new EternalGoal(goalName, goalDescription, goalAmountOfPoints);
                goals.Add(eternalGoal);
                return true;
            case "3":
                Console.Write("\r\nWhat is the name of your goal? ");
                goalName = Console.ReadLine();
                Console.Write("\r\nWhat is a short description of it? ");
                goalDescription = Console.ReadLine();
                Console.Write("\r\nWhat is the amount of points associated with this goal? ");
                goalAmountOfPoints = int.Parse(Console.ReadLine());
                Console.Write("\r\nHow many times does this goal need to be accomplished for a bonus? ");
                goalNumberOfTimes = int.Parse(Console.ReadLine());
                Console.Write("\r\nWhat is the bonus for accomplishing it that many times? ");
                goalBonusPoints = int.Parse(Console.ReadLine());
                Goal checkListGoal = new ChecklistGoal(goalName, goalDescription, goalAmountOfPoints, goalNumberOfTimes, goalBonusPoints);
                goals.Add(checkListGoal);
                return true;
            default:
                return true;
        }
    }

    public static void RecordEvent(string typeOfGoal,string goalName)
    {                               
        string currentTypeOfGoal;
        string currentGoalName;
                
        for (int i = 0; i < goals.Count; i++)
        {
            currentTypeOfGoal = goals[i].GetType().ToString();
            currentGoalName = goals[i].GetName();
            if (currentTypeOfGoal.Equals(typeOfGoal) && currentGoalName.Equals(goalName))
            {
                goals[i].RecordEvent();
                gamePoints += goals[i].GetAmountOfPoints();                
                
                if (currentTypeOfGoal.Equals("ChecklistGoal"))
                {   
                    ChecklistGoal checklistGoal = (ChecklistGoal)goals[i];
                    gamePoints += checklistGoal.GetBonusPoints();                    
                }
                break;
            }            
        }                             
    }
}