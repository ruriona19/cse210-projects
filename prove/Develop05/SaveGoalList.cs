using System;
using System.Text.Json;

class SaveGoalList
{    
    private List<Goal> _goals;    
    private int _gamePoints;    

    public SaveGoalList(List<Goal> goals, int gamePoints)
    {
        _goals = goals;
        _gamePoints = gamePoints;                
    }

    public void WriteToTxtFile(string fileName)
    {
       using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // You can add text to the file with the WriteLine method
            outputFile.WriteLine(_gamePoints);
                                                
            foreach (Goal goal in _goals)
            {                
                if (!goal.IsComplete())
                {
                    outputFile.WriteLine(goal.GetGoalDetails());   
                }                
            }
            foreach (Goal goal in _goals)
            {                
                if (goal.IsComplete())
                {
                    outputFile.WriteLine(goal.GetGoalDetails());   
                }                
            }
        } 
    }
    
}