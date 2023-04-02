public class SwimmingActivity: Activity
{    
    private int _numberOfLaps;

    public SwimmingActivity(DateOnly date, int minutesLength, int numberOfLaps)
        : base(date, minutesLength)
    {   
        _numberOfLaps = numberOfLaps;
    }
    
    public override float GetDistance()
    {                
        float distance = (_numberOfLaps * 50)/1000;
        return distance;
    }

    public override float GetSpeed()
    {                
        float distance = GetDistance();
        float speed = (distance/GetMinutesLength())*60;
        return speed;
    }

    public override float GetPace()
    {                
        float pace = 60/GetSpeed();
        return pace;
    }
}