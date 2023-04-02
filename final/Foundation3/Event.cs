using System;
using System.Text.Json;

class Event
{    
    private string _title;
    private string _description;
    private DateOnly _date;
    private TimeOnly _time;
    private Address _address;

    public Event(string title, string description, DateOnly date, TimeOnly time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
    
    public void FullDetailsMessage()
    {        
        Console.WriteLine("Full Details");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Date: {_date.ToString()}");
        Console.WriteLine($"Time: {_time.ToString()}");
        Console.WriteLine($"Address: {_address.GetFullAddress()}");        
    }

    public void StandardDetailsMessage()
    {        
        Console.WriteLine("Standard Details");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Date: {_date.ToString()}");
        Console.WriteLine($"Time: {_time.ToString()}");
        Console.WriteLine($"Address: {_address.GetFullAddress()}\n");
    }

    public void ShortDescriptionMessage(string typeOfEvent)
    {        
        Console.WriteLine("Short Description");
        Console.WriteLine($"Type of event: {typeOfEvent}");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Date: {_date.ToString()}\n");
    }    
}