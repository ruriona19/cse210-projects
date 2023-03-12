using System;
using System.Text.Json;

abstract class Goal
{    
    protected string _name;
    protected string _description;
    protected int _amountOfPoints;

    
    public abstract void RecordEvent();
    
    public abstract void DisplayGoal(int goalNumber);

    public abstract bool IsComplete();

    public abstract string GetGoalDetails();

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetAmountOfPoints()
    {
        return _amountOfPoints;
    }        
}