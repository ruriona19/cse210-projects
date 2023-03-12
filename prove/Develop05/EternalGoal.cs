using System;
using System.Text.Json;
using System.Threading;

class EternalGoal: Goal
{    
        

    public EternalGoal(string name, string description, int amountOfPoints)
    {
        _name = name;
        _description = description;
        _amountOfPoints = amountOfPoints;        
    }   

    public override void RecordEvent()
    {
           
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void DisplayGoal(int goalNumber)
    {
        Console.WriteLine($"{goalNumber}. [ ] {_name} ({_description})");
    }          

    public override string GetGoalDetails()
    {
        string objectType = this.GetType().ToString();
        string goalDetails = $"{objectType}:{_name},{_description},{_amountOfPoints}";
        return goalDetails;        
    }
}