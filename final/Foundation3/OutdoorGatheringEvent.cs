class OutdoorGatheringEvent: Event
{        
    private int _temperature;
    private int _probabilityOfPrecipitation;

    public OutdoorGatheringEvent(string title, string description, DateOnly date, TimeOnly time, Address address, int temperature, int probabilityOfPrecipitation)
        : base(title, description, date, time, address)
    {              
        _temperature = temperature;
        _probabilityOfPrecipitation = probabilityOfPrecipitation;
    }

    public void OutdoorFullDetailsMessage()
    {        
        FullDetailsMessage();
        Console.WriteLine($"Type Of event: {this.GetType().ToString()}");
        Console.WriteLine($"Temperature: {_temperature.ToString()} ºC");
        Console.WriteLine($"Probability Of Precipitation: {_probabilityOfPrecipitation.ToString()}%\n");
    }     
}