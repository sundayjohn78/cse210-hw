public class Lecture : Event
{
    public string SpeakerName { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        SpeakerName = speakerName;
        Capacity = capacity;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {SpeakerName}\nCapacity: {Capacity}";
    }
}
