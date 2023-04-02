public class CyclingActivity: Activity
{    
    private float _speed;

    public CyclingActivity(DateOnly date, int minutesLength, float speed)
        : base(date, minutesLength)
    {        
        _speed = speed;
    }
    
    public override float GetDistance()
    {                
        float distance = (_speed/60)*GetMinutesLength();
        return distance;
    }

    public override float GetSpeed()
    {                
        return _speed;
    }

    public override float GetPace()
    {                
        float pace = 60/_speed;
        return pace;
    }
}