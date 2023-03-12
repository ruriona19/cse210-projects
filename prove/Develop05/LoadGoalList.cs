using System;
using System.Text.Json;

class LoadGoalList
{    
    private List<Goal> _goals;    
    private int _gamePoints;    
    
    public LoadGoalList()
    {
        _goals = new List<Goal>();
        _gamePoints = 0;
    }

    public void ReadFromTxtFile(string fileName)
    {
             
        string[] lines = System.IO.File.ReadAllLines(fileName);
        
        for (int i = 0; i < lines.Count(); i++)
        {
            if (i == 0)
            {
                string temp = lines[i];
                _gamePoints = int.Parse(temp);
            }  
            else
            {                
                LoadGoalFromLine(lines[i]);
            }  
        }        
    }
    
    public int GetGamePoints()
    {
        return _gamePoints;
    }
    
    public List<Goal> GetGoalList()
    {
        return _goals;
    }

    public void LoadGoalFromLine(string line)
    {
        string[] parts = line.Split(":");
        string typeOfGoal = parts[0];
        string[] goalDetails = parts[1].Split(",");

        string goalName = goalDetails[0];
        string goalDescription = goalDetails[1];
        int goalAmountOfPoints = int.Parse(goalDetails[2]);                             

        if (String.Equals(typeOfGoal,"SimpleGoal"))
        {            
            bool isCompleted = bool.Parse(goalDetails[3]);
            Goal simpleGoal = new SimpleGoal(goalName, goalDescription, goalAmountOfPoints, isCompleted);
            _goals.Add(simpleGoal);
        }
        else if (String.Equals(typeOfGoal,"EternalGoal"))
        {            
            Goal eternalGoal = new EternalGoal(goalName, goalDescription, goalAmountOfPoints);
            _goals.Add(eternalGoal);
        }
        else if (String.Equals(typeOfGoal,"ChecklistGoal"))
        {            
            int goalNumberOfTimes = int.Parse(goalDetails[3]);                
            int goalBonusPoints = int.Parse(goalDetails[4]);
            int numberOfTimesCompleted = int.Parse(goalDetails[5]);
            Goal checkListGoal = new ChecklistGoal(goalName, goalDescription, goalAmountOfPoints, goalBonusPoints, goalNumberOfTimes, numberOfTimesCompleted);
            _goals.Add(checkListGoal);
        }        
    }
}