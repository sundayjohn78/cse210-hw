using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Los Angeles", "CA", "USA");
        Address address3 = new Address("789 Elm Blvd", "Chicago", "IL", "USA");

        // Create events
        Event lectureEvent = new Lecture("Tech Talk", "Exciting new technologies", DateTime.Now, "10:00 AM", address1, "John Sunday", 50);
        Event receptionEvent = new Reception("Networking Mixer", "Meet and greet with industry professionals", DateTime.Now, "6:00 PM", address2, "rsvp@example.com");
        Event outdoorEvent = new OutdoorGathering("Picnic in the Park", "Enjoy a day outdoors", DateTime.Now, "12:00 PM", address3, "Sunny skies");

        // Generate marketing messages
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(((Lecture)lectureEvent).GetFullDetails());
        Console.WriteLine(((Reception)receptionEvent).GetFullDetails());
        Console.WriteLine(((OutdoorGathering)outdoorEvent).GetFullDetails());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
