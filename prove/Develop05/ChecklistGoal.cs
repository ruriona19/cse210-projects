using System;
using System.Text.Json;
using System.Threading;

class ChecklistGoal: Goal
{    
    private int _bonusPoints;
    private int _numberOfTimes;
    private int _numberOfTimesCompleted;

    public ChecklistGoal(string name, string description, int amountOfPoints, int numberOfTimes, int bonusPoints, int numberOfTimesCompleted = 0)
    {
        _name = name;
        _description = description;
        _amountOfPoints = amountOfPoints;        
        _numberOfTimes = numberOfTimes;
        _bonusPoints = bonusPoints;
        _numberOfTimesCompleted = numberOfTimesCompleted;
    } 

    public override void RecordEvent()
    {
        _numberOfTimesCompleted += 1; 
    }

    public override void DisplayGoal(int goalNumber)
    {
        string isCompletedCheck = " ";
        if (_numberOfTimesCompleted == 3)
        {
            isCompletedCheck = "X";
        }
        Console.WriteLine($"{goalNumber}. [{isCompletedCheck}] {_name} ({_description}) -- Currently completed: {_numberOfTimesCompleted}/{_numberOfTimes}");
    }   

    public override bool IsComplete()
    {
        if (_numberOfTimesCompleted < _numberOfTimes)
        {
            return false;
        }
        else
        {
            return true;
        }        
    }   

    public override string GetGoalDetails()
    {
        string objectType = this.GetType().ToString();
        string goalDetails = $"{objectType}:{_name},{_description},{_amountOfPoints},{_bonusPoints},{_numberOfTimes},{_numberOfTimesCompleted}";

        return goalDetails;        
    }

    public int GetBonusPoints()
    {
        if (_numberOfTimesCompleted == 3)
        {
            return _bonusPoints;    
        }
        else
        {
            return 0;   
        }        
    }
}