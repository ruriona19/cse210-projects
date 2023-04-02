public class RunningActivity: Activity
{    
    private float _distance;

    public RunningActivity(DateOnly date, int minutesLength, float distance)
        : base(date, minutesLength)
    {        
        _distance = distance;
    }
    
    public override float GetDistance()
    {                
        return _distance;
    }

    public override float GetSpeed()
    {       
        float speed = (_distance/GetMinutesLength())*60;
        return speed;
    }

    public override float GetPace()
    {                
        float pace = GetMinutesLength()/_distance;
        return pace;
    }    
}