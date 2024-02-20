using System;

public class Running : Activity
{
    private double Distance { get; set; }

    public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (DurationMinutes / 60.0); // Speed in miles per hour
    }

    public override double GetPace()
    {
        return DurationMinutes / Distance; // Pace in minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Running: Distance {Distance:F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min/mile";
    }
}
