class LectureEvent: Event
{        
    private string _speaker;
    private int _limitedCapacity;

    public LectureEvent(string title, string description, DateOnly date, TimeOnly time, Address address, string speaker, int limitedCapacity)
        : base(title, description, date, time, address)
    {              
        _speaker = speaker;
        _limitedCapacity = limitedCapacity;
    }

    public void LectureFullDetailsMessage()
    {        
        FullDetailsMessage();
        Console.WriteLine($"Type Of event: {this.GetType().ToString()}");
        Console.WriteLine($"Speaker: {_speaker}");
        Console.WriteLine($"Limited Capacity: {_limitedCapacity}\n");
    }     
}