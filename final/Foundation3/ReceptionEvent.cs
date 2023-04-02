class ReceptionEvent: Event
{        
    private string _rsvpEmail;
    private string _rsvpAnswer;    

    public ReceptionEvent(string title, string description, DateOnly date, TimeOnly time, Address address, string rsvpEmail, string rsvpAnswer)
        : base(title, description, date, time, address)
    {              
        _rsvpEmail = rsvpEmail;
        _rsvpAnswer = rsvpAnswer;
    }

    public void ReceptionFullDetailsMessage()
    {        
        FullDetailsMessage();
        Console.WriteLine($"Type Of event: {this.GetType().ToString()}");
        Console.WriteLine($"RSVP Email: {_rsvpEmail}");
        Console.WriteLine($"RSVP Answer: {_rsvpAnswer}\n");
    }     
}