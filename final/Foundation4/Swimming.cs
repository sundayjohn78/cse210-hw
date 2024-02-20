using System;
public class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (DurationMinutes / 60.0); // Speed in kilometers per hour
    }

    public override double GetPace()
    {
        return DurationMinutes / GetDistance(); // Pace in minutes per kilometer
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Swimming: Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min/km";
    }
}
