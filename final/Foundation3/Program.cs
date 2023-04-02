using System;

class Program
{    
    static void Main(string[] args)
    {
        DateOnly date1 = new DateOnly(2023,5,5);
        DateOnly date2 = new DateOnly(2023,6,6);
        DateOnly date3 = new DateOnly(2023,7,7);

        TimeOnly time1 = new TimeOnly(11,30);
        TimeOnly time2 = new TimeOnly(12,30);
        TimeOnly time3 = new TimeOnly(13,30);

        Address address1 = new Address("San Martin #415", "Tiquipaya", "Cochabamba", "Bolivia");
        Address address2 = new Address("Washington Av #713", "Salt Lake", "Utah", "USA");
        Address address3 = new Address("Brigham Youn Av #413", "Salt Lake", "Utah", "USA");       
        
        LectureEvent lecture = new LectureEvent("Lectures of faith", "Description title", 
                                                date1, time1, address1, "Speaker 1", 250);
        ReceptionEvent reception = new ReceptionEvent("Reception event title", "Reception Description", 
                                                      date2, time2, address2, "roberto.uriona@gmail.com", "Accept");
        OutdoorGatheringEvent outdoorGathering = new OutdoorGatheringEvent("Outdoor event title", "Outdoor Description", 
                                                                           date3, time3, address3, 23, 80);

        Console.WriteLine("Lecture Envent: ***********************************************");
        lecture.LectureFullDetailsMessage();
        lecture.StandardDetailsMessage();
        lecture.ShortDescriptionMessage(lecture.GetType().ToString());

        Console.WriteLine("Reception Envent: ***********************************************");
        reception.ReceptionFullDetailsMessage();
        reception.StandardDetailsMessage();
        reception.ShortDescriptionMessage(reception.GetType().ToString());

        Console.WriteLine("Outdoor Envent: ***********************************************");
        outdoorGathering.OutdoorFullDetailsMessage();
        outdoorGathering.StandardDetailsMessage();
        outdoorGathering.ShortDescriptionMessage(outdoorGathering.GetType().ToString());       
    }
}