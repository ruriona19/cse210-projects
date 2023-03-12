using System;
using System.Text.Json;

class SimpleGoal: Goal
{    
    private bool _isComplete;
    
    public SimpleGoal(string name, string description, int amountOfPoints, bool isComplete = false)
    {
        _name = name;
        _description = description;
        _amountOfPoints = amountOfPoints;
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void DisplayGoal(int goalNumber)
    {
        string isCompletedCheck = " ";
        if (_isComplete)
        {
            isCompletedCheck = "X";
        }
        Console.WriteLine($"{goalNumber}. [{isCompletedCheck}] {_name} ({_description})");
    }     

    public override string GetGoalDetails()
    {
        string objectType = this.GetType().ToString();
        string goalDetails = $"{objectType}:{_name},{_description},{_amountOfPoints},{_isComplete}";
        return goalDetails;        
    }

}