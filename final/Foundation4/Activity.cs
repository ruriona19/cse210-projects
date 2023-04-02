public abstract class Activity
{    
    private DateOnly _date;
    private int _minutesLength;    

    public Activity(DateOnly date, int minutesLength)
    {        
        _date = date;
        _minutesLength = minutesLength;
    }
    
    public abstract float GetDistance();    

    public abstract float GetSpeed();    

    public abstract float GetPace();    

    public int GetMinutesLength()
    {
        return _minutesLength;
    }

    public void GetSummary(float distance, float speed, float pace)
    {                
        Console.WriteLine($"{_date.ToString("dd MMMM yyyy")} {this.GetType().ToString()} ({_minutesLength} min): Distance {distance} km, Speed: {speed} kph, Pace: {Math.Round(pace,1)} min per km");
    }
}